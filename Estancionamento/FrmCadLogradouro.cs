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
    public partial class FrmCadLogradouro : Form
    {
        Enderecos enderecos;
        string sArquivoConexao;

        public FrmCadLogradouro(string vArquivoConexao)
        {
            InitializeComponent();
            sArquivoConexao = vArquivoConexao;
        }

        private void FrmCadLogradouro_Load(object sender, EventArgs e)
        {
            ve_se_existe();
        }

        /// <summary>
        /// Função para pesquisar as localidades
        /// </summary>
        /// <param name="iCodMunicipio">Código do municipio para pesquisa</param>
        /// <param name="bTipo">Tipo de pesquisa 0 - Municipio | 1 - Todos</param>
        private void listarLocalidade(int iCodMunicipio, byte bTipo)
        {
            ComboBoxItem cboItem;

            cmbLocalidade.Items.Clear();
            enderecos = new Enderecos();
            enderecos.ArquivoConexao = sArquivoConexao;

            List<Localidade> lstLocalidade = new List<Localidade>();
            lstLocalidade = null;
            switch (bTipo)
            {
                case 0: 
                    lstLocalidade = enderecos.pesquisarLocalidade(iCodMunicipio, 0);
                    break;
                case 1:
                    lstLocalidade = enderecos.pesquisarTodosLocalidade();
                    break;
            }
            if (lstLocalidade != null)
            {
                cmbLocalidade.Enabled = true;
                foreach (Localidade cLocalidade in lstLocalidade)
                {
                    cboItem = new ComboBoxItem();
                    cboItem.Text = cLocalidade.Nome_localidade;
                    cboItem.Value = cLocalidade.Codigo;
                    cmbLocalidade.Items.Add(cboItem);
                }
            }
            else
            {
                cmbLocalidade.Enabled = false;
            }
        }

        /// <summary>
        /// Função para pesquisar bairros
        /// </summary>
        /// <param name="iCodLocalidade">Código de localidade para pesquisa</param>
        /// <param name="bTipo">tipo de pesquisa 0 - Por localidade | 1 - Todos</param>
        private void listarBairro(int iCodLocalidade, byte bTipo)
        {
            ComboBoxItem cboItem;

            cmbBairro.Items.Clear();
            enderecos = new Enderecos();
            enderecos.ArquivoConexao = sArquivoConexao;

            List<Bairro> lstBairro = new List<Bairro>();
            lstBairro = null;
            switch (bTipo)
            {
                case 0:
                    lstBairro = enderecos.pesquisarBairro(iCodLocalidade, 0);
                    break;
                case 1:
                    lstBairro = enderecos.pesquisarTodosBairro();
                    break;
            }
            
            if (lstBairro != null)
            {
                cmbLocalidade.Enabled = true;
                foreach (Bairro cBairro in lstBairro)
                {
                    cboItem = new ComboBoxItem();
                    cboItem.Text = cBairro.Nome_bairro;
                    cboItem.Value = cBairro.Codigo;
                    cmbBairro.Items.Add(cboItem);
                }
            }
            else
            {
                cmbBairro.Enabled = false;
            }
        }

        private void ve_se_existe()
        {
            try
            {
                //Limpando campos
                cmbLogradouro.Items.Clear();
                cmbTipo.Items.Clear();
                txtCEP.Clear();
                cmbBairro.Items.Clear();
                cmbMunicipio.Items.Clear();
                cmbLocalidade.Items.Clear();

                //buscar dados de tipo:
                List<Logradouro_tipo> listTipo = new List<Logradouro_tipo>();
                ComboBoxItem cboItem;
                enderecos = new Enderecos();
                enderecos.ArquivoConexao = sArquivoConexao;
                listTipo= enderecos.pesquisarTodosLogradouro_Tipo();
                foreach (Logradouro_tipo lstTipo in listTipo)
                {
                    cboItem = new ComboBoxItem();
                    cboItem.Text = lstTipo.Tipo;
                    cboItem.Value = lstTipo.Codigo;
                    cmbTipo.Items.Add(cboItem);
                }

                //buscar dados de bairro:
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

                //buscar dados de logradouro:
                List<Logradouro> listLogradouro = new List<Logradouro>();
                ComboBoxItem cboLogradouro;
                listLogradouro = enderecos.pesquisarTodosLogradouro();
                foreach (Logradouro lstLogradoruo in listLogradouro)
                {
                    cboLogradouro = new ComboBoxItem();
                    cboLogradouro.Text = lstLogradoruo.Nome_logradouro;
                    cboLogradouro.Value = lstLogradoruo.Codigo;
                    cmbLogradouro.Items.Add(cboLogradouro);
                }

                //buscar dados de municpio
                List<Municipio> listMunicipio = new List<Municipio>();
                ComboBoxItem cboMunicipio;
                listMunicipio = enderecos.pesquisarTodosMunicipio();
                foreach (Municipio cMunicipio in listMunicipio)
                {
                    cboMunicipio = new ComboBoxItem();
                    cboMunicipio.Text = cMunicipio.Nome_municipio.Trim() + "/" + cMunicipio.UF.Trim();
                    cboMunicipio.Value = cMunicipio.Codigo;
                    cmbMunicipio.Items.Add(cboMunicipio);
                }

                cmbLocalidade.Enabled = false;
                cmbBairro.Enabled = false;

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao abrir janela de Logradouro! " + ex.Message, "EstacionamentoFacil (FrmLg01)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool validaTela()
        {
            bool bResposta = true;
            if (cmbLogradouro.Text.Length == 0)
            {
                bResposta = false;
                MessageBox.Show("Nome do logradouro em branco. Verifique! ", "EstacionamentoFacil (FrmLg02)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (bResposta && cmbTipo.Text.Length == 0)
            {
                bResposta = false;
                MessageBox.Show("Tipo de logradouro em branco. Verifique! ", "EstacionamentoFacil (FrmLg03)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (bResposta && txtCEP.Text.Length == 0)
            {
                bResposta = false;
                MessageBox.Show("CEP de logradouro em branco. Verifique! ", "EstacionamentoFacil (FrmLg04)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtCEP.Text.Length != 8)
            {
                bResposta = false;
                MessageBox.Show("CEP inválido. Verifique! ", "EstacionamentoFacil (FrmLg04b)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (bResposta && cmbBairro.Text.Length == 0)
            {
                bResposta = false;
                MessageBox.Show("Bairro do logradouro em branco. Verifique! ", "EstacionamentoFacil (FrmLg05)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return bResposta;
        }

        private void buscaDadosLogradouro(int iCodigoLogradouro)
        {
            Logradouro cLogradouro;
            Logradouro_tipo cTipo;
            Bairro cBairro;
            enderecos = new Enderecos();
            enderecos.ArquivoConexao = sArquivoConexao;
            try
            {
                cLogradouro = enderecos.pesquisarLogradouro(iCodigoLogradouro);
                cTipo = enderecos.pesquisarLogradouro_tipo(cLogradouro.Tipo);
                cBairro = enderecos.pesquisarBairro(cLogradouro.Cod_bairro);
                cmbTipo.Text = cTipo.Tipo;
                txtCEP.Text = cLogradouro.CEP;

                Municipio cMunicipio = enderecos.pesquisarMunicipio(enderecos.pesquisarLocalidade(cBairro.Cod_localidade).Cod_Municipio);
                cmbMunicipio.Text = cMunicipio.Nome_municipio.Trim() + "/" + cMunicipio.UF.Trim();

                cmbLocalidade.Enabled = true;
                listarLocalidade(enderecos.pesquisarLocalidade(cBairro.Cod_localidade).Cod_Municipio, 0);
                cmbLocalidade.Text = enderecos.pesquisarLocalidade(cBairro.Cod_localidade).Nome_localidade;

                cmbBairro.Enabled = true;
                listarBairro(cBairro.Cod_localidade, 0);
                cmbBairro.Text = cBairro.Nome_bairro;

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao buscar dados de logradouro! " + ex.Message, "EstacionamentoFacil (FrmLg06)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gravarLogradouro()
        {
            Logradouro cLogradouro = new Logradouro();
            ComboBoxItem cmbItem;
            ComboBoxItem cmbItemT;
            ComboBoxItem cmbItemB;
            enderecos = new Enderecos();
            enderecos.ArquivoConexao = sArquivoConexao;
            if (validaTela())
            {
                cmbItem = new ComboBoxItem();
                cmbItem = (ComboBoxItem)cmbLogradouro.SelectedItem;

                cmbItemT = new ComboBoxItem();
                cmbItemT = (ComboBoxItem)cmbTipo.SelectedItem;

                cmbItemB = new ComboBoxItem();
                cmbItemB = (ComboBoxItem)cmbBairro.SelectedItem;

                if (cmbItem != null )
                {
                    //atualizar
                    if (enderecos.seExisteLogradouro(cmbLogradouro.Text))
                    {
                        cLogradouro.Codigo = int.Parse(cmbItem.Value.ToString());
                        cLogradouro.Nome_logradouro = cmbLogradouro.Text.ToUpper().Trim();
                        cLogradouro.Tipo = int.Parse(cmbItemT.Value.ToString());
                        cLogradouro.CEP = txtCEP.Text;
                        cLogradouro.Cod_bairro = int.Parse(cmbItemB.Value.ToString());
                        if (enderecos.gravarLogradouro(cLogradouro, 1))
                        {
                            MessageBox.Show("Logradouro atualizado com sucesso!", "EstacionamentoFacil (FrmLg07)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            limparCampos();
                            ve_se_existe();
                        }
                        else
                        {
                            MessageBox.Show("O Logradouro não foi atualizado!", "EstacionamentoFacil (FrmLg08)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        //novo
                        cmbItemT = new ComboBoxItem();
                        cmbItemT = (ComboBoxItem)cmbTipo.SelectedItem;

                        cmbItemB = new ComboBoxItem();
                        cmbItemB = (ComboBoxItem)cmbBairro.SelectedItem;

                        if (cmbItemT != null && cmbItemB != null)
                        {
                            cLogradouro.Codigo = 0;
                            cLogradouro.Nome_logradouro = cmbLogradouro.Text.ToUpper().Trim();
                            cLogradouro.Tipo = int.Parse(cmbItemT.Value.ToString());
                            cLogradouro.CEP = txtCEP.Text;
                            cLogradouro.Cod_bairro = int.Parse(cmbItemB.Value.ToString());
                            if (enderecos.gravarLogradouro(cLogradouro, 0))
                            {
                                MessageBox.Show("Logradouro inserido com sucesso!", "EstacionamentoFacil (FrmLg09)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                limparCampos();
                                ve_se_existe();
                            }
                            else
                            {
                                MessageBox.Show("O Logradouro não foi inserido!", "EstacionamentoFacil (FrmLg10)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                }
                else
                {
                    //novo
                    cmbItemT = new ComboBoxItem();
                    cmbItemT = (ComboBoxItem)cmbTipo.SelectedItem;

                    cmbItemB = new ComboBoxItem();
                    cmbItemB = (ComboBoxItem)cmbBairro.SelectedItem;

                    if (cmbItemT != null && cmbItemB != null)
                    {
                        cLogradouro.Codigo = 0;
                        cLogradouro.Nome_logradouro = cmbLogradouro.Text.ToUpper().Trim();
                        cLogradouro.Tipo = int.Parse(cmbItemT.Value.ToString());
                        cLogradouro.CEP = txtCEP.Text;
                        cLogradouro.Cod_bairro = int.Parse(cmbItemB.Value.ToString());
                        if (enderecos.gravarLogradouro(cLogradouro, 0))
                        {
                            MessageBox.Show("Logradouro inserido com sucesso!", "EstacionamentoFacil (FrmLg09)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            limparCampos();
                            ve_se_existe();
                        }
                        else
                        {
                            MessageBox.Show("O Logradouro não foi inserido!", "EstacionamentoFacil (FrmLg10)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
        }//gravar

        private void selecionaLogradouro()
        {
            ComboBoxItem cmbItem = new ComboBoxItem();
            cmbItem = (ComboBoxItem)cmbLogradouro.SelectedItem;
            buscaDadosLogradouro(int.Parse(cmbItem.Value.ToString()));
        }

        private void lostLogradouro()
        {
            cmbTipo.SelectedIndex = -1;
            cmbBairro.SelectedIndex = -1;
            txtCEP.Clear();            
            if (cmbLogradouro.Text.Length > 0)
            {
                ComboBoxItem cmbItem = new ComboBoxItem();
                cmbItem = (ComboBoxItem)cmbLogradouro.SelectedItem;
                if (cmbItem != null)
                {
                    buscaDadosLogradouro(int.Parse(cmbItem.Value.ToString()));
                }
                else
                {
                    enderecos = new Enderecos();
                    enderecos.ArquivoConexao = sArquivoConexao;

                    if (enderecos.seExisteLogradouro(cmbLogradouro.Text.ToUpper().Trim()))
                    {
                        Logradouro cLogradouro = enderecos.pesquisarLogradouro(cmbLogradouro.Text.ToUpper().Trim());
                        if (cLogradouro != null)
                        {
                            listarLocalidade(0,1);
                            listarBairro(0,1);

                            cmbLogradouro.Text = cLogradouro.Nome_logradouro.Trim();
                            cmbTipo.Text = enderecos.pesquisarLogradouro_tipo(cLogradouro.Tipo).Tipo;
                            txtCEP.Text = cLogradouro.CEP;
                            cmbBairro.Enabled = true;
                            cmbBairro.Text = enderecos.pesquisarBairro(cLogradouro.Cod_bairro).Nome_bairro;
                            cmbLocalidade.Enabled = true;
                            cmbLocalidade.Text = enderecos.pesquisarLocalidade(enderecos.pesquisarBairro(cLogradouro.Cod_bairro).Cod_localidade).Nome_localidade;
                            cmbMunicipio.Text = enderecos.pesquisarMunicipio(enderecos.pesquisarLocalidade(enderecos.pesquisarBairro(cLogradouro.Cod_bairro).Cod_localidade).Cod_Municipio).Nome_municipio;
                        }
                        else
                        {
                            cmbTipo.SelectedIndex = -1;
                            cmbBairro.SelectedIndex = -1;
                            cmbMunicipio.SelectedIndex = -1;
                            cmbLocalidade.SelectedIndex = -1;
                            txtCEP.Clear();
                            cmbTipo.Focus();
                            cmbLocalidade.Enabled = false;
                            cmbBairro.Enabled = false;
                        }
                    }
                    else
                    {
                        cmbTipo.SelectedIndex = -1;
                        cmbBairro.SelectedIndex = -1;
                        cmbMunicipio.SelectedIndex = -1;
                        cmbLocalidade.SelectedIndex = -1;
                        txtCEP.Clear();
                        cmbTipo.Focus();
                        cmbLocalidade.Enabled = false;
                        cmbBairro.Enabled = false;
                    }
                }
            }
        }

        private void sairLogradouro()
        {
            this.Close();
        }

        private void excluirLogradouro()
        {
            Logradouro cLogradouro = new Logradouro();
            enderecos = new Enderecos();
            enderecos.ArquivoConexao = sArquivoConexao;
            if (validaTela())
            {
                ComboBoxItem cmbItem = new ComboBoxItem();
                cmbItem = (ComboBoxItem)cmbLogradouro.SelectedItem;
                if (cmbItem != null)
                {
                    //atualizar
                    if (enderecos.seExisteLogradouro(cmbLogradouro.Text))
                    {
                        if (MessageBox.Show("Deseja realmente excluir este Logradouro?", "EstacionamentoFacil (FrmLg11a)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (enderecos.excluirLogradouro(int.Parse(cmbItem.Value.ToString())))
                            {
                                MessageBox.Show("Logradouro excluído com sucesso!", "EstacionamentoFacil (FrmLg11)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                limparCampos();
                                ve_se_existe();
                            }
                            else
                            {
                                MessageBox.Show("O Logradouro não foi excluído!", "EstacionamentoFacil (FrmLg12)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Logradouro não cadastrado. Exclusão não executada!", "EstacionamentoFacil (FrmLg13)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void limparCampos()
        {
            cmbTipo.SelectedIndex = -1;
            txtCEP.Clear();
            cmbBairro.SelectedIndex = -1;
            cmbLogradouro.Text = "";
            cmbLocalidade.SelectedIndex = -1;
            cmbBairro.SelectedIndex = -1;
            cmbMunicipio.SelectedIndex = -1;
            cmbLocalidade.Enabled = false;
            cmbBairro.Enabled = false;
        }

        private void cmbLogradouro_SelectedValueChanged(object sender, EventArgs e)
        {
            selecionaLogradouro();
        }

        private void cmbLogradouro_Leave(object sender, EventArgs e)
        {
            lostLogradouro();
        }

        private void cmdGravar_Click(object sender, EventArgs e)
        {
            gravarLogradouro();
        }

        private void cmdExcluir_Click(object sender, EventArgs e)
        {
            excluirLogradouro();
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            sairLogradouro();
        }

        private void cmbLogradouro_Enter(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void cmbMunicipio_Enter(object sender, EventArgs e)
        {
            cmbLocalidade.Text = "";
            cmbBairro.Text = "";
            cmbLocalidade.Enabled = false;
            cmbBairro.Enabled = false;
        }

        private void cmbMunicipio_Leave(object sender, EventArgs e)
        {
            ComboBoxItem cmbItem = new ComboBoxItem();
            cmbItem = (ComboBoxItem)cmbMunicipio.SelectedItem;
            if (cmbItem != null)
            {
                listarLocalidade(int.Parse(cmbItem.Value.ToString()), 0);
                cmbLocalidade.Focus();
            }
        }

        private void cmbLocalidade_Enter(object sender, EventArgs e)
        {
            cmbBairro.Text = "";
            cmbBairro.Enabled = false;
        }

        private void cmbLocalidade_Leave(object sender, EventArgs e)
        {
            ComboBoxItem cmbItem = new ComboBoxItem();
            cmbItem = (ComboBoxItem)cmbLocalidade.SelectedItem;
            if (cmbItem != null)
            {
                listarBairro(int.Parse(cmbItem.Value.ToString()), 0);
                cmbBairro.Enabled = true;
                cmbBairro.Focus();
            }
        }

        private void txtCEP_Leave(object sender, EventArgs e)
        {
            if (txtCEP.Text.Trim().Length > 0)
            {
                if (txtCEP.Text.Trim().Length != 8)
                {
                    MessageBox.Show("CEP inválido. Verifique!", "EstacionamentoFacil (FrmLg14)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCEP.Clear();
                    txtCEP.Focus();
                }
            }
        }

    }
}
