using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

namespace Estancionamento
{    
    public class Backup
    {
        public bool backupBanco(string sEnderecoArquivo, string sPath, string sDiretorioBackup)
        {
            bool bResposta = false;
            try
            {
                Conexao cConexao = new Conexao();
                DadosConexao cDadosConexao = new DadosConexao();
                cDadosConexao = cConexao.buscarDadosConexao(sEnderecoArquivo, 0);
                if (cDadosConexao != null)
                {
                    
                    var filePath = (sPath);
                    var sc = new ServerConnection(cDadosConexao.sServidor, cDadosConexao.sUsuario, cDadosConexao.sSenha);
                    var server = new Server(sc);
                    if (server.Databases[cDadosConexao.sNomeBaseDados] != null)
                    {
                        //criando o diretorio do backup
                        if (!Directory.Exists(sDiretorioBackup))
                            Directory.CreateDirectory(sDiretorioBackup);

                        //criando o objeto backup
                        Microsoft.SqlServer.Management.Smo.Backup bak = new Microsoft.SqlServer.Management.Smo.Backup();
                        bak.Incremental = false;
                        bak.Action = BackupActionType.Database;
                        bak.BackupSetName = "estacionamento_Backup";

                        //definindo o banco a ser salvo
                        bak.Database = cDadosConexao.sNomeBaseDados;
                        bak.Checksum = true;

                        //adicionando o destino
                        bak.Devices.Add(new BackupDeviceItem(filePath, DeviceType.File));
                        //executando o backup
                        bak.SqlBackup(server);
                        bResposta = true;
                    }
                }
                else
                    System.Windows.Forms.MessageBox.Show("Nenhum dado encontrado!", "EstacionamentoFacil (Backup01)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            catch (Exception ex) {
                System.Windows.Forms.MessageBox.Show("Erro ao executar o backup!\n" + ex.Message, "EstacionamentoFacil (Backup02)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return bResposta;
        }
        
    }
}
