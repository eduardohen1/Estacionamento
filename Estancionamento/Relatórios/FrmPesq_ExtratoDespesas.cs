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
    public partial class FrmPesq_ExtratoDespesas : Form
    {
        Veiculos cVeiculos;
        FrmPrincipal vTelaPrincipal;
        string sArquivoConexao;

        public FrmPesq_ExtratoDespesas(FrmPrincipal vvTelaPrincipal, string vArquivoConexao)
        {
            InitializeComponent();
            vTelaPrincipal = vvTelaPrincipal;
            sArquivoConexao = vArquivoConexao;
        }

        private void FrmPesq_ExtratoDespesas_Load(object sender, EventArgs e)
        {
            ve_se_existe();
        }

        private void limparTela()
        {
            cmbCarro.Items.Clear();
        }

        private void ve_se_existe()
        {
            try
            {
                limparTela();                
                List<carro> lstCarro = new List<carro>();
                ComboBoxItem cboItem;
                cVeiculos = new Veiculos();
                cVeiculos.ArquivoConexao = sArquivoConexao;
                lstCarro = cVeiculos.pesquisarTodosCarros();
                if (lstCarro != null)
                {
                    if (lstCarro.Count > 0)
                    {
                        foreach (carro cCarro in lstCarro)
                        {
                            cboItem = new ComboBoxItem();
                            cboItem.Value = cCarro.Codigo;
                            cboItem.Text = cCarro.Placa2.Trim();
                            cmbCarro.Items.Add(cboItem);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir janela de Pesquisa de veículos!\n" + ex.Message, "EstacionamentoFacil (FrmPesqExt01)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//ve_se_existe

        private bool validaTela()
        {
            bool bResposta = true;

            if (cmbCarro.Text.Length == 0)
            {
                MessageBox.Show("Selecione o veículo para o extrato!", "EstacionamentoFacil (FrmPesqExt02)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bResposta = false;
            }

            if (chkPorData.Checked && bResposta)
            {
                if (DateTime.Parse(txtDtInicial.Text) > DateTime.Parse(txtDataFinal.Text))
                {
                    MessageBox.Show("Data inicial menor que a data final para o extrato!", "EstacionamentoFacil (FrmPesqExt03)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bResposta = false;
                }
            }
            return bResposta;
        }//validaTela

        private string montaPesquisa(byte bTipo = 0)
        {
            string sResposta = "";
            string sResposta2 = "";
                        
            if (chkPorData.Checked)
            {
                sResposta = " d.data BETWEEN CONVERT(DATETIME, '" + txtDtInicial.Text + "',103) AND CONVERT(DATETIME, '" + txtDataFinal.Text + "',103) ";
                sResposta2 = "Por data (" + txtDtInicial.Text + " à " + txtDataFinal.Text + ")";
            }
            if (sResposta.Trim().Length > 0) sResposta = " AND " + sResposta;
            if (bTipo == 1)
            {
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
                    ComboBoxItem cboItem = new ComboBoxItem();
                    cboItem = (ComboBoxItem)cmbCarro.SelectedItem;

                    if (cboItem != null)
                    {
                        carro cCarro = new carro();
                        cCarro = cVeiculos.pesquisarCarro(int.Parse(cboItem.Value.ToString()));
                        if (cVeiculos.impr_ExtradoDespesas(montaPesquisa(), montaPesquisa(1), cCarro))
                        {
                            //chamar tela de impressão
                            switch (vTelaPrincipal.vvEmpresa.tipo_relatorio)
                            {
                                case 0:
                                    vTelaPrincipal.abrirImpressaoExtratoDespesas(vTelaPrincipal);
                                    break;
                                case 1:
                                    vTelaPrincipal.abrirImpressaoExtratoDespesasW(vTelaPrincipal);
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao imprimir consulta!\n" + ex.Message, "EstacionamentoFacil (FrmPesqExt04)", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
