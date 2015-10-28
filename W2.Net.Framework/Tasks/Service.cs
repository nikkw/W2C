using W2.Net.Framework.W2Service;

namespace W2.Net.Framework.Tasks
{
    public class Service
    {
        private static W2WebServiceImpl m_IService;

        public static W2WebServiceImpl IService        
        {
            get
            {
                if(m_IService == null)
                {
                    try
                    {
                        m_IService = new W2WebServiceImplClient();
                    }
                    catch
                    {
                        m_IService = null;
                    }                    
                }

                return m_IService;
            }
        } 
    }
}
