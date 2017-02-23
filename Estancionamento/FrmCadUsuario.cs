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
    public partial class FrmCadUsuario : Form
    {

        Usuarios cUsuario;
        FrmPrincipal vTelaPrincipal;
        Funcoes cFuncoes;
        string sArquivoConexao;

        public FrmCadUsuario(string vArquivoConexao, FrmPrincipal vvTelaPrincipal)
        {
            InitializeComponent();
            sArquivoConexao = vArquivoConexao;
            vTelaPrincipal = vvTelaPrincipal;
        }

        private void FrmCadUsuario_Load(object sender, EventArgs e)
        {
            ve_se_existe();
        }

        private void limparTela(byte bTipo)
        {
            switch (bTipo)
            {
                case 0:
                    cmbUsuario.Items.Clear();
                    cmbTipo.Items.Clear();
                    cmbSituacao.Items.Clear();
                    break;
                case 1:
                    cmbUsuario.Text = "";
                    cmbTipo.Text = "";
                    cmbSituacao.Text = "";
                    break;
            }
            txtSenha.Clear();
            txtDica.Clear();
            txtNomeUsuario.Clear();
            txtObservacao.Clear();
        }

        private object retornaCodigoSituacao(byte bTipo, string sSituacao = "", int iCodigo = 0)
        {
            int iResposta = 0;
            string sResposta = "";
            if (bTipo == 0)
            {
                switch (sSituacao)
                {
                    case "ATIVO":
                        iResposta = 0;
                        break;
                    case "INATIVO":
                        iResposta = 1;
                        break;
                    case "CANCELADO":
                        iResposta = 2;
                        break;                    
                }
                return iResposta;
            }
            else
            {
                switch (iCodigo)
                {
                    case 0:
                        sResposta = "ATIVO";
                        break;
                    case 1:
                        sResposta = "INATIVO";
                        break;
                    case 2:
                        sResposta = "CANCELADO";
                        break;
                }
                return sResposta;
            }

        }

        private void ve_se_existe()
        {
            try
            {
                limparTela(0);
                ComboBoxItem cboItem;

                List<usuario> lstUsuario = new List<usuario>();
                cUsuario = new Usuarios();
                cUsuario.ArquivoConexao = sArquivoConexao;
                lstUsuario = cUsuario.buscaTodosUsuario(5);
                if (lstUsuario != null)
                {
                    if (lstUsuario.Count > 0)
                    {
                        foreach (usuario ccUsuario in lstUsuario)
                        {
                            cboItem = new ComboBoxItem();
                            cboItem.Value = ccUsuario.cod_usuario;
                            cboItem.Text = ccUsuario.sUsuario.Trim();
                            cmbUsuario.Items.Add(cboItem);
                        }
                    }
                }

                List<nivelAcesso> lstNivelAcesso = new List<nivelAcesso>();
                lstNivelAcesso = cUsuario.buscaNivelAcesso();
                if (lstNivelAcesso != null)
                {
                    if (lstNivelAcesso.Count > 0)
                    {
                        foreach (nivelAcesso cNivelAcesso in lstNivelAcesso)
                        {
                            cboItem = new ComboBoxItem();
                            cboItem.Value = cNivelAcesso.codigo;
                            cboItem.Text = cNivelAcesso.nivelacesso;
                            cmbTipo.Items.Add(cboItem);
                        }
                    }
                }

                string[] sSituacoes = { "ATIVO", "INATIVO", "CANCELADO" };
                foreach (string sSituacao in sSituacoes)
                {
                    cboItem = new ComboBoxItem();
                    cboItem.Value = int.Parse(retornaCodigoSituacao(0, sSituacao).ToString());
                    cboItem.Text = sSituacao;
                    cmbSituacao.Items.Add(cboItem);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir janela de cadastro de usuário!\n" + ex.Message, "EstacionamentoFacil (FrmCadU01)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//ve_se_existe

        private bool validaTela()
        {
            bool bResposta = true;
            if (cmbUsuario.Text.Length == 0)
            {
                MessageBox.Show("Digite o usuário! ", "EstacionamentoFacil (FrmCadU02)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bResposta = false;
            }
            if (cmbTipo.Text.Length == 0 && bResposta)
            {
                MessageBox.Show("Selecione o tipo de usuário! ", "EstacionamentoFacil (FrmCadU03)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bResposta = false;
            }
            if (txtSenha.Text.Length == 0 && bResposta)
            {
                MessageBox.Show("Digite a senha do usuário! ", "EstacionamentoFacil (FrmCadU04)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bResposta = false;
            }
            if (txtDica.Text.Length == 0 && bResposta)
            {
                MessageBox.Show("Digite a dica do usuário! ", "EstacionamentoFacil (FrmCadU05)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bResposta = false;
            }
            if (txtNomeUsuario.Text.Length == 0 && bResposta)
            {
                MessageBox.Show("Digite o nome do usuário! ", "EstacionamentoFacil (FrmCadU06)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bResposta = false;
            }
            if (cmbSituacao.Text.Length == 0 && bResposta)
            {
                MessageBox.Show("Selecione a situação do usuário! ", "EstacionamentoFacil (FrmCadU07)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bResposta = false;
            }
            if (txtObservacao.Text.Length == 0) txtObservacao.Text = " ";
            return bResposta;
        }//validatela

        private void exibirDadosUsuario(usuario obUsuario)
        {
            try
            {
                limparTela(2);
                cUsuario = new Usuarios();
                cFuncoes = new Funcoes();
                cUsuario.ArquivoConexao = sArquivoConexao;

                cmbTipo.Text = cUsuario.buscaNivelAcesso(obUsuario.tipo).nivelacesso;
                txtSenha.Text = cFuncoes.Descriptografar(obUsuario.senha);
                txtDica.Text = obUsuario.dica_senha;
                txtNomeUsuario.Text = obUsuario.nomeusuario;
                cmbSituacao.Text = retornaCodigoSituacao(1, "", obUsuario.situacao).ToString();
                txtObservacao.Text = obUsuario.observacao.Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao exibir dados de usuario!\n" + ex.Message, "EstacionamentoFacil (FrmCadU08)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//exibirdadosusuario

        private void gravarUsuario()
        {
            ComboBoxItem cmbItens01 = new ComboBoxItem();
            ComboBoxItem cmbItens02;
            cUsuario = new Usuarios();
            cFuncoes = new Funcoes();
            usuario obUsuario;
            cUsuario.ArquivoConexao = sArquivoConexao;

            try
            {
                if (validaTela())
                {
                    cmbItens01 = (ComboBoxItem)cmbUsuario.SelectedItem;
                    obUsuario = new usuario();
                    if (cmbItens01 != null)
                    {
                        //atualizar
                        obUsuario.cod_usuario = int.Parse(cmbItens01.Value.ToString());
                        obUsuario.dica_senha = txtDica.Text.Trim();
                        obUsuario.nomeusuario = txtNomeUsuario.Text.Trim();
                        obUsuario.observacao = txtObservacao.Text.Trim();
                        obUsuario.senha = cFuncoes.Criptografar(txtSenha.Text.Trim());
                        obUsuario.sUsuario = cmbItens01.Text;

                        cmbItens02 = new ComboBoxItem();
                        cmbItens02 = (ComboBoxItem)cmbSituacao.SelectedItem;
                        obUsuario.situacao = int.Parse(cmbItens02.Value.ToString());

                        cmbItens02 = new ComboBoxItem();
                        cmbItens02 = (ComboBoxItem)cmbTipo.SelectedItem;
                        obUsuario.tipo = int.Parse(cmbItens02.Value.ToString());

                        if (cUsuario.inserirAtualizarUsuario(obUsuario, 1))
                        {
                            MessageBox.Show("Usuário atualizado com sucesso!", "EstacionamentoFacil (FrmCadU09)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            limparTela(1);
                            ve_se_existe();
                            cmbTipo.Focus();
                        }
                    }
                    else
                    {
                        //inserir
                        obUsuario.cod_usuario = 0;
                        obUsuario.dica_senha = txtDica.Text.Trim();
                        obUsuario.nomeusuario = txtNomeUsuario.Text.Trim();
                        obUsuario.observacao = txtObservacao.Text.Trim();
                        obUsuario.senha = cFuncoes.Criptografar(txtSenha.Text.Trim());
                        obUsuario.sUsuario = cmbUsuario.Text;

                        cmbItens02 = new ComboBoxItem();
                        cmbItens02 = (ComboBoxItem)cmbSituacao.SelectedItem;
                        obUsuario.situacao = int.Parse(cmbItens02.Value.ToString());

                        cmbItens02 = new ComboBoxItem();
                        cmbItens02 = (ComboBoxItem)cmbTipo.SelectedItem;
                        obUsuario.tipo = int.Parse(cmbItens02.Value.ToString());

                        if (cUsuario.inserirAtualizarUsuario(obUsuario, 0))
                        {
                            MessageBox.Show("Usuário inserido com sucesso!", "EstacionamentoFacil (FrmCadU10)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            limparTela(1);
                            ve_se_existe();
                            cmbTipo.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gravar dados de usuario!\n" + ex.Message, "EstacionamentoFacil (FrmCadU11)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }//gravarUsuario

        private void selecionaUsuario()
        {
            ComboBoxItem cmbItem = new ComboBoxItem();
            cmbItem = (ComboBoxItem)cmbUsuario.SelectedItem;
            cUsuario = new Usuarios();
            cUsuario.ArquivoConexao = sArquivoConexao;
            usuario obUsuario = cUsuario.buscaDadosUsuario(int.Parse(cmbItem.Value.ToString()));
            exibirDadosUsuario(obUsuario);
        }//selecionaUsuario

        private void lostUsuario()
        {
            limparTela(2);
            if (cmbUsuario.Text.Length > 0)
            {
                ComboBoxItem cmbItem = new ComboBoxItem();
                cmbItem = (ComboBoxItem)cmbUsuario.SelectedItem;
                if (cmbItem != null)
                {
                    cUsuario = new Usuarios();
                    cUsuario.ArquivoConexao = sArquivoConexao;
                    usuario obUsuario = cUsuario.buscaDadosUsuario(int.Parse(cmbItem.Value.ToString()));
                    exibirDadosUsuario(obUsuario);
                }
            }
        }//lsotUsuario

        private void sairTela()
        {
            this.Close();
        }

        private void cmbUsuario_SelectedValueChanged(object sender, EventArgs e)
        {
            selecionaUsuario();
        }

        private void cmbUsuario_Leave(object sender, EventArgs e)
        {
            lostUsuario();
        }

        private void cmbUsuario_Enter(object sender, EventArgs e)
        {
            limparTela(1);
        }

        private void cmdGravar_Click(object sender, EventArgs e)
        {
            gravarUsuario();
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            sairTela();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ComboBoxItem cmbItem = new ComboBoxItem();
            if (cmbItem != null)
            {
                cUsuario = new Usuarios();
                cUsuario.ArquivoConexao = sArquivoConexao;
                usuario obUsuario;

                obUsuario = cUsuario.buscaDadosUsuario(int.Parse(cmbItem.Value.ToString()));
                string sNome = Microsoft.VisualBasic.Interaction.InputBox("Qual o novo nome?", "Novo nome",cmbItem.Text);
                if (sNome.Trim().Length != 0)
                {
                    obUsuario.nomeusuario = sNome.Trim();
                    if (cUsuario.inserirAtualizarUsuario(obUsuario, 1))
                    {
                        MessageBox.Show("Nome alterado com sucesso!", "EstacionamentoFacil (FrmCadU12)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ve_se_existe();
                    }
                }

            }
            else
            {
                MessageBox.Show("Alteração permitida somente para cadastros já gravados!", "EstacionamentoFacil (FrmCadU13)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }       
        }

    }
}
