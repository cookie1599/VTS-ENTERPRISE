using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace VTS.exe
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new PemilihanPetugas());
            //Application.Run(new Register());
            Application.Run(new ScanRFID());
        }
    }
}
