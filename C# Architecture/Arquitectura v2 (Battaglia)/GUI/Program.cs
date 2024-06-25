using System;
using System.Windows.Forms;

using TCTD2020.ArquitecturaCapasV2.UI;

namespace TCTD2020.ArquitecturaCapasV2
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
            Application.Run(new MenuForm());
        }
    }
}
