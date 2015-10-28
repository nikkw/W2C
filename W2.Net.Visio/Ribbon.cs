using Microsoft.Office.Tools.Ribbon;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using W2.Net.Info;

namespace W2.Net.Visio
{
    public partial class Ribbon
    {
        private void buttonLogin_Click(object sender, RibbonControlEventArgs e)
        {
            String file = Path.Combine(Folder.GetWatcherPath(), Folder.LOGIN_FILE_NAME);
            File.Create(file).Close();
        }

        private void buttonSaveDoc_Click(object sender, RibbonControlEventArgs e)
        {
            String name = Path.GetFileNameWithoutExtension(Globals.ThisAddIn.Application.ActiveDocument.Name);
            String temp = Path.GetRandomFileName().Replace(".", "");
            String path = Path.Combine(Dir.TempDirectory, temp);

            while (File.Exists(path))
            {
                temp = Path.GetRandomFileName().Replace(".", "");
                path = Path.Combine(Dir.TempDirectory, temp);
            }

            //salva o documento ativo
            Globals.ThisAddIn.Application.ActiveDocument.SaveAs(path);

            //obtem o documento salvo com a extensao correta
            var file = new DirectoryInfo(Dir.TempDirectory).GetFiles()
                .Where(f => Path.GetFileNameWithoutExtension(f.Name).Equals(temp))
                .First();

            //restaura o nome antigo do documento
            path = Path.Combine(Dir.TempDirectory, name);
            if (!File.Exists(path))
            {
                Globals.ThisAddIn.Application.ActiveDocument.SaveAs(path);
            }
            else
            {
                Globals.ThisAddIn.Application.ActiveDocument.Save();
            }

            if (file != null && !String.IsNullOrEmpty(file.FullName))
            {
                try
                {
                    path = Path.Combine(Folder.GetWatcherPath(), Folder.SENDFILE_FILE_NAME);

                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }

                    //cria o arquivo para a ponte, contendo o diretorio                                    
                    File.WriteAllLines(path, new string[] { file.FullName, name });
                }
                catch
                {
                    MessageBox.Show("Não foi possível salvar o documento.");
                }
            }
            else
            {
                MessageBox.Show("Não foi possível salvar o documento.");
            }
        }
    }
}
