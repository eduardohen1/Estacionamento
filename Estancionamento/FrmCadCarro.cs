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
    public partial class FrmCadCarro : Form
    {
        Cliente clientes;
        Veiculos veiculos;
        Enderecos endereços;
        FrmPrincipal vTelaPrincipal;
        funcoes cFuncoes;
        carro hCarro;
        string sArquivoConexao;
        TokenInputG.TokenInput cpToken;
        int iQteOpcionais;
        int iTela;
        bool bNovo;
        int iCodCarroGeral;

        public FrmCadCarro(string vArquivoConexao, FrmPrincipal vvTelaPrincipal)
        {
            InitializeComponent();
            sArquivoConexao = vArquivoConexao;            
            vTelaPrincipal = vvTelaPrincipal;
            iQteOpcionais = 0;
            iTela = 0;
        }

        public FrmCadCarro(string vArquivoConexao, FrmPrincipal vvTelaPrincipal, carro ccCarro)
        {
            InitializeComponent();
            sArquivoConexao = vArquivoConexao;
            vTelaPrincipal = vvTelaPrincipal;
            iQteOpcionais = 0;
            hCarro = ccCarro;
            iTela = 1;
        }

        private void FrmCadCarro_Load(object sender, EventArgs e)
        {
            ve_se_existe();
            cFuncoes = new funcoes();
            if (iTela == 1)
                inicioCarro(hCarro);
            bNovo = false;
            iCodCarroGeral = 0;
        }

        /// <summary>
        /// Limpar dados da tela de cadastro de carro
        /// </summary>
        /// <param name="bTipo">0 - Zerar e carregar combo de placa e marca; 1 - Limpar somente o text do campo</param>
        private void limparCampos(byte bTipo)
        {
            bNovo = false;
            switch (bTipo)
            {
                case 0:
                    //cmbPlaca.Items.Clear();
                    cmbMarca.Items.Clear();
                    iCodCarroGeral = 0;
                    break;
                case 1:
                    //cmbPlaca.Text = "";
                    cmbMarca.Text = "";                    
                    iCodCarroGeral = 0;
                    break;
            }
            txtPlaca.Clear();
            txtModelo.Clear();
            txtSerie.Clear();
            txtAnoFabr.Clear();
            txtAnoMod.Clear();
            txtCor.Clear();
            txtQtePortas.Clear();
            txtChassi.Clear();
            txtRenavan.Clear();
            txtNumMotor.Clear();
            txtLugares.Clear();
            txtPotencia.Clear();
            txtTracao.Clear();
            txtRPM.Clear();
            txtTorque.Clear();
            txtTransmissao.Clear();
            cmbSituacao.Text = "";
            pnlOpcionais.Controls.Clear();
            txtNomeCliente.Clear();

            gridHistorico.Rows.Clear();

            int vQteLinhas = gridDespesas.RowCount;
            while (vQteLinhas > 1)
            {                
                gridDespesas.Rows.RemoveAt(0);
                vQteLinhas = gridDespesas.RowCount;
            }
            
            vQteLinhas = gridObservacao.RowCount;
            while (vQteLinhas > 1)
            {
                gridObservacao.Rows.RemoveAt(0);
                vQteLinhas = gridObservacao.RowCount;
            }

            vQteLinhas = gridHistorico.RowCount;
            while (vQteLinhas > 1)
            {
                gridHistorico.Rows.RemoveAt(0);
                vQteLinhas = gridHistorico.RowCount;
            }

            txtObservacaoTela.Clear();

            txtPlaca.Enabled = false;
            button1.Text = "Novo";
            button1.Image = global::Estancionamento.Properties.Resources.plus;
            toolTip1.SetToolTip(button1, "Novo registro de veículo");
        }

        private void ve_se_existe()
        {
            limparCampos(0);
            ComboBoxItem cboItem;
            try
            {
                veiculos = new Veiculos();
                veiculos.ArquivoConexao = sArquivoConexao;
                /*
                //preencher combo carro
                List<carro> listCarro = new List<carro>();                
                listCarro = veiculos.pesquisarTodosCarros();
                foreach (carro lstCarro in listCarro)
                {
                    cboItem = new ComboBoxItem();
                    cboItem.Text = lstCarro.Placa2;
                    cboItem.Value = lstCarro.Codigo;
                    cmbPlaca.Items.Add(cboItem);
                }
                */
                //preencher combo de marca:
                List<marca> listMarca = new List<marca>();
                listMarca = veiculos.pesquisarTodasMarcas();
                foreach (marca lstMarca in listMarca)
                {
                    cboItem = new ComboBoxItem();
                    cboItem.Text = lstMarca.descricao;
                    cboItem.Value = lstMarca.codigo;
                    cmbMarca.Items.Add(cboItem);
                }

                //preencher combo situacao
                cmbSituacao.Items.Clear();
                
                cboItem = new ComboBoxItem();
                cboItem.Text = "ATIVO";
                cboItem.Value = "ATIVO";
                cmbSituacao.Items.Add(cboItem);
                
                cboItem = new ComboBoxItem();
                cboItem.Text = "EXCLUÍDO";
                cboItem.Value = "EXCLUÍDO";
                cmbSituacao.Items.Add(cboItem);

                cboItem = new ComboBoxItem();
                cboItem.Text = "HISTÓRICO";
                cboItem.Value = "HISTÓRICO";
                cmbSituacao.Items.Add(cboItem);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir janela de Veículos! " + ex.Message, "EstacionamentoFacil (FrmCar01)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Validação de tela antes de gravação
        /// </summary>
        /// <param name="bTipo">Tipo 0 - Atualização de dados 1 - Inserir novo</param>
        /// <returns>Retorna verdadeiro/falso mediante a execução de função</returns>
        private bool validaTela()
        {
            bool bResposta = true;
            /*
            if (cmbPlaca.Text.Length == 0)
            {
                bResposta = false;
                MessageBox.Show("Placa do veículo em branco. Verifique! ", "EstacionamentoFacil (FrmCar02)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
             * */
            if (bNovo)
            {
                if (txtPlaca.Text.Length == 0)
                {
                    bResposta = false;
                    MessageBox.Show("Placa do veículo em branco. Verifique! ", "EstacionamentoFacil (FrmCar02)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (cmbMarca.Text.Length == 0)
            {
                bResposta = false;
                MessageBox.Show("Selecione a marca do veículo. Verifique! ", "EstacionamentoFacil (FrmCar03)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (txtChassi.Text.Length == 0)
            {
                bResposta = false;
                MessageBox.Show("Digite o chassi do veículo! ", "EstacionamentoFacil (FrmCar04)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (txtRenavan.Text.Length == 0)
            {
                bResposta = false;
                MessageBox.Show("Digite o renavan do veículo! ", "EstacionamentoFacil (FrmCar05)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (txtNumMotor.Text.Length == 0)
            {
                bResposta = false;
                MessageBox.Show("Digite o número do motor do veículo! ", "EstacionamentoFacil (FrmCar06)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (cmbSituacao.Text.Length == 0)
            {
                bResposta = false;
                MessageBox.Show("Selecione a situação do veículo no sistema. ", "EstacionamentoFacil (FrmCar07)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if(txtAnoFabr.Text.Length == 0) txtAnoFabr.Text = "0";
            if(txtAnoMod.Text.Length == 0) txtAnoMod.Text = "0";
            if(txtQtePortas.Text.Length ==0) txtQtePortas.Text = "0";
            if(txtLugares.Text.Length == 0) txtLugares.Text = "0";
            if(txtTransmissao.Text.Length ==0) txtTransmissao.Text = "0";
            if(txtTracao.Text.Length == 0) txtTracao.Text = "0";
            if(txtPotencia.Text.Length == 0) txtPotencia.Text = "0";
            if(txtRPM.Text.Length == 0) txtRPM.Text = "0";
            if (txtTorque.Text.Length == 0) txtTorque.Text = "0";

            return bResposta;
        }

        private void sairTela()
        {
            vTelaPrincipal.fecharTelasRelacionadas("CadCarro");
            this.Close();
        }

        public void exibirDadosVeiculo(carro cCarro, byte bTipo = 0)
        {
            int iQte = 0;
            clientes = new Cliente();
            List<opicionais> listOpcionais;
            veiculos = new Veiculos();
            veiculos.ArquivoConexao = sArquivoConexao;
            clientes.ArquivoConexao = sArquivoConexao;
            limparCampos(1);
            try
            {
                bNovo = false;
                iCodCarroGeral = cCarro.Codigo;
                txtPlaca.Text = cCarro.Placa2.Trim();
                cmbMarca.Text = veiculos.pesquisarMarca(cCarro.CodMarca).descricao;
                txtModelo.Text = cCarro.Modelo.Trim();
                txtSerie.Text = cCarro.Serie;
                txtAnoFabr.Text = cCarro.AnoFab.ToString();
                txtAnoMod.Text = cCarro.AnoMod.ToString();
                txtCor.Text = cCarro.cor.Trim();
                txtQtePortas.Text = cCarro.QtdePortas.ToString();
                txtNumMotor.Text = cCarro.Num_motor.Trim();
                txtLugares.Text = cCarro.Lugares.ToString();
                txtTransmissao.Text = cCarro.Transmissao.ToString();
                txtTracao.Text = cCarro.Tracao.ToString();
                txtPotencia.Text = cCarro.Potencia.ToString();
                txtRPM.Text = cCarro.Rpm.ToString();
                txtTorque.Text = cCarro.Torque.ToString();
                txtChassi.Text = cCarro.Chassi2.Trim();
                switch (cCarro.Situacao)
                {
                    case "A":
                        cmbSituacao.Text = "ATIVO";
                        break;
                    case "E":
                        cmbSituacao.Text = "EXCLUÍDO";
                        break;
                    case "H":
                        cmbSituacao.Text = "HISTÓRICO";
                        break;
                }
                txtRenavan.Text = cCarro.Renavan2.Trim();
                int iCodClienteCarro = veiculos.buscaClienteCarro(cCarro.Codigo);
                if (iCodClienteCarro > 0)
                    txtNomeCliente.Text = clientes.pesquisarCliente(iCodClienteCarro).Nome.Trim();
                else
                    txtNomeCliente.Text = "";

                //Opcionais:
                listOpcionais = veiculos.pesquisarTodosOpicionaisCarro(cCarro.Codigo);
                if (listOpcionais != null)
                {
                    if (listOpcionais.Count > 0)
                    {
                        iQte = 0;
                        foreach (opicionais lstOpcional in listOpcionais)
                        {
                            cpToken = new TokenInputG.TokenInput(vTelaPrincipal);
                            cpToken.Name = "tokenO_" + iQte.ToString();
                            cpToken.Nome = lstOpcional.descricao.Trim();
                            cpToken.Indice = lstOpcional.codigo.ToString() + "#A";
                            cpToken.Texto = lstOpcional.descricao.Trim();
                            cpToken.ExibirLink = false;
                            cpToken.Link = "";
                            cpToken.textoLink = "";
                            cpToken.ajustarDadosTela();
                            pnlOpcionais.Controls.Add(cpToken);
                            iQte++;
                        }
                        iQteOpcionais = iQte;
                    }
                }

                //Histórico:
                lancarHistorico(cCarro);

                //Despesas:
                lancarDespesas(cCarro);

                //observação:
                lancarObservcao(cCarro);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar dados do veículo! " + ex.Message, "EstacionamentoFacil (FrmCar12)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (bTipo == 1) cmbMarca.Focus();

        }//exibir dados do veículo

        private void gravar()
        {            
            ComboBoxItem cmbItem2;
            carro cCarro = new carro();
            bool bErro = false;
            veiculos = new Veiculos();
            veiculos.ArquivoConexao = sArquivoConexao;

            if (validaTela())
            {                
                if (!bNovo)
                {
                    if (iCodCarroGeral > 0)
                    {
                        cCarro.Codigo = iCodCarroGeral;
                        cmbItem2 = (ComboBoxItem)cmbMarca.SelectedItem;
                        cCarro.CodMarca = int.Parse(cmbItem2.Value.ToString());
                        cCarro.Modelo = txtModelo.Text;
                        cCarro.Serie = txtSerie.Text;
                        cCarro.AnoFab = int.Parse(txtAnoFabr.Text);
                        cCarro.AnoMod = int.Parse(txtAnoMod.Text);
                        cCarro.cor = txtCor.Text;
                        cCarro.QtdePortas = int.Parse(txtQtePortas.Text);
                        cCarro.Num_motor = txtNumMotor.Text;
                        cCarro.Lugares = int.Parse(txtLugares.Text);
                        cCarro.Transmissao = int.Parse(txtTransmissao.Text);
                        cCarro.Tracao = int.Parse(txtTracao.Text);
                        cCarro.Potencia = int.Parse(txtPotencia.Text);
                        cCarro.Rpm = int.Parse(txtRPM.Text);
                        cCarro.Torque = int.Parse(txtTorque.Text);
                        cCarro.Chassi2 = txtChassi.Text;
                        cmbItem2 = (ComboBoxItem)cmbSituacao.SelectedItem;
                        switch (cmbItem2.Text)
                        {
                            case "ATIVO":
                                cCarro.Situacao = "A";
                                break;
                            case "EXCLUÍDO":
                                cCarro.Situacao = "E";
                                break;
                            case "HISTÓRICO":
                                cCarro.Situacao = "H";
                                break;
                        }
                        cCarro.Renavan2 = txtRenavan.Text;
                        cCarro.Placa = cCarro.Codigo;
                        cCarro.Chassi = 0;
                        cCarro.Renavan = 0;
                        cCarro.Procedencia = 0;
                        cCarro.Configuracao = 0;
                        cCarro.Placa2 = txtPlaca.Text.Trim();//cmbItem.Text.Trim();
                        if (veiculos.gravarCarros(cCarro, 1).Equals("T"))
                        {
                            //gravar opcionais
                            if (pnlOpcionais.Controls.Count > 0)
                            {
                                opicionais cOpcionais;
                                List<opicionais> lstOpcionais = new List<opicionais>();
                                foreach (TokenInputG.TokenInput cToken in pnlOpcionais.Controls)
                                {
                                    if (!cToken.Excluir)
                                    {
                                        string[] sCodOpcional = cToken.Indice.Split('#');
                                        cOpcionais = new opicionais();
                                        if (sCodOpcional[1].Equals("N"))
                                        {
                                            cOpcionais.codigo = int.Parse(sCodOpcional[0].ToString());
                                            cOpcionais.descricao = cToken.Texto;
                                            lstOpcionais.Add(cOpcionais);
                                        }
                                    }
                                    else
                                    {
                                        string[] sCodOpcional = cToken.Indice.Split('#');
                                        if (sCodOpcional[1].Equals("A"))
                                            veiculos.excluirOpcionalCarro(int.Parse(sCodOpcional[0]), 0);
                                    }
                                }
                                if (lstOpcionais.Count > 0)
                                {
                                    if (!veiculos.gravarOpcionalCarro(lstOpcionais, cCarro))
                                    {
                                        MessageBox.Show("Opcional(is) deste veículo não atualizado!", "EstacionamentoFacil (FrmCar13)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        bErro = true;
                                    }
                                }
                            }
                            else
                            {
                                //excluir todos os opcionais deste carro
                                veiculos.excluirOpcionalCarro(cCarro.Codigo, 1);
                            }
                            if (!bErro)
                                MessageBox.Show("Veículo atualizado com sucesso!", "EstacionamentoFacil (FrmCar14)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ve_se_existe();
                        }//if (veiculos.gravarCarros(cCarro, 1).Equals("T"))
                    }else
                        MessageBox.Show("Nenhum registro a ser atualizado. Localize primeiramente o veículo.", "EstacionamentoFacil (FrmCar14b)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }//!bNovo
                else
                {
                    //Novo
                    cCarro.Codigo = 0;
                    cmbItem2 = (ComboBoxItem)cmbMarca.SelectedItem;
                    cCarro.CodMarca = int.Parse(cmbItem2.Value.ToString());
                    cCarro.Modelo = txtModelo.Text;
                    cCarro.Serie = txtSerie.Text;
                    cCarro.AnoFab = int.Parse(txtAnoFabr.Text);
                    cCarro.AnoMod = int.Parse(txtAnoMod.Text);
                    cCarro.cor = txtCor.Text;
                    cCarro.QtdePortas = int.Parse(txtQtePortas.Text);
                    cCarro.Num_motor = txtNumMotor.Text;
                    cCarro.Lugares = int.Parse(txtLugares.Text);
                    cCarro.Transmissao = int.Parse(txtTransmissao.Text);
                    cCarro.Tracao = int.Parse(txtTracao.Text);
                    cCarro.Potencia = int.Parse(txtPotencia.Text);
                    cCarro.Rpm = int.Parse(txtRPM.Text);
                    cCarro.Torque = int.Parse(txtTorque.Text);
                    cCarro.Chassi2 = txtChassi.Text;
                    cmbItem2 = new ComboBoxItem();
                    cmbItem2 = (ComboBoxItem)cmbSituacao.SelectedItem;
                    switch (cmbItem2.Text)
                    {
                        case "ATIVO":
                            cCarro.Situacao = "A";
                            break;
                        case "EXCLUÍDO":
                            cCarro.Situacao = "E";
                            break;
                        case "HISTÓRICO":
                            cCarro.Situacao = "H";
                            break;
                    }
                    cCarro.Renavan2 = txtRenavan.Text;
                    cCarro.Placa = cCarro.Codigo;
                    cCarro.Chassi = 0;
                    cCarro.Renavan = 0;
                    cCarro.Procedencia = 0;
                    cCarro.Configuracao = 0;
                    cCarro.Placa2 = txtPlaca.Text.Trim().ToUpper();
                    string sResposta = veiculos.gravarCarros(cCarro, 0);
                    if (cFuncoes.isNumeric(sResposta))
                    {
                        cCarro.Codigo = int.Parse(sResposta);
                        //gravar opcionais
                        if (pnlOpcionais.Controls.Count > 0)
                        {
                            opicionais cOpcionais;
                            List<opicionais> lstOpcionais = new List<opicionais>();
                            foreach (TokenInputG.TokenInput cToken in pnlOpcionais.Controls)
                            {
                                if (!cToken.Excluir)
                                {
                                    string[] sCodOpcional = cToken.Indice.Split('#');
                                    cOpcionais = new opicionais();
                                    if (sCodOpcional[1].Equals("N"))
                                        cOpcionais.codigo = 0;
                                    else
                                        cOpcionais.codigo = int.Parse(sCodOpcional[0]);
                                    cOpcionais.descricao = cToken.Texto;
                                    lstOpcionais.Add(cOpcionais);
                                }
                                else
                                {
                                    string[] sCodOpcional = cToken.Indice.Split('#');
                                    if (sCodOpcional[1].Equals("A"))
                                        veiculos.excluirOpcionalCarro(int.Parse(sCodOpcional[0]), 0);
                                }
                            }
                            if (!veiculos.gravarOpcionalCarro(lstOpcionais, cCarro))
                            {
                                MessageBox.Show("Opcional(s) deste veículo não atualizado!", "EstacionamentoFacil (FrmCar15)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                bErro = true;
                            }
                        }
                        else
                        {
                            //excluir todos os opcionais deste carro
                            veiculos.excluirOpcionalCarro(cCarro.Codigo, 1);
                        }
                    }
                    if (!bErro)
                    {
                        //gravar Historico:
                        MessageBox.Show("Veículo novo!!!\nAtenção. Cadastro obrigatório!!!\n\nSerá necessário inserir um primeiro histórico deste veículo.", "EstacionamentoFacil (FrmCar40)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        novoHistorico(cCarro, true);
                        MessageBox.Show("Veículo inserido com sucesso!", "EstacionamentoFacil (FrmCar16)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    ve_se_existe();
                }//else Novo
            }//valida tela
        }//gravar
        
        /*
        private void selecionaPlaca()
        {
            ComboBoxItem cmbItem = new ComboBoxItem();
            cmbItem = (ComboBoxItem)cmbPlaca.SelectedItem;
            veiculos = new Veiculos();
            veiculos.ArquivoConexao = sArquivoConexao;
            carro cCarro = veiculos.pesquisarCarro(int.Parse(cmbItem.Value.ToString()));
            exibirDadosVeiculo(cCarro);
        }//selecionaPlaca
        

        private void lostPlaca()
        {
            //limparCampos(1);
            if (cmbPlaca.Text.Length > 0)
            {
                ComboBoxItem cmbItem = new ComboBoxItem();
                cmbItem = (ComboBoxItem)cmbPlaca.SelectedItem;
                if (cmbItem != null)
                {
                    veiculos = new Veiculos();
                    veiculos.ArquivoConexao = sArquivoConexao;
                    carro cCarro = veiculos.pesquisarCarro(int.Parse(cmbItem.Value.ToString()));
                    exibirDadosVeiculo(cCarro);
                }
            }
        }//lostPlaca
        */

        private void sairCarro()
        {
            this.Close();
        }//sairCarro

        /// <summary>
        /// Função para lançar dados de observação
        /// </summary>
        /// <param name="cCarro">Objeto Carro</param>
        public void lancarObservcao(carro cCarro)
        {
            DataGridViewRow row;
            gridObservacao.Rows.Clear();
            veiculos.ArquivoConexao = sArquivoConexao;
            List<observacao> lstObservacao = veiculos.buscarObservacaoCarro(cCarro.Codigo);
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
        }

        /// <summary>
        /// Função para lançar dados de despesas
        /// </summary>
        /// <param name="cCarro">Objeto Carro</param>
        public void lancarDespesas(carro cCarro)
        {
            DataGridViewRow row;
            gridDespesas.Rows.Clear();
            veiculos.ArquivoConexao = sArquivoConexao;
            List<despesas> lstDespesas = veiculos.buscaDespesasCarro(cCarro);
            if (lstDespesas != null)
            {
                if (lstDespesas.Count > 0)
                {
                    row = new DataGridViewRow();
                    foreach (despesas cDespesas in lstDespesas)
                    {
                        gridDespesas.AllowUserToAddRows = true;
                        row = (DataGridViewRow)gridDespesas.Rows[0].Clone();
                        gridDespesas.AllowUserToAddRows = false;
                        row.Cells[0].Value = cDespesas.codigo.ToString();
                        row.Cells[1].Value = cDespesas.Descrição.Trim();
                        row.Cells[2].Value = cDespesas.Num_nota.ToString();
                        row.Cells[3].Value = cDespesas.Data.ToShortDateString();
                        row.Cells[4].Value = cDespesas.Valor.ToString("C");
                        gridDespesas.Rows.Add(row);
                    }
                    txtTotalDespesas.Text = veiculos.pesquisaValorDespesaCarro(cCarro.Codigo).ToString("C");
                }
            }
        }

        /// <summary>
        /// Função para lançar linha de histórico na tabela
        /// </summary>
        /// <param name="cCarro">Objeto Carro preenchido</param>
        public void lancarHistorico(carro cCarro)
        {
            DataGridViewRow row;
            veiculos.ArquivoConexao = sArquivoConexao;
            List<historico> lstHistorico = veiculos.consultarHistoricoCarro(cCarro.Codigo);
            gridHistorico.Rows.Clear();
            if (lstHistorico != null)
            {
                if (lstHistorico.Count > 0)
                {
                    string sTipoHistorico = "";
                    row = new DataGridViewRow();
                    foreach (historico cHistorico in lstHistorico)
                    {
                        switch (cHistorico.tipo)
                        {
                            case 0:
                                sTipoHistorico = "COMPRA";
                                break;
                            case 1:
                                sTipoHistorico = "VENDA";
                                break;
                            case 2:
                                sTipoHistorico = "ENTRADA ESTANCIONAMENTO";
                                break;
                            case 3:
                                sTipoHistorico = "SAÍDA ESTANCIONAMENTO";
                                break;
                            case 4:
                                sTipoHistorico = "OBSERVAÇÃO";
                                break;
                        }
                        gridHistorico.AllowUserToAddRows = true;
                        row = (DataGridViewRow)gridHistorico.Rows[0].Clone();
                        gridHistorico.AllowUserToAddRows = false;
                        row.Cells[0].Value = cHistorico.cod_historico.ToString();
                        row.Cells[1].Value = cHistorico.data_hist.ToString("dd/MM/yyyy HH:mm:ss");
                        row.Cells[2].Value = sTipoHistorico;
                        row.Cells[3].Value = veiculos.buscaDadosUsuario(cHistorico.cod_usuario).nomeusuario.Trim();
                        row.Cells[4].Value = cHistorico.observacao;
                        row.Cells[5].Value = cHistorico.tipo.ToString();
                        gridHistorico.Rows.Add(row);
                    }
                }
            }
        }

        /// <summary>
        /// Lançar opcional para Cadastro de veículo
        /// </summary>
        /// <param name="cOpcional">Objeto Opcional para lançamento</param>
        public void lancarOpcional(opicionais cOpcional, string sTipo)
        {
            iQteOpcionais++;
            cpToken = new TokenInputG.TokenInput(vTelaPrincipal);
            cpToken.Name = "tokenO_" + iQteOpcionais.ToString();
            cpToken.Nome = cOpcional.descricao.Trim();
            cpToken.Indice = cOpcional.codigo.ToString() + "#" + sTipo;
            cpToken.Texto = cOpcional.descricao.Trim();
            cpToken.ExibirLink = false;
            cpToken.Link = "";
            cpToken.textoLink = "";
            cpToken.ajustarDadosTela();
            pnlOpcionais.Controls.Add(cpToken);            
        }//larncarOpcional

        public void inicioCarro(carro cCarro)
        {
            //cmbPlaca.Text = cCarro.Placa2.Trim();
            txtPlaca.Text = cCarro.Placa2.Trim();
            cmbMarca.Focus();
            exibirDadosVeiculo(cCarro);
            cmdGravar.Enabled = false;
            cmdLocalizar.Enabled = false;
            button1.Enabled = false;
        }

        private string buscaCodigosOpcionais()
        {
            string sResposta = "";
            if (pnlOpcionais.Controls.Count > 0)
            {
                foreach (TokenInputG.TokenInput cToken in pnlOpcionais.Controls)
                {
                    string[] sIndice = cToken.Indice.Split('#');
                    if (sResposta.Trim().Length > 0)
                        sResposta += ", ";
                    sResposta += sIndice[0];
                }
            }
            return sResposta;
        }//buscaCodigosOpcionais

        private void adicionarOpcional()
        {
            if (!bNovo) {
            /*ComboBoxItem cmbItem = (ComboBoxItem)cmbPlaca.SelectedItem;
            if (cmbItem != null)
            {*/
                veiculos = new Veiculos();
                veiculos.ArquivoConexao = sArquivoConexao;
                carro cCarro;            
                cCarro = veiculos.pesquisarCarro(iCodCarroGeral);
                vTelaPrincipal.abrirNovoOpcional(vTelaPrincipal, buscaCodigosOpcionais(), cCarro);
            }
            else
            {
                MessageBox.Show("Veículo novo! Não é permitido a inclusão de opcional antes da 1ª gravação!", "EstacionamentoFacil (FrmCar17)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void novoHistorico(carro ccCarro, bool bNovoCarro)
        {
            vTelaPrincipal.abrirCadHistorico(vTelaPrincipal, ccCarro, bNovoCarro);
        }

        private void cmdGravar_Click(object sender, EventArgs e)
        {
            gravar();
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            sairTela();
        }

        private void cmbPlaca_SelectedValueChanged(object sender, EventArgs e)
        {
            //selecionaPlaca();
            //cmbMarca.Focus();
        }

        private void cmbPlaca_Leave(object sender, EventArgs e)
        {
            //lostPlaca();
        }

        private void cmbPlaca_Enter(object sender, EventArgs e)
        {
            limparCampos(1);
        }

        private void cmdNovoOpcional_Click(object sender, EventArgs e)
        {
            adicionarOpcional();
        }

        private void cmdNovoHistorico_Click(object sender, EventArgs e)
        {
            //ComboBoxItem cmbItem = (ComboBoxItem)cmbPlaca.SelectedItem;
            if(!bNovo)
            {
                veiculos = new Veiculos();
                veiculos.ArquivoConexao = sArquivoConexao;
                carro cCarro;
            //if (cmbItem != null)
            //{
                cCarro = veiculos.pesquisarCarro(iCodCarroGeral);
                novoHistorico(cCarro, false);
            }
            else
            {
                MessageBox.Show("Veículo novo! Não é permitido a inclusão de histórico antes da primeira gravação!", "EstacionamentoFacil (FrmCar41)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
        }

        private void cmdNovaDespesa_Click(object sender, EventArgs e)
        {
            if(!bNovo){
            //ComboBoxItem cmbItem = (ComboBoxItem)cmbPlaca.SelectedItem;
                veiculos = new Veiculos();
                veiculos.ArquivoConexao = sArquivoConexao;
                carro cCarro;
            //if (cmbItem != null)
            //{
                cCarro = veiculos.pesquisarCarro(iCodCarroGeral);
                vTelaPrincipal.abrirCadDespesa(vTelaPrincipal, cCarro,false);                
            }
            else
            {
                MessageBox.Show("Veículo novo! Não é permitido a inclusão de despesa antes da primeira gravação!", "EstacionamentoFacil (FrmCar42)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }

        private void excluirDespesaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int iIndice = 0;
            //ComboBoxItem cmbItem = (ComboBoxItem)cmbPlaca.SelectedItem;
            veiculos = new Veiculos();
            veiculos.ArquivoConexao = sArquivoConexao;
            carro cCarro;
            //if (cmbItem != null)
            if(!bNovo)
            {
                cCarro = veiculos.pesquisarCarro(iCodCarroGeral);
                if (gridDespesas.Rows.Count > 0)
                {
                    iIndice = int.Parse(gridDespesas.CurrentRow.Cells[0].Value.ToString());
                    if (iIndice > 0)
                    {
                        if (MessageBox.Show("Deseja realmente excluir esta despesa?", "EstacionamentoFacil (FrmCar43)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            string sMotivo = Microsoft.VisualBasic.Interaction.InputBox("Qual o motivo da exclusão?", "Motivo da exclusão");
                            if (sMotivo.Length == 0) sMotivo = "Motivo não declarado pelo usuário " + vTelaPrincipal.vvNomeUsuario.Trim();
                            veiculos = new Veiculos();
                            veiculos.ArquivoConexao = sArquivoConexao;                            
                            if (veiculos.excluirDespesa(int.Parse(gridDespesas.CurrentRow.Cells[0].Value.ToString()), this.Text, vTelaPrincipal.vvCodigoUsuario,sMotivo))
                            {
                                MessageBox.Show("Despesa excluída com sucesso!", "EstacionamentoFacil (FrmCar44)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                lancarDespesas(cCarro);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Veículo novo! Não é permitido a exclusão de despesa antes da primeira gravação!", "EstacionamentoFacil (FrmCar45)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int iIndice = 0;
            //ComboBoxItem cmbItem = (ComboBoxItem)cmbPlaca.SelectedItem;
            veiculos = new Veiculos();
            veiculos.ArquivoConexao = sArquivoConexao;
            carro cCarro;
            //if (cmbItem != null)
            if(!bNovo)
            {
                cCarro = veiculos.pesquisarCarro(iCodCarroGeral);
                if (gridObservacao.Rows.Count > 0)
                {
                    iIndice = int.Parse(gridObservacao.CurrentRow.Cells[0].Value.ToString());
                    if (iIndice > 0)
                    {
                        if (MessageBox.Show("Deseja realmente excluir esta observação?", "EstacionamentoFacil (FrmCar46)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            string sMotivo = Microsoft.VisualBasic.Interaction.InputBox("Qual o motivo da exclusão?", "Motivo da exclusão");
                            if (sMotivo.Length == 0) sMotivo = "Motivo não declarado pelo usuário " + vTelaPrincipal.vvNomeUsuario.Trim();
                            veiculos = new Veiculos();
                            veiculos.ArquivoConexao = sArquivoConexao;
                            
                            //verificar se o usuário da exclusão é o proprietário da observação e/ou admin
                            if (vTelaPrincipal.vvNomeUsuario.ToUpper().Equals("ADMIN") || int.Parse(gridObservacao.CurrentRow.Cells[3].Value.ToString()) == vTelaPrincipal.vvCodigoUsuario)
                            {
                                if (veiculos.excluirObservacaoCarro(int.Parse(gridObservacao.CurrentRow.Cells[0].ToString()), vTelaPrincipal.vvCodigoUsuario, this.Text,sMotivo))
                                {
                                    MessageBox.Show("Observação excluída com sucesso!", "EstacionamentoFacil (FrmCar47)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    lancarObservcao(cCarro);
                                }
                            }
                            else
                            {
                                MessageBox.Show("A observação somete será excluída pelo usuário " + gridObservacao.CurrentRow.Cells[2].Value.ToString() + ".\nOperação cancelada!", "EstacionamentoFacil (FrmCar48)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Veículo novo! Não é permitido a exclusão de observação antes da primeira gravação!", "EstacionamentoFacil (FrmCar49)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmdNovaObservacao_Click(object sender, EventArgs e)
        {
            //ComboBoxItem cmbItem = (ComboBoxItem)cmbPlaca.SelectedItem;
            veiculos = new Veiculos();
            veiculos.ArquivoConexao = sArquivoConexao;
            carro cCarro;
            //if (cmbItem != null)
            if(!bNovo)
            {
                cCarro = veiculos.pesquisarCarro(iCodCarroGeral);
                vTelaPrincipal.abrirCadObservacao(vTelaPrincipal, cCarro);
            }
            else
            {
                MessageBox.Show("Veículo novo! Não é permitido a inclusão de observação antes da primeira gravação!", "EstacionamentoFacil (FrmCar50)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int iIndice = 0;
            //ComboBoxItem cmbItem = (ComboBoxItem)cmbPlaca.SelectedItem;
            veiculos = new Veiculos();
            veiculos.ArquivoConexao = sArquivoConexao;
            carro cCarro;
            //if (cmbItem != null)
            if(!bNovo)
            {
                cCarro = veiculos.pesquisarCarro(iCodCarroGeral);
                if (gridHistorico.Rows.Count > 0)
                {
                    iIndice = int.Parse(gridHistorico.CurrentRow.Cells[0].Value.ToString());
                    if (iIndice > 0)
                    {
                        if (MessageBox.Show("Deseja realmente excluir este histórico?", "EstacionamentoFacil (FrmCar51)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            string sMotivo = Microsoft.VisualBasic.Interaction.InputBox("Qual o motivo da exclusão?", "Motivo da exclusão");
                            if (sMotivo.Length == 0) sMotivo = "Motivo não declarado pelo usuário " + vTelaPrincipal.vvNomeUsuario.Trim();
                            veiculos = new Veiculos();
                            veiculos.ArquivoConexao = sArquivoConexao;

                            //verificar se o usuário da exclusão administrador
                            if (vTelaPrincipal.vvNivelAcesso ==0)
                            {
                                if (veiculos.excluirHistorico(int.Parse(gridHistorico.CurrentRow.Cells[0].Value.ToString()), vTelaPrincipal.vvCodigoUsuario, sMotivo, this.Text))
                                {
                                    MessageBox.Show("Histórico excluído com sucesso!", "EstacionamentoFacil (FrmCar52)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    lancarHistorico(cCarro);
                                }
                            }
                            else
                            {
                                MessageBox.Show("O histórico somete será excluído por administradores do sistema.\nOperação cancelada!", "EstacionamentoFacil (FrmCar53)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Veículo novo! Não é permitido a exclusão de histórico antes da primeira gravação!", "EstacionamentoFacil (FrmCar54)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FrmCadCarro_FormClosed(object sender, FormClosedEventArgs e)
        {
            vTelaPrincipal.fecharTelasRelacionadas("CadCarro");
        }

        //55
        private void detalhamentoDeHistóricoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int iIndice = 0;
            //ComboBoxItem cmbItem = (ComboBoxItem)cmbPlaca.SelectedItem;
            veiculos = new Veiculos();
            veiculos.ArquivoConexao = sArquivoConexao;
            carro cCarro;
            //if (cmbItem != null)
            if(!bNovo)
            {
                cCarro = veiculos.pesquisarCarro(iCodCarroGeral);
                if (gridHistorico.Rows.Count > 0)
                {
                    iIndice = int.Parse(gridHistorico.CurrentRow.Cells[0].Value.ToString());
                    if (iIndice > 0)
                    {
                        if (int.Parse(gridHistorico.CurrentRow.Cells[5].Value.ToString()) < 3)
                        {
                            string sObservacao = gridHistorico.CurrentRow.Cells[4].Value.ToString();
                            int iPosicao = sObservacao.IndexOf('#');
                            if (iPosicao > 0)
                            {
                                vendas cVenda = new vendas();
                                sObservacao = sObservacao.Substring(iPosicao + 1, 5);
                                cVenda = veiculos.pesquisarVenda(int.Parse(sObservacao));                                
                                vTelaPrincipal.abrirCadVendas(vTelaPrincipal, 1, cVenda);
                            }else
                                MessageBox.Show("Detalhamento de histórico somente para Vendas e Compras!", "EstacionamentoFacil (FrmCar55b)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Detalhamento de histórico somente para Vendas e Compras!", "EstacionamentoFacil (FrmCar55)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Veículo novo! Não é permitido a exclusão de histórico antes da primeira gravação!", "EstacionamentoFacil (FrmCar56)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void exibirMensagem(byte bTipo)
        {
            switch (bTipo)
            {
                case 0:
                    txtObservacaoTela.Text = "Clique com o botão da direita do mouse para obter mais opções!";
                    break;
                case 1:
                    txtObservacaoTela.Clear();
                    break;
            }
        }

        private void gridHistorico_MouseEnter(object sender, EventArgs e)
        {
            exibirMensagem(0);
        }

        private void gridHistorico_MouseLeave(object sender, EventArgs e)
        {
            exibirMensagem(1);
        }

        private void gridDespesas_MouseEnter(object sender, EventArgs e)
        {
            exibirMensagem(0);
        }

        private void cmbPlaca_MouseEnter(object sender, EventArgs e)
        {
            /*ComboBoxItem cmbItem = (ComboBoxItem)cmbPlaca.SelectedItem;
            if (cmbItem != null)
            {
                exibirMensagem(0);
            }*/
        }

        private void cmbPlaca_MouseLeave(object sender, EventArgs e)
        {
            exibirMensagem(1);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            //ComboBoxItem cmbItem = (ComboBoxItem)cmbPlaca.SelectedItem;
            //if (cmbItem != null)
            if(!bNovo)
            {
                veiculos = new Veiculos();
                veiculos.ArquivoConexao = sArquivoConexao;
                carro cCarro;
                string sPlaca = Microsoft.VisualBasic.Interaction.InputBox("Qual a nova placa?", "Nova placa",txtPlaca.Text.Trim());
                if (sPlaca.Trim().Length != 0)
                {
                    cCarro = veiculos.pesquisarCarro(iCodCarroGeral);
                    cCarro.Placa2 = sPlaca.Trim();
                    if (veiculos.gravarCarros(cCarro, 1).Equals("T"))
                    {
                        MessageBox.Show("Placa alterada com sucesso!", "EstacionamentoFacil (FrmCar57)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ve_se_existe();
                        exibirDadosVeiculo(cCarro,1);
                    }
                }

            }
            else
            {
                MessageBox.Show("Alteração somente para cadastros já gravados!", "EstacionamentoFacil (FrmCar58)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmdLocalizar_Click(object sender, EventArgs e)
        {
            limparCampos(1);
            vTelaPrincipal.abrirLocalizarVeiculo(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.Equals("Novo"))
            {
                limparCampos(1);
                txtPlaca.Enabled = true;
                bNovo = true;                
                txtPlaca.Focus();

                button1.Text = "Cancelar";
                button1.Image = global::Estancionamento.Properties.Resources.cancel;
                toolTip1.SetToolTip(button1, "Cancelar novo registro de veículo");
            }
            else 
            {
                limparCampos(1);
            }
        }

        private void txtAnoFabr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8)
                if (!char.IsDigit(e.KeyChar))
                    e.Handled = true;
        }

        private void txtAnoMod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8)
                if (!char.IsDigit(e.KeyChar))
                    e.Handled = true;
        }

        private void txtQtePortas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8)
                if (!char.IsDigit(e.KeyChar))
                    e.Handled = true;
        }

        private void txtLugares_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8)
                if (!char.IsDigit(e.KeyChar))
                    e.Handled = true;
        }

        private void txtTransmissao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8)
                if (!char.IsDigit(e.KeyChar))
                    e.Handled = true;
        }

        private void txtTracao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8)
                if (!char.IsDigit(e.KeyChar))
                    e.Handled = true;
        }

        private void txtPotencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8)
                if (!char.IsDigit(e.KeyChar))
                    e.Handled = true;
        }

        private void txtRPM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8)
                if (!char.IsDigit(e.KeyChar))
                    e.Handled = true;
        }

        private void txtTorque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8)
                if (!char.IsDigit(e.KeyChar))
                    e.Handled = true;
        }
        

    }
}
