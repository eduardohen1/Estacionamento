using MetroFramework.Forms;
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
    public partial class FrmTeste : MetroForm //Form
    {
        const int iWidth = 209;

        int vQte;
        TokenInputG.TokenInput token;

        public FrmTeste()
        {
            InitializeComponent();
        }

        private void FrmTeste_Load(object sender, EventArgs e)
        {
            /*tokenInput1.Nome = "Telefone";
            tokenInput1.Texto = "Texto...";
            tokenInput1.Indice = "1";
            tokenInput1.ajustarDadosTela();//*/
            vQte = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           /*
            token = new TokenInputG.TokenInput(this);
            token.Name = "token_" + vQte.ToString();
            token.Nome = "Telefone";
            token.Indice = "Telefone_" + vQte.ToString();
            token.Texto = "novo token " + vQte.ToString();
            token.ajustarDadosTela();
            vQte++;
            flowLayoutPanel1.Controls.Add(token);
            //groupBox1.Controls.Add(token);
            scripts.ControlMover.Init(token);
            * */
        }
    }
}
