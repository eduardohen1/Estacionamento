namespace Estancionamento
{
    partial class FrmLocalizarCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLocalizarCliente));
            this.gridHistorico = new System.Windows.Forms.DataGridView();
            this.CodCarro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataHistorico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoHistorico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtCPF = new System.Windows.Forms.MaskedTextBox();
            this.cmdPesquisar = new System.Windows.Forms.Button();
            this.cmdGravar = new System.Windows.Forms.Button();
            this.cmdFechar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridHistorico)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridHistorico
            // 
            this.gridHistorico.AllowUserToAddRows = false;
            this.gridHistorico.AllowUserToDeleteRows = false;
            this.gridHistorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridHistorico.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodCarro,
            this.DataHistorico,
            this.TipoHistorico});
            this.gridHistorico.Location = new System.Drawing.Point(12, 89);
            this.gridHistorico.Name = "gridHistorico";
            this.gridHistorico.ReadOnly = true;
            this.gridHistorico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridHistorico.Size = new System.Drawing.Size(449, 115);
            this.gridHistorico.TabIndex = 22;
            this.gridHistorico.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridHistorico_CellDoubleClick);
            // 
            // CodCarro
            // 
            this.CodCarro.HeaderText = "CodCliente";
            this.CodCarro.Name = "CodCarro";
            this.CodCarro.ReadOnly = true;
            this.CodCarro.Visible = false;
            // 
            // DataHistorico
            // 
            this.DataHistorico.HeaderText = "Nome";
            this.DataHistorico.Name = "DataHistorico";
            this.DataHistorico.ReadOnly = true;
            this.DataHistorico.Width = 250;
            // 
            // TipoHistorico
            // 
            this.TipoHistorico.HeaderText = "CPF";
            this.TipoHistorico.Name = "TipoHistorico";
            this.TipoHistorico.ReadOnly = true;
            this.TipoHistorico.Width = 120;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(391, 71);
            this.tabControl1.TabIndex = 21;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtNome);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(383, 45);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Por nome";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtNome
            // 
            this.txtNome.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtNome.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNome.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.ForeColor = System.Drawing.Color.Green;
            this.txtNome.Location = new System.Drawing.Point(6, 6);
            this.txtNome.MaxLength = 50;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(371, 32);
            this.txtNome.TabIndex = 5;
            this.txtNome.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtNome, "Para pesquisar todos os registros utilize o caracter: *");
            this.txtNome.Enter += new System.EventHandler(this.txtNome_Enter);
            this.txtNome.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNome_KeyUp);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtCPF);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(383, 45);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Por CPF";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtCPF
            // 
            this.txtCPF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCPF.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.txtCPF.ForeColor = System.Drawing.Color.Green;
            this.txtCPF.Location = new System.Drawing.Point(6, 6);
            this.txtCPF.Mask = "###,###,###-##";
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(371, 32);
            this.txtCPF.TabIndex = 8;
            this.txtCPF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCPF.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtCPF.Enter += new System.EventHandler(this.txtCPF_Enter);
            this.txtCPF.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCPF_KeyUp);
            // 
            // cmdPesquisar
            // 
            this.cmdPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdPesquisar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPesquisar.Image = global::Estancionamento.Properties.Resources.lupa;
            this.cmdPesquisar.Location = new System.Drawing.Point(409, 40);
            this.cmdPesquisar.Name = "cmdPesquisar";
            this.cmdPesquisar.Size = new System.Drawing.Size(52, 42);
            this.cmdPesquisar.TabIndex = 20;
            this.cmdPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdPesquisar.UseVisualStyleBackColor = true;
            this.cmdPesquisar.Click += new System.EventHandler(this.cmdPesquisar_Click);
            // 
            // cmdGravar
            // 
            this.cmdGravar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdGravar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGravar.Image = global::Estancionamento.Properties.Resources.usuario_pp;
            this.cmdGravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGravar.Location = new System.Drawing.Point(275, 210);
            this.cmdGravar.Name = "cmdGravar";
            this.cmdGravar.Size = new System.Drawing.Size(90, 30);
            this.cmdGravar.TabIndex = 18;
            this.cmdGravar.Text = "Carregar";
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
            this.cmdFechar.Location = new System.Drawing.Point(371, 210);
            this.cmdFechar.Name = "cmdFechar";
            this.cmdFechar.Size = new System.Drawing.Size(90, 30);
            this.cmdFechar.TabIndex = 19;
            this.cmdFechar.Text = "Fechar";
            this.cmdFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdFechar.UseVisualStyleBackColor = true;
            this.cmdFechar.Click += new System.EventHandler(this.cmdFechar_Click);
            // 
            // FrmLocalizarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 247);
            this.Controls.Add(this.gridHistorico);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cmdPesquisar);
            this.Controls.Add(this.cmdGravar);
            this.Controls.Add(this.cmdFechar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLocalizarCliente";
            this.Text = "Localizar cliente";
            this.Load += new System.EventHandler(this.FrmLocalizarCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridHistorico)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridHistorico;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button cmdPesquisar;
        private System.Windows.Forms.Button cmdGravar;
        private System.Windows.Forms.Button cmdFechar;
        private System.Windows.Forms.MaskedTextBox txtCPF;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodCarro;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataHistorico;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoHistorico;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}