using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2Checksum
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main(string[] Args)
        {
            string[] CliArgs = Environment.GetCommandLineArgs();

            if (CliArgs.Length > 3)
            {
                switch (CliArgs[1])
                {
                    case "export":
                        // Get file list
                        string[] CliFileList = new string[CliArgs.Length - 3];
                        for (int i = 3; i < CliArgs.Length; i++)
                        {
                            CliFileList[i - 3] = CliArgs[i];
                        }

                        // Gather file information through the creation of a no-GUI from
                        Form1 NoGuiForm = new Form1(CliFileList);

                        // Generate export file
                        string ExportInfo = "";

                        for (int i = 0; i < Form1.FileInfo.Length; i++)
                        {
                            if(CliArgs[2] == "4")   // export with 4-digit format
                            {
                                ExportInfo = ExportInfo + Form1.STR_FILENAME_PROMPT + Path.GetFileName(Form1.FileInfo[i].Filename) + "\n";
                                ExportInfo = ExportInfo + Form1.STR_CHECKSUM_PROMPT + String.Format("{0:X4}", (Form1.FileInfo[i].Checksum & 0xFFFF)) + "h\n\n";
                            }
                            else if (CliArgs[2] == "8") // export with 8-digit format
                            {
                                ExportInfo = ExportInfo + Form1.STR_FILENAME_PROMPT + Path.GetFileName(Form1.FileInfo[i].Filename) + "\n";
                                ExportInfo = ExportInfo + Form1.STR_CHECKSUM_PROMPT + String.Format("{0:X8}", (Form1.FileInfo[i].Checksum & 0xFFFFFFFF)) + "h\n\n";
                            }
                            else    // Invalid checksum format
                            {
                                ExportInfo = "Invalid checksum format.\n";
                                ExportInfo = ExportInfo + "You should specify checksum format as 4-digit or 8-digit.\n\n";
                                ExportInfo = ExportInfo + "For 4-digit checksum:\n    2Checksum export 4 [FILE_LIST]\n";
                                ExportInfo = ExportInfo + "For 8-digit checksum:\n    2Checksum export 8 [FILE_LIST]\n";
                            }
                        }

                        System.IO.File.WriteAllText(Form1.EXPORT_FILENAME, ExportInfo);
                        break;

                    default:
                        RunGuiApp(Args);
                        break;
                }

                Environment.Exit(0);
            }
            else
            {
                RunGuiApp(Args);
            }
        }

        static void RunGuiApp(string[] Args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Args.Length == 0)
            {
                Application.Run(new Form1());
            }
            else
            {
                Application.Run(new Form1(Args));
            }
        }
    }
}
