namespace Estancionamento
{
    partial class FrmAuditoria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAuditoria));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdPesquisar = new System.Windows.Forms.Button();
            this.chkPorChave = new System.Windows.Forms.CheckBox();
            this.cmbUsuario = new System.Windows.Forms.ComboBox();
            this.chkPorUsuario = new System.Windows.Forms.CheckBox();
            this.chkPorAuditoria = new System.Windows.Forms.CheckBox();
            this.chkPorData = new System.Windows.Forms.CheckBox();
            this.txtDataFinal = new System.Windows.Forms.DateTimePicker();
            this.txtDtInicial = new System.Windows.Forms.DateTimePicker();
            this.cmbAuditoria = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtChave = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.gridAuditoria = new System.Windows.Forms.DataGridView();
            this.CodAuditoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Auditoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdImprimir = new System.Windows.Forms.Button();
            this.cmdFechar = new System.Windows.Forms.Button();
            this.pnlPesquisa = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAuditoria)).BeginInit();
            this.pnlPesquisa.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmdPesquisar);
            this.panel1.Controls.Add(this.chkPorChave);
            this.panel1.Controls.Add(this.cmbUsuario);
            this.panel1.Controls.Add(this.chkPorUsuario);
            this.panel1.Controls.Add(this.chkPorAuditoria);
            this.panel1.Controls.Add(this.chkPorData);
            this.panel1.Controls.Add(this.txtDataFinal);
            this.panel1.Controls.Add(this.txtDtInicial);
            this.panel1.Controls.Add(this.cmbAuditoria);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtChave);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(862, 79);
            this.panel1.TabIndex = 0;
            // 
            // cmdPesquisar
            // 
            this.cmdPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdPesquisar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPesquisar.Image = global::Estancionamento.Properties.Resources.pesquisar;
            this.cmdPesquisar.Location = new System.Drawing.Point(807, 24);
            this.cmdPesquisar.Name = "cmdPesquisar";
            this.cmdPesquisar.Size = new System.Drawing.Size(46, 39);
            this.cmdPesquisar.TabIndex = 10;
            this.cmdPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.cmdPesquisar, "Pesquisar");
            this.cmdPesquisar.UseVisualStyleBackColor = true;
            this.cmdPesquisar.Click += new System.EventHandler(this.cmdPesquisar_Click);
            // 
            // chkPorChave
            // 
            this.chkPorChave.AutoSize = true;
            this.chkPorChave.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.chkPorChave.Location = new System.Drawing.Point(476, 45);
            this.chkPorChave.Name = "chkPorChave";
            this.chkPorChave.Size = new System.Drawing.Size(95, 20);
            this.chkPorChave.TabIndex = 8;
            this.chkPorChave.Text = "Por chave:";
            this.chkPorChave.UseVisualStyleBackColor = true;
            // 
            // cmbUsuario
            // 
            this.cmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbUsuario.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUsuario.FormattingEnabled = true;
            this.cmbUsuario.Location = new System.Drawing.Point(586, 11);
            this.cmbUsuario.Name = "cmbUsuario";
            this.cmbUsuario.Size = new System.Drawing.Size(215, 24);
            this.cmbUsuario.TabIndex = 5;
            // 
            // chkPorUsuario
            // 
            this.chkPorUsuario.AutoSize = true;
            this.chkPorUsuario.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.chkPorUsuario.Location = new System.Drawing.Point(476, 17);
            this.chkPorUsuario.Name = "chkPorUsuario";
            this.chkPorUsuario.Size = new System.Drawing.Size(104, 20);
            this.chkPorUsuario.TabIndex = 4;
            this.chkPorUsuario.Text = "Por usuário:";
            this.chkPorUsuario.UseVisualStyleBackColor = true;
            // 
            // chkPorAuditoria
            // 
            this.chkPorAuditoria.AutoSize = true;
            this.chkPorAuditoria.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.chkPorAuditoria.Location = new System.Drawing.Point(3, 45);
            this.chkPorAuditoria.Name = "chkPorAuditoria";
            this.chkPorAuditoria.Size = new System.Drawing.Size(114, 20);
            this.chkPorAuditoria.TabIndex = 6;
            this.chkPorAuditoria.Text = "Por auditoria:";
            this.chkPorAuditoria.UseVisualStyleBackColor = true;
            // 
            // chkPorData
            // 
            this.chkPorData.AutoSize = true;
            this.chkPorData.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.chkPorData.Location = new System.Drawing.Point(3, 17);
            this.chkPorData.Name = "chkPorData";
            this.chkPorData.Size = new System.Drawing.Size(85, 20);
            this.chkPorData.TabIndex = 1;
            this.chkPorData.Text = "Por data:";
            this.chkPorData.UseVisualStyleBackColor = true;
            // 
            // txtDataFinal
            // 
            this.txtDataFinal.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtDataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDataFinal.Location = new System.Drawing.Point(291, 13);
            this.txtDataFinal.Name = "txtDataFinal";
            this.txtDataFinal.Size = new System.Drawing.Size(169, 22);
            this.txtDataFinal.TabIndex = 3;
            // 
            // txtDtInicial
            // 
            this.txtDtInicial.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtDtInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDtInicial.Location = new System.Drawing.Point(94, 13);
            this.txtDtInicial.Name = "txtDtInicial";
            this.txtDtInicial.Size = new System.Drawing.Size(169, 22);
            this.txtDtInicial.TabIndex = 2;
            // 
            // cmbAuditoria
            // 
            this.cmbAuditoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAuditoria.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbAuditoria.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAuditoria.FormattingEnabled = true;
            this.cmbAuditoria.Location = new System.Drawing.Point(123, 40);
            this.cmbAuditoria.Name = "cmbAuditoria";
            this.cmbAuditoria.Size = new System.Drawing.Size(337, 24);
            this.cmbAuditoria.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(269, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 16);
            this.label2.TabIndex = 120;
            this.label2.Text = "à";
            // 
            // txtChave
            // 
            this.txtChave.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtChave.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtChave.BackColor = System.Drawing.SystemColors.Window;
            this.txtChave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChave.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChave.Location = new System.Drawing.Point(586, 41);
            this.txtChave.MaxLength = 50;
            this.txtChave.Name = "txtChave";
            this.txtChave.Size = new System.Drawing.Size(215, 22);
            this.txtChave.TabIndex = 9;
            // 
            // gridAuditoria
            // 
            this.gridAuditoria.AllowUserToAddRows = false;
            this.gridAuditoria.AllowUserToDeleteRows = false;
            this.gridAuditoria.AllowUserToOrderColumns = true;
            this.gridAuditoria.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridAuditoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAuditoria.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodAuditoria,
            this.Data,
            this.Operacao,
            this.Auditoria,
            this.Usuario});
            this.gridAuditoria.Location = new System.Drawing.Point(12, 97);
            this.gridAuditoria.Name = "gridAuditoria";
            this.gridAuditoria.ReadOnly = true;
            this.gridAuditoria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridAuditoria.Size = new System.Drawing.Size(862, 272);
            this.gridAuditoria.TabIndex = 1;
            // 
            // CodAuditoria
            // 
            this.CodAuditoria.HeaderText = "CodAuditoria";
            this.CodAuditoria.Name = "CodAuditoria";
            this.CodAuditoria.ReadOnly = true;
            this.CodAuditoria.Visible = false;
            // 
            // Data
            // 
            this.Data.HeaderText = "Data";
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            // 
            // Operacao
            // 
            this.Operacao.HeaderText = "Operação";
            this.Operacao.Name = "Operacao";
            this.Operacao.ReadOnly = true;
            // 
            // Auditoria
            // 
            this.Auditoria.HeaderText = "Auditoria";
            this.Auditoria.Name = "Auditoria";
            this.Auditoria.ReadOnly = true;
            this.Auditoria.Width = 300;
            // 
            // Usuario
            // 
            this.Usuario.HeaderText = "Usuário";
            this.Usuario.Name = "Usuario";
            this.Usuario.ReadOnly = true;
            this.Usuario.Width = 250;
            // 
            // cmdImprimir
            // 
            this.cmdImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdImprimir.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdImprimir.Image = global::Estancionamento.Properties.Resources.imprimir_p;
            this.cmdImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdImprimir.Location = new System.Drawing.Point(688, 375);
            this.cmdImprimir.Name = "cmdImprimir";
            this.cmdImprimir.Size = new System.Drawing.Size(90, 30);
            this.cmdImprimir.TabIndex = 5;
            this.cmdImprimir.Text = "Imprimir";
            this.cmdImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdImprimir.UseVisualStyleBackColor = true;
            this.cmdImprimir.Click += new System.EventHandler(this.cmdImprimir_Click);
            // 
            // cmdFechar
            // 
            this.cmdFechar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdFechar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFechar.Image = global::Estancionamento.Properties.Resources.cancelar_p;
            this.cmdFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdFechar.Location = new System.Drawing.Point(784, 375);
            this.cmdFechar.Name = "cmdFechar";
            this.cmdFechar.Size = new System.Drawing.Size(90, 30);
            this.cmdFechar.TabIndex = 6;
            this.cmdFechar.Text = "Fechar";
            this.cmdFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdFechar.UseVisualStyleBackColor = true;
            this.cmdFechar.Click += new System.EventHandler(this.cmdFechar_Click);
            // 
            // pnlPesquisa
            // 
            this.pnlPesquisa.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlPesquisa.Controls.Add(this.lblStatus);
            this.pnlPesquisa.Location = new System.Drawing.Point(241, 170);
            this.pnlPesquisa.Name = "pnlPesquisa";
            this.pnlPesquisa.Size = new System.Drawing.Size(414, 107);
            this.pnlPesquisa.TabIndex = 7;
            this.pnlPesquisa.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(129, 38);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(138, 25);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Pesquisando...";
            // 
            // FrmAuditoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 417);
            this.Controls.Add(this.pnlPesquisa);
            this.Controls.Add(this.cmdImprimir);
            this.Controls.Add(this.cmdFechar);
            this.Controls.Add(this.gridAuditoria);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAuditoria";
            this.Text = "Auditoria operacional";
            this.Load += new System.EventHandler(this.FrmAuditoria_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAuditoria)).EndInit();
            this.pnlPesquisa.ResumeLayout(false);
            this.pnlPesquisa.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker txtDataFinal;
        private System.Windows.Forms.DateTimePicker txtDtInicial;
        private System.Windows.Forms.ComboBox cmbAuditoria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkPorChave;
        private System.Windows.Forms.ComboBox cmbUsuario;
        private System.Windows.Forms.CheckBox chkPorUsuario;
        private System.Windows.Forms.CheckBox chkPorAuditoria;
        private System.Windows.Forms.CheckBox chkPorData;
        private System.Windows.Forms.TextBox txtChave;
        private System.Windows.Forms.Button cmdPesquisar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridView gridAuditoria;
        private System.Windows.Forms.Button cmdImprimir;
        private System.Windows.Forms.Button cmdFechar;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodAuditoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Auditoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.Panel pnlPesquisa;
        private System.Windows.Forms.Label lblStatus;
    }
}