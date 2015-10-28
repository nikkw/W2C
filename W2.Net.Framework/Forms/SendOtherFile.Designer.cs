namespace W2.Net.Framework.Forms
{
    partial class SendOtherFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendOtherFile));
            this.buttonChoiceFile = new System.Windows.Forms.Button();
            this.boxObs = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonChoiceFile
            // 
            this.buttonChoiceFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChoiceFile.Location = new System.Drawing.Point(137, 33);
            this.buttonChoiceFile.Name = "buttonChoiceFile";
            this.buttonChoiceFile.Size = new System.Drawing.Size(404, 56);
            this.buttonChoiceFile.TabIndex = 0;
            this.buttonChoiceFile.Text = "Escolher arquivo";
            this.buttonChoiceFile.UseVisualStyleBackColor = true;
            this.buttonChoiceFile.Click += new System.EventHandler(this.buttonChoiceFile_Click);
            // 
            // boxObs
            // 
            this.boxObs.Location = new System.Drawing.Point(12, 121);
            this.boxObs.Name = "boxObs";
            this.boxObs.Size = new System.Drawing.Size(647, 38);
            this.boxObs.TabIndex = 1;
            // 
            // buttonSend
            // 
            this.buttonSend.Enabled = false;
            this.buttonSend.Location = new System.Drawing.Point(492, 175);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(167, 47);
            this.buttonSend.TabIndex = 2;
            this.buttonSend.Text = "Enviar";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // SendOtherFile
            // 
            this.AcceptButton = this.buttonSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 239);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.boxObs);
            this.Controls.Add(this.buttonChoiceFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "SendOtherFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enviar arquivo";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SendOtherFile_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonChoiceFile;
        private System.Windows.Forms.TextBox boxObs;
        private System.Windows.Forms.Button buttonSend;

    }
}