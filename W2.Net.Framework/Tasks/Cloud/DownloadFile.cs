using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using W2.Net.Framework.W2Service;
using W2.Net.Info;

namespace W2.Net.Framework.Tasks.AbcDoc
{
    public partial class Cloud
    {
        public void DownloadFile(documento doc, Forms.MyAccount form)
        {            
            Thread t = new Thread(() => {                
                if (!String.IsNullOrEmpty(doc.hash))
                {
                    if (String.IsNullOrEmpty(doc.name))
                    {
                        doc.name = "Sem nome";
                    }

                    if (AbcDoc != null)
                    {
                        String oldName = string.Empty;

                        try
                        {
                            //recebe o arquivo do abcdoc
                            oldName = AbcDoc.receberArquivo(doc.hash, Dir.TempDirectory);
                        }
                        catch
                        {
                            oldName = string.Empty;
                        }

                        if (!String.IsNullOrEmpty(oldName))
                        {
                            String newFileName = Util.User.GetDirDownload() + doc.name;
                            String newFileExtension = new FileInfo(oldName).Extension;
                            String newName = newFileName + newFileExtension;

                            if (File.Exists(newName))
                            {
                                //cria um versionamento pro arquivo, pois ele ja existe
                                Int32 count = 1;

                                while (File.Exists(newFileName + "(" + count.ToString() + ")" + newFileExtension))
                                {
                                    count++;
                                }                                

                                newName = newFileName + "(" + count.ToString() + ")" + newFileExtension;
                            }

                            if (File.Exists(oldName) && !File.Exists(newName))
                            {
                                File.Move(oldName, newName);

                                if (File.Exists(newName))
                                {
                                    if (Addin.CurrentAccount.openDocument)
                                    {
                                        //faz a uniao das extensoes de documentos, planilhas e apresentacoes
                                        var union =
                                            Forms.MyAccount.wextensions
                                            .Concat(Forms.MyAccount.eextensions)
                                            .Concat(Forms.MyAccount.pextensions)
                                            .Concat(Forms.MyAccount.iextensions);
                                        
                                        if(union.Any(ext => ext.ToLower().Equals(newFileExtension.ToLower())))
                                        {
                                            Process.Start(newName);
                                        }
                                    }
                                }

                                try
                                {
                                    File.Delete(oldName);
                                }
                                catch
                                {
                                }
                            }
                            else
                            {
                                MessageBox.Show("Não foi possível completar o download. O arquivo é inválido.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível completar o download. Verifique sua conexão com a internet.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível completar o download. Verifique sua conexão com a internet.");
                    }
                }
                else
                {
                    MessageBox.Show("Não foi possível completar o download. O documento selecionado é inválido.");
                }

                form.Invoke((MethodInvoker)(() => form.buttonDownloadDocument.Enabled = true));
            });

            t.Start();
        }        
    }
}
