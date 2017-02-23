namespace Estancionamento
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cmdLogar = new System.Windows.Forms.ToolStripButton();
            this.cmdSairSistema = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdCadastros = new System.Windows.Forms.ToolStripDropDownButton();
            this.endereçamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empresaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.municípioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localidadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bairroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logradouroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.operadorasTelefoniaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.veículoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marcaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionaisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.carroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.vendasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaDeEsperaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdSuporte = new System.Windows.Forms.ToolStripButton();
            this.cmdCadastroSistema = new System.Windows.Forms.ToolStripDropDownButton();
            this.usuáriosDoSistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdRelatorios = new System.Windows.Forms.ToolStripDropDownButton();
            this.veículosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.veículosCadastradosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.despesasComVeículosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.extratoIndividualDeDespesasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesCadastradosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.vendasToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.vendasPorPeríodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.comissõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdAlterarSenha = new System.Windows.Forms.ToolStripButton();
            this.cmdAbout = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.txtStatus01 = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmdCadCliente = new System.Windows.Forms.ToolStripButton();
            this.cmdCadVeiculos = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdLancarDespesas = new System.Windows.Forms.ToolStripButton();
            this.cmdLancarVenda = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdAuditoria = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdBackup = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdLogar,
            this.cmdSairSistema,
            this.toolStripSeparator1,
            this.cmdCadastros,
            this.cmdSuporte,
            this.cmdCadastroSistema,
            this.cmdRelatorios,
            this.toolStripSeparator4,
            this.cmdAlterarSenha,
            this.cmdAbout});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            // 
            // cmdLogar
            // 
            this.cmdLogar.Image = global::Estancionamento.Properties.Resources.login1;
            resources.ApplyResources(this.cmdLogar, "cmdLogar");
            this.cmdLogar.Name = "cmdLogar";
            this.cmdLogar.Click += new System.EventHandler(this.cmdLogar_Click);
            // 
            // cmdSairSistema
            // 
            this.cmdSairSistema.Image = global::Estancionamento.Properties.Resources.logout;
            resources.ApplyResources(this.cmdSairSistema, "cmdSairSistema");
            this.cmdSairSistema.Name = "cmdSairSistema";
            this.cmdSairSistema.Click += new System.EventHandler(this.cmdSairSistema_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // cmdCadastros
            // 
            this.cmdCadastros.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.endereçamentoToolStripMenuItem,
            this.veículoToolStripMenuItem,
            this.vendasToolStripMenuItem,
            this.toolStripMenuItem2,
            this.clienteToolStripMenuItem,
            this.listaDeEsperaToolStripMenuItem});
            this.cmdCadastros.Image = global::Estancionamento.Properties.Resources.cadastrog2;
            resources.ApplyResources(this.cmdCadastros, "cmdCadastros");
            this.cmdCadastros.Name = "cmdCadastros";
            // 
            // endereçamentoToolStripMenuItem
            // 
            this.endereçamentoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.empresaToolStripMenuItem,
            this.toolStripMenuItem9,
            this.municípioToolStripMenuItem,
            this.localidadeToolStripMenuItem,
            this.bairroToolStripMenuItem,
            this.logradouroToolStripMenuItem,
            this.toolStripMenuItem4,
            this.operadorasTelefoniaToolStripMenuItem});
            this.endereçamentoToolStripMenuItem.Name = "endereçamentoToolStripMenuItem";
            resources.ApplyResources(this.endereçamentoToolStripMenuItem, "endereçamentoToolStripMenuItem");
            // 
            // empresaToolStripMenuItem
            // 
            this.empresaToolStripMenuItem.Name = "empresaToolStripMenuItem";
            resources.ApplyResources(this.empresaToolStripMenuItem, "empresaToolStripMenuItem");
            this.empresaToolStripMenuItem.Click += new System.EventHandler(this.empresaToolStripMenuItem_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            resources.ApplyResources(this.toolStripMenuItem9, "toolStripMenuItem9");
            // 
            // municípioToolStripMenuItem
            // 
            this.municípioToolStripMenuItem.Name = "municípioToolStripMenuItem";
            resources.ApplyResources(this.municípioToolStripMenuItem, "municípioToolStripMenuItem");
            this.municípioToolStripMenuItem.Click += new System.EventHandler(this.municípioToolStripMenuItem_Click);
            // 
            // localidadeToolStripMenuItem
            // 
            this.localidadeToolStripMenuItem.Name = "localidadeToolStripMenuItem";
            resources.ApplyResources(this.localidadeToolStripMenuItem, "localidadeToolStripMenuItem");
            this.localidadeToolStripMenuItem.Click += new System.EventHandler(this.localidadeToolStripMenuItem_Click);
            // 
            // bairroToolStripMenuItem
            // 
            this.bairroToolStripMenuItem.Name = "bairroToolStripMenuItem";
            resources.ApplyResources(this.bairroToolStripMenuItem, "bairroToolStripMenuItem");
            this.bairroToolStripMenuItem.Click += new System.EventHandler(this.bairroToolStripMenuItem_Click);
            // 
            // logradouroToolStripMenuItem
            // 
            this.logradouroToolStripMenuItem.Name = "logradouroToolStripMenuItem";
            resources.ApplyResources(this.logradouroToolStripMenuItem, "logradouroToolStripMenuItem");
            this.logradouroToolStripMenuItem.Click += new System.EventHandler(this.logradouroToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
            // 
            // operadorasTelefoniaToolStripMenuItem
            // 
            this.operadorasTelefoniaToolStripMenuItem.Name = "operadorasTelefoniaToolStripMenuItem";
            resources.ApplyResources(this.operadorasTelefoniaToolStripMenuItem, "operadorasTelefoniaToolStripMenuItem");
            this.operadorasTelefoniaToolStripMenuItem.Click += new System.EventHandler(this.operadorasTelefoniaToolStripMenuItem_Click);
            // 
            // veículoToolStripMenuItem
            // 
            this.veículoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.marcaToolStripMenuItem,
            this.opcionaisToolStripMenuItem,
            this.toolStripMenuItem1,
            this.carroToolStripMenuItem});
            this.veículoToolStripMenuItem.Name = "veículoToolStripMenuItem";
            resources.ApplyResources(this.veículoToolStripMenuItem, "veículoToolStripMenuItem");
            // 
            // marcaToolStripMenuItem
            // 
            this.marcaToolStripMenuItem.Name = "marcaToolStripMenuItem";
            resources.ApplyResources(this.marcaToolStripMenuItem, "marcaToolStripMenuItem");
            this.marcaToolStripMenuItem.Click += new System.EventHandler(this.marcaToolStripMenuItem_Click);
            // 
            // opcionaisToolStripMenuItem
            // 
            this.opcionaisToolStripMenuItem.Name = "opcionaisToolStripMenuItem";
            resources.ApplyResources(this.opcionaisToolStripMenuItem, "opcionaisToolStripMenuItem");
            this.opcionaisToolStripMenuItem.Click += new System.EventHandler(this.opcionaisToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // carroToolStripMenuItem
            // 
            this.carroToolStripMenuItem.Name = "carroToolStripMenuItem";
            resources.ApplyResources(this.carroToolStripMenuItem, "carroToolStripMenuItem");
            this.carroToolStripMenuItem.Click += new System.EventHandler(this.carroToolStripMenuItem_Click);
            // 
            // vendasToolStripMenuItem
            // 
            this.vendasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vendedorToolStripMenuItem,
            this.toolStripMenuItem3,
            this.vendasToolStripMenuItem1});
            this.vendasToolStripMenuItem.Name = "vendasToolStripMenuItem";
            resources.ApplyResources(this.vendasToolStripMenuItem, "vendasToolStripMenuItem");
            // 
            // vendedorToolStripMenuItem
            // 
            this.vendedorToolStripMenuItem.Name = "vendedorToolStripMenuItem";
            resources.ApplyResources(this.vendedorToolStripMenuItem, "vendedorToolStripMenuItem");
            this.vendedorToolStripMenuItem.Click += new System.EventHandler(this.vendedorToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            // 
            // vendasToolStripMenuItem1
            // 
            this.vendasToolStripMenuItem1.Name = "vendasToolStripMenuItem1";
            resources.ApplyResources(this.vendasToolStripMenuItem1, "vendasToolStripMenuItem1");
            this.vendasToolStripMenuItem1.Click += new System.EventHandler(this.vendasToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            resources.ApplyResources(this.clienteToolStripMenuItem, "clienteToolStripMenuItem");
            this.clienteToolStripMenuItem.Click += new System.EventHandler(this.clienteToolStripMenuItem_Click);
            // 
            // listaDeEsperaToolStripMenuItem
            // 
            this.listaDeEsperaToolStripMenuItem.Name = "listaDeEsperaToolStripMenuItem";
            resources.ApplyResources(this.listaDeEsperaToolStripMenuItem, "listaDeEsperaToolStripMenuItem");
            // 
            // cmdSuporte
            // 
            this.cmdSuporte.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmdSuporte.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdSuporte.Image = global::Estancionamento.Properties.Resources.suporte1;
            resources.ApplyResources(this.cmdSuporte, "cmdSuporte");
            this.cmdSuporte.Name = "cmdSuporte";
            this.cmdSuporte.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // cmdCadastroSistema
            // 
            this.cmdCadastroSistema.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuáriosDoSistemaToolStripMenuItem});
            this.cmdCadastroSistema.Image = global::Estancionamento.Properties.Resources.cadastrog;
            resources.ApplyResources(this.cmdCadastroSistema, "cmdCadastroSistema");
            this.cmdCadastroSistema.Name = "cmdCadastroSistema";
            // 
            // usuáriosDoSistemaToolStripMenuItem
            // 
            this.usuáriosDoSistemaToolStripMenuItem.Name = "usuáriosDoSistemaToolStripMenuItem";
            resources.ApplyResources(this.usuáriosDoSistemaToolStripMenuItem, "usuáriosDoSistemaToolStripMenuItem");
            this.usuáriosDoSistemaToolStripMenuItem.Click += new System.EventHandler(this.usuáriosDoSistemaToolStripMenuItem_Click);
            // 
            // cmdRelatorios
            // 
            this.cmdRelatorios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.veículosToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.toolStripMenuItem5,
            this.vendasToolStripMenuItem2});
            this.cmdRelatorios.Image = global::Estancionamento.Properties.Resources.report;
            resources.ApplyResources(this.cmdRelatorios, "cmdRelatorios");
            this.cmdRelatorios.Name = "cmdRelatorios";
            // 
            // veículosToolStripMenuItem
            // 
            this.veículosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.veículosCadastradosToolStripMenuItem,
            this.despesasComVeículosToolStripMenuItem,
            this.toolStripMenuItem7,
            this.extratoIndividualDeDespesasToolStripMenuItem});
            this.veículosToolStripMenuItem.Name = "veículosToolStripMenuItem";
            resources.ApplyResources(this.veículosToolStripMenuItem, "veículosToolStripMenuItem");
            // 
            // veículosCadastradosToolStripMenuItem
            // 
            this.veículosCadastradosToolStripMenuItem.Name = "veículosCadastradosToolStripMenuItem";
            resources.ApplyResources(this.veículosCadastradosToolStripMenuItem, "veículosCadastradosToolStripMenuItem");
            this.veículosCadastradosToolStripMenuItem.Click += new System.EventHandler(this.veículosCadastradosToolStripMenuItem_Click);
            // 
            // despesasComVeículosToolStripMenuItem
            // 
            this.despesasComVeículosToolStripMenuItem.Name = "despesasComVeículosToolStripMenuItem";
            resources.ApplyResources(this.despesasComVeículosToolStripMenuItem, "despesasComVeículosToolStripMenuItem");
            this.despesasComVeículosToolStripMenuItem.Click += new System.EventHandler(this.despesasComVeículosToolStripMenuItem_Click_1);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            resources.ApplyResources(this.toolStripMenuItem7, "toolStripMenuItem7");
            // 
            // extratoIndividualDeDespesasToolStripMenuItem
            // 
            this.extratoIndividualDeDespesasToolStripMenuItem.Name = "extratoIndividualDeDespesasToolStripMenuItem";
            resources.ApplyResources(this.extratoIndividualDeDespesasToolStripMenuItem, "extratoIndividualDeDespesasToolStripMenuItem");
            this.extratoIndividualDeDespesasToolStripMenuItem.Click += new System.EventHandler(this.extratoIndividualDeDespesasToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesCadastradosToolStripMenuItem});
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            resources.ApplyResources(this.clientesToolStripMenuItem, "clientesToolStripMenuItem");
            // 
            // clientesCadastradosToolStripMenuItem
            // 
            this.clientesCadastradosToolStripMenuItem.Name = "clientesCadastradosToolStripMenuItem";
            resources.ApplyResources(this.clientesCadastradosToolStripMenuItem, "clientesCadastradosToolStripMenuItem");
            this.clientesCadastradosToolStripMenuItem.Click += new System.EventHandler(this.clientesCadastradosToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            resources.ApplyResources(this.toolStripMenuItem5, "toolStripMenuItem5");
            // 
            // vendasToolStripMenuItem2
            // 
            this.vendasToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vendasPorPeríodoToolStripMenuItem,
            this.toolStripMenuItem6,
            this.comissõesToolStripMenuItem});
            this.vendasToolStripMenuItem2.Name = "vendasToolStripMenuItem2";
            resources.ApplyResources(this.vendasToolStripMenuItem2, "vendasToolStripMenuItem2");
            // 
            // vendasPorPeríodoToolStripMenuItem
            // 
            this.vendasPorPeríodoToolStripMenuItem.Name = "vendasPorPeríodoToolStripMenuItem";
            resources.ApplyResources(this.vendasPorPeríodoToolStripMenuItem, "vendasPorPeríodoToolStripMenuItem");
            this.vendasPorPeríodoToolStripMenuItem.Click += new System.EventHandler(this.vendasPorPeríodoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            resources.ApplyResources(this.toolStripMenuItem6, "toolStripMenuItem6");
            // 
            // comissõesToolStripMenuItem
            // 
            this.comissõesToolStripMenuItem.Name = "comissõesToolStripMenuItem";
            resources.ApplyResources(this.comissõesToolStripMenuItem, "comissõesToolStripMenuItem");
            this.comissõesToolStripMenuItem.Click += new System.EventHandler(this.comissõesToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // cmdAlterarSenha
            // 
            this.cmdAlterarSenha.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmdAlterarSenha.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdAlterarSenha.Image = global::Estancionamento.Properties.Resources.login;
            resources.ApplyResources(this.cmdAlterarSenha, "cmdAlterarSenha");
            this.cmdAlterarSenha.Name = "cmdAlterarSenha";
            this.cmdAlterarSenha.Click += new System.EventHandler(this.cmdAlterarSenha_Click);
            // 
            // cmdAbout
            // 
            this.cmdAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmdAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdAbout.Image = global::Estancionamento.Properties.Resources.information_icon;
            resources.ApplyResources(this.cmdAbout, "cmdAbout");
            this.cmdAbout.Name = "cmdAbout";
            this.cmdAbout.Click += new System.EventHandler(this.cmdAbout_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtStatus01});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            // 
            // txtStatus01
            // 
            this.txtStatus01.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.txtStatus01, "txtStatus01");
            this.txtStatus01.Name = "txtStatus01";
            // 
            // cmdCadCliente
            // 
            this.cmdCadCliente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdCadCliente.Image = global::Estancionamento.Properties.Resources.usuario_g;
            resources.ApplyResources(this.cmdCadCliente, "cmdCadCliente");
            this.cmdCadCliente.Name = "cmdCadCliente";
            this.cmdCadCliente.Click += new System.EventHandler(this.cmdCadCliente_Click);
            // 
            // cmdCadVeiculos
            // 
            this.cmdCadVeiculos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.cmdCadVeiculos, "cmdCadVeiculos");
            this.cmdCadVeiculos.Name = "cmdCadVeiculos";
            this.cmdCadVeiculos.Click += new System.EventHandler(this.cmdCadVeiculos_Click_1);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // cmdLancarDespesas
            // 
            this.cmdLancarDespesas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdLancarDespesas.Image = global::Estancionamento.Properties.Resources.despesas_g;
            resources.ApplyResources(this.cmdLancarDespesas, "cmdLancarDespesas");
            this.cmdLancarDespesas.Name = "cmdLancarDespesas";
            this.cmdLancarDespesas.Click += new System.EventHandler(this.despesasComVeículosToolStripMenuItem_Click);
            // 
            // cmdLancarVenda
            // 
            this.cmdLancarVenda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdLancarVenda.Image = global::Estancionamento.Properties.Resources.carrovenda_m;
            resources.ApplyResources(this.cmdLancarVenda, "cmdLancarVenda");
            this.cmdLancarVenda.Name = "cmdLancarVenda";
            this.cmdLancarVenda.Click += new System.EventHandler(this.vendasToolStripMenuItem1_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // cmdAuditoria
            // 
            this.cmdAuditoria.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdAuditoria.Image = global::Estancionamento.Properties.Resources.auditoria_g;
            resources.ApplyResources(this.cmdAuditoria, "cmdAuditoria");
            this.cmdAuditoria.Name = "cmdAuditoria";
            this.cmdAuditoria.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // cmdBackup
            // 
            this.cmdBackup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdBackup.Image = global::Estancionamento.Properties.Resources.backup_g;
            resources.ApplyResources(this.cmdBackup, "cmdBackup");
            this.cmdBackup.Name = "cmdBackup";
            this.cmdBackup.Click += new System.EventHandler(this.cmdBackup_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.toolStrip2, "toolStrip2");
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdCadCliente,
            this.cmdCadVeiculos,
            this.toolStripSeparator2,
            this.cmdLancarDespesas,
            this.cmdLancarVenda,
            this.toolStripSeparator3,
            this.cmdAuditoria,
            this.toolStripButton1,
            this.toolStripSeparator5,
            this.cmdBackup});
            this.toolStrip2.Name = "toolStrip2";
            // 
            // FrmPrincipal
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Estancionamento.Properties.Resources.EstancionamentoFacil;
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.IsMdiContainer = true;
            this.Name = "FrmPrincipal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton cmdCadastros;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem endereçamentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem municípioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localidadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bairroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logradouroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem veículoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marcaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opcionaisToolStripMenuItem;
        //private System.Windows.Forms.ToolStripButton cmdLogar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton cmdSairSistema;
        private System.Windows.Forms.ToolStripButton cmdSuporte;
        /*private System.Windows.Forms.RibbonButton ribbonButton4;
        private System.Windows.Forms.RibbonButton ribbonButton5;
        private System.Windows.Forms.RibbonButton ribbonButton3;*/
        private System.Windows.Forms.ToolStripStatusLabel txtStatus01;
        private System.Windows.Forms.ToolStripButton cmdLogar;
        private System.Windows.Forms.ToolStripMenuItem operadorasTelefoniaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem carroToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem vendasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vendedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem vendasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripDropDownButton cmdCadastroSistema;
        private System.Windows.Forms.ToolStripMenuItem usuáriosDoSistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton cmdAlterarSenha;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripDropDownButton cmdRelatorios;
        private System.Windows.Forms.ToolStripMenuItem veículosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem veículosCadastradosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem despesasComVeículosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem extratoIndividualDeDespesasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesCadastradosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem vendasToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem vendasPorPeríodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem comissõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem empresaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton cmdAbout;
        private System.Windows.Forms.ToolStripButton cmdCadCliente;
        private System.Windows.Forms.ToolStripButton cmdCadVeiculos;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton cmdLancarDespesas;
        private System.Windows.Forms.ToolStripButton cmdLancarVenda;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton cmdAuditoria;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton cmdBackup;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripMenuItem listaDeEsperaToolStripMenuItem;
    }
}