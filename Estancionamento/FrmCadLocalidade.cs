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
    public partial class FrmCadLocalidade : Form
    {
        Enderecos enderecos;
        string sArquivoConexao;

        public FrmCadLocalidade(string vArquivoConexao)
        {
            InitializeComponent();
            sArquivoConexao = vArquivoConexao;
        }

        private void FrmCadLocalidade_Load(object sender, EventArgs e)
        {
            ve_se_existe();
        }

        private void ve_se_existe()
        {
            try
            {
                cmbLocalidade.Items.Clear();
                cmbMunicipio.Items.Clear();

                //buscar dados de municipio:
                List<Municipio> listMunicipio = new List<Municipio>();
                ComboBoxItem cboMunicipio;
                enderecos = new Enderecos();
                enderecos.ArquivoConexao = sArquivoConexao;
                listMunicipio = enderecos.pesquisarTodosMunicipio();
                foreach(Municipio lstMunicipio in listMunicipio){
                    cboMunicipio = new ComboBoxItem();
                    cboMunicipio.Text = lstMunicipio.Nome_municipio;
                    cboMunicipio.Value = lstMunicipio.Codigo;
                    cmbMunicipio.Items.Add(cboMunicipio);
                }

                List<Localidade> listLocalidade = new List<Localidade>();
                ComboBoxItem cboLocalidade;
                listLocalidade = enderecos.pesquisarTodosLocalidade();
                foreach(Localidade lstLocalidade in listLocalidade){
                    cboLocalidade = new ComboBoxItem();
                    cboLocalidade.Text = lstLocalidade.Nome_localidade;
                    cboLocalidade.Value = lstLocalidade.Codigo;
                    cmbLocalidade.Items.Add(cboLocalidade);
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao abrir janela de Localidade! " + ex.Message, "EstacionamentoFacil (FrmL01)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool validaTela()
        {
            bool bResposta = true;
            if (cmbLocalidade.Text.Length == 0)
            {
                bResposta = false;
                MessageBox.Show("Nome da localidade em branco. Verifique! ", "EstacionamentoFacil (FrmL02)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (bResposta && cmbMunicipio.Text.Length == 0)
            {
                bResposta = false;
                MessageBox.Show("Nome do município em branco. Verifique! ", "EstacionamentoFacil (FrmL03)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return bResposta;
        }

        private string buscaMunicipio(int iCodigoLocalidade)
        {
            string sResposta = "";
            Municipio cMunicipio;
            Localidade cLocalidade;
            enderecos = new Enderecos();
            enderecos.ArquivoConexao = sArquivoConexao;
            try
            {
                cLocalidade = enderecos.pesquisarLocalidade(iCodigoLocalidade);
                cMunicipio = enderecos.pesquisarMunicipio(cLocalidade.Cod_Municipio);
                sResposta = cMunicipio.Nome_municipio;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao buscar município da localidade! " + ex.Message, "EstacionamentoFacil (FrmL04)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return sResposta;
        }

        private void cmdGravar_Click(object sender, EventArgs e)
        {
            Localidade cLocalidade = new Localidade();
            ComboBoxItem cmbItemM;
            enderecos = new Enderecos();
            enderecos.ArquivoConexao = sArquivoConexao;
            if (validaTela())
            {
                ComboBoxItem cmbItem = new ComboBoxItem();
                cmbItem = (ComboBoxItem)cmbLocalidade.SelectedItem;

                cmbItemM = new ComboBoxItem();
                cmbItemM = (ComboBoxItem)cmbMunicipio.SelectedItem;

                if (cmbItem != null)
                {
                    //atualizar
                    if (enderecos.seExisteLocalidade(cmbLocalidade.Text.ToUpper().Trim()))
                    {
                        cLocalidade.Codigo = int.Parse(cmbItem.Value.ToString());
                        cLocalidade.Nome_localidade = cmbLocalidade.Text.ToUpper().Trim();
                        cLocalidade.Cod_Municipio = int.Parse(cmbItemM.Value.ToString());
                        if (enderecos.gravarLocalidade(cLocalidade, 1))
                        {
                            MessageBox.Show("Localidade atualizada com sucesso!", "EstacionamentoFacil (FrmL05)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            limparCampos();
                            ve_se_existe();
                        }
                        else
                        {
                            MessageBox.Show("A localidade não foi atualizada!", "EstacionamentoFacil (FrmL06)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        //novo
                        cmbItemM = new ComboBoxItem();
                        cmbItemM = (ComboBoxItem)cmbMunicipio.SelectedItem;
                        if (cmbItemM != null)
                        {
                            cLocalidade.Codigo = 0;
                            cLocalidade.Nome_localidade = cmbLocalidade.Text.ToUpper().Trim();
                            cLocalidade.Cod_Municipio = int.Parse(cmbItemM.Value.ToString());
                            if (enderecos.gravarLocalidade(cLocalidade, 0))
                            {
                                MessageBox.Show("Localidade inserida com sucesso!", "EstacionamentoFacil (FrmL07)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                limparCampos();
                                ve_se_existe();
                            }
                            else
                            {
                                MessageBox.Show("A Localidade não foi inserida!", "EstacionamentoFacil (FrmL08)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                }
                else
                {
                    //novo
                    cmbItemM = new ComboBoxItem();
                    cmbItemM = (ComboBoxItem)cmbMunicipio.SelectedItem;
                    if (cmbItemM != null)
                    {
                        cLocalidade.Codigo = 0;
                        cLocalidade.Nome_localidade = cmbLocalidade.Text.ToUpper().Trim();
                        cLocalidade.Cod_Municipio = int.Parse(cmbItemM.Value.ToString());
                        if (enderecos.gravarLocalidade(cLocalidade, 0))
                        {
                            MessageBox.Show("Localidade inserida com sucesso!", "EstacionamentoFacil (FrmL07)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            limparCampos();
                            ve_se_existe();
                        }
                        else
                        {
                            MessageBox.Show("A Localidade não foi inserida!", "EstacionamentoFacil (FrmL08)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
        }

        private void cmbLocalidade_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBoxItem cmbItem = new ComboBoxItem();
            cmbItem = (ComboBoxItem)cmbLocalidade.SelectedItem;
            if(cmbItem != null)
                cmbMunicipio.Text = buscaMunicipio(int.Parse(cmbItem.Value.ToString()));
        }

        private void cmbLocalidade_Leave(object sender, EventArgs e)
        {
            cmbMunicipio.Text = "";
            if (cmbLocalidade.Text.Length > 0)
            {
                ComboBoxItem cmbItem = new ComboBoxItem();
                cmbItem = (ComboBoxItem)cmbLocalidade.SelectedItem;
                if (cmbItem != null)
                {
                    cmbMunicipio.Text = buscaMunicipio(int.Parse(cmbItem.Value.ToString()));
                }
                else
                {
                    enderecos = new Enderecos();
                    enderecos.ArquivoConexao = sArquivoConexao;
                    if (enderecos.seExisteLocalidade(cmbLocalidade.Text.ToUpper().Trim()))
                    {
                        Localidade cLocalidade = enderecos.pesquisarLocalidade(cmbLocalidade.Text.ToUpper().Trim());
                        if (cLocalidade != null)
                        {
                            cmbLocalidade.Text = cLocalidade.Nome_localidade.Trim();
                            cmbMunicipio.Text = enderecos.pesquisarMunicipio(cLocalidade.Cod_Municipio).Nome_municipio.Trim();
                        }
                        else
                        {
                            cmbMunicipio.Text = "";
                            cmbMunicipio.Focus();
                        }
                    }
                    else
                    {
                        cmbMunicipio.Text = "";
                        cmbMunicipio.Focus();
                    }
                }
            }    
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdExcluir_Click(object sender, EventArgs e)
        {
            Localidade cLocalidade = new Localidade();
            enderecos = new Enderecos();
            enderecos.ArquivoConexao = sArquivoConexao;
            if (validaTela())
            {
                ComboBoxItem cmbItem = new ComboBoxItem();
                cmbItem = (ComboBoxItem)cmbLocalidade.SelectedItem;
                if (cmbItem != null)
                {
                    //atualizar
                    if (enderecos.seExisteLocalidade(cmbLocalidade.Text))
                    {
                        if (MessageBox.Show("Deseja realmente excluir esta localidade?", "EstacionamentoFacil (FrmL10a)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (enderecos.excluirLocalidade(int.Parse(cmbItem.Value.ToString())))
                            {
                                MessageBox.Show("Localidade excluída com sucesso!", "EstacionamentoFacil (FrmL10)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                limparCampos();
                                ve_se_existe();
                            }
                            else
                            {
                                MessageBox.Show("A Localidade não foi excluída!", "EstacionamentoFacil (FrmL11)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Localidade não cadastrado. Exclusão não executada!", "EstacionamentoFacil (FrmL09)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void cmbLocalidade_Enter(object sender, EventArgs e)
        {
            cmbLocalidade.SelectedIndex = -1;
        }

        private void limparCampos()
        {
            cmbLocalidade.Text = "";
            cmbMunicipio.Text = "";
        }

    }
}
