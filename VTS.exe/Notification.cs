using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using VTS.BusinessEntity;
using VTS.BusinessRule;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace VTS.exe
{
    public partial class Notification : Form
    {
        public Notification()
        {
            InitializeComponent();
        }

        private void Notif_Load(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Thread.Sleep(TimeSpan.FromSeconds(3));
            //Process _proc = null;
            //string _targetDir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Resources\");
            String[] _resourceArray = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceNames();
            try
            {
                //VTS.exe.ScanRFID.ActiveForm.WindowState = FormWindowState.Maximized;
                //this.Hide();

                ScanRFID _scanRFID = new ScanRFID();
                _scanRFID.Show();

                this.Close(); // (_)(_)===D

                //if (Directory.Exists(_targetDir))
                //{
                //    //_proc = new Process();
                //    //_proc.StartInfo.WorkingDirectory = _targetDir;
                //    //_proc.StartInfo.FileName = "ReRun.bat";
                //    //_proc.StartInfo.Arguments = string.Format("10");//this is argument
                //    //_proc.StartInfo.CreateNoWindow = false;
                //    //_proc.Start();
                //    //_proc.WaitForExit();
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occurred :{0},{1}", ex.Message, ex.StackTrace.ToString());
            }
            Environment.Exit(0);
        }

        //public static extern IntPtr FindWindows(string lpClassName, string lpWindowName);

        //public static extern bool ShowWindows(IntPtr hWnd, int nCmdShow);

        //public static extern bool SetForegroundWindows(IntPtr hWnd);

        public static void ShowToFront(string windowName)
        {
            //IntPtr firstInstance = FindWindows(null, windowName);
            //ShowWindows(firstInstance, 1);
            //SetForegroundWindows(firstInstance);
        }
    }
}
