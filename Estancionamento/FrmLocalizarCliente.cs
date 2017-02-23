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
    public partial class FrmLocalizarCliente : Form
    {
        FrmCadCliente vTelaCliente;
        funcoes cFuncoes;
        Cliente clientes;
        string sArquivoConexao;

        public FrmLocalizarCliente(string ssArquivoConexao, FrmCadCliente vvTelaCliente)
        {
            InitializeComponent();
            sArquivoConexao = ssArquivoConexao;
            vTelaCliente = vvTelaCliente;
        }

        private bool validarPesquisa()
        {
            bool bResposta = true;
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    if (txtNome.Text.Length == 0)
                    {
                        bResposta = false;
                        MessageBox.Show("Digite o nome do cliente para a pesquisa!", "EstacionamentoFacil (FrmLC01)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case 1:
                    if (txtCPF.Text.Length == 0)
                    {
                        bResposta = false;
                        MessageBox.Show("Digite o CPF do cliente para a pesquisa!", "EstacionamentoFacil (FrmLC02)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
            return bResposta;
        }

        private void pesquisarCliente()
        {
            List<cliente> lstCliente = null;
            string sSQL = "";
            DataGridViewRow row;

            if (validarPesquisa())
            {   
                clientes = new Cliente();
                clientes.ArquivoConexao = sArquivoConexao;
                limparGrid();
                switch (tabControl1.SelectedIndex)
                {
                    case 0:
                        if (!txtNome.Text.Trim().Equals("*"))
                            sSQL = " Nome LIKE '%" + txtNome.Text.Trim() + "%'";
                        else
                            sSQL = "";
                        break;
                    case 1:
                        sSQL = " CPF = '" + txtCPF.Text.Trim()  + "'";
                        break;                    
                }
                lstCliente = clientes.localizarDadosCliente(sSQL);
                if (lstCliente != null)
                {
                    if (lstCliente.Count > 0)
                    {
                        row = new DataGridViewRow();
                        foreach (cliente cCliente in lstCliente)
                        {
                            gridHistorico.AllowUserToAddRows = true;
                            row = (DataGridViewRow)gridHistorico.Rows[0].Clone();
                            gridHistorico.AllowUserToAddRows = false;
                            row.Cells[0].Value = cCliente.Codigo.ToString();
                            row.Cells[1].Value = cCliente.Nome.ToString().Trim();
                            row.Cells[2].Value = cCliente.CPF.ToString().Trim();                            
                            gridHistorico.Rows.Add(row);
                        }
                    }
                }
            }
        }

        private void selecionaCliente()
        {
            int iCodigo = 0;
            if (gridHistorico.Rows.Count > 0)
            {
                iCodigo = int.Parse(gridHistorico.CurrentRow.Cells[0].Value.ToString());
                if (iCodigo > 0)
                {
                    cliente cCliente = new cliente();
                    clientes = new Cliente();
                    clientes.ArquivoConexao = sArquivoConexao;
                    cCliente = clientes.pesquisarCliente(iCodigo);
                    if (cCliente != null)
                    {
                        vTelaCliente.exibirDadosCliente(cCliente);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Nenhum cliente selecionado.", "EstacionamentoFacil (FrmLC05)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Nenhum cliente selecionado.", "EstacionamentoFacil (FrmLC06)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Nenhum cliente encontrado.", "EstacionamentoFacil (FrmLC07)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void limparGrid()
        {
            gridHistorico.Rows.Clear();
        }

        private void FrmLocalizarCliente_Load(object sender, EventArgs e)
        {
            txtNome.Focus();
        }

        private void txtNome_Enter(object sender, EventArgs e)
        {
            limparGrid();
        }

        private void txtCPF_Enter(object sender, EventArgs e)
        {
            limparGrid();
        }

        private void txtCPF_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) pesquisarCliente();
        }

        private void txtNome_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) pesquisarCliente();
        }

        private void cmdPesquisar_Click(object sender, EventArgs e)
        {
            pesquisarCliente();
        }

        private void gridHistorico_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selecionaCliente();
        }

        private void cmdGravar_Click(object sender, EventArgs e)
        {
            selecionaCliente();
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
