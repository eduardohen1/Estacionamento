using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using Security;

namespace Estancionamento
{
    public partial class FrmPrincipal : Form
    {
        //variaveis de controle de conexao:
        private string vEnderecoConfig = Application.StartupPath.ToString() + "\\conexao.xml";
        private string vEnderecoConexao;
        private bool vLogado;
        private string vNomeUsuario;
        private int vNivelAcesso;
        private int iCodigoUsuario;
        private empresa ccEmpresa;

        //variaveis de tela
        private FrmLogin vTela_FrmLogin;
        private FrmSuportes vTela_FrmSuportes;
        private FrmSuporte01 vTela_FrmSuporte01;
        private FrmSenhaAcesso vTela_FrmSenhaAcesso;
        private FrmCadMunicipio vTela_FrmCadMunicipio;
        private FrmCadLocalidade vTela_FrmCadLocalidade;
        private FrmCadBairro vTela_FrmCadBairro;
        private FrmCadLogradouro vTela_FrmCadLogradouro;
        private FrmCadOperadora vTela_FrmCadOperadora;
        public FrmCadCliente vTela_FrmCadCliente;
        public FrmNovoTelefone vTela_FrmNovoTelefone;
        public FrmNovoCarroCliente vTela_FrmNovoCarroCliente;
        public FrmCadMarca vTela_FrmCadMarca;
        public FrmCadOpcionais vTela_FrmCadOpcionais;
        public FrmCadCarro_Opcional vTela_FrmCadCarro_Opcional;
        public FrmCadHistorico vTela_FrmCadHistorico;
        public FrmCadDespesa vTela_FrmCadDespesa;
        public FrmCadObservacao vTela_FrmCadObservacao;
        public FrmCadCarro vTela_FrmCadCarro;
        public FrmCadVendedor vTela_FrmCadVendedor;
        public FrmCadVenda vTela_FrmCadVenda;
        public FrmCadComissao vTela_FrmCadComissao;
        private FrmAlterarSenha vTela_FrmAlterarSenha;
        private FrmCadUsuario vTela_FrmCadUsuario;
        private FrmAuditoria vTela_FrmAuditoria;
        private FrmCadEmpresa vTela_FrmCadEmpresa;        
        private FrmTeste vTelaTeste;
        public FrmLocalizarVeiculo vTela_FrmLocalizarVeiculo;
        public FrmLocalizarCliente vTela_FrmLocalizarCliente;
        public FrmContaCartaoCliente vTela_FrmContaCartaoCliente;

        private Relatórios.FrmImpressao_Auditoria vTela_FrmImpressao_Auditoria;
        private Relatórios.FrmImpressao_Auditoria_W vTela_FrmImpressao_AuditoriaW;
        private Relatórios.FrmPesq_ClientesCadastrados vTela_FrmPesq_ClientesCadastrados;
        private Relatórios.FrmPesq_VeiculosCadastradoscs vTela_FrmPesq_VeiculosCadastrados;
        private Relatórios.FrmPesq_ExtratoDespesas vTela_FrmPesq_ExtratoDespesas;
        private Relatórios.FrmPesq_TotalDespesas vTela_FrmPesq_TotalDesppesas;
        private Relatórios.FrmPesq_Vendas vTela_FrmPesq_Vendas;
        private Relatórios.FrmPesq_Comissao vTela_FrmPesq_Comissao;
        private Relatórios.FrmImpressao_ClientesCadastrados vTela_FrmImpressao_ClientesCadastrados;
        private Relatórios.FrmImpressao_ClientesCadastrados_W vTela_FrmImpressao_ClientesCadastradosW;
        private Relatórios.FrmImpressao_ClientesCadastroEtiqueta_W vTela_FrmImpressao_ClientesCadastradosEtiquetaW;
        private Relatórios.FrmImpressao_VeiculosCadastrados vTela_FrmImpressao_VeiculosCadastrados;
        private Relatórios.FrmImpressao_VeiculosCadastrados_W vTela_FrmImpressao_VeiculosCadastradosW;
        private Relatórios.FrmImpressao_ExtratoDespesas vTela_FrmImpressao_ExtratoDespesas;
        private Relatórios.FrmImpressao_ExtratoDespesas_W vTela_FrmImpressao_ExtratoDespesasW;
        private Relatórios.FrmImpressao_TotalDespesas vTela_FrmImpressao_TotalDespesas;
        private Relatórios.FrmImpressao_TotalDespesas_W vTela_FrmImpressao_TotalDespesasW;
        private Relatórios.FrmImpressao_Vendas vTela_FrmImpressao_Vendas;
        private Relatórios.FrmImpressao_Vendas_W vTela_FrmImpressao_VendasW;
        private Relatórios.FrmImpressao_Comissao vTela_FrmImpressao_Comissao;
        private Relatórios.FrmImpressao_Comissao_W vTela_FrmImpressao_ComissaoW;

        private Ativacao.FrmConfiguraConexao vTela_FrmConfiguraConexao;

        public bool bAtivacaoTelefone{ get; set; }
        public string sAtivacaoTelefone { get; set; }

        public int vvCodigoUsuario
        {
            get { return iCodigoUsuario; }
            set { iCodigoUsuario = value; }
        }

        public string sEnderecoArquivoConexao
        {
            get { return vEnderecoConfig; }
        }

        public int vvSituacaoUsuario { get; set; }
        public string vvObservcaoUsuario { get; set; }
        public string vvUsuario { get; set; }
        public string vvSenhaUsuario { get; set; }
        public bool bAlterarLicenca { get; set; }

        public bool vvLogado
        {
            get { return vLogado; }
            set { vLogado = value; }
        }

        public empresa vvEmpresa{
            get{ return ccEmpresa;}
            set{ccEmpresa = value;}
        }

        public string vvNomeUsuario
        {
            get { return vNomeUsuario; }
            set { vNomeUsuario = value; }
        }

        public int vvNivelAcesso
        {
            get { return vNivelAcesso; }
            set { vNivelAcesso = value; }
        }

        public string vvEnderecoConfig
        {
            get { return vEnderecoConfig; }
        }

        public string vvEnderecoConexao
        {
            get { return vEnderecoConexao; }
            set { vEnderecoConexao = value; }
        }

        /// <summary>
        /// Relação da cartela de sistemas
        /// </summary>
        [Flags]
        public enum sistemasEhSol
        {
            EstacionamentoFacil = 1,
            FinanceiraWeb = 2
        }

