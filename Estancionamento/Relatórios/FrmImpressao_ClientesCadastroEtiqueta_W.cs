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
    public partial class FrmImpressao_ClientesCadastroEtiqueta_W : Form
    {
        FrmPrincipal vTelaPrincipal;
        string sArquivoConexao;

        public FrmImpressao_ClientesCadastroEtiqueta_W(FrmPrincipal vvTelaPrincipal, string ssArquivoConexao)
        {
            InitializeComponent();
            vTelaPrincipal = vvTelaPrincipal;
            sArquivoConexao = ssArquivoConexao;
        }

        private void FrmImpressao_ClientesCadastroEtiqueta_W_Load(object sender, EventArgs e)
        {
            Cliente cCliente = new Cliente();
            cCliente.ArquivoConexao = sArquivoConexao;
            DataSet dsTemp = cCliente.imprimirClientesCadastrados(0);
            if (dsTemp != null)
            {
                Microsoft.Reporting.WinForms.ReportDataSource rds = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dsTemp.Tables[0]);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Estancionamento.Relatórios.ClientesCadastrados_Etiqueta.rdlc";
                this.reportViewer1.LocalReport.DataSources.Add(rds);
                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();
            }
            else this.Close();
        }
    }
}
