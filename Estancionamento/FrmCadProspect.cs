using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Estancionamento
{
    public partial class FrmCadProspect : Form
    {
        Cliente clientes;
        Veiculos veiculos;
        Enderecos enderecos;
        FrmPrincipal vTelaPrincipal;
        string sArquivoConexao;
        int iQteTelefones;
        int iQteMarca;
        int iQteCor;
        int iQteMotor;
        int iQtePortas;
        bool bNovo;
        int iCodigoProspect;
        int iCodigoCliente;
        TokenInputG.TokenInput cpToken;

        public FrmCadProspect(string vArquivoConexao, FrmPrincipal vvTelaPrincipal)
        {
            InitializeComponent();
            sArquivoConexao = vArquivoConexao;
            iQteTelefones = 0;
            iQteMarca = 0;
            iQteCor = 0;
            iQteMotor = 0;
            iQtePortas = 0;
            vTelaPrincipal = vvTelaPrincipal;
        }

        private void limparCampos()
        {
            txtNome.Clear();
            txtCPF.Clear();
            txtRG.Clear();
            txtEmail.Clear();
            cmbLogradouro.Text = "";
            txtNumero.Clear();
            pnlTelefones.Controls.Clear();
            pnlCor.Controls.Clear();
            pnlMarcas.Controls.Clear();
            pnlMotor.Controls.Clear();
            pnlPortas.Controls.Clear();

            iCodigoProspect = 0;
            iCodigoCliente = 0;
            bNovo = true;
            cmdNovoRegistro.Text = "Novo";
            cmdNovoRegistro.Image = global::Estancionamento.Properties.Resources.plus;
            toolTip1.SetToolTip(cmdNovoRegistro, "Novo registro de cliente");

            cmbLogradouro.SelectedIndex = -1;
            cmbMunicipio.SelectedIndex = -1;
            cmbLocalidade.SelectedIndex = -1;
            cmbBairro.SelectedIndex = -1;

            cmbLocalidade.Enabled = false;
            cmbBairro.Enabled = false;
            cmbLogradouro.Enabled = false;
        }

        private void ve_se_existe()
        {
            limparCampos();
            ComboBoxItem cboItem;
            try
            {
                //buscar dados do cliente:
                clientes = new Cliente();
                clientes.ArquivoConexao = sArquivoConexao;
                
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
                gridObservacao.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir janela de lista de espera! " + ex.Message, "EstacionamentoFacil (FrmPros01)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//ve_se_existe

         private bool validaTela()
        {
            bool bResposta = true;
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
                 MessageBox.Show("Erro ao buscar Logradouro do Cliente! " + ex.Message, "EstacionamentoFacil (FrmPros05)", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

         public void exibirDadosProspect(Prospect cProspect, byte bTipo = 0)
         {
             cliente cCliente = cProspect.cCliente;
             Enderecos endereco = new Enderecos();
             Veiculos cVeiculos = new Veiculos();
             cVeiculos.ArquivoConexao = sArquivoConexao;
             string sTelefone = "";
             int iQte = 0;
             List<Telefones> listTelefone;
             List<ProspectMarca> listMarca = cProspect.cProspectMarca;
             List<ProspectCor> listCor = cProspect.cProspectCor;
             List<ProspectMotor> listMotor = cProspect.cProspectMotor;
             List<ProspectPortas> listPortas = cProspect.cProspectPortas;
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
                 cmbBairro.Text = cBairro.Nome_bairro;

                 listarLogradouro(cBairro.Codigo, 0);
                 cmbLogradouro.Enabled = true;
                 cmbLogradouro.Text = buscaLogradouro(cCliente.Cod_logradouro);

                 txtNumero.Text = cCliente.Numero.ToString();
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

                         cpToken.Texto = "(" + lstTelefone.ddd.PadLeft(2, '0') + ") " + sTelefone + " - " + cOperadora.operadora.Trim() + " (" + buscaTipoTelefone(lstTelefone.tipotelefone).Trim() + ")";
                         cpToken.ExibirLink = false;
                         cpToken.ajustarDadosTela();
                         pnlTelefones.Controls.Add(cpToken);
                         iQte++;
                     }
                     iQteTelefones = iQte;
                 }

                 //listar marcas
                 if (listMarca != null)
                 {
                     iQte = 0;
                     foreach (ProspectMarca lstMarca in listMarca)
                     {
                         cpToken = new TokenInputG.TokenInput(vTelaPrincipal);
                         cpToken.Name = "tokenMarca_" + iQte.ToString();
                         cpToken.Nome = "Marca de " + cCliente.Nome;
                         cpToken.Indice = lstMarca.CodMarca.ToString() + "#" + lstMarca.CodProspect.ToString();
                         cpToken.Texto = cVeiculos.pesquisarMarca(lstMarca.CodMarca).descricao.Trim();
                         cpToken.ExibirLink = false;
                         cpToken.ajustarDadosTela();
                         pnlMarcas.Controls.Add(cpToken);
                         iQte++;
                     }
                     iQteMarca = iQte;
                 }

                 //listar cor
                 if (listCor != null)
                 {
                     iQte = 0;
                     foreach (ProspectCor lstCor in listCor)
                     {
                         cpToken = new TokenInputG.TokenInput(vTelaPrincipal);
                         cpToken.Name = "tokenCor_" + iQte.ToString();
                         cpToken.Nome = "Cor de " + cCliente.Nome;
                         cpToken.Indice = lstCor.CodProspect.ToString() + "#" + lstCor.cCores.CodCor.ToString();
                         cpToken.Texto = lstCor.cCores.sCor.Trim();
                         cpToken.ExibirLink = false;
                         cpToken.ModificarCor = false;//true;
                         cpToken.CorFundo = lstCor.cCores.sRGB;
                         cpToken.ajustarDadosTela();
                         pnlCor.Controls.Add(cpToken);
                         iQte++;
                     }
                     iQteCor = iQte;
                 }

                 //listar Motor
                 if (listMotor != null)
                 {
                     iQte = 0;
                     foreach (ProspectMotor lstMotor in listMotor)
                     {
                         cpToken = new TokenInputG.TokenInput(vTelaPrincipal);
                         cpToken.Name = "tokenCor_" + iQte.ToString();
                         cpToken.Nome = "Motor de " + cCliente.Nome;
                         cpToken.Indice = lstMotor.CodProspect.ToString() + "#" + lstMotor.CodMotor.ToString();
                         cpToken.Texto = cVeiculos.pesquisarMotor(lstMotor.CodMotor).TipoMotor.Trim();
                         cpToken.ExibirLink = false;
                         cpToken.ModificarCor = false;
                         cpToken.ajustarDadosTela();
                         pnlMotor.Controls.Add(cpToken);
                         iQte++;
                     }
                     iQteMotor = iQte;
                 }

                 //portas
                 if (listPortas != null)
                 {
                     iQte = 0;
                     foreach (ProspectPortas lstPortas in listPortas)
                     {
                         cpToken = new TokenInputG.TokenInput(vTelaPrincipal);
                         cpToken.Name = "tokenCor_" + iQte.ToString();
                         cpToken.Nome = "Portas de " + cCliente.Nome;
                         cpToken.Indice = lstPortas.CodProspect.ToString() + "#" + lstPortas.iQtePortas.ToString();
                         cpToken.Texto = lstPortas.iQtePortas.ToString("D2");
                         cpToken.ExibirLink = false;
                         cpToken.ModificarCor = false;
                         cpToken.ajustarDadosTela();
                         pnlPortas.Controls.Add(cpToken);
                         iQte++;
                     }
                     iQtePortas = iQte;
                 }

                 //exibir dados de observação
                 lancarObservacao(cCliente);

                 
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Erro ao buscar dados do Cliente! " + ex.Message, "EstacionamentoFacil (FrmPros06)", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
             if (bTipo == 1) txtCPF.Focus();
         }//exibirDadosCliente

         private void gravarClientes()
         {
             
         }//gravarClientes

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

         private void novaObservacao()
         {
             //ComboBoxItem cmbItem = (ComboBoxItem)cmbNome.SelectedItem;
             clientes = new Cliente();
             clientes.ArquivoConexao = sArquivoConexao;
             //if (cmbItem != null)
             if (!bNovo)
             {
                 vTelaPrincipal.abrirCadObservacao(vTelaPrincipal, clientes.pesquisarCliente(iCodigoCliente));
             }
             else
             {
                 MessageBox.Show("Cadastro novo! Não é permitido a inclusão de observação antes da primeira gravação!", "EstacionamentoFacil (FrmPros15)", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                     lstLogradouro = enderecos.pesquisarLogradouro(iCodBairro, 0);
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

        private void cmdNovoRegistro_Click(object sender, EventArgs e)
        {

        }
    }
}
