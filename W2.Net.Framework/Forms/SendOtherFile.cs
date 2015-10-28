using System;
using System.IO;
using System.Windows.Forms;
using W2.Net.Framework.Tasks.AbcDoc;
using W2.Net.Framework.W2Service;
using W2.Net.Info;

namespace W2.Net.Framework.Forms
{
    public partial class SendOtherFile : Form
    {
        private Int32 Level;
        private Object tag;

        public SendOtherFile(Int32 level, object tag)
        {
            InitializeComponent();

            Util.Extern.SendMessage(this.boxObs.Handle, Util.Extern.EM_SETCUEBANNER, 0, "Adicionar observação");

            this.Level = level;

            this.tag = tag;

            this.Show();            
        }

        private void buttonChoiceFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Folder.GetUserPath(Types.UserFolder.Desktop);
            dialog.Multiselect = false;

            if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                String dir = dialog.FileName;

                if(File.Exists(dir))
                {
                    this.buttonChoiceFile.Tag = dir;
                    this.buttonChoiceFile.Text = dialog.SafeFileName;
                    this.buttonSend.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Não foi possível selecionar o arquivo");
                }
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            String dir = Convert.ToString(this.buttonChoiceFile.Tag);
            String name = Path.GetFileNameWithoutExtension(this.buttonChoiceFile.Text);
            String ext = Path.GetExtension(this.buttonChoiceFile.Text);

            if(File.Exists(dir))
            {
                this.buttonSend.Enabled = false;

                //build document
                documento doc = new documento();
                doc.active = true;
                doc.idacc = Addin.CurrentAccount.id;
                doc.name = name;
                doc.observacao = this.boxObs.Text.TrimStart().TrimEnd();
                doc.pages = 1;
                doc.format = ext;
                doc.areaid = Util.User.CurrentArea.id;

                bool change = false;

                Cloud cloud = new Cloud();

                if(this.Level > 0)
                {
                    if (this.Level == 1)
                    {
                        group tag = (group)this.tag;

                        if (tag != null)
                        {                            
                            doc.grupoid = tag.id;
                            doc.subid = 0;
                            change = true;
                        }
                    }  
                    else
                    {
                        subGroup tag = (subGroup)this.tag;

                        if(tag != null)
                        {
                            doc.grupoid = tag.idGroup;
                            doc.subid = tag.id;
                            change = true;
                        }
                    }
                }

                if(change)
                {
                    cloud.UploadFile(dir, doc, this);
                }
                else
                {
                    MessageBox.Show("Não foi possível enviar o arquivo. Tente novamente");
                }
            }
            else
            {
                MessageBox.Show("Não foi possível enviar. O arquivo não existe.");
            }
        }

        private void SendOtherFile_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }        
    }
}
