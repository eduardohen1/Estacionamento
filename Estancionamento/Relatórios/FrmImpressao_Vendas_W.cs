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
    public partial class FrmImpressao_Vendas_W : Form
    {
        FrmPrincipal vTelaPrincipal;
        string sArquivoConexao;
        Veiculos cVeiculos;


        public FrmImpressao_Vendas_W(FrmPrincipal vvTelaPrincipal, string ssArquivoConexao)
        {
            InitializeComponent();
            vTelaPrincipal = vvTelaPrincipal;
            sArquivoConexao = ssArquivoConexao;
        }

        private void FrmImpressao_Vendas_W_Load(object sender, EventArgs e)
        {
            cVeiculos = new Veiculos();
            cVeiculos.ArquivoConexao = sArquivoConexao;
            DataSet dsTemp = cVeiculos.impr_Vendas(0);
            if (dsTemp != null)
            {
                Microsoft.Reporting.WinForms.ReportDataSource rds = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dsTemp.Tables[0]);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Estancionamento.Relatórios.Vendas.rdlc";
                this.reportViewer1.LocalReport.DataSources.Add(rds);
                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();
            }
            else this.Close();
        }
    }
}
