using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace W2.Net.Info
{
    public class Addin
    {
        private static Process BridgeProcess;

        public static void Init()
        {
            var processes = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(Folder.BRIDGE_NAME));

            //caso nao esteja em execucao
            if (processes == null || processes.Length == 0)
            {
                //Executa a ponte para o funcionamento correto da aplicacao
                String bridge = Folder.GetInstallerPath();
                bridge = Path.Combine(bridge, Folder.BRIDGE_NAME);

                if (File.Exists(bridge))
                {
                    ProcessStartInfo process = new ProcessStartInfo();
                    process.FileName = bridge;

                    try
                    {
                        BridgeProcess = Process.Start(process);
                    }
                    catch
                    {
                        MessageBox.Show("Não foi possível inicializar o addin.");
                        return;
                    }

                    if (BridgeProcess == null)
                    {
                        MessageBox.Show("Não foi possível inicializar o addin.");
                    }
                }
                else
                {
                    MessageBox.Show("Não foi possível inicializar o addin. Reinstale para corrigir o erro.");
                }
            }
        }
    }
}
