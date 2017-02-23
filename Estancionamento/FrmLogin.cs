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
    public partial class FrmLogin : Form
    {
        private CamadaDados vConexao;
        private FrmPrincipal vFrmPrincipal;

        public FrmLogin(FrmPrincipal frmPrincipal)
        {
            InitializeComponent();
            vFrmPrincipal = frmPrincipal;
            vConexao = new CamadaDados();
        }
        
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            string vEnderecoConfig = vFrmPrincipal.vvEnderecoConfig;
            bool bEntrada = true;
            if (vConexao.buscarDadosConexao(vEnderecoConfig))
            {
                if (vConexao.Conectar(vConexao.vvServidor, vConexao.vvDataBase, vConexao.vvUser, vConexao.vvPass, vConexao.vvPorta))
                {
                    txtUsuario.Focus();
                }
                else
                {
                    bEntrada = false;
                    /*
                    this.Dispose();
                    this.Close();*/
                }
            }
            if (!bEntrada) cmdConectar.Enabled = false;
        }

        private bool validarTela()
        {
            bool bResposta = true;
            if (txtUsuario.Text.Length == 0)
            {
                bResposta = false;
                MessageBox.Show("Usuário em branco. Verifique! ", "EstacionamentoFacil (FmL01)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Focus();
            }
            if (txtSenha.Text.Length == 0 && bResposta)
            {
                bResposta = false;
                MessageBox.Show("Senha em branco. Verifique! ", "EstacionamentoFacil (FmL02)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSenha.Focus();
            }
            return bResposta;
        }

        private void fecharTela()
        {
            vConexao.Desconectar();
            this.Dispose();
            this.Close();
        }

        private void conectar()
        {
            cmdConectar.Enabled = false;
            cmdConectar.Text = "Conectando...";
            int iSituacao = 0;
            if (validarTela())
            {
                SqlDataReader drLer = vConexao.pesquisaUsuario(txtUsuario.Text, txtSenha.Text);
                if (drLer.HasRows)
                {
                    if (drLer.Read())
                    {

                        iSituacao = int.Parse(drLer["situacao"].ToString());

                        if (iSituacao == 0)
                        {
                            vFrmPrincipal.vvLogado = true;
                            vFrmPrincipal.vvNivelAcesso = int.Parse(drLer["tipo"].ToString());
                            vFrmPrincipal.vvNomeUsuario = drLer["nomeusuario"].ToString();
                            vFrmPrincipal.vvCodigoUsuario = int.Parse(drLer["cod_usuario"].ToString());
                            vFrmPrincipal.vvSituacaoUsuario = int.Parse(drLer["situacao"].ToString());
                            vFrmPrincipal.vvObservcaoUsuario = drLer["observacao"].ToString();
                            vFrmPrincipal.vvUsuario = drLer["usuario"].ToString();
                            vFrmPrincipal.vvSenhaUsuario = drLer["senha"].ToString();
                            vFrmPrincipal.logarSistema();
                            fecharTela();
                        }
                        else
                        {
                            MessageBox.Show("Usuário inativo/cancelado!\nProcure o administrador do sistema", "EstacionamentoFacil (FmL03b)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    drLer.Dispose();
                    drLer.Close();
                }
                else
                {
                    MessageBox.Show("Usuário e/ou Senha inválidos! ", "EstacionamentoFacil (FmL03)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    fecharTela();
                }
            }
            cmdConectar.Enabled = true;
            cmdConectar.Text = "Conectar";
        }

        private void cmdConectar_Click(object sender, EventArgs e)
        {
            conectar();
        }

        private void cmdSair_Click(object sender, EventArgs e)
        {
            fecharTela();
        }

        private void txtUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtSenha.Focus();
        }

        private void txtSenha_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) conectar();
        }
    }
}
