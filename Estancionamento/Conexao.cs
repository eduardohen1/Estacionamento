using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace Estancionamento
{
    public class DadosConexao
    {
        public string sServidor {get; set;}
        public int iPorta {get; set;}
        public string sUsuario {get; set;}
        public string sSenha {get; set;}
        public string sNomeBaseDados {get; set;}
        public string sChaveAcesso {get; set;}
        public int iTipoRelatorio { get; set; }
    }

    class Conexao
    {
        public SqlConnection conexaoPrincipal = new SqlConnection();
        public string vvServidor = "";        
        public int vvPorta = 0;
        public string vvUser = "";
        public string vvPass = "";        
        public string vvDataBase = "";
        public string vvChaveAcesso = "";
        public int vvTipoRelatorio = 0;

        /// <summary>
        /// Função para conexão com o servidor de dados
        /// </summary>
        /// <param name="sServidor">Endereço do servidor de dados</param>
        /// <param name="sDataBase">Nome da base de dados</param>
        /// <param name="sUsuario">Usuário de acesso</param>
        /// <param name="sSenha">Senha de acesso</param>
        /// <returns></returns>
        public bool Conectar(string sServidor, String sDataBase, string sUsuario, string sSenha, int iPorta)
        {
            bool bResposta = true;
            try
            {
                if (conexaoPrincipal.State == ConnectionState.Open) 
                    Desconectar();
                //string sSQL = "Server=" + sServidor + ";Database=" + sDataBase + ";UID=" + sUsuario + ";PWD=" + sSenha;
                string sSQL = "User ID=" + sUsuario + "; Password=" + sSenha + "; Initial Catalog=" + sDataBase + "; Data Source=" + sServidor + "," + iPorta;
                conexaoPrincipal.ConnectionString = sSQL;
                conexaoPrincipal.Open();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao conectar no banco de dados!\n"  + ex.Message, "EstacionamentoFacil (BD01)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                bResposta = false;
            }
            return bResposta;
        }
        /// <summary>
        /// Função para desconectar do banco de dados
        /// </summary>
        public void Desconectar()
        {
            conexaoPrincipal.Close();
        }

        /// <summary>
        /// Função para abastecer dados para conexão com o banco de dados via arquivo de
        /// configuração xml.
        /// </summary>
        /// <param name="sArquivoConexao">Endereço do arquivo de configuração no micro</param>
        /// <returns>Verdadeiro/Falso</returns>
        public bool buscarDadosConexao(string sArquivoConexao) {
            bool bResposta = true;

            try
            {
                Funcoes cFuncoes = new Funcoes();
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(sArquivoConexao);
                XmlNodeList xnList = xmlDoc.GetElementsByTagName("Parametros");
                foreach (XmlNode xn in xnList)
                {
                    vvServidor = xn["Servidor"].InnerText;
                    vvPorta = int.Parse(xn["Porta"].InnerText);
                    vvUser = xn["User"].InnerText;
                    vvPass = cFuncoes.Descriptografar(xn["Pass"].InnerText);
                    //vvPass = xn["Pass"].InnerText;
                    vvDataBase = xn["DataBase"].InnerText;
                    //vvChaveAcesso = xn["ChaveAcesso"].InnerText;
                    vvChaveAcesso = cFuncoes.Descriptografar(xn["ChaveAcesso"].InnerText);
                    string ssTipoRelatorio = "0";// xn["TipoRelatorio"].InnerText;
                    if (ssTipoRelatorio.Trim().Length > 0)
                        vvTipoRelatorio = int.Parse(ssTipoRelatorio);
                    else
                        vvTipoRelatorio = 0;
                }
                if (vvServidor.Length == 0) bResposta = false;
                xmlDoc = null;
            }
            catch (XmlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar dados para acesso ao banco de dados!\n" + ex.Message, "EstacionamentoFacil (BD02)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                bResposta = false;
            }

            return bResposta;
        }

        public DadosConexao buscarDadosConexao(string sArquivoConexao, byte bTipo = 0)
        {
            DadosConexao cDadosConexao = null;

            try
            {
                Funcoes cFuncoes = new Funcoes();
                cDadosConexao = new DadosConexao();
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(sArquivoConexao);
                XmlNodeList xnList = xmlDoc.GetElementsByTagName("Parametros");
                foreach (XmlNode xn in xnList)
                {
                    cDadosConexao.sServidor = xn["Servidor"].InnerText;
                    cDadosConexao.iPorta = int.Parse(xn["Porta"].InnerText);
                    cDadosConexao.sUsuario = xn["User"].InnerText;
                    cDadosConexao.sSenha = cFuncoes.Descriptografar(xn["Pass"].InnerText);
                    cDadosConexao.sNomeBaseDados = xn["DataBase"].InnerText;
                    cDadosConexao.sChaveAcesso = cFuncoes.Descriptografar(xn["ChaveAcesso"].InnerText);
                    cDadosConexao.iTipoRelatorio = 0;// int.Parse(xn["TipoRelatorio"].InnerText);
                }
                xnList = null;      
            }
            catch (XmlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar dados para acesso ao banco de dados!\n" + ex.Message, "EstacionamentoFacil (BD02b)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);                
            }
            return cDadosConexao;
        }
        
        /*
        'zerando valores
                vJ = 0
                'Nome da tabela
                vNomeTabela = vDS.Tables(vI).ToString 'dados

                If vNomeTabela = vEmpresa Then

                    'percorrendo nomes dos campos e criando parametros
                    While vJ < vDS.Tables(vI).Columns.Count 'nome campos
                        Select Case vDS.Tables(vI).Columns(vJ).ColumnName
                            Case "DNS"
                                vvDNS = vDS.Tables(vI).Rows(0).Item(vJ)
                            Case "IP"
                                vvIp = vDS.Tables(vI).Rows(0).Item(vJ)
                            Case "Porta"
                                vvPorta = vDS.Tables(vI).Rows(0).Item(vJ)
                            Case "User"
                                vvUser = vDS.Tables(vI).Rows(0).Item(vJ)
                            Case "Pass"
                                vvPass = vDS.Tables(vI).Rows(0).Item(vJ)
                            Case "UseIp"
                                vvUseIp = CByte(vDS.Tables(vI).Rows(0).Item(vJ))
                            Case "DataBase"
                                vvDataBase = vDS.Tables(vI).Rows(0).Item(vJ)
                            Case "Link"
                                Principal.vvEnderecoLink = vDS.Tables(vI).Rows(0).Item(vJ)
                            Case "ServidorGestCom"
                                Principal.vvServidorGestCom = vDS.Tables(vI).Rows(0).Item(vJ)
                        End Select
                        vJ = vJ + 1
                    End While
                End If

                vI = vI + 1
            End While

            piscaLabel()

            vResposta = True
        Catch ex As Exception
            MsgBox("Erro ao recuperar dados da conexão." & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Dados da conexão")
            vResposta = False
        End Try
        Return vResposta
    End Function
         * */

    }
}
