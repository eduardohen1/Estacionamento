using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Estancionamento
{
    public partial class FrmAlterarSenha : Form
    {
        FrmPrincipal vTelaPrincipal;
        Usuarios cUsuarios;
        usuario obUsuario;
        Funcoes cFuncoes;
        string sArquivoConexao;

        public FrmAlterarSenha(FrmPrincipal vvTelaPrincipal, usuario ccUsuario, string ssArquivoConexao)
        {
            InitializeComponent();
            vTelaPrincipal = vvTelaPrincipal;
            obUsuario = ccUsuario;
            sArquivoConexao = ssArquivoConexao;
        }

        private void FrmAlterarSenha_Load(object sender, EventArgs e)
        {
            lblNomeUsuario.Text = obUsuario.nomeusuario;
        }

        private bool validaTela()
        {
            bool bResposta = true;
            cFuncoes = new Funcoes();
            if (txtSenhaAtual.Text.Length == 0)
            {
                MessageBox.Show("Digite a senha atual! ", "EstacionamentoFacil (FrmAltS01)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bResposta = false;
            }
            if (txtNovaSenha.Text.Length == 0 && bResposta)
            {
                MessageBox.Show("Digite a nova senha! ", "EstacionamentoFacil (FrmAltS02)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bResposta = false;
            }
            if (txtRepitaSenha.Text.Length == 0 && bResposta)                
            {
                MessageBox.Show("Repita a nova senha! ", "EstacionamentoFacil (FrmAltS03)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bResposta = false;  
            }
            if (txtDica.Text.Length == 0 && bResposta)
            {
                MessageBox.Show("Digite a dica da nova senha! ", "EstacionamentoFacil (FrmAltS04)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bResposta = false;
            }
            if (!txtSenhaAtual.Text.Equals(cFuncoes.Descriptografar(obUsuario.senha)) && bResposta)
            {
                MessageBox.Show("A senha atual digitada não confere com a cadastrada! ", "EstacionamentoFacil (FrmAltS05)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bResposta = false;
            }
            if (!txtNovaSenha.Text.Equals(txtRepitaSenha.Text) && bResposta)
            {
                MessageBox.Show("A nova senha não confere com a sua repetição! ", "EstacionamentoFacil (FrmAltS06)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bResposta = false;
            }
            return bResposta;
        }

        private void gravarNovaSenha()
        {
            cUsuarios = new Usuarios();
            cFuncoes = new Funcoes();
            cUsuarios.ArquivoConexao = sArquivoConexao;
            if (validaTela())
            {
                if (cUsuarios.alterarSenhaUsuario(obUsuario, cFuncoes.Criptografar(txtNovaSenha.Text), txtDica.Text, vTelaPrincipal.vvCodigoUsuario,this.Name))
                {
                    MessageBox.Show("Senha alterada com sucesso!", "EstacionamentoFacil (FrmAltS07)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vTelaPrincipal.vvSenhaUsuario = cFuncoes.Criptografar(txtNovaSenha.Text);
                    this.Close();
                }
            }
        }

        private void sairTela()
        {
            this.Close();
        }

        private void cmdGravar_Click(object sender, EventArgs e)
        {
            gravarNovaSenha();
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            sairTela();
        }

    }
}
