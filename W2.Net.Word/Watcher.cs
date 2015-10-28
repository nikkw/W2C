using System.IO;
using W2.Net.Info;

namespace W2.Net.Word
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
            if(e.Name == Folder.LOGIN_ACTION_FILE_NAME)
            {
                Globals.Ribbons.Ribbon.buttonLogin.Label = "Minhas áreas";
                Globals.Ribbons.Ribbon.buttonSaveDoc.Visible = true;
            }

            else if(e.Name == Folder.LOGOFF_ACTION_FILE_NAME)
            {
                Globals.Ribbons.Ribbon.buttonLogin.Label = "Login";
                Globals.Ribbons.Ribbon.buttonSaveDoc.Visible = false;
            }
        }
    }
}
