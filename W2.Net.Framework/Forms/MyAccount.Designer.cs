namespace W2.Net.Framework.Forms
{
    partial class MyAccount
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyAccount));
            this.menuActions = new System.Windows.Forms.ToolStrip();
            this.buttonSendDocument = new System.Windows.Forms.ToolStripButton();
            this.separatorFolder = new System.Windows.Forms.ToolStripSeparator();
            this.buttonAddFolder = new System.Windows.Forms.ToolStripButton();
            this.separatorFolder1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonRenameFolder = new System.Windows.Forms.ToolStripButton();
            this.separatorFolder2 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonRemoveFolder = new System.Windows.Forms.ToolStripButton();
            this.buttonDeleteDocument = new System.Windows.Forms.ToolStripButton();
            this.documentSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.buttonRestoreDocument = new System.Windows.Forms.ToolStripButton();
            this.documentSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonRenameDocument = new System.Windows.Forms.ToolStripButton();
            this.documentSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonDownloadDocument = new System.Windows.Forms.ToolStripButton();
            this.menuArea = new System.Windows.Forms.ToolStripDropDownButton();
            this.buttonAccount = new System.Windows.Forms.ToolStripDropDownButton();
            this.buttonSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonLoggout = new System.Windows.Forms.ToolStripMenuItem();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeFolders = new System.Windows.Forms.TreeView();
            this.list = new System.Windows.Forms.ListView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.filters = new System.Windows.Forms.ToolStripDropDownButton();
            this.filterAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.filterWord = new System.Windows.Forms.ToolStripMenuItem();
            this.filterExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.filterpPoint = new System.Windows.Forms.ToolStripMenuItem();
            this.filterImages = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.boxSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.menuActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuActions
            // 
            this.menuActions.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuActions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonSendDocument,
            this.separatorFolder,
            this.buttonAddFolder,
            this.separatorFolder1,
            this.buttonRenameFolder,
            this.separatorFolder2,
            this.buttonRemoveFolder,
            this.buttonDeleteDocument,
            this.documentSeparator,
            this.buttonRestoreDocument,
            this.documentSeparator1,
            this.buttonRenameDocument,
            this.documentSeparator2,
            this.buttonDownloadDocument});
            this.menuActions.Location = new System.Drawing.Point(0, 53);
            this.menuActions.Name = "menuActions";
            this.menuActions.Padding = new System.Windows.Forms.Padding(0);
            this.menuActions.Size = new System.Drawing.Size(1820, 48);
            this.menuActions.TabIndex = 0;
            this.menuActions.Text = "toolStrip2";
            // 
            // buttonSendDocument
            // 
            this.buttonSendDocument.Image = global::W2.Net.Framework.Properties.Resources.document_upload;
            this.buttonSendDocument.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSendDocument.Name = "buttonSendDocument";
            this.buttonSendDocument.Size = new System.Drawing.Size(223, 45);
            this.buttonSendDocument.Text = "Enviar arquivo";
            this.buttonSendDocument.Visible = false;
            this.buttonSendDocument.Click += new System.EventHandler(this.buttonSendDocument_Click);
            // 
            // separatorFolder
            // 
            this.separatorFolder.Name = "separatorFolder";
            this.separatorFolder.Size = new System.Drawing.Size(6, 48);
            this.separatorFolder.Visible = false;
            // 
            // buttonAddFolder
            // 
            this.buttonAddFolder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddFolder.Image = global::W2.Net.Framework.Properties.Resources.folder_add;
            this.buttonAddFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAddFolder.Name = "buttonAddFolder";
            this.buttonAddFolder.Size = new System.Drawing.Size(242, 45);
            this.buttonAddFolder.Text = "Adicionar pasta";
            this.buttonAddFolder.Visible = false;
            this.buttonAddFolder.Click += new System.EventHandler(this.buttonAddFolder_Click);
            // 
            // separatorFolder1
            // 
            this.separatorFolder1.Name = "separatorFolder1";
            this.separatorFolder1.Size = new System.Drawing.Size(6, 48);
            this.separatorFolder1.Visible = false;
            // 
            // buttonRenameFolder
            // 
            this.buttonRenameFolder.Image = global::W2.Net.Framework.Properties.Resources.folder_rename;
            this.buttonRenameFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonRenameFolder.Name = "buttonRenameFolder";
            this.buttonRenameFolder.Size = new System.Drawing.Size(253, 45);
            this.buttonRenameFolder.Text = "Renomear pasta";
            this.buttonRenameFolder.Visible = false;
            this.buttonRenameFolder.Click += new System.EventHandler(this.buttonRenameFolder_Click);
            // 
            // separatorFolder2
            // 
            this.separatorFolder2.Name = "separatorFolder2";
            this.separatorFolder2.Size = new System.Drawing.Size(6, 48);
            this.separatorFolder2.Visible = false;
            // 
            // buttonRemoveFolder
            // 
            this.buttonRemoveFolder.Image = global::W2.Net.Framework.Properties.Resources.folder_delete;
            this.buttonRemoveFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonRemoveFolder.Name = "buttonRemoveFolder";
            this.buttonRemoveFolder.Size = new System.Drawing.Size(235, 45);
            this.buttonRemoveFolder.Text = "Remover pasta";
            this.buttonRemoveFolder.Visible = false;
            this.buttonRemoveFolder.Click += new System.EventHandler(this.buttonRemoveFolder_Click);
            // 
            // buttonDeleteDocument
            // 
            this.buttonDeleteDocument.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.buttonDeleteDocument.Image = global::W2.Net.Framework.Properties.Resources.document_delete;
            this.buttonDeleteDocument.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonDeleteDocument.Name = "buttonDeleteDocument";
            this.buttonDeleteDocument.Size = new System.Drawing.Size(122, 45);
            this.buttonDeleteDocument.Text = "Excluir";
            this.buttonDeleteDocument.Visible = false;
            this.buttonDeleteDocument.Click += new System.EventHandler(this.buttonDeleteDocument_Click);
            // 
            // documentSeparator
            // 
            this.documentSeparator.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.documentSeparator.Name = "documentSeparator";
            this.documentSeparator.Size = new System.Drawing.Size(6, 48);
            this.documentSeparator.Visible = false;
            // 
            // buttonRestoreDocument
            // 
            this.buttonRestoreDocument.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.buttonRestoreDocument.Image = global::W2.Net.Framework.Properties.Resources.document_restore;
            this.buttonRestoreDocument.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonRestoreDocument.Name = "buttonRestoreDocument";
            this.buttonRestoreDocument.Size = new System.Drawing.Size(162, 45);
            this.buttonRestoreDocument.Text = "Restaurar";
            this.buttonRestoreDocument.Visible = false;
            this.buttonRestoreDocument.Click += new System.EventHandler(this.buttonRestoreDocument_Click);
            // 
            // documentSeparator1
            // 
            this.documentSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.documentSeparator1.Name = "documentSeparator1";
            this.documentSeparator1.Size = new System.Drawing.Size(6, 48);
            this.documentSeparator1.Visible = false;
            // 
            // buttonRenameDocument
            // 
            this.buttonRenameDocument.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.buttonRenameDocument.Image = global::W2.Net.Framework.Properties.Resources.document_rename;
            this.buttonRenameDocument.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonRenameDocument.Name = "buttonRenameDocument";
            this.buttonRenameDocument.Size = new System.Drawing.Size(174, 45);
            this.buttonRenameDocument.Text = "Renomear";
            this.buttonRenameDocument.Visible = false;
            this.buttonRenameDocument.Click += new System.EventHandler(this.buttonRenameDocument_Click);
            // 
            // documentSeparator2
            // 
            this.documentSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.documentSeparator2.Name = "documentSeparator2";
            this.documentSeparator2.Size = new System.Drawing.Size(6, 48);
            this.documentSeparator2.Visible = false;
            // 
            // buttonDownloadDocument
            // 
            this.buttonDownloadDocument.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.buttonDownloadDocument.Image = global::W2.Net.Framework.Properties.Resources.document_download;
            this.buttonDownloadDocument.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonDownloadDocument.Name = "buttonDownloadDocument";
            this.buttonDownloadDocument.Size = new System.Drawing.Size(174, 45);
            this.buttonDownloadDocument.Text = "Download";
            this.buttonDownloadDocument.Visible = false;
            this.buttonDownloadDocument.Click += new System.EventHandler(this.buttonDownloadDocument_Click);
            // 
            // menuArea
            // 
            this.menuArea.Image = global::W2.Net.Framework.Properties.Resources.areas;
            this.menuArea.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuArea.Name = "menuArea";
            this.menuArea.Size = new System.Drawing.Size(244, 50);
            this.menuArea.Text = "Minhas áreas";
            // 
            // buttonAccount
            // 
            this.buttonAccount.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.buttonAccount.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonSettings,
            this.buttonLoggout});
            this.buttonAccount.Image = global::W2.Net.Framework.Properties.Resources.account;
            this.buttonAccount.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAccount.Name = "buttonAccount";
            this.buttonAccount.Size = new System.Drawing.Size(138, 50);
            this.buttonAccount.Text = "Conta";
            // 
            // buttonSettings
            // 
            this.buttonSettings.Image = global::W2.Net.Framework.Properties.Resources.settings;
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(315, 50);
            this.buttonSettings.Text = "Configurações";
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // buttonLoggout
            // 
            this.buttonLoggout.Image = global::W2.Net.Framework.Properties.Resources.loggout;
            this.buttonLoggout.Name = "buttonLoggout";
            this.buttonLoggout.Size = new System.Drawing.Size(315, 50);
            this.buttonLoggout.Text = "Sair";
            this.buttonLoggout.Click += new System.EventHandler(this.buttonLoggout_Click);
            // 
            // splitter1
            // 
            this.splitter1.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Enabled = false;
            this.splitter1.Location = new System.Drawing.Point(1804, 101);
            this.splitter1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(16, 1041);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Enabled = false;
            this.splitter2.Location = new System.Drawing.Point(0, 101);
            this.splitter2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(1804, 14);
            this.splitter2.TabIndex = 3;
            this.splitter2.TabStop = false;
            // 
            // splitter3
            // 
            this.splitter3.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter3.Enabled = false;
            this.splitter3.Location = new System.Drawing.Point(0, 1128);
            this.splitter3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(1804, 14);
            this.splitter3.TabIndex = 4;
            this.splitter3.TabStop = false;
            // 
            // splitter4
            // 
            this.splitter4.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitter4.Enabled = false;
            this.splitter4.Location = new System.Drawing.Point(0, 115);
            this.splitter4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(16, 1013);
            this.splitter4.TabIndex = 5;
            this.splitter4.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(16, 115);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeFolders);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.list);
            this.splitContainer1.Size = new System.Drawing.Size(1788, 1013);
            this.splitContainer1.SplitterDistance = 308;
            this.splitContainer1.SplitterWidth = 20;
            this.splitContainer1.TabIndex = 6;
            // 
            // treeFolders
            // 
            this.treeFolders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.treeFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeFolders.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeFolders.HideSelection = false;
            this.treeFolders.HotTracking = true;
            this.treeFolders.Location = new System.Drawing.Point(0, 0);
            this.treeFolders.Name = "treeFolders";
            this.treeFolders.ShowNodeToolTips = true;
            this.treeFolders.Size = new System.Drawing.Size(308, 1013);
            this.treeFolders.TabIndex = 0;
            this.treeFolders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeFolders_AfterSelect);
            this.treeFolders.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeFolders_MouseClick);
            // 
            // list
            // 
            this.list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list.FullRowSelect = true;
            this.list.GridLines = true;
            this.list.HideSelection = false;
            this.list.LabelWrap = false;
            this.list.Location = new System.Drawing.Point(0, 0);
            this.list.MultiSelect = false;
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(1460, 1013);
            this.list.TabIndex = 0;
            this.list.UseCompatibleStateImageBehavior = false;
            this.list.View = System.Windows.Forms.View.Details;
            this.list.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.list_ColumnClick);
            this.list.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.list_ItemSelectionChanged);
            this.list.KeyDown += new System.Windows.Forms.KeyEventHandler(this.list_KeyDown);
            this.list.Leave += new System.EventHandler(this.list_Leave);
            this.list.MouseClick += new System.Windows.Forms.MouseEventHandler(this.list_MouseClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuArea,
            this.buttonAccount,
            this.toolStripSeparator1,
            this.filters,
            this.toolStripSeparator2,
            this.boxSearch,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(1820, 53);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 53);
            // 
            // filters
            // 
            this.filters.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterAll,
            this.toolStripSeparator4,
            this.filterWord,
            this.filterExcel,
            this.filterpPoint,
            this.filterImages});
            this.filters.Image = global::W2.Net.Framework.Properties.Resources.filter;
            this.filters.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.filters.Name = "filters";
            this.filters.Size = new System.Drawing.Size(140, 50);
            this.filters.Text = "Filtros";
            // 
            // filterAll
            // 
            this.filterAll.Name = "filterAll";
            this.filterAll.Size = new System.Drawing.Size(327, 50);
            this.filterAll.Text = "Todos arquivos";
            this.filterAll.Click += new System.EventHandler(this.filterAll_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(324, 6);
            // 
            // filterWord
            // 
            this.filterWord.Name = "filterWord";
            this.filterWord.Size = new System.Drawing.Size(327, 50);
            this.filterWord.Text = "Documentos";
            this.filterWord.Click += new System.EventHandler(this.filterWord_Click);
            // 
            // filterExcel
            // 
            this.filterExcel.Name = "filterExcel";
            this.filterExcel.Size = new System.Drawing.Size(327, 50);
            this.filterExcel.Text = "Planilhas";
            this.filterExcel.Click += new System.EventHandler(this.filterExcel_Click);
            // 
            // filterpPoint
            // 
            this.filterpPoint.Name = "filterpPoint";
            this.filterpPoint.Size = new System.Drawing.Size(327, 50);
            this.filterpPoint.Text = "Apresentações";
            this.filterpPoint.Click += new System.EventHandler(this.filterpPoint_Click);
            // 
            // filterImages
            // 
            this.filterImages.Name = "filterImages";
            this.filterImages.Size = new System.Drawing.Size(327, 50);
            this.filterImages.Text = "Imagens";
            this.filterImages.Click += new System.EventHandler(this.filterImages_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 53);
            // 
            // boxSearch
            // 
            this.boxSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxSearch.Font = new System.Drawing.Font("Segoe UI", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxSearch.Name = "boxSearch";
            this.boxSearch.Size = new System.Drawing.Size(380, 53);
            this.boxSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxSearch_KeyPress);
            this.boxSearch.TextChanged += new System.EventHandler(this.boxSearch_TextChanged);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::W2.Net.Framework.Properties.Resources.search;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 50);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // MyAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1820, 1142);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.splitter4);
            this.Controls.Add(this.splitter3);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.menuActions);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.Name = "MyAccount";
            this.Activated += new System.EventHandler(this.MyAccount_Activated);
            this.Load += new System.EventHandler(this.MyAccount_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MyAccount_KeyDown);
            this.menuActions.ResumeLayout(false);
            this.menuActions.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip menuActions;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Splitter splitter4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton menuArea;
        private System.Windows.Forms.ToolStripDropDownButton buttonAccount;
        private System.Windows.Forms.ToolStripMenuItem buttonSettings;
        private System.Windows.Forms.ToolStripButton buttonAddFolder;
        private System.Windows.Forms.ToolStripSeparator separatorFolder1;
        private System.Windows.Forms.ToolStripButton buttonRenameFolder;
        private System.Windows.Forms.ToolStripSeparator separatorFolder2;
        private System.Windows.Forms.ToolStripButton buttonRemoveFolder;
        private System.Windows.Forms.ToolStripButton buttonDeleteDocument;
        private System.Windows.Forms.ToolStripSeparator documentSeparator;
        private System.Windows.Forms.ToolStripButton buttonRenameDocument;
        private System.Windows.Forms.ToolStripSeparator documentSeparator2;
        private System.Windows.Forms.ToolStripButton buttonRestoreDocument;
        private System.Windows.Forms.ToolStripSeparator documentSeparator1;
        private System.Windows.Forms.ToolStripMenuItem buttonLoggout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox boxSearch;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton buttonSendDocument;
        private System.Windows.Forms.ToolStripSeparator separatorFolder;
        internal System.Windows.Forms.ToolStripButton buttonDownloadDocument;
        internal System.Windows.Forms.ListView list;
        internal System.Windows.Forms.TreeView treeFolders;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem filterAll;
        private System.Windows.Forms.ToolStripMenuItem filterWord;
        private System.Windows.Forms.ToolStripMenuItem filterExcel;
        private System.Windows.Forms.ToolStripMenuItem filterpPoint;
        private System.Windows.Forms.ToolStripMenuItem filterImages;
        public System.Windows.Forms.ToolStripDropDownButton filters;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}