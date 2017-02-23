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
    public partial class FrmCadOpcionais : Form
    {
        FrmPrincipal vTelaPrincipal;
        Veiculos veiculos;
        string sArquivoConexao;

        public FrmCadOpcionais(string vArquivoConexao, FrmPrincipal vvTelaPrincipal)
        {
            InitializeComponent();
            sArquivoConexao = vArquivoConexao;
            vTelaPrincipal = vvTelaPrincipal;
        }

        private void FrmCadOpcionais_Load(object sender, EventArgs e)
        {
            ve_se_existe();
        }

        private void ve_se_existe()
        {
            try
            {
                cmbOpcionais.Items.Clear();
                List<opicionais> listOpcionais = new List<opicionais>();
                ComboBoxItem cboItem;
                veiculos = new Veiculos();
                veiculos.ArquivoConexao = sArquivoConexao;
                listOpcionais = veiculos.pesquisarTodosOpicionais();
                foreach (opicionais lstOpcionais in listOpcionais)
                {
                    cboItem = new ComboBoxItem();
                    cboItem.Text = lstOpcionais.descricao;
                    cboItem.Value = lstOpcionais.codigo;
                    cmbOpcionais.Items.Add(cboItem);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao abrir janela de Opcionais! " + ex.Message, "EstacionamentoFacil (FrmOp01)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool validaTela()
        {
            bool bResposta = true;
            if (cmbOpcionais.Text.Length == 0)
            {
                bResposta = false;
                MessageBox.Show("Descrição da opcionais em branco. Verifique! ", "EstacionamentoFacil (FrmOp02)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return bResposta;
        }

        private void excluirOpcional()
        {
            veiculos = new Veiculos();
            veiculos.ArquivoConexao = sArquivoConexao;

            ComboBoxItem cmbItem = new ComboBoxItem();
            cmbItem = (ComboBoxItem)cmbOpcionais.SelectedItem;

            if (cmbItem != null)
            {
                if (MessageBox.Show("Deseja realmente excluir este Opcional?", "EstacionamentoFacil (FrmOp07)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string sMotivo = Microsoft.VisualBasic.Interaction.InputBox("Qual o motivo da exclusão?", "Motivo da exclusão");
                    if (sMotivo.Length == 0) sMotivo = "Motivo não declarado pelo usuário " + vTelaPrincipal.vvNomeUsuario.Trim();
                    if (veiculos.excluirOpcional(int.Parse(cmbItem.Value.ToString()), sMotivo, this.Text, vTelaPrincipal.vvCodigoUsuario))
                    {
                        MessageBox.Show("Opcional excluído com sucesso!", "EstacionamentoFacil (FrmOp08)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ve_se_existe();
                    }
                }
            }
            else
            {
                MessageBox.Show("Registro de Marca novo. Não permitida exclusão!", "EstacionamentoFacil (FrmOp09)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void gravar()
        {
            opicionais cOpcionais = new opicionais();
            veiculos = new Veiculos();
            veiculos.ArquivoConexao = sArquivoConexao;
            if (validaTela())
            {
                ComboBoxItem cmbItem = new ComboBoxItem();
                cmbItem = (ComboBoxItem)cmbOpcionais.SelectedItem;

                if (cmbItem != null)
                {
                    //novo
                    cOpcionais.codigo = int.Parse(cmbItem.Value.ToString());
                    cOpcionais.descricao = cmbItem.Text;
                    if (veiculos.gravarOpicionais(cOpcionais, 1))
                    {
                        MessageBox.Show("Opcional atualizado com sucesso!", "EstacionamentoFacil (FrmOp03)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ve_se_existe();
                    }
                    else
                    {
                        MessageBox.Show("O opcional não foi inserida!", "EstacionamentoFacil (FrmOp04)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    //novo
                    cOpcionais.codigo = 0;
                    cOpcionais.descricao = cmbOpcionais.Text;
                    if (veiculos.gravarOpicionais(cOpcionais, 0))
                    {
                        MessageBox.Show("Opcional atualizado com sucesso!", "EstacionamentoFacil (FrmOp05)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ve_se_existe();
                    }
                    else
                    {
                        MessageBox.Show("O opcional não foi inserido!", "EstacionamentoFacil (FrmOp06)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void sairTela()
        {
            this.Close();
        }

        private void cmdGravar_Click(object sender, EventArgs e)
        {
            gravar();
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            sairTela();
        }

        private void cmbOpcionais_Enter(object sender, EventArgs e)
        {
            cmbOpcionais.SelectedIndex = -1;
        }

        private void cmdExcluir_Click(object sender, EventArgs e)
        {
            excluirOpcional();
        }



    }
}
