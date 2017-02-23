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
    public partial class FrmCadOperadora : Form
    {
        Cliente cliente;
        string sArquivoConexao;

        public FrmCadOperadora(string vArquivoConexao)
        {
            InitializeComponent();
            sArquivoConexao = vArquivoConexao;
        }

        private void FrmCadOperadora_Load(object sender, EventArgs e)
        {
            ve_se_existe();
        }

        private void ve_se_existe()
        {
            try
            {
                cmbOperadora.Items.Clear();
                //buscar dados de operadora
                List<Operadora> listOperadora = new List<Operadora>();
                ComboBoxItem cboOperadora;
                cliente = new Cliente();
                cliente.ArquivoConexao = sArquivoConexao;
                listOperadora = cliente.pesquisarTodasOperadoras();
                foreach (Operadora lstOperadora in listOperadora)
                {
                    cboOperadora = new ComboBoxItem();
                    cboOperadora.Text = lstOperadora.operadora;
                    cboOperadora.Value = lstOperadora.Codigo;
                    cmbOperadora.Items.Add(cboOperadora);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao abrir janela de Operadoras! " + ex.Message, "EstacionamentoFacil (FrmOp01)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool validaTela()
        {
            bool bResposta = true;
            if (cmbOperadora.Text.Length == 0)
            {
                bResposta = false;
                MessageBox.Show("Nome da Operadora em branco. Verifique! ", "EstacionamentoFacil (FrmOp02)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return bResposta;
        }
        private void gravarOperadora()
        {
            Operadora cOperadora = new Operadora();            
            cliente = new Cliente();
            cliente.ArquivoConexao = sArquivoConexao;
            if (validaTela())
            {
                ComboBoxItem cmbItem = new ComboBoxItem();
                cmbItem = (ComboBoxItem)cmbOperadora.SelectedItem;

                if (cmbItem != null)
                {
                    //novo
                    cOperadora.Codigo = int.Parse(cmbItem.Value.ToString());
                    cOperadora.operadora = cmbItem.Text;
                    if (cliente.gravarOperadora(cOperadora,1)) { 
                        MessageBox.Show("Operadora atualizada com sucesso!", "EstacionamentoFacil (FrmOp03)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ve_se_existe();
                    }
                    else
                    {
                        MessageBox.Show("A Operadora não foi inserida!", "EstacionamentoFacil (FrmOp04)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    //novo
                    cOperadora.Codigo = 0;
                    cOperadora.operadora = cmbOperadora.Text;
                    if (cliente.gravarOperadora(cOperadora, 0)) { 
                        MessageBox.Show("Operadora atualizada com sucesso!", "EstacionamentoFacil (FrmOp05)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ve_se_existe();
                    }
                    else
                    {
                        MessageBox.Show("A Operadora não foi inserida!", "EstacionamentoFacil (FrmOp06)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }                
            }
        }
        private void sairOperadora()
        {
            this.Close();
        }
        private void excluirOperadora()
        {
            Operadora cOperadora = new Operadora();
            cliente = new Cliente();
            cliente.ArquivoConexao = sArquivoConexao;
            if (validaTela())
            {
                ComboBoxItem cmbItem = new ComboBoxItem();
                cmbItem = (ComboBoxItem)cmbOperadora.SelectedItem;
                if (cmbItem != null)
                {
                    //atualizar
                    if (!cliente.seExisteOperadora(cmbOperadora.Text))
                    {
                        if (cliente.excluirOperadora(int.Parse(cmbItem.Value.ToString())))
                        {
                            MessageBox.Show("Operadora excluída com sucesso!", "EstacionamentoFacil (FrmOp07)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ve_se_existe();
                        }
                        else
                        {
                            MessageBox.Show("A Operadora não foi excluída!", "EstacionamentoFacil (FrmOp08)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Operadora não cadastrada. Exclusão não executada!", "EstacionamentoFacil (FrmOp09)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void cmbOperadora_Enter(object sender, EventArgs e)
        {
            cmbOperadora.SelectedIndex = -1;
        }

        private void cmdGravar_Click(object sender, EventArgs e)
        {
            gravarOperadora();
        }

        private void cmdExcluir_Click(object sender, EventArgs e)
        {
            excluirOperadora();
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            sairOperadora();
        }

    }
}
