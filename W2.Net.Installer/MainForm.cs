using Ionic.Zip;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using W2.Net.Info;

namespace W2.Net.Installer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Terminate()
        {
            Application.Exit();
        }

        private void Terminate(String message)
        {
            MessageBox.Show(message);
            Terminate();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            const String package_name = "package.zip";
            const String vsto_name = "setup.exe";
            String installer_path = Folder.GetInstallerPath();           

            var t = new Thread(() =>
            {
                var processes = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(Folder.BRIDGE_NAME));
                bool kill = false;
                if(processes != null && processes.Length > 0)
                {
                    foreach(var process in processes)
                    {
                        try
                        {
                            process.Kill();
                        }
                        catch
                        {
                            continue;
                        }
                    }
                    
                    kill = true;
                }

                var files = new DirectoryInfo(installer_path).GetFiles().Where(file => file.Extension.ToLower().Equals(".tmp") || file.Extension.ToLower().Equals(".w2"));
                if (files != null)
                {
                    foreach (var file in files)
                    {
                        try
                        {
                            file.Delete();
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }

                try
                {
                    using (var zip = ZipFile.Read(package_name))
                    {
                        zip.ExtractAll(installer_path, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
                catch
                {
                    Terminate("Não foi possível completar a instalação.");
                    return;
                }

                if (kill)
                {
                    String bridge_path = Path.Combine(installer_path, Folder.BRIDGE_NAME);

                    try
                    {
                        Process.Start(bridge_path);
                    }
                    catch
                    {
                    }
                }

                try
                {
                    Process.Start(vsto_name);
                }
                catch(FileNotFoundException)
                {
                    Terminate("Arquivo setup.exe não encontrado.");
                    return;
                }
                catch
                {
                    Terminate("Não foi possível completar a instalação. [#2]");
                    return;
                }                

                Terminate();                
            });

            t.Start();
        }
    }
}
