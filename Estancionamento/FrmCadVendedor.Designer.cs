namespace Estancionamento
{
    partial class FrmCadVendedor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadVendedor));
            this.cmdGravar = new System.Windows.Forms.Button();
            this.cmdFechar = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmbSituacao = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdNovoTelefone = new System.Windows.Forms.Button();
            this.pnlTelefones = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtCPF = new System.Windows.Forms.MaskedTextBox();
            this.cmbNome = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip4 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gridHistorico = new System.Windows.Forms.DataGridView();
            this.CodVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlacaVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.excluirDespesaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtObservacaoTela = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHistorico)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdGravar
            // 
            this.cmdGravar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdGravar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGravar.Image = global::Estancionamento.Properties.Resources.salvar_p;
            this.cmdGravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGravar.Location = new System.Drawing.Point(332, 308);
            this.cmdGravar.Name = "cmdGravar";
            this.cmdGravar.Size = new System.Drawing.Size(90, 30);
            this.cmdGravar.TabIndex = 95;
            this.cmdGravar.Text = "Gravar";
            this.cmdGravar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdGravar.UseVisualStyleBackColor = true;
            this.cmdGravar.Click += new System.EventHandler(this.cmdGravar_Click);
            // 
            // cmdFechar
            // 
            this.cmdFechar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdFechar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFechar.Image = global::Estancionamento.Properties.Resources.cancelar_p;
            this.cmdFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdFechar.Location = new System.Drawing.Point(428, 308);
            this.cmdFechar.Name = "cmdFechar";
            this.cmdFechar.Size = new System.Drawing.Size(90, 30);
            this.cmdFechar.TabIndex = 96;
            this.cmdFechar.Text = "Fechar";
            this.cmdFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdFechar.UseVisualStyleBackColor = true;
            this.cmdFechar.Click += new System.EventHandler(this.cmdFechar_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(506, 290);
            this.tabControl1.TabIndex = 97;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.cmbSituacao);
            this.tabPage1.Controls.Add(this.label20);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtEmail);
            this.tabPage1.Controls.Add(this.txtCPF);
            this.tabPage1.Controls.Add(this.cmbNome);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(498, 264);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cadastro";
            // 
            // cmbSituacao
            // 
            this.cmbSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSituacao.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbSituacao.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSituacao.FormattingEnabled = true;
            this.cmbSituacao.Items.AddRange(new object[] {
            "Ativo",
            "Excluído",
            "Histórico"});
            this.cmbSituacao.Location = new System.Drawing.Point(102, 103);
            this.cmbSituacao.Name = "cmbSituacao";
            this.cmbSituacao.Size = new System.Drawing.Size(112, 24);
            this.cmbSituacao.TabIndex = 102;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(6, 106);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(68, 16);
            this.label20.TabIndex = 103;
            this.label20.Text = "Situação:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdNovoTelefone);
            this.groupBox1.Controls.Add(this.pnlTelefones);
            this.groupBox1.Location = new System.Drawing.Point(12, 133);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(471, 121);
            this.groupBox1.TabIndex = 101;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Telefones:";
            // 
            // cmdNovoTelefone
            // 
            this.cmdNovoTelefone.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdNovoTelefone.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNovoTelefone.Image = global::Estancionamento.Properties.Resources.adicionar;
            this.cmdNovoTelefone.Location = new System.Drawing.Point(419, 72);
            this.cmdNovoTelefone.Name = "cmdNovoTelefone";
            this.cmdNovoTelefone.Size = new System.Drawing.Size(46, 39);
            this.cmdNovoTelefone.TabIndex = 7;
            this.cmdNovoTelefone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.cmdNovoTelefone, "Novo telefone");
            this.cmdNovoTelefone.UseVisualStyleBackColor = true;
            this.cmdNovoTelefone.Click += new System.EventHandler(this.cmdNovoTelefone_Click);
            // 
            // pnlTelefones
            // 
            this.pnlTelefones.Location = new System.Drawing.Point(7, 15);
            this.pnlTelefones.Name = "pnlTelefones";
            this.pnlTelefones.Size = new System.Drawing.Size(406, 96);
            this.pnlTelefones.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 16);
            this.label5.TabIndex = 99;
            this.label5.Text = "E-mail:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 100;
            this.label2.Text = "CPF:";
            // 
            // txtEmail
            // 
            this.txtEmail.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtEmail.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(102, 75);
            this.txtEmail.MaxLength = 200;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(381, 22);
            this.txtEmail.TabIndex = 97;
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // txtCPF
            // 
            this.txtCPF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCPF.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtCPF.Location = new System.Drawing.Point(102, 47);
            this.txtCPF.Mask = "###,###,###-##";
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(112, 22);
            this.txtCPF.TabIndex = 96;
            this.txtCPF.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtCPF.Leave += new System.EventHandler(this.txtCPF_Leave);
            // 
            // cmbNome
            // 
            this.cmbNome.ContextMenuStrip = this.contextMenuStrip4;
            this.cmbNome.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbNome.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNome.FormattingEnabled = true;
            this.cmbNome.Location = new System.Drawing.Point(102, 17);
            this.cmbNome.Name = "cmbNome";
            this.cmbNome.Size = new System.Drawing.Size(381, 24);
            this.cmbNome.TabIndex = 95;
            this.cmbNome.SelectedValueChanged += new System.EventHandler(this.cmbNome_SelectedValueChanged);
            this.cmbNome.Enter += new System.EventHandler(this.cmbNome_Enter);
            this.cmbNome.Leave += new System.EventHandler(this.cmbNome_Leave);
            this.cmbNome.MouseEnter += new System.EventHandler(this.cmbNome_MouseEnter);
            this.cmbNome.MouseLeave += new System.EventHandler(this.cmbNome_MouseLeave);
            // 
            // contextMenuStrip4
            // 
            this.contextMenuStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4});
            this.contextMenuStrip4.Name = "contextMenuStrip1";
            this.contextMenuStrip4.Size = new System.Drawing.Size(214, 26);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(213, 22);
            this.toolStripMenuItem4.Text = "Alterar nome do vendedor";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 98;
            this.label1.Text = "Nome:";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.gridHistorico);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(498, 264);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Histórico de vendas";
            // 
            // gridHistorico
            // 
            this.gridHistorico.AllowUserToAddRows = false;
            this.gridHistorico.AllowUserToDeleteRows = false;
            this.gridHistorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridHistorico.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodVenda,
            this.PlacaVenda,
            this.TipoVenda,
            this.ValorVenda,
            this.DataVenda});
            this.gridHistorico.ContextMenuStrip = this.contextMenuStrip1;
            this.gridHistorico.Location = new System.Drawing.Point(6, 6);
            this.gridHistorico.Name = "gridHistorico";
            this.gridHistorico.ReadOnly = true;
            this.gridHistorico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridHistorico.Size = new System.Drawing.Size(486, 252);
            this.gridHistorico.TabIndex = 1;
            this.gridHistorico.MouseEnter += new System.EventHandler(this.gridHistorico_MouseEnter);
            this.gridHistorico.MouseLeave += new System.EventHandler(this.gridHistorico_MouseLeave);
            // 
            // CodVenda
            // 
            this.CodVenda.HeaderText = "CodVenda";
            this.CodVenda.Name = "CodVenda";
            this.CodVenda.ReadOnly = true;
            this.CodVenda.Visible = false;
            // 
            // PlacaVenda
            // 
            this.PlacaVenda.HeaderText = "Placa";
            this.PlacaVenda.Name = "PlacaVenda";
            this.PlacaVenda.ReadOnly = true;
            // 
            // TipoVenda
            // 
            this.TipoVenda.HeaderText = "Tipo venda";
            this.TipoVenda.Name = "TipoVenda";
            this.TipoVenda.ReadOnly = true;
            // 
            // ValorVenda
            // 
            this.ValorVenda.HeaderText = "Valor";
            this.ValorVenda.Name = "ValorVenda";
            this.ValorVenda.ReadOnly = true;
            // 
            // DataVenda
            // 
            this.DataVenda.HeaderText = "Data";
            this.DataVenda.Name = "DataVenda";
            this.DataVenda.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excluirDespesaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(189, 26);
            // 
            // excluirDespesaToolStripMenuItem
            // 
            this.excluirDespesaToolStripMenuItem.Image = global::Estancionamento.Properties.Resources.carrovenda_p;
            this.excluirDespesaToolStripMenuItem.Name = "excluirDespesaToolStripMenuItem";
            this.excluirDespesaToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.excluirDespesaToolStripMenuItem.Text = "Exibir dados da venda";
            this.excluirDespesaToolStripMenuItem.Click += new System.EventHandler(this.excluirDespesaToolStripMenuItem_Click);
            // 
            // txtObservacaoTela
            // 
            this.txtObservacaoTela.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtObservacaoTela.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtObservacaoTela.BackColor = System.Drawing.SystemColors.Control;
            this.txtObservacaoTela.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtObservacaoTela.Enabled = false;
            this.txtObservacaoTela.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacaoTela.ForeColor = System.Drawing.Color.Blue;
            this.txtObservacaoTela.Location = new System.Drawing.Point(12, 308);
            this.txtObservacaoTela.MaxLength = 50;
            this.txtObservacaoTela.Name = "txtObservacaoTela";
            this.txtObservacaoTela.Size = new System.Drawing.Size(314, 13);
            this.txtObservacaoTela.TabIndex = 108;
            this.txtObservacaoTela.Text = "teste";
            // 
            // FrmCadVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 346);
            this.Controls.Add(this.txtObservacaoTela);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cmdGravar);
            this.Controls.Add(this.cmdFechar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCadVendedor";
            this.Text = "Cadastro de vendedor";
            this.Load += new System.EventHandler(this.FrmCadVendedor_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.contextMenuStrip4.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridHistorico)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdGravar;
        private System.Windows.Forms.Button cmdFechar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox cmbSituacao;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdNovoTelefone;
        private System.Windows.Forms.FlowLayoutPanel pnlTelefones;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.MaskedTextBox txtCPF;
        private System.Windows.Forms.ComboBox cmbNome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView gridHistorico;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlacaVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataVenda;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtObservacaoTela;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem excluirDespesaToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;

    }
}