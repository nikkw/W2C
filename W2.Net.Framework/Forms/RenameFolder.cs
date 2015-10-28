using System;
using System.Windows.Forms;
using W2.Net.Framework.Tasks;
using W2.Net.Framework.W2Service;

namespace W2.Net.Framework.Forms
{
    public partial class RenameFolder : Form
    {
        private TreeNode SelectedNode;

        public RenameFolder(TreeNode node)
        {
            InitializeComponent();

            this.SelectedNode = node;

            if (this.SelectedNode.Level == 1)
            {  //grupo
                group tag = (group)this.SelectedNode.Tag;

                if(tag != null)
                {
                    this.boxName.Text = tag.nome;
                }
            }
            else
            {
                subGroup tag = (subGroup)this.SelectedNode.Tag;

                if(tag != null)
                {
                    this.boxName.Text = tag.nome;
                }
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
                    if (this.SelectedNode != null)
                    {
                        if (Service.IService != null)
                        {
                            if (this.SelectedNode.Level > 0)
                            {
                                this.buttonRename.Enabled = false;

                                String newName = string.Empty;
                                object newTag = null;

                                if (this.SelectedNode.Level == 1)
                                {  //grupo

                                    group tag = (group)this.SelectedNode.Tag;
                                    
                                    if(tag != null && tag.active && tag.id != 0)
                                    {
                                        group newGroup = tag;

                                        newGroup.nome = name;

                                        setGrupoResponse response = null;

                                        try
                                        {
                                            response = await Service.IService.setGrupoAsync(new setGrupoRequest(newGroup, Util.User.GetHashID()));
                                        }
                                        catch
                                        {
                                            response = null;
                                        }

                                        if(response != null)
                                        {
                                            //affected rows
                                            Int32 sucess = response.@return;

                                            if(sucess != 0)
                                            {
                                                newName = name;
                                                newTag = newGroup;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    subGroup tag = (subGroup)this.SelectedNode.Tag;

                                    if(tag != null && tag.ativo && tag.id != 0)
                                    {
                                        subGroup newSubGroup = tag;

                                        newSubGroup.nome = name;

                                        setSubResponse response = null;

                                        try
                                        {
                                            response = await Service.IService.setSubAsync(new setSubRequest(newSubGroup, Util.User.GetHashID()));
                                        }
                                        catch
                                        {
                                            response = null;
                                        }

                                        if(response != null)
                                        {
                                            //affected rows
                                            Int32 sucess = response.@return;

                                            if(sucess != 0)
                                            {
                                                newName = name;
                                                newTag = newSubGroup;
                                            }
                                        }
                                    }
                                }

                                if(!String.IsNullOrEmpty(newName) && newTag != null)
                                {
                                    this.SelectedNode.Text = newName;
                                    this.SelectedNode.Name = newName;
                                    this.SelectedNode.Tag = newTag;
                                }
                                else
                                {
                                    MessageBox.Show("Não foi possível renomear a pasta.");
                                }

                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Não é possível renomear uma área");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível renomear a pasta. Verifique sua conexão com a internet.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível renomear a pasta.");
                    }
                }
                else
                {
                    MessageBox.Show("O nome deve conter entre 2 e 30 caracteres");
                }
            }
            else
            {
                MessageBox.Show("Digite um nome para a pasta");
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
