//-------------------------------------------------------------------------------------------------
//
// Usings
//
//-------------------------------------------------------------------------------------------------
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

//-------------------------------------------------------------------------------------------------
//
// Namespace: _2Checksum
//
//-------------------------------------------------------------------------------------------------
namespace _2Checksum
{
    //
    // Partial Calss: Form1
    //
    public partial class Form1 : Form
    {
        const int MAX_THREAD_NUM = 20;

        private _FileInformation[] FileInformation;
        private object Locker = new object();
        private int FinishThreadCount = 0;
        private uint Checksum = 0U;

        //
        // Constructor: Form1()
        //
        public Form1()
        {
            InitializeComponent();
        }

        //
        // Constructor: Form1(string[] FileList)
        //
        public Form1(string[] FileList)
        {
            FileStream FileToCalc;

            InitializeComponent();

            // Assign memory for FileInformation array
            FileInformation = new _FileInformation[FileList.Length];
            for (int i = 0; i < FileList.Length; i++)
            {
                FileInformation[i] = new _FileInformation();
            }

            for (int i = 0; i < FileList.Length; i++)
            {
                // Retrieve FileInformation
                FileToCalc = File.Open(FileList[i], FileMode.Open, FileAccess.Read);

                FileInformation[i].Filename = FileList[i];
                FileInformation[i].FileTime = File.GetLastWriteTime(FileList[i]);
                FileInformation[i].FileSize = FileToCalc.Length;

                FileToCalc.Close();

                // Calculate checksum
                CalcChecksum(FileInformation[i].Filename, FileInformation[i].FileSize, MAX_THREAD_NUM);
                FileInformation[i].Checksum = Checksum;

                // Display & Update file information
                if (i == 0)
                    DisplayAndUpdateFileInformation(true, FileInformation[i]);
                else
                    DisplayAndUpdateFileInformation(false, FileInformation[i]);
            }
        }

        //
        // Procedure: Button_Browse_Click
        //
        private void Button_Browse_Click(object sender, EventArgs e)
        {
            FileStream FileToCalc;
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();

            OpenFileDialog1.Multiselect = true;

            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Assign memory for FileInformation array
                FileInformation = new _FileInformation[OpenFileDialog1.FileNames.Length];
                for (int i = 0; i < OpenFileDialog1.FileNames.Length; i++)
                {
                    FileInformation[i] = new _FileInformation();
                }

                for (int i = 0; i < OpenFileDialog1.FileNames.Length; i++)
                {
                    // Retrieve FileInformation
                    FileToCalc = File.Open(OpenFileDialog1.FileNames[i], FileMode.Open, FileAccess.Read);

                    FileInformation[i].Filename = OpenFileDialog1.FileNames[i];
                    FileInformation[i].FileTime = File.GetLastWriteTime(OpenFileDialog1.FileNames[i]);
                    FileInformation[i].FileSize = FileToCalc.Length;

                    FileToCalc.Close();

                    // Calculate checksum
                    CalcChecksum(FileInformation[i].Filename, FileInformation[i].FileSize, MAX_THREAD_NUM);
                    FileInformation[i].Checksum = Checksum;

                    // Display & Update file information
                    if (i == 0)
                        DisplayAndUpdateFileInformation(true, FileInformation[i]);
                    else
                        DisplayAndUpdateFileInformation(false, FileInformation[i]);
                }
            }
        }

        //
        // Procedure: Button_Copy_Click
        //
        private void Button_Copy_Click(object sender, EventArgs e)
        {
            if (RichTextBox_FileInfo.TextLength > 0)
                Clipboard.SetText(RichTextBox_FileInfo.Text);
        }

        //
        // Procedure: DisplayAndUpdateFileInformation
        //
        private void DisplayAndUpdateFileInformation(bool bClearContent, _FileInformation FileInformation)
        {
            if (bClearContent)
            {
                RichTextBox_FileInfo.Clear();
            }

            if (CheckBox_Verbose.Checked)
            {
                const string STR_FILENAME_PROMPT = "Filename    : ";
                const string STR_FILEDATE_PROMPT = "File time   : ";
                const string STR_FILESIZE_PROMPT = "File size   : ";
                const string STR_CHECKSUM_PROMPT = "Checksum    : ";

                RichTextBox_FileInfo.AppendText(STR_FILENAME_PROMPT + Path.GetFileName(FileInformation.Filename) + "\n");
                RichTextBox_FileInfo.AppendText(STR_FILEDATE_PROMPT + FileInformation.FileTime.ToString() + "\n");
                RichTextBox_FileInfo.AppendText(STR_FILESIZE_PROMPT + String.Format("{0:n0}", FileInformation.FileSize) + " bytes\n");
                RichTextBox_FileInfo.AppendText(STR_CHECKSUM_PROMPT + String.Format("{0:X4}", (FileInformation.Checksum & 0xFFFF)) + "h\n");
            }
            else
            {
                RichTextBox_FileInfo.AppendText(Path.GetFileName(FileInformation.Filename) + " (" + String.Format("{0:X4}", (FileInformation.Checksum & 0xFFFF)) + "h" + ")");
            }

            RichTextBox_FileInfo.AppendText("\n");
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
        // Procedure: Form1_DragEnter
        //
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
                e.Effect = DragDropEffects.All;
        }

        //
        // Procedure: Form1_DragDrop
        //
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            FileStream FileToCalc;
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop);

            // Assign memory for FileInformation array
            FileInformation = new _FileInformation[FileList.Length];
            for (int i = 0; i < FileList.Length; i++)
            {
                FileInformation[i] = new _FileInformation();
            }

            for (int i = 0; i < FileList.Length; i++)
            {
                // Retrieve FileInformation
                FileToCalc = File.Open(FileList[i], FileMode.Open, FileAccess.Read);

                FileInformation[i].Filename = FileList[i];
                FileInformation[i].FileTime = File.GetLastWriteTime(FileList[i]);
                FileInformation[i].FileSize = FileToCalc.Length;

                FileToCalc.Close();

                // Calculate checksum
                CalcChecksum(FileInformation[i].Filename, FileInformation[i].FileSize, MAX_THREAD_NUM);
                FileInformation[i].Checksum = Checksum;

                // Display & Update file information
                if (i == 0)
                    DisplayAndUpdateFileInformation(true, FileInformation[i]);
                else
                    DisplayAndUpdateFileInformation(false, FileInformation[i]);
            }
        }

        //
        // Procedure: CheckBox_Verbose_Click
        //
        private void CheckBox_Verbose_Click(object sender, EventArgs e)
        {
            // Check if any file checksum has been calculated
            if (FileInformation == null)
                return;

            // Display & Update file information
            for (int i = 0; i < FileInformation.Length; i++)
            {
                if (i == 0)
                    DisplayAndUpdateFileInformation(true, FileInformation[i]);
                else
                    DisplayAndUpdateFileInformation(false, FileInformation[i]);
            }
        }
    }

    //
    // Class: _FileInformation
    //
    class _FileInformation
    {
        private string _Filename = "Not Available";
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
