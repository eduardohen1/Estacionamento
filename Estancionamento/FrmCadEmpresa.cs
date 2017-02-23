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
    public partial class FrmCadEmpresa : Form
    {
        FrmPrincipal vTelaPrincipal;
        string sArquivoConexao;
        Usuarios cUsuarios;
        Enderecos cEnderecos;
        Funcoes cFuncoes;

        public FrmCadEmpresa(FrmPrincipal vvTelaPrincipal, string ssArquivoConexao)
        {
            InitializeComponent();
            vTelaPrincipal = vvTelaPrincipal;
            sArquivoConexao = ssArquivoConexao;
        }

        private void FrmCadEmpresa_Load(object sender, EventArgs e)
        {
            ve_se_existe();
        }

        private void ve_se_existe()
        {
            try
            {
                ComboBoxItem cboItem;
                cUsuarios = new Usuarios();
                cEnderecos = new Enderecos();
                cFuncoes = new Funcoes();

                cUsuarios.ArquivoConexao = sArquivoConexao;
                cEnderecos.ArquivoConexao = sArquivoConexao;

                List<Logradouro> lstLogradouro = new List<Logradouro>();
                lstLogradouro = cEnderecos.pesquisarTodosLogradouro();
                foreach (Logradouro cLogradouro in lstLogradouro)
                {
                    cboItem = new ComboBoxItem();
                    cboItem.Value = cLogradouro.Codigo;
                    cboItem.Text = cLogradouro.Nome_logradouro.Trim();
                    cmbLogradouro.Items.Add(cboItem);
                }

                //tipo impressao
                cmbTipoImpressao.Items.Clear();
                cboItem = new ComboBoxItem();
                cboItem.Value = 0;
                cboItem.Text = "CRYSTAL REPORTS";
                cmbTipoImpressao.Items.Add(cboItem);

                cboItem = new ComboBoxItem();
                cboItem.Value = 1;
                cboItem.Text = "REPORT VIEWER";
                cmbTipoImpressao.Items.Add(cboItem);

                empresa cEmpresa = new empresa();
                cEmpresa = cUsuarios.buscaDadosEmpresa();

                txtEmpresa.Text = cEmpresa.nome_empresa.Trim();
                txtNomeFantasia.Text = cEmpresa.nome_fantasia.Trim();
                txtProprietario.Text = cEmpresa.proprietario.Trim();
                txtCNPJ.Text = cEmpresa.cnpj.Trim();
                txtTelefone01.Text = cEmpresa.telefone01.Trim();
                txtTelefone2.Text = cEmpresa.telefone02.Trim();
                txtEmail.Text = cEmpresa.email.Trim();
                cmbLogradouro.Text = cEnderecos.pesquisarLogradouro(cEmpresa.cod_logradouro).Nome_logradouro.Trim();
                txtNumero.Text = cEmpresa.numero.ToString();
                txtLicenca.Text = cEmpresa.licenca.Trim();// cFuncoes.Descriptografar(cEmpresa.licenca.Trim());

                switch (cEmpresa.tipo_relatorio)
                {
                    case 0:
                        cmbTipoImpressao.Text = "CRYSTAL REPORTS";
                        break;
                    case 1:
                        cmbTipoImpressao.Text = "REPORT VIEWER";
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir janela de cadastro de empresa!\n" + ex.Message, "EstacionamentoFacil (FrmEmp01)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//ve_se_Existe

        private bool validarTela()
        {
            bool bResposta = true;
            if (txtEmpresa.Text.Trim().Length == 0)
            {
                MessageBox.Show("Digite o nome da empresa!", "EstacionamentoFacil (FrmEmp02)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bResposta = false;
            }
            if (txtNomeFantasia.Text.Trim().Length == 0 && bResposta)
            {
                MessageBox.Show("Digite o nome da fantasia da empresa!", "EstacionamentoFacil (FrmEmp03)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bResposta = false;
            }
            if (txtLicenca.Text.Trim().Length == 0 && bResposta)
            {
                MessageBox.Show("Digite a licença do aplicativo da empresa!", "EstacionamentoFacil (FrmEmp04)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bResposta = false;
            }

            if (txtNumero.Text.Trim().Length == 0)
            {
                txtNumero.Text = "0";
            }

            return bResposta;
        }

        private void cmdGravar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validarTela())
                {
                    cUsuarios = new Usuarios();
                    cUsuarios.ArquivoConexao = sArquivoConexao;

                    empresa cEmpresa = new empresa();
                    cFuncoes = new Funcoes();
                    cEmpresa.nome_empresa = txtEmpresa.Text.Trim();
                    cEmpresa.nome_fantasia = txtNomeFantasia.Text.Trim();
                    cEmpresa.proprietario = txtProprietario.Text.Trim();
                    cEmpresa.cnpj = txtCNPJ.Text.Trim();
                    cEmpresa.telefone01 = txtTelefone01.Text.Trim();
                    cEmpresa.telefone02 = txtTelefone2.Text.Trim();
                    cEmpresa.email = txtEmail.Text.Trim();                    
                    if (cmbLogradouro.Text.Length == 0)
                        cEmpresa.cod_logradouro = 0;
                    else
                    {
                        ComboBoxItem cboItem = (ComboBoxItem)cmbLogradouro.SelectedItem;
                        if (cboItem != null)
                        {
                            cEmpresa.cod_logradouro = int.Parse(cboItem.Value.ToString());
                        }
                    }
                    cEmpresa.tipo_relatorio = 0;
                    if (cmbTipoImpressao.Text.Length != 0)
                    {
                        ComboBoxItem cboItem = (ComboBoxItem)cmbTipoImpressao.SelectedItem;
                        if (cboItem != null)
                            cEmpresa.tipo_relatorio = int.Parse(cboItem.Value.ToString());
                    }
                    cEmpresa.numero = int.Parse(txtNumero.Text);
                    cEmpresa.licenca = txtLicenca.Text.Trim();
                    cEmpresa.cod_empresa = 1;

                    if (cUsuarios.gravarDadosEmpresa(cEmpresa))
                    {
                        MessageBox.Show("Dados gravados com sucesso!", "EstacionamentoFacil (FrmEmp06)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Dados de empresa não foram gravados!", "EstacionamentoFacil (FrmEmp06b)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gravar dados da empresa!\n" + ex.Message, "EstacionamentoFacil (FrmEmp05)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidateFill(System.Windows.Forms.Control ctl, bool bCurrency)
        {
            System.Windows.Forms.TextBox t = (System.Windows.Forms.TextBox)ctl;
            try
            {
                int s = System.Convert.ToInt32(ctl.Text);
                if (bCurrency)
                    t.Text = s.ToString("C");
                System.Windows.Forms.Control c = this.GetNextControl(ctl, true);
                c.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Somente valores numéricos para o campo número. Verifique!!!", "EstacionamentoFacil (FrmEmp07)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (bCurrency)
                    t.Text = "0,00";
                else
                    t.Text = "0";
                t.Focus();
            }
        }

        private void txtNumero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue < 58)
            {
                if (e.KeyValue < 48 || e.KeyValue > 57)
                {
                    //backspace
                    if (e.KeyValue == 8)
                        e.SuppressKeyPress = false;
                    //enter
                    else if (e.KeyValue == 13)
                    {
                        e.SuppressKeyPress = false;
                        this.ValidateFill(this.txtNumero, false);
                    }
                    else
                    {
                        if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                            e.SuppressKeyPress = true;
                        else
                            e.SuppressKeyPress = false;
                    }
                }
                else
                {
                    if (e.Modifiers == Keys.Shift || e.Modifiers == Keys.ShiftKey)
                        e.SuppressKeyPress = true;
                    else
                        e.SuppressKeyPress = false;

                }
            }
            else
            {
                if (e.KeyValue < 96 || e.KeyValue > 105)
                    e.SuppressKeyPress = true;
                else
                    e.SuppressKeyPress = false;
            }
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCNPJ_Leave(object sender, EventArgs e)
        {
            if (txtCNPJ.Text.Length > 0)
            {
                Funcoes funcao = new Funcoes();
                if (!funcao.validarCNPJ(txtCNPJ.Text))
                {
                    if (MessageBox.Show("CNPJ inválido!\n\nDeseja continuar com a digitação dos dados?", "EstacionamentoFacil (FrmEmp08)", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                    {
                        txtCNPJ.Clear();
                        txtCNPJ.Focus();
                    }
                }
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text.Length > 0)
            {
                Funcoes funcao = new Funcoes();
                if (!funcao.validarEmail(txtEmail.Text))
                {
                    MessageBox.Show("E-mail inválido!\n\nVerifique a grafia se está correta!", "EstacionamentoFacil (FrmEmp09)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                }
            }
        }
    }
}
