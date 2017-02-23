namespace Estancionamento.Relatórios
{
    partial class FrmPesq_Vendas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesq_Vendas));
            this.chkPorData = new System.Windows.Forms.CheckBox();
            this.txtDataFinal = new System.Windows.Forms.DateTimePicker();
            this.txtDtInicial = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.chkPorVendedor = new System.Windows.Forms.CheckBox();
            this.cmbVendedor = new System.Windows.Forms.ComboBox();
            this.chkPorMarca = new System.Windows.Forms.CheckBox();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.chkPorTipoVenda = new System.Windows.Forms.CheckBox();
            this.cmbTipoVenda = new System.Windows.Forms.ComboBox();
            this.chkPorSituacao = new System.Windows.Forms.CheckBox();
            this.cmbSituacao = new System.Windows.Forms.ComboBox();
            this.cmdImprimir = new System.Windows.Forms.Button();
            this.cmdFechar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkPorData
            // 
            this.chkPorData.AutoSize = true;
            this.chkPorData.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.chkPorData.Location = new System.Drawing.Point(12, 18);
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
            this.txtDataFinal.Location = new System.Drawing.Point(317, 18);
            this.txtDataFinal.Name = "txtDataFinal";
            this.txtDataFinal.Size = new System.Drawing.Size(127, 22);
            this.txtDataFinal.TabIndex = 3;
            // 
            // txtDtInicial
            // 
            this.txtDtInicial.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtDtInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDtInicial.Location = new System.Drawing.Point(162, 18);
            this.txtDtInicial.Name = "txtDtInicial";
            this.txtDtInicial.Size = new System.Drawing.Size(127, 22);
            this.txtDtInicial.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(295, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 16);
            this.label2.TabIndex = 129;
            this.label2.Text = "à";
            // 
            // chkPorVendedor
            // 
            this.chkPorVendedor.AutoSize = true;
            this.chkPorVendedor.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.chkPorVendedor.Location = new System.Drawing.Point(12, 48);
            this.chkPorVendedor.Name = "chkPorVendedor";
            this.chkPorVendedor.Size = new System.Drawing.Size(117, 20);
            this.chkPorVendedor.TabIndex = 4;
            this.chkPorVendedor.Text = "Por vendedor:";
            this.chkPorVendedor.UseVisualStyleBackColor = true;
            // 
            // cmbVendedor
            // 
            this.cmbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVendedor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbVendedor.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVendedor.FormattingEnabled = true;
            this.cmbVendedor.Location = new System.Drawing.Point(162, 46);
            this.cmbVendedor.Name = "cmbVendedor";
            this.cmbVendedor.Size = new System.Drawing.Size(282, 24);
            this.cmbVendedor.TabIndex = 5;
            // 
            // chkPorMarca
            // 
            this.chkPorMarca.AutoSize = true;
            this.chkPorMarca.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.chkPorMarca.Location = new System.Drawing.Point(12, 78);
            this.chkPorMarca.Name = "chkPorMarca";
            this.chkPorMarca.Size = new System.Drawing.Size(97, 20);
            this.chkPorMarca.TabIndex = 6;
            this.chkPorMarca.Text = "Por marca:";
            this.chkPorMarca.UseVisualStyleBackColor = true;
            // 
            // cmbMarca
            // 
            this.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarca.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbMarca.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.Location = new System.Drawing.Point(162, 76);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(282, 24);
            this.cmbMarca.TabIndex = 7;
            // 
            // chkPorTipoVenda
            // 
            this.chkPorTipoVenda.AutoSize = true;
            this.chkPorTipoVenda.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.chkPorTipoVenda.Location = new System.Drawing.Point(12, 108);
            this.chkPorTipoVenda.Name = "chkPorTipoVenda";
            this.chkPorTipoVenda.Size = new System.Drawing.Size(144, 20);
            this.chkPorTipoVenda.TabIndex = 8;
            this.chkPorTipoVenda.Text = "Por tipo de venda:";
            this.chkPorTipoVenda.UseVisualStyleBackColor = true;
            // 
            // cmbTipoVenda
            // 
            this.cmbTipoVenda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoVenda.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbTipoVenda.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoVenda.FormattingEnabled = true;
            this.cmbTipoVenda.Location = new System.Drawing.Point(162, 106);
            this.cmbTipoVenda.Name = "cmbTipoVenda";
            this.cmbTipoVenda.Size = new System.Drawing.Size(161, 24);
            this.cmbTipoVenda.TabIndex = 9;
            // 
            // chkPorSituacao
            // 
            this.chkPorSituacao.AutoSize = true;
            this.chkPorSituacao.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.chkPorSituacao.Location = new System.Drawing.Point(12, 138);
            this.chkPorSituacao.Name = "chkPorSituacao";
            this.chkPorSituacao.Size = new System.Drawing.Size(110, 20);
            this.chkPorSituacao.TabIndex = 10;
            this.chkPorSituacao.Text = "Por situação:";
            this.chkPorSituacao.UseVisualStyleBackColor = true;
            // 
            // cmbSituacao
            // 
            this.cmbSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSituacao.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbSituacao.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSituacao.FormattingEnabled = true;
            this.cmbSituacao.Location = new System.Drawing.Point(162, 136);
            this.cmbSituacao.Name = "cmbSituacao";
            this.cmbSituacao.Size = new System.Drawing.Size(161, 24);
            this.cmbSituacao.TabIndex = 11;
            // 
            // cmdImprimir
            // 
            this.cmdImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdImprimir.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdImprimir.Image = global::Estancionamento.Properties.Resources.imprimir_p;
            this.cmdImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdImprimir.Location = new System.Drawing.Point(258, 166);
            this.cmdImprimir.Name = "cmdImprimir";
            this.cmdImprimir.Size = new System.Drawing.Size(90, 30);
            this.cmdImprimir.TabIndex = 12;
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
            this.cmdFechar.Location = new System.Drawing.Point(354, 166);
            this.cmdFechar.Name = "cmdFechar";
            this.cmdFechar.Size = new System.Drawing.Size(90, 30);
            this.cmdFechar.TabIndex = 13;
            this.cmdFechar.Text = "Fechar";
            this.cmdFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdFechar.UseVisualStyleBackColor = true;
            this.cmdFechar.Click += new System.EventHandler(this.cmdFechar_Click);
            // 
            // FrmPesq_Vendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 204);
            this.Controls.Add(this.cmdImprimir);
            this.Controls.Add(this.cmdFechar);
            this.Controls.Add(this.cmbSituacao);
            this.Controls.Add(this.chkPorSituacao);
            this.Controls.Add(this.cmbTipoVenda);
            this.Controls.Add(this.chkPorTipoVenda);
            this.Controls.Add(this.cmbMarca);
            this.Controls.Add(this.chkPorMarca);
            this.Controls.Add(this.cmbVendedor);
            this.Controls.Add(this.chkPorVendedor);
            this.Controls.Add(this.chkPorData);
            this.Controls.Add(this.txtDataFinal);
            this.Controls.Add(this.txtDtInicial);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPesq_Vendas";
            this.Text = "Vendas";
            this.Load += new System.EventHandler(this.FrmPesq_Vendas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkPorData;
        private System.Windows.Forms.DateTimePicker txtDataFinal;
        private System.Windows.Forms.DateTimePicker txtDtInicial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkPorVendedor;
        private System.Windows.Forms.ComboBox cmbVendedor;
        private System.Windows.Forms.CheckBox chkPorMarca;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.CheckBox chkPorTipoVenda;
        private System.Windows.Forms.ComboBox cmbTipoVenda;
        private System.Windows.Forms.CheckBox chkPorSituacao;
        private System.Windows.Forms.ComboBox cmbSituacao;
        private System.Windows.Forms.Button cmdImprimir;
        private System.Windows.Forms.Button cmdFechar;
    }
}