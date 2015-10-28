using abcDoc34Com;
using W2.Net.Framework.W2Service;

namespace W2.Net.Framework.Tasks.AbcDoc
{
    public partial class Cloud
    {
        private static bancoAbcDoc m_AbcDocInfo;

        private static bancoAbcDoc AbcDocInfo
        {
            get
            {
                try
                {
                    if (m_AbcDocInfo == null)
                    {
                        m_AbcDocInfo = new bancoAbcDoc();
                        
                        lock(m_AbcDocInfo)
                        {
                            m_AbcDocInfo = Tasks.Service.IService.getAbcDoc(new getAbcDocRequest()).@return;
                        }
                    }
                }
                catch
                {
                    m_AbcDocInfo = null;
                }

                return m_AbcDocInfo;                
            }
        }

        private static abcDoc34Acesso m_abcdoc;

        public static abcDoc34Acesso AbcDoc
        {
            get
            {
                try
                {
                    if (m_abcdoc == null)
                    {
                        m_abcdoc = new abcDoc34Acesso();

                        lock (m_abcdoc)
                        {
                            m_abcdoc.iniciarConexao(AbcDocInfo.ip, AbcDocInfo.port);

                            m_abcdoc.autenticarUsuario(AbcDocInfo.userr, AbcDocInfo.password);
                        }
                    }
                }
                catch
                {
                    m_abcdoc = null;
                }

                return m_abcdoc;
            }
            set
            {
                m_abcdoc = value;
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (AbcDoc != null)
                {
                    lock (AbcDoc)
                    {
                        AbcDoc.encerrarConexao();

                        AbcDoc = null;
                    }
                }
            }
            catch
            {
            }
        }

        ~Cloud()
        {
            CloseConnection();
        }
    }
}
