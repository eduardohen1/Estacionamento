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
    public partial class FrmCadBairro : Form
    {
        
        Enderecos enderecos;
        string sArquivoConexao;

        public FrmCadBairro(string vArquivoConexao)
        {
            InitializeComponent();
            sArquivoConexao = vArquivoConexao;
        }

        private void FrmCadBairro_Load(object sender, EventArgs e)
        {
            ve_se_existe();
        }

        private void ve_se_existe()
        {
            try
            {
                cmbBairro.Items.Clear();
                cmbLocalidade.Items.Clear();

                //buscar dados de localidade:
                List<Localidade> listLocalidade = new List<Localidade>();
                ComboBoxItem cboMunicipio;
                enderecos = new Enderecos();
                enderecos.ArquivoConexao = sArquivoConexao;
                listLocalidade = enderecos.pesquisarTodosLocalidade();
                foreach (Localidade lstLocalidade in listLocalidade)
                {
                    cboMunicipio = new ComboBoxItem();
                    cboMunicipio.Text = lstLocalidade.Nome_localidade;
                    cboMunicipio.Value = lstLocalidade.Codigo;
                    cmbLocalidade.Items.Add(cboMunicipio);
                }

                List<Bairro> listBairro = new List<Bairro>();
                ComboBoxItem cboBairro;
                listBairro = enderecos.pesquisarTodosBairro();
                foreach (Bairro lstBairro in listBairro)
                {
                    cboBairro = new ComboBoxItem();
                    cboBairro.Text = lstBairro.Nome_bairro;
                    cboBairro.Value = lstBairro.Codigo;
                    cmbBairro.Items.Add(cboBairro);
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao abrir janela de Bairro! " + ex.Message, "EstacionamentoFacil (FrmB01)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool validaTela()
        {
            bool bResposta = true;
            if (cmbBairro.Text.Length == 0)
            {
                bResposta = false;
                MessageBox.Show("Nome do Bairro em branco. Verifique! ", "EstacionamentoFacil (FrmB02)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (bResposta && cmbLocalidade.Text.Length == 0)
            {
                bResposta = false;
                MessageBox.Show("Nome da localidade em branca. Verifique! ", "EstacionamentoFacil (FrmB03)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return bResposta;
        }

        private string buscaLocalidade(int iCodigoBairro)
        {
            string sResposta = "";
            Localidade cLocalidade;
            Bairro cBairro;
            enderecos = new Enderecos();
            enderecos.ArquivoConexao = sArquivoConexao;
            try
            {
                cBairro = enderecos.pesquisarBairro(iCodigoBairro);
                cLocalidade = enderecos.pesquisarLocalidade(cBairro.Cod_localidade);                
                sResposta = cLocalidade.Nome_localidade;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao buscar Localidade do Bairro! " + ex.Message, "EstacionamentoFacil (FrmB04)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return sResposta;
        }

        private void gravarBairro()
        {
            Bairro cBairro = new Bairro();
            ComboBoxItem cmbItemL;
            enderecos = new Enderecos();
            enderecos.ArquivoConexao = sArquivoConexao;
            if (validaTela())
            {
                ComboBoxItem cmbItem = new ComboBoxItem();
                cmbItem = (ComboBoxItem)cmbBairro.SelectedItem;

                cmbItemL = new ComboBoxItem();
                cmbItemL = (ComboBoxItem)cmbLocalidade.SelectedItem;

                if (cmbItem != null)
                {
                    //atualizar
                    if (enderecos.seExisteLocalidade(cmbLocalidade.Text))
                    {
                        cBairro.Codigo = int.Parse(cmbItem.Value.ToString());
                        cBairro.Nome_bairro = cmbBairro.Text.ToUpper().Trim();
                        cBairro.Cod_localidade = int.Parse(cmbItemL.Value.ToString());
                        if (enderecos.gravarBairro(cBairro, 1))
                        {
                            MessageBox.Show("Bairro atualizado com sucesso!", "EstacionamentoFacil (FrmB05)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            limparCampos(); 
                            ve_se_existe();
                        }
                        else
                        {
                            MessageBox.Show("O Bairro não foi atualizado!", "EstacionamentoFacil (FrmL06)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        //novo
                        cmbItemL = new ComboBoxItem();
                        cmbItemL = (ComboBoxItem)cmbLocalidade.SelectedItem;
                        if (cmbItemL != null)
                        {
                            cBairro.Codigo = 0;
                            cBairro.Nome_bairro = cmbBairro.Text.ToUpper().Trim();
                            cBairro.Cod_localidade = int.Parse(cmbItemL.Value.ToString());
                            if (enderecos.gravarBairro(cBairro, 0))
                            {
                                MessageBox.Show("Bairro inserido com sucesso!", "EstacionamentoFacil (FrmB07)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                limparCampos();
                                ve_se_existe();
                            }
                            else
                            {
                                MessageBox.Show("O Bairro não foi inserido!", "EstacionamentoFacil (FrmB08)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                }
                else
                {
                    //novo
                    cmbItemL = new ComboBoxItem();
                    cmbItemL = (ComboBoxItem)cmbLocalidade.SelectedItem;
                    if (cmbItemL != null)
                    {
                        cBairro.Codigo = 0;
                        cBairro.Nome_bairro = cmbBairro.Text.ToUpper().Trim();
                        cBairro.Cod_localidade = int.Parse(cmbItemL.Value.ToString());
                        if (enderecos.gravarBairro(cBairro, 0))
                        {
                            MessageBox.Show("Bairro inserido com sucesso!", "EstacionamentoFacil (FrmB07)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            limparCampos();
                            ve_se_existe();
                        }
                        else
                        {
                            MessageBox.Show("O Bairro não foi inserido!", "EstacionamentoFacil (FrmB08)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
        }

        private void selecionaBairro()
        {
            ComboBoxItem cmbItem = new ComboBoxItem();
            cmbItem = (ComboBoxItem)cmbBairro.SelectedItem;
            cmbLocalidade.Text = buscaLocalidade(int.Parse(cmbItem.Value.ToString()));
        }

        private void lostBairro()
        {
            cmbLocalidade.Text = "";
            if (cmbBairro.Text.Length > 0)
            {
                ComboBoxItem cmbItem = new ComboBoxItem();
                cmbItem = (ComboBoxItem)cmbBairro.SelectedItem;
                if (cmbItem != null)
                {
                    cmbLocalidade.Text = buscaLocalidade(int.Parse(cmbItem.Value.ToString()));
                }
                else
                {
                    enderecos = new Enderecos();
                    enderecos.ArquivoConexao = sArquivoConexao;
                    if (enderecos.seExisteBairro(cmbBairro.Text.ToUpper().Trim()))
                    {
                        Bairro cBairro = enderecos.pesquisarBairro(cmbBairro.Text.ToUpper().Trim());
                        if (cBairro != null)
                        {
                            cmbBairro.Text = cBairro.Nome_bairro.Trim();
                            cmbLocalidade.Text = enderecos.pesquisarLocalidade(cBairro.Cod_localidade).Nome_localidade.Trim();
                        }
                        else
                        {
                            cmbLocalidade.Text = "";
                            cmbLocalidade.Focus();
                        }
                    }
                    else
                    {
                        cmbLocalidade.Text = "";
                        cmbLocalidade.Focus();
                    }
                }
            }    
        }

        private void sairBairro()
        {
            this.Close();
        }

        private void excluirBairro()
        {
            Bairro cBairro = new Bairro();
            enderecos = new Enderecos();
            enderecos.ArquivoConexao = sArquivoConexao;
            if (validaTela())
            {
                ComboBoxItem cmbItem = new ComboBoxItem();
                cmbItem = (ComboBoxItem)cmbBairro.SelectedItem;
                if (cmbItem != null)
                {
                    //atualizar
                    if (enderecos.seExisteBairro(cmbBairro.Text))
                    {
                        if (MessageBox.Show("Deseja realmente excluir este Bairro?", "EstacionamentoFacil (FrmB10a)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (enderecos.excluirBairro(int.Parse(cmbItem.Value.ToString())))
                            {
                                MessageBox.Show("Bairro excluído com sucesso!", "EstacionamentoFacil (FrmB10)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                limparCampos();
                                ve_se_existe();
                            }
                            else
                            {
                                MessageBox.Show("O Bairro não foi excluído!", "EstacionamentoFacil (FrmB11)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Bairro não cadastrado. Exclusão não executada!", "EstacionamentoFacil (FrmB09)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void cmbBairro_SelectedValueChanged(object sender, EventArgs e)
        {
            selecionaBairro();
        }

        private void cmbBairro_Leave(object sender, EventArgs e)
        {
            lostBairro();
        }

        private void cmdGravar_Click(object sender, EventArgs e)
        {
            gravarBairro();
        }

        private void cmdExcluir_Click(object sender, EventArgs e)
        {
            excluirBairro();
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            sairBairro();
        }

        private void cmbBairro_Enter(object sender, EventArgs e)
        {
            cmbLocalidade.SelectedIndex = -1;
        }

        private void limparCampos()
        {
            cmbBairro.Text = "";
            cmbLocalidade.Text = "";
        }

    }
}
