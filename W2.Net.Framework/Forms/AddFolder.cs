using System;
using System.Linq;
using System.Windows.Forms;
using W2.Net.Framework;
using W2.Net.Framework.W2Service;
using W2.Net.Framework.Tasks;

namespace W2.Net.Framework.Forms
{
    public partial class AddFolder : Form
    {
        private TreeNode SelectedNode;

        public AddFolder(TreeNode node)
        {
            InitializeComponent();

            this.SelectedNode = node;

            this.ShowDialog();
        }

        private async void buttonCreate_Click(object sender, EventArgs e)
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
                            this.buttonCreate.Enabled = false;

                            TreeNode newNode = null;

                            if (this.SelectedNode.Level == 0)
                            {
                                area tag = (area)this.SelectedNode.Tag;

                                if (tag != null)
                                {
                                    group folder = new group();

                                    if (tag.id != Util.User.DOC_RECENT_ID && tag.id != Util.User.TRASH_ID)
                                    {
                                        folder.active = true;
                                        folder.idAcc = Addin.CurrentAccount.id;
                                        folder.idArea = tag.id;
                                        folder.nome = name;

                                        newGrupoResponse groupResponse = null;

                                        try
                                        {
                                            groupResponse = await Service.IService.newGrupoAsync(new newGrupoRequest(folder, Util.User.GetHashID()));
                                        }
                                        catch
                                        {
                                            groupResponse = null;
                                        }

                                        if (groupResponse != null)
                                        {
                                            group groupReturned = groupResponse.@return;

                                            if(groupReturned != null)
                                            {
                                                Int64 idReturned = groupReturned.id;

                                                if(idReturned != 0)
                                                {
                                                    folder.id = idReturned;

                                                    newNode = new TreeNode(name);
                                                    newNode.Tag = folder;
                                                    newNode.Name = name;
                                                }
                                            }                                       
                                        }
                                    }
                                }
                            }

                            else
                            {
                                subGroup folder = new subGroup();
                                folder.ativo = true;
                                folder.nome = name;
                                folder.idGroup = 0;                                

                                if (this.SelectedNode.Level == 1)
                                {
                                    group tag = (group)this.SelectedNode.Tag;

                                    if (tag != null)
                                    {
                                        folder.idGroup = tag.id;
                                        folder.idPai = 0;
                                    }
                                }
                                else
                                {
                                    subGroup tag = (subGroup)this.SelectedNode.Tag;

                                    if (tag != null)
                                    {
                                        folder.idGroup = tag.idGroup;
                                        folder.idPai = tag.id;
                                    }
                                }

                                if (folder.idGroup != 0)
                                {
                                    newSubGrupoResponse subGroupResponse = null;

                                    try
                                    {
                                        subGroupResponse = await Service.IService.newSubGrupoAsync(new newSubGrupoRequest(folder, Util.User.GetHashID()));
                                    }
                                    catch
                                    {
                                        subGroupResponse = null;
                                    }

                                    if (subGroupResponse != null)
                                    {
                                        subGroup subGroupReturned = subGroupResponse.@return;

                                        if (subGroupReturned != null && subGroupReturned.id != 0)
                                        {
                                            newNode = new TreeNode(subGroupReturned.nome);
                                            newNode.Tag = subGroupReturned;
                                            newNode.Name = subGroupReturned.nome;                                            
                                        }
                                    }
                                }
                            }

                            if (newNode != null)
                            {
                                this.SelectedNode.Nodes.Add(newNode);

                                this.SelectedNode.Expand();
                            }
                            else
                            {
                                MessageBox.Show("Não foi possível criar a pasta.");
                            }

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível criar a pasta. Verifique sua conexão com a internet.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível criar a pasta.");
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

            this.buttonCreate.Enabled = true;
        }

        private void ChangeEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }        
    }
}
