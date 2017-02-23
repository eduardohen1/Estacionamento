namespace Estancionamento
{
    partial class FrmCadComissao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadComissao));
            this.lblNumVenda = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbVendedor = new System.Windows.Forms.ComboBox();
            this.txtValorVenda = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSituacao = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmdGravar = new System.Windows.Forms.Button();
            this.cmdFechar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNumVenda
            // 
            this.lblNumVenda.AutoSize = true;
            this.lblNumVenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lblNumVenda.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumVenda.ForeColor = System.Drawing.Color.Blue;
            this.lblNumVenda.Location = new System.Drawing.Point(12, 9);
            this.lblNumVenda.Name = "lblNumVenda";
            this.lblNumVenda.Size = new System.Drawing.Size(85, 16);
            this.lblNumVenda.TabIndex = 47;
            this.lblNumVenda.Text = "Num. Venda";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 49;
            this.label2.Text = "Vendedor:";
            // 
            // cmbVendedor
            // 
            this.cmbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVendedor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbVendedor.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVendedor.FormattingEnabled = true;
            this.cmbVendedor.Location = new System.Drawing.Point(126, 44);
            this.cmbVendedor.Name = "cmbVendedor";
            this.cmbVendedor.Size = new System.Drawing.Size(309, 24);
            this.cmbVendedor.TabIndex = 1;
            // 
            // txtValorVenda
            // 
            this.txtValorVenda.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtValorVenda.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtValorVenda.BackColor = System.Drawing.SystemColors.Window;
            this.txtValorVenda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValorVenda.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorVenda.Location = new System.Drawing.Point(126, 74);
            this.txtValorVenda.MaxLength = 50;
            this.txtValorVenda.Name = "txtValorVenda";
            this.txtValorVenda.Size = new System.Drawing.Size(170, 22);
            this.txtValorVenda.TabIndex = 2;
            this.txtValorVenda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValorVenda_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 16);
            this.label5.TabIndex = 51;
            this.label5.Text = "Valor comissão:";
            // 
            // cmbSituacao
            // 
            this.cmbSituacao.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbSituacao.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSituacao.FormattingEnabled = true;
            this.cmbSituacao.Location = new System.Drawing.Point(126, 102);
            this.cmbSituacao.MaxLength = 7;
            this.cmbSituacao.Name = "cmbSituacao";
            this.cmbSituacao.Size = new System.Drawing.Size(170, 24);
            this.cmbSituacao.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 16);
            this.label10.TabIndex = 111;
            this.label10.Text = "Situação:";
            // 
            // cmdGravar
            // 
            this.cmdGravar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdGravar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGravar.Image = global::Estancionamento.Properties.Resources.salvar_p;
            this.cmdGravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGravar.Location = new System.Drawing.Point(249, 137);
            this.cmdGravar.Name = "cmdGravar";
            this.cmdGravar.Size = new System.Drawing.Size(90, 30);
            this.cmdGravar.TabIndex = 4;
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
            this.cmdFechar.Location = new System.Drawing.Point(345, 137);
            this.cmdFechar.Name = "cmdFechar";
            this.cmdFechar.Size = new System.Drawing.Size(90, 30);
            this.cmdFechar.TabIndex = 5;
            this.cmdFechar.Text = "Fechar";
            this.cmdFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdFechar.UseVisualStyleBackColor = true;
            this.cmdFechar.Click += new System.EventHandler(this.cmdFechar_Click);
            // 
            // FrmCadComissao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 180);
            this.Controls.Add(this.cmdGravar);
            this.Controls.Add(this.cmdFechar);
            this.Controls.Add(this.cmbSituacao);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtValorVenda);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbVendedor);
            this.Controls.Add(this.lblNumVenda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCadComissao";
            this.Text = "Cadastro de comissão";
            this.Load += new System.EventHandler(this.FrmCadComissao_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumVenda;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbVendedor;
        private System.Windows.Forms.TextBox txtValorVenda;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbSituacao;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button cmdGravar;
        private System.Windows.Forms.Button cmdFechar;
    }
}