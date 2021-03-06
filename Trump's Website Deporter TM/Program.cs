﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Trump_s_Website_Deporter_TM
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (File.Exists("systems"))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            else if (args.Length > 0)
            {
                List<string> newURLs = new List<string>(MainForm.ProcessURLs(args));
                newURLs.RemoveAt(0);
                MainForm.WriteListToHosts(newURLs,true);
                //File.Delete(@"C:\Windows\PaExec.exe");
                Environment.Exit(0);
            }
            else
            {
                MessageBox.Show(
                    "Please provide a 'systems' file in the directory.",
                    "Missing file required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                Environment.Exit(2);
            }

        }
    }
}
