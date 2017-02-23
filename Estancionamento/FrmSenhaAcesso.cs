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
    public partial class FrmSenhaAcesso : Form
    {
        FrmPrincipal vvFrmPrincipal;
        byte vvForm;
        
        public FrmSenhaAcesso(byte vForm, FrmPrincipal vFrmPrincipal)
        {
            InitializeComponent();
            vvForm = vForm;
            vvFrmPrincipal = vFrmPrincipal;
        }

        private void FrmSenhaAcesso_Load(object sender, EventArgs e)
        {
            Funcoes fFuncoes = new Funcoes();
            txtChave.Text = fFuncoes.geraSenhaAcesso(vvFrmPrincipal);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtContraChave.Text.Length > 0)
            {
                Funcoes fFuncoes = new Funcoes();
                if (fFuncoes.validarSenhaAcesso(txtContraChave.Text, txtChave.Text))
                {
                    switch (vvForm)
                    {
                        case 0:
                            vvFrmPrincipal.abrirSuportes();
                            break;
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Senha de validação inválida!", "EstacionamentoFacil (fSA02)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Digite a contra-chave para validação!" , "EstacionamentoFacil (fSA01)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
    }
}
