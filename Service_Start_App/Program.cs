using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Denso_ORM_PLC_Service
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            bool Running;

            Mutex mutex = new Mutex(true, "Denso_ORM_PLC_Service", out Running);
            if (Running == true)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainWindow());
            }
            else
            {
                Process[] processList = Process.GetProcessesByName("Denso_ORM_PLC_Service");

                if (processList.Length > 0)
                {
                    //bool Flag = processList[0].Responding;
                    //if (Flag == false)
                    //{
                    //    processList[0].Kill();
                    //}
                    processList[0].Kill();
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainWindow());
                }
            }
        }
    }
}
