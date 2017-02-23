namespace Estancionamento
{
    partial class FrmCadProspect
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbBairro = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbLocalidade = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbMunicipio = new System.Windows.Forms.ComboBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtAnoFinal = new System.Windows.Forms.TextBox();
            this.txtAnoInicial = new System.Windows.Forms.TextBox();
            this.txtValorFinal = new System.Windows.Forms.TextBox();
            this.txtValorInicial = new System.Windows.Forms.TextBox();
            this.cmdAdicionarPortas = new System.Windows.Forms.Button();
            this.pnlPortas = new System.Windows.Forms.FlowLayoutPanel();
            this.cmdAdicionarMotor = new System.Windows.Forms.Button();
            this.pnlMotor = new System.Windows.Forms.FlowLayoutPanel();
            this.cmdAdicionarCor = new System.Windows.Forms.Button();
            this.pnlCor = new System.Windows.Forms.FlowLayoutPanel();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdAdicionarMarca = new System.Windows.Forms.Button();
            this.pnlMarcas = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdNovoTelefone = new System.Windows.Forms.Button();
            this.pnlTelefones = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtRG = new System.Windows.Forms.TextBox();
            this.txtCPF = new System.Windows.Forms.MaskedTextBox();
            this.cmbLogradouro = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cmdNovaObservacao = new System.Windows.Forms.Button();
            this.gridObservacao = new System.Windows.Forms.DataGridView();
            this.CodObservacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Observacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdNovoRegistro = new System.Windows.Forms.Button();
            this.cmdLocalizar = new System.Windows.Forms.Button();
            this.cmdGravar = new System.Windows.Forms.Button();
            this.cmdFechar = new System.Windows.Forms.Button();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.novaObservaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridObservacao)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(951, 411);
            this.tabControl1.TabIndex = 33;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.cmbBairro);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.cmbLocalidade);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.cmbMunicipio);
            this.tabPage1.Controls.Add(this.txtNome);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtNumero);
            this.tabPage1.Controls.Add(this.txtEmail);
            this.tabPage1.Controls.Add(this.txtRG);
            this.tabPage1.Controls.Add(this.txtCPF);
            this.tabPage1.Controls.Add(this.cmbLogradouro);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(943, 385);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cadastro";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 155);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 16);
            this.label10.TabIndex = 47;
            this.label10.Text = "Bairro:";
            // 
            // cmbBairro
            // 
            this.cmbBairro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBairro.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbBairro.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBairro.FormattingEnabled = true;
            this.cmbBairro.Location = new System.Drawing.Point(105, 152);
            this.cmbBairro.Name = "cmbBairro";
            this.cmbBairro.Size = new System.Drawing.Size(355, 24);
            this.cmbBairro.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 125);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 16);
            this.label9.TabIndex = 45;
            this.label9.Text = "Localidade:";
            // 
            // cmbLocalidade
            // 
            this.cmbLocalidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocalidade.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbLocalidade.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLocalidade.FormattingEnabled = true;
            this.cmbLocalidade.Location = new System.Drawing.Point(105, 122);
            this.cmbLocalidade.Name = "cmbLocalidade";
            this.cmbLocalidade.Size = new System.Drawing.Size(355, 24);
            this.cmbLocalidade.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 16);
            this.label8.TabIndex = 43;
            this.label8.Text = "Município:";
            // 
            // cmbMunicipio
            // 
            this.cmbMunicipio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMunicipio.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbMunicipio.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMunicipio.FormattingEnabled = true;
            this.cmbMunicipio.Location = new System.Drawing.Point(105, 92);
            this.cmbMunicipio.Name = "cmbMunicipio";
            this.cmbMunicipio.Size = new System.Drawing.Size(355, 24);
            this.cmbMunicipio.TabIndex = 5;
            // 
            // txtNome
            // 
            this.txtNome.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtNome.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNome.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(105, 7);
            this.txtNome.MaxLength = 50;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(355, 22);
            this.txtNome.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.txtAnoFinal);
            this.groupBox2.Controls.Add(this.txtAnoInicial);
            this.groupBox2.Controls.Add(this.txtValorFinal);
            this.groupBox2.Controls.Add(this.txtValorInicial);
            this.groupBox2.Controls.Add(this.cmdAdicionarPortas);
            this.groupBox2.Controls.Add(this.pnlPortas);
            this.groupBox2.Controls.Add(this.cmdAdicionarMotor);
            this.groupBox2.Controls.Add(this.pnlMotor);
            this.groupBox2.Controls.Add(this.cmdAdicionarCor);
            this.groupBox2.Controls.Add(this.pnlCor);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cmdAdicionarMarca);
            this.groupBox2.Controls.Add(this.pnlMarcas);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(469, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(456, 370);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Veículos:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Arial", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label19.ForeColor = System.Drawing.Color.Gray;
            this.label19.Location = new System.Drawing.Point(264, 283);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(21, 24);
            this.label19.TabIndex = 52;
            this.label19.Text = "à";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Arial", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label18.ForeColor = System.Drawing.Color.Gray;
            this.label18.Location = new System.Drawing.Point(264, 336);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(21, 24);
            this.label18.TabIndex = 52;
            this.label18.Text = "à";
            // 
            // txtAnoFinal
            // 
            this.txtAnoFinal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAnoFinal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAnoFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAnoFinal.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold);
            this.txtAnoFinal.Location = new System.Drawing.Point(303, 279);
            this.txtAnoFinal.MaxLength = 200;
            this.txtAnoFinal.Name = "txtAnoFinal";
            this.txtAnoFinal.Size = new System.Drawing.Size(140, 30);
            this.txtAnoFinal.TabIndex = 16;
            this.txtAnoFinal.Text = "20.000,12";
            this.txtAnoFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtAnoInicial
            // 
            this.txtAnoInicial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAnoInicial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAnoInicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAnoInicial.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold);
            this.txtAnoInicial.Location = new System.Drawing.Point(104, 279);
            this.txtAnoInicial.MaxLength = 200;
            this.txtAnoInicial.Name = "txtAnoInicial";
            this.txtAnoInicial.Size = new System.Drawing.Size(140, 30);
            this.txtAnoInicial.TabIndex = 15;
            this.txtAnoInicial.Text = "20.000,12";
            this.txtAnoInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtValorFinal
            // 
            this.txtValorFinal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtValorFinal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtValorFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValorFinal.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold);
            this.txtValorFinal.Location = new System.Drawing.Point(303, 332);
            this.txtValorFinal.MaxLength = 200;
            this.txtValorFinal.Name = "txtValorFinal";
            this.txtValorFinal.Size = new System.Drawing.Size(140, 30);
            this.txtValorFinal.TabIndex = 18;
            this.txtValorFinal.Text = "20.000,12";
            this.txtValorFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtValorInicial
            // 
            this.txtValorInicial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtValorInicial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtValorInicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValorInicial.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold);
            this.txtValorInicial.Location = new System.Drawing.Point(104, 332);
            this.txtValorInicial.MaxLength = 200;
            this.txtValorInicial.Name = "txtValorInicial";
            this.txtValorInicial.Size = new System.Drawing.Size(140, 30);
            this.txtValorInicial.TabIndex = 17;
            this.txtValorInicial.Text = "20.000,12";
            this.txtValorInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmdAdicionarPortas
            // 
            this.cmdAdicionarPortas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAdicionarPortas.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAdicionarPortas.Image = global::Estancionamento.Properties.Resources.adicionar;
            this.cmdAdicionarPortas.Location = new System.Drawing.Point(397, 218);
            this.cmdAdicionarPortas.Name = "cmdAdicionarPortas";
            this.cmdAdicionarPortas.Size = new System.Drawing.Size(46, 39);
            this.cmdAdicionarPortas.TabIndex = 14;
            this.cmdAdicionarPortas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAdicionarPortas.UseVisualStyleBackColor = true;
            // 
            // pnlPortas
            // 
            this.pnlPortas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPortas.Location = new System.Drawing.Point(104, 218);
            this.pnlPortas.Name = "pnlPortas";
            this.pnlPortas.Size = new System.Drawing.Size(296, 39);
            this.pnlPortas.TabIndex = 44;
            // 
            // cmdAdicionarMotor
            // 
            this.cmdAdicionarMotor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAdicionarMotor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAdicionarMotor.Image = global::Estancionamento.Properties.Resources.adicionar;
            this.cmdAdicionarMotor.Location = new System.Drawing.Point(397, 153);
            this.cmdAdicionarMotor.Name = "cmdAdicionarMotor";
            this.cmdAdicionarMotor.Size = new System.Drawing.Size(46, 39);
            this.cmdAdicionarMotor.TabIndex = 13;
            this.cmdAdicionarMotor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAdicionarMotor.UseVisualStyleBackColor = true;
            // 
            // pnlMotor
            // 
            this.pnlMotor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMotor.Location = new System.Drawing.Point(104, 153);
            this.pnlMotor.Name = "pnlMotor";
            this.pnlMotor.Size = new System.Drawing.Size(297, 39);
            this.pnlMotor.TabIndex = 42;
            // 
            // cmdAdicionarCor
            // 
            this.cmdAdicionarCor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAdicionarCor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAdicionarCor.Image = global::Estancionamento.Properties.Resources.adicionar;
            this.cmdAdicionarCor.Location = new System.Drawing.Point(397, 86);
            this.cmdAdicionarCor.Name = "cmdAdicionarCor";
            this.cmdAdicionarCor.Size = new System.Drawing.Size(46, 39);
            this.cmdAdicionarCor.TabIndex = 12;
            this.cmdAdicionarCor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAdicionarCor.UseVisualStyleBackColor = true;
            // 
            // pnlCor
            // 
            this.pnlCor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCor.Location = new System.Drawing.Point(104, 86);
            this.pnlCor.Name = "pnlCor";
            this.pnlCor.Size = new System.Drawing.Size(297, 39);
            this.pnlCor.TabIndex = 40;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label15.ForeColor = System.Drawing.Color.Gray;
            this.label15.Location = new System.Drawing.Point(9, 335);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 24);
            this.label15.TabIndex = 39;
            this.label15.Text = "Valor de";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label14.ForeColor = System.Drawing.Color.Gray;
            this.label14.Location = new System.Drawing.Point(9, 282);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 24);
            this.label14.TabIndex = 38;
            this.label14.Text = "Ano de";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label13.ForeColor = System.Drawing.Color.Gray;
            this.label13.Location = new System.Drawing.Point(6, 227);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 24);
            this.label13.TabIndex = 37;
            this.label13.Text = "Portas:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label12.ForeColor = System.Drawing.Color.Gray;
            this.label12.Location = new System.Drawing.Point(9, 162);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 24);
            this.label12.TabIndex = 36;
            this.label12.Text = "Motor:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label11.ForeColor = System.Drawing.Color.Gray;
            this.label11.Location = new System.Drawing.Point(9, 94);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 24);
            this.label11.TabIndex = 35;
            this.label11.Text = "Cor:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(9, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 24);
            this.label3.TabIndex = 34;
            this.label3.Text = "Marca:";
            // 
            // cmdAdicionarMarca
            // 
            this.cmdAdicionarMarca.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAdicionarMarca.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAdicionarMarca.Image = global::Estancionamento.Properties.Resources.adicionar;
            this.cmdAdicionarMarca.Location = new System.Drawing.Point(397, 21);
            this.cmdAdicionarMarca.Name = "cmdAdicionarMarca";
            this.cmdAdicionarMarca.Size = new System.Drawing.Size(46, 39);
            this.cmdAdicionarMarca.TabIndex = 11;
            this.cmdAdicionarMarca.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAdicionarMarca.UseVisualStyleBackColor = true;
            // 
            // pnlMarcas
            // 
            this.pnlMarcas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMarcas.Location = new System.Drawing.Point(104, 21);
            this.pnlMarcas.Name = "pnlMarcas";
            this.pnlMarcas.Size = new System.Drawing.Size(297, 39);
            this.pnlMarcas.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdNovoTelefone);
            this.groupBox1.Controls.Add(this.pnlTelefones);
            this.groupBox1.Location = new System.Drawing.Point(6, 240);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(445, 137);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Telefones:";
            // 
            // cmdNovoTelefone
            // 
            this.cmdNovoTelefone.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdNovoTelefone.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNovoTelefone.Image = global::Estancionamento.Properties.Resources.adicionar;
            this.cmdNovoTelefone.Location = new System.Drawing.Point(388, 92);
            this.cmdNovoTelefone.Name = "cmdNovoTelefone";
            this.cmdNovoTelefone.Size = new System.Drawing.Size(46, 39);
            this.cmdNovoTelefone.TabIndex = 10;
            this.cmdNovoTelefone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdNovoTelefone.UseVisualStyleBackColor = true;
            // 
            // pnlTelefones
            // 
            this.pnlTelefones.Location = new System.Drawing.Point(7, 15);
            this.pnlTelefones.Name = "pnlTelefones";
            this.pnlTelefones.Size = new System.Drawing.Size(375, 116);
            this.pnlTelefones.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 35;
            this.label4.Text = "Núm.:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 16);
            this.label6.TabIndex = 36;
            this.label6.Text = "Logradouro:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 16);
            this.label5.TabIndex = 37;
            this.label5.Text = "E-mail:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(223, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 16);
            this.label7.TabIndex = 38;
            this.label7.Text = "RG:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 39;
            this.label2.Text = "CPF:";
            // 
            // txtNumero
            // 
            this.txtNumero.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtNumero.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumero.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero.Location = new System.Drawing.Point(105, 212);
            this.txtNumero.MaxLength = 10;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(87, 22);
            this.txtNumero.TabIndex = 9;
            // 
            // txtEmail
            // 
            this.txtEmail.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtEmail.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(105, 63);
            this.txtEmail.MaxLength = 200;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(355, 22);
            this.txtEmail.TabIndex = 4;
            // 
            // txtRG
            // 
            this.txtRG.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtRG.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtRG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRG.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRG.Location = new System.Drawing.Point(260, 35);
            this.txtRG.MaxLength = 200;
            this.txtRG.Name = "txtRG";
            this.txtRG.Size = new System.Drawing.Size(200, 22);
            this.txtRG.TabIndex = 3;
            // 
            // txtCPF
            // 
            this.txtCPF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCPF.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtCPF.Location = new System.Drawing.Point(105, 35);
            this.txtCPF.Mask = "###,###,###-##";
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(112, 22);
            this.txtCPF.TabIndex = 2;
            this.txtCPF.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // cmbLogradouro
            // 
            this.cmbLogradouro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLogradouro.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbLogradouro.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLogradouro.FormattingEnabled = true;
            this.cmbLogradouro.Location = new System.Drawing.Point(105, 182);
            this.cmbLogradouro.Name = "cmbLogradouro";
            this.cmbLogradouro.Size = new System.Drawing.Size(355, 24);
            this.cmbLogradouro.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 33;
            this.label1.Text = "Nome:";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.cmdNovaObservacao);
            this.tabPage3.Controls.Add(this.gridObservacao);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(943, 385);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Observações";
            // 
            // cmdNovaObservacao
            // 
            this.cmdNovaObservacao.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdNovaObservacao.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNovaObservacao.Image = global::Estancionamento.Properties.Resources.adicionar;
            this.cmdNovaObservacao.Location = new System.Drawing.Point(868, 378);
            this.cmdNovaObservacao.Name = "cmdNovaObservacao";
            this.cmdNovaObservacao.Size = new System.Drawing.Size(46, 39);
            this.cmdNovaObservacao.TabIndex = 10;
            this.cmdNovaObservacao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdNovaObservacao.UseVisualStyleBackColor = true;
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
            this.gridObservacao.Size = new System.Drawing.Size(856, 411);
            this.gridObservacao.TabIndex = 24;
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
            this.Observacao.Width = 450;
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
            // cmdNovoRegistro
            // 
            this.cmdNovoRegistro.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdNovoRegistro.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNovoRegistro.Image = global::Estancionamento.Properties.Resources.plus;
            this.cmdNovoRegistro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdNovoRegistro.Location = new System.Drawing.Point(585, 429);
            this.cmdNovoRegistro.Name = "cmdNovoRegistro";
            this.cmdNovoRegistro.Size = new System.Drawing.Size(90, 30);
            this.cmdNovoRegistro.TabIndex = 19;
            this.cmdNovoRegistro.Text = "Novo";
            this.cmdNovoRegistro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdNovoRegistro.UseVisualStyleBackColor = true;
            this.cmdNovoRegistro.Click += new System.EventHandler(this.cmdNovoRegistro_Click);
            // 
            // cmdLocalizar
            // 
            this.cmdLocalizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdLocalizar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLocalizar.Image = global::Estancionamento.Properties.Resources.lupa;
            this.cmdLocalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdLocalizar.Location = new System.Drawing.Point(681, 429);
            this.cmdLocalizar.Name = "cmdLocalizar";
            this.cmdLocalizar.Size = new System.Drawing.Size(90, 30);
            this.cmdLocalizar.TabIndex = 20;
            this.cmdLocalizar.Text = "Localizar";
            this.cmdLocalizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdLocalizar.UseVisualStyleBackColor = true;
            // 
            // cmdGravar
            // 
            this.cmdGravar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdGravar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGravar.Image = global::Estancionamento.Properties.Resources.salvar_p;
            this.cmdGravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGravar.Location = new System.Drawing.Point(777, 429);
            this.cmdGravar.Name = "cmdGravar";
            this.cmdGravar.Size = new System.Drawing.Size(90, 30);
            this.cmdGravar.TabIndex = 21;
            this.cmdGravar.Text = "Gravar";
            this.cmdGravar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdGravar.UseVisualStyleBackColor = true;
            // 
            // cmdFechar
            // 
            this.cmdFechar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdFechar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFechar.Image = global::Estancionamento.Properties.Resources.cancelar_p;
            this.cmdFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdFechar.Location = new System.Drawing.Point(873, 429);
            this.cmdFechar.Name = "cmdFechar";
            this.cmdFechar.Size = new System.Drawing.Size(90, 30);
            this.cmdFechar.TabIndex = 22;
            this.cmdFechar.Text = "Fechar";
            this.cmdFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdFechar.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novaObservaçãoToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(172, 54);
            // 
            // novaObservaçãoToolStripMenuItem
            // 
            this.novaObservaçãoToolStripMenuItem.Image = global::Estancionamento.Properties.Resources.adicionar;
            this.novaObservaçãoToolStripMenuItem.Name = "novaObservaçãoToolStripMenuItem";
            this.novaObservaçãoToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.novaObservaçãoToolStripMenuItem.Text = "Nova observação";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(168, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::Estancionamento.Properties.Resources._1322_128x128;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
            this.toolStripMenuItem1.Text = "Excluir observação";
            // 
            // FrmCadProspect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 470);
            this.Controls.Add(this.cmdNovoRegistro);
            this.Controls.Add(this.cmdLocalizar);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cmdGravar);
            this.Controls.Add(this.cmdFechar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCadProspect";
            this.Text = "Lista de espera";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridObservacao)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdNovoRegistro;
        private System.Windows.Forms.Button cmdLocalizar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbBairro;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbLocalidade;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbMunicipio;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdNovoTelefone;
        private System.Windows.Forms.FlowLayoutPanel pnlTelefones;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtRG;
        private System.Windows.Forms.MaskedTextBox txtCPF;
        private System.Windows.Forms.ComboBox cmbLogradouro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button cmdNovaObservacao;
        private System.Windows.Forms.DataGridView gridObservacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodObservacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataH;
        private System.Windows.Forms.Button cmdGravar;
        private System.Windows.Forms.Button cmdFechar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtValorInicial;
        private System.Windows.Forms.Button cmdAdicionarPortas;
        private System.Windows.Forms.FlowLayoutPanel pnlPortas;
        private System.Windows.Forms.Button cmdAdicionarMotor;
        private System.Windows.Forms.FlowLayoutPanel pnlMotor;
        private System.Windows.Forms.Button cmdAdicionarCor;
        private System.Windows.Forms.FlowLayoutPanel pnlCor;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdAdicionarMarca;
        private System.Windows.Forms.FlowLayoutPanel pnlMarcas;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtAnoFinal;
        private System.Windows.Forms.TextBox txtAnoInicial;
        private System.Windows.Forms.TextBox txtValorFinal;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem novaObservaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}