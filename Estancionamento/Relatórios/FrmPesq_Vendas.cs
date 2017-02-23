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
    public partial class FrmPesq_Vendas : Form
    {
        Veiculos cVeiculos;
        FrmPrincipal vTelaPrincipal;
        string sArquivoConexao;

        public FrmPesq_Vendas(FrmPrincipal vvTelaPrincipal, string vArquivoConexao)
        {
            InitializeComponent();
            vTelaPrincipal = vvTelaPrincipal;
            sArquivoConexao = vArquivoConexao;
        }

        private void FrmPesq_Vendas_Load(object sender, EventArgs e)
        {
            ve_se_existe();
        }

        private void limparCampos()
        {
            cmbMarca.Items.Clear();
            cmbSituacao.Items.Clear();
            cmbTipoVenda.Items.Clear();
            cmbVendedor.Items.Clear();
        }

        private void ve_se_existe()
        {
            try
            {
                limparCampos();
                ComboBoxItem cboItem;
                List<marca> lstMarca = new List<marca>();
                List<vendedor> lstVendedor = new List<vendedor>();

                string[] cTipoVenda = { "0ESTANCIONAMENTO", "1INTERMEDIAÇÃO" };
                string[] cSituacao = { "ABERTO", "CONCLUÍDA", "CANCELADA", "AGUARDANDO FINANCIAMENTO", "SUSPENSA" };

                cVeiculos = new Veiculos();                
                cVeiculos.ArquivoConexao = sArquivoConexao;

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

                foreach (string sTipoVenda in cTipoVenda)
                {
                    cboItem = new ComboBoxItem();
                    cboItem.Value = int.Parse(sTipoVenda.Substring(0, 1));
                    cboItem.Text = sTipoVenda.Substring(1, (sTipoVenda.Length-1));
                    cmbTipoVenda.Items.Add(cboItem);
                }

                foreach (string sSituacao in cSituacao)
                {
                    cboItem = new ComboBoxItem();
                    cboItem.Value = int.Parse(retornaCodigoSituacao(0,sSituacao).ToString());
                    cboItem.Text = sSituacao;
                    cmbSituacao.Items.Add(cboItem);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir janela de pesquisa de vendas!\n" + ex.Message, "EstacionamentoFacil (FrmPesqVd01)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//ve_se_existe

        private bool validaTela()
        {
            bool bResposta = true;
            if (chkPorData.Checked)
            {
                if (DateTime.Parse(txtDtInicial.Text) > DateTime.Parse(txtDataFinal.Text))
                {
                    MessageBox.Show("Data inicial maior que a data final!", "EstacionamentoFacil (FrmPesqVd02)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bResposta = false;
                }
            }

            if (chkPorMarca.Checked && bResposta)
            {
                if (cmbMarca.Text.Length == 0)
                {
                    MessageBox.Show("Selecione a marca a ser pesquisada!", "EstacionamentoFacil (FrmPesqVd03)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bResposta = false;
                }
            }

            if (chkPorSituacao.Checked && bResposta)
            {
                if (cmbSituacao.Text.Length == 0)
                {
                    MessageBox.Show("Selecione a situação a ser pesquisada!", "EstacionamentoFacil (FrmPesqVd04)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bResposta = false;
                }
            }

            if (chkPorTipoVenda.Checked && bResposta)
            {
                if (cmbTipoVenda.Text.Length == 0)
                {
                    MessageBox.Show("Selecione o tipo de venda a ser pesquisado!", "EstacionamentoFacil (FrmPesqVd05)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bResposta = false;
                }
            }

            if (chkPorVendedor.Checked && bResposta)
            {
                if (cmbVendedor.Text.Length == 0)
                {
                    MessageBox.Show("Selecione o vendedor a ser pesquisado!", "EstacionamentoFacil (FrmPesqVd06)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bResposta = false;
                }
            }

            return bResposta;
        }//validaTela

        private object retornaCodigoSituacao(byte bTipo, string sSituacao = "", int iCodigo = 0)
        {
            int iResposta = 0;
            string sResposta = "";
            if (bTipo == 0)
            {
                switch (sSituacao)
                {
                    case "ABERTO":
                        iResposta = 0;
                        break;
                    case "CONCLUÍDA":
                        iResposta = 1;
                        break;
                    case "CANCELADA":
                        iResposta = 2;
                        break;
                    case "AGUARDANDO FINANCIAMENTO":
                        iResposta = 3;
                        break;
                    case "SUSPENSA":
                        iResposta = 4;
                        break;
                }
                return iResposta;
            }
            else
            {
                switch (iCodigo)
                {
                    case 0:
                        sResposta = "ABERTO";
                        break;
                    case 1:
                        sResposta = "CONCLUÍDA";
                        break;
                    case 2:
                        sResposta = "CANCELADA";
                        break;
                    case 3:
                        sResposta = "AGUARDANDO FINANCIAMENTO";
                        break;
                    case 4:
                        sResposta = "SUSPENSA";
                        break;
                }
                return sResposta;
            }

        }

        private string montaPesquisa(byte bTipo = 0)
        {
            string sResposta = "";
            string sResposta2 = "";
            ComboBoxItem cboItem;
            if (chkPorData.Checked)
            {
                if (sResposta.Trim().Length > 0) sResposta = sResposta + " AND ";
                if (sResposta2.Trim().Length > 0) sResposta2 = sResposta2 + ", ";
                sResposta = sResposta + "v.data_venda BETWEEN CONVERT(DATETIME,'" + txtDtInicial.Text + "',103) AND CONVERT(DATETIME,'" + txtDataFinal.Text + "',103) ";
                sResposta2 = sResposta2 + "Por data (" + txtDtInicial.Text + " à " + txtDataFinal.Text + ")";
            }

            if (chkPorMarca.Checked)
            {
                cboItem = new ComboBoxItem();
                cboItem = (ComboBoxItem)cmbMarca.SelectedItem;
                if (cboItem != null)
                {
                    if (sResposta.Trim().Length > 0) sResposta = sResposta + " AND ";
                    if (sResposta2.Trim().Length > 0) sResposta2 = sResposta2 + ", ";
                    sResposta = sResposta + "car.CodMarca = " + cboItem.Value.ToString();
                    sResposta2 = sResposta2 + "Por Marca (" + cboItem.Text + ")";
                }
            }

            if (chkPorSituacao.Checked)
            {
                cboItem = new ComboBoxItem();
                cboItem = (ComboBoxItem)cmbSituacao.SelectedItem;
                if (cboItem != null)
                {
                    if (sResposta.Trim().Length > 0) sResposta = sResposta + " AND ";
                    if (sResposta2.Trim().Length > 0) sResposta2 = sResposta2 + ", ";
                    sResposta = sResposta + "v.situacao = " + cboItem.Value.ToString();
                    sResposta2 = sResposta2 + "Por Situação (" + cboItem.Text + ")";
                }
            }

            if (chkPorTipoVenda.Checked)
            {
                cboItem = new ComboBoxItem();
                cboItem = (ComboBoxItem)cmbTipoVenda.SelectedItem;
                if (cboItem != null)
                {
                    if (sResposta.Trim().Length > 0) sResposta = sResposta + " AND ";
                    if (sResposta2.Trim().Length > 0) sResposta2 = sResposta2 + ", ";
                    sResposta = sResposta + "v.tipo_venda = " + cboItem.Value.ToString();
                    sResposta2 = sResposta2 + "Por Tipo de venda (" + cboItem.Text + ")";
                }
            }

            if (chkPorVendedor.Checked)
            {
                cboItem = new ComboBoxItem();
                cboItem = (ComboBoxItem)cmbVendedor.SelectedItem;
                if (cboItem != null)
                {
                    if (sResposta.Trim().Length > 0) sResposta = sResposta + " AND ";
                    if (sResposta2.Trim().Length > 0) sResposta2 = sResposta2 + ", ";
                    sResposta = sResposta + "v.cod_venda IN (SELECT cod_venda FROM vendas_vendedor WHERE cod_vendedor = " + cboItem.Value.ToString() + ") ";
                    sResposta2 = sResposta2 + "Por Vendedor (" + cboItem.Text + ")";
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
                    if (cVeiculos.impr_Vendas(montaPesquisa(), montaPesquisa(1)))
                    {
                        //chamar tela de impressão
                        switch (vTelaPrincipal.vvEmpresa.tipo_relatorio)
                        {
                            case 0:
                                vTelaPrincipal.abrirImpressaoVendas(vTelaPrincipal);
                                break;
                            case 1:
                                vTelaPrincipal.abrirImpressaoVendasW(vTelaPrincipal);
                                break;
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao imprimir consulta!\n" + ex.Message, "EstacionamentoFacil (FrmPesqVd07)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdImprimir_Click(object sender, EventArgs e)
        {
            Application.DoEvents();
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
