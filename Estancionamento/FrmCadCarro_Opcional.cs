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
    public partial class FrmCadCarro_Opcional : Form
    {    
        public string sCodigosExistentes;
        FrmPrincipal vTelaPrincipal;        
        carro cCarro;
        Veiculos veiculos;
        string sArquivoConexao;
        
        public FrmCadCarro_Opcional(string vArquivoConexao, FrmPrincipal vTela_FrmPrincipal, carro ccCarro)
        {
            InitializeComponent();
            sArquivoConexao = vArquivoConexao;
            vTelaPrincipal = vTela_FrmPrincipal;
            cCarro = ccCarro;
        }

        private void FrmCadCarro_Opcional_Load(object sender, EventArgs e)
        {
            ve_se_existe();
        }

        private void ve_se_existe()
        {
            int iQte = 0;
            bool bResposta = true;
            try
            {
                chkListOpcional.Items.Clear();
                veiculos = new Veiculos();
                veiculos.ArquivoConexao = sArquivoConexao;

                List<opicionais> listOpcional = new List<opicionais>();
                ComboBoxItem cboItem;
                listOpcional = veiculos.pesquisarTodosOpicionaisNCarro(cCarro.Codigo);
                foreach (opicionais lstOpcional in listOpcional)
                {
                    cboItem = new ComboBoxItem();
                    cboItem.Text = lstOpcional.descricao.Trim();
                    cboItem.Value = lstOpcional.codigo;
                    chkListOpcional.Items.Add(cboItem);
                    iQte++;
                }
                if (iQte == 0)
                {
                    MessageBox.Show("Nenhum opcional cadastrado!", "EstacionamentoFacil (FrmNopC02)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    bResposta = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir janela de Novo opcional do carro! " + ex.Message, "EstacionamentoFacil (FrmNopC01)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bResposta = false;
            }
            if (!bResposta) cmdGravar.Enabled = false;
        }

        private bool validaTela()
        {
            bool bResposta = true;

            if (chkListOpcional.CheckedItems.Count == 0)
            {
                bResposta = false;
                MessageBox.Show("Selecione um opcional para adicionar!", "EstacionamentoFacil (FrmNopC03)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return bResposta;
        }

        private void cmdGravar_Click(object sender, EventArgs e)
        {
            opicionais cOpcional;
            if (validaTela())
            {
                foreach (ComboBoxItem item in chkListOpcional.CheckedItems)
                {
                    cOpcional = new opicionais();
                    cOpcional.codigo = int.Parse(item.Value.ToString());
                    cOpcional.descricao = item.Text;
                    vTelaPrincipal.vTela_FrmCadCarro.lancarOpcional(cOpcional,"N");
                    }
                this.Close();
            }
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
