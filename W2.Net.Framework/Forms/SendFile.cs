using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using W2.Net.Framework.Tasks;
using W2.Net.Framework.Tasks.AbcDoc;
using W2.Net.Framework.W2Service;

namespace W2.Net.Framework.Forms
{
    public partial class SendFile : Form
    {
        private String FilePath;

        public SendFile(String dir, String name)
        {
            InitializeComponent();

            Util.Extern.SendMessage(this.boxObs.Handle, Util.Extern.EM_SETCUEBANNER, 0, "Adicionar observação");

            this.FilePath = dir;
            this.boxName.Text = name;
        }

        private async void SendFile_Load(object sender, EventArgs e)
        {
            //pr2105sa
            if (Addin.Areas.Count > 0)
            {
                if (Service.IService != null)
                {
                    var areas = Addin.Areas.Where(@area => @area.id != Util.User.DOC_RECENT_ID && @area.id != Util.User.TRASH_ID);

                    foreach (var @area in areas)
                    {
                        //adiciona as areas no menu
                        Bitmap image = null;
                        bool @checked = false;

                        if (@area.id == Util.User.MY_ACCOUNT_ID)
                        {
                            image = Properties.Resources.folder_opened;
                            @checked = true;
                        }
                        else
                        {
                            image = Properties.Resources.folder_closed;
                        }

                        ToolStripMenuItem menuItem = new ToolStripMenuItem(@area.nome, image, MenuChangeArea_Click);
                        menuItem.Tag = @area;
                        menuItem.Name = @area.nome;
                        menuItem.Checked = @checked;
                        this.menuArea.DropDownItems.Add(menuItem);
                    }                        

                    //adiciona o primeiro nivel(area)
                    area initialArea = Addin.Areas[Util.User.MY_ACCOUNT_POS];
                    TreeNode node = new TreeNode(initialArea.nome);
                    node.Tag = initialArea;
                    node.Name = initialArea.nome;
                    this.treeFolders.Nodes.Add(node);

                    if (this.treeFolders.Nodes.Count > 0)
                    {
                        //adiciona o segundo nivel(grupo)
                        getGruposResponse response = null;

                        try
                        {
                            response = await Service.IService.getGruposAsync(new getGruposRequest(initialArea.id, Util.User.GetHashID()));
                        }
                        catch
                        {
                            response = null;
                        }

                        if (response != null)
                        {
                            var groups = response.@return;

                            if (groups != null)
                            {
                                foreach (var @group in groups)
                                {
                                    if (@group.nome != null)
                                    {
                                        @group.nome = @group.nome.TrimStart().TrimEnd();

                                        if (@group.active && !String.IsNullOrEmpty(@group.nome))
                                        {
                                            TreeNode aux = new TreeNode(@group.nome);
                                            aux.Tag = @group;
                                            aux.Name = @group.nome;
                                            this.treeFolders.Nodes[0].Nodes.Add(aux);
                                        }
                                    }
                                }
                            }

                            //expand the node
                            this.treeFolders.Nodes[0].Expand();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Não foi possível concluir o processo de inicialização. Verifique sua conexão com a internet.");
                }
            }
        }

        private async void MenuChangeArea_Click(object sender, EventArgs e)
        {
            if (Service.IService != null)
            {
                var items = this.menuArea.DropDownItems.Cast<ToolStripMenuItem>();
                                 
                foreach(var item in items)
                {
                    item.Checked = false;                    
                }

                var clickedItem = (ToolStripMenuItem)sender;
                clickedItem.Checked = true;

                this.treeFolders.Nodes.Clear();

                area tag = (area)clickedItem.Tag;
                if(tag != null)
                {                    
                    //adiciona o primeiro nivel(area)                        
                    TreeNode node = new TreeNode(tag.nome);
                    node.Tag = tag;
                    node.Name = tag.nome;
                    this.treeFolders.Nodes.Add(node);

                    if (this.treeFolders.Nodes.Count > 0)
                    {
                        //adiciona o segundo nivel(grupo)
                        getGruposResponse response = null;
                        try
                        {
                            response = await Service.IService.getGruposAsync(new getGruposRequest(tag.id, Util.User.GetHashID()));
                        }
                        catch
                        {
                            response = null;
                        }

                        var groups = response.@return;

                        if (groups != null)
                        {
                            foreach (var @group in groups)
                            {
                                if (@group.nome != null)
                                {
                                    @group.nome = @group.nome.TrimStart().TrimEnd();

                                    if (@group.active && !String.IsNullOrEmpty(@group.nome))
                                    {
                                        TreeNode aux = new TreeNode(@group.nome);
                                        aux.Tag = @group;
                                        aux.Name = @group.nome;
                                        this.treeFolders.Nodes[0].Nodes.Add(aux);
                                    }
                                }
                            }
                        }

                        //expande o primeiro nó
                        this.treeFolders.Nodes[0].Expand();
                    }
                }                
            }    
            else
            {
                MessageBox.Show("Não foi possível completar a operação. Verifique sua conexão com a internet.");
            }
        }

        private async void treeFolders_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(e.Node != null)
            {
                if(Service.IService != null)
                {
                    if(e.Node.Level > 0)
                    {
                        if(e.Node.Nodes.Count == 0)
                        {
                            getSubGruposResponse subGroupsResponse = null;

                            try
                            {
                                if (e.Node.Level == 1)
                                {
                                    //grupo

                                    group tag = (group)e.Node.Tag;

                                    if (tag.id != 0)
                                    {
                                        subGroupsResponse = await Service.IService.getSubGruposAsync(new getSubGruposRequest(tag.id, 0, Util.User.GetHashID()));
                                    }
                                }
                                else
                                {
                                    //sub grupo

                                    subGroup tag = (subGroup)e.Node.Tag;

                                    if (tag.id != 0 && tag.idGroup != 0)
                                    {
                                        subGroupsResponse = await Service.IService.getSubGruposAsync(new getSubGruposRequest(tag.idGroup, tag.id, Util.User.GetHashID()));
                                    }
                                }
                            }
                            catch
                            {
                                subGroupsResponse = null;
                            }

                            var subGroups = subGroupsResponse.@return;

                            if(subGroups != null && subGroups.Length > 0)
                            {
                                foreach(var sub in subGroups)
                                {
                                    if(sub.nome != null)
                                    {
                                        sub.nome = sub.nome.TrimStart().TrimEnd();
                                        if (!String.IsNullOrEmpty(sub.nome) && sub.ativo && sub.id != 0)
                                        {
                                            TreeNode node = new TreeNode(sub.nome);
                                            node.Tag = sub;
                                            node.Name = sub.nome;
                                            e.Node.Nodes.Add(node);
                                        }
                                    }
                                }

                                e.Node.Expand();
                            }
                        }                        
                    }
                }
                else
                {
                    MessageBox.Show("Não foi possível completar a operação. Verifique sua conexão com a internet.");
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (File.Exists(this.FilePath))
            {
                var node = this.treeFolders.SelectedNode;
                if (node != null)
                {
                    if (node.Level > 0)
                    {
                        this.buttonSave.Enabled = false;

                        Thread t = new Thread(() =>
                        {
                            String name = this.boxName.Text.TrimStart().TrimEnd();

                            if (!String.IsNullOrEmpty(name))
                            {
                                String obs = this.boxObs.Text.TrimStart().TrimEnd();
                                area @area = (area)this.treeFolders.Nodes[0].Tag;

                                if (@area != null)
                                {
                                    bool sucess = false;
                                    Int64 groupId = 0;
                                    Int64 subId = 0;

                                    if (node.Level == 1)
                                    {
                                        group tag = (group)node.Tag;

                                        if (tag != null)
                                        {
                                            groupId = tag.id;
                                            sucess = true;
                                        }
                                    }
                                    else
                                    {
                                        subGroup tag = (subGroup)node.Tag;

                                        if (tag != null)
                                        {
                                            groupId = tag.idGroup;
                                            subId = tag.id;
                                            sucess = true;
                                        }
                                    }

                                    if (sucess)
                                    {
                                        //build document
                                        documento doc = new documento();
                                        doc.active = true;
                                        doc.areaid = @area.id;
                                        doc.format = Path.GetExtension(this.FilePath);
                                        doc.grupoid = groupId;
                                        doc.idacc = Addin.CurrentAccount.id;
                                        doc.name = name;
                                        doc.observacao = obs;
                                        doc.pages = 1;
                                        doc.subid = subId;

                                        Cloud cloud = new Cloud();
                                        cloud.UploadFile(this.FilePath, doc, this);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Não foi possível salvar o documento.");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Não foi possível salvar o documento.");
                                }
                            }

                            else
                            {
                                MessageBox.Show("Digite um nome para o documento");
                            }

                            this.Invoke((MethodInvoker)(() => this.buttonSave.Enabled = true));                            
                        });

                        t.Start();                        
                    }
                    else
                    {
                        MessageBox.Show("Selecione uma pasta para salvar o documento");
                    }
                }
            }
            else
            {
                MessageBox.Show("Não foi possível enviar. O arquivo não existe.");
            }            
        }

        private void buttonAddFolder_Click(object sender, EventArgs e)
        {
            if (this.treeFolders.SelectedNode != null)
            {
                new AddFolder(this.treeFolders.SelectedNode);
            }
            else
            {
                MessageBox.Show("Selecione uma pasta para criar");
            }
        }        

        private void MyAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }        
    }
}
