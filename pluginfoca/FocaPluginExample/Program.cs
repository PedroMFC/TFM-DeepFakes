using System;
using System.Windows.Forms;

namespace FocaPluginExample
{
    static public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static public void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FrmPluginExample());
            Application.Run(new Form1());
        }
    }
}
