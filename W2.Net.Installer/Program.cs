using System;
using System.Windows.Forms;

namespace W2.Net.Installer
{
    static class Program
    {        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());         
        }
    }
}
