using System;
using System.IO;
using System.Windows.Forms;
using W2.Net.Framework.Tasks;
using W2.Net.Framework.W2Service;

namespace W2.Net.Framework.Forms
{
    public partial class UserSettings : Form
    {
        private bool loaded = false;

        public UserSettings()
        {
            InitializeComponent();
        }

        private void UserSettings_Load(object sender, EventArgs e)
        {
            this.boxEmail.Text = Addin.CurrentAccount.email;

            this.boxDirDownload.Text = Util.User.GetDirDownload();

            this.checkOpenDocument.Checked = Addin.CurrentAccount.openDocument;

            this.loaded = true;
        }

        private void buttonChangeEmail_Click(object sender, EventArgs e)
        {
            new ChangeEmail();
        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            new ChangePassword();
        }

        private async void buttonChangeDirDownload_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Selecione o novo diretório de download";
            dialog.RootFolder = Environment.SpecialFolder.Desktop;
            
            if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                String dir = dialog.SelectedPath;

                if(!String.IsNullOrEmpty(dir))
                {
                    if(Directory.Exists(dir))
                    {
                        this.buttonChangeDirDownload.Enabled = false;

                        bool change = false;

                        setDirDownloadResponse response = null;
                        try
                        {
                            response = await Service.IService.setDirDownloadAsync(new setDirDownloadRequest(dir, Util.User.GetHashID()));
                        }
                        catch
                        {
                            response = null;
                        }

                        if(response != null)
                        {
                            Int32 sucess = response.@return;

                            if(sucess != 0)
                            {
                                change = true;
                            }
                        }

                        if(change)
                        {
                            Addin.CurrentAccount.dirDownload = dir;
                            boxDirDownload.Text = dir;
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível alterar o diretório de download. Tente novamente mais tarde");
                        }
                    }
                }
            }

            this.buttonChangeDirDownload.Enabled = true;
        }

        private async void checkOpenDocument_CheckStateChanged(object sender, EventArgs e)
        {
            if (this.loaded)
            {
                bool change = false;
                this.checkOpenDocument.Enabled = false;
                bool option = this.checkOpenDocument.Checked;

                setOpenDocumentResponse response = null;
                try
                {
                    response = await Service.IService.setOpenDocumentAsync(new setOpenDocumentRequest(option, Util.User.GetHashID()));
                }
                catch
                {
                    response = null;
                }

                if (response != null)
                {
                    Int32 sucess = response.@return;

                    if (sucess != 0)
                    {
                        change = true;
                    }
                }

                if (change)
                {
                    Addin.CurrentAccount.openDocument = option;
                }
                else
                {
                    MessageBox.Show("Não foi possível alterar a configuração. Tente novamente mais tarde");

                    this.loaded = false;
                    this.checkOpenDocument.Checked = !this.checkOpenDocument.Checked;
                    this.loaded = true;
                }
            }

            this.checkOpenDocument.Enabled = true;
        }  
        
        private void UserSettings_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }              
    }
}
