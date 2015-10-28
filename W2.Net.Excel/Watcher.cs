using System.IO;
using W2.Net.Info;

namespace W2.Net.Excel
{
    public class Watcher
    {
        private static FileSystemWatcher watcher;
        public static void Init()
        {
            watcher = new FileSystemWatcher(Folder.GetWatcherPath());
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
            if (e.Name == Folder.LOGIN_ACTION_FILE_NAME)
            {
                Globals.Ribbons.Ribbon1.buttonLogin.Label = "Minhas áreas";
                Globals.Ribbons.Ribbon1.buttonSendFile.Visible = true;
            }

            else if (e.Name == Folder.LOGOFF_ACTION_FILE_NAME)
            {
                Globals.Ribbons.Ribbon1.buttonLogin.Label = "Login";
                Globals.Ribbons.Ribbon1.buttonSendFile.Visible = false;
            }
        }
    }
}
