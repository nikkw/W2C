namespace W2.Net.Framework.Forms
{
    partial class ChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePassword));
            this.label1 = new System.Windows.Forms.Label();
            this.boxActualPassword = new System.Windows.Forms.TextBox();
            this.buttonChange = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.boxNewPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.boxPasswordConfirmation = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Digite a senha atual:";
            // 
            // boxActualPassword
            // 
            this.boxActualPassword.Location = new System.Drawing.Point(17, 62);
            this.boxActualPassword.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.boxActualPassword.Name = "boxActualPassword";
            this.boxActualPassword.PasswordChar = '*';
            this.boxActualPassword.Size = new System.Drawing.Size(711, 38);
            this.boxActualPassword.TabIndex = 0;
            // 
            // buttonChange
            // 
            this.buttonChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChange.Location = new System.Drawing.Point(528, 328);
            this.buttonChange.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(200, 55);
            this.buttonChange.TabIndex = 3;
            this.buttonChange.Text = "Alterar";
            this.buttonChange.UseVisualStyleBackColor = true;
            this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(327, 39);
            this.label2.TabIndex = 5;
            this.label2.Text = "Digite a nova senha:";
            // 
            // boxNewPassword
            // 
            this.boxNewPassword.Location = new System.Drawing.Point(17, 162);
            this.boxNewPassword.Multiline = true;
            this.boxNewPassword.Name = "boxNewPassword";
            this.boxNewPassword.PasswordChar = '*';
            this.boxNewPassword.Size = new System.Drawing.Size(711, 38);
            this.boxNewPassword.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(393, 39);
            this.label3.TabIndex = 6;
            this.label3.Text = "Confimação nova senha:";
            // 
            // boxPasswordConfirmation
            // 
            this.boxPasswordConfirmation.Location = new System.Drawing.Point(17, 260);
            this.boxPasswordConfirmation.Multiline = true;
            this.boxPasswordConfirmation.Name = "boxPasswordConfirmation";
            this.boxPasswordConfirmation.PasswordChar = '*';
            this.boxPasswordConfirmation.Size = new System.Drawing.Size(711, 38);
            this.boxPasswordConfirmation.TabIndex = 2;
            // 
            // ChangePassword
            // 
            this.AcceptButton = this.buttonChange;
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(749, 408);
            this.Controls.Add(this.boxPasswordConfirmation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.boxNewPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonChange);
            this.Controls.Add(this.boxActualPassword);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.MaximizeBox = false;
            this.Name = "ChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alterar senha";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChangeEmail_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox boxActualPassword;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox boxNewPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox boxPasswordConfirmation;
    }
}