﻿namespace W2.Net.Visio
{
    partial class Ribbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.buttonLogin = this.Factory.CreateRibbonButton();
            this.buttonSaveDoc = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "O2W";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.buttonLogin);
            this.group1.Items.Add(this.buttonSaveDoc);
            this.group1.Label = "O2W";
            this.group1.Name = "group1";
            // 
            // buttonLogin
            // 
            this.buttonLogin.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.buttonLogin.Image = global::W2.Net.Visio.Properties.Resources.account;
            this.buttonLogin.Label = "Login";
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.ShowImage = true;
            this.buttonLogin.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.buttonLogin_Click);
            // 
            // buttonSaveDoc
            // 
            this.buttonSaveDoc.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.buttonSaveDoc.Image = global::W2.Net.Visio.Properties.Resources.document_upload;
            this.buttonSaveDoc.Label = "Salvar diagrama";
            this.buttonSaveDoc.Name = "buttonSaveDoc";
            this.buttonSaveDoc.ShowImage = true;
            this.buttonSaveDoc.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.buttonSaveDoc_Click);
            // 
            // Ribbon
            // 
            this.Name = "Ribbon";
            this.RibbonType = "Microsoft.Visio.Drawing";
            this.Tabs.Add(this.tab1);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonLogin;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonSaveDoc;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon Ribbon
        {
            get { return this.GetRibbon<Ribbon>(); }
        }
    }
}
