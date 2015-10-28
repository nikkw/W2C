namespace W2.Net.Framework.Forms
{
    partial class UserSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserSettings));
            this.label1 = new System.Windows.Forms.Label();
            this.boxEmail = new System.Windows.Forms.TextBox();
            this.buttonChangeEmail = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonChangePassword = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.boxDirDownload = new System.Windows.Forms.TextBox();
            this.buttonChangeDirDownload = new System.Windows.Forms.Button();
            this.checkOpenDocument = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Email";
            // 
            // boxEmail
            // 
            this.boxEmail.BackColor = System.Drawing.Color.White;
            this.boxEmail.Location = new System.Drawing.Point(17, 54);
            this.boxEmail.Name = "boxEmail";
            this.boxEmail.ReadOnly = true;
            this.boxEmail.Size = new System.Drawing.Size(984, 38);
            this.boxEmail.TabIndex = 1;
            // 
            // buttonChangeEmail
            // 
            this.buttonChangeEmail.Location = new System.Drawing.Point(1007, 50);
            this.buttonChangeEmail.Name = "buttonChangeEmail";
            this.buttonChangeEmail.Size = new System.Drawing.Size(138, 49);
            this.buttonChangeEmail.TabIndex = 2;
            this.buttonChangeEmail.Text = "Alterar";
            this.buttonChangeEmail.UseVisualStyleBackColor = true;
            this.buttonChangeEmail.Click += new System.EventHandler(this.buttonChangeEmail_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 39);
            this.label2.TabIndex = 3;
            this.label2.Text = "Senha";
            // 
            // buttonChangePassword
            // 
            this.buttonChangePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChangePassword.Location = new System.Drawing.Point(22, 165);
            this.buttonChangePassword.Name = "buttonChangePassword";
            this.buttonChangePassword.Size = new System.Drawing.Size(236, 53);
            this.buttonChangePassword.TabIndex = 4;
            this.buttonChangePassword.Text = "Alterar senha";
            this.buttonChangePassword.UseVisualStyleBackColor = true;
            this.buttonChangePassword.Click += new System.EventHandler(this.buttonChangePassword_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 236);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(504, 39);
            this.label3.TabIndex = 5;
            this.label3.Text = "Local de download dos arquivos";
            // 
            // boxDirDownload
            // 
            this.boxDirDownload.BackColor = System.Drawing.Color.White;
            this.boxDirDownload.Location = new System.Drawing.Point(17, 291);
            this.boxDirDownload.Multiline = true;
            this.boxDirDownload.Name = "boxDirDownload";
            this.boxDirDownload.ReadOnly = true;
            this.boxDirDownload.Size = new System.Drawing.Size(984, 38);
            this.boxDirDownload.TabIndex = 6;
            // 
            // buttonChangeDirDownload
            // 
            this.buttonChangeDirDownload.Location = new System.Drawing.Point(1007, 287);
            this.buttonChangeDirDownload.Name = "buttonChangeDirDownload";
            this.buttonChangeDirDownload.Size = new System.Drawing.Size(138, 49);
            this.buttonChangeDirDownload.TabIndex = 7;
            this.buttonChangeDirDownload.Text = "Alterar";
            this.buttonChangeDirDownload.UseVisualStyleBackColor = true;
            this.buttonChangeDirDownload.Click += new System.EventHandler(this.buttonChangeDirDownload_Click);
            // 
            // checkOpenDocument
            // 
            this.checkOpenDocument.AutoSize = true;
            this.checkOpenDocument.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkOpenDocument.Location = new System.Drawing.Point(17, 361);
            this.checkOpenDocument.Name = "checkOpenDocument";
            this.checkOpenDocument.Size = new System.Drawing.Size(1121, 43);
            this.checkOpenDocument.TabIndex = 8;
            this.checkOpenDocument.Text = "Abrir documentos, planílhas, apresentações e imagens após download";
            this.checkOpenDocument.UseVisualStyleBackColor = true;
            this.checkOpenDocument.CheckStateChanged += new System.EventHandler(this.checkOpenDocument_CheckStateChanged);
            // 
            // UserSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 435);
            this.Controls.Add(this.checkOpenDocument);
            this.Controls.Add(this.buttonChangeDirDownload);
            this.Controls.Add(this.boxDirDownload);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonChangePassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonChangeEmail);
            this.Controls.Add(this.boxEmail);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "UserSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurações";
            this.Load += new System.EventHandler(this.UserSettings_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserSettings_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox boxEmail;
        private System.Windows.Forms.Button buttonChangeEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonChangePassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox boxDirDownload;
        private System.Windows.Forms.Button buttonChangeDirDownload;
        private System.Windows.Forms.CheckBox checkOpenDocument;
    }
}