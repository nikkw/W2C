using System;
using System.Windows.Forms;

namespace W2.Net.BridgeApplication
{
    static class Program
    {
        internal static Form MainForm;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm = new MainForm();            
            MainForm.Visible = false;
            Application.Run(MainForm);
        }
    }
}
