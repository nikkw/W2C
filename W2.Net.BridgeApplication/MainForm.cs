using System;
using System.Net;
using System.Windows.Forms;

namespace W2.Net.BridgeApplication
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(delegate
            {
                this.Hide();
            }));

            ServicePointManager.Expect100Continue = false;
            Watcher.Init();
            Framework.Addin.InitAddin();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Watcher.Final();
        }
    }
}
