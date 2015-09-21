using System;
using System.Threading;
using System.IO;

namespace ChecksumLib
{
    class AdditionChecksum
    {
        //
        // Constants
        //
        const int NUM_OF_THREADS = 20;

        //
        // Global Variables
        //
        private object Locker = new object();
        private int FinishThreadCount = 0;

        //
        // Properties
        //
        private UInt16 _Checksum = 0;

        //
        // Structures
        //
        public struct PartialChecksumCalcThreadParam
        {
            public Byte[] PartialStream;
            public long StreamSize;
        }

        //
        // Procedure: CalcChecksum
        //
        public void CalcChecksum(string Filename, out UInt16 Checksum)
        {
            Byte[] Buffer;
            Byte[][] PartialBuffers;

            Checksum = 0;

            Buffer = File.ReadAllBytes(Filename);

            if (Buffer.Length < NUM_OF_THREADS)
            {
                Checksum = 0;

                for (int i = 0; i < Buffer.Length; i++)
                {
                    Checksum += Buffer[i];
                }
            }
            else
            {
                // Clear _Checksum
                _Checksum = 0;

                // Assign memory to PartialBuffers & copy partial file stream to these buffers
                PartialBuffers = new Byte[NUM_OF_THREADS][];
                for (int i = 0; i < NUM_OF_THREADS - 1; i++)
                {
                    PartialBuffers[i] = new Byte[(int)Buffer.Length / (NUM_OF_THREADS - 1)];
                    System.Buffer.BlockCopy(Buffer, i * ((int)Buffer.Length / (NUM_OF_THREADS - 1)), PartialBuffers[i], 0, (int)Buffer.Length / (NUM_OF_THREADS - 1));
                }

                PartialBuffers[NUM_OF_THREADS - 1] = new Byte[Buffer.Length % (NUM_OF_THREADS - 1)];
                System.Buffer.BlockCopy(Buffer, ((int)Buffer.Length / (NUM_OF_THREADS - 1)) * (NUM_OF_THREADS - 1), PartialBuffers[NUM_OF_THREADS - 1], 0, (int)Buffer.Length - ((int)Buffer.Length / (NUM_OF_THREADS - 1)) * (NUM_OF_THREADS - 1));

                // Create threads used to calculate partial checksum values
                for (int i = 0; i < NUM_OF_THREADS; i++)
                {
                    PartialChecksumCalcThreadParam Param;

                    Param.PartialStream = PartialBuffers[i];

                    if (i < NUM_OF_THREADS - 1)
                    {
                        Param.StreamSize = (int)Buffer.Length / (NUM_OF_THREADS - 1);
                    }
                    else
                    {
                        Param.StreamSize = (int)Buffer.Length - ((int)Buffer.Length / (NUM_OF_THREADS - 1)) * (NUM_OF_THREADS - 1);
                    }

                    Thread CalcThread = new Thread(new ParameterizedThreadStart(PartialChecksumCalcThread));
                    CalcThread.Start(Param);
                }

                lock (Locker)
                {
                    while (FinishThreadCount != NUM_OF_THREADS)
                    {
                        Monitor.Wait(Locker);
                    }
                }

                FinishThreadCount = 0;

                Checksum = _Checksum;
            }
        }

        //
        // Thread Method: PartialChecksumCalcThread
        //
        private void PartialChecksumCalcThread(object Obj)
        {
            PartialChecksumCalcThreadParam Param = (PartialChecksumCalcThreadParam)Obj;
            UInt16 PartialChecksum = 0;

            for (int i = 0; i < Param.StreamSize; i++)
            {
                PartialChecksum += Param.PartialStream[i];
            }

            lock (Locker)
            {
                _Checksum += PartialChecksum;
                FinishThreadCount++;
                Monitor.Pulse(Locker);
            }
        }
    }
}
