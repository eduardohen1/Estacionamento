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
    public partial class FrmCadCliente : Form
    {

        Cliente clientes;
        Veiculos veiculos;
        Enderecos enderecos;
        FrmPrincipal vTelaPrincipal;
        string sArquivoConexao;
        int iQteTelefones;
        int iQteCarros;
        bool bNovo;
        int iCodigoCliente;
        TokenInputG.TokenInput cpToken;

        public FrmCadCliente(string vArquivoConexao, FrmPrincipal vvTelaPrincipal)
        {
            InitializeComponent();
            sArquivoConexao = vArquivoConexao;
            iQteTelefones = 0;
            vTelaPrincipal = vvTelaPrincipal;
        }

        private void FrmCadCliente_Load(object sender, EventArgs e)
        {
            ve_se_existe();
            txtObservacaoTela.Clear();
        }

        private void limparCampos()
        {
            txtNome.Clear();
            txtCPF.Clear();
            txtRG.Clear();
            txtEmail.Clear();
            cmbLogradouro.Text = "";
            txtNumero.Clear();
            txtObservacao.Clear();
            pnlVeiculos.Controls.Clear();
            pnlTelefones.Controls.Clear();

            iCodigoCliente = 0;
            button2.Text = "Novo";
            button2.Image = global::Estancionamento.Properties.Resources.plus;
            toolTip1.SetToolTip(button2, "Novo registro de cliente");
            
            cmbLogradouro.SelectedIndex = -1;
            cmbMunicipio.SelectedIndex = -1;
            cmbLocalidade.SelectedIndex = -1;
            cmbBairro.SelectedIndex = -1;

            cmbTipoPessoa.SelectedIndex = -1;
            txtDtNascimento.Text = "";
            txtDataCadastro.Text = "";
            cmbSexo.SelectedIndex = -1;
            txtProfissao.Clear();
            txtEstadoCivil.Clear();
            cmbFaixaSalarial.SelectedIndex = -1;
            txtCNH.Clear();
            txtValidadeCNH.Text = "";
            txtCategoriaCNH.Clear();
            txtPrimeiraHabilitacaoCNH.Text = "";
            txtDtRenovacaoSeguro.Text = "";
            cmbStatus.SelectedIndex = -1;

            cmbLocalidade.Enabled = false;
            cmbBairro.Enabled = false;
            cmbLogradouro.Enabled = false;

        }

        private void ve_se_existe()
        {
            string[] sCampos;
            limparCampos();
            ComboBoxItem cboItem;
            try
            {
                //buscar dados do cliente:
                //List<cliente> listCliente = new List<cliente>();                
                clientes = new Cliente();
                clientes.ArquivoConexao = sArquivoConexao;
                /*listCliente = clientes.pesquisarTodosClientes();
                foreach (cliente lstCliente in listCliente)
                {
                    cboItem = new ComboBoxItem();
                    cboItem.Text = lstCliente.Nome;
                    cboItem.Value = lstCliente.Codigo;
                    cmbNome.Items.Add(cboItem);
                }
                 * */

                //buscar dados do logradouro:
                List<Logradouro> listLogradouro = new List<Logradouro>();
                enderecos = new Enderecos();
                enderecos.ArquivoConexao = sArquivoConexao;
                listLogradouro = enderecos.pesquisarTodosLogradouro();
                foreach (Logradouro lstLogradouro in listLogradouro)
                {
                    cboItem = new ComboBoxItem();
                    cboItem.Text = lstLogradouro.Nome_logradouro;
                    cboItem.Value = lstLogradouro.Codigo;
                    cmbLogradouro.Items.Add(cboItem);
                }
                listarMunicipio();
                txtObservacaoTela.Clear();
                gridHistorico.Rows.Clear();
                gridObservacao.Rows.Clear();
                gridContaCartao.Rows.Clear();

                //TIPO PESSOA
                cmbTipoPessoa.Items.Clear();
                cboItem = new ComboBoxItem();
                cboItem.Text = "FÍSICA";
                cboItem.Value = 0;
                cmbTipoPessoa.Items.Add(cboItem);

                cboItem = new ComboBoxItem();
                cboItem.Text = "JURÍDICA";
                cboItem.Value = 1;
                cmbTipoPessoa.Items.Add(cboItem);

                //SEXO
                cmbSexo.Items.Clear();
                cboItem = new ComboBoxItem();
                cboItem.Text = "MASCULINO";
                cboItem.Value = 0;
                cmbSexo.Items.Add(cboItem);

                cboItem = new ComboBoxItem();
                cboItem.Text = "FEMININO";
                cboItem.Value = 1;
                cmbSexo.Items.Add(cboItem);

                //FAIXA SALARIAL
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

                //status
                cmbStatus.Items.Clear();
                cboItem = new ComboBoxItem();
                cboItem.Text = "ATIVO";
                cboItem.Value = 0;
                cmbStatus.Items.Add(cboItem);

                cboItem = new ComboBoxItem();
                cboItem.Text = "INATIVO";
                cboItem.Value = 1;
                cmbStatus.Items.Add(cboItem);

                cboItem = new ComboBoxItem();
                cboItem.Text = "CANCELADO";
                cboItem.Value = 2;
                cmbStatus.Items.Add(cboItem);

                cboItem = new ComboBoxItem();
                cboItem.Text = "POTENCIAL";
                cboItem.Value = 3;
                cmbStatus.Items.Add(cboItem);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir janela de clientes! " + ex.Message, "EstacionamentoFacil (FrmCl01)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//ve_se_existe

        private bool validaTela()
        {
            bool bResposta = true;
            if (bNovo)
            {
                if (txtNome.Text.Length == 0)
                {
                    bResposta = false;
                    MessageBox.Show("Nome do Cliente em branco. Verifique! ", "EstacionamentoFacil (FrmCl02)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (iCodigoCliente == 0)
                {
                    bResposta = false;
                    if (MessageBox.Show("Nenhum cliente selecionado!!!\nDeseja gravar os dados como novo cliente?", "EstacionamentoFacil (FrmCl02b)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        bResposta = true;
                        bNovo = true;
                        if (txtNome.Text.Length == 0)
                        {
                            bResposta = false;
                            MessageBox.Show("Nome do Cliente em branco. Verifique! ", "EstacionamentoFacil (FrmCl02b)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            if (txtCPF.Text.Length == 0 && bResposta)
            {
                bResposta = false;
                MessageBox.Show("CPF do Cliente em branco. Verifique! ", "EstacionamentoFacil (FrmCl03)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (cmbLogradouro.Text.Length == 0 && bResposta)
            {
                bResposta = false;
                MessageBox.Show("Selecione o Endereço do Cliente.", "EstacionamentoFacil (FrmCl04)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return bResposta;
        }// validaTela

        private string buscaLogradouro(int iCodigoLogradouro)
        {
            string sResposta = "";
            try
            {
                Logradouro cLogradouro;
                enderecos = new Enderecos();
                enderecos.ArquivoConexao = sArquivoConexao;
                cLogradouro = enderecos.pesquisarLogradouro(iCodigoLogradouro);
                sResposta = cLogradouro.Nome_logradouro;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao buscar Logradouro do Cliente! " + ex.Message, "EstacionamentoFacil (FrmCl05)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return sResposta;
        }//buscaLogradouro

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

        /// <summary>
        /// Função para lançar observação em Cliente
        /// </summary>
        /// <param name="cCliente">Objeto cliente</param>
        public void lancarObservacao(cliente cCliente)
        {
            DataGridViewRow row;
            gridObservacao.Rows.Clear();
            veiculos = new Veiculos();
            veiculos.ArquivoConexao = sArquivoConexao;
            List<observacao> lstObservacao = clientes.buscarObservacaoCliente(cCliente.Codigo);
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

        private void lancarHistorico(cliente cCliente)
        {
            DataGridViewRow row;
            gridObservacao.Rows.Clear();
            veiculos.ArquivoConexao = sArquivoConexao;
            List<histCliente> lstHistorico = clientes.buscarHistoricoCliente(cCliente);
            if (lstHistorico!= null)
            {
                if (lstHistorico.Count > 0)
                {
                    row = new DataGridViewRow();
                    foreach (histCliente cHistorico in lstHistorico)
                    {
                        gridHistorico.AllowUserToAddRows = true;
                        row = (DataGridViewRow)gridHistorico.Rows[0].Clone();
                        gridHistorico.AllowUserToAddRows = false;
                        row.Cells[0].Value = cHistorico.CodVenda.ToString();
                        row.Cells[1].Value = cHistorico.CodCarro.ToString();
                        row.Cells[2].Value = cHistorico.dataHist.ToString("dd/MM/yyyy HH:mm:ss");
                        row.Cells[3].Value = cHistorico.operacao;
                        row.Cells[4].Value = veiculos.pesquisarCarro(cHistorico.CodCarro).Placa2;
                        row.Cells[5].Value = veiculos.pesquisarMarca(veiculos.pesquisarCarro(cHistorico.CodCarro).CodMarca).descricao + " | " + veiculos.pesquisarCarro(cHistorico.CodCarro).Modelo;
                        gridHistorico.Rows.Add(row);
                    }
                }
            }
        }

        public void lancarContaCartao(cliente cCliente)
        {
            DataGridViewRow row;
            gridContaCartao.Rows.Clear();
            clientes.ArquivoConexao = sArquivoConexao;
            List<ContaCartaoCliente> lstContaCartao = clientes.buscarContaCartaoCliente(cCliente);
            if (lstContaCartao != null)
            {
                row = new DataGridViewRow();
                foreach (ContaCartaoCliente cContaCartao in lstContaCartao)
                {
                    gridContaCartao.AllowUserToAddRows = true;
                    row = (DataGridViewRow)gridContaCartao.Rows[0].Clone();
                    gridContaCartao.AllowUserToAddRows = false;
                    row.Cells[0].Value = cContaCartao.CodContaCartao.ToString();
                    row.Cells[1].Value = cContaCartao.CodCliente.ToString();
                    switch(cContaCartao.Tipo){
                        case 0: row.Cells[2].Value = "CARTÃO"; break;
                        case 1: row.Cells[2].Value = "CONTA CORRENTE"; break;
                        case 2: row.Cells[2].Value = "CONTA POUPANÇA"; break;
                    }                    
                    row.Cells[3].Value = cContaCartao.Numero;
                    row.Cells[4].Value = cContaCartao.Bandeira;
                    row.Cells[5].Value = cContaCartao.NomeBanco;
                    row.Cells[6].Value = cContaCartao.Agencia;
                    row.Cells[7].Value = cContaCartao.NumConta;
                    row.Cells[8].Value = cContaCartao.CPF;
                    row.Cells[9].Value = cContaCartao.CNPJ;
                    row.Cells[10].Value = cContaCartao.Obs;
                    gridContaCartao.Rows.Add(row);
                }
            }
        }

        public void exibirDadosCliente(cliente cCliente, byte bTipo = 0)
        {
            Enderecos endereco = new Enderecos();
            string sTelefone = "";
            int iQte=0;            
            List<Telefones> listTelefone;
            List<carro> listCarro;
            Operadora cOperadora;
            limparCampos();
            try
            {
                bNovo = false;
                endereco.ArquivoConexao = sArquivoConexao;
                iCodigoCliente = cCliente.Codigo;
                txtNome.Text = cCliente.Nome.Trim();
                txtCPF.Text = cCliente.CPF;
                txtRG.Text = cCliente.RG;
                txtEmail.Text = cCliente.Email;
                
                Municipio cMunicipio = endereco.pesquisarMunicipio(endereco.pesquisarLocalidade(endereco.pesquisarBairro(endereco.pesquisarLogradouro(cCliente.Cod_logradouro).Cod_bairro).Cod_localidade).Cod_Municipio);
                cmbMunicipio.Enabled = true;
                cmbMunicipio.Text = cMunicipio.Nome_municipio.Trim() + "/" + cMunicipio.UF.Trim();

                Bairro cBairro = endereco.pesquisarBairro(endereco.pesquisarLogradouro(cCliente.Cod_logradouro).Cod_bairro);

                cmbLocalidade.Enabled = true;
                listarLocalidade(enderecos.pesquisarLocalidade(cBairro.Cod_localidade).Cod_Municipio, 0);
                cmbLocalidade.Text = enderecos.pesquisarLocalidade(cBairro.Cod_localidade).Nome_localidade;

                cmbBairro.Enabled = true;
                listarBairro(cBairro.Cod_localidade, 0);
                cmbBairro.Text = cBairro.Nome_bairro.Trim();

                listarLogradouro(cBairro.Codigo, 0);
                cmbLogradouro.Enabled = true;
                cmbLogradouro.Text = buscaLogradouro(cCliente.Cod_logradouro);

                txtNumero.Text = cCliente.Numero.ToString();
                txtObservacao.Text = cCliente.Observacao;

                switch (cCliente.TipoPessoa)
                {
                    case 0: cmbTipoPessoa.Text = "FÍSICA"; break;
                    case 1: cmbTipoPessoa.Text = "JURÍDICA"; break;
                }

                txtDtNascimento.Text = cCliente.DtNascimento.ToString("dd/MM/yyyy");
                txtDataCadastro.Text = cCliente.DtCadastro.ToString("dd/MM/yyyy");

                switch (cCliente.Sexo)
                {
                    case 0: cmbSexo.Text = "MASCULINO"; break;
                    case 1: cmbSexo.Text = "FEMININO"; break;
                }
                txtProfissao.Text = cCliente.Profissao.Trim();
                txtEstadoCivil.Text = cCliente.EstadoCivil.Trim();
                switch (cCliente.FaixaSalarial)
                {
                    case 0: cmbFaixaSalarial.Text = "R$0,00 - R$1.000,00"; break;
                    case 1: cmbFaixaSalarial.Text = "R$1.001,00 - R$3.000,00"; break;
                    case 2: cmbFaixaSalarial.Text = "R$3.001,00 - R$5.000,00"; break;
                    case 3: cmbFaixaSalarial.Text = "R$5.001,00 - R$10.000,00"; break;
                    case 4: cmbFaixaSalarial.Text = "R$10.001,00 - R$20.000,00"; break;
                }

                txtCNH.Text = cCliente.CNH.Trim();
                txtValidadeCNH.Text = cCliente.ValidadeCNH.ToString("dd/MM/yyyy");
                txtCategoriaCNH.Text = cCliente.CategoriaCNH.Trim();
                txtPrimeiraHabilitacaoCNH.Text = cCliente.DtPrimeiraCNH.ToString("dd/MM/yyyy");
                txtDtRenovacaoSeguro.Text = cCliente.DtRenovacaoSeguro.ToString("dd/MM/yyyy");
                switch (cCliente.Status)
                {
                    case 0: cmbStatus.Text = "ATIVO"; break;
                    case 1: cmbStatus.Text = "INATIVO"; break;
                    case 2: cmbStatus.Text = "CANCELADO"; break;
                    case 3: cmbStatus.Text = "POTENCIAL"; break;
                }

                //buscar dados de telefone:
                listTelefone = clientes.pesquisarTelefoneCliente(cCliente.Codigo);
                if (listTelefone != null)
                {
                    foreach (Telefones lstTelefone in listTelefone)
                    {
                        cOperadora = clientes.pesquisarOperadora(lstTelefone.codoperadora);

                        cpToken = new TokenInputG.TokenInput(vTelaPrincipal);
                        cpToken.Name = "token_" + iQte.ToString();
                        cpToken.Nome = "Telefone de " + cCliente.Nome;
                        cpToken.Indice = lstTelefone.CodigoTelefone + "#" + lstTelefone.ddd + "#" + lstTelefone.telefone + "#" + lstTelefone.codoperadora + "#" + lstTelefone.tipotelefone;
                        if (lstTelefone.telefone.Trim().Length <= 8)
                            sTelefone = lstTelefone.telefone.Substring(0, 4) + "-" + lstTelefone.telefone.Substring(4, 4);
                        else
                            sTelefone = lstTelefone.telefone.Substring(0, 5) + "-" + lstTelefone.telefone.Substring(5, 4);
                             
                        cpToken.Texto = "(" +  lstTelefone.ddd.PadLeft(2,'0') + ") " + sTelefone + " - " + cOperadora.operadora.Trim() + " (" + buscaTipoTelefone(lstTelefone.tipotelefone).Trim() + ")" ;
                        cpToken.ExibirLink = false;
                        cpToken.ajustarDadosTela();
                        pnlTelefones.Controls.Add(cpToken);
                        iQte++;
                    }
                    iQteTelefones = iQte;
                }
                
                //exibir dados de observação
                lancarObservacao(cCliente);

                //exibir histórico do cliente
                lancarHistorico(cCliente);

                //exibir histórico de contas/cartoes
                lancarContaCartao(cCliente);

                //buscar dados de veículos para este cliente
                veiculos = new Veiculos();
                veiculos.ArquivoConexao = sArquivoConexao;
                listCarro = veiculos.pesquisarTodosCarrosCliente(cCliente.Codigo);
                if (listCarro != null)
                {
                    iQte = 0;
                    foreach (carro lstCarro in listCarro)
                    {
                        marca cMarca = veiculos.pesquisarMarca(lstCarro.CodMarca);

                        cpToken = new TokenInputG.TokenInput(vTelaPrincipal);
                        cpToken.Name = "tokenC_" + iQte.ToString();
                        cpToken.Nome = "Veículo de " + cCliente.Nome;
                        cpToken.Indice = lstCarro.Codigo.ToString() + "#A";
                        cpToken.Texto = lstCarro.Placa2 + " - " + cMarca.descricao.Trim();
                        cpToken.ExibirLink = true;
                        cpToken.Link = "VEICULO#" + lstCarro.Codigo.ToString();
                        cpToken.textoLink = "Abrir cadastro do carro placa: " + lstCarro.Placa2;
                        cpToken.ajustarDadosTela();
                        pnlVeiculos.Controls.Add(cpToken);
                        iQte++;
                    }
                    iQteCarros = iQte;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar dados do Cliente! " + ex.Message, "EstacionamentoFacil (FrmCl06)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (bTipo == 1) txtCPF.Focus();
        }//exibirDadosCliente

        private void gravarClientes()
        {
            bool bErro = false;
            cliente cCliente = new cliente();
            //ComboBoxItem cmbItem;
            ComboBoxItem cmbItem2;
            clientes = new Cliente();
            clientes.ArquivoConexao = sArquivoConexao;
            if (validaTela())
            {
                //cmbItem = (ComboBoxItem)cmbNome.SelectedItem;
                //if (cmbItem != null)
                if(!bNovo)
                {
                    //atualizar
                    //if (clientes.seExisteCliente(txtNome.Text))
                    //{
                    cCliente.Codigo = iCodigoCliente;// int.Parse(cmbItem.Value.ToString());
                    cCliente.Nome = txtNome.Text.ToUpper().Trim();
                    cCliente.CPF = txtCPF.Text;
                    cCliente.RG = txtRG.Text;
                    cCliente.Email = txtEmail.Text;
                    cCliente.Observacao = txtObservacao.Text;
                    cCliente.TipoCliente = 0;
                    cmbItem2 = (ComboBoxItem)cmbLogradouro.SelectedItem;
                    if (cmbItem2 != null)
                        cCliente.Cod_logradouro = int.Parse(cmbItem2.Value.ToString());
                    else
                        cCliente.Cod_logradouro = 0;
                    cCliente.Numero = int.Parse(txtNumero.Text);

                    cmbItem2 = (ComboBoxItem)cmbTipoPessoa.SelectedItem;
                    if (cmbItem2 != null) cCliente.TipoPessoa = int.Parse(cmbItem2.Value.ToString());
                    else cCliente.TipoPessoa = 0;
                    cCliente.DtNascimento = DateTime.Parse(txtDtNascimento.Text);
                    cCliente.DtCadastro = DateTime.Parse(txtDataCadastro.Text);
                    cmbItem2 = (ComboBoxItem)cmbSexo.SelectedItem;
                    if (cmbItem2 != null) cCliente.Sexo = int.Parse(cmbItem2.Value.ToString());
                    else cCliente.Sexo = 0;
                    cCliente.Profissao = txtProfissao.Text.ToUpper().Trim();
                    cCliente.EstadoCivil = txtEstadoCivil.Text.ToUpper().Trim();
                    cmbItem2 = (ComboBoxItem)cmbFaixaSalarial.SelectedItem;
                    if (cmbItem2 != null) cCliente.FaixaSalarial = int.Parse(cmbItem2.Value.ToString());
                    else cCliente.FaixaSalarial = 0;
                    cCliente.CNH = txtCNH.Text.Trim();
                    cCliente.ValidadeCNH = DateTime.Parse(txtValidadeCNH.Text);
                    cCliente.CategoriaCNH = txtCategoriaCNH.Text.Trim();
                    cCliente.DtPrimeiraCNH = DateTime.Parse(txtPrimeiraHabilitacaoCNH.Text);
                    cCliente.DtRenovacaoSeguro = DateTime.Parse(txtDtRenovacaoSeguro.Text);
                    cmbItem2 = (ComboBoxItem)cmbStatus.SelectedItem;
                    if (cmbItem2 != null) cCliente.Status = int.Parse(cmbItem2.Value.ToString());
                    else cCliente.Status = 2;

                    if (clientes.gravarCliente(cCliente, 1))
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
                            if (!clientes.gravarTelefones(lstTelefone, cCliente))
                            {
                                MessageBox.Show("Telefone(s) do Cliente não atualizado!", "EstacionamentoFacil (FrmCl07)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                bErro = true;
                            }
                        }
                        else
                        {
                            clientes.excluirTodosTelefones(cCliente.Codigo);
                        }

                        //gravar veículos:
                        if (pnlVeiculos.Controls.Count > 0)
                        {                                
                            foreach (TokenInputG.TokenInput cToken in pnlVeiculos.Controls)
                            {
                                if (!cToken.Excluir)
                                {
                                    string[] sIndice = cToken.Indice.Split('#');
                                    if (sIndice[1].Equals("I"))
                                        if (!clientes.gravarVeiculosCliente(cCliente.Codigo, int.Parse(sIndice[0])))
                                        {
                                            bErro = true;
                                        }                                                
                                }
                                else
                                {
                                    string[] sIndice = cToken.Indice.Split('#');
                                    clientes.excluirVeiculoCliente(int.Parse(sIndice[0]), cCliente.Codigo);
                                }
                                    
                            }
                        }
                        else
                        {
                            clientes.excluirTodosVeiculosCliente(cCliente.Codigo);
                        }

                        if (!bErro)
                            MessageBox.Show("Cliente atualizado com sucesso!", "EstacionamentoFacil (FrmCl08)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ve_se_existe();
                    }
                    else
                    {
                        MessageBox.Show("O Cliente não foi atualizado!", "EstacionamentoFacil (FrmCl09)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //}
                }
                else
                {
                    //novo
                    cCliente.Codigo = clientes.ultimoCodigoCliente() + 1;
                    cCliente.Nome = txtNome.Text.ToUpper().Trim();
                    cCliente.CPF = txtCPF.Text;
                    cCliente.RG = txtRG.Text;
                    cCliente.Email = txtEmail.Text;
                    cCliente.Observacao = txtObservacao.Text;
                    cCliente.TipoCliente = 0;
                    
                    cmbItem2 = (ComboBoxItem)cmbTipoPessoa.SelectedItem;
                    if (cmbItem2 != null) cCliente.TipoPessoa = int.Parse(cmbItem2.Value.ToString());
                    else cCliente.TipoPessoa = 0;
                    cCliente.DtNascimento = DateTime.Parse(txtDtNascimento.Text);
                    cCliente.DtCadastro = DateTime.Parse(txtDataCadastro.Text);
                    cmbItem2 = (ComboBoxItem)cmbSexo.SelectedItem;
                    if (cmbItem2 != null) cCliente.Sexo = int.Parse(cmbItem2.Value.ToString());
                    else cCliente.Sexo = 0;
                    cCliente.Profissao = txtProfissao.Text.ToUpper().Trim();
                    cCliente.EstadoCivil = txtEstadoCivil.Text.ToUpper().Trim();
                    cmbItem2 = (ComboBoxItem)cmbFaixaSalarial.SelectedItem;
                    if (cmbItem2 != null) cCliente.FaixaSalarial = int.Parse(cmbItem2.Value.ToString());
                    else cCliente.FaixaSalarial = 0;
                    cCliente.CNH = txtCNH.Text.Trim();
                    cCliente.ValidadeCNH = DateTime.Parse(txtValidadeCNH.Text);
                    cCliente.CategoriaCNH = txtCategoriaCNH.Text.Trim();
                    cCliente.DtPrimeiraCNH = DateTime.Parse(txtPrimeiraHabilitacaoCNH.Text);
                    cCliente.DtRenovacaoSeguro = DateTime.Parse(txtDtRenovacaoSeguro.Text);
                    cmbItem2 = (ComboBoxItem)cmbStatus.SelectedItem;
                    if (cmbItem2 != null) cCliente.Status = int.Parse(cmbItem2.Value.ToString());
                    else cCliente.Status = 2;

                    cmbItem2 = (ComboBoxItem)cmbLogradouro.SelectedItem;
                    if (cmbItem2 != null)
                        cCliente.Cod_logradouro = int.Parse(cmbItem2.Value.ToString());
                    else
                        cCliente.Cod_logradouro = 0;
                    cCliente.Numero = int.Parse(txtNumero.Text);

                    if (clientes.gravarCliente(cCliente, 0))
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
                            }
                            if (!clientes.gravarTelefones(lstTelefone, cCliente))
                            {
                                MessageBox.Show("Telefone(s) do Cliente não atualizado!", "EstacionamentoFacil (FrmCl10)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                bErro = true;
                            }
                        }
                        else
                            clientes.excluirTodosTelefones(cCliente.Codigo);

                        //gravar veículos:
                        if (pnlVeiculos.Controls.Count > 0)
                        {
                            foreach (TokenInputG.TokenInput cToken in pnlVeiculos.Controls)
                            {
                                if (!cToken.Excluir)
                                {
                                    string[] sIndice = cToken.Indice.Split('#');
                                    if (sIndice[1].Equals("I"))
                                        if (!clientes.gravarVeiculosCliente(cCliente.Codigo, int.Parse(sIndice[0])))
                                        {
                                            bErro = true;
                                        }
                                }
                                else
                                {
                                    string[] sIndice = cToken.Indice.Split('#');
                                    clientes.excluirVeiculoCliente(int.Parse(sIndice[0]), cCliente.Codigo);
                                }

                            }
                        }
                        else
                        {
                            clientes.excluirTodosVeiculosCliente(cCliente.Codigo);
                        }
                        
                        if (!bErro)
                            MessageBox.Show("Cliente inserido com sucesso!", "EstacionamentoFacil (FrmCl11)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ve_se_existe();
                    }
                }
            }
        }//gravarClientes

        /*
        private void selecionaCliente()
        {   
            ComboBoxItem cmbItem = new ComboBoxItem();
            cmbItem = (ComboBoxItem)cmbNome.SelectedItem;
            clientes = new Cliente();
            clientes.ArquivoConexao = sArquivoConexao;
            cliente cCliente = clientes.pesquisarCliente(int.Parse(cmbItem.Value.ToString()));
            exibirDadosCliente(cCliente);            
        }//selecionaCliente

        private void lostCliente()
        {
            limparCampos(2);
            if (cmbNome.Text.Length > 0)
            {
                ComboBoxItem cmbItem = new ComboBoxItem();
                cmbItem = (ComboBoxItem)cmbNome.SelectedItem;
                if (cmbItem != null)
                {
                    clientes = new Cliente();
                    clientes.ArquivoConexao = sArquivoConexao;
                    cliente cCliente = clientes.pesquisarCliente(int.Parse(cmbItem.Value.ToString()));
                    exibirDadosCliente(cCliente); 
                }
            }
        }//lostCliente
        */

        private void sairCliente()
        {
            this.Close();
        }//sairCliente

        private void excluirCliente()
        {
            clientes = new Cliente();
            clientes.ArquivoConexao = sArquivoConexao;
            if (validaTela())
            {
                //ComboBoxItem cmbItem = new ComboBoxItem();
                //cmbItem = (ComboBoxItem)cmbNome.SelectedItem;
                //if (cmbItem != null)
                if(!bNovo)
                {
                    //atualizar
                    //if (!clientes.seExisteCliente(txtNome.Text))
                    //{
                        if (MessageBox.Show("Deseja realmente excluir o registro deste cliente?\nTodos os dados registros de venda e vículo com veículos serão apagados neste processo.", "EstacionamentoFacil(FrmCl13a)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            string sConfirmacao = Microsoft.VisualBasic.Interaction.InputBox("Digite a palavra CONFIRMA para confirmar a exclusão deste cliente", "Exclusão de cliente");
                            if (sConfirmacao.ToUpper().Trim().Equals("CONFIRMA"))
                            {
                                if (clientes.excluirCliente(iCodigoCliente, vTelaPrincipal.vvCodigoUsuario, this.Text.Trim()))
                                {
                                    MessageBox.Show("Cliente excluído com sucesso!", "EstacionamentoFacil (FrmCl12)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    ve_se_existe();
                                }
                                else
                                {
                                    MessageBox.Show("O Cliente não foi excluído!", "EstacionamentoFacil (FrmCl13)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Texto digitado não confere. Cliente não excluído!", "EstacionamentoFacil (FrmCl13b)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    //}
                }
                else
                {
                    MessageBox.Show("Cliente não cadastrado. Exclusão não executada!", "EstacionamentoFacil (FrmCl14)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }//excluirCliente


        /// <summary>
        /// Função para adicionar o token input de novo telefone
        /// </summary>
        /// <param name="cctoken">Objeto TelefoneToken contendo dados do telefone</param>
        public void lancarTelefone(TelefoneToken cctoken)
        {
            string sTelefone;
            iQteTelefones++;
            clientes = new Cliente();
            clientes.ArquivoConexao = sArquivoConexao;
            Operadora cOperadora = clientes.pesquisarOperadora(cctoken.Codigo_Operadora);
            cpToken = new TokenInputG.TokenInput(vTelaPrincipal);
            cpToken.Name = "token_" + iQteTelefones.ToString();
            if (txtNome.Text.Length > 0)
                cpToken.Nome = "Telefone de " + txtNome.Text;
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
        }

        /// <summary>
        /// Função para lançar em tela o componente de Carro para cadastro.
        /// </summary>
        /// <param name="cCarro">Objeto Carro para retorno</param>
        public void lancarVeiculo(carro cCarro, cliente cCliente)
        {
            iQteCarros++;            
            veiculos = new Veiculos();
            veiculos.ArquivoConexao = sArquivoConexao;
            marca cMarca = veiculos.pesquisarMarca(cCarro.CodMarca);

            cpToken = new TokenInputG.TokenInput(vTelaPrincipal);
            cpToken.Name = "tokenC_" + iQteCarros.ToString();
            cpToken.Nome = "Veículo de " + cCliente.Nome;
            cpToken.Indice = cCarro.Codigo.ToString() + "#I";
            cpToken.Texto = cCarro.Placa2 + " - " + cMarca.descricao.Trim();
            cpToken.ExibirLink = true;
            cpToken.Link = "VEICULO#" + cCarro.Codigo.ToString();
            cpToken.textoLink = "Abrir cadastro do carro placa: " + cCarro.Placa2;
            cpToken.ajustarDadosTela();
            pnlVeiculos.Controls.Add(cpToken);
        }

        private string buscaCodigosVeiculosPainel()
        {
            string sResposta="";
            if (pnlVeiculos.Controls.Count > 0)
            {
                foreach (TokenInputG.TokenInput cToken in pnlVeiculos.Controls)
                {
                    string[] sIndice = cToken.Indice.Split('#');
                    if (sResposta.Trim().Length > 0)
                        sResposta += ", ";
                    sResposta += sIndice[0];
                }
            }
            return sResposta;
        }

        private void cmbNome_SelectedValueChanged(object sender, EventArgs e)
        {
            //selecionaCliente();
        }

        private void cmbNome_Leave(object sender, EventArgs e)
        {
            //lostCliente();
        }

        private void cmbNome_Enter(object sender, EventArgs e)
        {
            //limparCampos(1);
        }

        private void cmdGravar_Click(object sender, EventArgs e)
        {
            gravarClientes();
        }

        private void cmdExcluir_Click(object sender, EventArgs e)
        {
            excluirCliente();
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            sairCliente();
        }

        private void cmdNovoTelefone_Click(object sender, EventArgs e)
        {
            /*ComboBoxItem cmbItem = (ComboBoxItem)cmbNome.SelectedItem;
            if (cmbItem != null)
            {*/
                vTelaPrincipal.abrirNovoTelefone(vTelaPrincipal,0);
            //}
            //else
              //  MessageBox.Show("Cadastro novo! Não é permitido a inclusão de veículo antes da primeira gravação!", "EstacionamentoFacil (FrmCl15b)", MessageBoxButtons.OK, MessageBoxIcon.Information);            
        }

        /// <summary>
        /// Incluir novos veículos para este cliente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //ComboBoxItem cmbItem = (ComboBoxItem)cmbNome.SelectedItem;
            clientes = new Cliente();
            clientes.ArquivoConexao = sArquivoConexao;
            cliente cCliente;
            //if (cmbItem != null)
            if(!bNovo)
            {
                cCliente = clientes.pesquisarCliente(iCodigoCliente);
                vTelaPrincipal.abrirNovoVeiculo(vTelaPrincipal, buscaCodigosVeiculosPainel(),cCliente);
            }else
                MessageBox.Show("Cadastro novo! Não é permitido a inclusão de veículo antes da primeira gravação!", "EstacionamentoFacil (FrmCl15b)", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void novaObservacao()
        {
            //ComboBoxItem cmbItem = (ComboBoxItem)cmbNome.SelectedItem;
            clientes = new Cliente();
            clientes.ArquivoConexao = sArquivoConexao;            
            //if (cmbItem != null)
            if(!bNovo)
            {
                vTelaPrincipal.abrirCadObservacao(vTelaPrincipal, clientes.pesquisarCliente(iCodigoCliente));
            }
            else
            {
                MessageBox.Show("Cadastro novo! Não é permitido a inclusão de observação antes da primeira gravação!", "EstacionamentoFacil (FrmCl15)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }

        private void novaContaCartao()
        {
            clientes = new Cliente();
            clientes.ArquivoConexao = sArquivoConexao;
            if (!bNovo)
                vTelaPrincipal.abrirCadContaCartaoCliente(vTelaPrincipal, clientes.pesquisarCliente(iCodigoCliente));
            else
                MessageBox.Show("Cadastro novo! Não é permitido a inclusão de conta/cartão antes da primeira gravação!", "EstacionamentoFacil (FrmCl15b)", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmdNovaObservacao_Click(object sender, EventArgs e)
        {
            novaObservacao();
        }

        private void novaObservaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            novaObservacao();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int iIndice = 0;
            //ComboBoxItem cmbItem = (ComboBoxItem)cmbNome.SelectedItem;
            clientes = new Cliente();
            clientes.ArquivoConexao = sArquivoConexao;
            cliente cCliente;
            //if (cmbItem != null)
            if(!bNovo && iCodigoCliente > 0)
            {
                cCliente = clientes.pesquisarCliente(iCodigoCliente);
                if (gridObservacao.Rows.Count > 0)
                {
                    iIndice = int.Parse(gridObservacao.CurrentRow.Cells[0].Value.ToString());
                    if (iIndice > 0)
                    {
                        if (MessageBox.Show("Deseja realmente excluir esta observação?", "EstacionamentoFacil (FrmCl16)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            string sMotivo = Microsoft.VisualBasic.Interaction.InputBox("Qual o motivo da exclusão?", "Motivo da exclusão");
                            if (sMotivo.Length == 0) sMotivo = "Motivo não declarado pelo usuário " + vTelaPrincipal.vvNomeUsuario.Trim();
                            
                            //verificar se o usuário da exclusão é o proprietário da observação e/ou admin
                            if (vTelaPrincipal.vvNomeUsuario.ToUpper().Equals("ADMIN") || int.Parse(gridObservacao.CurrentRow.Cells[3].Value.ToString()) == vTelaPrincipal.vvCodigoUsuario)
                            {
                                if (clientes.excluirObservacaoCliente(int.Parse(gridObservacao.CurrentRow.Cells[0].ToString()), vTelaPrincipal.vvCodigoUsuario, this.Text, sMotivo))
                                {
                                    MessageBox.Show("Observação excluída com sucesso!", "EstacionamentoFacil (FrmCl17)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    lancarObservacao(cCliente);
                                }
                            }
                            else
                            {
                                MessageBox.Show("A observação somete será excluída pelo usuário " + gridObservacao.CurrentRow.Cells[2].Value.ToString() + ".\nOperação cancelada!", "EstacionamentoFacil (FrmCl18)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Cadastro novo! Não é permitido a exclusão de observação antes da primeira gravação!", "EstacionamentoFacil (FrmCar49)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void excluirContaCartao(int iCodContaCartao)
        {            
            clientes = new Cliente();
            clientes.ArquivoConexao = sArquivoConexao;
            cliente cCliente;
            if (!bNovo && iCodigoCliente > 0)
            {
                cCliente = clientes.pesquisarCliente(iCodigoCliente);
                if (gridContaCartao.Rows.Count > 0)
                {                    
                    if (iCodContaCartao > 0)
                    {
                        if (MessageBox.Show("Deseja realmente excluir esta conta/cartão?", "EstacionamentoFacil (FrmCl16b)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            string sMotivo = Microsoft.VisualBasic.Interaction.InputBox("Qual o motivo da exclusão?", "Motivo da exclusão");
                            if (sMotivo.Length == 0) sMotivo = "Motivo não declarado pelo usuário " + vTelaPrincipal.vvNomeUsuario.Trim();

                            if (clientes.excluirContaCartaoCliente(iCodContaCartao, vTelaPrincipal.vvCodigoUsuario, this.Text, sMotivo))
                            {
                                MessageBox.Show("Conta/Cartão excluído com sucesso!", "EstacionamentoFacil (FrmCl17b)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                lancarContaCartao(cCliente);
                            }                            
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Cadastro novo! Não é permitido a exclusão de conta/cartão antes da primeira gravação!", "EstacionamentoFacil (FrmCar49b)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void excluirDespesaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ComboBoxItem cmbItem = (ComboBoxItem)cmbNome.SelectedItem;
            clientes = new Cliente();
            clientes.ArquivoConexao = sArquivoConexao;
            cliente cCliente;
            Veiculos veiculos = new Veiculos();
            veiculos.ArquivoConexao = sArquivoConexao;
            int iIndice = 0;
            //if (cmbItem != null)
            if(!bNovo)
            {
                cCliente = clientes.pesquisarCliente(iCodigoCliente);
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
                        MessageBox.Show("Nenhum dado a ser exibido!", "EstacionamentoFacil (FrmCar50)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Cadastro novo! Selecione primeiro um cliente!", "EstacionamentoFacil (FrmCar51)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void exibirDadosDoVeículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ComboBoxItem cmbItem = (ComboBoxItem)cmbNome.SelectedItem;
            clientes = new Cliente();
            clientes.ArquivoConexao = sArquivoConexao;
            cliente cCliente;
            Veiculos veiculos = new Veiculos();
            veiculos.ArquivoConexao = sArquivoConexao;
            int iIndice = 0;
            //if (cmbItem != null)
            if(!bNovo && iCodigoCliente >0)
            {
                cCliente = clientes.pesquisarCliente(iCodigoCliente);
                if (gridHistorico.Rows.Count > 0)
                {
                    iIndice = int.Parse(gridHistorico.CurrentRow.Cells[1].Value.ToString());
                    if (iIndice > 0)
                    {
                        carro cCarro = new carro();
                        cCarro = veiculos.pesquisarCarro(int.Parse(gridHistorico.CurrentRow.Cells[1].Value.ToString()));
                        vTelaPrincipal.abrirCadCarro(vTelaPrincipal,cCarro);
                    }
                    else
                    {
                        MessageBox.Show("Nenhum dado a ser exibido!", "EstacionamentoFacil (FrmCar52)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Cadastro novo! Selecione primeiro um cliente!", "EstacionamentoFacil (FrmCar53)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void tooltipGrid(byte bTipo)
        {
            switch (bTipo)
            {
                case 0:
                    txtObservacaoTela.Text = "Clique com o botão da direita para mais opções!";
                    break;
                case 1:
                    txtObservacaoTela.Clear();
                    break;
            }
        }

        private void gridHistorico_MouseEnter(object sender, EventArgs e)
        {
            tooltipGrid(0);
        }

        private void gridHistorico_MouseLeave(object sender, EventArgs e)
        {
            tooltipGrid(1);
        }

        private void gridObservacao_MouseEnter(object sender, EventArgs e)
        {
            tooltipGrid(0);
        }

        private void gridObservacao_MouseLeave(object sender, EventArgs e)
        {
            tooltipGrid(1);
        }

        private void cmbNome_MouseEnter(object sender, EventArgs e)
        {
            /*ComboBoxItem cmbItem = (ComboBoxItem)cmbNome.SelectedItem;
            if (cmbItem != null)
            {
                tooltipGrid(0);
            }*/
        }

        private void cmbNome_MouseLeave(object sender, EventArgs e)
        {
            //tooltipGrid(1);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            //ComboBoxItem cmbItem = (ComboBoxItem)cmbNome.SelectedItem;
            //if (cmbItem != null)
            if(!bNovo && iCodigoCliente>0)
            {
                clientes = new Cliente();
                clientes.ArquivoConexao = sArquivoConexao;
                cliente cCliente = new cliente();
                cCliente = clientes.pesquisarCliente(iCodigoCliente);
                string sNome = Microsoft.VisualBasic.Interaction.InputBox("Qual o novo nome?", "Novo nome",txtNome.Text);
                if (sNome.Trim().Length != 0)
                {
                    cCliente.Nome = sNome.Trim();
                    if (clientes.gravarCliente(cCliente, 1))
                    {
                        MessageBox.Show("Nome alterado com sucesso!", "EstacionamentoFacil (FrmCar54)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ve_se_existe();
                        exibirDadosCliente(cCliente,1);
                    }
                }
            }
            else
            {
                MessageBox.Show("Alteração de nome somente para cadastros já gravados!", "EstacionamentoFacil (FrmCar55)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmdLocalizar_Click(object sender, EventArgs e)
        {
            limparCampos();   
            vTelaPrincipal.abrirLocalizarCliente(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text.Equals("Novo"))
            {
                limparCampos();                
                bNovo = true;
                txtNome.Focus();

                button2.Text = "Cancelar";
                button2.Image = global::Estancionamento.Properties.Resources.cancel;
                toolTip1.SetToolTip(button2, "Cancelar novo registro de cliente");
            }
            else
            {
                limparCampos();
            }
        }
        
        private void txtNumero_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8)
                if (!char.IsDigit(e.KeyChar))
                    e.Handled = true;
        }

        private void txtCPF_Leave(object sender, EventArgs e)
        {
            if (txtCPF.Text.Length > 0)
            {
                Funcoes funcao = new Funcoes();
                if (!funcao.validarCPF(txtCPF.Text.Trim()))
                {
                    if (MessageBox.Show("CPF Inválido!\n\nDeseja continuar a digitação dos dados do cliente?", "EstacionamentoFacil (FrmCar56)", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                    {
                        txtCPF.Clear();
                        txtCPF.Focus();
                    }
                }
            }
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

        private void listarLogradouro(int iCodBairro, byte bTipo)
        {
            ComboBoxItem cboItem;

            cmbLogradouro.Items.Clear();
            enderecos = new Enderecos();
            enderecos.ArquivoConexao = sArquivoConexao;

            List<Logradouro> lstLogradouro = new List<Logradouro>();
            lstLogradouro = null;
            switch (bTipo)
            {
                case 0:
                    lstLogradouro =  enderecos.pesquisarLogradouro(iCodBairro,0);
                    break;
                case 1:
                    lstLogradouro = enderecos.pesquisarTodosLogradouro();
                    break;
            }

            if (lstLogradouro != null)
            {
                cmbLogradouro.Enabled = true;
                foreach (Logradouro cLogradouro in lstLogradouro)
                {
                    cboItem = new ComboBoxItem();
                    cboItem.Text = cLogradouro.Nome_logradouro.Trim();
                    cboItem.Value = cLogradouro.Codigo;
                    cmbLogradouro.Items.Add(cboItem);
                }
            }
            else
            {
                cmbLogradouro.Enabled = false;
            }
        }

        private void listarMunicipio()
        {
            ComboBoxItem cboItem;

            cmbMunicipio.Items.Clear();
            enderecos = new Enderecos();
            enderecos.ArquivoConexao = sArquivoConexao;

            List<Municipio> lstMunicipio = new List<Municipio>();
            lstMunicipio = null;            
            lstMunicipio = enderecos.pesquisarTodosMunicipio();
                        
            if (lstMunicipio != null)
            {                
                foreach (Municipio cMunicipio in lstMunicipio)
                {
                    cboItem = new ComboBoxItem();
                    cboItem.Text = cMunicipio.Nome_municipio.Trim() + "/" + cMunicipio.UF.Trim();
                    cboItem.Value = cMunicipio.Codigo;
                    cmbMunicipio.Items.Add(cboItem);
                }
            }
            else
            {
                cmbMunicipio.Enabled = false;
            }
        }

        private void cmbMunicipio_Enter(object sender, EventArgs e)
        {
            cmbLocalidade.SelectedIndex = -1;
            cmbBairro.SelectedIndex = -1;
            cmbLogradouro.SelectedIndex = -1;
            cmbLocalidade.Enabled = false;
            cmbBairro.Enabled = false;
            cmbLogradouro.Enabled = false;
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
            cmbBairro.SelectedIndex = -1;
            cmbBairro.Enabled = false;
            cmbLogradouro.SelectedIndex = -1;
            cmbLogradouro.Enabled = false;
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

        private void cmbBairro_Enter(object sender, EventArgs e)
        {
            cmbLogradouro.SelectedIndex = -1;
            cmbLogradouro.Enabled = false;
        }

        private void cmbBairro_Leave(object sender, EventArgs e)
        {
            ComboBoxItem cmbItem = new ComboBoxItem();
            cmbItem = (ComboBoxItem)cmbBairro.SelectedItem;
            if (cmbItem != null)
            {
                listarLogradouro(int.Parse(cmbItem.Value.ToString()), 0);
                cmbLogradouro.Enabled = true;
                cmbLogradouro.Focus();
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text.Trim().Length > 0)
            {
                Funcoes cFuncoes = new Funcoes();
                if (!cFuncoes.validarEmail(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("E-mail digitado inválido. Verifique!", "EstacionamentoFacil (FrmCar56b)", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    txtEmail.Clear();
                    txtEmail.Focus();
                }
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            novaContaCartao();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {            
            int iCodContaCartao = int.Parse(gridContaCartao.CurrentRow.Cells[0].Value.ToString());
            excluirContaCartao(iCodContaCartao);
        }

        private void gridContaCartao_MouseEnter(object sender, EventArgs e)
        {
            tooltipGrid(0);
        }

        private void gridContaCartao_MouseLeave(object sender, EventArgs e)
        {
            tooltipGrid(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            novaContaCartao();
        }

        private void cmdExcluirCliente_Click(object sender, EventArgs e)
        {
            excluirCliente();
        }

    }
}
