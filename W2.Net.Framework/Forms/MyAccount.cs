using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using W2.Net.Framework.Tasks;
using W2.Net.Framework.Tasks.AbcDoc;
using W2.Net.Framework.W2Service;
using W2.Net.Info;

namespace W2.Net.Framework.Forms
{
    public partial class MyAccount : Form
    {
        private ContextMenu m_ListMenu;

        private ContextMenu ListMenu
        {
            get
            {
                if(this.m_ListMenu == null)
                {
                    this.m_ListMenu = new ContextMenu();

                    this.m_ListMenu.MenuItems.Add(new MenuItem("Download"));
                    this.m_ListMenu.MenuItems[LISTMENU_DOWNLOAD_INDEX].Click += new EventHandler(this.buttonDownloadDocument_Click);

                    this.m_ListMenu.MenuItems.Add(new MenuItem("Renomear"));
                    this.m_ListMenu.MenuItems[LISTMENU_RENAME_INDEX].Click += new EventHandler(this.buttonRenameDocument_Click);

                    this.m_ListMenu.MenuItems.Add(new MenuItem("Restaurar"));
                    this.m_ListMenu.MenuItems[LISTMENU_RESTORE_INDEX].Click += new EventHandler(this.buttonRestoreDocument_Click);

                    this.m_ListMenu.MenuItems.Add(new MenuItem("Excluir"));
                    this.m_ListMenu.MenuItems[LISTMENU_DELETE_INDEX].Click += new EventHandler(this.buttonDeleteDocument_Click);
                }

                return this.m_ListMenu;
            }
        }

        private const Int32 LISTMENU_DOWNLOAD_INDEX = 0;
        private const Int32 LISTMENU_RENAME_INDEX = 1;
        private const Int32 LISTMENU_RESTORE_INDEX = 2;
        private const Int32 LISTMENU_DELETE_INDEX = 3;

        private ContextMenu m_TreeMenu;

        private ContextMenu TreeMenu
        {
            get
            {
                if(m_TreeMenu == null)
                {
                    m_TreeMenu = new ContextMenu();

                    this.m_TreeMenu.MenuItems.Add("Enviar arquivo");
                    this.m_TreeMenu.MenuItems[TREEMENU_ADDDOCUMENT_INDEX].Click += new EventHandler(this.buttonSendDocument_Click);

                    this.m_TreeMenu.MenuItems.Add("Adicionar pasta");
                    this.m_TreeMenu.MenuItems[TREEMENU_ADDFOLDER_INDEX].Click += new EventHandler(this.buttonAddFolder_Click);

                    this.m_TreeMenu.MenuItems.Add("Renomear");
                    this.m_TreeMenu.MenuItems[TREEMENU_RENAMEFOLDER_INDEX].Click += new EventHandler(this.buttonRenameFolder_Click);

                    this.m_TreeMenu.MenuItems.Add("Remover");
                    this.m_TreeMenu.MenuItems[TREEMENU_REMOVEFOLDER_INDEX].Click += new EventHandler(this.buttonRemoveFolder_Click);
                }

                return m_TreeMenu;
            }
        }

        private const Int32 TREEMENU_ADDDOCUMENT_INDEX = 0;
        private const Int32 TREEMENU_ADDFOLDER_INDEX = 1;
        private const Int32 TREEMENU_RENAMEFOLDER_INDEX = 2;
        private const Int32 TREEMENU_REMOVEFOLDER_INDEX = 3;

        public MyAccount()
        {
            InitializeComponent();

            Util.Extern.SendMessage(this.boxSearch.TextBox.Handle, Util.Extern.EM_SETCUEBANNER, 0, "Pesquisar");
        }

