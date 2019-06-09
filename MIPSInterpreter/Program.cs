using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIPSInterpreter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// Used only to launch UI - all other actions
        /// done from there.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
