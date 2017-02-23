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
    public partial class FrmCadVenda : Form
    {
        Cliente clientes;
        Veiculos veiculos;
        FrmPrincipal vTelaPrincipal;
        string sArquivoConexao;
        /// <summary>
        /// TipoEntrada 0 Normal 1 Com dados de vendas
        /// </summary>
        byte bTipoEntrada=0;
        vendas cPrincipalVendas=null;

        int SituacaoVenda
        {
            get;
            set;
        }

        public FrmCadVenda(string vArquivoConexao, FrmPrincipal vvTelaPrincipal, byte bbTipo, vendas ccVendas)
        {
            InitializeComponent();
            sArquivoConexao = vArquivoConexao;
            vTelaPrincipal = vvTelaPrincipal;
            bTipoEntrada = bbTipo;
            cPrincipalVendas = ccVendas;
        }

        private void cmdNovaObservacao_Click(object sender, EventArgs e)
        {
            novaObservacao();
        }

        private void FrmCadVenda_Load(object sender, EventArgs e)
        {
            ve_se_existe();
            switch (bTipoEntrada)
            {
                case 1:
                    exibirDadosVenda(cPrincipalVendas);
                    break;
            }
        }

        private void ve_se_existe()
        {
            try
            {
                limparTela(0);
                ComboBoxItem cboItem;
                
                //venda
                List<vendas> lstVenda = new List<vendas>();
                veiculos = new Veiculos();
                veiculos.ArquivoConexao = sArquivoConexao;
                lstVenda = veiculos.pesquisarTodasVendas(5);
                if (lstVenda != null)
                {
                    if (lstVenda.Count > 0)
                    {
                        foreach (vendas cVenda in lstVenda)
                        {
                            cboItem = new ComboBoxItem();
                            cboItem.Value = cVenda.cod_venda;
                            cboItem.Text = cVenda.cod_venda.ToString("D5") + "/" + cVenda.data_venda.Year.ToString();
                            cmbVenda.Items.Add(cboItem);
                        }
                    }
                }

                //carro
                List<carro> lstCarro = new List<carro>();                
                lstCarro = veiculos.pesquisarTodosCarros();
                if (lstCarro != null)
                {
                    if (lstCarro.Count > 0)
                    {
                        foreach (carro cCarro in lstCarro)
                        {
                            cboItem = new ComboBoxItem();
                            cboItem.Value = cCarro.Codigo;
                            cboItem.Text = cCarro.Placa2.Trim();
                            cmbVeiculo.Items.Add(cboItem);
                        }
                    }
                }

                //clientes
                List<cliente> lstCliente = new List<cliente>();
                clientes = new Cliente();
                clientes.ArquivoConexao = sArquivoConexao;
                lstCliente = clientes.pesquisarTodosClientes();
                if (lstCliente != null)
                {
                    if (lstCliente.Count > 0)
                    {
                        foreach (cliente cCliente in lstCliente)
                        {
                            cboItem = new ComboBoxItem();
                            cboItem.Value = cCliente.Codigo;
                            cboItem.Text = cCliente.Nome.Trim();
                            cmbClienteComprador.Items.Add(cboItem);
                            cmbClienteVendedor.Items.Add(cboItem);
                        }
                    }
                }

                //Tipo venda
                cboItem = new ComboBoxItem();
                cboItem.Value = 0;
                cboItem.Text = "ESTANCIONAMENTO";
                cmbTipoVenda.Items.Add(cboItem);

                cboItem = new ComboBoxItem();
                cboItem.Value = 1;
                cboItem.Text = "INTERMEDIAÇÃO";
                cmbTipoVenda.Items.Add(cboItem);

                //situacao 0 em aberto 1 concluída 2 cancelada 3 aguardando financiamento 4 suspensa
                int iCodSituacao = 0;
                string[] situacao = {"ABERTO", "CONCLUÍDA","CANCELADA", "AGUARDANDO FINANCIAMENTO","SUSPENSA"};
                foreach (string sSituacao in situacao)
                {
                    iCodSituacao = int.Parse(retornaCodigoSituacao(0, sSituacao).ToString());
                    cboItem = new ComboBoxItem();
                    cboItem.Value = iCodSituacao;
                    cboItem.Text = sSituacao;
                    cmbSituacao.Items.Add(cboItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir janela de Venda!\n" + ex.Message, "EstacionamentoFacil (FrmVd01)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//ve_se_existe

        private object retornaCodigoSituacao(byte bTipo,string sSituacao="", int iCodigo = 0)
        {
            int iResposta = 0;
            string sResposta = "";
            if (bTipo == 0)
            {
                switch (sSituacao)
                {
                    case "ABERTO":
                        iResposta = 0;
                        break;
                    case "CONCLUÍDA":
                        iResposta = 1;
                        break;
                    case "CANCELADA":
                        iResposta = 2;
                        break;
                    case "AGUARDANDO FINANCIAMENTO":
                        iResposta = 3;
                        break;
                    case "SUSPENSA":
                        iResposta = 4;
                        break;
                }
                return iResposta;
            }
            else
            {
                switch (iCodigo)
                {
                    case 0:
                        sResposta = "ABERTO";
                        break;
                    case 1:
                        sResposta = "CONCLUÍDA";
                        break;
                    case 2:
                        sResposta = "CANCELADA";
                        break;
                    case 3:
                        sResposta = "AGUARDANDO FINANCIAMENTO";
                        break;
                    case 4:
                        sResposta = "SUSPENSA";
                        break;
                }
                return sResposta;
            }
            
        }

        private void limparTela(byte bTipo)
        {
            switch (bTipo)
            {
                case 0:
                    cmbVenda.Items.Clear();
                    cmbVeiculo.Items.Clear();
                    cmbClienteComprador.Items.Clear();
                    cmbClienteVendedor.Items.Clear();
                    cmbSituacao.Items.Clear();
                    cmbTipoVenda.Items.Clear();
                    break;
                case 1:
                    cmbVenda.Text = "";
                    cmbVeiculo.Text = "";
                    cmbClienteVendedor.Text = "";
                    cmbClienteComprador.Text = "";
                    cmbSituacao.Text = "";
                    cmbTipoVenda.Text = "";
                    break;
            }
            txtModelo.Clear();                        
            txtValorVenda.Clear();
            txtObservacao.Clear();
            txtDescritivoComissao.Clear();
            txtObservacaoTela.Clear();
            if(bTipo == 0)
                cmbVeiculo.Focus();

            gridObservacao.Rows.Clear();
            gridVendedor.Rows.Clear();

        }//limparTela

        private bool validarTela()
        {
            bool bResposta = true;
            if (cmbVeiculo.Text.Length == 0)
            {
                MessageBox.Show("Selecione o veículo de venda! ", "EstacionamentoFacil (FrmVd02)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bResposta = false;
            }

            if (cmbClienteComprador.Text.Length == 0 && bResposta)
            {
                MessageBox.Show("Selecione o comprador do veículo! ", "EstacionamentoFacil (FrmVd03)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bResposta = false;
            }

            if (cmbClienteVendedor.Text.Length == 0 && bResposta)
            {
                MessageBox.Show("Selecione o vendedor do veículo! ", "EstacionamentoFacil (FrmVd03)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bResposta = false;
            }

            if (cmbTipoVenda.Text.Length == 0 && bResposta)
            {
                MessageBox.Show("Selecione o tipo de venda do veículo! ", "EstacionamentoFacil (FrmVd04)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bResposta = false;
            }

            if (txtValorVenda.Text.Length == 0 && bResposta)
            {
                MessageBox.Show("Digite o valor de venda do veículo! ", "EstacionamentoFacil (FrmVd05)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bResposta = false;
            }

            if (cmbSituacao.Text.Length == 0 && bResposta)
            {
                MessageBox.Show("Selecione a situação da venda do veículo! ", "EstacionamentoFacil (FrmVd06)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bResposta = false;
            }

            return bResposta;
        }//valida tela

        private void ValidateFill(System.Windows.Forms.Control ctl, bool bCurrency)
        {
            System.Windows.Forms.TextBox t = (System.Windows.Forms.TextBox)ctl;
            try
            {
                int s = System.Convert.ToInt32(ctl.Text);
                if (bCurrency)
                    t.Text = s.ToString("C");
                System.Windows.Forms.Control c = this.GetNextControl(ctl, true);
                c.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Somente valores numéricos. Verifique!!!", "EstacionamentoFacil (FrmVd07)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (bCurrency)
                    t.Text = "0,00";
                else
                    t.Text = "0";
                t.Focus();
            }
        }//validatefill

        private void exibirDadosVenda(vendas cVendas)
        {            
            try
            {
                limparTela(2);
                veiculos = new Veiculos();                
                clientes = new Cliente();
                veiculos.ArquivoConexao = sArquivoConexao;
                clientes.ArquivoConexao = sArquivoConexao;

                switch (bTipoEntrada)
                {
                    case 1:
                        cmbVenda.SelectedText = cVendas.cod_venda.ToString("D5") + "/" + cVendas.data_venda.Year.ToString();
                        break;
                }
                cmbVeiculo.Text = veiculos.pesquisarCarro(cVendas.cod_carro).Placa2.Trim();
                txtModelo.Text = veiculos.pesquisarMarca(veiculos.pesquisarCarro(cVendas.cod_carro).CodMarca).descricao + " | " + veiculos.pesquisarCarro(cVendas.cod_carro).Modelo;
                cmbClienteComprador.Text = clientes.pesquisarCliente(cVendas.cod_cliente_comprador).Nome.Trim();
                cmbClienteVendedor.Text = clientes.pesquisarCliente(cVendas.cod_cliente_vendedor).Nome.Trim();
                if (cVendas.tipo_venda == 0)
                    cmbTipoVenda.Text = "ESTANCIONAMENTO";
                else
                    cmbTipoVenda.Text = "INTERMEDIAÇÃO";
                txtValorVenda.Text = cVendas.valor.ToString("C");
                txtObservacao.Text = cVendas.observacao.Trim();
                cmbSituacao.Text = retornaCodigoSituacao(1, "", cVendas.situacao).ToString();
                txtDescritivoComissao.Text = cVendas.tipo_comissao.Trim();

                SituacaoVenda = cVendas.situacao;

                //Comissao
                lancarComissao(cVendas);

                //observacao
                lancarObservacao(cVendas);

                cmbVeiculo.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao exibir dados da venda!\n" + ex.Message, "EstacionamentoFacil (FrmVd08)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Função para pesquisar as comissões de uma venda
        /// </summary>
        /// <param name="cVendas">Objeto venda para pesquisa</param>
        public void lancarComissao(vendas cVendas)
        {
            gridVendedor.Rows.Clear();
            List<vendas_vendedor> lstComissao = veiculos.buscarComissaoVenda(cVendas.cod_venda);
            if (lstComissao != null)
            {
                if (lstComissao.Count > 0)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    string sSituacao = "";
                    foreach (vendas_vendedor cComissao in lstComissao)
                    {
                        gridVendedor.AllowUserToAddRows = true;
                        row = (DataGridViewRow)gridVendedor.Rows[0].Clone();
                        gridVendedor.AllowUserToAddRows = false;

                        switch (cComissao.situacao)
                        {
                            case 0:
                                sSituacao = "ABERTO";
                                break;
                            case 1:
                                sSituacao = "LANÇADO";
                                break;
                            case 2:
                                sSituacao = "CANCELADO";
                                break;
                            case 3:
                                sSituacao = "APENAS LANÇADO";
                                break;
                        }

                        row.Cells[0].Value = cComissao.cod_vendedor.ToString();
                        row.Cells[1].Value = cComissao.cod_venda.ToString();
                        row.Cells[2].Value = veiculos.pesquisaVendedor(cComissao.cod_vendedor).nome.Trim();
                        row.Cells[3].Value = cComissao.valor_comissao.ToString("C");
                        row.Cells[4].Value = sSituacao;
                        gridVendedor.Rows.Add(row);

                    }
                }
            }
        }//lancarComissao

        /// <summary>
        /// Função para exibir as observações de uma venda
        /// </summary>
        /// <param name="cVendas">Objeto Vendas</param>
        public void lancarObservacao(vendas cVendas)
        {
            DataGridViewRow row;
            gridObservacao.Rows.Clear();
            veiculos.ArquivoConexao = sArquivoConexao;
            List<observacao> lstObservacao = veiculos.buscarObservacaoVenda(cVendas.cod_venda);
            if (lstObservacao != null)
            {
                if (lstObservacao.Count > 0)
                {
                    row = new DataGridViewRow();
                    foreach (observacao cObservacao in lstObservacao)
                    {
                        gridObservacao.AllowUserToAddRows = true;
                        row = (DataGridViewRow)gridObservacao.Rows[0].Clone();
                        gridObservacao.AllowUserToAddRows = false;
                        row.Cells[0].Value = cObservacao.cod_observacao.ToString();
                        row.Cells[1].Value = cObservacao.sObservacao;
                        row.Cells[2].Value = veiculos.buscaDadosUsuario(cObservacao.cod_usuario).nomeusuario.Trim();
                        row.Cells[3].Value = cObservacao.cod_usuario.ToString();
                        row.Cells[4].Value = cObservacao.data_observacao.ToString("dd/MM/yyyy HH:mm:ss");
                        gridObservacao.Rows.Add(row);
                    }
                }
            }
        }//lancarObservacao

        private void gravarVenda()
        {
            string sRetorno = "";
            bool bErro = false;
            ComboBoxItem cmbItem;
            ComboBoxItem cboValores;
            vendas cVendas = new vendas();
            veiculos = new Veiculos();
            funcoes cFuncoes = new funcoes();
            veiculos.ArquivoConexao = sArquivoConexao;
            
            if (validarTela())
            {
                cmbItem = (ComboBoxItem)cmbVenda.SelectedItem;
                if (cmbItem != null)
                {
                    //atualizar
                    cVendas.cod_venda = int.Parse(cmbItem.Value.ToString());

                    cboValores = new ComboBoxItem();
                    cboValores = (ComboBoxItem)cmbVeiculo.SelectedItem;
                    cVendas.cod_carro = int.Parse(cboValores.Value.ToString());

                    cboValores = new ComboBoxItem();
                    cboValores = (ComboBoxItem)cmbClienteComprador.SelectedItem;
                    cVendas.cod_cliente_comprador = int.Parse(cboValores.Value.ToString());

                    cboValores = new ComboBoxItem();
                    cboValores = (ComboBoxItem)cmbClienteVendedor.SelectedItem;
                    cVendas.cod_cliente_vendedor = int.Parse(cboValores.Value.ToString());

                    cboValores = new ComboBoxItem();
                    cboValores = (ComboBoxItem)cmbTipoVenda.SelectedItem;
                    cVendas.tipo_venda = int.Parse(cboValores.Value.ToString());

                    cboValores = new ComboBoxItem();
                    cboValores = (ComboBoxItem)cmbSituacao.SelectedItem;
                    cVendas.situacao = int.Parse(cboValores.Value.ToString());

                    if (txtValorVenda.Text.Length == 0) txtValorVenda.Text = "0";
                    cVendas.valor = double.Parse(veiculos.limparMoeda(txtValorVenda.Text.Trim()));
                    cVendas.observacao = txtObservacao.Text;
                    cVendas.tipo_comissao = txtDescritivoComissao.Text;
                    
                    sRetorno = veiculos.inserirAtualizarVendas(cVendas, 1);
                    if (sRetorno.Equals("T"))
                    {
                        if (cVendas.situacao != SituacaoVenda)
                        {
                            switch (cVendas.situacao)
                            {
                                case 1:
                                    if (!veiculos.lancarHistoricoVenda(cVendas, vTelaPrincipal.vvCodigoUsuario, this.Name))
                                        bErro = true;
                                    break;
                                case 2:
                                    if (!veiculos.lancarHistoricoVendaCancelar(cVendas, vTelaPrincipal.vvCodigoUsuario, this.Name))
                                        bErro = true;
                                    break;
                            }//switch
                        }//if
                        
                        if (!bErro)
                        {
                            MessageBox.Show("Venda atualizada com sucesso!", "EstacionamentoFacil (FrmVd09)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            limparTela(1);
                            ve_se_existe();
                        }
                    }
                    else
                    {
                        MessageBox.Show("A venda não foi atualizada!", "EstacionamentoFacil (FrmVd10)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //nova
                    cVendas.cod_venda = 0;
                    cboValores = new ComboBoxItem();
                    cboValores = (ComboBoxItem)cmbVeiculo.SelectedItem;
                    cVendas.cod_carro = int.Parse(cboValores.Value.ToString());

                    cboValores = new ComboBoxItem();
                    cboValores = (ComboBoxItem)cmbClienteComprador.SelectedItem;
                    cVendas.cod_cliente_comprador = int.Parse(cboValores.Value.ToString());

                    cboValores = new ComboBoxItem();
                    cboValores = (ComboBoxItem)cmbClienteVendedor.SelectedItem;
                    cVendas.cod_cliente_vendedor = int.Parse(cboValores.Value.ToString());

                    cboValores = new ComboBoxItem();
                    cboValores = (ComboBoxItem)cmbTipoVenda.SelectedItem;
                    cVendas.tipo_venda = int.Parse(cboValores.Value.ToString());

                    cboValores = new ComboBoxItem();
                    cboValores = (ComboBoxItem)cmbSituacao.SelectedItem;
                    string sTemp = retornaCodigoSituacao(1, "", int.Parse(cboValores.Value.ToString())).ToString();
                    cVendas.situacao = int.Parse(cboValores.Value.ToString());

                    if (txtValorVenda.Text.Length == 0) txtValorVenda.Text = "0";
                    cVendas.valor = double.Parse(txtValorVenda.Text);
                    cVendas.observacao = txtObservacao.Text;
                    cVendas.tipo_comissao = txtDescritivoComissao.Text;

                    sRetorno = veiculos.inserirAtualizarVendas(cVendas, 0);
                    if (cFuncoes.isNumeric(sRetorno))
                    {
                        switch (cVendas.situacao)
                        {
                            case 1:
                                if (!veiculos.lancarHistoricoVenda(cVendas, vTelaPrincipal.vvCodigoUsuario, this.Name))
                                    bErro = true;
                                break;
                            case 2:
                                if (!veiculos.lancarHistoricoVendaCancelar(cVendas, vTelaPrincipal.vvCodigoUsuario, this.Name))
                                    bErro = true;
                                break;
                        }
                        if(!bErro)
                        {
                            MessageBox.Show("Venda inserida com sucesso!", "EstacionamentoFacil (FrmVd11)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            limparTela(1);
                            ve_se_existe();
                        }
                    }else
                        MessageBox.Show("A venda não foi inserida!", "EstacionamentoFacil (FrmVd12)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }//gravarVenda

        private void selecionarVenda()
        {
            ComboBoxItem cmbItem = new ComboBoxItem();
            cmbItem = (ComboBoxItem)cmbVenda.SelectedItem;
            veiculos = new Veiculos();
            veiculos.ArquivoConexao = sArquivoConexao;
            vendas cVendas = veiculos.pesquisarVenda(int.Parse(cmbItem.Value.ToString()));
            exibirDadosVenda(cVendas);
        }//selecionarVenda

        private void lostVenda()
        {
            limparTela(2);
            if (cmbVenda.Text.Length > 0)
            {
                ComboBoxItem cmbItem = new ComboBoxItem();
                cmbItem = (ComboBoxItem)cmbVenda.SelectedItem;
                if (cmbItem != null)
                {
                    veiculos = new Veiculos();
                    veiculos.ArquivoConexao = sArquivoConexao;
                    vendas cVendas = veiculos.pesquisarVenda(int.Parse(cmbItem.Value.ToString()));
                    exibirDadosVenda(cVendas);
                }
            }
        }//lostVenda

        private void sairTela()
        {
            this.Close();
        }
        private void txtValorVenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue < 58)
            {
                if (e.KeyValue < 48 || e.KeyValue > 57)
                {
                    //backspace
                    if (e.KeyValue == 8)
                        e.SuppressKeyPress = false;
                    //enter
                    else if (e.KeyValue == 13)
                    {
                        e.SuppressKeyPress = false;
                        this.ValidateFill(this.txtValorVenda, true);
                    }
                    else
                    {
                        if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                            e.SuppressKeyPress = true;
                        else
                            e.SuppressKeyPress = false;
                    }
                }
                else
                {
                    if (e.Modifiers == Keys.Shift || e.Modifiers == Keys.ShiftKey)
                        e.SuppressKeyPress = true;
                    else
                        e.SuppressKeyPress = false;

                }
            }
            else
            {
                if (e.KeyValue == 110 || e.KeyValue == 190)
                {
                    e.SuppressKeyPress = false;
                }
                else
                {
                    if (e.KeyValue < 96 || e.KeyValue > 105)
                        e.SuppressKeyPress = true;
                    else
                        e.SuppressKeyPress = false;
                }
            }
        }

        private void cmdGravar_Click(object sender, EventArgs e)
        {
            gravarVenda();
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            sairTela();
        }

        private void cmbVenda_SelectedValueChanged(object sender, EventArgs e)
        {
            selecionarVenda();
        }

        private void cmbVenda_Leave(object sender, EventArgs e)
        {
            lostVenda();
        }

        private void cmbVenda_Enter(object sender, EventArgs e)
        {
            limparTela(1);
        }

        private void cmdNovaComissao_Click(object sender, EventArgs e)
        {
            novaComissao();
        }

        private void novaComissao()
        {
            ComboBoxItem cmbItem = (ComboBoxItem)cmbVenda.SelectedItem;
            veiculos = new Veiculos();
            veiculos.ArquivoConexao = sArquivoConexao;
            vendas cVenda;
            if (cmbItem != null)
            {
                cVenda = veiculos.pesquisarVenda(int.Parse(cmbItem.Value.ToString()));
                vTelaPrincipal.abrirCadComissao(vTelaPrincipal, 0, cVenda, 0);
            }
            else
            {
                MessageBox.Show("Venda nova! Não é permitido a inclusão de observação antes da primeira gravação!", "EstacionamentoFacil (FrmVd13)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void novaObservacao()
        {
            ComboBoxItem cmbItem = (ComboBoxItem)cmbVenda.SelectedItem;
            veiculos = new Veiculos();
            veiculos.ArquivoConexao = sArquivoConexao;
            vendas cVenda;
            if (cmbItem != null)
            {
                cVenda = veiculos.pesquisarVenda(int.Parse(cmbItem.Value.ToString()));
                vTelaPrincipal.abrirCadObservacao(vTelaPrincipal, cVenda);
            }
            else
            {
                MessageBox.Show("Venda nova! Não é permitido a inclusão de observação antes da primeira gravação!", "EstacionamentoFacil (FrmVd14)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }

        private void excluirComissãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int iIndice = 0;
            ComboBoxItem cmbItem = (ComboBoxItem)cmbVenda.SelectedItem;
            veiculos = new Veiculos();
            veiculos.ArquivoConexao = sArquivoConexao;
            vendas cVendas;
            if (cmbItem != null)
            {
                cVendas = new vendas();
                cVendas = veiculos.pesquisarVenda(int.Parse(cmbItem.Value.ToString()));

                if (gridVendedor.Rows.Count > 0)
                {
                    iIndice = int.Parse(gridVendedor.CurrentRow.Cells[0].Value.ToString());
                    if (iIndice > 0)
                    {
                        if (MessageBox.Show("Deseja realmente excluir esta comissão?", "EstacionamentoFacil (FrmVd14)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            string sMotivo = Microsoft.VisualBasic.Interaction.InputBox("Qual o motivo da exclusão?", "Motivo da exclusão");
                            if (sMotivo.Length == 0) sMotivo = "Motivo não declarado pelo usuário " + vTelaPrincipal.vvNomeUsuario.Trim();
                            veiculos = new Veiculos();
                            veiculos.ArquivoConexao = sArquivoConexao;

                            //verificar se o usuário da exclusão é o proprietário da observação e/ou admin
                            if (vTelaPrincipal.vvNivelAcesso ==0)
                            {
                                if (veiculos.excluirComissao(cVendas.cod_venda, int.Parse(gridVendedor.CurrentRow.Cells[1].Value.ToString()), this.Name, sMotivo, vTelaPrincipal.vvCodigoUsuario))
                                {
                                    MessageBox.Show("Comissão excluída com sucesso!", "EstacionamentoFacil (FrmVd15)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    lancarComissao(cVendas);
                                }
                            }
                            else
                            {
                                MessageBox.Show("A comissão será excluída somente pelo adminsitrador do sistema!\nOperação cancelada!", "EstacionamentoFacil (FrmVd16)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Venda nova! Não é permitido a exclusão de observação antes da primeira gravação!", "EstacionamentoFacil (FrmVd17)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }//excluir comissao

        private void editarComissãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int iIndice = 0;
            ComboBoxItem cmbItem = (ComboBoxItem)cmbVenda.SelectedItem;
            veiculos = new Veiculos();
            veiculos.ArquivoConexao = sArquivoConexao;
            vendas cVendas;
            if (cmbItem != null)
            {
                cVendas = new vendas();
                cVendas = veiculos.pesquisarVenda(int.Parse(cmbItem.Value.ToString()));

                if (gridVendedor.Rows.Count > 0)
                {
                    iIndice = int.Parse(gridVendedor.CurrentRow.Cells[0].Value.ToString());
                    if (iIndice > 0)
                    {
                        if (vTelaPrincipal.vvNivelAcesso == 0)
                        {
                            int iCodVendedor = int.Parse(gridVendedor.CurrentRow.Cells[1].Value.ToString());
                            vTelaPrincipal.abrirCadComissao(vTelaPrincipal, 1, cVendas,iCodVendedor);
                        }
                        else
                        {
                            MessageBox.Show("A comissão somete será editada pelo adminsitrador do sistema!\nOperação cancelada!", "EstacionamentoFacil (FrmVd18)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Venda nova! Não é permitido a exclusão de observação antes da primeira gravação!", "EstacionamentoFacil (FrmVd19)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }//editar comissao

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int iIndice = 0;
            ComboBoxItem cmbItem = (ComboBoxItem)cmbVenda.SelectedItem;
            veiculos = new Veiculos();
            veiculos.ArquivoConexao = sArquivoConexao;
            vendas cVendas;
            if (cmbItem != null)
            {
                cVendas = veiculos.pesquisarVenda(int.Parse(cmbItem.Value.ToString()));
                if (gridObservacao.Rows.Count > 0)
                {
                    iIndice = int.Parse(gridObservacao.CurrentRow.Cells[0].Value.ToString());
                    if (iIndice > 0)
                    {
                        if (MessageBox.Show("Deseja realmente excluir esta observação?", "EstacionamentoFacil (FrmVd20)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            string sMotivo = Microsoft.VisualBasic.Interaction.InputBox("Qual o motivo da exclusão?", "Motivo da exclusão");
                            if (sMotivo.Length == 0) sMotivo = "Motivo não declarado pelo usuário " + vTelaPrincipal.vvNomeUsuario.Trim();
                            veiculos = new Veiculos();
                            veiculos.ArquivoConexao = sArquivoConexao;

                            //verificar se o usuário da exclusão é o proprietário da observação e/ou admin
                            if (vTelaPrincipal.vvNomeUsuario.ToUpper().Equals("ADMIN") || int.Parse(gridObservacao.CurrentRow.Cells[3].Value.ToString()) == vTelaPrincipal.vvCodigoUsuario)
                            {
                                if (veiculos.excluirObservacaoCarro(int.Parse(gridObservacao.CurrentRow.Cells[0].ToString()), vTelaPrincipal.vvCodigoUsuario, this.Text, sMotivo))
                                {
                                    MessageBox.Show("Observação excluída com sucesso!", "EstacionamentoFacil (FrmVd21)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    lancarObservacao(cVendas);
                                }
                            }
                            else
                            {
                                MessageBox.Show("A observação somete será excluída pelo usuário " + gridObservacao.CurrentRow.Cells[2].Value.ToString() + ".\nOperação cancelada!", "EstacionamentoFacil (FrmVd22)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Venda nova! Não é permitido a exclusão de observação antes da primeira gravação!", "EstacionamentoFacil (FrmVd23)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gridVendedor_MouseEnter(object sender, EventArgs e)
        {
            txtObservacaoTela.Text = "Clique com o botão da direita do mouse para obter mais opções!";
        }

        private void gridVendedor_MouseLeave(object sender, EventArgs e)
        {
            txtObservacaoTela.Text = "";
        }

        private void gridObservacao_MouseEnter(object sender, EventArgs e)
        {
            txtObservacaoTela.Text = "Clique com o botão da direita do mouse para obter mais opções!";
        }

        private void gridObservacao_MouseLeave(object sender, EventArgs e)
        {
            txtObservacaoTela.Text = "";
        }

        private void novaComissãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            novaComissao();
        }

        private void novaObservaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            novaObservacao();
        }

        private void cmbVeiculo_Leave(object sender, EventArgs e)
        {
            ComboBoxItem cboValores = new ComboBoxItem();
            cboValores = (ComboBoxItem)cmbVeiculo.SelectedItem;
            if (cboValores != null)
                txtModelo.Text = veiculos.pesquisarMarca(veiculos.pesquisarCarro(int.Parse(cboValores.Value.ToString())).CodMarca).descricao + " | " + veiculos.pesquisarCarro(int.Parse(cboValores.Value.ToString())).Modelo;
            else
                txtModelo.Text = "";
        }

        private void FrmCadVenda_FormClosed(object sender, FormClosedEventArgs e)
        {
            vTelaPrincipal.fecharTelasRelacionadas("CadVenda");
        }

    }
}
