using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Estancionamento.Relatórios
{
    public partial class FrmImpressao_Auditoria_W : Form
    {
        SqlConnection cmConexao = null;
        FrmPrincipal vTelaPrincipal;
        string sArquivoConexao;
        Usuarios cUsuario;

        public FrmImpressao_Auditoria_W(FrmPrincipal vvTelaPrincipal, string ssArquivoConexao)
        {
            InitializeComponent();
            vTelaPrincipal = vvTelaPrincipal;
            sArquivoConexao = ssArquivoConexao;
        }

        private void FrmImpressao_Auditoria_W_Load(object sender, EventArgs e)
        {
            cUsuario = new Usuarios();
            cUsuario.ArquivoConexao = sArquivoConexao;
            DataSet dsTemp = cUsuario.imprimirAuditoriaW(0);
            if (dsTemp != null)
            {
                Microsoft.Reporting.WinForms.ReportDataSource rds = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dsTemp.Tables[0]);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Estancionamento.Relatórios.Auditoria.rdlc";
                this.reportViewer1.LocalReport.DataSources.Add(rds);
                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();
            }
            else this.Close();
            
        }
        
        private bool imprimirRelatorio()
        {
            bool bResposta = true;
            cmConexao = cUsuario.imprimirAuditoriaW();
            if (cmConexao == null) bResposta = false;            
            return bResposta;
        }
    }
}