        private async void MyAccount_Load(object sender, EventArgs e)
        {
            if(Addin.Areas.Count > 0)
            {
                if (Service.IService != null)
                {
                    ToolStripMenuItem[] areaMenu = new ToolStripMenuItem[Addin.Areas.Count];

                    Int32 iterator = 0;
                    Addin.Areas.ForEach(value =>
                    {
                        Bitmap image = null;

                        if (iterator == Addin.Areas.Count - 1)
                        {   //lixeira - trash icon
                            image = new Bitmap(Properties.Resources.trash);
                        }
                        else if (iterator == Util.User.DOC_RECENT_POS)
                        {
                            image = new Bitmap(Properties.Resources.folder_opened);
                        }
                        else
                        {
                            image = new Bitmap(Properties.Resources.folder_closed);
                        }

                        areaMenu[iterator] = new ToolStripMenuItem(value.nome, image, MenuChangeArea_Click);
                        areaMenu[iterator].Tag = value;
                        areaMenu[iterator].Name = value.nome;

                        this.menuArea.DropDownItems.Add(areaMenu[iterator]);

                        iterator++;
                    });


                    //seta a area documentos recentes como area ativa
                    areaMenu[Util.User.DOC_RECENT_POS].Checked = true;

                    //seta a currentarea
                    Util.User.CurrentArea = Addin.Areas[Util.User.DOC_RECENT_POS];

                    //seta o titulo da janela como documentos recentes
                    String windowText = Addin.Areas[Util.User.DOC_RECENT_POS].nome;

                    if (windowText.Length > 30)
                    {
                        windowText = windowText.Substring(0, 30);
                    }

                    this.Text = windowText;

                    String login = Addin.CurrentAccount.fullName.ToLower().Split(' ')[0];

                    if (login != null)
                    {
                        if (String.IsNullOrEmpty(login))
                        {
                            login = "Configurações";
                        }
                        else
                        {
                            login = (Char.ToUpper(login[0]) + login.Substring(1));

                            if (login.Length > 20)
                            {
                                login = login.Substring(0, 20);
                            }
                        }
                    }

                    //seta o nome do botao de configuracoes para o login
                    this.buttonAccount.Text = login;

                    //adiciona um nó com nome documentos recentes
                    TreeNode node = new TreeNode(Addin.Areas[Util.User.DOC_RECENT_POS].nome);
                    node.Tag = Addin.Areas[Util.User.DOC_RECENT_POS];
                    node.Name = Addin.Areas[Util.User.DOC_RECENT_POS].nome;
                    this.treeFolders.Nodes.Add(node);

                    //get recent documents
                    getListaRecentesResponse recentDocsResponse = null;

                    try
                    {
                        recentDocsResponse = await Service.IService.getListaRecentesAsync(new getListaRecentesRequest(Util.User.GetHashID()));
                    }
                    catch
                    {
                        recentDocsResponse = null;
                    }

                    if (recentDocsResponse != null)
                    {
                        documento[] recentDocs = recentDocsResponse.@return;

                        Util.Document.Assembly(this.list, recentDocs, DocumentAssemblyType.Recent, false);                        
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
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            if (item != null)
            {
                if (Service.IService != null)
                {
                    for (Int32 i = 0; i < this.menuArea.DropDownItems.Count; i++)
                    {
                        ToolStripMenuItem menuItem = (ToolStripMenuItem)this.menuArea.DropDownItems[i];

                        //uncheck all
                        menuItem.Checked = false;

                        //fix icons
                        if (i != Addin.Areas.Count - 1)
                        {  //se nao for a lixeira
                            menuItem.Image = new Bitmap(Properties.Resources.folder_closed);
                        }
                        else
                        {
                            menuItem.Image = new Bitmap(Properties.Resources.trash);
                        }
                    }

                    area areaTag = (area)item.Tag;
                    Util.User.CurrentArea = areaTag;
                    Int32 areaId = areaTag.id;

                    if (areaId == Util.User.TRASH_ID)
                    {
                        item.Image = new Bitmap(Properties.Resources.trash_open);
                    }
                    else
                    {
                        item.Image = new Bitmap(Properties.Resources.folder_opened);
                    }

                    fixFilterMenu(this.filters.DropDownItems[0]);

                    Util.Document.Documents = null;

                    //check clicked item
                    item.Checked = true;

                    //clear list of documents
                    this.list.Items.Clear();

                    //clear list of groups
                    this.treeFolders.Nodes.Clear();

                    //change the window text
                    String windowText = item.Name;

                    if (windowText.Length > 30)
                    {
                        windowText = windowText.Substring(0, 30);
                    }

                    this.Text = windowText;

                    this.buttonAddFolder.Visible = false;
                    this.separatorFolder1.Visible = false;
                    this.buttonRenameFolder.Visible = false;
                    this.separatorFolder2.Visible = false;
                    this.buttonRemoveFolder.Visible = false;
                    this.buttonDownloadDocument.Visible = false;
                    this.buttonRenameDocument.Visible = false;
                    this.buttonRestoreDocument.Visible = false;
                    this.buttonDeleteDocument.Visible = false;
                    this.documentSeparator.Visible = false;
                    this.documentSeparator1.Visible = false;
                    this.documentSeparator2.Visible = false;
                    this.buttonSendDocument.Visible = false;
                    this.separatorFolder.Visible = false;
                        
                    //adiciona o primeiro nivel do nó: área
                    TreeNode node = null;
                    for (Int32 i = 0; i < Addin.Areas.Count; i++)
                    {
                        if (Addin.Areas[i].id == areaId)
                        {
                            node = new TreeNode(Addin.Areas[i].nome);
                            node.Tag = Addin.Areas[i];
                            node.Name = Addin.Areas[i].nome;
                            break;
                        }
                    }

                    if (node != null)
                    {
                        this.treeFolders.Nodes.Add(node);

                        if (areaId == Util.User.DOC_RECENT_ID)
                        {
                            //get recent documents
                            getListaRecentesResponse recentDocsResponse = null;

                            try
                            {
                                recentDocsResponse = await Service.IService.getListaRecentesAsync(new getListaRecentesRequest(Util.User.GetHashID()));
                            }
                            catch
                            {
                                recentDocsResponse = null;
                            }

                            if (recentDocsResponse != null)
                            {
                                documento[] recentDocs = recentDocsResponse.@return;

                                Util.Document.Assembly(this.list, recentDocs, DocumentAssemblyType.Recent, false);
                            }
                        }

                        else if (areaId == Util.User.TRASH_ID)
                        {
                            getDocumentosLixeiraGeralResponse response = null;

                            try
                            {
                                response = await Service.IService.getDocumentosLixeiraGeralAsync(new getDocumentosLixeiraGeralRequest(Util.User.GetHashID()));
                            }
                            catch
                            {
                                response = null;
                            }

                            if (response != null)
                            {
                                documento[] docs = response.@return;

                                Util.Document.Assembly(this.list, docs, DocumentAssemblyType.Trash, true);
                            }
                        }
                        else
                        {
                            getGruposResponse groupResponse = null;

                            try
                            {
                                groupResponse = await Service.IService.getGruposAsync(new getGruposRequest(areaId, Util.User.GetHashID()));
                            }
                            catch
                            {
                                groupResponse = null;
                            }

                            if (groupResponse != null)
                            {
                                group[] groups = groupResponse.@return;

                                if (groups != null)
                                {
                                    List<TreeNode> nodes = new List<TreeNode>();

                                    Array.ForEach(groups, group =>
                                    {
                                        if (group.nome != null)
                                        {
                                            group.nome = group.nome.TrimStart().TrimEnd();

                                            if (group.active && !String.IsNullOrEmpty(group.nome) && this.treeFolders.Nodes.Count > 0)
                                            {
                                                TreeNode auxNode = new TreeNode(group.nome);
                                                auxNode.Tag = group;
                                                auxNode.Name = group.nome;
                                                nodes.Add(auxNode);
                                            }
                                        }
                                    });

                                    //this.Invoke((MethodInvoker)(() =>
                                    //{
                                        if (nodes != null)
                                        {
                                            nodes.ForEach(value => this.treeFolders.Nodes[0].Nodes.Add(value));

                                            this.treeFolders.Nodes[0].Expand();
                                        }                                        
                                    //}));
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Não foi possível alternar a área. Verifique sua conexão com a internet.");
                }
            }
            else
            {
                MessageBox.Show("Não foi possível alternar a área.");
            }            
        }

        private async void treeFolders_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node != null)
                {
                    if (Service.IService != null)
                    {
                        if (e.Node.Level > 0)
                        {  //se nao for area

                            this.buttonAddFolder.Visible = true;
                            this.buttonRenameFolder.Visible = true;
                            this.buttonRemoveFolder.Visible = true;
                            this.separatorFolder1.Visible = true;
                            this.separatorFolder2.Visible = true;
                            this.buttonSendDocument.Visible = true;
                            this.separatorFolder.Visible = true;

                            if (e.Node.Nodes.Count == 0)
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

                                if (subGroupsResponse != null)
                                {
                                    subGroup[] subGroups = subGroupsResponse.@return;

                                    if (subGroups != null && subGroups.Length > 0)
                                    {
                                        List<TreeNode> nodes = new List<TreeNode>();

                                        Array.ForEach(subGroups, sub =>
                                        {
                                            if (sub.nome != null)
                                            {
                                                sub.nome = sub.nome.TrimStart().TrimEnd();

                                                if (!String.IsNullOrEmpty(sub.nome) && sub.ativo && sub.id != 0)
                                                {
                                                    TreeNode node = new TreeNode(sub.nome);
                                                    node.Tag = sub;
                                                    node.Name = sub.nome;
                                                    nodes.Add(node);
                                                }
                                            }
                                        });

                                        //this.Invoke((MethodInvoker)(() =>
                                        //{
                                            if (nodes != null)
                                            {
                                                nodes.ForEach(value =>
                                                {
                                                    e.Node.Nodes.Add(value);
                                                });

                                                e.Node.Expand();
                                            }
                                        //}));
                                    }
                                }
                            }                            

                            this.list.Items.Clear();

                            //listagem de documentos
                            getListaDocumentosResponse docsResponse = null;

                            try
                            {
                                if (e.Node.Level == 1)
                                {
                                    group tag = (group)e.Node.Tag;

                                    if (tag != null && tag.id != 0 && tag.active)
                                    {
                                        docsResponse = await Service.IService.getListaDocumentosAsync(new getListaDocumentosRequest(tag.id, 0, Util.User.GetHashID()));
                                    }
                                }
                                else
                                {
                                    subGroup tag = (subGroup)e.Node.Tag;

                                    if (tag != null && tag.idGroup != 0 && tag.id != 0)
                                    {
                                        docsResponse = await Service.IService.getListaDocumentosAsync(new getListaDocumentosRequest(tag.idGroup, tag.id, Util.User.GetHashID()));
                                    }
                                }
                            }
                            catch
                            {
                                docsResponse = null;
                            }

                            if (docsResponse != null)
                            {
                                documento[] docs = docsResponse.@return;

                                Util.Document.Assembly(this.list, docs, DocumentAssemblyType.Tree, clear:false);

                                if(docs == null || docs.Length == 0)
                                {
                                    Util.Document.Documents = null;
                                }
                            }
                        }
                        else
                        {
                            area tag = (area)e.Node.Tag;

                            if (tag.id == Util.User.DOC_RECENT_ID || tag.id == Util.User.TRASH_ID)
                            {
                                this.buttonAddFolder.Visible = false;
                            }
                            else
                            {
                                this.buttonAddFolder.Visible = true;

                                //this.list.Items.Clear();
                                //this.list.Columns.Clear();
                            }

                            this.buttonRenameFolder.Visible = false;
                            this.buttonRemoveFolder.Visible = false;
                            this.separatorFolder1.Visible = false;
                            this.separatorFolder2.Visible = false;
                            this.buttonSendDocument.Visible = false;
                            this.separatorFolder.Visible = false;

                            //e.Node.Expand();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível completar a busca. Verifique sua conexão com a internet.");
                    }

                    if (e.Action == TreeViewAction.ByMouse)
                    {
                        //e.Node.Expand();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }                                 

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            Util.Forms.Show(typeof(global::W2.Net.Framework.Forms.UserSettings));
        }

        private void buttonLoggout_Click(object sender, EventArgs e)
        {
            Addin.InSession = false;

            Util.Forms.CloseAll();

            Util.Forms.Show(typeof(global::W2.Net.Framework.Forms.Login));

            String file = Path.Combine(Folder.GetWatcherPath(), Folder.LOGOFF_ACTION_FILE_NAME);
            File.Create(file).Close();            
        }

        private void buttonSendDocument_Click(object sender, EventArgs e)
        {
            if (this.treeFolders.SelectedNode != null)
            {
                new SendOtherFile(this.treeFolders.SelectedNode.Level, this.treeFolders.SelectedNode.Tag);
            }
            else
            {
                MessageBox.Show("Selecione uma pasta para enviar um arquivo!");
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

        private void buttonRenameFolder_Click(object sender, EventArgs e)
        {
            if (this.treeFolders.SelectedNode != null)
            {
                if (this.treeFolders.SelectedNode.Level > 0)
                {
                    new RenameFolder(this.treeFolders.SelectedNode);
                }
                else
                {
                    MessageBox.Show("Não é possível renomear uma área");
                }
            }
            else
            {
                MessageBox.Show("Selecione uma pasta para renomear");
            }            
        }

        private async void buttonRemoveFolder_Click(object sender, EventArgs e)
        {
            if(this.treeFolders.SelectedNode != null)
            {   
                if(this.treeFolders.SelectedNode.Level > 0)
                {
                    if (MessageBox.Show("Deseja remover esta pasta?", "", MessageBoxButtons.YesNo, MessageBoxIcon.None) == DialogResult.Yes)
                    {
                        this.buttonRemoveFolder.Enabled = false;

                        bool remove = false;

                        if (this.treeFolders.SelectedNode.Level == 1)
                        {
                            group tag = (group)this.treeFolders.SelectedNode.Tag;

                            if (tag == null || !tag.active || tag.id == 0)
                            {
                                remove = true;
                            }
                            else
                            {
                                setExcluirGrupoResponse response = null;

                                try
                                {
                                    response = await Service.IService.setExcluirGrupoAsync(new setExcluirGrupoRequest(tag.id, Util.User.GetHashID()));
                                }
                                catch
                                {
                                    response = null;
                                }

                                if(response != null)
                                {
                                    bool sucess = response.@return;

                                    if(sucess)
                                    {
                                        remove = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            subGroup tag = (subGroup)this.treeFolders.SelectedNode.Tag;

                            if (tag == null || !tag.ativo || tag.id == 0)
                            {
                                remove = true;
                            }
                            else
                            {
                                setExcluirSubResponse response = null;

                                try
                                {
                                    response = await Service.IService.setExcluirSubAsync(new setExcluirSubRequest(tag.id, Util.User.GetHashID()));
                                }
                                catch
                                {
                                    response = null;
                                }

                                if(response != null)
                                {
                                    bool sucess = response.@return;

                                    if(sucess)
                                    {
                                        remove = true;
                                    }
                                }
                            }
                        }

                        if (remove)
                        {
                            this.treeFolders.SelectedNode.Remove();
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível remover a pasta.");
                        }
                    }
                }      
                else
                {
                    MessageBox.Show("Não é possível renomear uma área");
                }
            }
            else
            {
                MessageBox.Show("Selecione uma pasta para remover");
            }

            this.buttonRemoveFolder.Enabled = true;
        }        

        private void buttonDownloadDocument_Click(object sender, EventArgs e)
        {
            if (this.list.SelectedItems != null && this.list.SelectedItems.Count > 0 && this.list.Columns.Count > 1)
            {
                this.buttonDownloadDocument.Enabled = false;

                Cloud cloud = new Cloud();

                for(Int32 i = 0; i < this.list.SelectedItems.Count; i++)
                {
                    documento tag = (documento)this.list.SelectedItems[i].Tag;

                    if(tag != null && !String.IsNullOrEmpty(tag.hash))
                    {
                        cloud.DownloadFile(tag, this);                        
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível completar o download.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione algum arquivo para fazer download");
            }
        }

        private void buttonRenameDocument_Click(object sender, EventArgs e)
        {
            if (this.list.SelectedItems != null && this.list.SelectedItems.Count > 0 && this.list.Columns.Count > 1)
            {
                this.buttonRenameDocument.Enabled = false;

                new RenameDocument(this.list.SelectedItems);
            }
            else
            {
                MessageBox.Show("Selecione algum arquivo para renomear");
            }

            this.buttonRenameDocument.Enabled = true;
        }

        private async void buttonDeleteDocument_Click(object sender, EventArgs e)
        {
            if (this.list.SelectedItems != null && this.list.SelectedItems.Count > 0 && this.list.Columns.Count > 1)
            {
                String message = String.Empty;

                if (Util.User.CurrentArea.id == Util.User.TRASH_ID)
                {
                    if (this.list.SelectedItems.Count == 1)
                    {
                        documento doc = (documento)this.list.SelectedItems[0].Tag;

                        message = String.Format("Deseja remover PERMANENTEMENTE o arquivo {0}?", doc.name);
                    }
                    else
                    {
                        message = String.Format("Deseja remover PERMANENTEMENTE os {0} arquivos selecionados?", this.list.SelectedItems.Count);
                    }
                }
                else
                {
                    if (this.list.SelectedItems.Count == 1)
                    {
                        documento doc = (documento)this.list.SelectedItems[0].Tag;

                        message = String.Format("Deseja enviar o arquivo {0} para lixeira?", doc.name);
                    }
                    else
                    {
                        message = String.Format("Deseja enviar os {0} arquivos selecionados para a lixeira?", this.list.SelectedItems.Count);
                    }
                }

                if (MessageBox.Show(message, "", MessageBoxButtons.YesNo, MessageBoxIcon.None) == DialogResult.Yes)
                {
                    this.buttonDeleteDocument.Enabled = false;

                    bool remove = false;

                    documento[] docs = new documento[this.list.SelectedItems.Count];

                    for(Int32 i = 0; i < this.list.SelectedItems.Count; i++)
                    {
                        documento tag = (documento)this.list.SelectedItems[i].Tag;

                        docs[i] = tag;
                        
                        if (Util.User.CurrentArea.id == Util.User.TRASH_ID)
                        {
                            setExclusaoDefinitivaDocumentoResponse response = null;

                            try
                            {
                                response = await Service.IService.setExclusaoDefinitivaDocumentoAsync(new setExclusaoDefinitivaDocumentoRequest(tag.id, Util.User.GetHashID()));
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
                                    remove = true;
                                }
                            }
                        }
                        else
                        {
                            setExcluirDocumentoResponse response = null;

                            try
                            {
                                response = await Service.IService.setExcluirDocumentoAsync(new setExcluirDocumentoRequest(tag.id, Util.User.GetHashID()));
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
                                    remove = true;
                                }
                            }
                        }
                    }

                    if(remove)
                    {
                        for(Int32 i = 0; i < this.list.SelectedItems.Count; i++)
                        {
                            this.list.SelectedItems[i].Remove();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível remover o arquivo");
                    }

                    if(this.list.Items.Count == 0)
                    {
                        this.buttonDownloadDocument.Visible = false;
                        this.buttonRenameDocument.Visible = false;
                        this.buttonDeleteDocument.Visible = false;
                        this.buttonRestoreDocument.Visible = false;
                        this.documentSeparator.Visible = false;
                        this.documentSeparator1.Visible = false;
                        this.documentSeparator2.Visible = false;

                        Util.Document.CreateNoResultData(this.list);
                    }
                }
            }
            else
            {
                MessageBox.Show("Não foi possível remover o arquivo.");
            }

            this.buttonDeleteDocument.Enabled = true;
        }

        private void list_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                this.buttonDeleteDocument_Click(null, null);
            }

            else if(e.KeyCode == Keys.Enter)
            {
                if(Util.User.CurrentArea.id != Util.User.TRASH_ID &&
                    this.list.Columns.Count > 1 && this.list.SelectedItems.Count > 0)
                {
                    this.buttonDownloadDocument_Click(sender, null);
                }
            }                
        }

        private async void buttonRestoreDocument_Click(object sender, EventArgs e)
        {
            if (this.list.SelectedItems != null && this.list.SelectedItems.Count > 0 && this.list.Columns.Count > 1)
            {
                if(Util.User.CurrentArea.id == Util.User.TRASH_ID)
                {
                    this.buttonRestoreDocument.Enabled = false;

                    bool restore = false;

                    documento[] docs = new documento[this.list.SelectedItems.Count];

                    for (Int32 i = 0; i < this.list.SelectedItems.Count; i++)
                    {
                        documento tag = (documento)this.list.SelectedItems[i].Tag;

                        docs[i] = tag;

                        setRestaurarDocumentoResponse response = null;

                        try
                        {
                            response = await Service.IService.setRestaurarDocumentoAsync(new setRestaurarDocumentoRequest(tag.id, Util.User.GetHashID()));
                        }
                        catch
                        {
                            response = null;
                        }
                        
                        if(response != null)
                        {
                            bool sucess = response.@return;

                            if(sucess)
                            {
                                restore = true;
                            }
                        }
                    }

                    if(restore)
                    {
                        for (Int32 i = 0; i < this.list.SelectedItems.Count; i++)
                        {
                            this.list.SelectedItems[i].Remove();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível restaurar o arquivo");
                    }

                    if (this.list.Items.Count == 0)
                    {
                        this.buttonDownloadDocument.Visible = false;
                        this.buttonRenameDocument.Visible = false;
                        this.buttonDeleteDocument.Visible = false;
                        this.buttonRestoreDocument.Visible = false;
                        this.documentSeparator.Visible = false;
                        this.documentSeparator1.Visible = false;
                        this.documentSeparator2.Visible = false;

                        Util.Document.CreateNoResultData(this.list);
                    }
                }
            }

            this.buttonRestoreDocument.Enabled = true;
        }


        private void list_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            bool value = true;            
            
            if (this.list.SelectedItems.Count == 0 || this.list.Columns.Count <= 1)
            {
                value = false;
            }

            if (Util.User.CurrentArea.id != Util.User.TRASH_ID)
            {
                this.buttonDownloadDocument.Visible = value;
                this.buttonRenameDocument.Visible = value;
                this.buttonDeleteDocument.Visible = value;
                this.documentSeparator.Visible = value;
                this.documentSeparator2.Visible = value;

                this.documentSeparator1.Visible = false;
                this.buttonRestoreDocument.Visible = false;
            }
            else
            {
                this.buttonDownloadDocument.Visible = false;
                this.buttonRenameDocument.Visible = false;
                this.documentSeparator2.Visible = false;
                this.documentSeparator1.Visible = false;

                this.documentSeparator.Visible = value;
                this.buttonRestoreDocument.Visible = value;
                this.buttonDeleteDocument.Visible = value;             
            }            
        }

        private void list_Leave(object sender, EventArgs e)
        {
            this.buttonDownloadDocument.Visible = false;
            this.buttonRenameDocument.Visible = false;
            this.buttonDeleteDocument.Visible = false;
            this.buttonRestoreDocument.Visible = false;
            this.documentSeparator.Visible = false;
            this.documentSeparator1.Visible = false;
            this.documentSeparator2.Visible = false;  
        }

        private void MyAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void list_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                ListViewHitTestInfo test = this.list.HitTest(e.Location);

                if(test.Item != null && this.list.Items != null && this.list.Items.Count > 0 && this.ListMenu.MenuItems != null)
                {                   
                    if(Util.User.CurrentArea.id != Util.User.TRASH_ID)
                    {
                        this.ListMenu.MenuItems[LISTMENU_DOWNLOAD_INDEX].Visible = true;
                        this.ListMenu.MenuItems[LISTMENU_RENAME_INDEX].Visible = true;
                        this.ListMenu.MenuItems[LISTMENU_RESTORE_INDEX].Visible = false;
                        this.ListMenu.MenuItems[LISTMENU_DELETE_INDEX].Visible = true;
                    }
                    else
                    {
                        this.ListMenu.MenuItems[LISTMENU_DOWNLOAD_INDEX].Visible = false;
                        this.ListMenu.MenuItems[LISTMENU_RENAME_INDEX].Visible = false;
                        this.ListMenu.MenuItems[LISTMENU_RESTORE_INDEX].Visible = true;
                        this.ListMenu.MenuItems[LISTMENU_DELETE_INDEX].Visible = true;
                    }

                    if (this.list.SelectedItems != null && this.list.SelectedItems.Count > 0 && this.list.Columns.Count > 1)
                    {
                        this.ListMenu.Show(this.list, e.Location);
                    }
                }
            }
        }

        private void treeFolders_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeViewHitTestInfo test = this.treeFolders.HitTest(e.Location);

                if (test.Node != null && this.treeFolders.Nodes != null && this.treeFolders.Nodes.Count > 0 && this.ListMenu.MenuItems != null &&
                    Util.User.CurrentArea.id != Util.User.DOC_RECENT_ID &&
                    Util.User.CurrentArea.id != Util.User.TRASH_ID)
                {
                    this.TreeMenu.MenuItems[TREEMENU_ADDFOLDER_INDEX].Visible = true;

                    bool value = true;

                    if(test.Node.Level == 0)
                    {
                        value = false;
                    }

                    this.TreeMenu.MenuItems[TREEMENU_ADDDOCUMENT_INDEX].Visible = value;
                    this.TreeMenu.MenuItems[TREEMENU_RENAMEFOLDER_INDEX].Visible = value;
                    this.TreeMenu.MenuItems[TREEMENU_REMOVEFOLDER_INDEX].Visible = value;

                    this.TreeMenu.Show(this.treeFolders, e.Location);
                }
            }
        }

        private void boxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;               
            }
        }

        private async void boxSearch_TextChanged(object sender, EventArgs e)
        {
            String search = this.boxSearch.Text.TrimStart().TrimEnd().ToLower();

            if (Service.IService != null)
            {                
                if(search.Length == 2)
                {
                    //traz todas ocorrencias de documentos
                    getListaBuscaResponse response = null;
                    try
                    {
                        response = await Service.IService.getListaBuscaAsync(new getListaBuscaRequest(search, Util.User.GetHashID()));
                    }
                    catch
                    {
                        response = null;
                    }
                    if (response != null)
                    {
                        Util.Document.Assembly(this.list, response.@return, DocumentAssemblyType.Search);
                        Util.Document.SearchDocuments = response.@return;                        
                    }
                }

                else if(search.Length > 2)
                {
                    //filtra os documentos ja consultados
                    if(Util.Document.SearchDocuments != null && Util.Document.SearchDocuments.Length > 0)
                    {
                        var filter = Util.Document.SearchDocuments.Where(doc =>
                            doc.format.ToLower().TrimStart().TrimEnd().Replace(".", "").Equals(search.Replace(".", "")) ||
                            doc.name.ToLower().TrimStart().TrimEnd().Contains(search) ||
                            doc.observacao.ToLower().TrimStart().TrimEnd().Contains(search));
                        if(filter != null)
                        {
                            Util.Document.Assembly(this.list, filter.ToArray(), Util.Document.LastAssemblyType, true);
                        }                      
                    }
                }

                else if(search.Length == 0)
                {
                    //remove as ocorrencias gravadas
                    Util.Document.SearchDocuments = null;      
                    
                    //mostra os documentos da pasta/area selecionada
                    Int32 areaId = Util.User.CurrentArea.id;

                    if (areaId == Util.User.DOC_RECENT_ID)
                    {
                        //get recent documents
                        getListaRecentesResponse recentDocsResponse = null;

                        try
                        {
                            recentDocsResponse = await Service.IService.getListaRecentesAsync(new getListaRecentesRequest(Util.User.GetHashID()));
                        }
                        catch
                        {
                            recentDocsResponse = null;
                        }

                        if (recentDocsResponse != null)
                        {
                            documento[] recentDocs = recentDocsResponse.@return;

                            Util.Document.Assembly(this.list, recentDocs, DocumentAssemblyType.Recent);
                        }
                    }

                    else if (areaId == Util.User.TRASH_ID)
                    {
                        getDocumentosLixeiraGeralResponse response = null;

                        try
                        {
                            response = await Service.IService.getDocumentosLixeiraGeralAsync(new getDocumentosLixeiraGeralRequest(Util.User.GetHashID()));
                        }
                        catch
                        {
                            response = null;
                        }

                        if (response != null)
                        {
                            documento[] docs = response.@return;

                            Util.Document.Assembly(this.list, docs, DocumentAssemblyType.Trash, true);
                        }
                    }
                    else
                    {
                        if (this.treeFolders.Nodes != null && this.treeFolders.SelectedNode != null)
                        {
                            //listagem de documentos

                            getListaDocumentosResponse docsResponse = null;

                            try
                            {
                                if (this.treeFolders.SelectedNode.Level == 0)
                                {
                                    area tag = (area)this.treeFolders.SelectedNode.Tag;

                                    if (tag.id != Util.User.DOC_RECENT_ID && tag.id != Util.User.TRASH_ID)
                                    {
                                        this.list.Items.Clear();
                                        this.list.Columns.Clear();
                                    }
                                }

                                else if (this.treeFolders.SelectedNode.Level == 1)
                                {
                                    group tag = (group)this.treeFolders.SelectedNode.Tag;

                                    if (tag != null && tag.id != 0 && tag.active)
                                    {
                                        docsResponse = await Service.IService.getListaDocumentosAsync(new getListaDocumentosRequest(tag.id, 0, Util.User.GetHashID()));
                                    }
                                }
                                else
                                {
                                    subGroup tag = (subGroup)this.treeFolders.SelectedNode.Tag;

                                    if (tag != null && tag.idGroup != 0 && tag.id != 0)
                                    {
                                        docsResponse = await Service.IService.getListaDocumentosAsync(new getListaDocumentosRequest(tag.idGroup, tag.id, Util.User.GetHashID()));
                                    }
                                }
                            }
                            catch
                            {
                                docsResponse = null;
                            }

                            if (docsResponse != null)
                            {
                                documento[] docs = docsResponse.@return;

                                Util.Document.Assembly(this.list, docs, DocumentAssemblyType.Tree, true);
                            }
                        }
                    }                    
                }
            }
        }

        private bool activated = false;

        private void MyAccount_Activated(object sender, EventArgs e)
        {
            if (!this.activated)
            {
                String file = Path.Combine(Folder.GetWatcherPath(), Folder.LOGIN_ACTION_FILE_NAME);
                File.Create(file).Close();
                this.activated = true;
            }
        }

        private void filterAll_Click(object sender, EventArgs e)
        {
            fixFilterMenu(sender);           
            Util.Document.Assembly(this.list, Util.Document.Documents, Util.Document.LastAssemblyType, true, false);            
        }
        
        private void fixFilterMenu(object sender)
        {
            foreach (object menuItem in this.filters.DropDownItems)
            {
                try
                {
                    //fixa o menu de filtros
                    var filter = (ToolStripMenuItem)menuItem;
                    if (filter != null) filter.Checked = false;
                }
                catch
                {
                    continue;
                }
            }
            ((ToolStripMenuItem)sender).Checked = true;
        }

        public static readonly String[] wextensions = { ".doc", ".docx", ".dot", ".dotx", ".docm", ".dotm", ".docb", ".pdf", ".rtf", ".txt", ".odt", "word" };
        public static readonly String[] eextensions = { ".xls", ".xlt", ".xlm", ".xlsx", ".xlsm", ".xltx", ".xltm", ".xlsb", ".xla", ".xlam", ".xlw", ".ods", "excel" };
        public static readonly String[] pextensions = { ".ppt", ".pot", ".pps", ".pptx", ".pptm", ".potx", ".potm", ".ppam", ".ppsx", ".ppsm", ".sldx", ".sldm", ".odp", "powerpoint" };
        public static readonly String[] iextensions = { ".jpg", ".jpeg", ".gif", ".png", ".bitmap", ".bmp", ".tiff", ".raw", ".svg", ".webp" };

        private void filterWord_Click(object sender, EventArgs e)
        {
            fixFilterMenu(sender);            
            if (Util.Document.Documents != null)
            {
                var filter = Util.Document.Documents.Where(doc => wextensions.Where(ext => doc.format.ToLower().Equals(ext)).Any());
                Util.Document.Assembly(this.list, filter.ToArray(), Util.Document.LastAssemblyType, true, false);
            }
        }

        private void filterExcel_Click(object sender, EventArgs e)
        {
            fixFilterMenu(sender);
            if (Util.Document.Documents != null)
            {                
                var filter = Util.Document.Documents.Where(doc => eextensions.Where(ext => doc.format.ToLower().Equals(ext)).Any());
                Util.Document.Assembly(this.list, filter.ToArray(), Util.Document.LastAssemblyType, true, false);
            }
        }

        private void filterpPoint_Click(object sender, EventArgs e)
        {
            fixFilterMenu(sender);
            if (Util.Document.Documents != null)
            {                
                var filter = Util.Document.Documents.Where(doc => pextensions.Where(ext => doc.format.ToLower().Equals(ext)).Any());
                Util.Document.Assembly(this.list, filter.ToArray(), Util.Document.LastAssemblyType, true, false);
            }
        }

        private void filterImages_Click(object sender, EventArgs e)
        {
            fixFilterMenu(sender);
            if (Util.Document.Documents != null)
            {                
                var filter = Util.Document.Documents.Where(doc => iextensions.Where(ext => doc.format.ToLower().Equals(ext)).Any());
                Util.Document.Assembly(this.list, filter.ToArray(), Util.Document.LastAssemblyType, true, false);
            }
        }

        private void list_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //MessageBox.Show(this.list.Columns[e.Column].Text);
        }     
    }
}
