namespace Estancionamento
{
    partial class FrmCadBairro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadBairro));
            this.cmdFechar = new System.Windows.Forms.Button();
            this.cmbBairro = new System.Windows.Forms.ComboBox();
            this.cmbLocalidade = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdGravar = new System.Windows.Forms.Button();
            this.cmdExcluir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdFechar
            // 
            this.cmdFechar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdFechar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFechar.Image = global::Estancionamento.Properties.Resources.cancelar_p;
            this.cmdFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdFechar.Location = new System.Drawing.Point(333, 72);
            this.cmdFechar.Name = "cmdFechar";
            this.cmdFechar.Size = new System.Drawing.Size(90, 30);
            this.cmdFechar.TabIndex = 4;
            this.cmdFechar.Text = "Fechar";
            this.cmdFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdFechar.UseVisualStyleBackColor = true;
            this.cmdFechar.Click += new System.EventHandler(this.cmdFechar_Click);
            // 
            // cmbBairro
            // 
            this.cmbBairro.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbBairro.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBairro.FormattingEnabled = true;
            this.cmbBairro.Location = new System.Drawing.Point(98, 12);
            this.cmbBairro.Name = "cmbBairro";
            this.cmbBairro.Size = new System.Drawing.Size(325, 24);
            this.cmbBairro.TabIndex = 0;
            this.cmbBairro.SelectedValueChanged += new System.EventHandler(this.cmbBairro_SelectedValueChanged);
            this.cmbBairro.Enter += new System.EventHandler(this.cmbBairro_Enter);
            this.cmbBairro.Leave += new System.EventHandler(this.cmbBairro_Leave);
            // 
            // cmbLocalidade
            // 
            this.cmbLocalidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocalidade.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbLocalidade.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLocalidade.FormattingEnabled = true;
            this.cmbLocalidade.Location = new System.Drawing.Point(98, 42);
            this.cmbLocalidade.Name = "cmbLocalidade";
            this.cmbLocalidade.Size = new System.Drawing.Size(325, 24);
            this.cmbLocalidade.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Bairro:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Localidade:";
            // 
            // cmdGravar
            // 
            this.cmdGravar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdGravar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGravar.Image = global::Estancionamento.Properties.Resources.salvar_p;
            this.cmdGravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGravar.Location = new System.Drawing.Point(141, 72);
            this.cmdGravar.Name = "cmdGravar";
            this.cmdGravar.Size = new System.Drawing.Size(90, 30);
            this.cmdGravar.TabIndex = 2;
            this.cmdGravar.Text = "Gravar";
            this.cmdGravar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdGravar.UseVisualStyleBackColor = true;
            this.cmdGravar.Click += new System.EventHandler(this.cmdGravar_Click);
            // 
            // cmdExcluir
            // 
            this.cmdExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdExcluir.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExcluir.Image = global::Estancionamento.Properties.Resources.lixo_p;
            this.cmdExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdExcluir.Location = new System.Drawing.Point(237, 72);
            this.cmdExcluir.Name = "cmdExcluir";
            this.cmdExcluir.Size = new System.Drawing.Size(90, 30);
            this.cmdExcluir.TabIndex = 3;
            this.cmdExcluir.Text = "Excluir";
            this.cmdExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdExcluir.UseVisualStyleBackColor = true;
            this.cmdExcluir.Click += new System.EventHandler(this.cmdExcluir_Click);
            // 
            // FrmCadBairro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 112);
            this.Controls.Add(this.cmdGravar);
            this.Controls.Add(this.cmdFechar);
            this.Controls.Add(this.cmdExcluir);
            this.Controls.Add(this.cmbBairro);
            this.Controls.Add(this.cmbLocalidade);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCadBairro";
            this.Text = "Cadastro de bairro";
            this.Load += new System.EventHandler(this.FrmCadBairro_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdGravar;
        private System.Windows.Forms.Button cmdFechar;
        private System.Windows.Forms.Button cmdExcluir;
        private System.Windows.Forms.ComboBox cmbBairro;
        private System.Windows.Forms.ComboBox cmbLocalidade;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}