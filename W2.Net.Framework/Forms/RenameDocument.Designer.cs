namespace W2.Net.Framework.Forms
{
    partial class RenameDocument
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RenameDocument));
            this.label = new System.Windows.Forms.Label();
            this.boxName = new System.Windows.Forms.TextBox();
            this.buttonRename = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(17, 14);
            this.label.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(85, 38);
            this.label.TabIndex = 0;
            this.label.Text = "label";
            // 
            // boxName
            // 
            this.boxName.Location = new System.Drawing.Point(17, 62);
            this.boxName.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.boxName.Name = "boxName";
            this.boxName.Size = new System.Drawing.Size(711, 38);
            this.boxName.TabIndex = 1;
            // 
            // buttonRename
            // 
            this.buttonRename.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRename.Location = new System.Drawing.Point(528, 125);
            this.buttonRename.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonRename.Name = "buttonRename";
            this.buttonRename.Size = new System.Drawing.Size(200, 55);
            this.buttonRename.TabIndex = 4;
            this.buttonRename.Text = "Renomear";
            this.buttonRename.UseVisualStyleBackColor = true;
            this.buttonRename.Click += new System.EventHandler(this.buttonRename_Click);
            // 
            // RenameDocument
            // 
            this.AcceptButton = this.buttonRename;
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(749, 206);
            this.Controls.Add(this.buttonRename);
            this.Controls.Add(this.boxName);
            this.Controls.Add(this.label);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.MaximizeBox = false;
            this.Name = "RenameDocument";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Renomear documento";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChangeEmail_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox boxName;
        private System.Windows.Forms.Button buttonRename;
    }
}