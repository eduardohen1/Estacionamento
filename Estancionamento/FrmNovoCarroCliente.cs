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
    public partial class FrmNovoCarroCliente : Form
    {
        public string sCodigosExistentes;
        FrmPrincipal vTelaPrincipal;
        Cliente clientes;
        cliente cCliente;
        Veiculos veiculos;
        string sArquivoConexao;        

        public FrmNovoCarroCliente(string vArquivoConexao, FrmPrincipal vTela_FrmPrincipal, cliente ccCliente)
        {
            InitializeComponent();
            sArquivoConexao = vArquivoConexao;
            vTelaPrincipal = vTela_FrmPrincipal;
            cCliente = ccCliente;
        }

        private void FrmNovoCarroCliente_Load(object sender, EventArgs e)
        {
            ve_se_existe();
        }

        private void ve_se_existe()
        {
            int iQte = 0;
            bool bResposta = true;
            marca cMarca = new marca();
            try
            {
                chkListCarro.Items.Clear();
                
                clientes = new Cliente();
                clientes.ArquivoConexao = sArquivoConexao;
                veiculos = new Veiculos();
                veiculos.ArquivoConexao = sArquivoConexao;

                List<carro> listCarro = new List<carro>();
                ComboBoxItem cboItem;
                listCarro = veiculos.pesquisarTodosCarrosSemClientes(sCodigosExistentes);

                foreach (carro lstCarro in listCarro)
                {
                    cMarca = veiculos.pesquisarMarca(lstCarro.CodMarca);
                    cboItem = new ComboBoxItem();
                    cboItem.Text = lstCarro.Placa2 + " - " + cMarca.descricao;
                    cboItem.Value = lstCarro.Codigo;
                    chkListCarro.Items.Add(cboItem);
                    iQte++;
                }
                if (iQte == 0)
                {
                    MessageBox.Show("Nenhum veículo cadastrado!", "EstacionamentoFacil (FrmNCr03)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    bResposta = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir janela de Novo carro de cliente! " + ex.Message, "EstacionamentoFacil (FrmNCr01)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bResposta = false;
            }
            if (!bResposta)
                cmdGravar.Enabled = false;
        }

        private bool validaTela()
        {
            bool bResposta = true;

            if (chkListCarro.CheckedItems.Count == 0)
            {
                bResposta = false;
                MessageBox.Show("Selecione um veículo para adicionar!", "EstacionamentoFacil (FrmNCr02)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return bResposta;
        }

        private void cmdGravar_Click(object sender, EventArgs e)
        {
            if (validaTela())
            {
                carro cCarro;
                veiculos = new Veiculos();
                veiculos.ArquivoConexao = sArquivoConexao;

                foreach (ComboBoxItem item in chkListCarro.CheckedItems)
                {
                    cCarro = veiculos.pesquisarCarro(int.Parse(item.Value.ToString()));
                    vTelaPrincipal.vTela_FrmCadCliente.lancarVeiculo(cCarro, cCliente);
                }
                this.Close();
            }
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
