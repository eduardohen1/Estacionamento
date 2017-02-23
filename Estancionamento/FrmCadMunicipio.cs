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
    public partial class FrmCadMunicipio : Form
    {
        Enderecos enderecos;
        string sArquivoConexao;

        public FrmCadMunicipio(string vArquivoConexao)
        {
            InitializeComponent();
            sArquivoConexao = vArquivoConexao;
        }

        private void FrmCadMunicipio_Load(object sender, EventArgs e)
        {
            ve_se_existe();
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbMunicipio_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBoxItem cmbItem = new ComboBoxItem();
            cmbItem = (ComboBoxItem)cmbMunicipio.SelectedItem;
            cmbUF.Text = buscaUF(int.Parse(cmbItem.Value.ToString()));
        }

        private void cmbMunicipio_Leave(object sender, EventArgs e)
        {
            cmbUF.Text = "";
            if (cmbMunicipio.Text.Length > 0)
            {
                ComboBoxItem cmbItem = new ComboBoxItem();
                cmbItem = (ComboBoxItem)cmbMunicipio.SelectedItem;
                if (cmbItem != null)
                {
                    cmbUF.Text = buscaUF(int.Parse(cmbItem.Value.ToString()));
                }
                else
                {
                    //verificar se cidade existe, caso sim, seleciona-la e listar a UF
                    enderecos = new Enderecos();
                    enderecos.ArquivoConexao = sArquivoConexao;
                    if (enderecos.municipioExiste(cmbMunicipio.Text.ToUpper().Trim()))
                    {
                        Municipio cMunicipio = enderecos.pesquisarMunicipio(cmbMunicipio.Text.ToUpper().Trim());
                        if(cMunicipio != null){
                            cmbMunicipio.Text = cMunicipio.Nome_municipio.Trim();
                            cmbUF.Text = cMunicipio.UF;
                        }else{
                            cmbUF.Text = "";
                            cmbUF.Focus();
                        }
                    }
                    else
                    {
                        cmbUF.Text = "";
                        cmbUF.Focus();
                    }
                }
            }            
        }

        private string buscaUF(int iCodMunicipio)
        {
            Municipio cMunicipio;
            string sResposta = "";            
            enderecos = new Enderecos();
            enderecos.ArquivoConexao = sArquivoConexao;
            try
            {
                cMunicipio = enderecos.pesquisarMunicipio(iCodMunicipio);
                sResposta = cMunicipio.UF;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao buscar UF do município! " + ex.Message, "EstacionamentoFacil (FrmM02)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return sResposta;            
        }

        private bool validaTela()
        {
            bool bResposta = true;
            if (cmbMunicipio.Text.Length == 0)
            {
                bResposta = false;
                MessageBox.Show("Nome do município em branco. Verifique! ", "EstacionamentoFacil (FrmM03)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (bResposta && cmbUF.Text.Length == 0)
            {
                bResposta = false;
                MessageBox.Show("UF do município em branco. Verifique! ", "EstacionamentoFacil (FrmM04)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return bResposta;
        }

        private void ve_se_existe()
        {
            try
            {
                cmbMunicipio.Items.Clear();
                cmbUF.Items.Clear();
                ComboBoxItem cboItem;

                string[] sUF = { "AC", "AL","AP","AM","BA","CE","DF","ES","GO","MA","MG","MS","PA","PB","PR","PE","PI","RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO" };
                foreach (string ssUf in sUF)
                {
                    cboItem = new ComboBoxItem();
                    cboItem.Text = ssUf;
                    cboItem.Value = ssUf;
                    cmbUF.Items.Add(cboItem);
                }


                List<Municipio> listMunicipios = new List<Municipio>();                
                enderecos = new Enderecos();
                enderecos.ArquivoConexao = sArquivoConexao;
                listMunicipios = enderecos.pesquisarTodosMunicipio();
                foreach (Municipio ltMunicipio in listMunicipios)
                {
                    cboItem = new ComboBoxItem();
                    cboItem.Text = ltMunicipio.Nome_municipio;
                    cboItem.Value = ltMunicipio.Codigo;
                    cmbMunicipio.Items.Add(cboItem);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao abrir janela de Município! " + ex.Message, "EstacionamentoFacil (FrmM01)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdGravar_Click(object sender, EventArgs e)
        {
            Municipio cMunicipio = new Municipio();
            enderecos = new Enderecos();
            enderecos.ArquivoConexao = sArquivoConexao;
            if (validaTela())
            {
                ComboBoxItem cmbItem = new ComboBoxItem();
                cmbItem = (ComboBoxItem)cmbMunicipio.SelectedItem;
                if (cmbItem != null)
                {
                    //atualizar
                    if (enderecos.seExisteMunicipio(cmbMunicipio.Text))
                    {
                        cMunicipio.Codigo = int.Parse(cmbItem.Value.ToString());
                        cMunicipio.Nome_municipio = cmbMunicipio.Text.ToUpper().Trim();
                        cMunicipio.UF = cmbUF.Text;
                        if (enderecos.gravarMunicipio(cMunicipio, 1))
                        {
                            MessageBox.Show("Município atualizado com sucesso!", "EstacionamentoFacil (FrmM05)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ve_se_existe();
                        }
                        else
                        {
                            MessageBox.Show("O município não foi atualizado!", "EstacionamentoFacil (FrmM07)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        //novo
                        cMunicipio.Codigo = 0;
                        cMunicipio.Nome_municipio = cmbMunicipio.Text.ToUpper().Trim();
                        cMunicipio.UF = cmbUF.Text;
                        if (enderecos.gravarMunicipio(cMunicipio, 0))
                        {
                            MessageBox.Show("Município inserido com sucesso!", "EstacionamentoFacil (FrmM06)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ve_se_existe();
                        }
                        else
                        {
                            MessageBox.Show("O município não foi inserido!", "EstacionamentoFacil (FrmM08)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                    }
                }
                else
                {
                    //novo
                    cMunicipio.Codigo = 0;
                    cMunicipio.Nome_municipio = cmbMunicipio.Text.ToUpper().Trim();
                    cMunicipio.UF = cmbUF.Text;
                    if (enderecos.gravarMunicipio(cMunicipio, 0))
                    {
                        MessageBox.Show("Município inserido com sucesso!", "EstacionamentoFacil (FrmM06)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ve_se_existe();
                    }
                    else
                    {
                        MessageBox.Show("O município não foi inserido!", "EstacionamentoFacil (FrmM08)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void cmdExcluir_Click(object sender, EventArgs e)
        {
            Municipio cMunicipio = new Municipio();
            enderecos = new Enderecos();
            enderecos.ArquivoConexao = sArquivoConexao;
            if (validaTela())
            {
                ComboBoxItem cmbItem = new ComboBoxItem();
                cmbItem = (ComboBoxItem)cmbMunicipio.SelectedItem;
                if (cmbItem != null)
                {
                    //atualizar
                    if (enderecos.seExisteMunicipio(cmbMunicipio.Text))
                    {
                        if (MessageBox.Show("Deseja realmente excluir este município?", "EstacionamentoFacil (FrmM10a)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (enderecos.excluirMunicipio(int.Parse(cmbItem.Value.ToString())))
                            {
                                MessageBox.Show("Município excluído com sucesso!", "EstacionamentoFacil (FrmM10)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ve_se_existe();
                            }
                            else
                            {
                                MessageBox.Show("O município não foi excluído!", "EstacionamentoFacil (FrmM11)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Município não cadastro. Exclusão não executada!", "EstacionamentoFacil (FrmM09)", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                }
            }
        }

        private void cmbMunicipio_Enter(object sender, EventArgs e)
        {
            cmbMunicipio.Text = "";
            cmbUF.Text = "";
        }

    }
}
