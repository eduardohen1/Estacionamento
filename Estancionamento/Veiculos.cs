using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Estancionamento
{

    public class carro
    {
        public int Codigo { get; set; }
        public int CodMarca { get; set; }
        public string Modelo { get; set; }
        public string Serie { get; set; }
        public int Placa { get; set; }
        public int AnoFab { get; set; }
        public int AnoMod { get; set; }
        public string cor { get; set; }
        public int QtdePortas { get; set; }
        public int Chassi { get; set; }
        public int Renavan { get; set; }
        public string Num_motor { get; set; }
        public int Procedencia { get; set; }
        public int Configuracao { get; set; }
        public int Lugares { get; set; }
        public int Transmissao { get; set; }
        public int Tracao { get; set; }
        public int Potencia { get; set; }
        public int Rpm { get; set; }
        public float Torque { get; set; }
        public string Placa2 { get; set; }
        public string Chassi2 { get; set; }
        /// <summary>
        /// - Situacao 
        /// -- A Ativo
        /// -- E Excluído
        /// -- H Histórico
        /// </summary>
        public string Situacao { get; set; }
        public string Renavan2 { get; set; }
    }

    public class marca
    {
        public int codigo { get; set; }
        public string descricao { get; set; }
    }

    public class opicionais
    {
        public int codigo { get; set; }
        public string descricao { get; set; }
    }

    public class modelo
    {
        public int codigo { get; set; }
        public int codmarca { get; set; }
        public string Modelo { get; set; }
        public int portas { get; set; }
        public int motor { get; set; }
    }

    public class despesas
    {
        public int codigo { get; set; }
        public string Descrição { get; set; }
        public int Num_nota { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public string Observacao { get; set; }
    }

    public class movimento
    {
        public int codigo { get; set; }
        public int codcarro { get; set; }
        public int codcliente { get; set; }
        public DateTime datamoviment { get; set;}
        public int codvendedor { get; set; }
        public double valor { get; set; }
        public double tipocomissao { get; set; }
        public string valorcomissao { get; set; }
        public double lucroliquido { get; set; }
        public string dut { get; set; }
        public string recibo { get; set; }
        public string TipoComissao2 { get; set; }
        public double valorcomissao2 { get; set; }
    }

    public class vendedor
    {
        public int código { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string telefone { get; set; }
        public string celular { get; set; }
        public string email { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public string lembrete { get; set; }
        /// <summary>
        /// A - Ativo, E - Excluído, I - Inativo
        /// </summary>
        public string situacao { get; set; }
    }

    public class historico
    {
        public int cod_historico { get; set; }
        public int cod_carro { get; set; }
        public int cod_usuario { get; set; }
        /// <summary>
        /// tipo 0 Compra, 1 venda, 2 entrada estancionamento, 3 saida estancionamento, 4 texto livre
        /// </summary>
        public int tipo { get; set; }
        public DateTime data_hist { get; set; }
        public string observacao { get; set; }
        /// <summary>
        /// Código do objeto de relacionamento
        /// </summary>        
    }

    public class observacao
    {
        public int cod_observacao { get; set; }
        /// <summary>
        /// tipo 0 carro, 1 cliente
        /// </summary>
        public int tipo { get; set; }
        public string sObservacao { get; set; }
        public DateTime data_observacao { get; set; }
        public int cod_usuario { get; set; }
        public int codigo { get; set; }
    }

    public class vendas
    {
        public int cod_venda { get; set; }
        public int cod_carro { get; set; }
        public int cod_cliente_comprador { get; set; }
        /// <summary>
        /// 0 pelo estancionamento 1 intermediação
        /// </summary>
        public int tipo_venda { get; set; }
        public double valor { get; set; }
        public string tipo_comissao { get; set; }
        public double valor_comissao { get; set; }
        public DateTime data_venda { get; set; }
        public int cod_cliente_vendedor { get; set; }
        /// <summary>
        /// 0 em aberto 1 concluída 2 cancelada 3 aguardando financiamento 4 suspensa
        /// </summary>
        public int situacao { get; set; }
        public string observacao { get; set; }
    }

    public class vendas_vendedor
    {
        public int cod_venda { get; set; }
        public int cod_vendedor { get; set; }
        public double valor_comissao { get; set; }
        /// <summary>
        /// 0-Aberto 1-Lançado, 2-Cancelado, 3-Apenas Lançado
        /// </summary>
        public int situacao { get; set; }
    }

    public class Usuario
    {
        public int cod_usuario { get; set; }
        public string senha { get; set; }
        public int tipo { get; set; }
        public string dica_senha { get; set; }
        public string usuario { get; set; }
        public string nomeusuario { get; set; }
    }

    public class retornoConsultaVeiculos
    {
        public string sCodigo { get; set; }
        public string sTexto { get; set; }
    }

    public class Motor
    {
        public int CodMotor { get; set; }
        public string TipoMotor { get; set; }
        public string Potencia { get; set; }
        public string Combustivel { get; set; }
    }

    public class Cores
    {
        public int CodCor { get; set; }
        public string sCor { get; set; }
        public string sRGB { get; set; }
    }
    
    public class Veiculos
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
        /// Função para gravar dados do Carro
        /// </summary>
        /// <param name="cCarro">Objeto Carro</param>
        /// <param name="bTipo">Tipo de gravação 0 - Inserir, 1 - Atualizar</param>
        /// <returns>Retorna T (verdadeiro) F (falso) ou o código do carro para tipo = 0</returns>
        public string gravarCarros(carro cCarro, byte bTipo)
        {
            string sResposta = "F";
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    //ajustar modelo de veículo:
                    //if (execComandos.ajustarModelo(cCarro))
                    //{
                    sResposta = execComandos.inserirAtualizarCarro(cCarro, bTipo);
                    execComandos.Desconectar();
                    //}
                }
            }
            return sResposta;
        }

        /// <summary>
        /// Função para retornar dados de um determinado carro
        /// </summary>
        /// <param name="iCodigo">Código do carro a ser pesquisado</param>
        /// <returns>Retorna o objeto Carro preenchido</returns>
        public carro pesquisarCarro(int iCodigo)
        {
            carro cCarro = new carro();
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    cCarro = execComandos.pesquisaCarro(iCodigo);
                    return cCarro;
                }
                else return null;
                //execComandos.Desconectar();
            }
            else return null;
        }

        /// <summary>
        /// Função para retornar todos os carros cadastrados
        /// </summary>
        /// <returns>Lista de objetos Carro</returns>
        public List<carro> pesquisarTodosCarros()
        {
            SqlDataReader drLer;
            List<carro> _Carro = new List<carro>();
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    drLer = execComandos.pesquisarTodosCarros();
                    if (drLer.HasRows)
                    {
                        while (drLer.Read())
                        {
                            _Carro.Add(new carro()
                            {
                                Codigo = int.Parse(drLer["Codigo"].ToString()),
                                CodMarca = int.Parse(drLer["CodMarca"].ToString()),
                                Modelo = drLer["Modelo"].ToString(),
                                Serie = drLer["Serie"].ToString(),
                                Placa = int.Parse(drLer["Placa"].ToString()),
                                AnoFab = int.Parse(drLer["AnoFab"].ToString()),
                                AnoMod = int.Parse(drLer["AnoMod"].ToString()),
                                cor = drLer["Cor"].ToString(),
                                QtdePortas = int.Parse(drLer["QtdePortas"].ToString()),
                                Chassi = int.Parse(drLer["Chassi"].ToString()),
                                Renavan = int.Parse(drLer["Renavan"].ToString()),
                                Num_motor = drLer["Num_motor"].ToString(),
                                Procedencia = int.Parse(drLer["Procedencia"].ToString()),
                                Configuracao = int.Parse(drLer["Configuracao"].ToString()),
                                Lugares = int.Parse(drLer["Lugares"].ToString()),
                                Transmissao = int.Parse(drLer["Transmissao"].ToString()),
                                Tracao = int.Parse(drLer["Tracao"].ToString()),
                                Potencia = int.Parse(drLer["Potencia"].ToString()),
                                Rpm = int.Parse(drLer["Rpm"].ToString()),
                                Torque = float.Parse(drLer["Torque"].ToString()),
                                Placa2 = drLer["Placa2"].ToString(),
                                Chassi2 = drLer["Chassi2"].ToString(),
                                Situacao = drLer["Situacao"].ToString()
                            });
                        }
                    }
                    return _Carro;
                    execComandos.Desconectar();
                }
                else return null;
            }
            else return null;
        }

        /// <summary>
        /// Função apra pesquisar todos os carros do cliente
        /// </summary>
        /// <param name="iCodigo">Código do cliente</param>
        /// <returns>Retorna uma lista de objetos Carro contendo o result da pesquisa</returns>
        public List<carro> pesquisarTodosCarrosCliente(int iCodigo)
        {
            SqlDataReader drLer;
            List<carro> _Carro = new List<carro>();
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    drLer = execComandos.pesquisarTodosCarrosCliente(iCodigo);
                    if (drLer.HasRows)
                    {
                        while (drLer.Read())
                        {
                            _Carro.Add(new carro()
                            {
                                Codigo = int.Parse(drLer["Codigo"].ToString()),
                                CodMarca = int.Parse(drLer["CodMarca"].ToString()),
                                Modelo = drLer["Modelo"].ToString(),
                                Serie = drLer["Serie"].ToString(),
                                Placa = int.Parse(drLer["Placa"].ToString()),
                                AnoFab = int.Parse(drLer["AnoFab"].ToString()),
                                AnoMod = int.Parse(drLer["AnoMod"].ToString()),
                                cor = drLer["Cor"].ToString(),
                                QtdePortas = int.Parse(drLer["QtdePortas"].ToString()),
                                Chassi = int.Parse(drLer["Chassi"].ToString()),
                                Renavan = int.Parse(drLer["Renavan"].ToString()),
                                Num_motor = drLer["Num_motor"].ToString(),
                                Procedencia = int.Parse(drLer["Procedencia"].ToString()),
                                Configuracao = int.Parse(drLer["Configuracao"].ToString()),
                                Lugares = int.Parse(drLer["Lugares"].ToString()),
                                Transmissao = int.Parse(drLer["Transmissao"].ToString()),
                                Tracao = int.Parse(drLer["Tracao"].ToString()),
                                Potencia = int.Parse(drLer["Potencia"].ToString()),
                                Rpm = int.Parse(drLer["Rpm"].ToString()),
                                Torque = float.Parse(drLer["Torque"].ToString()),
                                Placa2 = drLer["Placa2"].ToString(),
                                Chassi2 = drLer["Chassi2"].ToString(),
                                Situacao = drLer["Situacao"].ToString()
                            });
                        }
                    }
                    return _Carro;
                    execComandos.Desconectar();
                }
                else return null;
            }
            else return null;
        }

        /// <summary>
        /// Função para listar todos os carros que não tem vínculo com outro cliente
        /// </summary>
        /// <param name="sCodigosNaoListar">Códigos de veículos para não listar</param>
        /// <returns>Retorna uma lista de objetos Carro contendo o result da pesquisa</returns>
        public List<carro> pesquisarTodosCarrosSemClientes(string sCodigosNaoListar)
        {
            SqlDataReader drLer;
            List<carro> _Carro = new List<carro>();
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    drLer = execComandos.pesquisarTodosCarrosSemClientes(sCodigosNaoListar);
                    if (drLer.HasRows)
                    {
                        while (drLer.Read())
                        {
                            _Carro.Add(new carro()
                            {
                                Codigo = int.Parse(drLer["Codigo"].ToString()),
                                CodMarca = int.Parse(drLer["CodMarca"].ToString()),
                                Modelo = drLer["Modelo"].ToString(),
                                Serie = drLer["Serie"].ToString(),
                                Placa = int.Parse(drLer["Placa"].ToString()),
                                AnoFab = int.Parse(drLer["AnoFab"].ToString()),
                                AnoMod = int.Parse(drLer["AnoMod"].ToString()),
                                cor = drLer["Cor"].ToString(),
                                QtdePortas = int.Parse(drLer["QtdePortas"].ToString()),
                                Chassi = int.Parse(drLer["Chassi"].ToString()),
                                Renavan = int.Parse(drLer["Renavan"].ToString()),
                                Num_motor = drLer["Num_motor"].ToString(),
                                Procedencia = int.Parse(drLer["Procedencia"].ToString()),
                                Configuracao = int.Parse(drLer["Configuracao"].ToString()),
                                Lugares = int.Parse(drLer["Lugares"].ToString()),
                                Transmissao = int.Parse(drLer["Transmissao"].ToString()),
                                Tracao = int.Parse(drLer["Tracao"].ToString()),
                                Potencia = int.Parse(drLer["Potencia"].ToString()),
                                Rpm = int.Parse(drLer["Rpm"].ToString()),
                                Torque = float.Parse(drLer["Torque"].ToString()),
                                Placa2 = drLer["Placa2"].ToString(),
                                Chassi2 = drLer["Chassi2"].ToString(),
                                Situacao = drLer["Situacao"].ToString()
                            });
                        }
                    }
                    return _Carro;
                    execComandos.Desconectar();
                }
                else return null;
            }
            else return null;
        }

        /// <summary>
        /// Função para alterar a situação do Carro
        /// </summary>
        /// <param name="iCodigo">Código do carro para alterar a situação</param>
        /// <param name="sSituacao">Situação de alteração (A - Ativo, E - Excluir, H - Histórico</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool alterarSituacaoCarro(int iCodigo, string sSituacao)
        {
            bool bResposta = false;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    if (execComandos.alterarSituacao(iCodigo, sSituacao)) bResposta = true;
                    execComandos.Desconectar();
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para verificar se um determinado carro existe
        /// </summary>
        /// <param name="sPlaca">Placa do carro para verificação</param>
        /// <returns>Retorna verdeiro ou falso se a placa do carro existe</returns>
        public bool seExisteCarro(string sPlaca)
        {
            bool bResposta = false;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    bResposta = execComandos.existeCarro(sPlaca);
                }
            }
            return bResposta;
        }

        //------------------------------------------------
        /// <summary>
        /// Função para gravar dados de Marca
        /// </summary>
        /// <param name="cMarca">Objeto Marca</param>
        /// <param name="bTipo">Tipo de gravação 0 - Inserir, 1 - Atualizar </param>
        /// <returns>Retorna verdadeiro ou falso dependendo do retorno da função</returns>
        public bool gravarMarca(marca cMarca, byte bTipo)
        {
            bool bResposta = false;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    if (bTipo == 0)
                        cMarca.codigo = execComandos.ultimoCodigoMarca() + 1;
                    bResposta = execComandos.inserirAtualizarMarca(cMarca, bTipo);
                    execComandos.Desconectar();
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para buscar dados de Marca
        /// </summary>
        /// <param name="iCodigo">Código da marca</param>
        /// <returns>Retorna o objeto Marca</returns>
        public marca pesquisarMarca(int iCodigo)
        {
            marca cMarca = new marca();
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    cMarca = execComandos.pesquisaMarca(iCodigo);
                    return cMarca;
                }
                else return null;
                execComandos.Desconectar();
            }
            else return null;
        }

        /// <summary>
        /// Função para pesquisar todas as marcas
        /// </summary>
        /// <returns>Lista de objeto Marca</returns>
        public List<marca> pesquisarTodasMarcas()
        {
            SqlDataReader drLer;
            List<marca> _Marca = new List<marca>();
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    drLer = execComandos.pesquisarTodasMarca();
                    if (drLer.HasRows)
                    {
                        while (drLer.Read())
                        {
                            _Marca.Add(new marca()
                            {
                                codigo = int.Parse(drLer["codigo"].ToString()),
                                descricao = drLer["descricao"].ToString()
                            });
                        }
                    }
                    return _Marca;
                    execComandos.Desconectar();
                }
                else return null;
            }
            else return null;
        }

        /// <summary>
        /// Função para verificar se existe a marca
        /// </summary>
        /// <param name="sNome">Nome da Marca</param>
        /// <returns>Verdadeiro ou falso se existe</returns>
        public bool seExisteMarca(string sNome)
        {
            bool bResposta = false;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    bResposta = execComandos.existeMarca(sNome);
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Pesquisar último código de Marca
        /// </summary>
        /// <returns>Retorna inteiro contendo o último código da tabela Marca2</returns>
        public int ultimoCodigoMarca()
        {
            int iResposta = 0;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    iResposta = execComandos.ultimoCodigoMarca();
                    execComandos.Desconectar();
                }
            }
            return iResposta;
        }

        /// <summary>
        /// Função para excluir marca
        /// </summary>
        /// <param name="iCodigoMarca">Código da Marca para exclusão</param>
        /// <param name="sMotivo">Motivo para exclusão</param>
        /// <param name="sTela">Tela de exclusão</param>
        /// <param name="iCodUsuario">Código do usuário</param>
        /// <returns></returns>
        public bool excluirMarca(int iCodigoMarca, string sMotivo, string sTela, int iCodUsuario)
        {
            bool bResposta = false;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    bResposta = execComandos.excluirMarca(iCodigoMarca);
                    if (bResposta) execComandos.inserirAuditoria(17, iCodUsuario, "Exclusão de Marca Cod.: " + iCodigoMarca.ToString() + "; Motivo: " + sMotivo, sTela);
                }
            }
            return bResposta;
        }

        //----------------------------------------------------
        /// <summary>
        /// Função para gravar dados de opicionais
        /// </summary>
        /// <param name="cOpicionais">Objeto Opicionais</param>
        /// <param name="bTipo">Tipo de gravação 0 - Inserir, 1 - Atualizar </param>
        /// <returns>Retorna verdadeiro ou falso dependendo do retorno da função</returns>
        public bool gravarOpicionais(opicionais cOpicionais, byte bTipo)
        {
            bool bResposta = false;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    if (bTipo == 0)
                        cOpicionais.codigo = execComandos.ultimoCodigoOpicionais() + 1;
                    bResposta = execComandos.inserirAtualizarOpicionais(cOpicionais, bTipo);
                    execComandos.Desconectar();
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para buscar dados de Opicionais
        /// </summary>
        /// <param name="iCodigo">Código da opicionais</param>
        /// <returns>Retorna o objeto opicionais</returns>
        public opicionais pesquisarOpicionais(int iCodigo)
        {
            opicionais cOpicionais = new opicionais();
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    cOpicionais = execComandos.pesquisaOpicionais(iCodigo);
                    return cOpicionais;
                }
                else return null;
                execComandos.Desconectar();
            }
            else return null;
        }

        /// <summary>
        /// Função para excluir opcional
        /// </summary>
        /// <param name="iCodigoOpcional">Código para exclusão</param>
        /// <param name="sMotivo">Motivo para exclusão</param>
        /// <param name="sTela">Tela de origem</param>
        /// <param name="iCodUsuario">Usuário de exclusão</param>
        /// <returns>Verdadeiro ou falso, mediante a execução da função</returns>
        public bool excluirOpcional(int iCodigoOpcional, string sMotivo, string sTela, int iCodUsuario)
        {
            bool bResposta = false;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    bResposta = execComandos.excluirOpcional(iCodigoOpcional);
                    if (bResposta) execComandos.inserirAuditoria(18, iCodUsuario, "Exclusão de Opcional Cod.: " + iCodigoOpcional.ToString() + "; Motivo: " + sMotivo, sTela);
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para pesquisar todas as opicionais
        /// </summary>
        /// <returns>Lista de objeto opicionais</returns>
        public List<opicionais> pesquisarTodosOpicionais()
        {
            SqlDataReader drLer;
            List<opicionais> _Opicionais = new List<opicionais>();
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    drLer = execComandos.pesquisarTodosOpicionais();
                    if (drLer.HasRows)
                    {
                        while (drLer.Read())
                        {
                            _Opicionais.Add(new opicionais()
                            {
                                codigo = int.Parse(drLer["codigo"].ToString()),
                                descricao = drLer["descricao"].ToString()
                            });
                        }
                    }
                    return _Opicionais;
                    execComandos.Desconectar();
                }
                else return null;
            }
            else return null;
        }

        /// <summary>
        /// Pesquisar todos os opcionais de um determinado carro
        /// </summary>
        /// <param name="iCodCarro">Código do carro para pesquisa</param>
        /// <returns>Retorna lista de opcionais</returns>
        public List<opicionais> pesquisarTodosOpicionaisCarro(int iCodCarro)
        {
            SqlDataReader drLer;
            List<opicionais> _Opicionais = new List<opicionais>();
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    drLer = execComandos.pesquisarTodosOpicionaisCarro(iCodCarro);
                    if (drLer.HasRows)
                    {
                        while (drLer.Read())
                        {
                            _Opicionais.Add(new opicionais()
                            {
                                codigo = int.Parse(drLer["codigo"].ToString()),
                                descricao = drLer["descricao"].ToString()
                            });
                        }
                    }
                    return _Opicionais;
                    execComandos.Desconectar();
                }
                else return null;
            }
            else return null;
        }

        /// <summary>
        /// Pesquisar todos os opcionais que não estão no cadastro de um determinado carro
        /// </summary>
        /// <param name="iCodCarro">Código do carro para pesquisa</param>
        /// <returns>Retorna lista de opcionais</returns>
        public List<opicionais> pesquisarTodosOpicionaisNCarro(int iCodCarro)
        {
            SqlDataReader drLer;
            List<opicionais> _Opicionais = new List<opicionais>();
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    drLer = execComandos.pesquisarTodosOpicionaisNCarro(iCodCarro);
                    if (drLer.HasRows)
                    {
                        while (drLer.Read())
                        {
                            _Opicionais.Add(new opicionais()
                            {
                                codigo = int.Parse(drLer["codigo"].ToString()),
                                descricao = drLer["descricao"].ToString()
                            });
                        }
                    }
                    return _Opicionais;
                    execComandos.Desconectar();
                }
                else return null;
            }
            else return null;
        }

        /// <summary>
        /// Função para verificar se existe a opicionais
        /// </summary>
        /// <param name="sNome">Nome da opicionais</param>
        /// <returns>Verdadeiro ou falso se existe</returns>
        public bool seExisteOpicinais(string sNome)
        {
            bool bResposta = false;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    bResposta = execComandos.existeOpicional(sNome);
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para verificar o último código de opicionas
        /// </summary>
        /// <returns>Retorna inteiro contendo o último código da tabela de Opicionais</returns>
        public int ultimoCodigoOpicionais()
        {
            int iResposta = 0;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    iResposta = execComandos.ultimoCodigoOpicionais();
                    execComandos.Desconectar();
                }
            }
            return iResposta;
        }

        //----------------------------------------------------
        /// <summary>
        /// Função para gravar dados de modelo
        /// </summary>
        /// <param name="cModelo">Objeto Modelo</param>
        /// <param name="bTipo">Tipo de gravação 0 - Inserir, 1 - Atualizar </param>
        /// <returns>Retorna verdadeiro ou falso dependendo do retorno da função</returns>
        public bool gravarModelo(modelo cModelo, byte bTipo)
        {
            bool bResposta = false;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    bResposta = execComandos.inserirAtualizarModelo(cModelo, bTipo);
                    execComandos.Desconectar();
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para buscar dados de Modelo
        /// </summary>
        /// <param name="iCodigo">Código do modelo</param>
        /// <returns>Retorna o objeto modelo</returns>
        public modelo pesquisarModelo(int iCodigo)
        {
            modelo cModelo = new modelo();
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    cModelo = execComandos.pesquisaModelo(iCodigo);
                    return cModelo;
                }
                else return null;
                execComandos.Desconectar();
            }
            else return null;
        }

        /// <summary>
        /// Função para pesquisar todos os modelos
        /// </summary>
        /// <returns>Lista de objeto modelos</returns>
        public List<modelo> pesquisarTodosModelos()
        {
            SqlDataReader drLer;
            List<modelo> _Modelo = new List<modelo>();
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    drLer = execComandos.pesquisarTodosModelos();
                    if (drLer.HasRows)
                    {
                        while (drLer.Read())
                        {
                            _Modelo.Add(new modelo()
                            {
                                codigo = int.Parse(drLer["codigo"].ToString()),
                                codmarca = int.Parse(drLer["codmarca"].ToString()),
                                Modelo = drLer["modelo"].ToString(),
                                portas = int.Parse(drLer["portas"].ToString()),
                                motor = int.Parse(drLer["motor"].ToString())
                            });
                        }
                    }
                    return _Modelo;
                    execComandos.Desconectar();
                }
                else return null;
            }
            else return null;
        }

        /// <summary>
        /// Função para exluir uma despesa
        /// </summary>
        /// <param name="iCodigoDespesa">Código da despesa para exlusão</param>
        /// <param name="vTela">Tela de origem para registro em auditoria</param>
        /// <param name="iCodigoUsuario">Código do usuário da exclusão</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool excluirDespesa(int iCodigoDespesa, string sTela, int iCodigoUsuario, string sMotivo)
        {
            bool bResposta = false;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    bResposta = execComandos.excluirDespesa(iCodigoDespesa);
                    if(bResposta)
                        execComandos.inserirAuditoria(5, iCodigoUsuario, "Exclusão de despesa: " + sMotivo.Trim(), sTela);
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para verificar se existe o modelo
        /// </summary>
        /// <param name="sNome">Nome da modelo</param>
        /// <returns>Verdadeiro ou falso se existe</returns>
        public bool seExisteModelo(string sNome)
        {
            bool bResposta = false;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    bResposta = execComandos.existeModelo(sNome);
                }
            }
            return bResposta;
        }

        //------------------------------------------------
        /// <summary>
        /// Função para gravar dados de despesas
        /// </summary>
        /// <param name="cDespesas">Objeto Despesas</param>
        /// <param name="iCodigoCarro">Código do carro a ser inserido a despesa</param>
        /// <param name="bTipo">Tipo de gravação 0 - Inserir, 1 - Atualizar </param>
        /// <returns>Retorna verdadeiro ou falso dependendo do retorno da função</returns>
        public bool gravarDespesas(despesas cDespesas, int iCodigoCarro, byte bTipo)
        {
            bool bResposta = false;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    bResposta = execComandos.inserirAtualizarDespesas(cDespesas,iCodigoCarro, bTipo);
                    execComandos.Desconectar();
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para buscar dados de despesas
        /// </summary>
        /// <param name="iCodigo">Código do despesas</param>
        /// <returns>Retorna o objeto despesas</returns>
        public despesas pesquisarDespesas(int iCodigo)
        {
            despesas cDespesas = new despesas();
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    cDespesas = execComandos.pesquisaDespesas(iCodigo);
                    return cDespesas;
                }
                else return null;
                execComandos.Desconectar();
            }
            else return null;
        }

        /// <summary>
        /// Função para pesquisar todas as despesas
        /// </summary>
        /// <returns>Lista de objeto despesas</returns>
        public List<despesas> pesquisarTodosDespesas()
        {
            SqlDataReader drLer;
            List<despesas> _Despesas = new List<despesas>();
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    drLer = execComandos.pesquisarTodasDespesas();
                    if (drLer.HasRows)
                    {
                        while (drLer.Read())
                        {
                            _Despesas.Add(new despesas()
                            {
                                codigo = int.Parse(drLer["codigo"].ToString()),
                                Descrição = drLer["Descrição"].ToString(),
                                Num_nota = int.Parse(drLer["Num_nota"].ToString()),
                                Data = DateTime.Parse(drLer["Data"].ToString()),
                                Valor = double.Parse(drLer["Valor"].ToString()),
                                Observacao = drLer["Observacao"].ToString()
                            });
                        }
                    }
                    return _Despesas;
                    execComandos.Desconectar();
                }
                else return null;
            }
            else return null;
        }

        /// <summary>
        /// Função para verificar se existe a despesa
        /// </summary>
        /// <param name="sNome">Nome da Despesa</param>
        /// <returns>Verdadeiro ou falso se existe</returns>
        public bool seExisteDespesas(string sNome)
        {
            bool bResposta = false;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    bResposta = execComandos.existeDespesa(sNome);
                }
            }
            return bResposta;
        }

        //------------------------------------------------
        /// <summary>
        /// Função para gravar dados de movimento
        /// </summary>
        /// <param name="cMovimento">Objeto Movimento</param>
        /// <param name="bTipo">Tipo de gravação 0 - Inserir, 1 - Atualizar </param>
        /// <returns>Retorna verdadeiro ou falso dependendo do retorno da função</returns>
        public bool gravarMovimento(movimento cMovimento, byte bTipo)
        {
            bool bResposta = false;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    bResposta = execComandos.inserirAtualizarMovimento(cMovimento, bTipo);
                    execComandos.Desconectar();
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para buscar dados de Movimento
        /// </summary>
        /// <param name="iCodigo">Código do movimento</param>
        /// <returns>Retorna o objeto Movimento</returns>
        public movimento pesquisarMovimento(int iCodigo)
        {
            movimento cMovimento = new movimento();
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    cMovimento = execComandos.pesquisaMovimento(iCodigo);
                    return cMovimento;
                }
                else return null;
                execComandos.Desconectar();
            }
            else return null;
        }

        /// <summary>
        /// Função para pesquisar todas os movimentos por carro
        /// </summary>
        /// <returns>Lista de objeto despesas</returns>
        public List<movimento> pesquisarTodosMovimentosCarro(int iCodCarro)
        {
            SqlDataReader drLer;
            List<movimento> _Movimento = new List<movimento>();
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    drLer = execComandos.pesquisarTodosMovimentosPorCarro(iCodCarro);
                    if (drLer.HasRows)
                    {
                        while (drLer.Read())
                        {
                            _Movimento.Add(new movimento()
                            {
                                codigo = int.Parse(drLer["codigo"].ToString()),
                                codcarro = int.Parse(drLer["codcarro"].ToString()),
                                codcliente = int.Parse(drLer["codcliente"].ToString()),
                                datamoviment = DateTime.Parse(drLer["datamoviment"].ToString()),
                                codvendedor = int.Parse(drLer["codvendedor"].ToString()),
                                valor = double.Parse(drLer["valor"].ToString()),
                                tipocomissao = double.Parse(drLer["tipocomissao"].ToString()),
                                valorcomissao = drLer["valorcomissao"].ToString(),
                                lucroliquido = double.Parse(drLer["lucroliquido"].ToString()),
                                dut = drLer["dut"].ToString(),
                                recibo = drLer["recibo"].ToString(),
                                TipoComissao2 = drLer["TipoComissao2"].ToString(),
                                valorcomissao2 = double.Parse(drLer["valorcomissao2"].ToString())
                            });
                        }
                    }
                    return _Movimento;
                    execComandos.Desconectar();
                }
                else return null;
            }
            else return null;
        }

        /// <summary>
        /// Função para pesquisar todas os movimentos por cliente
        /// </summary>
        /// <returns>Lista de objeto despesas</returns>
        public List<movimento> pesquisarTodosMovimentosCliente(int iCodCliente)
        {
            SqlDataReader drLer;
            List<movimento> _Movimento = new List<movimento>();
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    drLer = execComandos.pesquisarTodosMovimentosPorCliente(iCodCliente);
                    if (drLer.HasRows)
                    {
                        while (drLer.Read())
                        {
                            _Movimento.Add(new movimento()
                            {
                                codigo = int.Parse(drLer["codigo"].ToString()),
                                codcarro = int.Parse(drLer["codcarro"].ToString()),
                                codcliente = int.Parse(drLer["codcliente"].ToString()),
                                datamoviment = DateTime.Parse(drLer["datamoviment"].ToString()),
                                codvendedor = int.Parse(drLer["codvendedor"].ToString()),
                                valor = double.Parse(drLer["valor"].ToString()),
                                tipocomissao = double.Parse(drLer["tipocomissao"].ToString()),
                                valorcomissao = drLer["valorcomissao"].ToString(),
                                lucroliquido = double.Parse(drLer["lucroliquido"].ToString()),
                                dut = drLer["dut"].ToString(),
                                recibo = drLer["recibo"].ToString(),
                                TipoComissao2 = drLer["TipoComissao2"].ToString(),
                                valorcomissao2 = double.Parse(drLer["valorcomissao2"].ToString())
                            });
                        }
                    }
                    return _Movimento;
                    execComandos.Desconectar();
                }
                else return null;
            }
            else return null;
        }
        
        /// <summary>
        /// Função para excluir o relacionamento de opcional com o carro
        /// </summary>
        /// <param name="iCodigo">Código do opcional</param>
        /// <param name="bTipo">Tipo 0 - Codigo opcional 1 - Codigo carro</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool excluirOpcionalCarro(int iCodigo, byte bTipo)
        {
            bool bResposta = false;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario,sSenha, iPortaAcesso))
                    bResposta = execComandos.excluirOpcionalCarro(iCodigo, bTipo);
            }
            return bResposta;
        }

        /// <summary>
        /// Função para gravar relacionamento de opcionais com o Carro
        /// </summary>
        /// <param name="lOpcional">Lista de objetos Opcional</param>
        /// <param name="cCarro">Objeto Carro</param>
        /// <returns>Retorna verdadeiro ou falso, mediante a execução da função</returns>
        public bool gravarOpcionalCarro(List<opicionais> lOpcional, carro cCarro)
        {
            bool bResposta = false;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    foreach (opicionais lstOpcionais in lOpcional)
                    {
                        bResposta = execComandos.gravarOpcionalCarro(lstOpcionais,cCarro);
                        if (!bResposta)
                            break;
                    }
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para pesquisar uma lista de despesas do Carro
        /// </summary>
        /// <param name="cCarro">Objeto carro para pesquisa</param>
        /// <returns>Retorna List para despesas</returns>
        public List<despesas> buscaDespesasCarro(carro cCarro)
        {
            List<despesas> lstDespesas=null;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    lstDespesas = execComandos.buscaDespesasCarro(cCarro);
                }
            }
            return lstDespesas;
        }

        /// <summary>
        /// Função para inserir novo histórico
        /// </summary>
        /// <param name="cHistorico">Objeto histórico</param>
        /// <param name="bTipo">Tipo 0 inserir 1 atualizar</param>
        /// <param name="sTela">Tela que inseriu as informaçãos</param>
        /// <param name="iCodigoUsuario">Código do usuário logado</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool inserirAtualizarHistorico(historico cHistorico, byte bTipo, string sTela, int iCodigoUsuario)
        {
            bool bResposta = false;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    bResposta = execComandos.inserirAtualizarHistorico(cHistorico, bTipo);
                    if (bResposta)
                        execComandos.inserirAuditoria(4, iCodigoUsuario, "Novo histórico: " + cHistorico.observacao, sTela);
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para consultar um histórico específico
        /// </summary>
        /// <param name="iCodHistorico">Código do histório para consulta</param>
        /// <returns>Retorna objeto histórico</returns>
        public List<historico> consultarHistorico(int iCodHistorico)
        {
            List<historico> lstHistorico = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    lstHistorico = execComandos.consultarHistorico(iCodHistorico, 0);
                }
            }
            return lstHistorico;
        }

        /// <summary>
        /// Função para pesquisar histórico de carro específico
        /// </summary>
        /// <param name="iCodCarro">Código do carro a ser pesquisado</param>
        /// <returns>Retorna uma lista do objeto historico para exibição</returns>
        public List<historico> consultarHistoricoCarro(int iCodCarro)
        {
            List<historico> lstHistorico = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    lstHistorico = execComandos.consultarHistorico(iCodCarro,1);
                }
            }
            return lstHistorico;
        }

        /// <summary>
        /// Função para pesquisar o histórico de um usuário específico
        /// </summary>
        /// <param name="iCodUsuario">Código do usuário</param>
        /// <returns>Retorna uma lista do objeto historico</returns>
        public List<historico> consultarHistoricoUsuario(int iCodUsuario)
        {
            List<historico> lstHistorico = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    lstHistorico = execComandos.consultarHistorico(iCodUsuario, 2);
                }
            }
            return lstHistorico;
        }

        /// <summary>
        /// Função para excluir um determinado histórico
        /// </summary>
        /// <param name="iCodHistorico">Código de histórico para deleção</param>
        /// <param name="iCodUsuario">Código do usuário para exclusão</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool excluirHistorico(int iCodHistorico, int iCodUsuario, string sMotivo,string sTela)
        {
            bool bResposta = false;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    bResposta = execComandos.excluirHistorico(iCodHistorico);
                    if (bResposta) execComandos.inserirAuditoria(1, iCodUsuario, "Exclusão histórico: " + sMotivo, sTela);
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para inserir nova observação em veículo
        /// </summary>
        /// <param name="cObservacao">Objeto observação para gravação</param>
        /// <param name="sTela">Tela de cadastro</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool inserirObservacaoCarro(observacao cObservacao, string sTela)
        {
            bool bResposta = false;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    bResposta = execComandos.inserirObservacao(cObservacao);
                    if (bResposta) execComandos.inserirAuditoria(2, cObservacao.cod_usuario, "Nova observação para o veículo cód. " + cObservacao.codigo.ToString(), sTela);
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para inserir nova observação em Venda
        /// </summary>
        /// <param name="cObservacao">Objeto venda</param>
        /// <param name="sTela">Tela de origem para cadastro de auditoria</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool inserirObservacaoVenda(observacao cObservacao, string sTela)
        {
            bool bResposta = false;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    bResposta = execComandos.inserirObservacao(cObservacao);
                    if (bResposta) execComandos.inserirAuditoria(2, cObservacao.cod_usuario, "Nova observação para a venda cód. " + cObservacao.codigo.ToString(), sTela);
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para excluir observação de carro
        /// </summary>
        /// <param name="iCodigoObservacao">Código da observação para exclusão</param>
        /// <param name="iCodigoUsuario">Código do usuário para registro</param>
        /// <param name="sTela">Tela de exclusão</param>
        /// <param name="sMotivo">Motivo para exclusão</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool excluirObservacaoCarro(int iCodigoObservacao, int iCodigoUsuario, string sTela, string sMotivo)
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
        /// Função para buscar observações do veículo
        /// </summary>
        /// <param name="iCodigoCarro">Código do carro a ser pesquisado</param>
        /// <returns>Retorna uma lista de objetos de Observação do veículo</returns>
        public List<observacao> buscarObservacaoCarro(int iCodigoCarro)
        {
            List<observacao> lstObservacao = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    lstObservacao = execComandos.buscaObservacao(0, iCodigoCarro);
                }
            }
            return lstObservacao;
        }

        /// <summary>
        /// Função para retornar uma lista contendo as observações de uma venda
        /// </summary>
        /// <param name="iCodVenda">Código da venda</param>
        /// <returns></returns>
        public List<observacao> buscarObservacaoVenda(int iCodVenda)
        {
            List<observacao> lstObservacao = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    lstObservacao = execComandos.buscaObservacao(2, iCodVenda);
                }
            }
            return lstObservacao;
        }

        /// <summary>
        /// Função para retornar dados do usuário
        /// </summary>
        /// <param name="iCodigoUsuario">Código do usuário para a pesquisa</param>
        /// <returns>Retorna o objeto Usuario contendo dados</returns>
        public usuario buscaDadosUsuario(int iCodigoUsuario)
        {
            usuario cUsuario = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    cUsuario = execComandos.buscaDadosUsuario(iCodigoUsuario);
                }
            }
            return cUsuario;
        }

        /// <summary>
        /// Função para pesquisar o valor das despesas de um determinado carro
        /// </summary>
        /// <param name="iCodigoCarro">Código do carro para  pesquisa</param>
        /// <returns>Retorna o valor das despesas do carro</returns>
        public double pesquisaValorDespesaCarro(int iCodigoCarro)
        {
            double dResposta = 0;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    dResposta = execComandos.pesquisaDespesaValorCarro(iCodigoCarro);
                }
            }
            return dResposta;
        }

        /// <summary>
        /// Função para gravar dados de vendedor
        /// </summary>
        /// <param name="cVendedor">Objeto Vendedor</param>
        /// <param name="bTipo">Tipo 0 - Inserir; 1 - Atualizar</param>
        /// <returns>Retorna E/T ou código do último vendedor cadastrado (T - Atualização executada | E - Erro ao executar)</returns>
        public string inserirAtualizarVendedor(vendedor cVendedor, byte bTipo)
        {
            string sResposta = "";
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    sResposta = execComandos.inserirAtualizarVendedor(cVendedor, bTipo);
                }
            }
            return sResposta;
        }

        /// <summary>
        /// Função para retornar uma lista de vendedores mediante uma venda específico
        /// </summary>
        /// <param name="cVenda">Objeto venda</param>
        /// <returns>Retorna uma lista do objeto Vendedor</returns>
        public List<vendedor> pesquisarVendedorVenda(vendas cVenda)
        {
            List<vendedor> lstVendedor = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    lstVendedor = execComandos.pesquisarVendedorVenda(cVenda);
                }
            }
            return lstVendedor;
        }

        /// <summary>
        /// Função para pesquisar todas as vendas de um vendedor
        /// </summary>
        /// <param name="cVendedor">Objeto vendedor</param>
        /// <returns>Retorna uma lista de vendas.</returns>
        public List<vendas> pesquisarTodasVendasVendedor(vendedor cVendedor)
        {
            List<vendas> lstVendas = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    lstVendas = execComandos.pesquisarTodasVendasVendedor(cVendedor);
                }
            }

            return lstVendas;
        }

        /// <summary>
        /// Função para pesquisar todos vendedores
        /// </summary>        
        /// <param name="sSituacao">Situacao A - Ativo, E - Excluido, I - Inativo, X - Todos</param>
        /// <returns>Retorna a lista de Vendedores</returns>
        public List<vendedor> pesquisarTodosVendedores(string sSituacao)
        {
            List<vendedor> lstVendedor = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    lstVendedor = execComandos.pesquisarTodosVendedores(sSituacao);
                }
            }
            return lstVendedor;
        }

        /// <summary>
        /// Função para verificar se um determinado vendedor existe
        /// </summary>
        /// <param name="sNome">Nome do vendedor para pesquisa</param>
        /// <returns>Retorna verdeiro ou falso se a vendedor existe</returns>
        public bool seExisteVendedor(string sNome)
        {
            bool bResposta = false;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    bResposta = execComandos.existeVendedor(sNome);
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para pesquisar todos os telefones do vendedor
        /// </summary>
        /// <param name="cVendedor">Objeto vendedor</param>
        /// <returns>Retorna lista de telefones de vendedor</returns>
        public List<Telefones> pesquisarTodosTelefonesVendedor(vendedor cVendedor)
        {
            List<Telefones> lstTelefone = null;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    lstTelefone = execComandos.pesquisarTodosTelefonesVendedor(cVendedor);
                }
            }
            return lstTelefone;
        }

        /// <summary>
        /// Função para pesquisar os dados de um vendedor
        /// </summary>
        /// <param name="iCodigoVendedor">Código do vendedor</param>
        /// <returns>Retorna o objeto vendedor</returns>
        public vendedor pesquisaVendedor(int iCodigoVendedor)
        {
            vendedor cVendedor=null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    cVendedor = execComandos.pesquisaVendedor(iCodigoVendedor);
                }
            }
            return cVendedor;
        }

        /// <summary>
        /// Função para inserir/atualizar dados de telefones do vendedor
        /// </summary>
        /// <param name="lTelefones">Objeto telefone</param>
        /// <param name="cVendedor">Objeto vendedor</param>
        /// <returns>Retonra verdadeiro ou falso mediante a execução da função</returns>
        public bool inserirAtualizarTelefoneVendedor(List<Telefones> lTelefones, vendedor cVendedor)
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
                        bResposta = execComandos.inserirAtualizarTelefoneVendedor(lstTelefones, cVendedor, btTipo);
                        if (!bResposta)
                            break;
                    }
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para excluir todos os telefones de vendedor
        /// </summary>
        /// <param name="cVendedor">Objeto Vendedor</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da operação</returns>
        public bool excluirTodosTelefoneVendedor(vendedor cVendedor)
        {
            bool bResposta = false;
            List<Telefones> lstTelefone = null;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    bResposta = execComandos.excluirTodosTelefoneVendedor(cVendedor.código);
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para retornar dados de uma venda
        /// </summary>
        /// <param name="iCodigoVenda">Código da venda</param>
        /// <returns>Retorna objeto vendas</returns>
        public vendas pesquisarVenda(int iCodigoVenda)
        {
            vendas cVenda = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    cVenda = execComandos.buscarVenda(iCodigoVenda);
                }
            }
            return cVenda;
        }

        /// <summary>
        /// Função para pesquisar todas as vendas por uma determinada situacao
        /// </summary>
        /// <param name="iSituacao">0 em aberto 1 concluída 2 cancelada 3 aguardando financiamento 4 suspensa 5 Todos</param>
        /// <returns>Retorna uma lista de vendas</returns>
        public List<vendas> pesquisarTodasVendas(int iSituacao)
        {
            List<vendas> lstVendas = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    lstVendas = execComandos.buscaTodasVendas(iSituacao);
                }
            }

            return lstVendas;
        }

        /// <summary>
        /// Função para inserir/atualizar cadastro de vendas
        /// </summary>
        /// <param name="cVendas">Objeto Vendas</param>
        /// <param name="bTipo">Tipo 0 Inserir 1 Atualizar</param>
        /// <returns>Retorna T- Atualizado E-Erro ou o código da nova venda</returns>
        public string inserirAtualizarVendas(vendas cVendas, byte bTipo)
        {
            string sResposta = "E";
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    sResposta = execComandos.inserirAtualizarVendas(cVendas, bTipo);
                }
            }
            return sResposta;
        }

        /// <summary>
        /// Função para excluir um cadastro de vendas
        /// </summary>
        /// <param name="iCodVendas">Código da venda para exclusão</param>
        /// <param name="iCodUsuario">Código do usuário da exclusão</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool excluirVendas(int iCodVendas, int iCodUsuario)
        {
            bool bResposta = false;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    bResposta = false;// execComandos.excluirVendas(iCodVendas, iCodUsuario);
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para retornar as comissões de uma venda
        /// </summary>
        /// <param name="iCodigoVenda">Código da venda</param>
        /// <returns>Retorna uma lista de comissões</returns>
        public List<vendas_vendedor> buscarComissaoVenda(int iCodigoVenda)
        {
            List<vendas_vendedor> lstComissao = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    lstComissao = execComandos.buscaComissaoVendas(iCodigoVenda);
                }
            }
            return lstComissao;
        }

        /// <summary>
        /// Função para inserir/atualizar comissão
        /// </summary>
        /// <param name="cVendasVendedor">Objeto vendas_vendedor</param>
        /// <param name="bTipo">Tipo 0 - inserir, 1 - atualizar</param>
        /// <returns></returns>
        public bool inserirAtualizarComissao(vendas_vendedor cVendasVendedor, byte bTipo)
        {
            bool bResposta = false;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    bResposta = execComandos.inserirAtualizarComissao(cVendasVendedor, bTipo);
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para buscar dados de comissão
        /// </summary>
        /// <param name="iCodVenda">Cod venda</param>
        /// <param name="iCodVendedor">Cod vendedor</param>
        /// <returns>Retorna objeto vendas_vendedor</returns>
        public vendas_vendedor buscaDadosVendasVendedor(int iCodVenda, int iCodVendedor)
        {
            vendas_vendedor cVendasVendedor = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    cVendasVendedor = execComandos.buscaVendasVendedor(iCodVenda,iCodVendedor);
                }
            }
            return cVendasVendedor;
        }

        /// <summary>
        /// Função para exluir dados de comissão
        /// </summary>
        /// <param name="iCodVenda">Cod venda</param>
        /// <param name="iCodVendedor">Cod vendedor</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool excluirComissao(int iCodVenda, int iCodVendedor, string sTela, string sMotivo, int iCodUsuario)
        {
            bool bResposta = false;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    bResposta = execComandos.excluirVendasVendedor(iCodVenda, iCodVendedor);
                    if (bResposta) execComandos.inserirAuditoria(6, iCodUsuario, "Exclusão de comissão da venda cod.: " + iCodVenda.ToString("D5") + "; Motivo: " + sMotivo, sTela);
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para limpar o cifrão do campo de moeda
        /// </summary>
        /// <param name="sTexto">Texto de entrada</param>
        /// <returns>Retorna o campo de moeda sem o Cifrão</returns>
        public string limparMoeda(string sTexto)
        {
            string sResposta = "";
            int iQte = sTexto.Length;
            int iIndice = 0;
            while (iIndice < iQte)
            {
                if (!sTexto.Substring(iIndice, 1).Equals("R") && !sTexto.Substring(iIndice, 1).Equals("$"))
                {
                    sResposta = sResposta + sTexto.Substring(iIndice, 1);
                }
                iIndice++;
            }
            return sResposta.Trim();
        }

        /// <summary>
        /// Função para lançar histórico e transferência de dados do veículo para os clientes
        /// </summary>
        /// <param name="cVenda">Objeto de venda</param>
        /// <param name="iCodUsuario">Código de usuário do processo</param>
        /// <param name="sTela">Tela utilizada</param>
        /// <returns>Retorna verdadeio ou falso mediante a execução da função</returns>
        public bool lancarHistoricoVenda(vendas cVenda, int iCodUsuario, string sTela)
        {
            bool bResposta = false;
            historico cHistorico;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    cHistorico = new historico();
                    DateTime dtAgora = DateTime.Now;
                    //lancar venda para cliente antigo
                    cHistorico.cod_carro = cVenda.cod_carro;
                    cHistorico.cod_historico = 0;
                    cHistorico.cod_usuario = iCodUsuario;
                    cHistorico.observacao = "Veículo cod. (" + cVenda.cod_carro.ToString("D5") + ") vendido - venda: #" + cVenda.cod_venda.ToString("D5") + "/" + cVenda.data_venda.Year;
                    cHistorico.tipo = 1;
                    cHistorico.data_hist = dtAgora;

                    if (execComandos.inserirAtualizarHistorico(cHistorico, 0))
                    {
                        execComandos.inserirAuditoria(4, iCodUsuario, "Novo histórico: " + cHistorico.observacao, sTela);

                        //excluir cliente antigo
                        if (execComandos.excluirVeiculoCliente(cVenda.cod_cliente_vendedor, cVenda.cod_carro))
                        {
                            execComandos.inserirAuditoria(9, iCodUsuario, "Venda de veículo e transferência de dados (" + cVenda.cod_venda.ToString("D5") + "/" + cVenda.data_venda.Year + ")", sTela);
                            //lancar compra para cliente novo
                            cHistorico = new historico();
                            cHistorico.cod_carro = cVenda.cod_carro;
                            cHistorico.cod_historico = 0;
                            cHistorico.cod_usuario = iCodUsuario;
                            cHistorico.observacao = "Veículo cod. (" + cVenda.cod_carro.ToString("D5") + ") comprado - venda: #" + cVenda.cod_venda.ToString("D5") + "/" + cVenda.data_venda.Year;
                            cHistorico.tipo = 0;
                            cHistorico.data_hist = dtAgora;

                            if (execComandos.inserirAtualizarHistorico(cHistorico, 0))
                            {
                                execComandos.inserirAuditoria(4, iCodUsuario, "Novo histórico: " + cHistorico.observacao, sTela);
                                //inserir cliente novo ao vínculo com o veiculo
                                if (execComandos.inserirVeiculoCliente(cVenda.cod_carro, cVenda.cod_cliente_comprador))
                                {
                                    execComandos.inserirAuditoria(8, iCodUsuario, "Compra de veículo e transferência de dados (" + cVenda.cod_venda.ToString("D5") + "/" + cVenda.data_venda.Year.ToString() + ")", sTela);
                                    bResposta = true;
                                }
                                
                            }
                        }
                    }
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para lançamento de histórico e transferencia de dados de um cancelamento de venda
        /// </summary>
        /// <param name="cVenda">Objeto Venda</param>
        /// <param name="iCodUsuario">Código do usuário da operação</param>
        /// <param name="sTela">Tela de lançamento</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool lancarHistoricoVendaCancelar(vendas cVenda, int iCodUsuario, string sTela)
        {
            bool bResposta = false;
            historico cHistorico;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    cHistorico = new historico();
                    DateTime dtAgora = DateTime.Now;
                    //lancar venda para cliente antigo
                    cHistorico.cod_carro = cVenda.cod_carro;
                    cHistorico.cod_historico = 0;
                    cHistorico.cod_usuario = iCodUsuario;
                    cHistorico.observacao = "Cancelamento de venda do Veículo cod. (" + cVenda.cod_carro.ToString("D5") + ") - venda: " + cVenda.cod_venda.ToString("D5") + "/" + cVenda.data_venda.Year.ToString();
                    cHistorico.tipo = 4;
                    cHistorico.data_hist = dtAgora;
                    
                    //excluir cliente novo do cadastro de clientecarro
                    if (execComandos.excluirVeiculoCliente(cVenda.cod_cliente_comprador, cVenda.cod_carro))
                    {
                        if (execComandos.inserirVeiculoCliente(cVenda.cod_carro, cVenda.cod_cliente_vendedor))
                        {
                            execComandos.inserirAuditoria(10, iCodUsuario, "Cancelamento de compra de veículo - Venda (" + cVenda.cod_venda.ToString("D5") + "/" + cVenda.data_venda.Year.ToString() + ")", sTela);
                            bResposta = true;
                        }
                    }
                    //inserir cliente antigo no cadastro de cleintecarro
                    //lançar histórico de texto para o cancelamento
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para buscar o código do cliente de um veículo
        /// </summary>
        /// <param name="iCodigoCarro">Código do veículo</param>
        /// <returns>Retorna o código do cliente</returns>
        public int buscaClienteCarro(int iCodigoCarro)
        {
            int iResposta = 0;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    iResposta = execComandos.buscaClienteCarro(iCodigoCarro);
                }
            }
            return iResposta;
        }

        /// <summary>
        /// Função para pesquisa para preenchinto de dados de veículos
        /// </summary>
        /// <param name="iTipo">Tipo 0 qte potas, 1 Qte lugares, 2 cor</param>
        /// <returns>Retorna uma lista do objeto retornoConsultaVeiculos</returns>
        public List<retornoConsultaVeiculos> retornoConsultaVeiculo(int iTipo)
        {
            List<retornoConsultaVeiculos> lstRetorno = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    lstRetorno = execComandos.retornoConsultaVeiculo(iTipo);
                }
            }
            return lstRetorno;
        }

        /// <summary>
        /// Função para prepara a tabela temporaria para impressão
        /// </summary>
        /// <param name="sQuery">Cláusula SQL para pesquisa</param>
        /// <param name="sFiltro">Filtro que foi pesquisado para exibição em relatório</param>
        /// <returns>Retorna verdadeirou ou falso mediante a execução da função</returns>
        public bool impr_VeiculosCadastrados(string sQuery, string sFiltro)
        {
            bool bResposta = false;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    if (execComandos.impr_VeiculosCadastrados(sQuery, sFiltro))
                    {
                        bResposta = execComandos.existeRegistroTemp();
                        if(!bResposta)
                            System.Windows.Forms.MessageBox.Show("Nenhum registro selecionado.", "EstacionamentoFacil (100C)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para retornar o relatório para impressão
        /// </summary>
        /// <returns></returns>
        public CrystalDecisions.Windows.Forms.CrystalReportViewer impr_VeiculosCadastrados()
        {
            CrystalDecisions.Windows.Forms.CrystalReportViewer relatorio = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    relatorio = execComandos.impr_VeiculosCadastrados();
                }
            }
            return relatorio;
        }

        public DataSet impr_VeiculosCadastrados(byte bTipo)
        {
            DataSet dataset = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    dataset = execComandos.impr_VeiculosCadastrados(bTipo);
                }
            }
            return dataset;
        }

        /// <summary>
        /// Função para preparar os dados para impressão de extrato de despesas
        /// </summary>
        /// <param name="sQuery">Cláusula para pesquisa</param>
        /// <param name="sFiltro">Filtro para exibição no relatório</param>
        /// <param name="cCarro">Objeto Carro</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool impr_ExtradoDespesas(string sQuery, string sFiltro, carro cCarro)
        {
            bool bResposta = false;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    if (execComandos.impr_ExtradoDespesas(sQuery, sFiltro, cCarro))
                    {
                        bResposta = execComandos.existeRegistroTemp();
                        if(!bResposta)
                            System.Windows.Forms.MessageBox.Show("Nenhum registro selecionado.", "EstacionamentoFacil (100B)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);                        
                    }                    
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para retornar o relatório para impressão
        /// </summary>
        /// <returns></returns>
        public CrystalDecisions.Windows.Forms.CrystalReportViewer impr_ExtradoDespesas()
        {
            CrystalDecisions.Windows.Forms.CrystalReportViewer relatorio = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    relatorio = execComandos.impr_ExtradoDespesas();
                }
            }
            return relatorio;
        }

        public DataSet impr_ExtradoDespesas(byte bTipo)
        {
            DataSet dataset = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    dataset = execComandos.impr_ExtradoDespesas(bTipo);
                }
            }
            return dataset;
        }

        /// <summary>
        /// Função para preparar os dados para impressão de extrato de despesas
        /// </summary>
        /// <param name="sQuery">Cláusula para pesquisa</param>
        /// <param name="sFiltro">Filtro para exibição no relatório</param>        
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool impr_TotalDespesas(string sQuery, string sFiltro)
        {
            bool bResposta = false;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    if (execComandos.impr_TotalDespesas(sQuery, sFiltro))
                    {
                        bResposta = execComandos.existeRegistroTemp();
                        if (!bResposta)
                            System.Windows.Forms.MessageBox.Show("Nenhum registro selecionado.", "EstacionamentoFacil (100A)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);                        
                    }
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para retornar o relatório para impressão
        /// </summary>
        /// <returns></returns>
        public CrystalDecisions.Windows.Forms.CrystalReportViewer impr_TotalDespesas()
        {
            CrystalDecisions.Windows.Forms.CrystalReportViewer relatorio = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    relatorio = execComandos.impr_TotalDespesas();
                }
            }
            return relatorio;
        }

        public DataSet impr_TotalDespesas(byte bTipo)
        {
            DataSet dataset = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    dataset = execComandos.impr_TotalDespesas(bTipo);
                }
            }
            return dataset;
        }

        /// <summary>
        /// Função para preparar os dados para impressão de vendas
        /// </summary>
        /// <param name="sQuery">Cláusula para pesquisa</param>
        /// <param name="sFiltro">Filtro para exibição no relatório</param>        
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool impr_Vendas(string sQuery, string sFiltro)
        {
            bool bResposta = false;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    if (execComandos.impr_Vendas(sQuery, sFiltro))
                    {
                        bResposta = execComandos.existeRegistroTemp();
                        if (!bResposta)
                            System.Windows.Forms.MessageBox.Show("Nenhum registro selecionado.", "EstacionamentoFacil (100E)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para retornar o relatório para impressão
        /// </summary>
        /// <returns></returns>
        public CrystalDecisions.Windows.Forms.CrystalReportViewer impr_Vendas()
        {
            CrystalDecisions.Windows.Forms.CrystalReportViewer relatorio = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    relatorio = execComandos.impr_Vendas();
                }
            }
            return relatorio;
        }

        public DataSet impr_Vendas(byte bTipo)
        {
            DataSet dataset = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    dataset = execComandos.impr_Vendas(bTipo);
                }
            }
            return dataset;
        }

        /// <summary>
        /// Função para preparar os dados para impressão de comissao
        /// </summary>
        /// <param name="sQuery">Cláusula para pesquisa</param>
        /// <param name="sFiltro">Filtro para exibição no relatório</param>        
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool impr_Comissao(string sQuery, string sFiltro)
        {
            bool bResposta = false;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    if (execComandos.impr_Comissao(sQuery, sFiltro))
                    {
                        bResposta = execComandos.existeRegistroTemp();
                        if (!bResposta)
                            System.Windows.Forms.MessageBox.Show("Nenhum registro selecionado.", "EstacionamentoFacil (100F)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para retornar o relatório para impressão
        /// </summary>
        /// <returns></returns>
        public CrystalDecisions.Windows.Forms.CrystalReportViewer impr_Comissao()
        {
            CrystalDecisions.Windows.Forms.CrystalReportViewer relatorio = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    relatorio = execComandos.impr_Comissao();
                }
            }
            return relatorio;
        }

        public DataSet impr_Comissao(byte bTipo)
        {
            DataSet dataset = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    dataset = execComandos.impr_Comissao(bTipo);
                }
            }
            return dataset;
        }

        /// <summary>
        /// Função para localizar dados de um veículo na tela de Localização.
        /// </summary>
        /// <param name="sSQL">Filtro para pesquisa</param>
        /// <returns>Retorna objeto Carro</returns>
        public List<carro> localizaDadosCarro(string sSQL)
        {
            List<carro> cCarro = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    cCarro = execComandos.localizaDadosCarro(sSQL);
                }
            }
            return cCarro;
        }

        /// <summary>
        /// Função para Listar todos os motores do cadastro
        /// </summary>
        /// <returns>Retorna uma lista de motores</returns>
        public List<Motor> localizarTodosMotores()
        {
            List<Motor> lstMotor = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    //lstMotor = execComandos.localizarTodosMotores();
                }
            }
            return lstMotor;
        }

        /// <summary>
        /// Função para retornar os dados de um motor
        /// </summary>
        /// <param name="iCodMotor">Código do motor em questão</param>
        /// <returns>Retorna o objeto Motor</returns>
        public Motor pesquisarMotor(int iCodMotor)
        {
            Motor cMotor = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    //cMotor = execComandos.pesquisarMotor(iCodMotor);
                }
            }
            return cMotor;
        }

    }
}
