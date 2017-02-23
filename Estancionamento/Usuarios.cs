using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Estancionamento
{
    public class usuario
    {
        public int cod_usuario;
        public string senha;
        /// <summary>
        /// Tipo 0 Administrador do sistema, 1 Vendedor, 2 Administracao
        /// </summary>
        public int tipo;
        public string dica_senha;
        /// <summary>
        /// login para acesso
        /// </summary>
        public string sUsuario;
        /// <summary>
        /// Nome do usuário
        /// </summary>
        public string nomeusuario;
        public string observacao;
        /// <summary>
        /// 0 Ativo, 1 Inativo, 2 Cancelado
        /// </summary>
        public int situacao;
    }

    public class nivelAcesso
    {
        public int codigo;
        public string nivelacesso;
    }

    public class auditoria
    {
        public int codigo;
        /// <summary>
        /// Chave presente na tabela auditoria_operacao
        /// </summary>
        public int operacao;
        public int cod_usuario;
        public DateTime data_operacao;
        public string descritivo;
        public string tela;
    }

    public class auditoria_operacao
    {
        public int operacao;
        public string descricao;
    }

    public class empresa
    {
        public int cod_empresa;
        public string nome_empresa;
        public string nome_fantasia;
        public string telefone01;
        public string telefone02;
        public string email;
        public string cnpj;
        public string proprietario;
        public int cod_logradouro;
        public int numero;
        public string licenca;
        public int tipo_relatorio;
    }

    class Usuarios
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
        /// Função para inserir/atualizar dados de usuários
        /// </summary>
        /// <param name="cUsuario">Objeto usuario</param>
        /// <param name="bTipo">Tipo 0 Inserir 1 Atualizar</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool inserirAtualizarUsuario(usuario cUsuario, byte bTipo)
        {
            bool bResposta= false;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    bResposta = execComandos.inserirAtualizarUsuario(cUsuario, bTipo);
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para alterar a senha do usuário
        /// </summary>
        /// <param name="cUsuario">Objeto usuario</param>
        /// <param name="sNovaSenha"></param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool alterarSenhaUsuario(usuario cUsuario, string sNovaSenha, string sNovaDica, int iCodigoUsuario, string sTela)
        {
            bool bResposta = false;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    bResposta = execComandos.alterarSenhaUsuario(cUsuario, sNovaSenha, sNovaDica);
                    if (bResposta) execComandos.inserirAuditoria(11, iCodigoUsuario, "Alteração de senha", sTela);
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para pesquisar dados de um usuário
        /// </summary>
        /// <param name="iCodigoUsuario">Código do usuário</param>
        /// <returns>Retorna objeto usuario</returns>
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
        /// Função para retornar uma lista de todos os usuários
        /// </summary>
        /// <param name="iTipo">Tipo 0 - Ativos 1 - Inativos 2 - Cancelados 5 - TODOS</param>
        /// <returns></returns>
        public List<usuario> buscaTodosUsuario(int iTipo)
        {
            List<usuario> lstUsuario = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    lstUsuario = execComandos.buscaTodosUsuario(iTipo);
                }
            }
            return lstUsuario;
        }

        /// <summary>
        /// Função para retornar todos os níveis de acesso
        /// </summary>
        /// <returns>Retorna uma lista de objetos Nivel Acesso</returns>
        public List<nivelAcesso> buscaNivelAcesso()
        {
            List<nivelAcesso> lstNivelAcesso = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    lstNivelAcesso = execComandos.buscaNivelAcesso();
                }
            }
            return lstNivelAcesso;
        }

        /// <summary>
        /// Função para retornar o nível de acesso mediante código
        /// </summary>
        /// <param name="iCodNivelAcesso">Código do nível de acesso</param>
        /// <returns>Retorna objeto nível de acesso</returns>
        public nivelAcesso buscaNivelAcesso(int iCodNivelAcesso)
        {
            nivelAcesso cNivelAcesso = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    cNivelAcesso = execComandos.buscaNivelAcessoS(iCodNivelAcesso);
                }
            }
            return cNivelAcesso;
        }

        /// <summary>
        /// Função para pesquisar as listagem de auditorias
        /// </summary>
        /// <param name="sQuery">Cláusula para pesquisa</param>
        /// <returns>Retorna uma lista de auditorias</returns>
        public List<auditoria> buscaAuditorias(string sQuery)
        {
            List<auditoria> lstAuditoria = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    lstAuditoria = execComandos.buscaAuditorias(sQuery);
                }
            }
            return lstAuditoria;
        }

        /// <summary>
        /// Função para criar temporária para impressão de tela
        /// </summary>
        /// <param name="sQuery">Cláusula de pesquisa</param>
        /// <param name="sFiltro">variavel contendo os filtros</param>
        /// <returns>Retorna verdeiro ou falso mediante a execução da função</returns>
        public bool buscaAuditorias(string sQuery, string sFiltro)
        {
            bool bResposta = false;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    bResposta = execComandos.buscaAuditorias(sQuery,sFiltro);
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para retornar uma lista de operações de auditoria
        /// </summary>
        /// <returns>Lista de objeto auditoria_operacao</returns>
        public List<auditoria_operacao> buscaOperacaoAuditoria()
        {
            List<auditoria_operacao> lstAuditoria = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    lstAuditoria = execComandos.buscaOperacaoAuditoria();
                }
            }
            return lstAuditoria;
        }

        /// <summary>
        /// Função para buscar a operação de uma auditoria
        /// </summary>
        /// <param name="iCodigoOperacao">Código da operação</param>
        /// <returns>Retorna o objeto auditoria_operacao</returns>
        public auditoria_operacao buscaOperacaoAuditoria(int iCodigoOperacao)
        {
            auditoria_operacao obOperacao = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    obOperacao = execComandos.buscaOperacaoAuditoria(iCodigoOperacao);
                }
            }
            return obOperacao;
        }

        /// <summary>
        /// Função para buscar os dados de empresa
        /// </summary>
        /// <returns>Retorna o objeto empresa</returns>
        public empresa buscaDadosEmpresa()
        {
            empresa obEmpresa = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    obEmpresa = execComandos.buscaDadosEmpresa();
                }
            }
            return obEmpresa;
        }

        /// <summary>
        /// Função para gravar os dados da empresa
        /// </summary>
        /// <param name="cEmpresa">Objeto empresa</param>
        /// <returns>Retorna verdeirou ou falso mediante a execução da função</returns>
        public bool gravarDadosEmpresa(empresa cEmpresa)
        {
            bool bResposta = false;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    bResposta = execComandos.gravarDadosEmpresa(cEmpresa);
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Função para gerar o relatório de impressão
        /// </summary>
        /// <returns>Retorna CrystalReportViewer</returns>
        public CrystalDecisions.Windows.Forms.CrystalReportViewer imprimirAuditoria()
        {
            CrystalDecisions.Windows.Forms.CrystalReportViewer relatorio = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    relatorio = execComandos.imprimirAuditoria();
                }
            }
            return relatorio;
        }

        /// <summary>
        /// Função para gerar o relatório de impressão
        /// </summary>
        /// <returns>Retorna verdadeiro ou falso, mediante a execução</returns>
        public SqlConnection imprimirAuditoriaW()
        {
            SqlConnection relatorio = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    relatorio = execComandos.conexaoPrincipal;
                }
            }
            return relatorio;
        }

        public DataSet imprimirAuditoriaW(byte bTipo)
        {
            DataSet dsResposta = null;            
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    dsResposta = execComandos.imprimirAuditoriaW();
                }
            }
            return dsResposta;
        }
    }
}
