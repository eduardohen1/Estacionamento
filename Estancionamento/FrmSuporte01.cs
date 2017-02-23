using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Estancionamento
{
    public partial class FrmSuporte01 : Form
    {
        private FrmPrincipal vFrmPrincipal;
        private Conexao vConexao;

        public FrmSuporte01(FrmPrincipal frmPrincipal)
        {
            InitializeComponent();
            txtUsuario.Focus();
            vFrmPrincipal = frmPrincipal;
            vConexao = new Conexao();
        }

        private bool validarTela()
        {
            bool vResposta = true;
            if (txtUsuario.Text.Length == 0)
            {
                MessageBox.Show("Digite o usuário para cadastramento.\nOperação cancelada!","EstacionamentoFacil (FSp01)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                vResposta = false;
            }
            if (vResposta && txtSenha.Text.Length == 0)
            {
                MessageBox.Show("Digite a senha para cadastramento.\nOperação cancelada!", "EstacionamentoFacil (FSp02)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                vResposta = false;
            }
            return vResposta;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string vEnderecoConfig = vFrmPrincipal.vvEnderecoConfig;
            string sSQL = "SELECT COUNT(*) vConta FROM Usuarios WHERE usuario = @usuario";
            string sSenha = "";
            int iConta = 0;
            int iTipo = 0;
            string sDica = "super";
            Funcoes vFuncoes = new Funcoes();
            SqlCommand vComando;
            SqlDataReader vLer;

            try
            {
                if (validarTela())
                {
                    if (vConexao.buscarDadosConexao(vEnderecoConfig))
                    {
                        if (vConexao.Conectar(vConexao.vvServidor, vConexao.vvDataBase, vConexao.vvUser, vConexao.vvPass, vConexao.vvPorta))
                        {
                            vComando = new SqlCommand(sSQL, vConexao.conexaoPrincipal);
                            vComando.Parameters.Add(new SqlParameter("@usuario",txtUsuario.Text));
                            vLer = vComando.ExecuteReader();
                            if (vLer.HasRows)
                            {
                                if (vLer.Read())
                                {
                                    iConta = int.Parse(vLer["vConta"].ToString());
                                }
                            }
                            if (iConta > 0)
                            {
                                MessageBox.Show("Já existe este Login cadastrado.\nVerifique!!!", "EstacionamentoFacil (FSp03)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                                vLer.Dispose();
                                vComando.Dispose();
                            }
                            else
                            {
                                sSenha = txtSenha.Text;
                                sSenha = vFuncoes.Criptografar(sSenha);
                                vLer.Dispose();

                                sSQL = "INSERT INTO Usuarios(usuario, senha, tipo, dica_senha, nomeusuario) VALUES(@usuario, @senha, @tipo, @dica_senha, @NomeUsuario)";
                                vComando = new SqlCommand(sSQL, vConexao.conexaoPrincipal);
                                vComando.Parameters.Add(new SqlParameter("@usuario", txtUsuario.Text.Trim()));
                                vComando.Parameters.Add(new SqlParameter("@senha", sSenha));
                                vComando.Parameters.Add(new SqlParameter("@tipo", iTipo));
                                vComando.Parameters.Add(new SqlParameter("@dica_senha", sDica));
                                vComando.Parameters.Add(new SqlParameter("@NomeUsuario", txtUsuario.Text.Trim()));
                                vComando.ExecuteNonQuery();
                                vComando.Dispose();
                                MessageBox.Show("Usuário inserido com sucesso!!!", "EstacionamentoFacil (FSp05)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                                
                                CamadaDados vvConexao = new CamadaDados();
                                if (vvConexao.buscarDadosConexao(vFrmPrincipal.sEnderecoArquivoConexao))
                                {
                                    if (vvConexao.Conectar(vConexao.vvServidor, vConexao.vvDataBase, vConexao.vvUser, vConexao.vvPass, vConexao.vvPorta))
                                    {
                                        vvConexao.inserirAuditoria(15, vFrmPrincipal.vvCodigoUsuario, "Criado superusuario: " + txtUsuario.Text.Trim(), this.Text.Trim());
                                    }
                                }
                            }
                            vConexao.Desconectar();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao inserir dados de Superusuário!\n" + ex.Message, "EstacionamentoFacil (FSp04)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
    }
}
