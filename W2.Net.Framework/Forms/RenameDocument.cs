using System;
using System.Windows.Forms;
using W2.Net.Framework.Tasks;
using W2.Net.Framework.W2Service;

namespace W2.Net.Framework.Forms
{
    public partial class RenameDocument : Form
    {
        private ListView.SelectedListViewItemCollection SelectedItems;

        public RenameDocument(ListView.SelectedListViewItemCollection selectedItems)
        {            
            InitializeComponent();

            if(selectedItems.Count > 0)
            {
                this.SelectedItems = selectedItems;

                if(this.SelectedItems.Count == 1)
                {
                    this.label.Text = "Digite um novo nome para o documento";

                    documento tag = (documento)this.SelectedItems[0].Tag;

                    if(tag != null)
                    {
                        this.boxName.Text = tag.name;
                    }
                }
                else
                {
                    this.label.Text = "Digite um novo nome para os [" + this.SelectedItems.Count + "] documentos";
                }
            }            
            else
            {
                MessageBox.Show("Não foi possível renomear o documento");
            }

            this.ShowDialog();
        }                        

        private async void buttonRename_Click(object sender, EventArgs e)
        {
            String name = this.boxName.Text.TrimStart().TrimEnd();            

            if(!String.IsNullOrEmpty(name))
            {
                if(name.Length >= 2 && name.Length <= 30)
                {
                    if (this.SelectedItems != null && this.SelectedItems.Count > 0)
                    {
                        if (Service.IService != null)
                        {
                            for (Int32 i = 0; i < this.SelectedItems.Count; i++)
                            {
                                documento tag = (documento)this.SelectedItems[i].Tag;
                                
                                tag.name = name;

                                setRenomearDocumentoResponse response = null;

                                try
                                {
                                    response = await Service.IService.setRenomearDocumentoAsync(new setRenomearDocumentoRequest(tag.id, name, Util.User.GetHashID()));
                                }
                                catch
                                {
                                    response = null;
                                }

                                if(response != null)
                                {
                                    Int32 sucess = response.@return;

                                    if (sucess != 0)
                                    {
                                        this.SelectedItems[i].Text = tag.name;
                                        this.SelectedItems[i].Name = tag.name;
                                        this.SelectedItems[i].Tag = tag;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Não foi possível renomear o documento");
                                    }
                                }
                            }                  

                            this.Close();                              
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível renomear o documento. Verifique sua conexão com a internet.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível renomear o documento.");
                    }
                }
                else
                {
                    MessageBox.Show("O nome deve conter entre 2 e 30 caracteres");
                }
            }
            else
            {
                MessageBox.Show("Digite um nome para o documento");
            }

            this.buttonRename.Enabled = true;
        }        

        private void ChangeEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
