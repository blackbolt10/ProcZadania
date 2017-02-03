using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcZadania
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(String[] arg)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            bool debuger = true;

            if(arg != null && arg.Length > 0)
            {
                if(arg[0] == "-modyfikator")
                    uruchomModyfikator();
                else if(arg[0] == "-debuger")
                    debuger = false;
            }

            procentyProgram form1 = new procentyProgram(debuger);
            Application.ThreadException += new ThreadExceptionEventHandler(form1.UnhandledThreadExceptionHandler);
            Application.Run(form1);
        }

        static private void uruchomModyfikator()
        {
            Modyfikator_Rejestru modyfikator = new Modyfikator_Rejestru();
            modyfikator.ShowDialog();
            modyfikator.Dispose();
        }
    }
}