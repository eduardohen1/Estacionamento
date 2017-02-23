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
    public partial class FrmAuditoria : Form
    {
        Usuarios cUsuario;
        FrmPrincipal vTelaPrincipal;
        string sArquivoConexao;



        public FrmAuditoria(string vArquivoConexao, FrmPrincipal vvTelaPrincipal)
        {
            InitializeComponent();
            vTelaPrincipal = vvTelaPrincipal;
            sArquivoConexao = vArquivoConexao;
        }

        private void FrmAuditoria_Load(object sender, EventArgs e)
        {
            ve_se_existe();
        }

        private void limparTela()
        {
            cmbAuditoria.Items.Clear();
            cmbUsuario.Items.Clear();
            txtChave.Clear();
            gridAuditoria.Rows.Clear();
        }

        private void ve_se_existe()
        {
            try
            {
                limparTela();
                ComboBoxItem cboItem;
                List<auditoria_operacao> lstOperacao = new List<auditoria_operacao>();
                List<usuario> lstUsuarios = new List<usuario>();
                cUsuario = new Usuarios();
                cUsuario.ArquivoConexao = sArquivoConexao;
                
                //auditorias
                lstOperacao = cUsuario.buscaOperacaoAuditoria();
                if (lstOperacao != null)
                {
                    if (lstOperacao.Count > 0)
                    {
                        foreach (auditoria_operacao cOperacao in lstOperacao)
                        {
                            cboItem = new ComboBoxItem();
                            cboItem.Value = cOperacao.operacao;
                            cboItem.Text = cOperacao.descricao;
                            cmbAuditoria.Items.Add(cboItem);
                        }
                    }
                }

                //usuarios
                lstUsuarios = cUsuario.buscaTodosUsuario(5);
                if (lstUsuarios != null)
                {
                    if (lstUsuarios.Count > 0)
                    {
                        foreach (usuario obUsuario in lstUsuarios)
                        {
                            cboItem = new ComboBoxItem();
                            cboItem.Value = obUsuario.cod_usuario;
                            cboItem.Text = obUsuario.nomeusuario;
                            cmbUsuario.Items.Add(cboItem);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir janela de auditoria!\n" + ex.Message, "EstacionamentoFacil (FrmAud01)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//ve_se_existe

        private bool validaTela()
        {
            bool bResposta = true;
            if (chkPorData.Checked)
            {
                if (DateTime.Parse(txtDtInicial.Text) > DateTime.Parse(txtDataFinal.Text))
                {
                    MessageBox.Show("Data inicial é maior que a data final. Verifique!", "EstacionamentoFacil (FrmAud02)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bResposta = false;
                }
            }

            if (chkPorUsuario.Checked && bResposta)
            {
                if (cmbUsuario.Text.Length == 0)
                {
                    MessageBox.Show("Selecione o usuário para a pesquisa!", "EstacionamentoFacil (FrmAud03)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bResposta = false;
                }
            }

            if (chkPorAuditoria.Checked && bResposta)
            {
                if (cmbAuditoria.Text.Length == 0)
                {
                    MessageBox.Show("Selecione a auditoria para a pesquisa!", "EstacionamentoFacil (FrmAud04)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bResposta = false;
                }
            }

            if (chkPorChave.Checked && bResposta)
            {
                if (txtChave.Text.Length == 0)
                {
                    MessageBox.Show("Digite a CHAVE para a pesquisa!", "EstacionamentoFacil (FrmAud05)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bResposta = false;
                }
            }
            return bResposta;
        }//validaTela

        private string montaPesquisa(byte bTipo = 0)
        {
            string sResposta = "";
            string sResposta2 = "";
            ComboBoxItem cmbItem;

            if (chkPorData.Checked)
            {
                sResposta = " a.data_operacao BETWEEN CONVERT(DATETIME,'" + txtDtInicial.Text + " 00:00:00',103) AND CONVERT(DATETIME,'" + txtDataFinal.Text + " 23:59:59',103) ";
                sResposta2 = "Por data (" + txtDtInicial.Text + " à " + txtDataFinal.Text + ")";
            }
            if (chkPorUsuario.Checked)
            {
                cmbItem = (ComboBoxItem)cmbUsuario.SelectedItem;
                if (cmbItem != null)
                {
                    if(sResposta.Trim().Length >0) sResposta = sResposta + " AND ";
                    if (sResposta2.Trim().Length > 0) sResposta2 = sResposta2 + ", ";
                    sResposta = sResposta + " a.cod_usuario = " + cmbItem.Value.ToString();
                    sResposta2 = sResposta2 + "Por usuário (" + cmbUsuario.Text.Trim() + ")";
                }
            }
            if (chkPorAuditoria.Checked)
            {
                cmbItem = (ComboBoxItem)cmbAuditoria.SelectedItem;
                if (cmbItem != null)
                {
                    if (sResposta.Trim().Length > 0) sResposta = sResposta + " AND ";
                    if (sResposta2.Trim().Length > 0) sResposta2 = sResposta2 + ", ";
                    sResposta = sResposta + " a.operacao = " + cmbItem.Value.ToString();
                    sResposta2 = sResposta2 + "Por auditoria (" + cmbAuditoria.Text.Trim() + ")";
                }
            }
            if (chkPorChave.Checked)
            {
                if (sResposta.Trim().Length > 0) sResposta = sResposta + " AND ";
                if (sResposta2.Trim().Length > 0) sResposta2 = sResposta2 + ", ";
                sResposta = sResposta + " a.descritivo LIKE '%" + txtChave.Text.Trim() + "%'";
                sResposta2 = sResposta2 + "Por chave (" + txtChave.Text.Trim() + ")";
            }
            if (sResposta.Trim().Length > 0) sResposta = " WHERE " + sResposta;

            if (bTipo == 1) sResposta = sResposta2;
            return sResposta;
        }

        private void pesquisarAuditoria()
        {
            try
            {
                if (validaTela())
                {
                    if (gridAuditoria.Rows.Count > 0)
                        gridAuditoria.Rows.Clear();

                    cUsuario = new Usuarios();
                    cUsuario.ArquivoConexao = sArquivoConexao;
                    List<auditoria> lstAuditoria = new List<auditoria>();
                    lstAuditoria = cUsuario.buscaAuditorias(montaPesquisa());

                    if (lstAuditoria != null)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        if (lstAuditoria.Count > 0)
                        {
                            foreach (auditoria obAuditoria in lstAuditoria)
                            {
                                gridAuditoria.AllowUserToAddRows = true;
                                row = (DataGridViewRow)gridAuditoria.Rows[0].Clone();
                                gridAuditoria.AllowUserToAddRows = false;

                                row.Cells[0].Value = obAuditoria.codigo;
                                row.Cells[1].Value = obAuditoria.data_operacao.ToString("dd/MM/yyyy HH:mm:ss");
                                row.Cells[2].Value = cUsuario.buscaOperacaoAuditoria(obAuditoria.operacao).descricao.Trim();
                                row.Cells[3].Value = obAuditoria.descritivo.Trim();
                                row.Cells[4].Value = cUsuario.buscaDadosUsuario(obAuditoria.cod_usuario).nomeusuario.Trim();
                                gridAuditoria.Rows.Add(row);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao pesquisar!\n" + ex.Message, "EstacionamentoFacil (FrmAud06)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdImprimir_Click(object sender, EventArgs e)
        {
            Application.DoEvents();
            lblStatus.Text = "Imprimindo...";
            cmdPesquisar.Enabled = false;
            cmdFechar.Enabled = false;
            cmdImprimir.Enabled = false;
            pnlPesquisa.Visible = true;
            imprimirConsulta();
            cmdPesquisar.Enabled = true;
            cmdFechar.Enabled = true;
            cmdImprimir.Enabled = true;
            pnlPesquisa.Visible = false;
        }

        private void cmdPesquisar_Click(object sender, EventArgs e)
        {
            Application.DoEvents();
            lblStatus.Text = "Pesquisando...";
            cmdPesquisar.Enabled = false;
            cmdFechar.Enabled = false;
            cmdImprimir.Enabled = false;
            pnlPesquisa.Visible = true;
            pesquisarAuditoria();
            cmdPesquisar.Enabled = true;
            cmdFechar.Enabled = true;
            cmdImprimir.Enabled = true;
            pnlPesquisa.Visible = false;
        }

        private void imprimirConsulta()
        {
            try
            {
                if (gridAuditoria.Rows.Count > 0)
                {
                    if (validaTela())
                    {
                        cUsuario = new Usuarios();
                        cUsuario.ArquivoConexao = sArquivoConexao;
                        if (cUsuario.buscaAuditorias(montaPesquisa(), montaPesquisa(1)))
                        {
                            //chamar tela de impressao
                            switch (vTelaPrincipal.vvEmpresa.tipo_relatorio)
                            {
                                case 0:
                                    vTelaPrincipal.abrirImpressaoAuditoria(vTelaPrincipal);
                                    break;
                                case 1:
                                    vTelaPrincipal.abrirImpressaoAuditoria(vTelaPrincipal, 0);
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Nenhum dado a ser impresso!", "EstacionamentoFacil (FrmAud07)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar temporária de impressão!\n" + ex.Message, "EstacionamentoFacil (FrmAud08)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
