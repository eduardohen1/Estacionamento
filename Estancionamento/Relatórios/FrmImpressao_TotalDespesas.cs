﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Estancionamento.Relatórios
{
    public partial class FrmImpressao_TotalDespesas : Form
    {
        FrmPrincipal vTelaPrincipal;
        string sArquivoConexao;
        Veiculos cVeiculos;

        public FrmImpressao_TotalDespesas(FrmPrincipal vvTelaPrincipal, string ssArquivoConexao)
        {
            InitializeComponent();
            vTelaPrincipal = vvTelaPrincipal;
            sArquivoConexao = ssArquivoConexao;
        }

        private void FrmImpressao_TotalDespesas_Load(object sender, EventArgs e)
        {
            if (!imprimirRelatorio()) this.Close();
        }

        private bool imprimirRelatorio()
        {
            bool bResposta = true;
            CrystalDecisions.Windows.Forms.CrystalReportViewer relatorio;
            cVeiculos = new Veiculos();
            cVeiculos.ArquivoConexao = sArquivoConexao;

            relatorio = cVeiculos.impr_TotalDespesas();
            if (relatorio != null)
                crystalReportViewer1.ReportSource = relatorio.ReportSource;
            else
            {
                MessageBox.Show("Erro ao abrir tela de impressão!", "EstacionamentoFacil (FrmImpExb01)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                bResposta = false;
            }
            return bResposta;
        }
    }
}
