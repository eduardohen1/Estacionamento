using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


namespace Estancionamento
{
    public partial class FrmNovoTelefone : Form
    {

        FrmPrincipal vTelaPrincipal;
        Cliente clientes;
        string sArquivoConexao;
        byte bTela;

        /// <summary>
        /// Inicio de nova tela de telefone
        /// </summary>
        /// <param name="vArquivoConexao">Endereço do arquivo de conexao com BD</param>
        /// <param name="vTela_FrmPrincipal">Classe do formulário principal</param>
        /// <param name="bTela">Tela de origem 0 - CadCliente, 1 - CadVendedor</param>
        public FrmNovoTelefone(string vArquivoConexao, FrmPrincipal vTela_FrmPrincipal, byte bbTela)
        {
            InitializeComponent();
            sArquivoConexao = vArquivoConexao;
            vTelaPrincipal = vTela_FrmPrincipal;
            bTela = bbTela;
        }

        private void FrmNovoTelefone_Load(object sender, EventArgs e)
        {
            ve_se_existe();
        }

        private void ve_se_existe()
        {
            try
            {
                cmbOperadora.Items.Clear();
                List<Operadora> listOperadora = new List<Operadora>();
                ComboBoxItem cboOperadora;
                clientes = new Cliente();
                clientes.ArquivoConexao = sArquivoConexao;
                listOperadora = clientes.pesquisarTodasOperadoras();
                foreach (Operadora lstOperadora in listOperadora)
                {
                    cboOperadora = new ComboBoxItem();
                    cboOperadora.Text = lstOperadora.operadora;
                    cboOperadora.Value = lstOperadora.Codigo;
                    cmbOperadora.Items.Add(cboOperadora);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir janela de Novo telefone! " + ex.Message, "EstacionamentoFacil (FrmNT01)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTelefone_Leave(object sender, EventArgs e)
        {
            if (txtTelefone.Text.Length == 8)
                txtTelefone.Mask = "#### - ####";
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool validaTela()
        {
            bool bResposta = true;

            if (txtDDD.Text.Length == 0)
            {
                bResposta = false;
                MessageBox.Show("DDD em branco. Verifique!", "EstacionamentoFacil (FrmNT02)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (txtTelefone.Text.Length == 0 && bResposta)
            {
                bResposta = false;
                MessageBox.Show("Telefone em branco. Verifique!", "EstacionamentoFacil (FrmNT03)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (cmbOperadora.Text.Length == 0 && bResposta)
            {
                bResposta = false;
                MessageBox.Show("Selecione uma operadora!", "EstacionamentoFacil (FrmNT04)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if(cmbTipoTelefone.Text.Length == 0 && bResposta){
                bResposta = false;
                MessageBox.Show("Selecione um tipo de telefone!", "EstacionamentoFacil (FrmNT05)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return bResposta;
        }

        private void cmdGravar_Click(object sender, EventArgs e)
        {
            if (validaTela())
            {
                ComboBoxItem cmbItem = new ComboBoxItem();
                cmbItem = (ComboBoxItem)cmbOperadora.SelectedItem;

                TelefoneToken cTelefone = new TelefoneToken();
                cTelefone.Codigo = "N";
                cTelefone.ddd = txtDDD.Text;
                cTelefone.telefone = txtTelefone.Text;
                cTelefone.Codigo_Operadora = int.Parse(cmbItem.Value.ToString());
                switch (cmbTipoTelefone.Text)
                {
                    case "FIXO":
                        cTelefone.Tipo_telefone = 0;
                        break;
                    case "CELULAR":
                        cTelefone.Tipo_telefone = 1;
                        break;
                    case "OUTROS":
                        cTelefone.Tipo_telefone  = 2;
                        break;
                }
                switch (bTela)
                {
                    case 0:
                        vTelaPrincipal.vTela_FrmCadCliente.lancarTelefone(cTelefone);
                        break;
                    case 1:
                        vTelaPrincipal.vTela_FrmCadVendedor.lancarTelefone(cTelefone);
                        break;
                }
                this.Close();
            }
        }

        private void txtTelefone_Enter(object sender, EventArgs e)
        {
            txtTelefone.Mask = "##### - ####";
        }
    }
}
