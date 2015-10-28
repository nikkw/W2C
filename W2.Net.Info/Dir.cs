using System;
using System.IO;

namespace W2.Net.Info
{
    public class Dir
    {
        public static String TempDirectory
        {
            get
            {
                return Path.GetTempPath() + "__temp\\";
            }
        }

        public static String DataDirectory
        {
            get
            {
                return Path.GetTempPath() + "__data\\";
            }
        }
    }
}
