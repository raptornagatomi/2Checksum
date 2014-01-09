using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _2Checksum
{
    //
    // Partial Calss: Form1
    //
    public partial class Form1 : Form
    {
        const int MAX_THREAD_NUM = 20;

        private _FileInformation FileInformation = new _FileInformation();
        private object Locker = new object();
        private int FinishThreadCount = 0;
        private uint Checksum = 0U;

        public Form1()
        {
            InitializeComponent();
        }

        //
        // Procedure: Button_Browse_Click
        //
        private void Button_Browse_Click(object sender, EventArgs e)
        {
            FileStream FileToCalc;

            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Retrieve FileInformation
                FileToCalc = File.Open(OpenFileDialog.FileName, FileMode.Open, FileAccess.Read);

                FileInformation.Filename = OpenFileDialog.FileName;
                FileInformation.FileTime = File.GetLastWriteTime(OpenFileDialog.FileName);
                FileInformation.FileSize = FileToCalc.Length;

                FileToCalc.Close();

                // Calculate checksum
                CalcChecksum(FileInformation.Filename, FileInformation.FileSize, MAX_THREAD_NUM);
                FileInformation.Checksum = Checksum;

                // Display & Update file information
                DisplayAndUpdateFileInformation();
            }
        }

        //
        // Procedure: DisplayAndUpdateFileInformation
        //
        private void DisplayAndUpdateFileInformation()
        {
            const string STR_FILENAME_PROMPT = "Filename    : ";
            const string STR_FILEDATE_PROMPT = "File date   : ";
            const string STR_FILESIZE_PROMPT = "File size   : ";
            const string STR_CHECKSUM_PROMPT = "Checksum    : ";

            RichTextBox_FileInfo.Clear();
            RichTextBox_FileInfo.AppendText(STR_FILENAME_PROMPT + Path.GetFileName(FileInformation.Filename) + "\n");
            RichTextBox_FileInfo.AppendText(STR_FILEDATE_PROMPT + FileInformation.FileTime.ToString() + "\n");
            RichTextBox_FileInfo.AppendText(STR_FILESIZE_PROMPT + FileInformation.FileSize.ToString() + " bytes\n");

            if(RadioButton_4digitChecksum.Checked)
                RichTextBox_FileInfo.AppendText(STR_CHECKSUM_PROMPT + String.Format("{0,4:X4}", (FileInformation.Checksum & 0xFFFF)) + "h\n");
            else
                RichTextBox_FileInfo.AppendText(STR_CHECKSUM_PROMPT + String.Format("{0,8:X8}", (FileInformation.Checksum & 0xFFFFFFFF)) + "h\n");
        }

        //
        // Procedure: CalcChecksum
        //
        private void CalcChecksum(string FilePath, long FileSize, int NumOfThreads)
        {
            Byte[] StreamBuffer;
            Byte[][] PartialStreamBuffer;

            Checksum = 0U;
            StreamBuffer = File.ReadAllBytes(FilePath);

            if (FileSize < NumOfThreads)
            {
                Checksum = 0U;

                for (int i = 0; i < FileSize; i++)
                {
                    Checksum += StreamBuffer[i];
                }
            }
            else
            {
                // Assign memory to PartialStreamBuffer & copy partial file stream to the buffer
                PartialStreamBuffer = new Byte[NumOfThreads][];
                for (int i = 0; i < NumOfThreads - 1; i++)
                {
                    PartialStreamBuffer[i] = new Byte[(int)FileSize / (NumOfThreads - 1)];
                    Buffer.BlockCopy(StreamBuffer, i * ((int)FileSize / (NumOfThreads - 1)), PartialStreamBuffer[i], 0, (int)FileSize / (NumOfThreads - 1));
                }

                PartialStreamBuffer[NumOfThreads - 1] = new Byte[FileSize % (NumOfThreads - 1)];
                Buffer.BlockCopy(StreamBuffer, ((int)FileSize / (NumOfThreads - 1)) * (NumOfThreads - 1), PartialStreamBuffer[NumOfThreads - 1], 0, (int)FileSize - ((int)FileSize / (NumOfThreads - 1)) * (NumOfThreads - 1));

                // Create threads used to calculate partial checksum values
                for (int i = 0; i < NumOfThreads; i++)
                {
                    PartialChecksumCalcThreadParam Param = new PartialChecksumCalcThreadParam();

                    Param.PartialStream = PartialStreamBuffer[i];

                    if (i < NumOfThreads - 1)
                    {
                        Param.StreamSize = (int)FileSize / (NumOfThreads - 1);
                    }
                    else
                    {
                        Param.StreamSize = (int)FileSize - ((int)FileSize / (NumOfThreads - 1)) * (NumOfThreads - 1);
                    }

                    Thread CalcThread = new Thread(new ParameterizedThreadStart(PartialChecksumCalcThread));
                    CalcThread.Start(Param);
                }

                lock (Locker)
                {
                    while (FinishThreadCount != MAX_THREAD_NUM)
                    {
                        Monitor.Wait(Locker);
                    }
                }

                FinishThreadCount = 0;
            }
        }

        //
        // Thread Method: PartialChecksumCalcThread
        //
        private void PartialChecksumCalcThread(object Obj)
        {
            PartialChecksumCalcThreadParam Param = (PartialChecksumCalcThreadParam)Obj;
            uint PartialChecksum = 0U;

            for (int i = 0; i < Param.StreamSize; i++)
            {
                PartialChecksum += Param.PartialStream[i];
            }

            lock (Locker)
            {
                Checksum += PartialChecksum;
                FinishThreadCount++;
                Monitor.Pulse(Locker);
            }
        }

        //
        // RadioButton_4digitChecksum_CheckedChanged
        //
        private void RadioButton_4digitChecksum_CheckedChanged(object sender, EventArgs e)
        {
            // Display & Update file information
            DisplayAndUpdateFileInformation();
        }

        //
        // RadioButton_8digitChecksum_CheckedChanged
        //
        private void RadioButton_8digitChecksum_CheckedChanged(object sender, EventArgs e)
        {
            // Display & Update file information
            DisplayAndUpdateFileInformation();
        }
    }

    //
    // Class: _FileInformation
    //
    class _FileInformation
    {
        private string _Filename = "N/A";
        private DateTime _FileTime = new DateTime();
        private long _FileSize = 0;
        private uint _Checksum = 0U;

        // Attribute: Filename
        public string Filename
        {
            get
            {
                return _Filename;
            }

            set
            {
                _Filename = value;
            }
        }

        // Attribute: FileTime
        public DateTime FileTime
        {
            get
            {
                return _FileTime;
            }

            set
            {
                _FileTime = value;
            }
        }

        // Attribute: FileSize
        public long FileSize
        {
            get
            {
                return _FileSize;
            }

            set
            {
                _FileSize = value;
            }
        }

        // Attribute: Checksum
        public uint Checksum
        {
            get
            {
                return _Checksum;
            }

            set
            {
                _Checksum = value;
            }
        }
    }

    //
    // Class: PartialChecksumCalcThreadParam
    //
    public class PartialChecksumCalcThreadParam
    {
        public Byte[] PartialStream;
        public long StreamSize;
    }
}
