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
    public partial class FrmLocalizarVeiculo : Form
    {
        Veiculos veiculos;
        FrmCadCarro vTelaCarro;        
        funcoes cFuncoes;
        Cliente clientes;
        string sArquivoConexao;

        public FrmLocalizarVeiculo(string ssArquivoConexao, FrmCadCarro vvTelaCarro)
        {
            InitializeComponent();
            sArquivoConexao = ssArquivoConexao;
            vTelaCarro = vvTelaCarro;
        }

        private bool validarPesquisa()
        {
            bool bResposta = true;
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    if (txtPlaca.Text.Length == 0)
                    {
                        bResposta = false;
                        MessageBox.Show("Digite a placa do veículo para a pesquisa!", "EstacionamentoFacil (FrmLV01)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case 1:
                    if (cmbMarca.Text.Length == 0)
                    {
                        bResposta = false;
                        MessageBox.Show("Selecione a marca do veículo para a pesquisa!", "EstacionamentoFacil (FrmLV02)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case 2:
                    if (txtChassi.Text.Length == 0)
                    {
                        bResposta = false;
                        MessageBox.Show("Digite o chassi do veículo para a pesquisa!", "EstacionamentoFacil (FrmLV03)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case 3:
                    if (txtAno.Text.Length == 0)
                    {
                        bResposta = false;
                        MessageBox.Show("Digite o ano do veículo para a pesquisa!", "EstacionamentoFacil (FrmLV04)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
            return bResposta;
        }

        private void pesquisarVeiculos()
        {
            List<carro> lstCarro = null;
            string sSQL = "";
            DataGridViewRow row;

            if (validarPesquisa())
            {
                veiculos = new Veiculos();
                clientes = new Cliente();
                veiculos.ArquivoConexao = sArquivoConexao;
                clientes.ArquivoConexao = sArquivoConexao;
                limparGrid();
                switch (tabControl1.SelectedIndex)
                {
                    case 0:
                        if (!txtPlaca.Text.Trim().Equals("*"))
                            sSQL = " Placa2 LIKE '%" + txtPlaca.Text.Trim() + "%'";
                        else
                            sSQL = "";
                        break;
                    case 1:
                        ComboBoxItem cmbItem = (ComboBoxItem)cmbMarca.SelectedItem;
                        sSQL = " CodMarca = " + cmbItem.Value.ToString();
                        break;
                    case 2:
                        if (!txtChassi.Text.Trim().Equals("*"))
                            sSQL = " Chassi2 = '" + txtChassi.Text.Trim() + "'";
                        else
                            sSQL = "";
                        break;
                    case 3:
                        if (!txtAno.Text.Trim().Equals("*"))
                            sSQL = " (AnoFab = " + txtAno.Text.Trim() + " OR AnoMod = " + txtAno.Text.Trim() + " )";
                        else
                            sSQL = "";
                        break;
                }
                lstCarro = veiculos.localizaDadosCarro(sSQL);
                if (lstCarro != null)
                {
                    if (lstCarro.Count > 0)
                    {   
                        row = new DataGridViewRow();
                        foreach (carro cCarro in lstCarro)
                        {                            
                            gridHistorico.AllowUserToAddRows = true;
                            row = (DataGridViewRow)gridHistorico.Rows[0].Clone();
                            gridHistorico.AllowUserToAddRows = false;
                            row.Cells[0].Value = cCarro.Codigo.ToString();
                            row.Cells[1].Value = cCarro.Placa2.ToString().Trim();
                            row.Cells[2].Value = veiculos.pesquisarMarca(cCarro.CodMarca).descricao.ToString().Trim();
                            int iCodClienteCarro = veiculos.buscaClienteCarro(cCarro.Codigo);
                            if (iCodClienteCarro > 0)
                                row.Cells[3].Value = clientes.pesquisarCliente(iCodClienteCarro).Nome.Trim();
                            else
                                row.Cells[3].Value = "";
                            gridHistorico.Rows.Add(row);
                        }
                    }
                }
            }            
        }

        private void selecionaVeiculo()
        {
            int iCodigo = 0;
            if (gridHistorico.Rows.Count > 0)
            {
                iCodigo = int.Parse(gridHistorico.CurrentRow.Cells[0].Value.ToString());
                if (iCodigo > 0)
                {
                    carro cCarro = new carro();
                    veiculos = new Veiculos();
                    veiculos.ArquivoConexao = sArquivoConexao;

                    cCarro = veiculos.pesquisarCarro(iCodigo);
                    if (cCarro != null)
                    {
                        vTelaCarro.exibirDadosVeiculo(cCarro);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Nenhum veículo selecionado.", "EstacionamentoFacil (FrmLV05)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Nenhum veículo selecionado.", "EstacionamentoFacil (FrmLV06)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Nenhum veículo encontrado.", "EstacionamentoFacil (FrmLV07)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPlaca_Enter(object sender, EventArgs e)
        {
            limparGrid();
        }

        private void limparGrid()
        {
            gridHistorico.Rows.Clear();
        }

        private void cmbMarca_Enter(object sender, EventArgs e)
        {
            limparGrid();
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            limparGrid();
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            limparGrid();
        }

        private void cmdPesquisar_Click(object sender, EventArgs e)
        {
            pesquisarVeiculos();
        }

        private void gridHistorico_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selecionaVeiculo();
        }

        private void FrmLocalizarVeiculo_Load(object sender, EventArgs e)
        {
            //preencher combo de marca:
            List<marca> listMarca = new List<marca>();
            veiculos = new Veiculos();
            veiculos.ArquivoConexao = sArquivoConexao;
            listMarca = veiculos.pesquisarTodasMarcas();
            foreach (marca lstMarca in listMarca)
            {
                ComboBoxItem cboItem = new ComboBoxItem();
                cboItem.Text = lstMarca.descricao;
                cboItem.Value = lstMarca.codigo;
                cmbMarca.Items.Add(cboItem);
            }
            txtPlaca.Focus();
        }

        private void txtPlaca_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) pesquisarVeiculos();
        }

        private void txtChassi_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) pesquisarVeiculos();
        }

        private void txtAno_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) pesquisarVeiculos();
        }

        private void cmdGravar_Click(object sender, EventArgs e)
        {
            selecionaVeiculo();
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
