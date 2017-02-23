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
    public partial class FrmSuportes : Form
    {
        private FrmPrincipal vFrmPrincipal;
        public FrmSuportes(FrmPrincipal frmPrincipal)
        {
            InitializeComponent();
            vFrmPrincipal = frmPrincipal;
        }

        private void FrmSuportes_Load(object sender, EventArgs e)
        {
            cmdOK.Focus();
            CamadaDados vConexao = new CamadaDados();
            if (vConexao.buscarDadosConexao(vFrmPrincipal.sEnderecoArquivoConexao))
            {
                if (vConexao.Conectar(vConexao.vvServidor, vConexao.vvDataBase, vConexao.vvUser, vConexao.vvPass, vConexao.vvPorta))
                {
                    vConexao.inserirAuditoria(15, vFrmPrincipal.vvCodigoUsuario, "Tela de suporte", "");
                }
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (rdoSuporte.Checked)
            {
                vFrmPrincipal.abrirSuporte01(vFrmPrincipal);
                this.Close();
            }
            if (rdoSuporte02.Checked)
            {
                vFrmPrincipal.abrirConfiguraConexao();
                this.Close();
            }
            if (rdoSuporte03.Checked)
            {

            }
        }
    }
}
