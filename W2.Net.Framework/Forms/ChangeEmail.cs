using System;
using System.Windows.Forms;
using W2.Net.Framework.Tasks;
using W2.Net.Framework.W2Service;

namespace W2.Net.Framework.Forms
{
    public partial class ChangeEmail : Form
    {
        public ChangeEmail()
        {
            InitializeComponent();

            this.ShowDialog();
        }

        private async void buttonChange_Click(object sender, EventArgs e)
        {
            if(this.textboxEmail.Text != null && this.boxPassword.Text != null)
            {
                String email = this.textboxEmail.Text.TrimStart().TrimEnd();
                String pass = this.boxPassword.Text;

                if(!String.IsNullOrEmpty(email))
                {
                    bool valid = Util.RegularExpressions.ValidateEmail(email);

                    if(valid)
                    {
                        if(Addin.CurrentAccount.password.Equals(pass))
                        {                         
                            this.buttonChange.Enabled = false;

                            setEmailResponse response = null;
                            try
                            {
                                response = await Service.IService.setEmailAsync(new setEmailRequest(email, Util.User.GetHashID()));
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
                                    Addin.CurrentAccount.email = email;
                                }
                                else
                                {
                                    MessageBox.Show("Não foi possível alterar o email. Tente novamente mais tarde");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Não foi possível alterar o email. Verifique sua conexão com a internet");
                            }

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Senha incorreta");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Formato de email inválido");
                    }
                }
                else
                {
                    MessageBox.Show("Preencha o campo email");
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos");
            }

            this.buttonChange.Enabled = true;
        }   

        private void ChangeEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }        
    }
}
