using Microsoft.Win32;
using System;
using System.IO;

namespace W2.Net.Info
{
    public class Folder
    {
        private const string _userFolderKey = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders";

        public static String PRODUCT_NAME = "O2W";
        public static String BRIDGE_NAME = "W2.Net.BridgeApplication.exe";
        public static String LOGIN_FILE_NAME = "login.w2";
        public static String SENDFILE_FILE_NAME = "sendfile.w2";
        public static String LOGIN_ACTION_FILE_NAME = "loginaction.w2";
        public static String LOGOFF_ACTION_FILE_NAME = "logoffaction.w2";
        public static String LOGINDATA_SRC = "logindata.bin";

        private static string[] _userFolderKeyNames = new string[]
        {
            "{56784854-C6CB-462B-8169-88E350ACB882}", // Contacts
            "Desktop",                                // Desktop
            "Personal",                               // Documents
            "{374DE290-123F-4565-9164-39C4925E467B}", // Downloads
            "Favorites",                              // Favorites
            "{BFB9D5E0-C6A9-404C-B2B2-AE6DB6AF4968}", // Links
            "My Music",                               // Music
            "My Pictures",                            // Pictures
            "{4C5C32FF-BB9D-43B0-B5B4-2D72E54EAAA4}", // Saved Games
            "{7D1D3A04-DEBB-4115-95CF-2F29DA2920DA}", // Searches
            "My Video"                                // Videos
        };

        /// <summary>
        /// Gets the user defined path of a personal folder in Windows Vista and later operating systems.
        /// </summary>
        /// <param name="userFolder">The personal folder to retrieve.</param>
        /// <returns>The path of the personal folder or an empty string if its path was not specified.</returns>
        public static string GetUserPath(Types.UserFolder userFolder)
        {
            return Registry.GetValue(_userFolderKey, _userFolderKeyNames[(int)userFolder], String.Empty).ToString();
        }

        /// <summary>
        /// Gets the user defined path of a personal folder in Windows Vista and later operating systems.
        /// </summary>
        /// <returns>The path of the personal folder or an empty string if its path was not specified.</returns>
        public static string GetWatcherPath()
        {
            String dir = Registry.GetValue(_userFolderKey, _userFolderKeyNames[(int)Types.UserFolder.SavedGames], String.Empty).ToString();
            
            DirectoryInfo info = new DirectoryInfo(dir);

            foreach (var file in info.GetFiles())
            {
                if(file.Extension.ToLower() == ".w2")
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

            return dir;
        }

        /*
        private static String GetProgramFilesPath()
        {
            String path = string.Empty;
            if (IntPtr.Size == 8 || (!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"))))
            {
                path = Environment.GetEnvironmentVariable("ProgramFiles(x86)");
            }
            else
            {
                path = Environment.GetEnvironmentVariable("ProgramFiles");
            }            

            return path;
        }
         * */

        public static String GetInstallerPath()
        {
            return Registry.GetValue(_userFolderKey, _userFolderKeyNames[(int)Types.UserFolder.SavedGames], String.Empty).ToString();                       
        }
    }
}
