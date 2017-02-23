using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Estancionamento.Ativacao
{
    public partial class FrmConfiguraConexao : Form
    {
        string sArquivoConexao;
        string[] sTipoRelatorios = {"Crystal Reports", "Windows Report"};
        public FrmConfiguraConexao(string ssArquivoConexao)
        {
            InitializeComponent();
            sArquivoConexao = ssArquivoConexao;
        }

        private void FrmConfiguraConexao_Load(object sender, EventArgs e)
        {
            ve_se_existe();

            cmbRelatorios.Items.Clear();
            ComboBoxItem cboItem = new ComboBoxItem();
            cboItem.Text = sTipoRelatorios[0];
            cboItem.Value = 0;
            cmbRelatorios.Items.Add(cboItem);

            cboItem = new ComboBoxItem();
            cboItem.Text = sTipoRelatorios[1];
            cboItem.Value = 1;
            cmbRelatorios.Items.Add(cboItem);

        }

        private void ve_se_existe()
        {
            try
            {
                Conexao cConexao = new Conexao();
                DadosConexao cDadosConexao = new DadosConexao();
                cDadosConexao = cConexao.buscarDadosConexao(sArquivoConexao, 0);
                if (cDadosConexao != null)
                {
                    txtServidor.Text = cDadosConexao.sServidor.Trim();
                    txtPorta.Text = cDadosConexao.iPorta.ToString();
                    txtUsuario.Text = cDadosConexao.sUsuario.Trim();
                    txtSenha.Text = cDadosConexao.sSenha.Trim();
                    txtBancoDados.Text = cDadosConexao.sNomeBaseDados.Trim();
                    txtChaveAcesso.Text = cDadosConexao.sChaveAcesso.Trim();                    
                    cmbRelatorios.Text = sTipoRelatorios[cDadosConexao.iTipoRelatorio];
                }else
                    MessageBox.Show("Nenhum dado encontrado!", "EstacionamentoFacil (FrmCx01)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir tela!\n" + ex.Message, "EstacionamentoFacil (FrmCx02)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool validaTela()
        {
            bool bResposta = true;
            if (txtServidor.Text.Length == 0)
            {
                MessageBox.Show("Digite o endereço/nome servidor!", "EstacionamentoFacil (FrmCx03)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bResposta = false;
            }

            if (txtPorta.Text.Length == 0 && bResposta)
            {
                MessageBox.Show("Digite a porta de comunicação do servidor!", "EstacionamentoFacil (FrmCx04)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bResposta = false;
            }
            else
            {
                funcoes cFuncao = new funcoes();
                if (!cFuncao.isNumeric(txtPorta.Text))
                {
                    MessageBox.Show("Somente valores numéricos para o campo Porta!", "EstacionamentoFacil (FrmCx05)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bResposta = false;
                }
            }

            if (txtUsuario.Text.Length == 0 && bResposta)
            {
                MessageBox.Show("Digite usuário de conexão com o servidor!", "EstacionamentoFacil (FrmCx06)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bResposta = false;
            }

            if (txtSenha.Text.Length == 0 && bResposta)
            {
                MessageBox.Show("Digite a senha de conexão com o servidor!", "EstacionamentoFacil (FrmCx07)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bResposta = false;
            }

            if (txtBancoDados.Text.Length == 0 && bResposta)
            {
                MessageBox.Show("Digite o nome do banco de dados!", "EstacionamentoFacil (FrmCx08)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bResposta = false;
            }

            if (txtChaveAcesso.Text.Length == 0 && bResposta)
            {
                MessageBox.Show("Digite a chave de acesso!", "EstacionamentoFacil (FrmCx09)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bResposta = false;
            }

            if (cmbRelatorios.Text.Length == 0 && bResposta)
            {
                MessageBox.Show("Selecione um tipo de exibição de relatórios!", "EstacionamentoFacil (FrmCx09b)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bResposta = false;
            }
            return bResposta;
        }

        private void gravarRegistro()
        {
            try
            {
                Funcoes cFuncoes = new Funcoes();
                if (validaTela())
                {
                    if (File.Exists(sArquivoConexao))
                        File.Delete(sArquivoConexao);

                    System.Xml.XmlTextWriter xmlEscrever = new System.Xml.XmlTextWriter(sArquivoConexao, null);
                    
                    xmlEscrever.WriteStartDocument();
                    xmlEscrever.Formatting = System.Xml.Formatting.Indented;

                    xmlEscrever.WriteStartElement("Parametros");

                    xmlEscrever.WriteElementString("Servidor", txtServidor.Text.Trim());
                    xmlEscrever.WriteElementString("Porta", txtPorta.Text.Trim());
                    xmlEscrever.WriteElementString("User", txtUsuario.Text.Trim());
                    xmlEscrever.WriteElementString("Pass", cFuncoes.Criptografar(txtSenha.Text.Trim()));
                    xmlEscrever.WriteElementString("DataBase", txtBancoDados.Text.Trim());
                    xmlEscrever.WriteElementString("ChaveAcesso", cFuncoes.Criptografar(txtChaveAcesso.Text.Trim()));
                    int iTipoRelatorio = 0;
                    ComboBoxItem cmbItem2 = (ComboBoxItem)cmbRelatorios.SelectedItem;
                    if (cmbItem2 != null) iTipoRelatorio = int.Parse(cmbItem2.Value.ToString());
                    xmlEscrever.WriteElementString("TipoRelatorio", iTipoRelatorio.ToString());                    
                    
                    //xmlEscrever.WriteEndElement();
                    xmlEscrever.WriteFullEndElement();
                    xmlEscrever.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gravar dados de conexão!\n" + ex.Message, "EstacionamentoFacil (FrmCx10)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdGravar_Click(object sender, EventArgs e)
        {
            gravarRegistro();
        }

    }
}
