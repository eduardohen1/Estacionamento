using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Estancionamento.Relatórios
{
    public partial class FrmPesq_ClientesCadastrados : Form
    {
        Enderecos cEnderecos;
        Veiculos cVeiculos;
        FrmPrincipal vTelaPrincipal;
        string sArquivoConexao;

        public FrmPesq_ClientesCadastrados(string vArquivoConexao, FrmPrincipal vvTelaPrincipal)
        {
            InitializeComponent();
            vTelaPrincipal = vvTelaPrincipal;
            sArquivoConexao = vArquivoConexao;
        }

        private void FrmPesq_ClientesCadastrados_Load(object sender, EventArgs e)
        {
            ve_se_existe();
        }

        private void limparTela()
        {
            cmbBairro.Items.Clear();
            cmbCidade.Items.Clear();
            cmbMarca.Items.Clear();
            cmbFaixaSalarial.Items.Clear();
            cmbTipoPessoa.Items.Clear();
            cmbAniversariantes.Items.Clear();
        }

        private void ve_se_existe()
        {   
            try
            {
                limparTela();
                ComboBoxItem cboItem;
                List<Bairro> lstBairro = new List<Bairro>();
                List<Municipio> lstMunicipio = new List<Municipio>();
                List<marca> lstMarca = new List<marca>();
                cEnderecos = new Enderecos();
                cVeiculos = new Veiculos();
                cEnderecos.ArquivoConexao = sArquivoConexao;
                cVeiculos.ArquivoConexao = sArquivoConexao;

                //bairro:
                lstBairro = cEnderecos.pesquisarTodosBairro();
                if (lstBairro != null)
                {
                    if (lstBairro.Count > 0)
                    {
                        foreach (Bairro cBairro in lstBairro)
                        {
                            cboItem = new ComboBoxItem();
                            cboItem.Value = cBairro.Codigo;
                            cboItem.Text = cBairro.Nome_bairro;
                            cmbBairro.Items.Add(cboItem);
                        }
                    }
                }

                //Municipio:
                lstMunicipio = cEnderecos.pesquisarTodosMunicipio();
                if (lstMunicipio != null)
                {
                    if (lstMunicipio.Count > 0)
                    {
                        foreach (Municipio cMuncipio in lstMunicipio)
                        {
                            cboItem = new ComboBoxItem();
                            cboItem.Value = cMuncipio.Codigo;
                            cboItem.Text = cMuncipio.Nome_municipio;
                            cmbCidade.Items.Add(cboItem);
                        }
                    }
                }

                //marca
                lstMarca = cVeiculos.pesquisarTodasMarcas();
                if (lstMarca != null)
                {
                    if (lstMarca.Count > 0)
                    {
                        foreach (marca cMarca in lstMarca)
                        {
                            cboItem = new ComboBoxItem();
                            cboItem.Value = cMarca.codigo;
                            cboItem.Text = cMarca.descricao;
                            cmbMarca.Items.Add(cboItem);
                        }
                    }
                }

                //Faixa salarial:
                cmbFaixaSalarial.Items.Clear();
                cboItem = new ComboBoxItem();
                cboItem.Text = "R$0,00 - R$1.000,00";
                cboItem.Value = 0;
                cmbFaixaSalarial.Items.Add(cboItem);

                cboItem = new ComboBoxItem();
                cboItem.Text = "R$1.001,00 - R$3.000,00";
                cboItem.Value = 1;
                cmbFaixaSalarial.Items.Add(cboItem);

                cboItem = new ComboBoxItem();
                cboItem.Text = "R$3.001,00 - R$5.000,00";
                cboItem.Value = 2;
                cmbFaixaSalarial.Items.Add(cboItem);

                cboItem = new ComboBoxItem();
                cboItem.Text = "R$5.001,00 - R$10.000,00";
                cboItem.Value = 3;
                cmbFaixaSalarial.Items.Add(cboItem);

                cboItem = new ComboBoxItem();
                cboItem.Text = "R$10.001,00 - R$20.000,00";
                cboItem.Value = 4;
                cmbFaixaSalarial.Items.Add(cboItem);

                //Tipo pessoa
                cmbTipoPessoa.Items.Clear();
                cboItem = new ComboBoxItem();
                cboItem.Text = "FÍSICA";
                cboItem.Value = 0;
                cmbTipoPessoa.Items.Add(cboItem);

                cboItem = new ComboBoxItem();
                cboItem.Text = "JURÍDICA";
                cboItem.Value = 1;
                cmbTipoPessoa.Items.Add(cboItem);

                //Aniversariantes
                cmbAniversariantes.Items.Clear();
                cboItem = new ComboBoxItem();
                cboItem.Text = "JANEIRO";
                cboItem.Value = 1;
                cmbAniversariantes.Items.Add(cboItem);

                cboItem = new ComboBoxItem();
                cboItem.Text = "FEVEREIRO";
                cboItem.Value = 2;
                cmbAniversariantes.Items.Add(cboItem);

                cboItem = new ComboBoxItem();
                cboItem.Text = "MARÇO";
                cboItem.Value = 3;
                cmbAniversariantes.Items.Add(cboItem);

                cboItem = new ComboBoxItem();
                cboItem.Text = "ABRIL";
                cboItem.Value = 4;
                cmbAniversariantes.Items.Add(cboItem);

                cboItem = new ComboBoxItem();
                cboItem.Text = "MAIO";
                cboItem.Value = 5;
                cmbAniversariantes.Items.Add(cboItem);

                cboItem = new ComboBoxItem();
                cboItem.Text = "JUNHO";
                cboItem.Value = 6;
                cmbAniversariantes.Items.Add(cboItem);

                cboItem = new ComboBoxItem();
                cboItem.Text = "JULHO";
                cboItem.Value = 7;
                cmbAniversariantes.Items.Add(cboItem);

                cboItem = new ComboBoxItem();
                cboItem.Text = "AGOSTO";
                cboItem.Value = 8;
                cmbAniversariantes.Items.Add(cboItem);

                cboItem = new ComboBoxItem();
                cboItem.Text = "SETEMBRO";
                cboItem.Value = 9;
                cmbAniversariantes.Items.Add(cboItem);

                cboItem = new ComboBoxItem();
                cboItem.Text = "OUTUBRO";
                cboItem.Value = 10;
                cmbAniversariantes.Items.Add(cboItem);

                cboItem = new ComboBoxItem();
                cboItem.Text = "NOVEMBRO";
                cboItem.Value = 11;
                cmbAniversariantes.Items.Add(cboItem);

                cboItem = new ComboBoxItem();
                cboItem.Text = "DEZEMBRO";
                cboItem.Value = 12;
                cmbAniversariantes.Items.Add(cboItem);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir janela de Pesquisa de clientes!\n" + ex.Message, "EstacionamentoFacil (FrmPesqCl01)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//ve_se_existe

        private bool validaTela()
        {
            bool bResposta = true;
            if (chkPorCidade.Checked)
            {
                if (cmbCidade.Text.Length == 0)
                {
                    MessageBox.Show("Selecione a cidade para pesquisa!", "EstacionamentoFacil (FrmPesqCl02)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bResposta = false;
                }
            }

            if (chkPorBairro.Checked && bResposta)
            {
                if (cmbBairro.Text.Length == 0)
                {
                    MessageBox.Show("Selecione o bairro para pesquisa!", "EstacionamentoFacil (FrmPesqCl03)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bResposta = false;
                }
            }

            if (chkPorMarca.Checked && bResposta)
            {
                if (cmbMarca.Text.Length == 0)
                {
                    MessageBox.Show("Selecione a marca para a pesquisa!", "EstacionamentoFacil (FrmPesqCl04)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bResposta = false;
                }
            }

            if (chkPorFaixaSalarial.Checked && bResposta)
            {
                if (cmbFaixaSalarial.Text.Length == 0)
                {
                    MessageBox.Show("Selecione a faixa salarial para a pesquisa!", "EstacionamentoFacil (FrmPesqCl04b)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bResposta = false;
                }
            }

            if (chkPorTipoPessoa.Checked && bResposta)
            {
                if (cmbTipoPessoa.Text.Length == 0)
                {
                    MessageBox.Show("Selecione o tipo de pessoal para a pesquisa!", "EstacionamentoFacil (FrmPesqCl04c)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bResposta = false;
                }
            }

            if (chkPorAniversariantes.Checked && bResposta)
            {
                if (cmbAniversariantes.Text.Length == 0)
                {
                    MessageBox.Show("Selecione a mês de aniversário para a pesquisa!", "EstacionamentoFacil (FrmPesqCl04d)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bResposta = false;
                }
            }

            return bResposta;
        }//validaTela

        private string montaPesquisa(byte bTipo = 0)
        {
            string sResposta="";
            string sResposta2="";
            ComboBoxItem cboItem;
            if (chkPorCidade.Checked)
            {
                cboItem = (ComboBoxItem)cmbCidade.SelectedItem;
                if (cboItem != null)
                {
                    if (sResposta.Trim().Length > 0) sResposta = sResposta + " AND ";
                    if (sResposta2.Trim().Length > 0) sResposta2 = sResposta2 + ", ";
                    sResposta = " m.Codigo = " + cboItem.Value.ToString();
                    sResposta2 = "Por cidade (" + cboItem.Text + ")";
                }
            }

            if (chkPorBairro.Checked)
            {
                cboItem = (ComboBoxItem)cmbBairro.SelectedItem;
                if (cboItem != null)
                {
                    if (sResposta.Trim().Length > 0) sResposta = sResposta + " AND ";
                    if (sResposta2.Trim().Length > 0) sResposta2 = sResposta2 + ", ";
                    sResposta = " b.Codigo = " + cboItem.Value.ToString();
                    sResposta2 = "Por bairro (" + cboItem.Text + ")";
                }
            }

            if (chkPorMarca.Checked)
            {
                cboItem = (ComboBoxItem)cmbMarca.SelectedItem;
                if (cboItem != null)
                {
                    if (sResposta.Trim().Length > 0) sResposta = sResposta + " AND ";
                    if (sResposta2.Trim().Length > 0) sResposta2 = sResposta2 + ", ";
                    sResposta = " c.Codigo IN (SELECT  codigocliente FROM ClienteCarro cc1 INNER JOIN Carro cc2 ON cc1.codigocarro = cc2.Codigo WHERE cc2.CodMarca = " + cboItem.Value.ToString() + ")"; 
                    sResposta2 = "Por marca (" + cboItem.Text + ")";
                }
            }

            if (chkPorFaixaSalarial.Checked)
            {
                cboItem = (ComboBoxItem)cmbFaixaSalarial.SelectedItem;
                if (cboItem != null)
                {
                    if (sResposta.Trim().Length > 0) sResposta = sResposta + " AND ";
                    if (sResposta2.Trim().Length > 0) sResposta2 = sResposta2 + ", ";
                    sResposta = " c.FaixaSalarial = " + cboItem.Value.ToString() + " ";
                    sResposta2 = "Por Faixa salarial (" + cboItem.Text + ")";
                }
            }

            if (chkPorTipoPessoa.Checked)
            {
                cboItem = (ComboBoxItem)cmbTipoPessoa.SelectedItem;
                if (cboItem != null)
                {
                    if (sResposta.Trim().Length > 0) sResposta = sResposta + " AND ";
                    if (sResposta2.Trim().Length > 0) sResposta2 = sResposta2 + ", ";
                    sResposta = " c.TipoPessoa = " + cboItem.Value.ToString() + " ";
                    sResposta2 = "Por Tipo pessoa (" + cboItem.Text + ")";
                }
            }

            if (chkPorAniversariantes.Checked)
            {
                cboItem = (ComboBoxItem)cmbAniversariantes.SelectedItem;
                if (cboItem != null)
                {
                    if (sResposta.Trim().Length > 0) sResposta = sResposta + " AND ";
                    if (sResposta2.Trim().Length > 0) sResposta2 = sResposta2 + ", ";
                    sResposta = " MONTH(c.DtNascimento) = " + cboItem.Value.ToString() + " ";
                    sResposta2 = "Por Aniversariantes (" + cboItem.Text + ")";
                }
            }

            if (sResposta.Trim().Length > 0) sResposta = " WHERE " + sResposta;
            if (bTipo == 1)
            {
                if (sResposta2.Trim().Length == 0) sResposta2 = "Todos os cadastros";
                sResposta = sResposta2;
            }
            return sResposta;
        }

        private void imprimirConsulta()
        {
            try
            {
                if (validaTela())
                {
                    Cliente cCliente = new Cliente();
                    cCliente.ArquivoConexao = sArquivoConexao;
                    if (cCliente.impr_ClientesCadastrados(montaPesquisa(0), montaPesquisa(1)))
                    {
                        //chamar tela de impressão
                        switch (vTelaPrincipal.vvEmpresa.tipo_relatorio)
                        {
                            case 0:
                                if (!chkPorEtiqueta.Checked)
                                    vTelaPrincipal.abrirImpressaoClientesCadastrados(vTelaPrincipal);
                                else
                                    vTelaPrincipal.abrirImpressaoClientesCadastrados(vTelaPrincipal,1);
                                break;
                            case 1:
                                if(!chkPorEtiqueta.Checked)
                                    vTelaPrincipal.abrirImpressaoClientesCadastrados(vTelaPrincipal, 0);
                                else
                                    vTelaPrincipal.abrirImpressaoClientesCadastrados(vTelaPrincipal, 1);
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao imprimir consulta!\n" + ex.Message, "EstacionamentoFacil (FrmPesqCl05)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdImprimir_Click(object sender, EventArgs e)
        {
            cmdFechar.Enabled = false;
            cmdImprimir.Enabled = false;
            imprimirConsulta();
            cmdFechar.Enabled = true;
            cmdImprimir.Enabled = true;            
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
