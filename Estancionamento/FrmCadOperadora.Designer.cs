namespace Estancionamento
{
    partial class FrmCadOperadora
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadOperadora));
            this.cmdGravar = new System.Windows.Forms.Button();
            this.cmdFechar = new System.Windows.Forms.Button();
            this.cmdExcluir = new System.Windows.Forms.Button();
            this.cmbOperadora = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdGravar
            // 
            this.cmdGravar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdGravar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGravar.Image = global::Estancionamento.Properties.Resources.salvar_p;
            this.cmdGravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGravar.Location = new System.Drawing.Point(141, 42);
            this.cmdGravar.Name = "cmdGravar";
            this.cmdGravar.Size = new System.Drawing.Size(90, 30);
            this.cmdGravar.TabIndex = 14;
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
            this.cmdFechar.Location = new System.Drawing.Point(333, 42);
            this.cmdFechar.Name = "cmdFechar";
            this.cmdFechar.Size = new System.Drawing.Size(90, 30);
            this.cmdFechar.TabIndex = 16;
            this.cmdFechar.Text = "Fechar";
            this.cmdFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdFechar.UseVisualStyleBackColor = true;
            this.cmdFechar.Click += new System.EventHandler(this.cmdFechar_Click);
            // 
            // cmdExcluir
            // 
            this.cmdExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdExcluir.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExcluir.Image = global::Estancionamento.Properties.Resources.lixo_p;
            this.cmdExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdExcluir.Location = new System.Drawing.Point(237, 42);
            this.cmdExcluir.Name = "cmdExcluir";
            this.cmdExcluir.Size = new System.Drawing.Size(90, 30);
            this.cmdExcluir.TabIndex = 15;
            this.cmdExcluir.Text = "Excluir";
            this.cmdExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdExcluir.UseVisualStyleBackColor = true;
            this.cmdExcluir.Click += new System.EventHandler(this.cmdExcluir_Click);
            // 
            // cmbOperadora
            // 
            this.cmbOperadora.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbOperadora.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOperadora.FormattingEnabled = true;
            this.cmbOperadora.Location = new System.Drawing.Point(98, 12);
            this.cmbOperadora.Name = "cmbOperadora";
            this.cmbOperadora.Size = new System.Drawing.Size(325, 24);
            this.cmbOperadora.TabIndex = 13;
            this.cmbOperadora.Enter += new System.EventHandler(this.cmbOperadora_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "Operadora:";
            // 
            // FrmCadOperadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 81);
            this.Controls.Add(this.cmdGravar);
            this.Controls.Add(this.cmdFechar);
            this.Controls.Add(this.cmdExcluir);
            this.Controls.Add(this.cmbOperadora);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCadOperadora";
            this.Text = "Cadastro de operadoras";
            this.Load += new System.EventHandler(this.FrmCadOperadora_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdGravar;
        private System.Windows.Forms.Button cmdFechar;
        private System.Windows.Forms.Button cmdExcluir;
        private System.Windows.Forms.ComboBox cmbOperadora;
        private System.Windows.Forms.Label label3;
    }
}