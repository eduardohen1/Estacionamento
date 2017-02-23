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
    public partial class FrmPesq_Comissao : Form
    {
        Veiculos cVeiculos;
        FrmPrincipal vTelaPrincipal;
        string sArquivoConexao;

        public FrmPesq_Comissao(FrmPrincipal vvTelaPrincipal, string vArquivoConexao)
        {
            InitializeComponent();
            vTelaPrincipal = vvTelaPrincipal;
            sArquivoConexao = vArquivoConexao;

        }

        private void FrmPesq_Comissao_Load(object sender, EventArgs e)
        {
            ve_se_existe();
        }

        private void limparCampos()
        {
            cmbVendedor.Items.Clear();
            cmbSituacao.Items.Clear();
        }

        private object retornarSituacoes(byte bTipo, string sSituacao = "", int iCodigo = 0)
        {
            string sResposta = "";
            int iResposta = 0;
            if (bTipo == 0)
            {                
                switch (sSituacao)
                {
                    case "ABERTA":
                        iResposta = 0;
                        break;
                    case "LANÇADA":
                        iResposta = 1;
                        break;
                    case "CANCELADA":
                        iResposta = 2;
                        break;
                    case "APENAS LANÇADA":
                        iResposta = 3;
                        break;
                }
                return iResposta;
            }
            else
            {
                switch (iCodigo)
                {
                    case 0:
                        sResposta = "ABERTA";
                        break;
                    case 1:
                        sResposta = "LANÇADA";
                        break;
                    case 2:
                        sResposta = "CANCELADA";
                        break;
                    case 3:
                        sResposta = "APENAS LANÇADA";
                        break;
                }
                return sResposta;
            }
        }//retornarSituacoes

        private void ve_se_existe()
        {
            try
            {
                limparCampos();
                ComboBoxItem cboItem;
                List<vendedor> lstVendedor = new List<vendedor>();
                string[] cSituacao = { "ABERTA", "LANÇADA", "CANCELADA", "APENAS LANÇADA" };

                cVeiculos = new Veiculos();
                cVeiculos.ArquivoConexao = sArquivoConexao;

                lstVendedor = cVeiculos.pesquisarTodosVendedores("X");
                if (lstVendedor != null)
                {
                    if (lstVendedor.Count > 0)
                    {
                        foreach (vendedor cVendedor in lstVendedor)
                        {
                            cboItem = new ComboBoxItem();
                            cboItem.Value = cVendedor.código;
                            cboItem.Text = cVendedor.nome;
                            cmbVendedor.Items.Add(cboItem);
                        }
                    }
                }

                foreach (string sSituacao in cSituacao)
                {
                    cboItem = new ComboBoxItem();
                    cboItem.Value = int.Parse(retornarSituacoes(0, sSituacao).ToString());
                    cboItem.Text = sSituacao;
                    cmbSituacao.Items.Add(cboItem);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir janela de pesquisa de vendas!\n" + ex.Message, "EstacionamentoFacil (FrmPesqCom01)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//ve_se_existe

        private bool validaTela()
        {
            bool bResposta = true;
            if (chkPorData.Checked)
            {
                if (DateTime.Parse(txtDtInicial.Text) > DateTime.Parse(txtDataFinal.Text))
                {
                    MessageBox.Show("Data inicial maior que a data final!", "EstacionamentoFacil (FrmPesqCom02)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bResposta = false;
                }
            }
            
            if (cmbVendedor.Text.Length == 0)
            {
                MessageBox.Show("Selecione o vendedor a ser pesquisado!", "EstacionamentoFacil (FrmPesqCom03)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bResposta = false;
            }

            if (chkPorSituacao.Checked)
            {
                ComboBoxItem cboItem = new ComboBoxItem();
                cboItem = (ComboBoxItem)cmbSituacao.SelectedItem;
                if (cboItem != null)
                {
                    if (cmbSituacao.Text.Length == 0)
                    {
                        MessageBox.Show("Selecione a situação a ser pesquisada!", "EstacionamentoFacil (FrmPesqCom04)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        bResposta = false;
                    }
                }
            }

            return bResposta;
        }//validaTela

        private string montaPesquisa(byte bTipo = 0)
        {
            string sResposta = "";
            string sResposta2 = "";
            ComboBoxItem cboItem;
            if (chkPorData.Checked)
            {
                if (sResposta.Trim().Length > 0) sResposta = sResposta + " AND ";
                if (sResposta2.Trim().Length > 0) sResposta2 = sResposta2 + ", ";
                sResposta = sResposta + "vend.data_venda BETWEEN CONVERT(DATETIME,'" + txtDtInicial.Text + "',103) AND CONVERT(DATETIME,'" + txtDataFinal.Text + "',103) ";
                sResposta2 = sResposta2 + "Por data (" + txtDtInicial.Text + " à " + txtDataFinal.Text + ")";
            }

            cboItem = new ComboBoxItem();
            cboItem = (ComboBoxItem)cmbVendedor.SelectedItem;
            if (cboItem != null)
            {
                if (sResposta.Trim().Length > 0) sResposta = sResposta + " AND ";
                if (sResposta2.Trim().Length > 0) sResposta2 = sResposta2 + ", ";
                sResposta = sResposta + "vv.cod_vendedor = " + cboItem.Value.ToString();
                //sResposta2 = sResposta2 + "Por Vendedor (" + cboItem.Text.Trim() + ")";
            }

            if (chkPorSituacao.Checked)
            {
                cboItem = new ComboBoxItem();
                cboItem = (ComboBoxItem)cmbVendedor.SelectedItem;
                if (cboItem != null)
                {
                    if (sResposta.Trim().Length > 0) sResposta = sResposta + " AND ";
                    if (sResposta2.Trim().Length > 0) sResposta2 = sResposta2 + ", ";
                    sResposta = sResposta + "vv.situacao = " + cboItem.Value.ToString();
                    sResposta2 = sResposta2 + "Por Situação (" + cboItem.Text + ")";
                }
            }

            if (sResposta.Trim().Length > 0) sResposta = " WHERE " + sResposta;
            if (bTipo == 1)
                sResposta = sResposta2;
            return sResposta;
        }//monta pesquisa

        private void imprimirConsulta()
        {
            try
            {
                if (validaTela())
                {
                    cVeiculos = new Veiculos();
                    cVeiculos.ArquivoConexao = sArquivoConexao;
                    if (cVeiculos.impr_Comissao(montaPesquisa(), montaPesquisa(1)))
                    {
                        //chamar tela de impressão
                        switch (vTelaPrincipal.vvEmpresa.tipo_relatorio)
                        {
                            case 0:
                                vTelaPrincipal.abrirImpressaoComissao(vTelaPrincipal);
                                break;
                            case 1:
                                vTelaPrincipal.abrirImpressaoComissaoW(vTelaPrincipal);
                                break;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao imprimir consulta!\n" + ex.Message, "EstacionamentoFacil (FrmPesqCom05)", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
