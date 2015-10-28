using System;
using System.Linq;
using System.Windows.Forms;

namespace W2.Net.Framework.Util
{
    public class Forms
    {
        public static void CloseAll()
        {
            Application.OpenForms
                .Cast<Form>()
                .Where(form => !form.Name.ToLower().Equals("mainform"))
                .ToList()
                .ForEach(form => form.Invoke((MethodInvoker)(() => form.Close())));
        }

        public static void Show(Type frmType)
        {
            bool found = false;            

            foreach (Form frm in Application.OpenForms)
            {
                Type type = frm.GetType();

                if (type.Equals(frmType))
                {
                    if (frm.WindowState != FormWindowState.Minimized)
                    {
                        frm.WindowState = FormWindowState.Minimized;
                        frm.WindowState = FormWindowState.Normal;

                    }
                    else
                    {
                        frm.WindowState = FormWindowState.Normal;
                    }

                    //frm.TopMost = true;
                    frm.BringToFront();
                    frm.Show();
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Form form = (Form)Activator.CreateInstance(frmType);
                form.Show();                
            }        
        }
    }
}
