using System;
using System.IO;
using W2.Net.Framework.Tasks;
using W2.Net.Framework.W2Service;
using System.Linq;
using W2.Net.Info;

namespace W2.Net.Framework.Util
{
    public class User
    {
        public const Int32 TRASH_ID = -1;
        public const Int32 MY_ACCOUNT_ID = 2;
        public const Int32 DOC_RECENT_ID = -2;

        public const Int32 DOC_RECENT_POS = 0;
        public const Int32 MY_ACCOUNT_POS = 1;

        private static String UserHash = string.Empty;

        public static area CurrentArea
        {
            get;
            set;
        }
        
        public static String GetDirDownload()
        {
            return GetDirDownload(Addin.CurrentAccount.dirDownload);
        }

        public static String GetDirDownload(String dir)
        {
            if (String.IsNullOrEmpty(dir) || dir == "__temp__" || !Directory.Exists(dir))
            {
                return Folder.GetUserPath(Types.UserFolder.Downloads) + "\\";
            }

            return dir + "\\";
        }

        public static String GetHashID(Int32 usrId)
        {
            return usrId.ToString();

            if(String.IsNullOrEmpty(UserHash))
            {
                UserHash = Util.Crypto.Encrypt(usrId.ToString());
            }

            return UserHash;
        }

        public static String GetHashID()
        {
            return GetHashID(Addin.CurrentAccount.id);
        }

        public static String GetHashPassword(String pass)
        {
            return pass;

            return Util.Crypto.Encrypt(pass);
        }        

        public static void ReadAreas(accounts acc, String usrHash)
        {
            if (Service.IService != null)
            {
                getAreasResponse areaResponse = null;

                try
                {
                    //faz a leitura das areas
                    areaResponse = Service.IService.getAreas(new getAreasRequest(usrHash));
                }
                catch
                {
                    areaResponse = null;
                }

                if (areaResponse != null)
                {   //leitura feita corretamente

                    area docRecent = new area();
                    docRecent.active = true;
                    docRecent.edit = true;
                    docRecent.nome = "Arquivos recentes";
                    docRecent.id = DOC_RECENT_ID;
                    Addin.Areas.Add(docRecent);

                    area[] areas = areaResponse.@return;

                    if (areas != null && areas.Length > 0)
                    {                        
                        var condition = areas.Where(a => a.nome != null && !String.IsNullOrEmpty(a.nome.TrimStart().TrimEnd()) && a.active);
                        if (condition != null)
                        {
                            Addin.Areas.AddRange(condition);

                            for (Int32 i = 0; i < Addin.Areas.Count; i++)
                            {   //coloca a area privada na MY_ACCOUNT_POS da array
                                if (Addin.Areas[i].id == MY_ACCOUNT_ID && i != MY_ACCOUNT_POS)
                                {
                                    area aux = Addin.Areas[MY_ACCOUNT_POS];
                                    Addin.Areas[MY_ACCOUNT_POS] = Addin.Areas[i];
                                    Addin.Areas[i] = aux;
                                }
                            }

                            area trash = new area();
                            trash.active = true;
                            trash.edit = true;
                            trash.nome = "Lixeira";
                            trash.id = TRASH_ID;
                            Addin.Areas.Add(trash);
                        }
                    }
                }
            }
        }

        public static void ReadAreas(String usrHash)
        {
            ReadAreas(Addin.CurrentAccount, usrHash);
        }

        public static void ReadAreas()
        {
            String usrHash = Util.Crypto.Encrypt(Addin.CurrentAccount.id.ToString());

            ReadAreas(Addin.CurrentAccount, usrHash);
        }

        public static void ReadAreas(accounts acc)
        {
            String usrHash = Util.Crypto.Encrypt(acc.id.ToString());

            ReadAreas(acc, usrHash);
        }
    }
}