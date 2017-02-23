using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Estancionamento.Relatórios
{
    public partial class FrmPesq_VeiculosCadastradoscs : Form
    {
        Veiculos cVeiculos;
        FrmPrincipal vTelaPrincipal;
        string sArquivoConexao;

        public FrmPesq_VeiculosCadastradoscs(FrmPrincipal vvTelaPrincipal, string vArquivoConexao)
        {
            InitializeComponent();
            vTelaPrincipal = vvTelaPrincipal;
            sArquivoConexao = vArquivoConexao;
        }

        private void FrmPesq_VeiculosCadastradoscs_Load(object sender, EventArgs e)
        {
            ve_se_existe();
        }

        private void limparTela()
        {
            cmbMarca.Items.Clear();
            cmbQteLugares.Items.Clear();
            cmbCor.Items.Clear();
            cmbQtePortas.Items.Clear();
            cmbSituacao.Items.Clear();
            txtAnoFab.Clear();
            txtAnoMod.Clear();
        }

        private void ve_se_existe()
        {
            try
            {
                limparTela();
                List<retornoConsultaVeiculos> lstRetorno;
                List<marca> lstMarca = new List<marca>();                
                ComboBoxItem cboItem;
                cVeiculos = new Veiculos();
                cVeiculos.ArquivoConexao = sArquivoConexao;

                //marca
                lstMarca = cVeiculos.pesquisarTodasMarcas();
                if (lstMarca != null)
                {
                    if (lstMarca.Count > 0)
                    {
                        foreach (marca cMarca in lstMarca)
                        {
                            cboItem = new ComboBoxItem();
                            cboItem.Value = cMarca.codigo;
                            cboItem.Text = cMarca.descricao;
                            cmbMarca.Items.Add(cboItem);
                        }
                    }
                }
                else
                {
                    chkPorMarca.Checked = false;
                    chkPorMarca.Enabled = false;
                    cmbMarca.Enabled = false;   
                }

                //qte portas
                lstRetorno = null;
                lstRetorno = cVeiculos.retornoConsultaVeiculo(0);
                if (lstRetorno != null)
                {
                    if (lstRetorno.Count > 0)
                    {
                        foreach (retornoConsultaVeiculos cRetorno in lstRetorno)
                        {
                            cboItem = new ComboBoxItem();
                            cboItem.Value = cRetorno.sCodigo;
                            cboItem.Text = cRetorno.sTexto;
                            cmbQteLugares.Items.Add(cboItem);
                        }
                    }
                }
                else
                {
                    chkPorQtePortas.Checked = false;
                    chkPorQtePortas.Enabled = false;
                    cmbQtePortas.Enabled = false;
                }

                //qte lugares
                lstRetorno = null;
                lstRetorno = cVeiculos.retornoConsultaVeiculo(1);
                if (lstRetorno != null)
                {
                    if (lstRetorno.Count > 0)
                    {
                        foreach (retornoConsultaVeiculos cRetorno in lstRetorno)
                        {
                            cboItem = new ComboBoxItem();
                            cboItem.Value = cRetorno.sCodigo;
                            cboItem.Text = cRetorno.sTexto;
                            cmbQteLugares.Items.Add(cboItem);
                        }
                    }
                }
                else
                {
                    chkPorQteLugares.Checked = false;
                    chkPorQteLugares.Enabled = false;
                    cmbQteLugares.Enabled = false;
                }

                //Cor
                lstRetorno = null;
                lstRetorno = cVeiculos.retornoConsultaVeiculo(2);
                if (lstRetorno != null)
                {
                    if (lstRetorno.Count > 0)
                    {
                        foreach (retornoConsultaVeiculos cRetorno in lstRetorno)
                        {
                            cboItem = new ComboBoxItem();
                            cboItem.Value = cRetorno.sCodigo;
                            cboItem.Text = cRetorno.sTexto;
                            cmbCor.Items.Add(cboItem);
                        }
                    }
                }
                else
                {
                    chkPorCor.Checked = false;
                    chkPorCor.Enabled = false;
                    cmbCor.Enabled = false;
                }

                //Situacao
                lstRetorno = new List<retornoConsultaVeiculos>();
                string[] cSituacao = { "ATIVO", "EXCLUÍDO", "HISTÓRICO" };
                foreach (string sSituacao in cSituacao)
                {
                    cboItem = new ComboBoxItem();
                    cboItem.Value = sSituacao;
                    cboItem.Text = sSituacao;
                    cmbSituacao.Items.Add(cboItem);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir janela de Pesquisa de veículos!\n" + ex.Message, "EstacionamentoFacil (FrmPesqV01)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//ve_se_existe

        private bool validaTela()
        {
            bool bResposta = true;
            if(chkPorMarca.Checked)
            {
                if (cmbMarca.Text.Length == 0)
                {
                    MessageBox.Show("Selecione a marca para a pesquisa!", "EstacionamentoFacil (FrmPesqV02)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bResposta = false;
                }
            }

            if (chkPorAnoFab.Checked && bResposta)
            {
                if (txtAnoFab.Text.Length == 0)
                {
                    MessageBox.Show("Digite o ano de fabricação para a pesquisa!", "EstacionamentoFacil (FrmPesqV03)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bResposta = false;
                }
                else if(txtAnoFab.Text.Length != 4) 
                {
                    MessageBox.Show("Ano com 4 dígitos (ex.: 1990)!", "EstacionamentoFacil (FrmPesqV03b)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bResposta = false;
                }
            }

            if (chkPorAnoMod.Checked && bResposta)
            {
                if (txtAnoMod.Text.Length == 0)
                {
                    MessageBox.Show("Digite o ano de modelo para a pesquisa!", "EstacionamentoFacil (FrmPesqV04)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bResposta = false;
                }
                else if (txtAnoMod.Text.Length != 4)
                {
                    MessageBox.Show("Ano com 4 dígitos (ex.: 1990)!", "EstacionamentoFacil (FrmPesqV04b)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bResposta = false;
                }
            }

            if (chkPorQtePortas.Checked && bResposta)
            {
                if (cmbQtePortas.Text.Length == 0)
                {
                    MessageBox.Show("Selecione a qte de portas para a pesquisa!", "EstacionamentoFacil (FrmPesqV05)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bResposta = false;
                }
            }

            if (chkPorQteLugares.Checked && bResposta)
            {
                if (cmbQteLugares.Text.Length == 0)
                {
                    MessageBox.Show("Selecione a qte de lugares para a pesquisa!", "EstacionamentoFacil (FrmPesqV06)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bResposta = false;
                }
            }

            if (chkPorCor.Checked && bResposta)
            {
                if (cmbCor.Text.Length == 0)
                {
                    MessageBox.Show("Selecione a cor para a pesquisa!", "EstacionamentoFacil (FrmPesqV07)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bResposta = false;
                }
            }

            if (chkPorSituacao.Checked && bResposta)
            {
                if (cmbSituacao.Text.Length == 0)
                {
                    MessageBox.Show("Selecione a situação para a pesquisa!", "EstacionamentoFacil (FrmPesqV08)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bResposta = false;
                }
            }

            return bResposta;
        }

        private string montaPesquisa(byte bTipo = 0)
        {
            string sResposta = "";
            string sResposta2 = "";
            ComboBoxItem cboItem;

            if (chkPorMarca.Checked)
            {
                cboItem = (ComboBoxItem)cmbMarca.SelectedItem;
                if (cboItem != null)
                {
                    if (sResposta.Trim().Length > 0) sResposta = sResposta + " AND ";
                    if (sResposta2.Trim().Length > 0) sResposta2 = sResposta2 + ", ";
                    sResposta = " car.CodMarca = " + cboItem.Value.ToString();
                    sResposta2 = "Por marca (" + cboItem.Text + ")";
                }
            }

            if (chkPorAnoFab.Checked)
            {
                if (sResposta.Trim().Length > 0) sResposta = sResposta + " AND ";
                if (sResposta2.Trim().Length > 0) sResposta2 = sResposta2 + ", ";
                sResposta = " car.AnoFab = " + txtAnoFab.Text;
                sResposta2 = "Por ano fab. (" + txtAnoFab.Text + ")";
            }

            if (chkPorAnoMod.Checked)
            {
                if (sResposta.Trim().Length > 0) sResposta = sResposta + " AND ";
                if (sResposta2.Trim().Length > 0) sResposta2 = sResposta2 + ", ";
                sResposta = " car.AnoMod = " + txtAnoMod.Text;
                sResposta2 = "Por ano mod. (" + txtAnoMod.Text + ")";
            }

            if (chkPorQtePortas.Checked)
            {
                cboItem = (ComboBoxItem)cmbQtePortas.SelectedItem;
                if (cboItem != null)
                {
                    if (sResposta.Trim().Length > 0) sResposta = sResposta + " AND ";
                    if (sResposta2.Trim().Length > 0) sResposta2 = sResposta2 + ", ";
                    sResposta = " car.QtdePortas = " + cboItem.Value.ToString();
                    sResposta2 = "Por qte portas (" + cboItem.Text + ")";
                }
            }

            if (chkPorQteLugares.Checked)
            {
                cboItem = (ComboBoxItem)cmbQteLugares.SelectedItem;
                if (cboItem != null)
                {
                    if (sResposta.Trim().Length > 0) sResposta = sResposta + " AND ";
                    if (sResposta2.Trim().Length > 0) sResposta2 = sResposta2 + ", ";
                    sResposta = " car.Lugares = " + cboItem.Value.ToString();
                    sResposta2 = "Por qte lugares (" + cboItem.Text + ")";
                }
            }

            if (chkPorCor.Checked)
            {
                cboItem = (ComboBoxItem)cmbCor.SelectedItem;
                if (cboItem != null)
                {
                    if (sResposta.Trim().Length > 0) sResposta = sResposta + " AND ";
                    if (sResposta2.Trim().Length > 0) sResposta2 = sResposta2 + ", ";
                    sResposta = " car.Cor = '" + cboItem.Value.ToString() + "'";
                    sResposta2 = "Por cor (" + cboItem.Text + ")";
                }
            }

            if (chkPorSituacao.Checked)
            {
                cboItem = (ComboBoxItem)cmbSituacao.SelectedItem;
                if (cboItem != null)
                {
                    if (sResposta.Trim().Length > 0) sResposta = sResposta + " AND ";
                    if (sResposta2.Trim().Length > 0) sResposta2 = sResposta2 + ", ";
                    sResposta = " car.Situacao = '" + cboItem.Text.Substring(1,1).ToString() + "'";
                    sResposta2 = "Por situação (" + cboItem.Text + ")";
                }
            }
            if (sResposta.Trim().Length > 0) sResposta = " WHERE " + sResposta;
            if (bTipo == 1)
            {
                if (sResposta2.Trim().Length == 0) sResposta2 = "Todos os cadastros";
                sResposta = sResposta2;
            }

            return sResposta;
        }

        private void imprimirConsulta()
        {
            try
            {
                if (validaTela())
                {
                    cVeiculos = new Veiculos();
                    cVeiculos.ArquivoConexao = sArquivoConexao;
                    if (cVeiculos.impr_VeiculosCadastrados(montaPesquisa(0),montaPesquisa(1)))
                    {
                        //chamar tela de impressão
                        switch (vTelaPrincipal.vvEmpresa.tipo_relatorio)
                        {
                            case 0:
                                vTelaPrincipal.abrirImpressaoVeiculosCadastrados(vTelaPrincipal);
                                break;
                            case 1:
                                vTelaPrincipal.abrirImpressaoVeiculosCadastradosW(vTelaPrincipal);
                                break;
                        }                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao imprimir consulta!\n" + ex.Message, "EstacionamentoFacil (FrmPesqV09)", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Somente valores numéricos. Verifique!!!", "EstacionamentoFacil (FrmPesqV10)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (bCurrency)
                    t.Text = "0,00";
                else
                    t.Text = "0";
                t.Focus();
            }
        }//validatefill

        private void txtAnoFab_KeyDown(object sender, KeyEventArgs e)
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
                        this.ValidateFill(this.txtAnoFab, false);
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

        private void txtAnoMod_KeyDown(object sender, KeyEventArgs e)
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
                        this.ValidateFill(this.txtAnoMod,false);
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

        private void cmdImprimir_Click(object sender, EventArgs e)
        {
            cmdImprimir.Enabled = false;
            cmdFechar.Enabled = false;
            imprimirConsulta();
            cmdImprimir.Enabled = true;
            cmdFechar.Enabled = true;
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
