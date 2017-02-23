namespace Estancionamento.Relatórios
{
    partial class FrmPesq_ClientesCadastrados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesq_ClientesCadastrados));
            this.chkPorCidade = new System.Windows.Forms.CheckBox();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.chkPorBairro = new System.Windows.Forms.CheckBox();
            this.chkPorMarca = new System.Windows.Forms.CheckBox();
            this.cmbBairro = new System.Windows.Forms.ComboBox();
            this.cmbCidade = new System.Windows.Forms.ComboBox();
            this.cmdImprimir = new System.Windows.Forms.Button();
            this.cmdFechar = new System.Windows.Forms.Button();
            this.chkPorFaixaSalarial = new System.Windows.Forms.CheckBox();
            this.cmbFaixaSalarial = new System.Windows.Forms.ComboBox();
            this.chkPorTipoPessoa = new System.Windows.Forms.CheckBox();
            this.cmbTipoPessoa = new System.Windows.Forms.ComboBox();
            this.chkPorAniversariantes = new System.Windows.Forms.CheckBox();
            this.cmbAniversariantes = new System.Windows.Forms.ComboBox();
            this.chkPorEtiqueta = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkPorCidade
            // 
            this.chkPorCidade.AutoSize = true;
            this.chkPorCidade.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.chkPorCidade.Location = new System.Drawing.Point(15, 24);
            this.chkPorCidade.Name = "chkPorCidade";
            this.chkPorCidade.Size = new System.Drawing.Size(100, 20);
            this.chkPorCidade.TabIndex = 1;
            this.chkPorCidade.Text = "Por cidade:";
            this.chkPorCidade.UseVisualStyleBackColor = true;
            // 
            // cmbMarca
            // 
            this.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarca.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbMarca.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.Location = new System.Drawing.Point(168, 80);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(297, 24);
            this.cmbMarca.TabIndex = 6;
            // 
            // chkPorBairro
            // 
            this.chkPorBairro.AutoSize = true;
            this.chkPorBairro.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.chkPorBairro.Location = new System.Drawing.Point(15, 54);
            this.chkPorBairro.Name = "chkPorBairro";
            this.chkPorBairro.Size = new System.Drawing.Size(95, 20);
            this.chkPorBairro.TabIndex = 3;
            this.chkPorBairro.Text = "Por bairro:";
            this.chkPorBairro.UseVisualStyleBackColor = true;
            // 
            // chkPorMarca
            // 
            this.chkPorMarca.AutoSize = true;
            this.chkPorMarca.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.chkPorMarca.Location = new System.Drawing.Point(15, 84);
            this.chkPorMarca.Name = "chkPorMarca";
            this.chkPorMarca.Size = new System.Drawing.Size(147, 20);
            this.chkPorMarca.TabIndex = 5;
            this.chkPorMarca.Text = "Por marca veículo:";
            this.chkPorMarca.UseVisualStyleBackColor = true;
            // 
            // cmbBairro
            // 
            this.cmbBairro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBairro.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbBairro.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBairro.FormattingEnabled = true;
            this.cmbBairro.Location = new System.Drawing.Point(168, 50);
            this.cmbBairro.Name = "cmbBairro";
            this.cmbBairro.Size = new System.Drawing.Size(297, 24);
            this.cmbBairro.TabIndex = 4;
            // 
            // cmbCidade
            // 
            this.cmbCidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCidade.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbCidade.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCidade.FormattingEnabled = true;
            this.cmbCidade.Location = new System.Drawing.Point(168, 20);
            this.cmbCidade.Name = "cmbCidade";
            this.cmbCidade.Size = new System.Drawing.Size(297, 24);
            this.cmbCidade.TabIndex = 2;
            // 
            // cmdImprimir
            // 
            this.cmdImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdImprimir.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdImprimir.Image = global::Estancionamento.Properties.Resources.imprimir_p;
            this.cmdImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdImprimir.Location = new System.Drawing.Point(279, 226);
            this.cmdImprimir.Name = "cmdImprimir";
            this.cmdImprimir.Size = new System.Drawing.Size(90, 30);
            this.cmdImprimir.TabIndex = 14;
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
            this.cmdFechar.Location = new System.Drawing.Point(375, 226);
            this.cmdFechar.Name = "cmdFechar";
            this.cmdFechar.Size = new System.Drawing.Size(90, 30);
            this.cmdFechar.TabIndex = 15;
            this.cmdFechar.Text = "Fechar";
            this.cmdFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdFechar.UseVisualStyleBackColor = true;
            this.cmdFechar.Click += new System.EventHandler(this.cmdFechar_Click);
            // 
            // chkPorFaixaSalarial
            // 
            this.chkPorFaixaSalarial.AutoSize = true;
            this.chkPorFaixaSalarial.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.chkPorFaixaSalarial.Location = new System.Drawing.Point(15, 114);
            this.chkPorFaixaSalarial.Name = "chkPorFaixaSalarial";
            this.chkPorFaixaSalarial.Size = new System.Drawing.Size(140, 20);
            this.chkPorFaixaSalarial.TabIndex = 7;
            this.chkPorFaixaSalarial.Text = "Por faixa salarial:";
            this.chkPorFaixaSalarial.UseVisualStyleBackColor = true;
            // 
            // cmbFaixaSalarial
            // 
            this.cmbFaixaSalarial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFaixaSalarial.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbFaixaSalarial.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFaixaSalarial.FormattingEnabled = true;
            this.cmbFaixaSalarial.Location = new System.Drawing.Point(168, 110);
            this.cmbFaixaSalarial.Name = "cmbFaixaSalarial";
            this.cmbFaixaSalarial.Size = new System.Drawing.Size(297, 24);
            this.cmbFaixaSalarial.TabIndex = 8;
            // 
            // chkPorTipoPessoa
            // 
            this.chkPorTipoPessoa.AutoSize = true;
            this.chkPorTipoPessoa.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.chkPorTipoPessoa.Location = new System.Drawing.Point(15, 144);
            this.chkPorTipoPessoa.Name = "chkPorTipoPessoa";
            this.chkPorTipoPessoa.Size = new System.Drawing.Size(129, 20);
            this.chkPorTipoPessoa.TabIndex = 9;
            this.chkPorTipoPessoa.Text = "Por tipo pessoa:";
            this.chkPorTipoPessoa.UseVisualStyleBackColor = true;
            // 
            // cmbTipoPessoa
            // 
            this.cmbTipoPessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoPessoa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbTipoPessoa.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoPessoa.FormattingEnabled = true;
            this.cmbTipoPessoa.Location = new System.Drawing.Point(168, 140);
            this.cmbTipoPessoa.Name = "cmbTipoPessoa";
            this.cmbTipoPessoa.Size = new System.Drawing.Size(297, 24);
            this.cmbTipoPessoa.TabIndex = 10;
            // 
            // chkPorAniversariantes
            // 
            this.chkPorAniversariantes.AutoSize = true;
            this.chkPorAniversariantes.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.chkPorAniversariantes.Location = new System.Drawing.Point(15, 174);
            this.chkPorAniversariantes.Name = "chkPorAniversariantes";
            this.chkPorAniversariantes.Size = new System.Drawing.Size(129, 20);
            this.chkPorAniversariantes.TabIndex = 11;
            this.chkPorAniversariantes.Text = "Aniversariantes:";
            this.chkPorAniversariantes.UseVisualStyleBackColor = true;
            // 
            // cmbAniversariantes
            // 
            this.cmbAniversariantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAniversariantes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbAniversariantes.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAniversariantes.FormattingEnabled = true;
            this.cmbAniversariantes.Location = new System.Drawing.Point(168, 170);
            this.cmbAniversariantes.Name = "cmbAniversariantes";
            this.cmbAniversariantes.Size = new System.Drawing.Size(297, 24);
            this.cmbAniversariantes.TabIndex = 12;
            // 
            // chkPorEtiqueta
            // 
            this.chkPorEtiqueta.AutoSize = true;
            this.chkPorEtiqueta.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkPorEtiqueta.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.chkPorEtiqueta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.chkPorEtiqueta.Location = new System.Drawing.Point(286, 200);
            this.chkPorEtiqueta.Name = "chkPorEtiqueta";
            this.chkPorEtiqueta.Size = new System.Drawing.Size(179, 20);
            this.chkPorEtiqueta.TabIndex = 13;
            this.chkPorEtiqueta.Text = "Impressão por etiquetas";
            this.chkPorEtiqueta.UseVisualStyleBackColor = true;
            // 
            // FrmPesq_ClientesCadastrados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 262);
            this.Controls.Add(this.chkPorEtiqueta);
            this.Controls.Add(this.chkPorAniversariantes);
            this.Controls.Add(this.cmbAniversariantes);
            this.Controls.Add(this.chkPorTipoPessoa);
            this.Controls.Add(this.cmbTipoPessoa);
            this.Controls.Add(this.chkPorFaixaSalarial);
            this.Controls.Add(this.cmbFaixaSalarial);
            this.Controls.Add(this.cmbCidade);
            this.Controls.Add(this.cmbBairro);
            this.Controls.Add(this.cmdImprimir);
            this.Controls.Add(this.cmdFechar);
            this.Controls.Add(this.chkPorMarca);
            this.Controls.Add(this.chkPorBairro);
            this.Controls.Add(this.chkPorCidade);
            this.Controls.Add(this.cmbMarca);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPesq_ClientesCadastrados";
            this.Text = "Clientes cadastrados";
            this.Load += new System.EventHandler(this.FrmPesq_ClientesCadastrados_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkPorCidade;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.CheckBox chkPorBairro;
        private System.Windows.Forms.CheckBox chkPorMarca;
        private System.Windows.Forms.Button cmdImprimir;
        private System.Windows.Forms.Button cmdFechar;
        private System.Windows.Forms.ComboBox cmbBairro;
        private System.Windows.Forms.ComboBox cmbCidade;
        private System.Windows.Forms.CheckBox chkPorFaixaSalarial;
        private System.Windows.Forms.ComboBox cmbFaixaSalarial;
        private System.Windows.Forms.CheckBox chkPorTipoPessoa;
        private System.Windows.Forms.ComboBox cmbTipoPessoa;
        private System.Windows.Forms.CheckBox chkPorAniversariantes;
        private System.Windows.Forms.ComboBox cmbAniversariantes;
        private System.Windows.Forms.CheckBox chkPorEtiqueta;
    }
}