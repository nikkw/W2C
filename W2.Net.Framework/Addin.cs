using System;
using System.Collections.Generic;
using System.IO;
using W2.Net.Framework.W2Service;
using W2.Net.Info;

namespace W2.Net.Framework
{
    public class Addin
    {        
        private static accounts m_CurrentAccount;
        private static List<area> m_Areas;
        private static Boolean m_InSession;

        public static accounts CurrentAccount
        {
            get
            {
                if(m_CurrentAccount == null)
                {
                    m_CurrentAccount = new accounts();
                }

                return m_CurrentAccount;
            }
            set
            {
                m_CurrentAccount = value;
            }
        }

        public static List<area> Areas
        {
            get
            {
                if(m_Areas == null)
                {
                    m_Areas = new List<area>();                    
                }

                return m_Areas;
            }

            set
            {
                m_Areas = value;
            }
        }
        public static Boolean InSession
        {
            get
            {
                return m_InSession;
            }

            set
            {
                m_InSession = value;

                if(!value)
                {
                    CurrentAccount = null;
                    Areas = null;
                }
            }
        }

        public static void InitAddin()
        {
            if(!Directory.Exists(Dir.TempDirectory))
            {
                Directory.CreateDirectory(Dir.TempDirectory);
            }
            else
            {
                DirectoryInfo info = new DirectoryInfo(Dir.TempDirectory);

                foreach (FileInfo file in info.GetFiles())
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

            if(!Directory.Exists(Dir.DataDirectory))
            {
                Directory.CreateDirectory(Dir.DataDirectory);
            }
        }
    }
}
