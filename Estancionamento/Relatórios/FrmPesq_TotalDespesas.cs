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
    public partial class FrmPesq_TotalDespesas : Form
    {
        Veiculos cVeiculos;
        FrmPrincipal vTelaPrincipal;
        string sArquivoConexao;

        public FrmPesq_TotalDespesas(FrmPrincipal vvTelaPrincipal, string vArquivoConexao)
        {
            InitializeComponent();
            vTelaPrincipal = vvTelaPrincipal;
            sArquivoConexao = vArquivoConexao;
        }

        private void FrmPesq_TotalDespesas_Load(object sender, EventArgs e)
        {

        }

        private bool validaTela()
        {
            bool bResposta = true;

            if (DateTime.Parse(txtDtInicial.Text) > DateTime.Parse(txtDataFinal.Text))
            {
                MessageBox.Show("Data inicial menor que a data final para o extrato!", "EstacionamentoFacil (FrmPesqExtb01)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bResposta = false;
            }
            
            return bResposta;
        }//validaTela

        private string montaPesquisa(byte bTipo = 0)
        {
            string sResposta = "";
            string sResposta2 = "";

            sResposta = " d.data BETWEEN CONVERT(DATETIME, '" + txtDtInicial.Text + "',103) AND CONVERT(DATETIME, '" + txtDataFinal.Text + "',103) ";
            sResposta2 = "Por data (" + txtDtInicial.Text + " à " + txtDataFinal.Text + ")";
            
            if (sResposta.Trim().Length > 0) sResposta = " WHERE " + sResposta;
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

                    if (cVeiculos.impr_TotalDespesas(montaPesquisa(), montaPesquisa(1)))
                    {
                        //chamar tela de impressão
                        switch (vTelaPrincipal.vvEmpresa.tipo_relatorio)
                        {
                            case 0:
                                vTelaPrincipal.abrirImpressaoTotalDespesas(vTelaPrincipal);
                                break;
                            case 1:
                                vTelaPrincipal.abrirImpressaoTotalDespesasW(vTelaPrincipal);
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao imprimir consulta!\n" + ex.Message, "EstacionamentoFacil (FrmPesqExtb02)", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
