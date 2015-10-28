using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using W2.Net.Framework.W2Service;

namespace W2.Net.Framework.Tasks.AbcDoc
{
    public partial class Cloud
    {
        public void UploadFile(String dir, documento doc, Form form)
        {             
            Thread t = new Thread(() => {    
                if(File.Exists(dir))
                {
                    if(doc != null)
                    {
                        if(AbcDoc != null)
                        {                    
                            if(String.IsNullOrEmpty(doc.name))
                            {
                                doc.name = "Sem nome";
                            }

                            if(AbcDocInfo != null)
                            {
                                String docIdentifier = Util.Document.GetIdentifier(doc);
                                doc.identifier = docIdentifier;
                                String hash = string.Empty;

                                try
                                {
                                    //envia o arquivo pro abcdoc
                                    hash = AbcDoc.enviarArquivo(dir, AbcDocInfo.application, doc.identifier, doc.pages);
                                }
                                catch
                                {
                                    hash = string.Empty;
                                }

                                if(!String.IsNullOrEmpty(hash))
                                {
                                    doc.hash = hash;

                                    if (Tasks.Service.IService != null)
                                    {
                                        newDocumentoResponse response = null;

                                        try
                                        {
                                            //guarda os dados do arquivo no banco de dados
                                            response = Tasks.Service.IService.newDocumento(new newDocumentoRequest(doc, Util.User.GetHashID()));
                                        }                                    
                                        catch
                                        {
                                            response = null;
                                        }

                                        if (response != null)
                                        {
                                            documento docReturned = response.@return;

                                            if (docReturned == null)
                                            {
                                                MessageBox.Show("Não foi possível completar o upload[#7].");
                                            }
                                            else
                                            {
                                                try
                                                {
                                                    form.Invoke((MethodInvoker)(() => form.Close()));
                                                }
                                                catch
                                                { }

                                                //Atualiza a lista de documentos
                                                Forms.MyAccount myAccountForm = Application.OpenForms.OfType<Forms.MyAccount>().FirstOrDefault();
                                                if (myAccountForm != null)
                                                {
                                                    myAccountForm.Invoke((MethodInvoker)(() =>
                                                    {
                                                        if (myAccountForm.treeFolders.SelectedNode != null && myAccountForm.treeFolders.SelectedNode.Level > 0)
                                                        {
                                                            bool add = false;                                                            

                                                            if (myAccountForm.treeFolders.SelectedNode.Level == 1)
                                                            {
                                                                group tag = (group)myAccountForm.treeFolders.SelectedNode.Tag;

                                                                if (tag != null)
                                                                {
                                                                    if (docReturned.grupoid == tag.id && docReturned.subid == 0)
                                                                    {
                                                                        add = true;
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                subGroup tag = (subGroup)myAccountForm.treeFolders.SelectedNode.Tag;

                                                                if (tag != null)
                                                                {
                                                                    if (docReturned.grupoid == tag.idGroup && docReturned.subid == tag.id)
                                                                    {
                                                                        add = true;
                                                                    }
                                                                }
                                                            }

                                                            if (add)
                                                            {
                                                                if (myAccountForm.list.Columns.Count > 1)
                                                                {
                                                                    if (!String.IsNullOrEmpty(docReturned.name))
                                                                    {
                                                                        ListViewItem item = new ListViewItem(docReturned.name);
                                                                        item.SubItems.Add(docReturned.observacao.TrimStart().TrimEnd());
                                                                        item.SubItems.Add(docReturned.criacao);
                                                                        item.SubItems.Add(docReturned.format.TrimStart().TrimEnd());
                                                                        item.Tag = docReturned;
                                                                        item.Name = docReturned.name;
                                                                        myAccountForm.list.Items.Add(item);
                                                                    }                                                                    
                                                                }
                                                                else
                                                                {
                                                                    documento[] docs = { docReturned };
                                                                    Util.Document.Assembly(myAccountForm.list, docs, DocumentAssemblyType.Tree, true);
                                                                }
                                                            }
                                                        }
                                                    }));
                                                }
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Não foi possível completar o upload[#8].");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Não foi possível completar o upload[#1]. Verifique sua conexão com a internet.");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Não foi possível completar o upload[#2]. Verifique sua conexão com a internet.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Não foi possível completar o upload[#3]. Verifique sua conexão com a internet.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível completar o upload[#4]. Verifique sua conexão com a internet.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível completar o upload[#5]. O documento selecionado é inválido.");
                    }
                }
                else
                {
                    MessageBox.Show("Não foi possível completar o upload[#6]. Arquivo selecionado não existente.");
                }
            });

            t.Start();                          
        }            
    }
}
