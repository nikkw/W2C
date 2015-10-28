using System;
using System.Linq;
using System.Windows.Forms;
using W2.Net.Framework.W2Service;
using System.Collections.Generic;

namespace W2.Net.Framework.Util
{
    public class Document
    {
        public static documento[] Documents;
        public static documento[] SearchDocuments;

        public static DocumentAssemblyType LastAssemblyType;

        public static String GetIdentifier(documento doc)
        {
            return doc.name;
        }

        public static void Assembly(ListView list, documento[] docs, DocumentAssemblyType type, bool clear = true, bool change=true)
        {            
            Framework.Forms.MyAccount myAccountForm = Application.OpenForms.OfType<Framework.Forms.MyAccount>().FirstOrDefault();
            if (myAccountForm != null)
            {                
                myAccountForm.Invoke((MethodInvoker)(() =>
                {
                    if (clear)
                    {
                        list.Items.Clear();
                    }

                    if (docs == null || docs.Length == 0)
                    {
                        CreateNoResultData(list);
                        return;
                    }

                    list.Columns.Clear();
                    list.Columns.Add("Nome", 400);
                    list.Columns.Add("Observação", 200);

                    if (type == DocumentAssemblyType.Trash)
                    {
                        list.Columns.Add("Data de exclusão", 127);
                    }
                    else
                    {
                        list.Columns.Add("Data de criação", 127);
                    }

                    list.Columns.Add("Tipo", 100)
                        .AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);

                    foreach (documento doc in docs)
                    {
                        if (!String.IsNullOrEmpty(doc.name))
                        {
                            ListViewItem item = new ListViewItem(doc.name);

                            item.SubItems.Add(doc.observacao.TrimStart().TrimEnd());

                            if (type == DocumentAssemblyType.Trash)
                            {
                                item.SubItems.Add(doc.delete);
                            }
                            else
                            {
                                item.SubItems.Add(doc.criacao);
                            }

                            item.SubItems.Add(doc.format.TrimStart().TrimEnd());

                            item.Tag = doc;
                            item.Name = doc.name;

                            list.Items.Add(item);
                        }
                    }

                    if (change)
                    {
                        Documents = docs;

                        foreach (object menuItem in myAccountForm.filters.DropDownItems)
                        {
                            try
                            {
                                var filter = (ToolStripMenuItem)menuItem;
                                if (filter != null) filter.Checked = false;
                            }
                            catch
                            {
                                continue;
                            }
                        }
                        ((ToolStripMenuItem)myAccountForm.filters.DropDownItems[0]).Checked = true;
                    }

                    LastAssemblyType = type;
                }));
            }            
        }

        public static void CreateNoResultData(ListView list)
        {
            list.Items.Clear();
            list.Columns.Clear();

            list.Columns.Add("Resultado", 200);
            list.Items.Add("Não há nada aqui");            
        }
    }
}
