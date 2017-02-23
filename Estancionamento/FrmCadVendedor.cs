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
    public partial class FrmCadVendedor : Form
    {
        Cliente clientes;
        Veiculos veiculos;
        FrmPrincipal vTelaPrincipal;
        string sArquivoConexao;
        int iQteTelefones;
        int iQteCarros;
        TokenInputG.TokenInput cpToken;

        public FrmCadVendedor(string vArquivoConexao, FrmPrincipal vvTelaPrincipal)
        {
            InitializeComponent();
            iQteTelefones = 0;
            sArquivoConexao = vArquivoConexao;
            vTelaPrincipal = vvTelaPrincipal;
        }

        private void FrmCadVendedor_Load(object sender, EventArgs e)
        {
            ve_se_existe();
        }

        private void limparCampos(byte bTipo)
        {
            switch (bTipo)
            {
                case 0:
                    cmbNome.Items.Clear();
                    break;
                case 1:
                    cmbNome.Text = "";
                    break;
            }
            txtCPF.Clear();
            txtEmail.Clear();
            cmbSituacao.Text = "";
            pnlTelefones.Controls.Clear();
            gridHistorico.Rows.Clear();
            txtObservacaoTela.Clear();
        }

        private void ve_se_existe()
        {
            try
            {
                limparCampos(0);
                ComboBoxItem cboItem;
                List<vendedor> lstVendedor = new List<vendedor>();
                veiculos = new Veiculos();
                veiculos.ArquivoConexao = sArquivoConexao;
                lstVendedor = veiculos.pesquisarTodosVendedores("X");
                if (lstVendedor != null)
                {
                    if (lstVendedor.Count > 0)
                    {
                        foreach (vendedor cVendedor in lstVendedor)
                        {
                            cboItem = new ComboBoxItem();
                            cboItem.Value = cVendedor.código;
                            cboItem.Text = cVendedor.nome.Trim();
                            cmbNome.Items.Add(cboItem);
                        }
                    }//if
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir janela de vendedores! " + ex.Message, "EstacionamentoFacil (FrmVend01)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//ve_se_existe

        private bool validarTela()
        {
            bool bResposta = true;
            if (cmbNome.Text.Length == 0)
            {
                bResposta = false;
                MessageBox.Show("Nome do Vendedor em branco. Verifique! ", "EstacionamentoFacil (FrmVend02)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (txtCPF.Text.Length == 0 && bResposta)
            {
                bResposta = false;
                MessageBox.Show("CPF do Vendedor em branco. Verifique! ", "EstacionamentoFacil (FrmVend03)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (cmbSituacao.Text.Length == 0 && bResposta)
            {
                bResposta = false;
                MessageBox.Show("Selecione a situação do Vendedor! ", "EstacionamentoFacil (FrmVend04)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return bResposta;
        }

        private string buscaTipoTelefone(int iTipoTelefone)
        {
            string sResposta = "";
            switch (iTipoTelefone)
            {
                case 0:
                    sResposta = "Fixo";
                    break;
                case 1:
                    sResposta = "Celular";
                    break;
                case 2:
                    sResposta = "Outros";
                    break;
            }
            return sResposta;
        }

        private void exibirDadosVendedor(vendedor cVendedor,byte bTipo = 0)
        {
            string sTelefone="";
            int iQte = 0;
            List<Telefones> listTelefone;
            List<vendas> listVendas;
            Operadora cOperadora;
            limparCampos(2);
            try
            {                
                txtCPF.Text = cVendedor.cpf.Trim();
                txtEmail.Text = cVendedor.email.Trim();
                switch (cVendedor.situacao.Trim())
                {
                    case "A":
                        cmbSituacao.Text = "ATIVO";
                        break;
                    case "E":
                        cmbSituacao.Text = "EXCLUÍDO";
                        break;
                    case "I":
                        cmbSituacao.Text = "INATIVO";
                        break;
                }
                //telefones
                listTelefone = veiculos.pesquisarTodosTelefonesVendedor(cVendedor);
                if (listTelefone != null)
                {
                    foreach (Telefones lstTelefone in listTelefone)
                    {
                        Cliente cCliente = new Cliente();
                        cCliente.ArquivoConexao = sArquivoConexao;
                        cOperadora = cCliente.pesquisarOperadora(lstTelefone.codoperadora);

                        cpToken = new TokenInputG.TokenInput(vTelaPrincipal);
                        cpToken.Name = "token_" + iQte.ToString();
                        cpToken.Nome = "Telefone de " + cVendedor.nome;
                        cpToken.Indice = lstTelefone.CodigoTelefone + "#" + lstTelefone.ddd + "#" + lstTelefone.telefone + "#" + lstTelefone.codoperadora + "#" + lstTelefone.tipotelefone;
                        if (lstTelefone.telefone.Trim().Length <= 8)
                            sTelefone = lstTelefone.telefone.Substring(0, 4) + "-" + lstTelefone.telefone.Substring(4, 4);
                        else
                            sTelefone = lstTelefone.telefone.Substring(0, 5) + "-" + lstTelefone.telefone.Substring(5, 4);

                        cpToken.Texto = "(" + lstTelefone.ddd.PadLeft(2, '0') + ") " + sTelefone + " - " + cOperadora.operadora.Trim() + " (" + buscaTipoTelefone(lstTelefone.tipotelefone).Trim() + ")";
                        cpToken.ExibirLink = false;
                        cpToken.ajustarDadosTela();
                        pnlTelefones.Controls.Add(cpToken);
                        iQte++;
                    }
                    iQteTelefones = iQte;
                }
                //histórico de vendas
                listVendas = veiculos.pesquisarTodasVendasVendedor(cVendedor);
                if (listVendas != null)
                {
                    if (listVendas.Count > 0)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        string sTipoVenda = "";
                        foreach (vendas cVendas in listVendas)
                        {
                            switch (cVendas.tipo_venda)
                            {
                                case 0:
                                    sTipoVenda = "ESTANCIONAMENTO";
                                    break;
                                case 1:
                                    sTipoVenda = "INTERMEDIAÇÃO";
                                    break;
                            }
                            gridHistorico.AllowUserToAddRows = true;
                            row = (DataGridViewRow)gridHistorico.Rows[0].Clone();
                            gridHistorico.AllowUserToAddRows = false;

                            row.Cells[0].Value = cVendas.cod_venda.ToString();
                            row.Cells[1].Value = veiculos.pesquisarCarro(cVendas.cod_carro).Placa2.Trim();
                            row.Cells[2].Value = sTipoVenda;
                            row.Cells[3].Value = cVendas.valor.ToString("C");
                            row.Cells[4].Value = cVendas.data_venda.ToShortDateString();
                            gridHistorico.Rows.Add(row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao exibir dados de vendedor: " + ex.Message, "EstacionamentoFacil (FrmVend05)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (bTipo == 1) txtCPF.Focus();
        }

        private void gravarVendedor()
        {
            bool bErro = false;
            string sRetorno = "";
            Veiculos cVeiculo = new Veiculos();
            vendedor cVendedor = new vendedor();
            ComboBoxItem cmbItem;
            veiculos.ArquivoConexao = sArquivoConexao;
            if (validarTela())
            {
                cmbItem = (ComboBoxItem)cmbNome.SelectedItem;
                if (cmbItem != null)
                {
                    //atualizar
                    cVendedor.código = int.Parse(cmbItem.Value.ToString());
                    cVendedor.nome = cmbItem.Text;
                    cVendedor.cpf = txtCPF.Text;
                    cVendedor.email = txtEmail.Text;
                    cVendedor.situacao = cmbSituacao.Text.Substring(0, 1);
                    cVendedor.celular = "";
                    cVendedor.lembrete = "";
                    cVendedor.senha = "";
                    cVendedor.telefone = "";
                    sRetorno = veiculos.inserirAtualizarVendedor(cVendedor, 1);
                    if (sRetorno.Equals("T"))
                    {
                        //gravar telefones:
                        if (pnlTelefones.Controls.Count > 0)
                        {
                            TelefoneToken ccToken;
                            Telefones cTelefone;
                            List<Telefones> lstTelefone = new List<Telefones>();
                            foreach (TokenInputG.TokenInput cToken in pnlTelefones.Controls)
                            {
                                if (!cToken.Excluir)
                                {
                                    string[] sTelefone = cToken.Indice.Split('#');
                                    ccToken = new TelefoneToken();
                                    ccToken.Codigo = sTelefone[0];
                                    ccToken.ddd = sTelefone[1];
                                    ccToken.telefone = sTelefone[2];
                                    ccToken.Codigo_Operadora = int.Parse(sTelefone[3]);
                                    ccToken.Tipo_telefone = int.Parse(sTelefone[4]);

                                    cTelefone = new Telefones();

                                    if (ccToken.Codigo.Equals("N"))
                                        cTelefone.CodigoTelefone = 0;
                                    else
                                        cTelefone.CodigoTelefone = int.Parse(ccToken.Codigo);

                                    cTelefone.ddd = ccToken.ddd;
                                    cTelefone.telefone = ccToken.telefone;
                                    cTelefone.codoperadora = ccToken.Codigo_Operadora;
                                    cTelefone.tipotelefone = ccToken.Tipo_telefone;
                                    cTelefone.telefonedq = 0;
                                    lstTelefone.Add(cTelefone);
                                }
                                else
                                {
                                    string[] sTelefone = cToken.Indice.Split('#');
                                    if (!sTelefone[0].Equals("N"))
                                        clientes.excluirTelefone(int.Parse(sTelefone[0]));
                                }
                            }
                            if (!veiculos.inserirAtualizarTelefoneVendedor(lstTelefone,cVendedor))
                            {
                                MessageBox.Show("Telefone(s) do vendedor não atualizado!", "EstacionamentoFacil (FrmVend06)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                bErro = true;
                            }
                            if (!bErro)
                            {
                                MessageBox.Show("Vendedor atualizado com sucesso!", "EstacionamentoFacil (FrmVend07)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ve_se_existe();
                            }
                        }
                        else
                        {
                            veiculos.excluirTodosTelefoneVendedor(cVendedor);
                        }
                    }
                    else
                    {
                        MessageBox.Show("O Vendedor não foi atualizado!", "EstacionamentoFacil (FrmVend08)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    funcoes cFuncoes = new funcoes();
                    //inserir
                    cVendedor.nome = cmbNome.Text;
                    cVendedor.cpf = txtCPF.Text;
                    cVendedor.email = txtEmail.Text;
                    cVendedor.situacao = cmbSituacao.Text.Substring(0, 1);
                    cVendedor.celular = "";
                    cVendedor.lembrete = "";
                    cVendedor.senha = "";
                    cVendedor.telefone = "";
                    sRetorno = veiculos.inserirAtualizarVendedor(cVendedor, 0);
                    if (cFuncoes.isNumeric(sRetorno))
                    {
                        cVendedor.código = int.Parse(sRetorno);
                        //gravar telefones:
                        if (pnlTelefones.Controls.Count > 0)
                        {
                            TelefoneToken ccToken;
                            Telefones cTelefone;
                            List<Telefones> lstTelefone = new List<Telefones>();
                            foreach (TokenInputG.TokenInput cToken in pnlTelefones.Controls)
                            {
                                if (!cToken.Excluir)
                                {
                                    string[] sTelefone = cToken.Indice.Split('#');
                                    ccToken = new TelefoneToken();
                                    ccToken.Codigo = sTelefone[0];
                                    ccToken.ddd = sTelefone[1];
                                    ccToken.telefone = sTelefone[2];
                                    ccToken.Codigo_Operadora = int.Parse(sTelefone[3]);
                                    ccToken.Tipo_telefone = int.Parse(sTelefone[4]);

                                    cTelefone = new Telefones();

                                    if (ccToken.Codigo.Equals("N"))
                                        cTelefone.CodigoTelefone = 0;
                                    else
                                        cTelefone.CodigoTelefone = int.Parse(ccToken.Codigo);

                                    cTelefone.ddd = ccToken.ddd;
                                    cTelefone.telefone = ccToken.telefone;
                                    cTelefone.codoperadora = ccToken.Codigo_Operadora;
                                    cTelefone.tipotelefone = ccToken.Tipo_telefone;
                                    cTelefone.telefonedq = 0;
                                    lstTelefone.Add(cTelefone);
                                }
                                else
                                {
                                    string[] sTelefone = cToken.Indice.Split('#');
                                    if (!sTelefone[0].Equals("N"))
                                        clientes.excluirTelefone(int.Parse(sTelefone[0]));
                                }
                            }
                            if (!veiculos.inserirAtualizarTelefoneVendedor(lstTelefone, cVendedor))
                            {
                                MessageBox.Show("Telefone(s) do vendedor não inserido!", "EstacionamentoFacil (FrmVend09)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                bErro = true;
                            }                            
                        }
                        if (!bErro)
                        {
                            MessageBox.Show("Vendedor inserido com sucesso!", "EstacionamentoFacil (FrmVend10)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ve_se_existe();
                        }
                    }
                    else
                    {
                        MessageBox.Show("O Vendedor não foi atualizado!", "EstacionamentoFacil (FrmVend11)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }//inserir
            }//validarTela
        }//GravarVendedor

        private void selecionaVendedor()
        {
            ComboBoxItem cmbItem = new ComboBoxItem();
            cmbItem = (ComboBoxItem)cmbNome.SelectedItem;
            veiculos = new Veiculos();
            veiculos.ArquivoConexao = sArquivoConexao;
            vendedor cVendedor = veiculos.pesquisaVendedor(int.Parse(cmbItem.Value.ToString()));
            exibirDadosVendedor(cVendedor);
        }//selecionaVendedor

        private void lostVendedor()
        {
            limparCampos(2);
            if (cmbNome.Text.Length > 0)
            {
                ComboBoxItem cmbItem = new ComboBoxItem();
                cmbItem = (ComboBoxItem)cmbNome.SelectedItem;
                if (cmbItem != null)
                {
                    veiculos = new Veiculos();
                    veiculos.ArquivoConexao= sArquivoConexao;
                    vendedor cVendedor = veiculos.pesquisaVendedor(int.Parse(cmbItem.Value.ToString()));
                    exibirDadosVendedor(cVendedor);
                }
            }
        }//lostVendedor

        private void sairVendedor()
        {
            this.Close();
        }//sairVendedor

        /// <summary>
        /// Função para lançar um telefone na tela de vendedor
        /// </summary>
        /// <param name="cctoken">Objeto tokenTelefone</param>
        public void lancarTelefone(TelefoneToken cctoken)
        {
            string sTelefone;
            iQteTelefones++;
            veiculos = new Veiculos();
            Cliente cCliente = new Cliente();
            veiculos.ArquivoConexao = sArquivoConexao;
            cCliente.ArquivoConexao = sArquivoConexao;
            Operadora cOperadora = cCliente.pesquisarOperadora(cctoken.Codigo_Operadora);
            cpToken = new TokenInputG.TokenInput(vTelaPrincipal);
            cpToken.Name = "token_" + iQteTelefones.ToString();
            if (cmbNome.Text.Length > 0)
                cpToken.Nome = "Telefone de " + cmbNome.Text;
            else
                cpToken.Nome = "Telefone novo";

            if (cctoken.telefone.Trim().Length <= 8)
                sTelefone = cctoken.telefone.Substring(0, 4) + "-" + cctoken.telefone.Substring(4, 4);
            else
                sTelefone = cctoken.telefone.Substring(0, 5) + "-" + cctoken.telefone.Substring(5, 4);

            cpToken.Indice = cctoken.Codigo + "#" + cctoken.ddd + "#" + cctoken.telefone + "#" + cctoken.Codigo_Operadora.ToString() + "#" + cctoken.Tipo_telefone.ToString();
            cpToken.Texto = "(" + cctoken.ddd.PadLeft(2, '0') + ") " + sTelefone + " - " + cOperadora.operadora.Trim() + " (" + buscaTipoTelefone(cctoken.Tipo_telefone).Trim() + ")";
            cpToken.ExibirLink = false;
            cpToken.ajustarDadosTela();
            pnlTelefones.Controls.Add(cpToken);
        }//lancarTelefone

        private void cmbNome_SelectedValueChanged(object sender, EventArgs e)
        {
            selecionaVendedor();
        }

        private void cmbNome_Leave(object sender, EventArgs e)
        {
            lostVendedor();
        }

        private void cmbNome_Enter(object sender, EventArgs e)
        {
            limparCampos(1);
        }

        private void cmdGravar_Click(object sender, EventArgs e)
        {
            gravarVendedor();
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            sairVendedor();
        }

        private void cmdNovoTelefone_Click(object sender, EventArgs e)
        {
            ComboBoxItem cmbItem = (ComboBoxItem)cmbNome.SelectedItem;
            if (cmbItem != null)
            {
                vTelaPrincipal.abrirNovoTelefone(vTelaPrincipal, 1);
            }  
        }

        private void exibirObservacao(byte bTipo)
        {
            switch (bTipo)
            {
                case 0:
                    txtObservacaoTela.Text = "Clique com o botão da direita para obter mais opções!";
                    break;
                case 1:
                    txtObservacaoTela.Clear();
                    break;
            }
        }

        private void gridHistorico_MouseEnter(object sender, EventArgs e)
        {
            exibirObservacao(0);
        }

        private void gridHistorico_MouseLeave(object sender, EventArgs e)
        {
            exibirObservacao(1);
        }

        private void excluirDespesaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComboBoxItem cmbItem = (ComboBoxItem)cmbNome.SelectedItem;
            clientes = new Cliente();
            clientes.ArquivoConexao = sArquivoConexao;            
            vendedor cVendedor;
            Veiculos veiculos = new Veiculos();
            veiculos.ArquivoConexao = sArquivoConexao;
            int iIndice = 0;
            if (cmbItem != null)
            {
                cVendedor = veiculos.pesquisaVendedor(int.Parse(cmbItem.Value.ToString()));
                if (gridHistorico.Rows.Count > 0)
                {
                    iIndice = int.Parse(gridHistorico.CurrentRow.Cells[0].Value.ToString());
                    if (iIndice > 0)
                    {
                        vendas cVendas = new vendas();
                        cVendas = veiculos.pesquisarVenda(int.Parse(gridHistorico.CurrentRow.Cells[0].Value.ToString()));
                        vTelaPrincipal.abrirCadVendas(vTelaPrincipal, 1, cVendas);
                    }
                    else
                    {
                        MessageBox.Show("Nenhum dado a ser exibido!", "EstacionamentoFacil (FrmVend12)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Cadastro novo! Selecione primeiro um vendedor!", "EstacionamentoFacil (FrmVend13)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void cmbNome_MouseEnter(object sender, EventArgs e)
        {
            ComboBoxItem cmbItem = (ComboBoxItem)cmbNome.SelectedItem;
            if (cmbItem != null)
            {
                exibirObservacao(0);
            }
        }

        private void cmbNome_MouseLeave(object sender, EventArgs e)
        {
            exibirObservacao(1);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ComboBoxItem cmbItem = (ComboBoxItem)cmbNome.SelectedItem;
            if (cmbItem != null)
            {
                vendedor cVendedor;
                Veiculos veiculos = new Veiculos();
                veiculos.ArquivoConexao = sArquivoConexao;

                cVendedor = veiculos.pesquisaVendedor(int.Parse(cmbItem.Value.ToString()));
                string sNome = Microsoft.VisualBasic.Interaction.InputBox("Qual o novo nome?", "Novo nome", cmbItem.Text);
                if (sNome.Trim().Length != 0)
                {
                    cVendedor.nome = sNome.Trim();
                    if (veiculos.inserirAtualizarVendedor(cVendedor, 1).Equals("T"))
                    {
                        MessageBox.Show("Nome alterado com sucesso!", "EstacionamentoFacil (FrmVend14)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ve_se_existe();
                        exibirDadosVendedor(cVendedor, 1);
                    }
                }

            }
            else
            {
                MessageBox.Show("Alteração permitida somente para cadastros já gravados!", "EstacionamentoFacil (FrmVend15)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtCPF_Leave(object sender, EventArgs e)
        {
            Funcoes funcao = new Funcoes();
            if (txtCPF.Text.Length > 0)
            {
                if (!funcao.validarCPF(txtCPF.Text))
                {
                    if (MessageBox.Show("CPF Inválido!\n\nDeseja continuar com a digitação dos dados?", "EstacionamentoFacil (FrmVend15b)", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                    {
                        txtCPF.Clear();
                        txtCPF.Focus();
                    }
                }
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            Funcoes funcao = new Funcoes();
            if (txtEmail.Text.Length > 0)
            {
                if (!funcao.validarEmail(txtEmail.Text))
                {
                    if (MessageBox.Show("E-mail Inválido!\n\nDeseja continuar com a digitação dos dados?", "EstacionamentoFacil (FrmVend15c)", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                    {
                        txtEmail.Clear();
                        txtEmail.Focus();
                    }
                }
            }
        }
    }
}
