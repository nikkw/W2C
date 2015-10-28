using System;
using System.IO;
using System.Windows.Forms;
using W2.Net.Framework;
using W2.Net.Framework.Forms;

namespace W2.Net.BridgeApplication
{
    public class Watcher
    {
        private static FileSystemWatcher watcher;

        public static void Init()
        {
            watcher = new FileSystemWatcher(Info.Folder.GetWatcherPath());
            watcher.IncludeSubdirectories = false;
            watcher.Created += new FileSystemEventHandler(OnCreate);
            watcher.EnableRaisingEvents = true;            
        }

        public static void Final()
        {
            watcher.Dispose();
        }

        static void OnCreate(object sender, FileSystemEventArgs e)
        {
            Program.MainForm.TopMost = true;
            if(e.Name == Info.Folder.LOGIN_FILE_NAME)
            {
                if(Program.MainForm != null)
                {   
                    Program.MainForm.BeginInvoke(new MethodInvoker(() =>
                    {
                        if(Addin.InSession)
                        {
                            Framework.Util.Forms.Show(typeof(MyAccount));                            
                        }
                        else
                        {
                            Framework.Util.Forms.Show(typeof(Login));
                        }
                    }));                
                }                
            }

            else if (e.Name == Info.Folder.SENDFILE_FILE_NAME)
            {
                if (Program.MainForm != null)
                {
                    Program.MainForm.BeginInvoke(new MethodInvoker(() =>
                    {
                        String path = e.FullPath;
                            
                        if(File.Exists(path))
                        {
                            try
                            {
                                var info = File.ReadAllLines(path);
                                if (info != null && info.Length == 2)
                                {
                                    if(Addin.InSession)
                                    {
                                        SendFile form = new SendFile(info[0], info[1]);
                                        form.Show();
                                    }
                                    else
                                    {
                                        Login form = new Login(info[0], info[1]);
                                        form.Show();
                                    }
                                }
                            }
                            catch
                            { }
                        }
                    }));
                }                
            }
        }
    }
}
