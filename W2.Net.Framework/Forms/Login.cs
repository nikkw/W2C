using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using W2.Net.Framework.Tasks;
using W2.Net.Framework.W2Service;
using W2.Net.Info;

namespace W2.Net.Framework.Forms
{
    public partial class Login : Form
    {
        private AutoCompleteStringCollection m_LoginData;
        private String Dir;
        private String Name;

        private AutoCompleteStringCollection LoginData
        {
            get
            {
                if (this.m_LoginData == null)
                {
                    m_LoginData = new AutoCompleteStringCollection();

                    String file = Path.Combine(Folder.GetInstallerPath(), Folder.LOGINDATA_SRC);
                    if (File.Exists(file))
                    {
                        var data = File.ReadAllLines(file);
                        if(data != null)
                        {
                            m_LoginData.AddRange(data);                               
                        }
                    }
                }
                return m_LoginData;
            }            
        }

        public Login()
        {
            InitializeComponent();
        }

        public Login(String dir, String name)
        {
            InitializeComponent();
            this.Dir = dir;
            this.Name = name;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Addin.InSession = false;
            this.buttonStart.Enabled = true;
            this.boxLogin.AutoCompleteCustomSource = this.LoginData;            
        }

        private async void buttonStart_Click(object sender, EventArgs e)
        {   
            if(String.IsNullOrEmpty(this.boxPassword.Text)) return;
            else if(this.Controls.OfType<TextBox>().Any(box => String.IsNullOrEmpty(box.Text.Trim())))
            {
                MessageBox.Show("Preencha todos os campos.");
                return;
            }

            this.buttonStart.Enabled = false;

            if (Service.IService != null)
            {
                String login = this.boxLogin.Text.ToLower().TrimStart().TrimEnd();
                String pass = Util.User.GetHashPassword(this.boxPassword.Text);

                getAccountResponse accResponse = null;

                try
                {
                    //faz a leitura da conta
                    accResponse = await Service.IService.getAccountAsync(new getAccountRequest(login, pass));
                }
                catch
                {
                    accResponse = null;
                }

                if(accResponse != null)
                {                    
                    accounts acc = accResponse.@return;

                    if (acc != null)
                    {
                        //login e senha corretos
                        
                        //gera o hash do ID
                        String usrHash = Util.User.GetHashID(acc.id);

                        if(!String.IsNullOrEmpty(usrHash))
                        {   //hash gerado corretamente

                            Addin.CurrentAccount = acc;
                            Addin.InSession = true;

                            Util.User.ReadAreas(usrHash);

                            //add data to autofill
                            String file = Path.Combine(Folder.GetInstallerPath(), Folder.LOGINDATA_SRC);
                            this.LoginData.Add(login);
                            var data = this.LoginData.Cast<String>().Distinct();
                            File.WriteAllLines(file, data);                            

                            Util.Forms.CloseAll();

                            if(String.IsNullOrEmpty(this.Dir))
                            {
                                Util.Forms.Show(typeof(Forms.MyAccount));
                            }
                            else
                            {
                                SendFile form = new SendFile(this.Dir, this.Name);
                                form.Show();
                            }

                        }                                                    
                        else
                        {
                            MessageBox.Show("Informações da conta incorretas. Contate o suporte.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Login ou senha incorretos.");
                    }
                }
                else
                {
                    MessageBox.Show("Não foi possível completar o login. Verifique sua conexão com a internet.");
                }
            }
            else
            {
                MessageBox.Show("Não foi possível completar o login. Verifique sua conexão com a internet.");
            }

            this.buttonStart.Enabled = true;
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }        
    }
}
