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
    public partial class FrmCadMarca : Form
    {
        FrmPrincipal vTelaPrincipal;
        Veiculos veiculos;
        string sArquivoConexao;

        public FrmCadMarca(string vArquivoConexao, FrmPrincipal vvTelaPrincipal)
        {
            InitializeComponent();
            sArquivoConexao = vArquivoConexao;
            vTelaPrincipal = vvTelaPrincipal;
        }

        private void FrmCadMarca_Load(object sender, EventArgs e)
        {
            ve_se_existe();
        }

        private void ve_se_existe()
        {
            try
            {
                cmbMarca.Items.Clear();
                List<marca> listMarca = new List<marca>();
                ComboBoxItem cboItem;
                veiculos = new Veiculos();
                veiculos.ArquivoConexao = sArquivoConexao;
                listMarca = veiculos.pesquisarTodasMarcas();
                foreach (marca lstMarca in listMarca)
                {
                    cboItem = new ComboBoxItem();
                    cboItem.Text = lstMarca.descricao;
                    cboItem.Value = lstMarca.codigo;
                    cmbMarca.Items.Add(cboItem);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao abrir janela de Marcas! " + ex.Message, "EstacionamentoFacil (FrmMr01)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool validaTela()
        {
            bool bResposta = true;
            if (cmbMarca.Text.Length == 0)
            {
                bResposta = false;
                MessageBox.Show("Descrição da marca em branco. Verifique! ", "EstacionamentoFacil (FrmMr02)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return bResposta;
        }

        private void gravar()
        {
            marca cMarca = new marca();
            veiculos = new Veiculos();
            veiculos.ArquivoConexao = sArquivoConexao;
            if (validaTela())
            {
                ComboBoxItem cmbItem = new ComboBoxItem();
                cmbItem = (ComboBoxItem)cmbMarca.SelectedItem;

                if (cmbItem != null)
                {
                    //novo
                    cMarca.codigo = int.Parse(cmbItem.Value.ToString());
                    cMarca.descricao = cmbItem.Text;
                    if (veiculos.gravarMarca(cMarca,1))
                    {
                        MessageBox.Show("Marca atualizada com sucesso!", "EstacionamentoFacil (FrmMr03)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ve_se_existe();
                    }
                    else
                    {
                        MessageBox.Show("A marca não foi inserida!", "EstacionamentoFacil (FrmMr04)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    //novo
                    cMarca.codigo = 0;
                    cMarca.descricao = cmbMarca.Text;
                    if (veiculos.gravarMarca(cMarca,0))
                    {
                        MessageBox.Show("Marca atualizada com sucesso!", "EstacionamentoFacil (FrmMr05)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ve_se_existe();
                    }
                    else
                    {
                        MessageBox.Show("A marca não foi inserida!", "EstacionamentoFacil (FrmMr06)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void excluirMarca()
        {
            veiculos = new Veiculos();
            veiculos.ArquivoConexao = sArquivoConexao;
            
            ComboBoxItem cmbItem = new ComboBoxItem();
            cmbItem = (ComboBoxItem)cmbMarca.SelectedItem;

            if (cmbItem != null)
            {
                if (MessageBox.Show("Deseja realmente excluir esta Marca?", "EstacionamentoFacil (FrmMr10)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string sMotivo = Microsoft.VisualBasic.Interaction.InputBox("Qual o motivo da exclusão?", "Motivo da exclusão");
                    if (sMotivo.Length == 0) sMotivo = "Motivo não declarado pelo usuário " + vTelaPrincipal.vvNomeUsuario.Trim();
                    if (veiculos.excluirMarca(int.Parse(cmbItem.Value.ToString()), sMotivo, this.Text, vTelaPrincipal.vvCodigoUsuario))
                    {
                        MessageBox.Show("Marca excluída com sucesso!", "EstacionamentoFacil (FrmMr11)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ve_se_existe();
                    }
                }
            }
            else
            {
                MessageBox.Show("Registro de Marca novo. Não permitida exclusão!", "EstacionamentoFacil (FrmMr09)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }            
        }

        private void sairTela()
        {
            this.Close();
        }

        private void cmbMarca_Enter(object sender, EventArgs e)
        {
            cmbMarca.SelectedIndex = -1;
        }

        private void cmdGravar_Click(object sender, EventArgs e)
        {
            gravar();
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            sairTela();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ComboBoxItem cmbItem = new ComboBoxItem();
            cmbItem = (ComboBoxItem)cmbMarca.SelectedItem;
            if (cmbItem != null)
            {
                marca cMarca = new marca();
                veiculos = new Veiculos();
                veiculos.ArquivoConexao = sArquivoConexao;

                string sNome = Microsoft.VisualBasic.Interaction.InputBox("Qual a nova descrição?", "Novo descrição",cmbItem.Text);
                if (sNome.Trim().Length != 0)
                {
                    cMarca = veiculos.pesquisarMarca(int.Parse(cmbItem.Value.ToString()));
                    cMarca.descricao = sNome.Trim();
                    if (veiculos.gravarMarca(cMarca,1))
                    {
                        MessageBox.Show("Descrição alterada com sucesso!", "EstacionamentoFacil (FrmMr07)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ve_se_existe();
                    }
                }

            }
            else
            {
                MessageBox.Show("Alteração permitida somente para cadastros já gravados!", "EstacionamentoFacil (FrmMr08)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmdExcluir_Click(object sender, EventArgs e)
        {
            excluirMarca();
        }
    }
}
