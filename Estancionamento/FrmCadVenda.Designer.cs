namespace Estancionamento
{
    partial class FrmCadVenda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadVenda));
            this.cmdGravar = new System.Windows.Forms.Button();
            this.cmdFechar = new System.Windows.Forms.Button();
            this.txtObservacaoTela = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmbSituacao = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbVenda = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbVeiculo = new System.Windows.Forms.ComboBox();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.cmbClienteComprador = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbClienteVendedor = new System.Windows.Forms.ComboBox();
            this.txtValorVenda = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTipoVenda = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtDescritivoComissao = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdNovaComissao = new System.Windows.Forms.Button();
            this.gridVendedor = new System.Windows.Forms.DataGridView();
            this.CodVendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorComissao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SituacaoComissao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.novaComissãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarComissãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.gridObservacao = new System.Windows.Forms.DataGridView();
            this.CodObservacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Observacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.novaObservaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.cmdLocalizar = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridVendedor)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridObservacao)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdGravar
            // 
            this.cmdGravar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdGravar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGravar.Image = global::Estancionamento.Properties.Resources.salvar_p;
            this.cmdGravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGravar.Location = new System.Drawing.Point(597, 198);
            this.cmdGravar.Name = "cmdGravar";
            this.cmdGravar.Size = new System.Drawing.Size(90, 30);
            this.cmdGravar.TabIndex = 11;
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
            this.cmdFechar.Location = new System.Drawing.Point(693, 198);
            this.cmdFechar.Name = "cmdFechar";
            this.cmdFechar.Size = new System.Drawing.Size(90, 30);
            this.cmdFechar.TabIndex = 12;
            this.cmdFechar.Text = "Fechar";
            this.cmdFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdFechar.UseVisualStyleBackColor = true;
            this.cmdFechar.Click += new System.EventHandler(this.cmdFechar_Click);
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
            this.txtObservacaoTela.Location = new System.Drawing.Point(12, 198);
            this.txtObservacaoTela.MaxLength = 50;
            this.txtObservacaoTela.Name = "txtObservacaoTela";
            this.txtObservacaoTela.Size = new System.Drawing.Size(579, 13);
            this.txtObservacaoTela.TabIndex = 106;
            this.txtObservacaoTela.Text = "teste";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(771, 180);
            this.tabControl1.TabIndex = 107;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.cmbSituacao);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.cmbVenda);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.cmbVeiculo);
            this.tabPage1.Controls.Add(this.txtObservacao);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtModelo);
            this.tabPage1.Controls.Add(this.cmbClienteComprador);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cmbClienteVendedor);
            this.tabPage1.Controls.Add(this.txtValorVenda);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.cmbTipoVenda);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(763, 154);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Venda";
            // 
            // cmbSituacao
            // 
            this.cmbSituacao.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbSituacao.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSituacao.FormattingEnabled = true;
            this.cmbSituacao.Location = new System.Drawing.Point(142, 100);
            this.cmbSituacao.MaxLength = 7;
            this.cmbSituacao.Name = "cmbSituacao";
            this.cmbSituacao.Size = new System.Drawing.Size(118, 24);
            this.cmbSituacao.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 16);
            this.label10.TabIndex = 109;
            this.label10.Text = "Situação:";
            // 
            // cmbVenda
            // 
            this.cmbVenda.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbVenda.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVenda.FormattingEnabled = true;
            this.cmbVenda.Location = new System.Drawing.Point(142, 8);
            this.cmbVenda.MaxLength = 7;
            this.cmbVenda.Name = "cmbVenda";
            this.cmbVenda.Size = new System.Drawing.Size(118, 24);
            this.cmbVenda.TabIndex = 0;
            this.cmbVenda.SelectedValueChanged += new System.EventHandler(this.cmbVenda_SelectedValueChanged);
            this.cmbVenda.Enter += new System.EventHandler(this.cmbVenda_Enter);
            this.cmbVenda.Leave += new System.EventHandler(this.cmbVenda_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 16);
            this.label7.TabIndex = 107;
            this.label7.Text = "Venda:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(474, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 16);
            this.label8.TabIndex = 106;
            this.label8.Text = "Marca/Modelo:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(261, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 16);
            this.label9.TabIndex = 105;
            this.label9.Text = "Observação:";
            // 
            // cmbVeiculo
            // 
            this.cmbVeiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVeiculo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbVeiculo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVeiculo.FormattingEnabled = true;
            this.cmbVeiculo.Location = new System.Drawing.Point(326, 8);
            this.cmbVeiculo.Name = "cmbVeiculo";
            this.cmbVeiculo.Size = new System.Drawing.Size(135, 24);
            this.cmbVeiculo.TabIndex = 1;
            this.cmbVeiculo.Leave += new System.EventHandler(this.cmbVeiculo_Leave);
            // 
            // txtObservacao
            // 
            this.txtObservacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtObservacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtObservacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservacao.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacao.Location = new System.Drawing.Point(354, 100);
            this.txtObservacao.MaxLength = 50;
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacao.Size = new System.Drawing.Size(398, 48);
            this.txtObservacao.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(261, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 105;
            this.label1.Text = "Veículo:";
            // 
            // txtModelo
            // 
            this.txtModelo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtModelo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtModelo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtModelo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModelo.Enabled = false;
            this.txtModelo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModelo.Location = new System.Drawing.Point(582, 10);
            this.txtModelo.MaxLength = 50;
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(170, 22);
            this.txtModelo.TabIndex = 100;
            // 
            // cmbClienteComprador
            // 
            this.cmbClienteComprador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClienteComprador.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbClienteComprador.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClienteComprador.FormattingEnabled = true;
            this.cmbClienteComprador.Location = new System.Drawing.Point(142, 70);
            this.cmbClienteComprador.Name = "cmbClienteComprador";
            this.cmbClienteComprador.Size = new System.Drawing.Size(319, 24);
            this.cmbClienteComprador.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Cliente vendedor:";
            // 
            // cmbClienteVendedor
            // 
            this.cmbClienteVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClienteVendedor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbClienteVendedor.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClienteVendedor.FormattingEnabled = true;
            this.cmbClienteVendedor.Location = new System.Drawing.Point(142, 40);
            this.cmbClienteVendedor.Name = "cmbClienteVendedor";
            this.cmbClienteVendedor.Size = new System.Drawing.Size(319, 24);
            this.cmbClienteVendedor.TabIndex = 2;
            // 
            // txtValorVenda
            // 
            this.txtValorVenda.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtValorVenda.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtValorVenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtValorVenda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValorVenda.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorVenda.Location = new System.Drawing.Point(582, 72);
            this.txtValorVenda.MaxLength = 50;
            this.txtValorVenda.Name = "txtValorVenda";
            this.txtValorVenda.Size = new System.Drawing.Size(170, 22);
            this.txtValorVenda.TabIndex = 5;
            this.txtValorVenda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValorVenda_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "Cliente comprador:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(467, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 16);
            this.label5.TabIndex = 36;
            this.label5.Text = "Valor da venda:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(467, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "Tipo de venda:";
            // 
            // cmbTipoVenda
            // 
            this.cmbTipoVenda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoVenda.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbTipoVenda.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoVenda.FormattingEnabled = true;
            this.cmbTipoVenda.Location = new System.Drawing.Point(582, 40);
            this.cmbTipoVenda.Name = "cmbTipoVenda";
            this.cmbTipoVenda.Size = new System.Drawing.Size(170, 24);
            this.cmbTipoVenda.TabIndex = 3;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.txtDescritivoComissao);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(763, 154);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Comissão";
            // 
            // txtDescritivoComissao
            // 
            this.txtDescritivoComissao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtDescritivoComissao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtDescritivoComissao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescritivoComissao.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescritivoComissao.Location = new System.Drawing.Point(163, 6);
            this.txtDescritivoComissao.MaxLength = 50;
            this.txtDescritivoComissao.Name = "txtDescritivoComissao";
            this.txtDescritivoComissao.Size = new System.Drawing.Size(594, 22);
            this.txtDescritivoComissao.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 16);
            this.label6.TabIndex = 38;
            this.label6.Text = "Descritivo de comissão:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdNovaComissao);
            this.groupBox1.Controls.Add(this.gridVendedor);
            this.groupBox1.Location = new System.Drawing.Point(237, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(520, 123);
            this.groupBox1.TabIndex = 99;
            this.groupBox1.TabStop = false;
            // 
            // cmdNovaComissao
            // 
            this.cmdNovaComissao.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdNovaComissao.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNovaComissao.Image = global::Estancionamento.Properties.Resources.adicionar;
            this.cmdNovaComissao.Location = new System.Drawing.Point(468, 78);
            this.cmdNovaComissao.Name = "cmdNovaComissao";
            this.cmdNovaComissao.Size = new System.Drawing.Size(46, 39);
            this.cmdNovaComissao.TabIndex = 9;
            this.cmdNovaComissao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.cmdNovaComissao, "Adicionar nova comissão");
            this.cmdNovaComissao.UseVisualStyleBackColor = true;
            this.cmdNovaComissao.Click += new System.EventHandler(this.cmdNovaComissao_Click);
            // 
            // gridVendedor
            // 
            this.gridVendedor.AllowUserToAddRows = false;
            this.gridVendedor.AllowUserToDeleteRows = false;
            this.gridVendedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridVendedor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodVendedor,
            this.CodVenda,
            this.Vendedor,
            this.ValorComissao,
            this.SituacaoComissao});
            this.gridVendedor.ContextMenuStrip = this.contextMenuStrip1;
            this.gridVendedor.Location = new System.Drawing.Point(6, 10);
            this.gridVendedor.Name = "gridVendedor";
            this.gridVendedor.ReadOnly = true;
            this.gridVendedor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridVendedor.Size = new System.Drawing.Size(456, 107);
            this.gridVendedor.TabIndex = 40;
            this.gridVendedor.MouseEnter += new System.EventHandler(this.gridVendedor_MouseEnter);
            this.gridVendedor.MouseLeave += new System.EventHandler(this.gridVendedor_MouseLeave);
            // 
            // CodVendedor
            // 
            this.CodVendedor.HeaderText = "CodVendedor";
            this.CodVendedor.Name = "CodVendedor";
            this.CodVendedor.ReadOnly = true;
            this.CodVendedor.Visible = false;
            // 
            // CodVenda
            // 
            this.CodVenda.HeaderText = "CodVenda";
            this.CodVenda.Name = "CodVenda";
            this.CodVenda.ReadOnly = true;
            this.CodVenda.Visible = false;
            // 
            // Vendedor
            // 
            this.Vendedor.HeaderText = "Vendedor";
            this.Vendedor.Name = "Vendedor";
            this.Vendedor.ReadOnly = true;
            this.Vendedor.Width = 200;
            // 
            // ValorComissao
            // 
            this.ValorComissao.HeaderText = "Valor comissão";
            this.ValorComissao.Name = "ValorComissao";
            this.ValorComissao.ReadOnly = true;
            // 
            // SituacaoComissao
            // 
            this.SituacaoComissao.HeaderText = "Situação";
            this.SituacaoComissao.Name = "SituacaoComissao";
            this.SituacaoComissao.ReadOnly = true;
            this.SituacaoComissao.Width = 80;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novaComissãoToolStripMenuItem,
            this.editarComissãoToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripMenuItem4});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(162, 76);
            // 
            // novaComissãoToolStripMenuItem
            // 
            this.novaComissãoToolStripMenuItem.Image = global::Estancionamento.Properties.Resources.adicionar;
            this.novaComissãoToolStripMenuItem.Name = "novaComissãoToolStripMenuItem";
            this.novaComissãoToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.novaComissãoToolStripMenuItem.Text = "Nova comissão";
            this.novaComissãoToolStripMenuItem.Click += new System.EventHandler(this.novaComissãoToolStripMenuItem_Click);
            // 
            // editarComissãoToolStripMenuItem
            // 
            this.editarComissãoToolStripMenuItem.Name = "editarComissãoToolStripMenuItem";
            this.editarComissãoToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.editarComissãoToolStripMenuItem.Text = "Editar comissão";
            this.editarComissãoToolStripMenuItem.Click += new System.EventHandler(this.editarComissãoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(158, 6);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Image = global::Estancionamento.Properties.Resources._1322_128x128;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(161, 22);
            this.toolStripMenuItem4.Text = "Excluir comissão";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.excluirComissãoToolStripMenuItem_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.gridObservacao);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(763, 154);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Observação";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::Estancionamento.Properties.Resources.adicionar;
            this.button1.Location = new System.Drawing.Point(711, 109);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 39);
            this.button1.TabIndex = 25;
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.button1, "Adicionar nova observação");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.cmdNovaObservacao_Click);
            // 
            // gridObservacao
            // 
            this.gridObservacao.AllowUserToAddRows = false;
            this.gridObservacao.AllowUserToDeleteRows = false;
            this.gridObservacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridObservacao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodObservacao,
            this.Observacao,
            this.Usuario,
            this.CodUsuario,
            this.DataH});
            this.gridObservacao.ContextMenuStrip = this.contextMenuStrip2;
            this.gridObservacao.Location = new System.Drawing.Point(6, 6);
            this.gridObservacao.Name = "gridObservacao";
            this.gridObservacao.ReadOnly = true;
            this.gridObservacao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridObservacao.Size = new System.Drawing.Size(699, 142);
            this.gridObservacao.TabIndex = 24;
            this.gridObservacao.MouseEnter += new System.EventHandler(this.gridObservacao_MouseEnter);
            this.gridObservacao.MouseLeave += new System.EventHandler(this.gridObservacao_MouseLeave);
            // 
            // CodObservacao
            // 
            this.CodObservacao.HeaderText = "CodObservacao";
            this.CodObservacao.Name = "CodObservacao";
            this.CodObservacao.ReadOnly = true;
            this.CodObservacao.Visible = false;
            // 
            // Observacao
            // 
            this.Observacao.HeaderText = "Observação";
            this.Observacao.Name = "Observacao";
            this.Observacao.ReadOnly = true;
            this.Observacao.Width = 350;
            // 
            // Usuario
            // 
            this.Usuario.HeaderText = "Usuário";
            this.Usuario.Name = "Usuario";
            this.Usuario.ReadOnly = true;
            this.Usuario.Width = 150;
            // 
            // CodUsuario
            // 
            this.CodUsuario.HeaderText = "CodUsuario";
            this.CodUsuario.Name = "CodUsuario";
            this.CodUsuario.ReadOnly = true;
            this.CodUsuario.Visible = false;
            // 
            // DataH
            // 
            this.DataH.HeaderText = "Data";
            this.DataH.Name = "DataH";
            this.DataH.ReadOnly = true;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novaObservaçãoToolStripMenuItem,
            this.toolStripMenuItem3,
            this.toolStripMenuItem2});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(172, 54);
            // 
            // novaObservaçãoToolStripMenuItem
            // 
            this.novaObservaçãoToolStripMenuItem.Image = global::Estancionamento.Properties.Resources.adicionar;
            this.novaObservaçãoToolStripMenuItem.Name = "novaObservaçãoToolStripMenuItem";
            this.novaObservaçãoToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.novaObservaçãoToolStripMenuItem.Text = "Nova observação";
            this.novaObservaçãoToolStripMenuItem.Click += new System.EventHandler(this.novaObservaçãoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(168, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::Estancionamento.Properties.Resources._1322_128x128;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(171, 22);
            this.toolStripMenuItem2.Text = "Excluir observação";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::Estancionamento.Properties.Resources.plus;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(405, 198);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 30);
            this.button2.TabIndex = 108;
            this.button2.Text = "Novo";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.button2, "Novo registro de veículo");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // cmdLocalizar
            // 
            this.cmdLocalizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdLocalizar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLocalizar.Image = global::Estancionamento.Properties.Resources.lupa;
            this.cmdLocalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdLocalizar.Location = new System.Drawing.Point(501, 198);
            this.cmdLocalizar.Name = "cmdLocalizar";
            this.cmdLocalizar.Size = new System.Drawing.Size(90, 30);
            this.cmdLocalizar.TabIndex = 109;
            this.cmdLocalizar.Text = "Localizar";
            this.cmdLocalizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdLocalizar.UseVisualStyleBackColor = true;
            this.cmdLocalizar.Visible = false;
            // 
            // FrmCadVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 236);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cmdLocalizar);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtObservacaoTela);
            this.Controls.Add(this.cmdGravar);
            this.Controls.Add(this.cmdFechar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCadVenda";
            this.Text = "Cadastro de venda";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmCadVenda_FormClosed);
            this.Load += new System.EventHandler(this.FrmCadVenda_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridVendedor)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridObservacao)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdGravar;
        private System.Windows.Forms.Button cmdFechar;
        private System.Windows.Forms.TextBox txtObservacaoTela;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView gridObservacao;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDescritivoComissao;
        private System.Windows.Forms.DataGridView gridVendedor;
        private System.Windows.Forms.Button cmdNovaComissao;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbClienteVendedor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbClienteComprador;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTipoVenda;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtValorVenda;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbVeiculo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodObservacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataH;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbVenda;
        private System.Windows.Forms.ComboBox cmbSituacao;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodVendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorComissao;
        private System.Windows.Forms.DataGridViewTextBoxColumn SituacaoComissao;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editarComissãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem novaComissãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novaObservaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button cmdLocalizar;
    }
}