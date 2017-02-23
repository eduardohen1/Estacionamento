using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Estancionamento
{
    public class cliente
    {
        public int Codigo {get; set;}
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Email { get; set; }
        public int Cod_logradouro { get; set; }
        public int Numero { get; set; }
        public string Observacao {get; set;}
        /// <summary>
        /// 0 Cliente normal - 1 Prospect
        /// </summary>
        public int TipoCliente { get; set; }
        /// <summary>
        /// 0 Pessoa física 1 Pessoa Juridica
        /// </summary>
        public int TipoPessoa { get; set; }
        public DateTime DtNascimento { get; set; }
        public DateTime DtCadastro { get; set; }
        public DateTime DtRenovacaoSeguro { get; set; }
        public string Profissao { get; set; }
        /// <summary>
        /// 0 ATIVO 1 INATIVO 2 CANCELADO 3 POTENCIAL
        /// </summary>
        public int Status { get; set; }
        public string EstadoCivil { get; set; }
        /// <summary>
        /// 0 (0 - 1000) 1 (1001 - 3000) 2 (3001 - 5000) 3 (5001 - 10000) 4 (10001 - 20000)
        /// </summary>
        public int FaixaSalarial { get; set; }
        public string CNH { get; set; }
        public DateTime ValidadeCNH { get; set; }
        public string CategoriaCNH { get; set; }
        public DateTime DtPrimeiraCNH { get; set; }
        /// <summary>
        /// 0 Masculino 1 Feminino
        /// </summary>
        public int Sexo { get; set; }
    }

    public class ContaCartaoCliente
    {
        public int CodContaCartao { get; set; }
        /// <summary>
        /// 0 Cartao 1 Conta Corrente 2 Conta Poupança
        /// </summary>
        public int Tipo { get; set; }
        public int CodCliente { get; set; }
        public string Numero { get; set; }
        public string Bandeira { get; set; }
        public string NomeBanco { get; set; }
        public string Agencia { get; set; }
        public string NumConta { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public string Obs { get; set; }
    }

    public class Operadora
    {
        public int Codigo { get; set; }
        public string operadora { get; set; }
    }

    public class Telefones
    {
        public int CodigoTelefone { get; set; }
        public int codoperadora { get; set; }
        public string ddd { get; set; }
        public string telefone { get; set; }
        /// <summary>
        /// TipoTelefone 0 - Telefone fixo; 1 - Telefone celular; 2 - Outros;
        /// </summary>
        public int tipotelefone { get; set; }
        /// <summary>
        /// Telefone de qual classe: 0 - Clientes; 1 - Vendedor
        /// </summary>
        public int telefonedq { get; set; }
    }

    public class TelefoneToken
    {
        public string Codigo { get; set; }
        public string ddd { get; set; }
        public string telefone { get; set; }
        public int Codigo_Operadora { get; set; }
        public int Tipo_telefone { get; set; }
    }

    public class histCliente
    {
        public int CodVenda { get; set; }
        public int CodCarro { get; set; }
        public DateTime dataHist { get; set; }
        public string operacao { get; set; }        
    }

    public class ProspectMarca
    {
        public int CodProspect { get; set; }
        public int CodMarca { get; set; }
    }

    public class ProspectCor
    {
        public int CodProspect { get; set; }
        public Cores cCores { get; set; }
    }

    public class ProspectMotor
    {
        public int CodProspect { get; set; }
        public int CodMotor { get; set; }
    }

    public class ProspectPortas
    {
        public int CodProspect { get; set; }
        public int iQtePortas { get; set; }
    }
    public class Prospect
    {
        public int CodProspect { get; set; }
        public cliente cCliente { get; set; }
        public List<ProspectMarca> cProspectMarca { get; set; }
        public List<ProspectCor> cProspectCor { get; set; }
        public List<ProspectMotor> cProspectMotor { get; set; }
        public List<ProspectPortas> cProspectPortas { get; set; }
    }
        
    class Cliente
    {
        //comandos
        CamadaDados execComandos = new CamadaDados();
        
        //conexao 
        SqlConnection cnConexao;
        string sServidor;
        string sDataBase;
        string sUsuario;
        string sSenha;
        string sChaveAcesso;
        int iPortaAcesso;
        string sArquivoConexao;

        public bool preparaBancoDados()
        {
            bool bResposta = true;

            if (execComandos.buscarDadosConexao(sArquivoConexao))
            {
                this.sServidor = execComandos.vvServidor;
                this.sDataBase = execComandos.vvDataBase;
                this.sUsuario = execComandos.vvUser;
                this.sSenha = execComandos.vvPass;
                this.iPortaAcesso = execComandos.vvPorta;
                this.sChaveAcesso = execComandos.vvChaveAcesso;
            }
            else
            {
                bResposta = false;
            }
            return bResposta;
        }

        //Conexao
        public SqlConnection Conexao
        {
            set { cnConexao = value; }
        }
        public string NomeServidor
        {
            get { return sServidor; }
            set { sServidor = value; }
        }
        public string DataBase
        {
            get { return sDataBase; }
            set { sDataBase = value; }
        }
        public string UsuarioDataBase
        {
            get { return sUsuario; }
            set { sUsuario = value; }
        }
        public string SenhaDataBase
        {
            get { return sSenha; }
            set { sSenha = value; }
        }
        public string ArquivoConexao
        {
            get { return sArquivoConexao; }
            set { sArquivoConexao = value; }
        }

        /// <summary>
        /// Função para gravar dados de operadora
        /// </summary>
        /// <param name="cOperadora">Objeto Operadora</param>
        /// <param name="bTipo">Tipo de gravação 0 - Inserir, 1 - Atualizar </param>
        /// <returns>Retorna verdadeiro ou falso dependendo do retorno da função</returns>
        public bool gravarOperadora(Operadora cOperadora, byte bTipo)
        {
            bool bResposta = false;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    if (bTipo == 0)
                    {
                        cOperadora.Codigo = execComandos.ultimoCodigoOperadora() +1;
                    }
                    if (cOperadora.Codigo != 0)
                    {
                        bResposta = execComandos.inserirAtualizarOperadora(cOperadora, bTipo);
                    }
                    execComandos.Desconectar();
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para buscar dados de operadora
        /// </summary>
        /// <param name="iCodigo">Código da operadora</param>
        /// <returns>Retorna o objeto Operadora</returns>
        public Operadora pesquisarOperadora(int iCodigo)
        {
            Operadora cOperadora = new Operadora();
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    cOperadora = execComandos.pesquisaOperadora(iCodigo);
                    return cOperadora;
                }
                else return null;
                execComandos.Desconectar();
            }
            else return null;
        }

        /// <summary>
        /// Função para pesquisar todas as operadoras
        /// </summary>
        /// <returns>Lista de objeto Operadora</returns>
        public List<Operadora> pesquisarTodasOperadoras()
        {
            SqlDataReader drLer;
            List<Operadora> _Operadora = new List<Operadora>();
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    drLer = execComandos.pesquisarTodasOperadoras();
                    if (drLer.HasRows)
                    {
                        while (drLer.Read())
                        {
                            _Operadora.Add(new Operadora()
                            {
                                Codigo = int.Parse(drLer["codigo"].ToString()),
                                operadora = drLer["operadora"].ToString()
                            });
                        }
                    }
                    return _Operadora;
                    execComandos.Desconectar();
                }
                else return null;
            }
            else return null;
        }

        /// <summary>
        /// Função para excluir operadoras
        /// </summary>
        /// <param name="iCodigo">Código de operadora para excluir</param>
        /// <returns>Retorna verdadeiro ou falso na execução da função</returns>
        public bool excluirOperadora(int iCodigo)
        {
            bool bResposta = false;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    if (execComandos.excluirOperadora(iCodigo)) bResposta = true;
                    execComandos.Desconectar();
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para verificar se existe a operadora
        /// </summary>
        /// <param name="sNome">Nome da operadora</param>
        /// <returns>Verdadeiro ou falso se existe</returns>
        public bool seExisteOperadora(string sNome)
        {
            bool bResposta = false;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    bResposta = execComandos.existeOperadora(sNome);
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para gravar telefones
        /// </summary>
        /// <param name="lTelefones">Lista de objetos Telefone</param>
        /// <param name="cCliente">Objeto cliente para atualizar o relacionamento</param>
        /// <returns>Retorna verdadeiro ou falso conforme a execução da função</returns>
        public bool gravarTelefones(List<Telefones> lTelefones, cliente cCliente)
        {
            bool bResposta = false;
            byte btTipo = 1;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    foreach (Telefones lstTelefones in lTelefones)
                    {
                        if (lstTelefones.CodigoTelefone == 0)
                        {
                            lstTelefones.CodigoTelefone = execComandos.ultimoCodigoTelefone() + 1;
                            btTipo = 0;
                        }
                        bResposta = execComandos.inserirAtualizarTelefone(lstTelefones, cCliente, btTipo);
                        if (!bResposta)
                            break;
                    }
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para gravar carro para cliente
        /// </summary>
        /// <param name="iCodigoCliente">Código do cliente</param>
        /// <param name="iCodigoCarro">Código do carro</param>
        /// <param name="bTipo">Tipo de execução 0 - Insert 1 - Update</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool gravarVeiculosCliente(int iCodigoCliente, int iCodigoCarro)
        {
            bool bResposta = false;
            byte btTipo = 1;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    bResposta = execComandos.inserirVeiculoCliente(iCodigoCarro, iCodigoCliente);
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para retornar a lista de objetos de telefone
        /// </summary>
        /// <param name="iCodigo">Código do cliente</param>
        /// <returns>Lista de telefones</returns>
        public List<Telefones> pesquisarTelefoneCliente(int iCodigo)
        {
            List<Telefones> lstTelefone = new List<Telefones>();
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    lstTelefone = execComandos.pesquisaTelefoneCliente(iCodigo);
                    return lstTelefone;
                }
                else return null;
                execComandos.Desconectar();
            }
            else return null;

        }

        /// <summary>
        /// Função para excluir telefone
        /// </summary>
        /// <param name="iCodigo">Código do telefone a ser excluído</param>
        /// <returns>Retorna verdadeiro ou falso conforme a execução do programa</returns>
        public bool excluirTelefone(int iCodigo)
        {
            bool bResposta = false;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    if (execComandos.excluirTelefone(iCodigo)) bResposta = true;
                    execComandos.Desconectar();
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para excluir todos os registro de telefones do cliente
        /// </summary>
        /// <param name="iCodigoCliente">Código do cliente</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool excluirTodosTelefones(int iCodigoCliente)
        {
            bool bResposta = false;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    if (execComandos.excluirTodosTelefoneCliente(iCodigoCliente)) bResposta = true;
                    execComandos.Desconectar();
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para excluir todos os registros de veículos do cliente
        /// </summary>
        /// <param name="iCodigoCliente">Código do cliente</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool excluirTodosVeiculosCliente(int iCodigoCliente)
        {
            bool bResposta = false;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    if (execComandos.excluirTodosVeiculosCliente(iCodigoCliente)) bResposta = true;
                    execComandos.Desconectar();
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para excluir veículo de cliente
        /// </summary>
        /// <param name="iCodigoVeiculo">Código do veículo</param>
        /// <param name="iCodigoCliente">Código do cliente</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool excluirVeiculoCliente(int iCodigoVeiculo, int iCodigoCliente)
        {
            bool bResposta = false;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    if (execComandos.excluirVeiculoCliente(iCodigoCliente,iCodigoVeiculo)) bResposta = true;
                    execComandos.Desconectar();
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para gravar dados do cliente
        /// </summary>
        /// <param name="cCliente">Objeto cliente já preenchido</param>
        /// <param name="bTipo">Tipo de operação (0 insert, 1 update)</param>
        /// <returns>Retorna verdadeiro ou falso dependendo da execução da função</returns>
        public bool gravarCliente(cliente cCliente, byte bTipo)
        {
            bool bResposta = false;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {                    
                    bResposta = execComandos.inserirAtualizarCliente(cCliente, bTipo);
                    execComandos.Desconectar();
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para retornar o último código cadastrado de clientes
        /// </summary>
        /// <returns>Último código cadastardo</returns>
        public int ultimoCodigoCliente()
        {
            int iResposta = 0;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    iResposta = execComandos.ultimoCodigoCliente();
                    execComandos.Desconectar();
                }
            }
            return iResposta;
        }

        /// <summary>
        /// Função de pesquisa dos dados de um determinado cliente
        /// </summary>
        /// <param name="iCodigo">Código do cliente a ser pesquisado</param>
        /// <returns>Retorna o objeto cliente com os dados preenchidos</returns>
        public cliente pesquisarCliente(int iCodigo)
        {   
            cliente cCliente = new cliente();            
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    cCliente = execComandos.pesquisaCliente(iCodigo);
                    return cCliente;
                }
                else return null;
                execComandos.Desconectar();
            }
            else return null;
            
        }

        /// <summary>
        /// Função para ajustar versão do banco de dados e do sistema
        /// </summary>
        /// <returns></returns>
        public bool controleVersao()
        {            
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    return execComandos.controleVersao();                    
                }
                else return false;
                execComandos.Desconectar();
            }
            else return false;
        }

        /// <summary>
        /// Função para pesquisa de Todos os clientes cadastrados
        /// </summary>
        /// <returns>Retorna uma lista de objetos cliente</returns>
        public List<cliente> pesquisarTodosClientes()
        {
            SqlDataReader drLer;
            List<cliente> _Cliente = new List<cliente>();
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    drLer = execComandos.pesquisarTodosClientes();
                    if (drLer.HasRows)
                    {
                        while (drLer.Read())
                        {
                            _Cliente.Add(new cliente()
                            {
                                Codigo = int.Parse(drLer["Codigo"].ToString()),
                                Nome = drLer["Nome"].ToString(),
                                CPF = drLer["CPF"].ToString(),
                                RG = drLer["RG"].ToString(),
                                Cod_logradouro = int.Parse(drLer["Cod_logradouro"].ToString()),
                                Numero = int.Parse(drLer["Numero"].ToString()),
                                Email = drLer["Email"].ToString(),
                                Observacao = drLer["Observacao"].ToString(),
                                TipoCliente = int.Parse(drLer["TipoCliente"].ToString())
                            });
                        }
                    }
                    return _Cliente;
                    execComandos.Desconectar();
                }
                else return null;
            }
            else return null;
        }

        /// <summary>
        /// Função para exclusão de um determinado Cleinte
        /// </summary>
        /// <param name="iCodigo">Código para exclusão</param>
        /// <returns>Retorna verdadeiro ou false dependendo da execução da função</returns>
        public bool excluirCliente(int iCodigo, int iCodigoUsuario, string sTela)
        {
            bool bResposta = false;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    if (execComandos.excluirCliente(iCodigo))
                    {
                        if (execComandos.excluirTodosTelefoneCliente(iCodigo))
                        {
                            if (execComandos.excluirTodosVeiculosCliente(iCodigo))
                                bResposta = true;
                            else
                                bResposta = false;
                        }
                        else
                        {
                            bResposta = false;
                        }
                        if (bResposta) execComandos.inserirAuditoria(21, iCodigoUsuario, "Exclusão de cliente código: " + iCodigo.ToString(), sTela);

                    }
                    execComandos.Desconectar();
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para verificação se um cliente existe cadastrado
        /// </summary>
        /// <param name="sNome">Nome do cliente para pesquisa</param>
        /// <returns>Retorna verdadeiro ou falso caso exista ou não o cliente</returns>
        public bool seExisteCliente(string sNome)
        {
            bool bResposta = false;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    bResposta = execComandos.existeCliente(sNome);
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para buscar observações do cliente
        /// </summary>
        /// <param name="iCodigoCliente">Código do cliente a ser pesquisado</param>
        /// <returns>Retorna uma lista de objetos de Observação do cliente</returns>
        public List<observacao> buscarObservacaoCliente(int iCodigoCliente)
        {
            List<observacao> lstObservacao = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    lstObservacao = execComandos.buscaObservacao(1,iCodigoCliente);
                }
            }
            return lstObservacao;
        }

        /// <summary>
        /// Função para buscar o histórico de veículos do cliente
        /// </summary>
        /// <param name="cCliente">Objeto cliente</param>
        /// <returns>Retorna uma lista do objeto histCliente</returns>
        public List<histCliente> buscarHistoricoCliente(cliente cCliente)
        {
            List<histCliente> lstHistorico = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    lstHistorico = execComandos.buscarHistoricoCliente(cCliente.Codigo);
                }
            }
            return lstHistorico;
        }

        public List<ContaCartaoCliente> buscarContaCartaoCliente(cliente cCliente)
        {
            List<ContaCartaoCliente> lstContaCartao = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    lstContaCartao = execComandos.buscarContaCartaoCliente(cCliente.Codigo);
                }
            }
            return lstContaCartao;
        }

        /// <summary>
        /// Função para inserir observação para o cliente
        /// </summary>
        /// <param name="cObservacao">Objeto observação</param>
        /// <param name="sTela">Tela de origem</param>
        /// <returns>Retorna verdeiro ou falso mediante a execução da função</returns>
        public bool inserirObservacaoCliente(observacao cObservacao, string sTela)
        {
            bool bResposta = false;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    bResposta = execComandos.inserirObservacao(cObservacao);
                    if (bResposta) execComandos.inserirAuditoria(2, cObservacao.cod_usuario, "Nova observação para o cliente cód. " + cObservacao.codigo.ToString(), sTela);
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para inserir conta/cartão para o cliente
        /// </summary>
        /// <param name="cContaCartao">Objeto conta/cartão</param>
        /// <param name="sTela">Tela de origem</param>
        /// <returns>Retorna verdeiro ou falso mediante a execução da função</returns>
        public bool inserirContaCartaoCliente(ContaCartaoCliente cContaCartao, int iCodigoUsuario, string sTela)
        {
            bool bResposta = false;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    bResposta = execComandos.inserirContaCartaoCliente(cContaCartao);
                    if (bResposta) execComandos.inserirAuditoria(20, iCodigoUsuario, "Nova Conta/Cartão para o cliente cód. " + cContaCartao.CodCliente.ToString(), sTela);
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para excluir observação do cliente
        /// </summary>
        /// <param name="iCodigoObservacao">Código da observação para exclusão</param>
        /// <param name="iCodigoUsuario">Código do usuário da exclusão</param>
        /// <param name="sTela">Tela de exclusão</param>
        /// <param name="sMotivo">Motivo para exclusão</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool excluirObservacaoCliente(int iCodigoObservacao, int iCodigoUsuario, string sTela, string sMotivo)
        {
            bool bResposta = false;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    bResposta = execComandos.excluirObservacao(iCodigoObservacao);
                    if (bResposta) execComandos.inserirAuditoria(3, iCodigoUsuario, "Exclusão observação: " + sMotivo, sTela);
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para excluir conta/cartao do cliente
        /// </summary>
        /// <param name="iCodigoContaCartao">Código da conta/cartão para exclusão</param>
        /// <param name="iCodigoUsuario">Código do usuário da exclusão</param>
        /// <param name="sTela">Tela de exclusão</param>
        /// <param name="sMotivo">Motivo para exclusão</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool excluirContaCartaoCliente(int iCodigoContaCartao, int iCodigoUsuario, string sTela, string sMotivo)
        {
            bool bResposta = false;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    bResposta = execComandos.excluirContaCartaoCliente(iCodigoContaCartao);
                    if (bResposta) execComandos.inserirAuditoria(19, iCodigoUsuario, "Exclusão conta/cartão: " + sMotivo, sTela);
                }
            }
            return bResposta;
        }
        /// <summary>
        /// Função para gerar dados para a impressão de relatório de clientes cadastrados
        /// </summary>
        /// <param name="sQuery">Cláusula para pesquisa</param>
        /// <param name="sFiltro">Filtro para pesquisa</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool impr_ClientesCadastrados(string sQuery, string sFiltro)
        {
            bool bResposta = false;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    if (execComandos.impr_ClientesCadastrados(sQuery, sFiltro))
                    {
                        bResposta = execComandos.existeRegistroTemp();
                        if(!bResposta)
                            System.Windows.Forms.MessageBox.Show("Nenhum registro selecionado.", "EstacionamentoFacil (100D)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);                        
                    }
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para a impressão de relatório
        /// </summary>
        /// <returns></returns>
        public CrystalDecisions.Windows.Forms.CrystalReportViewer imprimirClientesCadastrados()
        {
            CrystalDecisions.Windows.Forms.CrystalReportViewer relatorio = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    relatorio = execComandos.impr_ClientesCadastrados();
                }
            }
            return relatorio;
        }

        /// <summary>
        /// Função apra a impressão de relatório
        /// </summary>
        /// <param name="bTipo">Tipo</param>
        /// <returns>Retorna dataset contendo a temporariaimpressao</returns>
        public DataSet imprimirClientesCadastrados(byte bTipo)
        {
            DataSet dataset = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    dataset = execComandos.impr_ClientesCadastrados(bTipo);
                }
            }
            return dataset;
        }

        /// <summary>
        /// Função para localizar dados de um cliente na tela de Localização.
        /// </summary>
        /// <param name="sSQL">Filtro para pesquisa</param>
        /// <returns>Retorna lista de objeto Cleinte</returns>
        public List<cliente> localizarDadosCliente(string sSQL)
        {
            List<cliente> cCliente = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    cCliente = execComandos.localizarDadosCliente(sSQL);
                }
            }
            return cCliente;
        }

    }

}