        /// <summary>
        /// Função para iniciar o backup do banco de dados
        /// </summary>
        private void backupBanco()
        {
            string sNomeArquivo = Application.StartupPath + "\\Backup\\Estacionamento_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".bak";
            Backup obBackup = new Backup();
            Cursor.Current = Cursors.WaitCursor;
            if (obBackup.backupBanco(this.vEnderecoConfig, sNomeArquivo, Application.StartupPath + "\\Backup\\"))
            {
                MessageBox.Show("Backup executado com sucesso!\n\nArquivo gravado em: " + sNomeArquivo, "EstacionamentoFacil (Prin40)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CamadaDados vConexao = new CamadaDados();
                if (vConexao.buscarDadosConexao(vEnderecoConfig))
                {
                    if (vConexao.Conectar(vConexao.vvServidor, vConexao.vvDataBase, vConexao.vvUser, vConexao.vvPass, vConexao.vvPorta))
                    {
                        vConexao.inserirAuditoria(14, vvCodigoUsuario, "Backup realizado com sucesso!", "");
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void verificarUltimoBackup()
        {   
            try
            {
                CamadaDados vConexao = new CamadaDados();
                if (vConexao.buscarDadosConexao(vEnderecoConfig))
                {
                    if (vConexao.Conectar(vConexao.vvServidor, vConexao.vvDataBase, vConexao.vvUser, vConexao.vvPass, vConexao.vvPorta))
                    {
                        if (!vConexao.verificarUltimoBackup())
                        {
                            MessageBox.Show("Atenção!!!\n\nÚltimo backup realizado a mais de 30 dias!\nRealize o backup dos seus dados.", "EstacionamentoFacil (Prin41)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao pesquisar dados de Backup!\n" + ex.Message, "EstacionamentoFacil (Prin42)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Função para abrir a tela de login
        /// </summary>
        private void abrirLogin()
        {
            var vLogin = this.MdiChildren.OfType<FrmLogin>().FirstOrDefault();
            if (vLogin == null)
            {
                vTela_FrmLogin = new FrmLogin(this);
                vTela_FrmLogin.MdiParent = this;
                vTela_FrmLogin.WindowState = FormWindowState.Normal;
                vTela_FrmLogin.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmLogin.Show();                
            }
            else
            {
                vTela_FrmLogin.Focus();
            }
        }

        /// <summary>
        /// Função apra abrir a tela de senha de acesso
        /// </summary>
        /// <param name="vvForm">Formulários para serem abertos: 0 - FrmSuportes</param>
        private void abrirSenhaAcesso(byte vvForm)
        {
            var vTela = this.MdiChildren.OfType<FrmSenhaAcesso>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmSenhaAcesso = new FrmSenhaAcesso(vvForm, this);
                vTela_FrmSenhaAcesso.MdiParent = this;
                vTela_FrmSenhaAcesso.WindowState = FormWindowState.Normal;
                vTela_FrmSenhaAcesso.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmSenhaAcesso.Show();
            }
            else
            {
                vTela_FrmSenhaAcesso.Focus();
            }
        }

        /// <summary>
        /// Função para abrir a tela de suportes
        /// </summary>
        public void abrirSuportes()
        {
            var vTela = this.MdiChildren.OfType<FrmSuportes>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmSuportes = new FrmSuportes(this);
                vTela_FrmSuportes.MdiParent = this;
                vTela_FrmSuportes.WindowState = FormWindowState.Normal;
                vTela_FrmSuportes.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmSuportes.Show();                
            }
            else
            {
                vTela_FrmSuportes.Focus();
            }
        }

        public void abrirSuporte01(FrmPrincipal vFrmPrincipal)
        {
            var vTela = this.MdiChildren.OfType<FrmSuporte01>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmSuporte01 = new FrmSuporte01(vFrmPrincipal);
                vTela_FrmSuporte01.MdiParent = this;
                vTela_FrmSuporte01.WindowState = FormWindowState.Normal;
                vTela_FrmSuporte01.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmSuporte01.Show();
            }
            else
            {
                vTela_FrmSuporte01.Focus();
            }
        }

        private void abrirCadMunicipio()
        {
            var vTela = this.MdiChildren.OfType<FrmCadMunicipio>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmCadMunicipio = new FrmCadMunicipio(this.vEnderecoConfig);
                vTela_FrmCadMunicipio.MdiParent = this;
                vTela_FrmCadMunicipio.WindowState = FormWindowState.Normal;
                vTela_FrmCadMunicipio.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmCadMunicipio.Show();
            }
            else
            {
                vTela_FrmCadMunicipio.Focus();
            }
        }

        private void abrirCadLocalidade()
        {
            var vTela = this.MdiChildren.OfType<FrmCadLocalidade>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmCadLocalidade = new FrmCadLocalidade(this.vEnderecoConfig);
                vTela_FrmCadLocalidade.MdiParent = this;
                vTela_FrmCadLocalidade.WindowState = FormWindowState.Normal;
                vTela_FrmCadLocalidade.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmCadLocalidade.Show();
            }
            else
            {
                vTela_FrmCadLocalidade.Focus();
            }
        }

        private void abrirCadBairro()
        {
            var vTela = this.MdiChildren.OfType<FrmCadBairro>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmCadBairro = new FrmCadBairro(this.vEnderecoConfig);
                vTela_FrmCadBairro.MdiParent = this;
                vTela_FrmCadBairro.WindowState = FormWindowState.Normal;
                vTela_FrmCadBairro.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmCadBairro.Show();
            }
            else
            {
                vTela_FrmCadBairro.Focus();
            }
        }

        private void abrirCadLogradouro()
        {
            var vTela = this.MdiChildren.OfType<FrmCadLogradouro>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmCadLogradouro = new FrmCadLogradouro(this.vEnderecoConfig);
                vTela_FrmCadLogradouro.MdiParent = this;
                vTela_FrmCadLogradouro.WindowState = FormWindowState.Normal;
                vTela_FrmCadLogradouro.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmCadLogradouro.Show();
            }
            else
            {
                vTela_FrmCadBairro.Focus();
            }
        }

        private void abrirCadOperadora()
        {
            var vTela = this.MdiChildren.OfType<FrmCadOperadora>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmCadOperadora = new FrmCadOperadora(this.vEnderecoConfig);
                vTela_FrmCadOperadora.MdiParent = this;
                vTela_FrmCadOperadora.WindowState = FormWindowState.Normal;
                vTela_FrmCadOperadora.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmCadOperadora.Show();
            }
            else
            {
                vTela_FrmCadOperadora.Focus();
            }
        }

        public void abrirNovoTelefone(FrmPrincipal vTelaPrincipal, byte bTela)
        {
            var vTela = this.MdiChildren.OfType<FrmNovoTelefone>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmNovoTelefone = new FrmNovoTelefone(this.vEnderecoConfig,vTelaPrincipal,bTela);
                vTela_FrmNovoTelefone.MdiParent = this;
                vTela_FrmNovoTelefone.WindowState = FormWindowState.Normal;
                vTela_FrmNovoTelefone.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmNovoTelefone.Show();
            }
            else
            {
                vTela_FrmNovoTelefone.Focus();
            }
        }

        public void abrirNovoVeiculo(FrmPrincipal vTelaPrincipal, string sCodigosNaoListar, cliente cCliente)
        {
            var vTela = this.MdiChildren.OfType<FrmNovoCarroCliente>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmNovoCarroCliente = new FrmNovoCarroCliente(this.vEnderecoConfig, vTelaPrincipal, cCliente);
                vTela_FrmNovoCarroCliente.MdiParent = this;
                vTela_FrmNovoCarroCliente.WindowState = FormWindowState.Normal;
                vTela_FrmNovoCarroCliente.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmNovoCarroCliente.sCodigosExistentes = sCodigosNaoListar;
                vTela_FrmNovoCarroCliente.Show();
            }
            else
            {
                vTela_FrmNovoCarroCliente.Focus();
            }
        }

        public void abrirNovoOpcional(FrmPrincipal vTelaPrincipal, string sCodigosNaoListar, carro cCarro)
        {
            var vTela = this.MdiChildren.OfType<FrmCadCarro_Opcional>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmCadCarro_Opcional = new FrmCadCarro_Opcional(this.vEnderecoConfig, vTelaPrincipal, cCarro);
                vTela_FrmCadCarro_Opcional.MdiParent = this;
                vTela_FrmCadCarro_Opcional.WindowState = FormWindowState.Normal;
                vTela_FrmCadCarro_Opcional.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmCadCarro_Opcional.sCodigosExistentes = sCodigosNaoListar;
                vTela_FrmCadCarro_Opcional.Show();
            }
            else
            {
                vTela_FrmCadCarro_Opcional.Focus();
            }
        }

        public void abrirCadVendedor(FrmPrincipal vTelaPrincipal)
        {
            var vTela = this.MdiChildren.OfType<FrmCadVendedor>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmCadVendedor = new FrmCadVendedor(this.vEnderecoConfig, vTelaPrincipal);
                vTela_FrmCadVendedor.MdiParent = this;
                vTela_FrmCadVendedor.WindowState = FormWindowState.Normal;
                vTela_FrmCadVendedor.StartPosition = FormStartPosition.CenterScreen;                
                vTela_FrmCadVendedor.Show();
            }
            else
            {
                vTela_FrmCadVendedor.Focus();
            }
        }

