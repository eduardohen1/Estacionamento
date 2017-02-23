using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace TokenInputG
{
    public partial class TokenInput : UserControl
    {
        Estancionamento.FrmPrincipal vTela;

        public TokenInput(Estancionamento.FrmPrincipal vvTela)
        {
            InitializeComponent();
            vTela = vvTela;
        }

        private void TokenInput_Load(object sender, EventArgs e)
        {
            /*GraphicsPath graPath = new GraphicsPath();
            graPath.AddEllipse(new System.Drawing.RectangleF(100, 100, 200, 200));
            this.Region = new System.Drawing.Region(graPath);//*/            
        }

        private void lblFechar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir este " + Nome + "?", "Excluir " + Nome, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                lblFechar.Visible = false;
                Excluir = true;
                this.BackColor = Color.FromArgb(255, 192, 192);
            }
        }

        public void ajustarDadosTela()
        {
            Excluir = false;
            lblTexto.Text = Texto;
            toolTip1.SetToolTip(lblFechar, "Excluir este " + Nome);
            toolTip1.SetToolTip(cmdLink, textoLink);
            cmdLink.Visible = ExibirLink;
            if (ModificarCor)
            {
                //this.BackColor = new Color(CorFundo);
                this.lblTexto.ForeColor = Color.White;
            }
        }

        protected override Size DefaultSize { 
            get
            {
                return base.DefaultSize;
            }
        }

        [System.ComponentModel.DefaultValue("Ítem")]
        public string Nome { get; set; }

        public string Texto { get; set; }
        public string Indice { get; set; }
        public bool Excluir { get; set; }
        public bool ExibirLink { get; set; }
        public string Link { get; set; }
        public string textoLink { get; set; }

        [System.ComponentModel.DefaultValue(false)]
        public bool ModificarCor { get; set; }

        [System.ComponentModel.DefaultValue("")]
        public string CorFundo { get; set; }

        private void cmdLink_Click(object sender, EventArgs e)
        {
            vTela.dispararLinkToken(Link);
        }

    }
}
