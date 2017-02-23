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
    public partial class FrmCadDespesa : Form
    {

        FrmPrincipal vTelaPrincipal;
        carro cCarro;
        Veiculos veiculos;
        string sArquivoConexao;
        bool bSemCarro;

        public carro vCarro
        {
            get { return cCarro; }
            set {cCarro = value;}
        }

        public bool vSemCarro
        {
            get { return bSemCarro; }
            set { bSemCarro = value; }
        }

        public FrmCadDespesa(string vArquivoConexao, FrmPrincipal vTela_FrmPrincipal, carro ccCarro, bool bbSemCarro)
        {
            InitializeComponent();
            sArquivoConexao = vArquivoConexao;
            vTelaPrincipal = vTela_FrmPrincipal;
            bSemCarro = bbSemCarro;
            if(!bSemCarro)
                cCarro = ccCarro;
        }

        private void FrmCadDespesa_Load(object sender, EventArgs e)
        {
            ve_se_existe();
        }

        public void ve_se_existe()
        {
            if (!bSemCarro)
            {
                lblPlaca.Visible = false;
                cmbPlaca.Visible = false;
                lblPlacaVeiculo.Visible = true;
                lblPlacaVeiculo.Text = cCarro.Placa2.Trim();
                txtDescricao.Focus();
            }
            else
            {
                lblPlacaVeiculo.Visible = false;
                lblPlaca.Visible = true;
                cmbPlaca.Visible = true;
                try
                {
                    ComboBoxItem cboItem;
                    //preencher combo carro
                    List<carro> listCarro = new List<carro>();
                    veiculos = new Veiculos();
                    veiculos.ArquivoConexao = sArquivoConexao;
                    listCarro = veiculos.pesquisarTodosCarros();
                    foreach (carro lstCarro in listCarro)
                    {
                        cboItem = new ComboBoxItem();
                        cboItem.Text = lstCarro.Placa2;
                        cboItem.Value = lstCarro.Codigo;
                        cmbPlaca.Items.Add(cboItem);
                    }
                    cmbPlaca.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao iniciar tela de despesa: " + ex.Message, "EstacionamentoFacil (FrmCDes10)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }

        private bool validaTela()
        {
            bool bResposta = true;

            if (bSemCarro)
            {
                ComboBoxItem cboItem = (ComboBoxItem)cmbPlaca.SelectedItem;
                if (cboItem == null)
                {
                    bResposta = false;
                    MessageBox.Show("Selecione a placa do veículo para o lançamento.", "EstacionamentoFacil (FrmCDes11)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (txtDescricao.Text.Trim().Length == 0 && bResposta)
            {
                bResposta = false;
                MessageBox.Show("Campo descrição em branco. Verifique!!!", "EstacionamentoFacil (FrmCDes02)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (txtNumNota.Text.Trim().Length == 0 && bResposta)
            {
                bResposta = false;
                MessageBox.Show("Campo num. de nota em branco. Verifique!!!", "EstacionamentoFacil (FrmCDes03)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (txtValor.Text.Trim().Length == 0 && bResposta)
            {
                bResposta = false;
                MessageBox.Show("Campo valor da despesa em branco. Verifique!!!", "EstacionamentoFacil (FrmCDes04)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (txtObservacao.Text.Trim().Length == 0)
            {
                txtObservacao.Text = " ";
            }
            return bResposta;
        }

        private void ValidateFill(System.Windows.Forms.Control ctl, bool bCurrency)
        {
            System.Windows.Forms.TextBox t = (System.Windows.Forms.TextBox)ctl;
            try
            {
                int s = System.Convert.ToInt32(ctl.Text);
                if(bCurrency)
                    t.Text = s.ToString("C");
                System.Windows.Forms.Control c = this.GetNextControl(ctl, true);
                c.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Somente valores numéricos para. Verifique!!!", "EstacionamentoFacil (FrmCDes01)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (bCurrency)
                    t.Text = "0,00";
                else
                    t.Text = "0";
                t.Focus();
            }
        }

        private void txtNumNota_KeyDown(object sender, KeyEventArgs e)
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
                        this.ValidateFill(this.txtNumNota,false);
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
        }//private void txtNumNota_KeyDown
        
        /// <summary>
        /// Função para gravar dados da Despesa
        /// </summary>
        private void gravarDespesa()
        {
            despesas cDespesa;
            if (validaTela())
            {
                try
                {                    
                    veiculos = new Veiculos();
                    veiculos.ArquivoConexao = sArquivoConexao;
                    if (bSemCarro)
                    {
                        ComboBoxItem cmbItem = new ComboBoxItem();
                        cmbItem = (ComboBoxItem)cmbPlaca.SelectedItem;
                        cCarro = new carro();
                        cCarro = veiculos.pesquisarCarro(int.Parse(cmbItem.Value.ToString()));
                    }
                    
                    cDespesa = new despesas();
                    cDespesa.codigo = 0;
                    cDespesa.Descrição = txtDescricao.Text.Trim();
                    cDespesa.Num_nota = int.Parse(txtNumNota.Text);
                    cDespesa.Valor = double.Parse(txtValor.Text);
                    cDespesa.Data = DateTime.Parse(txtData.Text);
                    cDespesa.Observacao = txtObservacao.Text;                    
                    if (veiculos.gravarDespesas(cDespesa, cCarro.Codigo, 0))
                    {
                        MessageBox.Show("Despesa gravada com sucesso!", "EstacionamentoFacil (FrmCDes07)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (!bSemCarro)
                        {
                            vTelaPrincipal.vTela_FrmCadCarro.lancarDespesas(cCarro);
                            this.Close();
                        }
                        else
                            limparTela();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao gravar dados de despesa: " + ex.Message, "EstacionamentoFacil (FrmCDes06)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void limparTela()
        {            
            txtDescricao.Clear();
            txtNumNota.Clear();
            txtNumNota.Clear();
            txtObservacao.Clear();
            txtValor.Clear();
            if (bSemCarro)
            {
                cmbPlaca.Text = "";
                cmbPlaca.Focus();
            }
            else
                txtDescricao.Focus();
        }

        private void txtValor_KeyDown(object sender, KeyEventArgs e)
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
                        this.ValidateFill(this.txtValor, true);
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
                if (e.KeyValue == 110 || e.KeyValue == 190)
                {
                    e.SuppressKeyPress = false;
                }
                else
                {
                    if (e.KeyValue < 96 || e.KeyValue > 105)
                        e.SuppressKeyPress = true;
                    else
                        e.SuppressKeyPress = false;
                }
            }
        }

        private void cmdGravar_Click(object sender, EventArgs e)
        {
            gravarDespesa();
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