        public void abrirLocalizarVeiculo(FrmCadCarro vTelaCadCarro)
        {
            var vTela = this.MdiChildren.OfType<FrmLocalizarVeiculo>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmLocalizarVeiculo = new FrmLocalizarVeiculo(this.vEnderecoConfig, vTelaCadCarro);
                vTela_FrmLocalizarVeiculo.MdiParent = this;
                vTela_FrmLocalizarVeiculo.WindowState = FormWindowState.Normal;
                vTela_FrmLocalizarVeiculo.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmLocalizarVeiculo.Show();
            }
            else
            {
                vTela_FrmLocalizarVeiculo.Focus();
            }
        }
        
        public void abrirLocalizarCliente(FrmCadCliente vTelaCadCliente)
        {
            var vTela = this.MdiChildren.OfType<FrmLocalizarCliente>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmLocalizarCliente = new FrmLocalizarCliente(this.vEnderecoConfig, vTelaCadCliente);
                vTela_FrmLocalizarCliente.MdiParent = this;
                vTela_FrmLocalizarCliente.WindowState = FormWindowState.Normal;
                vTela_FrmLocalizarCliente.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmLocalizarCliente.Show();
            }
            else
            {
                vTela_FrmLocalizarCliente.Focus();
            }
        }

        /// <summary>
        /// Função para abrir a tela de vendas
        /// </summary>
        /// <param name="vTelaPrincipal">Tela principal</param>
        /// <param name="bTipo">(Opcional) Tipo 0 - Novo cadastro e/ou atualização 1 - Chamada direta mediante ao objeto vendas</param>
        /// <param name="cVendas">(Opcional) Objeto vendas</param>
        public void abrirCadVendas(FrmPrincipal vTelaPrincipal, byte bTipo = 0, vendas cVendas = null)
        {
            var vTela = this.MdiChildren.OfType<FrmCadVenda>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmCadVenda = new FrmCadVenda(this.vEnderecoConfig, vTelaPrincipal, bTipo, cVendas);
                vTela_FrmCadVenda.MdiParent = this;
                vTela_FrmCadVenda.WindowState = FormWindowState.Normal;
                vTela_FrmCadVenda.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmCadVenda.Show();
            }
            else
            {
                vTela_FrmCadVenda.Focus();
            }
        }

        public void abrirAlterarSenha(FrmPrincipal vTelaPrincipal)
        {
            var vTela = this.MdiChildren.OfType<FrmAlterarSenha>().FirstOrDefault();
            if (vTela == null)
            {

                usuario obUsuario = new usuario();
                obUsuario.cod_usuario = this.vvCodigoUsuario;
                obUsuario.dica_senha = "";
                obUsuario.nomeusuario = this.vvNomeUsuario;
                obUsuario.observacao = "";
                obUsuario.senha = this.vvSenhaUsuario;
                obUsuario.situacao = this.vvSituacaoUsuario;
                obUsuario.sUsuario = this.vvUsuario;
                obUsuario.tipo = this.vvNivelAcesso;

                vTela_FrmAlterarSenha = new FrmAlterarSenha(vTelaPrincipal, obUsuario, this.vEnderecoConfig);
                vTela_FrmAlterarSenha.MdiParent = this;
                vTela_FrmAlterarSenha.WindowState = FormWindowState.Normal;
                vTela_FrmAlterarSenha.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmAlterarSenha.Show();
            }
            else
            {
                vTela_FrmAlterarSenha.Focus();
            }
        }

        private void abrirCadUsuario(FrmPrincipal vTelaPrincipal)
        {
            var vTela = this.MdiChildren.OfType<FrmCadUsuario>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmCadUsuario = new FrmCadUsuario(this.vEnderecoConfig, vTelaPrincipal);
                vTela_FrmCadUsuario.MdiParent = this;
                vTela_FrmCadUsuario.WindowState = FormWindowState.Normal;
                vTela_FrmCadUsuario.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmCadUsuario.Show();
            }
            else
            {
                vTela_FrmCadUsuario.Focus();
            }
        }

        private void abrirAuditoria(FrmPrincipal vTelaPrincipal)
        {
            var vTela = this.MdiChildren.OfType<FrmAuditoria>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmAuditoria = new FrmAuditoria(this.vEnderecoConfig, vTelaPrincipal);
                vTela_FrmAuditoria.MdiParent = this;
                vTela_FrmAuditoria.WindowState = FormWindowState.Normal;
                vTela_FrmAuditoria.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmAuditoria.Show();
            }
            else
            {
                vTela_FrmAuditoria.Focus();
            }
        }

        private void abrirCadEmpresa(FrmPrincipal vTelaPrincipal)
        {
            var vTela = this.MdiChildren.OfType<FrmCadEmpresa>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmCadEmpresa = new FrmCadEmpresa(vTelaPrincipal, this.vEnderecoConfig);
                vTela_FrmCadEmpresa.MdiParent = this;
                vTela_FrmCadEmpresa.WindowState = FormWindowState.Normal;
                vTela_FrmCadEmpresa.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmCadEmpresa.Show();
            }
            else
            {
                vTela_FrmCadEmpresa.Focus();
            }
        }

        public void abrirImpressaoAuditoria(FrmPrincipal vTelaPrincipal)
        {
            var vTela = this.MdiChildren.OfType<Relatórios.FrmImpressao_Auditoria>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmImpressao_Auditoria = new Relatórios.FrmImpressao_Auditoria(vTelaPrincipal, this.vEnderecoConfig);
                vTela_FrmImpressao_Auditoria.MdiParent = this;
                vTela_FrmImpressao_Auditoria.WindowState = FormWindowState.Normal;
                vTela_FrmImpressao_Auditoria.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmImpressao_Auditoria.Show();
            }
            else
            {
                vTela_FrmImpressao_Auditoria.Focus();
            }
        }

        public void abrirImpressaoAuditoria(FrmPrincipal vTelaPrincipal, byte bTipo)
        {
            var vTela = this.MdiChildren.OfType<Relatórios.FrmImpressao_Auditoria_W>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmImpressao_AuditoriaW = new Relatórios.FrmImpressao_Auditoria_W(vTelaPrincipal, this.vEnderecoConfig);
                vTela_FrmImpressao_AuditoriaW.MdiParent = this;
                vTela_FrmImpressao_AuditoriaW.WindowState = FormWindowState.Normal;
                vTela_FrmImpressao_AuditoriaW.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmImpressao_AuditoriaW.Show();
            }
            else
            {
                vTela_FrmImpressao_AuditoriaW.Focus();
            }
        }

        public void abrirPesq_ClientesCadastrados(FrmPrincipal vTelaPrincipal)
        {
            var vTela = this.MdiChildren.OfType<Relatórios.FrmPesq_ClientesCadastrados>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmPesq_ClientesCadastrados = new Relatórios.FrmPesq_ClientesCadastrados(this.vEnderecoConfig, vTelaPrincipal);
                vTela_FrmPesq_ClientesCadastrados.MdiParent = this;
                vTela_FrmPesq_ClientesCadastrados.WindowState = FormWindowState.Normal;
                vTela_FrmPesq_ClientesCadastrados.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmPesq_ClientesCadastrados.Show();
            }
            else
            {
                vTela_FrmPesq_ClientesCadastrados.Focus();
            }
        }

        public void abrirPesq_VeiculosCadastrados(FrmPrincipal vTelaPrincipal)
        {
            var vTela = this.MdiChildren.OfType<Relatórios.FrmPesq_VeiculosCadastradoscs>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmPesq_VeiculosCadastrados = new Relatórios.FrmPesq_VeiculosCadastradoscs(vTelaPrincipal, this.vEnderecoConfig);
                vTela_FrmPesq_VeiculosCadastrados.MdiParent = this;
                vTela_FrmPesq_VeiculosCadastrados.WindowState = FormWindowState.Normal;
                vTela_FrmPesq_VeiculosCadastrados.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmPesq_VeiculosCadastrados.Show();
            }
            else
            {
                vTela_FrmPesq_VeiculosCadastrados.Focus();
            }
        }

        public void abrirPesq_ExtratoDespesas(FrmPrincipal vTelaPrincipal)
        {
            var vTela = this.MdiChildren.OfType<Relatórios.FrmPesq_ExtratoDespesas>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmPesq_ExtratoDespesas = new Relatórios.FrmPesq_ExtratoDespesas(vTelaPrincipal, this.vEnderecoConfig);
                vTela_FrmPesq_ExtratoDespesas.MdiParent = this;
                vTela_FrmPesq_ExtratoDespesas.WindowState = FormWindowState.Normal;
                vTela_FrmPesq_ExtratoDespesas.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmPesq_ExtratoDespesas.Show();
            }
            else
            {
                vTela_FrmPesq_ExtratoDespesas.Focus();
            }
        }

        public void abrirPesq_TotalDespesas(FrmPrincipal vTelaPrincipal)
        {
            var vTela = this.MdiChildren.OfType<Relatórios.FrmPesq_TotalDespesas>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmPesq_TotalDesppesas = new Relatórios.FrmPesq_TotalDespesas(vTelaPrincipal, this.vEnderecoConfig);
                vTela_FrmPesq_TotalDesppesas.MdiParent = this;
                vTela_FrmPesq_TotalDesppesas.WindowState = FormWindowState.Normal;
                vTela_FrmPesq_TotalDesppesas.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmPesq_TotalDesppesas.Show();
            }
            else
            {
                vTela_FrmPesq_TotalDesppesas.Focus();
            }
        }

        public void abrirPesq_Vendas(FrmPrincipal vTelaPrincipal)
        {
            var vTela = this.MdiChildren.OfType<Relatórios.FrmPesq_Vendas>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmPesq_Vendas = new Relatórios.FrmPesq_Vendas(vTelaPrincipal, this.vEnderecoConfig);
                vTela_FrmPesq_Vendas.MdiParent = this;
                vTela_FrmPesq_Vendas.WindowState = FormWindowState.Normal;
                vTela_FrmPesq_Vendas.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmPesq_Vendas.Show();
            }
            else
            {
                vTela_FrmPesq_Vendas.Focus();
            }
        }

        public void abrirPesq_Comissao(FrmPrincipal vTelaPrincipal)
        {
            var vTela = this.MdiChildren.OfType<Relatórios.FrmPesq_Comissao>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmPesq_Comissao = new Relatórios.FrmPesq_Comissao(vTelaPrincipal, this.vEnderecoConfig);
                vTela_FrmPesq_Comissao.MdiParent = this;
                vTela_FrmPesq_Comissao.WindowState = FormWindowState.Normal;
                vTela_FrmPesq_Comissao.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmPesq_Comissao.Show();
            }
            else
            {
                vTela_FrmPesq_Comissao.Focus();
            }
        }

        public void abrirImpressaoClientesCadastrados(FrmPrincipal vTelaPrincipal)
        {
            var vTela = this.MdiChildren.OfType<Relatórios.FrmImpressao_ClientesCadastrados>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmImpressao_ClientesCadastrados = new Relatórios.FrmImpressao_ClientesCadastrados(vTelaPrincipal, this.vEnderecoConfig);
                vTela_FrmImpressao_ClientesCadastrados.MdiParent = this;
                vTela_FrmImpressao_ClientesCadastrados.WindowState = FormWindowState.Maximized;
                vTela_FrmImpressao_ClientesCadastrados.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmImpressao_ClientesCadastrados.Show();
            }
            else
            {
                vTela_FrmImpressao_ClientesCadastrados.Focus();
            }
        }

        public void abrirImpressaoClientesCadastrados(FrmPrincipal vTelaPrincipal, byte bTipo)
        {
            switch(bTipo){
                case 0:
                    var vTela = this.MdiChildren.OfType<Relatórios.FrmImpressao_ClientesCadastrados_W>().FirstOrDefault();
                    if (vTela == null)
                    {
                        vTela_FrmImpressao_ClientesCadastradosW = new Relatórios.FrmImpressao_ClientesCadastrados_W(vTelaPrincipal, this.vEnderecoConfig);
                        vTela_FrmImpressao_ClientesCadastradosW.MdiParent = this;
                        vTela_FrmImpressao_ClientesCadastradosW.WindowState = FormWindowState.Maximized;
                        vTela_FrmImpressao_ClientesCadastradosW.StartPosition = FormStartPosition.CenterScreen;
                        vTela_FrmImpressao_ClientesCadastradosW.Show();
                    }
                    else
                    {
                        vTela_FrmImpressao_ClientesCadastradosW.Focus();
                    }
                    break;
                case 1:
                    var vTela2 = this.MdiChildren.OfType<Relatórios.FrmImpressao_ClientesCadastroEtiqueta_W>().FirstOrDefault();
                    if (vTela2 == null)
                    {
                        vTela_FrmImpressao_ClientesCadastradosEtiquetaW = new Relatórios.FrmImpressao_ClientesCadastroEtiqueta_W(vTelaPrincipal, this.vEnderecoConfig);
                        vTela_FrmImpressao_ClientesCadastradosEtiquetaW.MdiParent = this;
                        vTela_FrmImpressao_ClientesCadastradosEtiquetaW.WindowState = FormWindowState.Maximized;
                        vTela_FrmImpressao_ClientesCadastradosEtiquetaW.StartPosition = FormStartPosition.CenterScreen;
                        vTela_FrmImpressao_ClientesCadastradosEtiquetaW.Show();
                    }
                    else
                    {
                        vTela_FrmImpressao_ClientesCadastradosW.Focus();
                    }
                    break;
            }
        }

        public void abrirImpressaoVeiculosCadastrados(FrmPrincipal vTelaPrincipal)
        {
            var vTela = this.MdiChildren.OfType<Relatórios.FrmImpressao_VeiculosCadastrados>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmImpressao_VeiculosCadastrados = new Relatórios.FrmImpressao_VeiculosCadastrados(vTelaPrincipal, this.vEnderecoConfig);
                vTela_FrmImpressao_VeiculosCadastrados.MdiParent = this;
                vTela_FrmImpressao_VeiculosCadastrados.WindowState = FormWindowState.Maximized;
                vTela_FrmImpressao_VeiculosCadastrados.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmImpressao_VeiculosCadastrados.Show();
            }
            else
            {
                vTela_FrmImpressao_VeiculosCadastrados.Focus();
            }
        }

        public void abrirImpressaoVeiculosCadastradosW(FrmPrincipal vTelaPrincipal)
        {
            var vTela = this.MdiChildren.OfType<Relatórios.FrmImpressao_VeiculosCadastrados_W>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmImpressao_VeiculosCadastradosW = new Relatórios.FrmImpressao_VeiculosCadastrados_W(vTelaPrincipal, this.vEnderecoConfig);
                vTela_FrmImpressao_VeiculosCadastradosW.MdiParent = this;
                vTela_FrmImpressao_VeiculosCadastradosW.WindowState = FormWindowState.Maximized;
                vTela_FrmImpressao_VeiculosCadastradosW.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmImpressao_VeiculosCadastradosW.Show();
            }
            else
            {
                vTela_FrmImpressao_VeiculosCadastradosW.Focus();
            }
        }

        public void abrirImpressaoExtratoDespesas(FrmPrincipal vTelaPrincipal)
        {
            var vTela = this.MdiChildren.OfType<Relatórios.FrmImpressao_ExtratoDespesas>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmImpressao_ExtratoDespesas = new Relatórios.FrmImpressao_ExtratoDespesas(vTelaPrincipal, this.vEnderecoConfig);
                vTela_FrmImpressao_ExtratoDespesas.MdiParent = this;
                vTela_FrmImpressao_ExtratoDespesas.WindowState = FormWindowState.Maximized;
                vTela_FrmImpressao_ExtratoDespesas.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmImpressao_ExtratoDespesas.Show();
            }
            else
            {
                vTela_FrmImpressao_ExtratoDespesas.Focus();
            }
        }

        public void abrirImpressaoExtratoDespesasW(FrmPrincipal vTelaPrincipal)
        {
            var vTela = this.MdiChildren.OfType<Relatórios.FrmImpressao_ExtratoDespesas_W>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmImpressao_ExtratoDespesasW = new Relatórios.FrmImpressao_ExtratoDespesas_W(vTelaPrincipal, this.vEnderecoConfig);
                vTela_FrmImpressao_ExtratoDespesasW.MdiParent = this;
                vTela_FrmImpressao_ExtratoDespesasW.WindowState = FormWindowState.Maximized;
                vTela_FrmImpressao_ExtratoDespesasW.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmImpressao_ExtratoDespesasW.Show();
            }
            else
            {
                vTela_FrmImpressao_ExtratoDespesasW.Focus();
            }
        }

        public void abrirImpressaoTotalDespesas(FrmPrincipal vTelaPrincipal)
        {
            var vTela = this.MdiChildren.OfType<Relatórios.FrmImpressao_TotalDespesas>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmImpressao_TotalDespesas = new Relatórios.FrmImpressao_TotalDespesas(vTelaPrincipal, this.vEnderecoConfig);
                vTela_FrmImpressao_TotalDespesas.MdiParent = this;
                vTela_FrmImpressao_TotalDespesas.WindowState = FormWindowState.Maximized;
                vTela_FrmImpressao_TotalDespesas.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmImpressao_TotalDespesas.Show();
            }
            else
            {
                vTela_FrmImpressao_TotalDespesas.Focus();
            }
        }

        public void abrirImpressaoTotalDespesasW(FrmPrincipal vTelaPrincipal)
        {
            var vTela = this.MdiChildren.OfType<Relatórios.FrmImpressao_TotalDespesas_W>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmImpressao_TotalDespesasW = new Relatórios.FrmImpressao_TotalDespesas_W(vTelaPrincipal, this.vEnderecoConfig);
                vTela_FrmImpressao_TotalDespesasW.MdiParent = this;
                vTela_FrmImpressao_TotalDespesasW.WindowState = FormWindowState.Maximized;
                vTela_FrmImpressao_TotalDespesasW.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmImpressao_TotalDespesasW.Show();
            }
            else
            {
                vTela_FrmImpressao_TotalDespesasW.Focus();
            }
        }

        public void abrirImpressaoVendas(FrmPrincipal vTelaPrincipal)
        {
            var vTela = this.MdiChildren.OfType<Relatórios.FrmImpressao_Vendas>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmImpressao_Vendas = new Relatórios.FrmImpressao_Vendas(vTelaPrincipal, this.vEnderecoConfig);
                vTela_FrmImpressao_Vendas.MdiParent = this;
                vTela_FrmImpressao_Vendas.WindowState = FormWindowState.Maximized;
                vTela_FrmImpressao_Vendas.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmImpressao_Vendas.Show();
            }
            else
            {
                vTela_FrmImpressao_Vendas.Focus();
            }
        }

        public void abrirImpressaoVendasW(FrmPrincipal vTelaPrincipal)
        {
            var vTela = this.MdiChildren.OfType<Relatórios.FrmImpressao_Vendas_W>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmImpressao_VendasW = new Relatórios.FrmImpressao_Vendas_W(vTelaPrincipal, this.vEnderecoConfig);
                vTela_FrmImpressao_VendasW.MdiParent = this;
                vTela_FrmImpressao_VendasW.WindowState = FormWindowState.Maximized;
                vTela_FrmImpressao_VendasW.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmImpressao_VendasW.Show();
            }
            else
            {
                vTela_FrmImpressao_VendasW.Focus();
            }
        }

        public void abrirImpressaoComissao(FrmPrincipal vTelaPrincipal)
        {
            var vTela = this.MdiChildren.OfType<Relatórios.FrmImpressao_Comissao>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmImpressao_Comissao = new Relatórios.FrmImpressao_Comissao(vTelaPrincipal, this.vEnderecoConfig);
                vTela_FrmImpressao_Comissao.MdiParent = this;
                vTela_FrmImpressao_Comissao.WindowState = FormWindowState.Maximized;
                vTela_FrmImpressao_Comissao.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmImpressao_Comissao.Show();
            }
            else
            {
                vTela_FrmImpressao_Comissao.Focus();
            }
        }

        public void abrirImpressaoComissaoW(FrmPrincipal vTelaPrincipal)
        {
            var vTela = this.MdiChildren.OfType<Relatórios.FrmImpressao_Comissao_W>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmImpressao_ComissaoW = new Relatórios.FrmImpressao_Comissao_W(vTelaPrincipal, this.vEnderecoConfig);
                vTela_FrmImpressao_ComissaoW.MdiParent = this;
                vTela_FrmImpressao_ComissaoW.WindowState = FormWindowState.Maximized;
                vTela_FrmImpressao_ComissaoW.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmImpressao_ComissaoW.Show();
            }
            else
            {
                vTela_FrmImpressao_ComissaoW.Focus();
            }
        }

        public void abrirConfiguraConexao()
        {
            var vTela = this.MdiChildren.OfType<Ativacao.FrmConfiguraConexao>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmConfiguraConexao = new Ativacao.FrmConfiguraConexao(this.vEnderecoConfig);
                vTela_FrmConfiguraConexao.MdiParent = this;
                vTela_FrmConfiguraConexao.WindowState = FormWindowState.Normal;
                vTela_FrmConfiguraConexao.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmConfiguraConexao.Show();
            }
            else
            {
                vTela_FrmConfiguraConexao.Focus();
            }
        }

        /// <summary>
        /// Função para abrir tela de cadastro de comissão
        /// </summary>
        /// <param name="vTelaPrincipal">Tela principal</param>
        /// <param name="iTipo">Tipo 0 - Nova comissão, 1 - Atualizar comissao</param>
        /// <param name="iCodVendedor">Cod vendedor para consulta</param>
        /// <param name="cVendas"></param>
        public void abrirCadComissao(FrmPrincipal vTelaPrincipal, int iTipo, vendas cVendas, int iCodVendedor)
        {
            var vTela = this.MdiChildren.OfType<FrmCadComissao>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmCadComissao= new FrmCadComissao(this.vEnderecoConfig, vTelaPrincipal, iTipo, cVendas,iCodVendedor);
                vTela_FrmCadComissao.MdiParent = this;
                vTela_FrmCadComissao.WindowState = FormWindowState.Normal;
                vTela_FrmCadComissao.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmCadComissao.Show();
            }
            else
            {
                vTela_FrmCadComissao.Focus();
            }
        }

        public void fecharTelasRelacionadas(string sTela)
        {
            switch (sTela)
            {
                case "CadCarro":
                    //Despesa
                    var vTela01 = this.MdiChildren.OfType<FrmCadDespesa>().FirstOrDefault();
                    if (vTela01 != null) vTela_FrmCadDespesa.Close();
                    //Observacao
                    var vTela02 = this.MdiChildren.OfType<FrmCadObservacao>().FirstOrDefault();
                    if (vTela02 != null) vTela_FrmCadObservacao.Close();
                    //Historico
                    var vTela03 = this.MdiChildren.OfType<FrmCadHistorico>().FirstOrDefault();
                    if (vTela03 != null) vTela_FrmCadHistorico.Close();
                    //Opcionais
                    var vTela04 = this.MdiChildren.OfType<FrmCadCarro_Opcional>().FirstOrDefault();
                    if (vTela04 != null) vTela_FrmCadCarro_Opcional.Close();
                    //Localizar
                    var vTela07 = this.MdiChildren.OfType<FrmLocalizarVeiculo>().FirstOrDefault();
                    if (vTela07 != null) vTela_FrmLocalizarVeiculo.Close();

                    break;
                case "CadVenda":
                    var vTela05 = this.MdiChildren.OfType<FrmCadComissao>().FirstOrDefault();
                    if (vTela05 != null) vTela_FrmCadComissao.Close();

                    var vTela06 = this.MdiChildren.OfType<FrmCadObservacao>().FirstOrDefault();
                    if (vTela06 != null) vTela_FrmCadObservacao.Close();
                    break;
            }
        }

        public void abrirCadDespesa(FrmPrincipal vTelaPrincipal, carro cCarro, bool bSemCarro)
        {
            var vTela = this.MdiChildren.OfType<FrmCadDespesa>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmCadDespesa = new FrmCadDespesa(this.vEnderecoConfig, vTelaPrincipal, cCarro, bSemCarro);
                vTela_FrmCadDespesa.MdiParent = this;
                vTela_FrmCadDespesa.WindowState = FormWindowState.Normal;
                vTela_FrmCadDespesa.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmCadDespesa.Show();
            }
            else
            {
                if (bSemCarro != vTela_FrmCadDespesa.vSemCarro)
                {
                    if (!bSemCarro)
                    {
                        vTela_FrmCadDespesa.vSemCarro = bSemCarro;
                        vTela_FrmCadDespesa.vCarro = cCarro;
                        vTela_FrmCadDespesa.ve_se_existe();
                    }
                    else
                    {
                        vTela_FrmCadDespesa.vSemCarro = bSemCarro;
                        vTela_FrmCadDespesa.vCarro = null;
                        vTela_FrmCadDespesa.ve_se_existe();
                    }
                }
                vTela_FrmCadDespesa.Focus();
            }
        }

        public void abrirCadObservacao(FrmPrincipal vTelaPrincipal, carro cCarro)
        {
            var vTela = this.MdiChildren.OfType<FrmCadObservacao>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmCadObservacao = new FrmCadObservacao(this.vEnderecoConfig, vTelaPrincipal, cCarro);
                vTela_FrmCadObservacao.MdiParent = this;
                vTela_FrmCadObservacao.WindowState = FormWindowState.Normal;
                vTela_FrmCadObservacao.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmCadObservacao.Show();
            }
            else
            {
                vTela_FrmCadObservacao.Focus();
            }
        }

        public void abrirCadContaCartaoCliente(FrmPrincipal vTelaPrincipal, cliente cCliente)
        {
            var vTela = this.MdiChildren.OfType<FrmContaCartaoCliente>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmContaCartaoCliente = new FrmContaCartaoCliente(this.vEnderecoConfig, vTelaPrincipal, cCliente);
                vTela_FrmContaCartaoCliente.MdiParent = this;
                vTela_FrmContaCartaoCliente.WindowState = FormWindowState.Normal;
                vTela_FrmContaCartaoCliente.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmContaCartaoCliente.Show();
            }
            else
            {
                vTela_FrmContaCartaoCliente.Focus();
            }
        }

        public void abrirCadObservacao(FrmPrincipal vTelaPrincipal, vendas cVendas)
        {
            var vTela = this.MdiChildren.OfType<FrmCadObservacao>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmCadObservacao = new FrmCadObservacao(this.vEnderecoConfig, vTelaPrincipal,cVendas);
                vTela_FrmCadObservacao.MdiParent = this;
                vTela_FrmCadObservacao.WindowState = FormWindowState.Normal;
                vTela_FrmCadObservacao.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmCadObservacao.Show();
            }
            else
            {
                vTela_FrmCadObservacao.Focus();
            }
        }

        public void abrirCadObservacao(FrmPrincipal vTelaPrincipal, cliente cCliente)
        {
            var vTela = this.MdiChildren.OfType<FrmCadObservacao>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmCadObservacao = new FrmCadObservacao(this.vEnderecoConfig, vTelaPrincipal, cCliente);
                vTela_FrmCadObservacao.MdiParent = this;
                vTela_FrmCadObservacao.WindowState = FormWindowState.Normal;
                vTela_FrmCadObservacao.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmCadObservacao.Show();
            }
            else
            {
                vTela_FrmCadObservacao.Focus();
            }
        }

        public void abrirCadHistorico(FrmPrincipal vTelaPrincipal, carro cCarro, bool bNovoVeiculo)
        {
            var vTela = this.MdiChildren.OfType<FrmCadHistorico>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmCadHistorico = new FrmCadHistorico(this.vEnderecoConfig, vTelaPrincipal,cCarro, bNovoVeiculo);
                vTela_FrmCadHistorico.MdiParent = this;
                vTela_FrmCadHistorico.WindowState = FormWindowState.Normal;
                vTela_FrmCadHistorico.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmCadHistorico.Show();
            }
            else
            {
                vTela_FrmCadHistorico.Focus();
            }
        }

        public void abrirCadCliente(FrmPrincipal vTelaPrincipal)
        {
            var vTela = this.MdiChildren.OfType<FrmCadCliente>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmCadCliente = new FrmCadCliente(this.vEnderecoConfig, vTelaPrincipal);
                vTela_FrmCadCliente.MdiParent = this;
                vTela_FrmCadCliente.WindowState = FormWindowState.Normal;
                vTela_FrmCadCliente.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmCadCliente.Show();
            }
            else
            {
                vTela_FrmCadCliente.Focus();
            }
        }

        public void abrirCadCarro(FrmPrincipal vTelaPrincipal)
        {
            var vTela = this.MdiChildren.OfType<FrmCadCarro>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmCadCarro = new FrmCadCarro(this.vEnderecoConfig, vTelaPrincipal);
                vTela_FrmCadCarro.MdiParent = this;
                vTela_FrmCadCarro.WindowState = FormWindowState.Normal;
                vTela_FrmCadCarro.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmCadCarro.Show();
            }
            else
            {
                vTela_FrmCadCarro.Focus();
            }
        }

        public void abrirCadCarro(FrmPrincipal vTelaPrincipal, carro cCarro)
        {
            var vTela = this.MdiChildren.OfType<FrmCadCarro>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmCadCarro = new FrmCadCarro(this.vEnderecoConfig, vTelaPrincipal,cCarro);
                vTela_FrmCadCarro.MdiParent = this;
                vTela_FrmCadCarro.WindowState = FormWindowState.Normal;
                vTela_FrmCadCarro.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmCadCarro.Show();
            }
            else
            {
                vTela_FrmCadCarro.Focus();
            }
        }

        private void abrirCadMarca()
        {
            var vTela = this.MdiChildren.OfType<FrmCadMarca>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmCadMarca = new FrmCadMarca(this.vEnderecoConfig, this);
                vTela_FrmCadMarca.MdiParent = this;
                vTela_FrmCadMarca.WindowState = FormWindowState.Normal;
                vTela_FrmCadMarca.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmCadMarca.Show();
            }
            else
            {
                vTela_FrmCadMarca.Focus();
            }
        }

        private void abrirCadOpcionais()
        {
            var vTela = this.MdiChildren.OfType<FrmCadOpcionais>().FirstOrDefault();
            if (vTela == null)
            {
                vTela_FrmCadOpcionais = new FrmCadOpcionais(this.vEnderecoConfig,this);
                vTela_FrmCadOpcionais.MdiParent = this;
                vTela_FrmCadOpcionais.WindowState = FormWindowState.Normal;
                vTela_FrmCadOpcionais.StartPosition = FormStartPosition.CenterScreen;
                vTela_FrmCadOpcionais.Show();
            }
            else
            {
                vTela_FrmCadOpcionais.Focus();
            }
        }

        private bool validarSistema()
        {
            bool bResposta = false;
            try
            {
                CamadaDados vConexao = new CamadaDados();
                if (vConexao.buscarDadosConexao(vEnderecoConfig))
                {
                    if (vConexao.Conectar(vConexao.vvServidor, vConexao.vvDataBase, vConexao.vvUser, vConexao.vvPass, vConexao.vvPorta))
                    {
                        //buscar chave do sistema
                        empresa cEmpresa = new empresa();
                        Funcoes cFuncao = new Funcoes();
                        Seguranca cSeguranca = new Seguranca();
                        int iChaveAtivacao = 0;
                        int iQteAcessos = 0;

                        cFuncao.CheckRegistryKey("EstacionamentoFacil");

                        //buscar a qte de acessos:
                        iQteAcessos = int.Parse(cSeguranca.sDescriptografarString(cFuncao.GetStringValue("EstacionamentoFacil", "Acessos", "E")));
                        cEmpresa = vConexao.buscaDadosEmpresa();

                        //verificar se existe licença:
                        if (cEmpresa.licenca.Trim().Length > 0)
                        {
                            //verificar a data de expiração do sistema
                            if (cSeguranca.verificarDataExpiracao(cFuncao.retirarPonto(cEmpresa.licenca)))
                            {
                                //verificar se o micro está ativado                        
                                iChaveAtivacao = verificarAtivacao(cEmpresa); //0 - OK, 1 - Chave errada, 2 - Sem chave
                                switch (iChaveAtivacao)
                                {
                                    case 0:
                                        bResposta = true;
                                        break;
                                    case 1:
                                        if (MessageBox.Show("Verificamos que a chave de ativação não pertence a este computador!\nDeseja inserir nova chave de ativação?", "EstacionamentoFacil (Prin05)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                                        {
                                            if (ativarComputador(cEmpresa))
                                                bResposta = true;
                                        }
                                        else
                                        {
                                            cFuncao.SetStringValue("EstacionamentoFacil", "Ativação", "");
                                        }
                                        break;
                                    case 2:
                                        if (MessageBox.Show("Verificamos que este computador não está ativado!\nDeseja ativa-lo?", "EstacionamentoFacil (Prin06)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                                        {
                                            if (ativarComputador(cEmpresa))
                                                bResposta = true;
                                        }
                                        else
                                        {
                                            cFuncao.SetStringValue("EstacionamentoFacil", "Ativação", "");
                                        }
                                        break;
                                    case 3:
                                        bResposta = false;
                                        this.Close();
                                        break;
                                }//switch
                            }//data expiração
                            else
                            {
                                //avisar e dar crédito de qte de acessos
                                bool bQteAcessos = false;
                                string sIP = "";
                                byte bTipo = 1;
                                if (cFuncao.conectadoInternet())
                                {
                                    bTipo = 0;
                                    sIP = cFuncao.retornaIP();
                                    
                                    Security.Security cSeguranca2 = new Security.Security();
                                    bQteAcessos = cSeguranca2.verificarQteAcessosCliente(cFuncao.retirarPonto(cEmpresa.licenca), iQteAcessos, bTipo, sIP);
                                }
                                else
                                {
                                    bTipo = 1;
                                    bQteAcessos = cSeguranca.verificarQteAcessosCliente(cEmpresa.licenca, iQteAcessos, bTipo, sIP);
                                }
                                if (bQteAcessos)
                                {
                                    iQteAcessos++;
                                    cFuncao.SetStringValue("EstacionamentoFacil", "Acessos",cSeguranca.sCriptografarString(iQteAcessos.ToString()));

                                    //verificar se o micro está ativado                        
                                    iChaveAtivacao = verificarAtivacao(cEmpresa); //0 - OK, 1 - Chave errada, 2 - Sem chave
                                    switch (iChaveAtivacao)
                                    {
                                        case 0:
                                            bResposta = true;
                                            break;
                                        case 1:
                                            if (MessageBox.Show("Verificamos que a chave de ativação não pertence a este computador!\nDeseja inserir nova chave de ativação?", "EstacionamentoFacil (Prin05)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                                            {
                                                if (ativarComputador(cEmpresa))
                                                    bResposta = true;
                                            }
                                            else
                                            {
                                                cFuncao.SetStringValue("EstacionamentoFacil", "Ativação", "");
                                            }
                                            break;
                                        case 2:
                                            if (MessageBox.Show("Verificamos que este computador não está ativado!\nDeseja ativa-lo?", "EstacionamentoFacil (Prin06)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                                            {
                                                if (ativarComputador(cEmpresa))
                                                    bResposta = true;
                                            }
                                            else
                                            {
                                                cFuncao.SetStringValue("EstacionamentoFacil", "Ativação", "");
                                            }
                                            break;
                                        case 3:
                                            bResposta = false;
                                            this.Close();
                                            break;
                                    }//switch
                                    
                                    bResposta = true;
                                }
                                else
                                {
                                    MessageBox.Show("Prazo de utilização do sistema expirou!\nEntre em contato com a empresa responsável!", "EstacionamentoFacil (Prin04)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                            }
                        }//;sem licença
                        else
                        {
                            if (MessageBox.Show("Atenção!!!\n\nSistema não possui licença. Deseja inserir a licença?", "EstacionamentoFacil (Prin10)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                            {
                                string ssLicenca="";
                                bResposta = novaLicenca(out ssLicenca);
                                if (bResposta)
                                {
                                    cEmpresa.licenca = ssLicenca.Trim();
                                    CamadaDados obConexao = new CamadaDados();
                                    if (obConexao.buscarDadosConexao(vEnderecoConfig))
                                    {
                                        if (obConexao.Conectar(obConexao.vvServidor, obConexao.vvDataBase, obConexao.vvUser, obConexao.vvPass, obConexao.vvPorta))
                                        {
                                            bResposta = obConexao.gravarDadosEmpresa(cEmpresa);
                                        }
                                    }                                    
                                }
                            }
                            else
                                this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {   
                MessageBox.Show("Problema no processo de licenciamento/ativação!\n" + ex.Message, "EstacionamentoFacil (Prin21)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bResposta = false;
            }
            return bResposta;
        }

        public bool novaLicenca(out string ssLicenca)
        {
            bool bResposta = false;
            ssLicenca = "";
            try
            {
                Funcoes cFuncao = new Funcoes();
                string sLicença = Microsoft.VisualBasic.Interaction.InputBox("Digite a licença do produto:", "EstacionamentoFacil - Licença");
                string sChave = "";                
                if (sLicença.Trim().Length == 24)
                {
                    if (!cFuncao.conectadoInternet())
                    {
                        Seguranca cSeguranca = new Seguranca();
                        licenciamento cLicenciamento = cSeguranca.retornaDadosLicenca(sLicença);

                        if (cLicenciamento.iCodSistema == 1)
                        {
                            int iMinuto = DateTime.Now.Minute + cSeguranca.iSomaSeguranca;
                            string sContraChave = "";
                            sChave = cSeguranca.sCriptografarString(cLicenciamento.iCodCliente.ToString("D4")) + "@" + cSeguranca.sCriptografarString(iMinuto.ToString("D2"));
                            sContraChave = Microsoft.VisualBasic.Interaction.InputBox("Digite a Contra-chave passada:", "EstacionamentoFacil(" + sChave + ")");
                            if (!sContraChave.Substring(0, 3).Equals("ERR"))
                            {
                                string[] cChave = sContraChave.Split('@');
                                int iMinutoConf = int.Parse(cSeguranca.sDescriptografarString(cChave[1]));
                                iMinutoConf = iMinutoConf - cSeguranca.iSomaSeguranca;
                                if (iMinuto == iMinutoConf)
                                {
                                    bResposta = true;
                                    ssLicenca = sLicença.Trim();
                                }
                                else
                                {
                                    if (MessageBox.Show("Licença inválida!\nDeseja inserir nova licença?", "EstacionamentoFacil (Prin13)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                                        bResposta = novaLicenca(out ssLicenca);
                                    else
                                        bResposta = false;
                                }
                            }
                            else
                            {
                                if (MessageBox.Show("Licença inválida!\nDeseja inserir nova licença?", "EstacionamentoFacil (Prin14)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                                    bResposta = novaLicenca(out ssLicenca);
                                else
                                    bResposta = false;
                            }
                        }
                        else
                        {
                            if (MessageBox.Show("Licença inválida!\nDeseja inserir nova licença?", "EstacionamentoFacil (Prin12)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                                bResposta = novaLicenca(out ssLicenca);
                            else
                                bResposta = false;
                        }
                    }
                    else
                    {
                        Security.Security cSeguranca = new Security.Security();
                        Security.licenciamento cLicenciamento = cSeguranca.retornaDadosLicenca(sLicença);

                        if (cLicenciamento.iCodSistema == 1)
                        {
                            int iMinuto = DateTime.Now.Minute + cSeguranca.iSomaSeguranca();
                            string sContraChave = "";
                            sChave = cSeguranca.sCriptografarString(cLicenciamento.iCodCliente.ToString("D4")) + "@" + cSeguranca.sCriptografarString(iMinuto.ToString("D2"));
                            sContraChave = Microsoft.VisualBasic.Interaction.InputBox("Digite a Contra-chave passada:", "EstacionamentoFacil(" + sChave + ")");
                            if (!sContraChave.Substring(0, 3).Equals("ERR"))
                            {
                                string[] cChave = sContraChave.Split('@');
                                int iMinutoConf = int.Parse(cSeguranca.sDescriptografarString(cChave[1]));
                                iMinutoConf = iMinutoConf - cSeguranca.iSomaSeguranca();
                                if (iMinuto == iMinutoConf)
                                {
                                    bResposta = true;
                                    ssLicenca = sLicença.Trim();
                                }
                                else
                                {
                                    if (MessageBox.Show("Licença inválida!\nDeseja inserir nova licença?", "EstacionamentoFacil (Prin15)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                                        bResposta = novaLicenca(out ssLicenca);
                                    else
                                        bResposta = false;
                                }
                            }
                            else
                            {
                                if (MessageBox.Show("Licença inválida!\nDeseja inserir nova licença?", "EstacionamentoFacil (Prin16)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                                    bResposta = novaLicenca(out ssLicenca);
                                else
                                    bResposta = false;
                            }
                        }
                        else
                        {
                            if (MessageBox.Show("Licença inválida!\nDeseja inserir nova licença?", "EstacionamentoFacil (Prin17)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                                bResposta = novaLicenca(out ssLicenca);
                            else
                                bResposta = false;
                        }
                    }
                }
                else
                {
                    if (MessageBox.Show("Licença inválida!\nDeseja inserir nova licença?", "EstacionamentoFacil (Prin11)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        bResposta = novaLicenca(out ssLicenca);
                    else
                        bResposta = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problema no processo de licenciamento/ativação!\n" + ex.Message, "EstacionamentoFacil (Prin22)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bResposta = false;
            }

            return bResposta;
        }

        public bool contoleVersao()
        {
            Cliente clientes = new Cliente();
            clientes.ArquivoConexao = vEnderecoConfig;
            return clientes.controleVersao();
        }

        public void logarSistema()
        {
            if (contoleVersao())
            {

                if (validarSistema())
                {
                    CamadaDados vConexao = new CamadaDados();
                    if (vConexao.buscarDadosConexao(vEnderecoConfig))
                    {
                        if (vConexao.Conectar(vConexao.vvServidor, vConexao.vvDataBase, vConexao.vvUser, vConexao.vvPass, vConexao.vvPorta))
                        {
                            vvEmpresa = vConexao.buscaDadosEmpresa();
                            txtStatus01.Text = vNomeUsuario.Trim() + " (" + vConexao.buscaNivelAcesso(vNivelAcesso).Trim() + ")";
                            cmdLogar.Visible = false;
                            cmdSairSistema.Visible = true;
                            cmdAlterarSenha.Visible = true;
                            cmdAbout.Visible = true;
                            cmdSuporte.Visible = false;
                            MessageBox.Show("Bem vindo " + vNomeUsuario.Trim() + " ao Sistema EstacionamentoFacil!", "EstacionamentoFacil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            vConexao.inserirAuditoria(12, vvCodigoUsuario, "Usuário entrou no sistema", "");
                            switch (vNivelAcesso)
                            {
                                case 0:
                                    //super-usuario
                                    cmdCadastros.Visible = true;
                                    cmdCadastroSistema.Visible = true;
                                    cmdLancarDespesas.Visible = true;
                                    cmdLancarVenda.Visible = true;
                                    cmdCadCliente.Visible = true;
                                    cmdCadVeiculos.Visible = true;
                                    toolStripSeparator1.Visible = true;
                                    toolStripSeparator2.Visible = true;
                                    toolStripSeparator3.Visible = true;
                                    toolStripSeparator4.Visible = true;
                                    toolStripSeparator5.Visible = true;
                                    cmdAuditoria.Visible = true;
                                    cmdRelatorios.Visible = true;
                                    cmdBackup.Visible = true;
                                    if (vNomeUsuario.Trim().ToUpper().Equals("ADMIN") && vNivelAcesso == 0) cmdSuporte.Visible = true;
                                    verificarUltimoBackup();
                                    break;
                                case 1:
                                    //vendedor
                                    toolStripSeparator1.Visible = true;
                                    cmdCadCliente.Visible = true;
                                    cmdCadVeiculos.Visible = true;
                                    toolStripSeparator2.Visible = true;
                                    cmdLancarDespesas.Visible = true;
                                    break;
                                case 2:
                                    //administração
                                    cmdCadastros.Visible = true;
                                    cmdLancarDespesas.Visible = true;
                                    cmdLancarVenda.Visible = true;
                                    cmdCadCliente.Visible = true;
                                    cmdCadVeiculos.Visible = true;
                                    toolStripSeparator1.Visible = true;
                                    toolStripSeparator2.Visible = true;
                                    //toolStripSeparator3.Visible = true;
                                    toolStripSeparator4.Visible = true;
                                    cmdRelatorios.Visible = true;
                                    toolStripSeparator5.Visible = true;
                                    cmdBackup.Visible = true;
                                    verificarUltimoBackup();
                                    break;
                            }
                        }
                        vConexao.Desconectar();
                    }
                }
                else
                {
                    MessageBox.Show("Licenciamento não executado!\nO sistema será finalizado!", "EstacionamentoFacil (Prin20)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }

        /// <summary>
        /// Função para ativação do computador
        /// </summary>
        /// <returns>Retorna verdadeiro ou falso, mediante a execução da função.</returns>
        public bool ativarComputador(empresa obEmpresa)
        {
            bool bResposta = false;
            Seguranca cSeguranca = new Seguranca();
            Funcoes cFuncoes = new Funcoes();
            string sNumHD = cFuncoes.GetVolumeSerial("C");
            string sAtivacao = "";

            if (cFuncoes.conectadoInternet())
            {
                Security.Security cSeguranca2 = new Security.Security();
                if (cSeguranca2.ativarComputador(cFuncoes.retirarPonto(obEmpresa.licenca), sNumHD, Environment.MachineName, DateTime.Now, out sAtivacao))
                {
                    cFuncoes.SetStringValue("EstacionamentoFacil", "Ativação", sAtivacao);
                    bResposta = true;
                }
                else
                {
                    MessageBox.Show("Computador não ativado!\nEntre em contato com a empresa responsável!\n" + cSeguranca2.sMensagemErro, "EstacionamentoFacil (Prin07)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cFuncoes.SetStringValue("EstacionamentoFacil", "Ativação", sAtivacao);
                    bResposta = false;
                }
            }
            else
            {
                //abrir tela de ativação por telefone
                sAtivacaoTelefone = "";
                bAtivacaoTelefone = false;
                new Ativacao.FrmAtivacaoTelefone(this, obEmpresa).ShowDialog();
                cFuncoes.SetStringValue("EstacionamentoFacil", "Ativação", sAtivacaoTelefone);
                bResposta = bAtivacaoTelefone;
                if(bResposta)
                    MessageBox.Show("Computador ativado com sucesso!", "EstacionamentoFacil (Prin08)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Ativação não executada!\nEntre em contato com a empresa responsável!", "EstacionamentoFacil (Prin09)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return bResposta;
        }

        /// <summary>
        /// Verificar ativação do produto
        /// </summary>
        /// <param name="obEmpresa">Objeto Empresa</param>
        /// <returns>Retorna 0 - OK, 1 - Chave errada, 2 - Sem chave</returns>
        public int verificarAtivacao(empresa obEmpresa)
        {
            int iResposta = 0;
            string sChaveAtivacao = "";
            string sChaveDefault = "";
            string sNumHD = "";
            try
            {
                Funcoes cFuncoes = new Funcoes();
                
                if (!cFuncoes.conectadoInternet())
                {
                    Seguranca cSeguranca = new Seguranca();
                    sNumHD = cFuncoes.GetVolumeSerial("C");
                    sChaveDefault = cSeguranca.sCriptografarString(cSeguranca.getCodigoCliente(cFuncoes.retirarPonto(obEmpresa.licenca)).ToString("D5")) + "." + cSeguranca.sCriptografarString(sNumHD) + "." + cSeguranca.sCriptografarString("P");
                    cFuncoes.CheckRegistryKey("EstacionamentoFacil");
                    sChaveAtivacao = cFuncoes.GetStringValue("EstacionamentoFacil", "Ativação", sChaveDefault);

                    if (!sChaveAtivacao.Equals(sChaveDefault))
                    {

                        string[] cChave = sChaveAtivacao.Split('.');

                        ///verificar se o cliente é o mesmo da chave
                        if (cSeguranca.getCodigoCliente(cFuncoes.retirarPonto(obEmpresa.licenca)) != int.Parse(cSeguranca.sDescriptografarString(cChave[0])))
                            iResposta = 1;

                        //verificar o num. do hd se é o mesmo
                        if (!sNumHD.Equals(cSeguranca.sDescriptografarString(cChave[1])))
                            iResposta = 1;

                        //verificar a situacao da ativação
                        if (!cSeguranca.sDescriptografarString(cChave[2]).Equals("A"))
                            iResposta = 1;
                    }
                    else
                        iResposta = 2;
                }
                else
                {
                    Security.Security cSeguranca = new Security.Security();
                    sNumHD = cFuncoes.GetVolumeSerial("C");
                    sChaveDefault = cSeguranca.sCriptografarString(cSeguranca.getCodigoCliente(cFuncoes.retirarPonto(obEmpresa.licenca)).ToString("D5")) + "." + cSeguranca.sCriptografarString(sNumHD) + "." + cSeguranca.sCriptografarString("P");
                    cFuncoes.CheckRegistryKey("EstacionamentoFacil");
                    sChaveAtivacao = cFuncoes.GetStringValue("EstacionamentoFacil", "Ativação", sChaveDefault);

                    if (!sChaveAtivacao.Equals(sChaveDefault))
                    {

                        string[] cChave = sChaveAtivacao.Split('.');

                        ///verificar se o cliente é o mesmo da chave
                        if (cSeguranca.getCodigoCliente(cFuncoes.retirarPonto(obEmpresa.licenca)) != int.Parse(cSeguranca.sDescriptografarString(cChave[0])))
                            iResposta = 1;

                        //verificar o num. do hd se é o mesmo
                        if (!sNumHD.Equals(cSeguranca.sDescriptografarString(cChave[1])))
                            iResposta = 1;

                        //verificar a situacao da ativação
                        if (!cSeguranca.sDescriptografarString(cChave[2]).Equals("A"))
                            iResposta = 1;

                        //verificar a situacao de ativacao na internet
                        if ((iResposta != 1) && (DateTime.Now.Hour > 8 && DateTime.Now.Hour < 12) && (DateTime.Now.DayOfWeek == DayOfWeek.Monday || DateTime.Now.DayOfWeek == DayOfWeek.Thursday || DateTime.Now.DayOfWeek == DayOfWeek.Friday))
                        {   
                            cSeguranca.sMensagemErro = "";
                            string sSituacaoAtivacao = cSeguranca.situacaoAtivacao(cFuncoes.retirarPonto(obEmpresa.licenca), sNumHD);
                            sSituacaoAtivacao = sSituacaoAtivacao.Trim();
                            if (sSituacaoAtivacao.Length > 0)
                            {
                                iResposta = 0;
                                /*
                                switch (sSituacaoAtivacao)
                                {
                                    case "A":
                                        iResposta = 0;
                                        break;
                                    case "S":
                                        iResposta = 3;
                                        MessageBox.Show("Atenção!!!\nAtivação deste computador está suspensa!", "EstacionamentoFacil (Prin03c)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        break;
                                    case "C":
                                        iResposta = 3;
                                        MessageBox.Show("Atenção!!!\nAtivação deste computador está cancelada!", "EstacionamentoFacil (Prin03d)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        break;
                                    case "F":
                                        iResposta = 3;
                                        MessageBox.Show("Atenção!!!\nAtivação deste computador está finalizada!", "EstacionamentoFacil (Prin03e)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        break;
                                }
                                 * */
                            }
                            else
                            {
                                MessageBox.Show("Erro ao buscar chave de ativação!\n" + cSeguranca.sMensagemErro, "EstacionamentoFacil (Prin03b)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                iResposta = 1;
                            }
                        }
                    }
                    else
                        iResposta = 2;
                }                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar chave de ativação!\n" + ex.Message, "EstacionamentoFacil (Prin03)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                iResposta = 1;
            }
            return iResposta;
        }

        private void limparVariaveis(byte bTipo = 0)
        {
            if (bTipo == 1)
            {
                CamadaDados vConexao = new CamadaDados();
                if (vConexao.buscarDadosConexao(vEnderecoConfig))
                {
                    if (vConexao.Conectar(vConexao.vvServidor, vConexao.vvDataBase, vConexao.vvUser, vConexao.vvPass, vConexao.vvPorta))
                    {
                        vConexao.inserirAuditoria(13, vvCodigoUsuario, "Usuário saiu do sistema", "");
                    }
                }
            }
            cmdLogar.Visible = true;
            cmdSairSistema.Visible = false;
            cmdCadastros.Visible = false;
            cmdCadastroSistema.Visible = false;
            cmdAlterarSenha.Visible = false;
            cmdAbout.Visible = false;
            cmdLancarDespesas.Visible = false;
            cmdLancarVenda.Visible = false;
            cmdRelatorios.Visible = false;
            cmdBackup.Visible = false;
            cmdAuditoria.Visible = false;
            cmdCadVeiculos.Visible = false;
            cmdCadCliente.Visible = false;
            vLogado = false;
            vNomeUsuario = "";
            txtStatus01.Text = "";
            toolStripSeparator1.Visible = false;
            toolStripSeparator2.Visible = false;
            toolStripSeparator3.Visible = false;
            toolStripSeparator4.Visible = false;
            toolStripSeparator5.Visible = false;
            cmdSuporte.Visible = true;
            ccEmpresa = null;
        }
        public void dispararLinkToken(string sLink)
        {
            string[] slink = sLink.Split('#');
            switch (slink[0].ToString())
            {
                case "VEICULO":
                    CamadaDados vConexao = new CamadaDados();
                    if (vConexao.buscarDadosConexao(vEnderecoConfig))
                    {
                        if (vConexao.Conectar(vConexao.vvServidor, vConexao.vvDataBase, vConexao.vvUser, vConexao.vvPass, vConexao.vvPorta))
                        {
                            Veiculos cVeiculo = new Veiculos();
                            cVeiculo.ArquivoConexao = vEnderecoConfig;
                            carro cCarro = new carro();
                            cCarro = cVeiculo.pesquisarCarro(int.Parse(slink[1].ToString()));
                            if (cCarro.Codigo > 0)
                            {
                                abrirCadCarro(this);
                                vTela_FrmCadCarro.inicioCarro(cCarro);
                            }
                        }
                    }
                    break;
            }
        }

        private string gerarChaveTela()
        {            
            string sResposta = "";
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar chave de tela!\n" + ex.Message, "EstacionamentoFacil (Prin02)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return sResposta;
        }

        public bool liberarTela()
        {            
            bool bResposta = false;
            Seguranca cSeguranca;
            DateTime dDataAgora = DateTime.Now;
            string sSenha = "EST" + dDataAgora.Month.ToString() + dDataAgora.Minute.ToString();
            try
            {
                CamadaDados cConexao = new CamadaDados();
                if (cConexao.buscarDadosConexao(vEnderecoConfig))
                {
                    if (cConexao.Conectar(cConexao.vvServidor, cConexao.vvDataBase, cConexao.vvUser, cConexao.vvPass, cConexao.vvPorta))
                    {
                        empresa cEmpresa = new empresa();
                        Funcoes cFuncoes = new Funcoes();
                        cEmpresa = cConexao.buscaDadosEmpresa();
                        cEmpresa.licenca = cFuncoes.retirarPonto(cEmpresa.licenca);

                        cSeguranca = new Seguranca();
                        string sChave = cSeguranca.gerarChaveTela(DateTime.Now, cEmpresa.licenca);
                        string sContraChave = Microsoft.VisualBasic.Interaction.InputBox("Digite a contra-chave:", "Liberação de tela (" + sChave + ")");
                        if (sContraChave.Length > 0)
                        {
                            if (!sContraChave.ToUpper().Equals(cSeguranca.sSenhaDireta)){                                
                                if (!sContraChave.ToUpper().Equals(sSenha))
                                    bResposta = cSeguranca.validarChave(sChave, sContraChave);
                                else
                                    bResposta = true;
                            }
                            else
                                bResposta = true;
                        }
                    }
                    else
                    {
                        bResposta = false;
                        cSeguranca = new Seguranca();
                        string sContraChave = Microsoft.VisualBasic.Interaction.InputBox("Digite a contra-chave:", "Liberação de tela (SUPORTE)");
                        if (sContraChave.Length > 0)
                        {
                            if (sContraChave.ToUpper().Equals(cSeguranca.sSenhaDireta))
                                bResposta = true;
                            else
                                if (sContraChave.ToUpper().Equals(sSenha))
                                    bResposta = true;
                        }
                    }
                }
                else
                {
                    cSeguranca = new Seguranca();
                    string sContraChave = Microsoft.VisualBasic.Interaction.InputBox("Digite a contra-chave:", "Liberação de tela (SUPORTE)");
                    if (sContraChave.Length > 0)
                    {
                        if (sContraChave.ToUpper().Equals(cSeguranca.sSenhaDireta))
                            bResposta = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao liberar tela!\n" + ex.Message, "EstacionamentoFacil (Prin01)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bResposta;
        }

        /// <summary>
        /// Função para exibir o splash mediante a conexão com a internet
        /// </summary>
        public void dispararSplash()
        {
            Funcoes cFuncoes = new Funcoes();
            /*if (cFuncoes.conectadoInternet())
                new splash.SplashWindow().ShowDialog();
            else*/
                new splash.Splash().ShowDialog();
        }

        public FrmPrincipal()
        {   
            InitializeComponent();
            vLogado = false;
            cmdSairSistema.Visible = false;
            cmdLogar.Visible = true;
            toolStripSeparator1.Visible = true;
            toolStripSeparator2.Visible = true;
            dispararSplash();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            limparVariaveis();
            //abrirLogin();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if(liberarTela())
                abrirSuportes();    
            //abrirSenhaAcesso(0);
        }

        private void cmdSairSistema_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair de sua conta?", "EstacionamentoFacil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                limparVariaveis(1);
            }
        }

        private void municípioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirCadMunicipio();
        }

        private void cmdLogar_Click(object sender, EventArgs e)
        {
            abrirLogin();
        }

        private void localidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirCadLocalidade();
        }

        private void bairroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirCadBairro();
        }

        private void logradouroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirCadLogradouro();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {            
            var vTela = this.MdiChildren.OfType<FrmTeste>().FirstOrDefault();
            if (vTela == null)
            {
                vTelaTeste = new FrmTeste();
                vTelaTeste.MdiParent = this;
                vTelaTeste.WindowState = FormWindowState.Normal;
                vTelaTeste.StartPosition = FormStartPosition.CenterScreen;                
                vTelaTeste.Show();
            }
            else
            {
                vTelaTeste.Focus();
            }
        }

        private void operadorasTelefoniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirCadOperadora();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirCadCliente(this);
        }

        private void marcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirCadMarca();
        }

        private void opcionaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirCadOpcionais();
        }

        private void carroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirCadCarro(this);
        }

        private void cmdLancarDespesas_Click(object sender, EventArgs e)
        {
            abrirCadDespesa(this, null, true);
        }

        private void vendedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirCadVendedor(this);
        }

        private void vendasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            abrirCadVendas(this);
        }

        private void cmdLancarVenda_Click(object sender, EventArgs e)
        {
            abrirCadVendas(this);
        }

        private void cmdAlterarSenha_Click(object sender, EventArgs e)
        {
            abrirAlterarSenha(this);
        }

        private void usuáriosDoSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirCadUsuario(this);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            abrirAuditoria(this);
        }

        private void empresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirCadEmpresa(this);
        }

        private void clientesCadastradosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirPesq_ClientesCadastrados(this);
        }

        private void veículosCadastradosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirPesq_VeiculosCadastrados(this);
        }

        private void despesasComVeículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirCadDespesa(this, null, true);
            //abrirPesq_ExtratoDespesas(this);
        }

        private void extratoIndividualDeDespesasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirPesq_TotalDespesas(this);
        }

        private void vendasPorPeríodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirPesq_Vendas(this);
        }

        private void comissõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirPesq_Comissao(this);
        }

        private void cmdCadCliente_Click(object sender, EventArgs e)
        {
            abrirCadCliente(this);
        }

        private void cmdCadVeiculos_Click(object sender, EventArgs e)
        {
            abrirCadCarro(this);
        }

        private void FrmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (!cmdLogar.Visible)
                {
                    CamadaDados vConexao = new CamadaDados();
                    if (vConexao.buscarDadosConexao(vEnderecoConfig))
                    {
                        if (vConexao.Conectar(vConexao.vvServidor, vConexao.vvDataBase, vConexao.vvUser, vConexao.vvPass, vConexao.vvPorta))
                        {
                            vConexao.inserirAuditoria(13, vvCodigoUsuario, "Usuário saiu do sistema - GERAL", "");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao sair do sistema!\n" + ex.Message, "EstacionamentoFacil (Prin30)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmdAbout_Click(object sender, EventArgs e)
        {
            new FrmAboutBox1().ShowDialog();
        }

        private void cmdBackup_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente fazer o backup do banco de dados?", "EstacionamentoFacil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                backupBanco();
            }
        }

        private void cmdCadVeiculos_Click_1(object sender, EventArgs e)
        {
            abrirCadCarro(this);
        }

        private void despesasComVeículosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            abrirPesq_ExtratoDespesas(this);
        }
    }
}
