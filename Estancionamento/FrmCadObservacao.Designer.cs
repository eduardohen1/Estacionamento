namespace Estancionamento
{
    partial class FrmCadObservacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadObservacao));
            this.lblPlacaVeiculo = new System.Windows.Forms.Label();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdGravar = new System.Windows.Forms.Button();
            this.cmdFechar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPlacaVeiculo
            // 
            this.lblPlacaVeiculo.AutoSize = true;
            this.lblPlacaVeiculo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lblPlacaVeiculo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlacaVeiculo.ForeColor = System.Drawing.Color.Blue;
            this.lblPlacaVeiculo.Location = new System.Drawing.Point(12, 9);
            this.lblPlacaVeiculo.Name = "lblPlacaVeiculo";
            this.lblPlacaVeiculo.Size = new System.Drawing.Size(94, 16);
            this.lblPlacaVeiculo.TabIndex = 46;
            this.lblPlacaVeiculo.Text = "Placa veículo";
            // 
            // txtObservacao
            // 
            this.txtObservacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtObservacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtObservacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservacao.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacao.Location = new System.Drawing.Point(105, 34);
            this.txtObservacao.MaxLength = 200;
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacao.Size = new System.Drawing.Size(186, 52);
            this.txtObservacao.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 45;
            this.label1.Text = "Observação:";
            // 
            // cmdGravar
            // 
            this.cmdGravar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdGravar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGravar.Image = global::Estancionamento.Properties.Resources.salvar_p;
            this.cmdGravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGravar.Location = new System.Drawing.Point(105, 92);
            this.cmdGravar.Name = "cmdGravar";
            this.cmdGravar.Size = new System.Drawing.Size(90, 30);
            this.cmdGravar.TabIndex = 2;
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
            this.cmdFechar.Location = new System.Drawing.Point(201, 92);
            this.cmdFechar.Name = "cmdFechar";
            this.cmdFechar.Size = new System.Drawing.Size(90, 30);
            this.cmdFechar.TabIndex = 3;
            this.cmdFechar.Text = "Fechar";
            this.cmdFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdFechar.UseVisualStyleBackColor = true;
            this.cmdFechar.Click += new System.EventHandler(this.cmdFechar_Click);
            // 
            // FrmCadObservacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 131);
            this.Controls.Add(this.lblPlacaVeiculo);
            this.Controls.Add(this.txtObservacao);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdGravar);
            this.Controls.Add(this.cmdFechar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCadObservacao";
            this.Text = "Cadastro de observação";
            this.Load += new System.EventHandler(this.FrmCadObservacao_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlacaVeiculo;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdGravar;
        private System.Windows.Forms.Button cmdFechar;
    }
}