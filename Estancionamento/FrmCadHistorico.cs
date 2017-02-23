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
    public partial class FrmCadHistorico : Form
    {
        carro cCarro;
        FrmPrincipal vTelaPrincipal;        
        string sArquivoConexao;
        bool bNovoVeiculo;

        public FrmCadHistorico(string vArquivoConexao, FrmPrincipal vTela_FrmPrincipal,carro ccCarro, bool bbNovoVeiculo)
        {
            InitializeComponent();
            cCarro = ccCarro;
            sArquivoConexao = vArquivoConexao;
            vTelaPrincipal = vTela_FrmPrincipal;
            bNovoVeiculo = bbNovoVeiculo;
        }

        private void FrmCadHistorico_Load(object sender, EventArgs e)
        {
            if (bNovoVeiculo)
                cmdFechar.Enabled = false;
            lblPlacaVeiculo.Text = cCarro.Placa2;            
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdGravar_Click(object sender, EventArgs e)
        {
            int iTipo = 0;
            historico cHistorico;
            Veiculos veiculos;

            if (validaTela())
            {
                try
                {
                    
                    switch (cmbTipo.Text.ToUpper())
                    {
                        case "COMPRA":
                            iTipo = 0;
                            break;
                        case "VENDA":
                            iTipo = 1;
                            break;
                        case "ENTRADA ESTACIONAMENTO":
                            iTipo = 2;
                            break;
                        case "SAÍDA ESTACIONAMENTO":
                            iTipo = 3;
                            break;
                        case "TEXTO":
                            iTipo = 4;
                            break;
                    }

                    cHistorico = new historico();
                    cHistorico.cod_historico = 0;
                    cHistorico.cod_carro = cCarro.Codigo;
                    cHistorico.cod_usuario = vTelaPrincipal.vvCodigoUsuario;
                    cHistorico.data_hist = DateTime.Now;
                    cHistorico.observacao = txtObservacao.Text;
                    cHistorico.tipo = iTipo;

                    veiculos = new Veiculos();
                    veiculos.ArquivoConexao = sArquivoConexao;
                    if (veiculos.inserirAtualizarHistorico(cHistorico, 0,this.Name,vTelaPrincipal.vvCodigoUsuario))
                    {
                        MessageBox.Show("Histórico gravado com sucesso!", "EstacionamentoFacil (FrmCdH02)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (!bNovoVeiculo)
                            vTelaPrincipal.vTela_FrmCadCarro.lancarHistorico(cCarro);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao gravar dados de histórico: " + ex.Message, "EstacionamentoFacil (FrmCdH01)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }//valida tela
        }

        private bool validaTela()
        {
            bool bResposta = true;
            if (cmbTipo.Text.Length == 0)
            {
                MessageBox.Show("Selecione uma opção de Tipo de movimentação." , "EstacionamentoFacil (FrmCdH03)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bResposta = false;
            }

            if (txtObservacao.Text.Length == 0 && !bResposta)
            {
                MessageBox.Show("Digite uma observação para a movimentação.", "EstacionamentoFacil (FrmCdH04)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bResposta = false;
            }
            return bResposta;
        }

    }
}
