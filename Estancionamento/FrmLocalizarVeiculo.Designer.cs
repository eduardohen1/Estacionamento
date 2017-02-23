namespace Estancionamento
{
    partial class FrmLocalizarVeiculo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLocalizarVeiculo));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtPlaca = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtChassi = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txtAno = new System.Windows.Forms.TextBox();
            this.gridHistorico = new System.Windows.Forms.DataGridView();
            this.CodCarro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataHistorico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoHistorico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioHistorico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdPesquisar = new System.Windows.Forms.Button();
            this.cmdGravar = new System.Windows.Forms.Button();
            this.cmdFechar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHistorico)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(391, 71);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtPlaca);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(383, 45);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Por placa";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtPlaca
            // 
            this.txtPlaca.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtPlaca.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtPlaca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPlaca.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlaca.ForeColor = System.Drawing.Color.Green;
            this.txtPlaca.Location = new System.Drawing.Point(6, 6);
            this.txtPlaca.MaxLength = 50;
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(371, 32);
            this.txtPlaca.TabIndex = 5;
            this.txtPlaca.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtPlaca, "Para pesquisar todos os registros utilize o caracter: *");
            this.txtPlaca.Enter += new System.EventHandler(this.txtPlaca_Enter);
            this.txtPlaca.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPlaca_KeyUp);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cmbMarca);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(383, 45);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Por marca";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cmbMarca
            // 
            this.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarca.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbMarca.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.cmbMarca.ForeColor = System.Drawing.Color.Green;
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.Location = new System.Drawing.Point(3, 6);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(374, 32);
            this.cmbMarca.TabIndex = 3;
            this.cmbMarca.Enter += new System.EventHandler(this.cmbMarca_Enter);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtChassi);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(383, 45);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Por chassi";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtChassi
            // 
            this.txtChassi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtChassi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtChassi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChassi.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChassi.ForeColor = System.Drawing.Color.Green;
            this.txtChassi.Location = new System.Drawing.Point(6, 6);
            this.txtChassi.MaxLength = 50;
            this.txtChassi.Name = "txtChassi";
            this.txtChassi.Size = new System.Drawing.Size(371, 32);
            this.txtChassi.TabIndex = 6;
            this.txtChassi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtChassi, "Para pesquisar todos os registros utilize o caracter: *");
            this.txtChassi.Enter += new System.EventHandler(this.textBox2_Enter);
            this.txtChassi.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtChassi_KeyUp);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.txtAno);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(383, 45);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Por ano";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txtAno
            // 
            this.txtAno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAno.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAno.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAno.ForeColor = System.Drawing.Color.Green;
            this.txtAno.Location = new System.Drawing.Point(6, 6);
            this.txtAno.MaxLength = 4;
            this.txtAno.Name = "txtAno";
            this.txtAno.Size = new System.Drawing.Size(371, 32);
            this.txtAno.TabIndex = 6;
            this.txtAno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAno.Enter += new System.EventHandler(this.textBox3_Enter);
            this.txtAno.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAno_KeyUp);
            // 
            // gridHistorico
            // 
            this.gridHistorico.AllowUserToAddRows = false;
            this.gridHistorico.AllowUserToDeleteRows = false;
            this.gridHistorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridHistorico.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodCarro,
            this.DataHistorico,
            this.TipoHistorico,
            this.UsuarioHistorico});
            this.gridHistorico.Location = new System.Drawing.Point(12, 89);
            this.gridHistorico.Name = "gridHistorico";
            this.gridHistorico.ReadOnly = true;
            this.gridHistorico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridHistorico.Size = new System.Drawing.Size(449, 115);
            this.gridHistorico.TabIndex = 17;
            this.toolTip1.SetToolTip(this.gridHistorico, "Clique duas vezes sobre a linha que deseja visualizar os dados ou selecione a lin" +
        "ha e clique no botão Carregar");
            this.gridHistorico.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridHistorico_CellDoubleClick);
            // 
            // CodCarro
            // 
            this.CodCarro.HeaderText = "CodCarro";
            this.CodCarro.Name = "CodCarro";
            this.CodCarro.ReadOnly = true;
            this.CodCarro.Visible = false;
            // 
            // DataHistorico
            // 
            this.DataHistorico.HeaderText = "Placa";
            this.DataHistorico.Name = "DataHistorico";
            this.DataHistorico.ReadOnly = true;
            this.DataHistorico.Width = 120;
            // 
            // TipoHistorico
            // 
            this.TipoHistorico.HeaderText = "Marca";
            this.TipoHistorico.Name = "TipoHistorico";
            this.TipoHistorico.ReadOnly = true;
            this.TipoHistorico.Width = 120;
            // 
            // UsuarioHistorico
            // 
            this.UsuarioHistorico.HeaderText = "Cliente";
            this.UsuarioHistorico.Name = "UsuarioHistorico";
            this.UsuarioHistorico.ReadOnly = true;
            this.UsuarioHistorico.Width = 150;
            // 
            // cmdPesquisar
            // 
            this.cmdPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdPesquisar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPesquisar.Image = global::Estancionamento.Properties.Resources.lupa;
            this.cmdPesquisar.Location = new System.Drawing.Point(409, 40);
            this.cmdPesquisar.Name = "cmdPesquisar";
            this.cmdPesquisar.Size = new System.Drawing.Size(52, 42);
            this.cmdPesquisar.TabIndex = 15;
            this.cmdPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdPesquisar.UseVisualStyleBackColor = true;
            this.cmdPesquisar.Click += new System.EventHandler(this.cmdPesquisar_Click);
            // 
            // cmdGravar
            // 
            this.cmdGravar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdGravar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGravar.Image = global::Estancionamento.Properties.Resources.carro_ico;
            this.cmdGravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGravar.Location = new System.Drawing.Point(275, 210);
            this.cmdGravar.Name = "cmdGravar";
            this.cmdGravar.Size = new System.Drawing.Size(90, 30);
            this.cmdGravar.TabIndex = 13;
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
            this.cmdFechar.TabIndex = 14;
            this.cmdFechar.Text = "Fechar";
            this.cmdFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdFechar.UseVisualStyleBackColor = true;
            this.cmdFechar.Click += new System.EventHandler(this.cmdFechar_Click);
            // 
            // FrmLocalizarVeiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 245);
            this.Controls.Add(this.gridHistorico);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cmdPesquisar);
            this.Controls.Add(this.cmdGravar);
            this.Controls.Add(this.cmdFechar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLocalizarVeiculo";
            this.Text = "Localizar veículo";
            this.Load += new System.EventHandler(this.FrmLocalizarVeiculo_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHistorico)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdGravar;
        private System.Windows.Forms.Button cmdFechar;
        private System.Windows.Forms.Button cmdPesquisar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView gridHistorico;
        private System.Windows.Forms.TextBox txtPlaca;
        private System.Windows.Forms.TextBox txtChassi;
        private System.Windows.Forms.TextBox txtAno;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodCarro;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataHistorico;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoHistorico;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioHistorico;
    }
}