//-------------------------------------------------------------------------------------------------
//
// Usings
//
//-------------------------------------------------------------------------------------------------
using System;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using ChecksumLib;

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

        public static FileInformation[] FileInfo;
        private object Locker = new object();
        private int FinishThreadCount = 0;

        public const string STR_FILENAME_PROMPT = "Filename     : ";
        public const string STR_FILEDATE_PROMPT = "File time    : ";
        public const string STR_FILESIZE_PROMPT = "File size    : ";
        public const string STR_CHECKSUM_PROMPT = "Checksum     : ";
        public const string STR_FILE_VER_PROMPT = "File version : ";

        public const string EXPORT_FILENAME = "Checksum.txt";

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
            InitializeComponent();
            GatherFileInformation(FileList);

            // Display & Update file information
            for (int i = 0; i < FileInfo.Length; i++)
            {
                if (i == 0)
                    DisplayAndUpdateFileInformation(true, FileInfo[i]);
                else
                    DisplayAndUpdateFileInformation(false, FileInfo[i]);
            }
        }

        //
        // Procedure: Button_Browse_Click
        //
        private void Button_Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();

            OpenFileDialog1.Multiselect = true;

            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                GatherFileInformation(OpenFileDialog1.FileNames);

                // Display & Update file information
                for (int i = 0; i < FileInfo.Length; i++)
                {
                    if (i == 0)
                        DisplayAndUpdateFileInformation(true, FileInfo[i]);
                    else
                        DisplayAndUpdateFileInformation(false, FileInfo[i]);
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
        // Procedure: GatherFileInformation
        //
        private void GatherFileInformation(string[] FileList)
        {
            FileStream FileToCalc;
            UInt32 Checksum = 0;
            AdditionChecksum BiosChecksum = new AdditionChecksum();

            // Assign memory for FileInformation array
            FileInfo = new FileInformation[FileList.Length];
            for (int i = 0; i < FileList.Length; i++)
            {
                FileInfo[i] = new FileInformation();
            }

            for (int i = 0; i < FileList.Length; i++)
            {
                // Retrieve FileInformation
                FileToCalc = File.Open(FileList[i], FileMode.Open, FileAccess.Read);

                FileInfo[i].Filename = FileList[i];
                FileInfo[i].FileTime = File.GetLastWriteTime(FileList[i]);
                FileInfo[i].FileSize = FileToCalc.Length;

                FileToCalc.Close();

                // Calculate checksum
                BiosChecksum.CalcChecksum(FileList[i], out Checksum);
                FileInfo[i].Checksum = Checksum;

                // Retrieve File Version Information for .EXE file
                FileInfo[i].ExeFileVersion = FileVersionInfo.GetVersionInfo(FileList[i]).FileVersion;
            }
        }

        //
        // Procedure: DisplayAndUpdateFileInformation
        //
        private void DisplayAndUpdateFileInformation(bool bClearContent, FileInformation FileInformation)
        {
            if (bClearContent)
            {
                RichTextBox_FileInfo.Clear();
            }

            if (CheckBox_Verbose.Checked)
            {
                RichTextBox_FileInfo.AppendText(STR_FILENAME_PROMPT + Path.GetFileName(FileInformation.Filename) + "\n");
                RichTextBox_FileInfo.AppendText(STR_FILEDATE_PROMPT + String.Format("{0:yyyy/MM/dd, HH:mm:ss}\n", FileInformation.FileTime));
                RichTextBox_FileInfo.AppendText(STR_FILESIZE_PROMPT + String.Format("{0:n0}", FileInformation.FileSize) + " bytes\n");

                if (CheckBox_DigitLength.Checked)    // 8-digit checksum
                    RichTextBox_FileInfo.AppendText(STR_CHECKSUM_PROMPT + String.Format("{0:X8}", (FileInformation.Checksum & 0xFFFFFFFF)) + "h\n");
                else // 4-digit checksum
                    RichTextBox_FileInfo.AppendText(STR_CHECKSUM_PROMPT + String.Format("{0:X4}", (FileInformation.Checksum & 0xFFFF)) + "h\n");

                if (FileInformation.ExeFileVersion != null)
                    RichTextBox_FileInfo.AppendText(STR_FILE_VER_PROMPT + FileInformation.ExeFileVersion + "\n");
            }
            else
            {
                if (CheckBox_DigitLength.Checked)    // 8-digit checksum
                    RichTextBox_FileInfo.AppendText(Path.GetFileName(FileInformation.Filename) + " (" + String.Format("{0:X8}", (FileInformation.Checksum & 0xFFFFFFFF)) + "h" + ")");
                else // 4-digit checksum
                    RichTextBox_FileInfo.AppendText(Path.GetFileName(FileInformation.Filename) + " (" + String.Format("{0:X4}", (FileInformation.Checksum & 0xFFFF)) + "h" + ")");
            }

            RichTextBox_FileInfo.AppendText("\n");
        }

        //
        // Procedure: CommonDragEnter
        //
        private void CommonDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
                e.Effect = DragDropEffects.All;
        }

        //
        // Procedure: Form1_DragDrop
        //
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop);

            GatherFileInformation(FileList);

            // Display & Update file information
            for (int i = 0; i < FileInfo.Length; i++)
            {
                if (i == 0)
                    DisplayAndUpdateFileInformation(true, FileInfo[i]);
                else
                    DisplayAndUpdateFileInformation(false, FileInfo[i]);
            }
        }

        //
        // Procedure: CheckBox_Verbose_Click
        //
        private void CheckBox_Verbose_Click(object sender, EventArgs e)
        {
            // Check if any file checksum has been calculated
            if (FileInfo == null)
                return;

            // Display & Update file information
            for (int i = 0; i < FileInfo.Length; i++)
            {
                if (i == 0)
                    DisplayAndUpdateFileInformation(true, FileInfo[i]);
                else
                    DisplayAndUpdateFileInformation(false, FileInfo[i]);
            }
        }

        private void CheckBox_DigitLength_CheckedChanged(object sender, EventArgs e)
        {
            if(CheckBox_DigitLength.Checked)
            {
                CheckBox_DigitLength.Text = "8-digit";
            }
            else
            {
                CheckBox_DigitLength.Text = "4-digit";
            }

            // Display & Update file information
            if (FileInfo != null)
            {
                for (int i = 0; i < FileInfo.Length; i++)
                {
                    if (i == 0)
                        DisplayAndUpdateFileInformation(true, FileInfo[i]);
                    else
                        DisplayAndUpdateFileInformation(false, FileInfo[i]);
                }
            }
        }

        private void Button_Export_Click(object sender, EventArgs e)
        {
            string ExportInfo = "";

            if (RichTextBox_FileInfo.TextLength > 0)
            {
                for (int i = 0; i < FileInfo.Length; i++)
                {
                    ExportInfo = ExportInfo + STR_FILENAME_PROMPT + Path.GetFileName(FileInfo[i].Filename) + "\n";

                    if (CheckBox_DigitLength.Checked)   // 8-digit checksum
                        ExportInfo = ExportInfo + STR_CHECKSUM_PROMPT + String.Format("{0:X8}", (FileInfo[i].Checksum & 0xFFFFFFFF)) + "h\n\n";
                    else    // 4-digit checksum
                        ExportInfo = ExportInfo + STR_CHECKSUM_PROMPT + String.Format("{0:X4}", (FileInfo[i].Checksum & 0xFFFF)) + "h\n\n";
                }

                System.IO.File.WriteAllText(EXPORT_FILENAME, ExportInfo);
            }
        }
    }

    //
    // Class: FileInformation
    //
    public class FileInformation
    {
        private string _Filename = "Not Available";
        private DateTime _FileTime = new DateTime();
        private long _FileSize = 0;
        private uint _Checksum = 0U;
        private string _ExeFileVersion = "Not Available";

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

        // Attribute: ExeFileVerison
        public string ExeFileVersion
        {
            get
            {
                return _ExeFileVersion;
            }

            set
            {
                _ExeFileVersion = value;
            }
        }
    }
}
