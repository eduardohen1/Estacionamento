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
    public partial class FrmCadComissao : Form
    {
        int iCodVenda;
        int iCodVendedor;
        Veiculos veiculos;
        FrmPrincipal vTelaPrincipal;
        string sArquivoConexao;
        vendas cVendas;
        /// <summary>
        /// Tipo de entrada 0 - novo registro, 1 atualizar registro
        /// </summary>
        int iTipoEntrada; 

        public int CodVenda
        {
            set { iCodVenda = value;}
        }
        public int CodVendedor
        {
            set { iCodVendedor = value;}
        }

        public FrmCadComissao(string vArquivoConexao, FrmPrincipal vvTelaPrincipal, int iTipo, vendas ccVendas, int iiCodVendedor)
        {
            InitializeComponent();
            sArquivoConexao = vArquivoConexao;
            vTelaPrincipal = vvTelaPrincipal;
            iTipoEntrada = iTipo;
            cVendas = ccVendas;
            CodVendedor = iiCodVendedor;
        }

        private void FrmCadComissao_Load(object sender, EventArgs e)
        {
            vendas_vendedor cVendasVendedor;

            ve_se_existe();
            if (iTipoEntrada == 1)
            {
                veiculos = new Veiculos();
                veiculos.ArquivoConexao = sArquivoConexao;
                cVendasVendedor = veiculos.buscaDadosVendasVendedor(cVendas.cod_venda, iCodVendedor);
                exibirDadosComissao(cVendasVendedor);
                cmbVendedor.Enabled = false;
            }
            lblNumVenda.Text = cVendas.cod_venda.ToString("D5") + "/" + cVendas.data_venda.Year.ToString();
        }

        private void limparTela(byte bTipo)
        {
            switch (bTipo)
            {
                case 0:
                    cmbVendedor.Items.Clear();
                    cmbSituacao.Items.Clear();
                    break;
                case 1:
                    cmbVendedor.Text = "";
                    cmbSituacao.Text = "";
                    break;
            }            
            txtValorVenda.Clear();            
        }

        private void ve_se_existe()
        {   
            veiculos = new Veiculos();
            veiculos.ArquivoConexao = sArquivoConexao;

            try
            {
                ComboBoxItem cboItem;
                limparTela(0);
                List<vendedor> lstVendedor = veiculos.pesquisarTodosVendedores("A");
                if (lstVendedor != null)
                {
                    if (lstVendedor.Count > 0)
                    {
                        foreach (vendedor cVendedor in lstVendedor)
                        {
                            cboItem = new ComboBoxItem();
                            cboItem.Value = int.Parse(cVendedor.código.ToString());
                            cboItem.Text = cVendedor.nome.Trim();
                            cmbVendedor.Items.Add(cboItem);
                        }
                    }
                }
                string[] Situacoes = { "ABERTA", "LANÇADA", "CANCELADA", "APENAS LANÇADA" };
                foreach (string sSituacao in Situacoes)
                {
                    cboItem = new ComboBoxItem();
                    cboItem.Value = int.Parse(retornarSituacoes(0, sSituacao).ToString());
                    cboItem.Text = sSituacao;
                    cmbSituacao.Items.Add(cboItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir janela de Venda!\n" + ex.Message, "EstacionamentoFacil (FrmCom01)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Função para retornar a situação mediante o código ou o código mediante a situação.
        /// </summary>
        /// <param name="bTipo">Tipo 0 Situação para código; 1 Código para situação</param>
        /// <param name="sSituacao">Situação - Opcional</param>
        /// <param name="iCodigo">Código da situação - Opcional</param>
        /// <returns>Retorna a situação ou o código da situação</returns>
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

        private void exibirDadosComissao(vendas_vendedor cVendasVendedor)
        {
            try
            {
                limparTela(1);
                veiculos = new Veiculos();
                veiculos.ArquivoConexao = sArquivoConexao;
                cmbVendedor.Text = veiculos.pesquisaVendedor(cVendasVendedor.cod_vendedor).nome.Trim();
                txtValorVenda.Text = cVendasVendedor.valor_comissao.ToString("C");
                cmbSituacao.Text = retornarSituacoes(1, "", cVendasVendedor.situacao).ToString();
                CodVenda = cVendasVendedor.cod_venda;
                CodVendedor = cVendasVendedor.cod_vendedor;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir dados da comissão!\n" + ex.Message, "EstacionamentoFacil (FrmCom02)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool validarTela()
        {
            bool bResposta = true;
            if (cmbVendedor.Text.Length == 0)
            {
                MessageBox.Show("Selecione o vendedor desta comissão! ", "EstacionamentoFacil (FrmCom03)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bResposta = false;
            }
            if (txtValorVenda.Text.Length == 0 && bResposta)
            {
                MessageBox.Show("Digite  o valor da comissão! ", "EstacionamentoFacil (FrmCom04)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bResposta = false;
            }
            if (cmbSituacao.Text.Length == 0 && bResposta)
            {
                MessageBox.Show("Selecione a situação da comissão! ", "EstacionamentoFacil (FrmCom05)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bResposta = false;
            }
            return bResposta;
        }

        private void gravarComissao()
        {
            vendas_vendedor cVendasVendedor;
            ComboBoxItem cboValores;
            bool bErro = false;
            try
            {
                if (validarTela())
                {
                    cVendasVendedor = new vendas_vendedor();
                    cVendasVendedor.valor_comissao = double.Parse(veiculos.limparMoeda(txtValorVenda.Text.Trim()));
                    cboValores = (ComboBoxItem)cmbSituacao.SelectedItem;
                    cVendasVendedor.situacao = int.Parse(cboValores.Value.ToString());

                    if (iTipoEntrada == 0)
                    {
                        //novo
                        cVendasVendedor.cod_venda = cVendas.cod_venda;
                        cboValores = (ComboBoxItem)cmbVendedor.SelectedItem;
                        cVendasVendedor.cod_vendedor = int.Parse(cboValores.Value.ToString());
                        if (!veiculos.inserirAtualizarComissao(cVendasVendedor, 0))
                            bErro = true;                        
                    }
                    else
                    {
                        //atualizar
                        cVendasVendedor.cod_venda = iCodVenda;
                        cVendasVendedor.cod_vendedor = iCodVendedor;
                        if (!veiculos.inserirAtualizarComissao(cVendasVendedor, 1))
                            bErro = true;
                        
                    }
                    if(!bErro)
                    {
                        MessageBox.Show("Comissão gravada com sucesso! ", "EstacionamentoFacil (FrmCom06)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        vTelaPrincipal.vTela_FrmCadVenda.lancarComissao(cVendas);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Comissão não gravada! ", "EstacionamentoFacil (FrmCom07)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gravar comissão!\n" + ex.Message, "EstacionamentoFacil (FrmCom08)", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Somente valores numéricos. Verifique!!!", "EstacionamentoFacil (FrmCom09)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (bCurrency)
                    t.Text = "0,00";
                else
                    t.Text = "0";
                t.Focus();
            }
        }//validatefill

        private void cmdGravar_Click(object sender, EventArgs e)
        {
            gravarComissao();
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtValorVenda_KeyDown(object sender, KeyEventArgs e)
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
                        this.ValidateFill(this.txtValorVenda, true);
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

    }
}
