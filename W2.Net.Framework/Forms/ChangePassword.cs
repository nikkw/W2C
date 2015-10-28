using System;
using System.Windows.Forms;
using W2.Net.Framework.Tasks;
using W2.Net.Framework.W2Service;

namespace W2.Net.Framework.Forms
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();

            this.ShowDialog();
        }

        private async void buttonChange_Click(object sender, EventArgs e)
        {
            if(this.boxActualPassword.Text != null && this.boxNewPassword.Text != null && this.boxPasswordConfirmation.Text != null && !String.IsNullOrEmpty(this.boxActualPassword.Text) && !String.IsNullOrEmpty(this.boxNewPassword.Text) && !String.IsNullOrEmpty(this.boxPasswordConfirmation.Text))
            {
                if(this.boxActualPassword.Text.Equals(Addin.CurrentAccount.password))
                {
                    if(this.boxNewPassword.Text.Equals(this.boxPasswordConfirmation.Text))
                    {
                        if(this.boxNewPassword.Text.Length > 4)
                        {
                            this.buttonChange.Enabled = false;
                            this.boxNewPassword.Enabled = false;
                            this.boxActualPassword.Enabled = false;
                            this.boxPasswordConfirmation.Enabled = false;

                            String pass = this.boxNewPassword.Text;

                            setPasswordResponse response = null;
                            try
                            {
                                response = await Service.IService.setPasswordAsync(new setPasswordRequest(pass, Util.User.GetHashID()));
                            }
                            catch
                            {
                                response = null;
                            }

                            if (response != null)
                            {
                                Int32 sucess = response.@return;

                                if (sucess != 0)
                                {
                                    Addin.CurrentAccount.password = pass;
                                }
                                else
                                {
                                    MessageBox.Show("Não foi possível alterar a senha. Tente novamente mais tarde");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Não foi possível alterar a senha. Tente novamente mais tarde");
                            }

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("A senha deve conter mais do que 4 caracteres");
                        }
                    }
                    else
                    {
                        MessageBox.Show("As senhas estão diferentes");
                    }
                }
                else
                {
                    MessageBox.Show("Senha atual incorreta");
                }
            }

            this.buttonChange.Enabled = true;
            this.boxNewPassword.Enabled = true;
            this.boxActualPassword.Enabled = true;
            this.boxPasswordConfirmation.Enabled = true;
        }   

        private void ChangeEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }        
    }
}
