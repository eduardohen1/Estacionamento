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
    public partial class FrmCadObservacao : Form
    {
        FrmPrincipal vTelaPrincipal;
        carro cCarro;
        vendas cVenda;
        Veiculos veiculos;
        cliente cCliente;
        string sArquivoConexao;
        /// <summary>
        /// 0 Cad carro 1 Cad cliente 2 Cad vendas
        /// </summary>
        int iTela = 0;

        public FrmCadObservacao(string vArquivoConexao, FrmPrincipal vTela_FrmPrincipal, carro ccCarro)
        {
            InitializeComponent();
            sArquivoConexao = vArquivoConexao;
            vTelaPrincipal = vTela_FrmPrincipal;
            cCarro = ccCarro;
            iTela = 0;
        }

        public FrmCadObservacao(string vArquivoConexao, FrmPrincipal vTela_FrmPrincipal, vendas ccVenda)
        {
            InitializeComponent();
            sArquivoConexao = vArquivoConexao;
            vTelaPrincipal = vTela_FrmPrincipal;
            cVenda = ccVenda;
            iTela = 2;
        }

        public FrmCadObservacao(string vArquivoConexao, FrmPrincipal vTela_FrmPrincipal, cliente ccCliente)
        {
            InitializeComponent();
            sArquivoConexao = vArquivoConexao;
            vTelaPrincipal = vTela_FrmPrincipal;
            cCliente = ccCliente;
            iTela = 1;
        }

        private void FrmCadObservacao_Load(object sender, EventArgs e)
        {
            switch (iTela)
            {
                case 0:
                    lblPlacaVeiculo.Text = cCarro.Placa2.Trim();
                    break;
                case 1:
                    lblPlacaVeiculo.Text = cCliente.Nome.Trim();
                    break;
                case 2:
                    lblPlacaVeiculo.Text = "Venda (" + cVenda.cod_venda.ToString("D5") + "/" + cVenda.data_venda.Year.ToString() + ")";
                    break;
            }  
            
        }

        private void cmdGravar_Click(object sender, EventArgs e)
        {
            if (txtObservacao.Text.Trim().Length != 0)
            {
                try
                {
                    observacao cObservacao = new observacao();
                    cObservacao.cod_observacao = 0;
                    cObservacao.cod_usuario = vTelaPrincipal.vvCodigoUsuario;                    
                    cObservacao.data_observacao = DateTime.Now;
                    cObservacao.sObservacao = txtObservacao.Text.Trim();
                    Veiculos veiculos = new Veiculos();
                    veiculos.ArquivoConexao = sArquivoConexao;
                    switch (iTela)
                    {
                        case 0:
                            cObservacao.codigo = cCarro.Codigo;
                            cObservacao.tipo = 0;
                            if (veiculos.inserirObservacaoCarro(cObservacao, this.Name.ToString()))
                            {
                                MessageBox.Show("Observação gravada com sucesso!", "EstacionamentoFacil (FrmObs03a)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                vTelaPrincipal.vTela_FrmCadCarro.lancarObservcao(cCarro);
                                this.Close();
                            }
                            break;
                        case 1:
                            cObservacao.codigo = cCliente.Codigo;
                            cObservacao.tipo = 1;
                            Cliente hCliente = new Cliente();
                            hCliente.ArquivoConexao = sArquivoConexao;
                            if (hCliente.inserirObservacaoCliente(cObservacao, this.Name.ToString()))
                            {
                                MessageBox.Show("Observação gravada com sucesso!", "EstacionamentoFacil (FrmObs03c)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                vTelaPrincipal.vTela_FrmCadCliente.lancarObservacao(cCliente);
                                this.Close();
                            }
                            break;
                        case 2:
                            cObservacao.codigo = cVenda.cod_venda;
                            cObservacao.tipo = 2;
                            if (veiculos.inserirObservacaoVenda(cObservacao, this.Name.ToString()))
                            {
                                MessageBox.Show("Observação gravada com sucesso!", "EstacionamentoFacil (FrmObs03b)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                vTelaPrincipal.vTela_FrmCadVenda.lancarObservacao(cVenda);
                                this.Close();
                            }
                            break;
                    }//switch

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao gravar nova observação.\n" + ex.Message, "EstacionamentoFacil (FrmObs02)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Campo de observação em branco. Verifique!!!", "EstacionamentoFacil (FrmObs01)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
