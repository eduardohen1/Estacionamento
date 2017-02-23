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
    public partial class FrmContaCartaoCliente : Form
    {
        FrmPrincipal vTelaPrincipal;
        cliente cCliente;
        string sArquivoConexao;
        ComboBoxItem cboItem;

        public FrmContaCartaoCliente(string vArquivoConexao, FrmPrincipal vTela_FrmPrincipal, cliente ccCliente)
        {
            InitializeComponent();
            sArquivoConexao = vArquivoConexao;
            vTelaPrincipal = vTela_FrmPrincipal;
            cCliente = ccCliente;            
        }

        private void enableCampos()
        {
            txtNomeBanco.Enabled = true;
            txtAgencia.Enabled = true;
            txtNumConta.Enabled = true;
            txtNumero.Enabled = true;
            txtBandeira.Enabled = true;
        }

        private void limparCampos()
        {
            enableCampos();

            cmbTipo.SelectedIndex = -1;
            txtNumero.Clear();
            txtBandeira.Clear();
            txtNomeBanco.Clear();
            txtAgencia.Clear();
            txtNumConta.Clear();
            txtObservacao.Clear();
            txtCPF.Clear();
            txtCNPJ.Clear();
        }

        private void FrmContaCartaoCliente_Load(object sender, EventArgs e)
        {
            lblNomeCliente.Text = cCliente.Nome.ToUpper().Trim();

            cmbTipo.Items.Clear();
            cboItem = new ComboBoxItem();
            cboItem.Text = "CARTÃO";
            cboItem.Value = 0;
            cmbTipo.Items.Add(cboItem);

            cboItem = new ComboBoxItem();
            cboItem.Text = "CONTA CORRENTE";
            cboItem.Value = 1;
            cmbTipo.Items.Add(cboItem);

            cboItem = new ComboBoxItem();
            cboItem.Text = "CONTA POUPANÇA";
            cboItem.Value = 2;
            cmbTipo.Items.Add(cboItem);

            limparCampos();

        }

        private void cmbTipo_Leave(object sender, EventArgs e)
        {
            cboItem = (ComboBoxItem)cmbTipo.SelectedItem;
            if (cboItem != null)
            {
                enableCampos();

                switch(int.Parse(cboItem.Value.ToString())){
                    case 0:
                        txtNomeBanco.Text = "-";
                        txtAgencia.Text = "-";
                        txtNumConta.Text = "-";
                        txtNomeBanco.Enabled =false;
                        txtAgencia.Enabled = false;
                        txtNumConta.Enabled = false;
                        break;
                    case 1:
                        txtNumero.Text = "-";
                        txtBandeira.Text = "-";
                        txtNumero.Enabled = false;
                        txtBandeira.Enabled = false;
                        break;
                    case 2:
                        txtNumero.Text = "-";
                        txtBandeira.Text = "-";
                        txtNumero.Enabled = false;
                        txtBandeira.Enabled = false;
                        break;
                }
            }
        }

        private void cmbTipo_Enter(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void txtCPF_Leave(object sender, EventArgs e)
        {
            if (txtCPF.Text.Length > 0)
            {
                Funcoes funcao = new Funcoes();
                if (!funcao.validarCPF(txtCPF.Text.Trim()))
                {
                    if (MessageBox.Show("CPF Inválido!\n\nDeseja continuar a digitação dos dados do conta/cartão?", "EstacionamentoFacil (FrmConta01)", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                    {
                        txtCPF.Clear();
                        txtCPF.Focus();
                    }
                }
            }
        }

        private void txtCNPJ_Leave(object sender, EventArgs e)
        {
            if (txtCNPJ.Text.Length > 0)
            {
                Funcoes funcao = new Funcoes();
                if (!funcao.validarCNPJ(txtCNPJ.Text.Trim()))
                {
                    if (MessageBox.Show("CNPJ Inválido!\n\nDeseja continuar a digitação dos dados do conta/cartão?", "EstacionamentoFacil (FrmConta02)", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                    {
                        txtCPF.Clear();
                        txtCPF.Focus();
                    }
                }
            }
        }

        private void gravarContaCartao()
        {
            cboItem = (ComboBoxItem)cmbTipo.SelectedItem;
            if (cboItem != null)
            {
                enableCampos();
                ContaCartaoCliente cContaCartao = new ContaCartaoCliente();
                cContaCartao.CodContaCartao = 0;
                cContaCartao.CodCliente = cCliente.Codigo;
                cContaCartao.Tipo = int.Parse(cboItem.Value.ToString());
                cContaCartao.Numero = txtNumero.Text;
                cContaCartao.Bandeira = txtBandeira.Text;
                cContaCartao.NomeBanco = txtNomeBanco.Text;
                cContaCartao.Agencia = txtAgencia.Text;
                cContaCartao.NumConta = txtNumConta.Text;
                cContaCartao.CPF = txtCPF.Text;
                cContaCartao.CNPJ = txtCNPJ.Text;
                cContaCartao.Obs = txtObservacao.Text;

                //validando campos
                if (cContaCartao.Numero.Trim().Length == 0) cContaCartao.Numero = "-";
                if (cContaCartao.Bandeira.Trim().Length == 0) cContaCartao.Bandeira = "-";
                if (cContaCartao.NomeBanco.Trim().Length == 0) cContaCartao.NomeBanco = "-";
                if(cContaCartao.Agencia.Trim().Length == 0) cContaCartao.Agencia = "-";
                if (cContaCartao.NumConta.Trim().Length == 0) cContaCartao.NumConta = "-";
                if (cContaCartao.Obs.Trim().Length == 0) cContaCartao.Obs = " ";

                Cliente hCliente = new Cliente();
                hCliente.ArquivoConexao = sArquivoConexao;
                if (hCliente.inserirContaCartaoCliente(cContaCartao, vTelaPrincipal.vvCodigoUsuario, this.Name.ToString()))
                {
                    MessageBox.Show("Conta/cartão gravado com sucesso!", "EstacionamentoFacil (FrmConta04)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vTelaPrincipal.vTela_FrmCadCliente.lancarContaCartao(cCliente);
                    this.Close();
                }
            }else
                MessageBox.Show("Selecione um tipo de conta/cartão para o cadastro!\n\nOperação cancelada!", "EstacionamentoFacil (FrmConta03)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void cmdGravar_Click(object sender, EventArgs e)
        {
            gravarContaCartao();
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
