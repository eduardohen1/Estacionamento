using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Estancionamento.Ativacao
{
    public partial class FrmAtivacaoTelefone : Form
    {
        FrmPrincipal vTelaPrincipal;
        empresa cEmpresa;

        public FrmAtivacaoTelefone(FrmPrincipal vvTelaPrincipal, empresa ccEmpresa)
        {
            InitializeComponent();
            vTelaPrincipal = vvTelaPrincipal;
            cEmpresa = ccEmpresa;
        }

        private void FrmAtivacaoTelefone_Load(object sender, EventArgs e)
        {
            txtChave.Text = gerarChave();
        }

        private string gerarChave()
        {
            string sResposta = "";
            Funcoes cFuncoes = new Funcoes();
            Seguranca cSeguranca = new Seguranca();
            string sNumHD = cFuncoes.GetVolumeSerial("C");
            int iCodCliente = cSeguranca.getCodigoCliente(cFuncoes.retirarPonto(cEmpresa.licenca));
            int iCodSistema = cSeguranca.getCodigoSistema(cFuncoes.retirarPonto(cEmpresa.licenca));
            sResposta = cSeguranca.sCriptografarString(iCodCliente.ToString("D4")) + "." + sNumHD + "." + cSeguranca.sCriptografarString(iCodSistema.ToString("D3"));
            return sResposta;
        }

        private void ativarMicro()
        {
            Funcoes cFuncoes = new Funcoes();
            Seguranca cSeguranca = new Seguranca();
            string sNumHD = cFuncoes.GetVolumeSerial("C");

            if (cSeguranca.validarChaveAtivacao(txtContraChave.Text.Trim(), cFuncoes.retirarPonto(cEmpresa.licenca)))
            {
                vTelaPrincipal.bAtivacaoTelefone = true;
                vTelaPrincipal.sAtivacaoTelefone = cSeguranca.sCriptografarString(cSeguranca.getCodigoCliente(cFuncoes.retirarPonto(cEmpresa.licenca)).ToString("D5")) + "." + cSeguranca.sCriptografarString(sNumHD) + "." + cSeguranca.sCriptografarString("A");
            }
            else
            {
                vTelaPrincipal.bAtivacaoTelefone = true;
                vTelaPrincipal.sAtivacaoTelefone = cSeguranca.sCriptografarString(cSeguranca.getCodigoCliente(cFuncoes.retirarPonto(cEmpresa.licenca)).ToString("D5")) + "." + cSeguranca.sCriptografarString(sNumHD) + "." + cSeguranca.sCriptografarString("N");
            }
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdGravar_Click(object sender, EventArgs e)
        {
            ativarMicro();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Seguranca cSeguranca = new Seguranca();
            txtContraChave.Text = cSeguranca.gerarContraChaveAtivacao(txtChave.Text.Trim());
        }

    }
}
