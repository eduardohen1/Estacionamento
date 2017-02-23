namespace Estancionamento.Relatórios
{
    partial class FrmPesq_VeiculosCadastradoscs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesq_VeiculosCadastradoscs));
            this.chkPorAnoFab = new System.Windows.Forms.CheckBox();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.chkPorMarca = new System.Windows.Forms.CheckBox();
            this.txtAnoFab = new System.Windows.Forms.TextBox();
            this.chkPorAnoMod = new System.Windows.Forms.CheckBox();
            this.chkPorQtePortas = new System.Windows.Forms.CheckBox();
            this.chkPorQteLugares = new System.Windows.Forms.CheckBox();
            this.chkPorCor = new System.Windows.Forms.CheckBox();
            this.chkPorSituacao = new System.Windows.Forms.CheckBox();
            this.txtAnoMod = new System.Windows.Forms.TextBox();
            this.cmbQtePortas = new System.Windows.Forms.ComboBox();
            this.cmbQteLugares = new System.Windows.Forms.ComboBox();
            this.cmbCor = new System.Windows.Forms.ComboBox();
            this.cmbSituacao = new System.Windows.Forms.ComboBox();
            this.cmdImprimir = new System.Windows.Forms.Button();
            this.cmdFechar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkPorAnoFab
            // 
            this.chkPorAnoFab.AutoSize = true;
            this.chkPorAnoFab.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.chkPorAnoFab.Location = new System.Drawing.Point(12, 43);
            this.chkPorAnoFab.Name = "chkPorAnoFab";
            this.chkPorAnoFab.Size = new System.Drawing.Size(109, 20);
            this.chkPorAnoFab.TabIndex = 3;
            this.chkPorAnoFab.Text = "Por ano fab.:";
            this.chkPorAnoFab.UseVisualStyleBackColor = true;
            // 
            // cmbMarca
            // 
            this.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarca.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbMarca.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.Location = new System.Drawing.Point(146, 12);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(329, 24);
            this.cmbMarca.TabIndex = 2;
            // 
            // chkPorMarca
            // 
            this.chkPorMarca.AutoSize = true;
            this.chkPorMarca.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.chkPorMarca.Location = new System.Drawing.Point(12, 16);
            this.chkPorMarca.Name = "chkPorMarca";
            this.chkPorMarca.Size = new System.Drawing.Size(97, 20);
            this.chkPorMarca.TabIndex = 1;
            this.chkPorMarca.Text = "Por marca:";
            this.chkPorMarca.UseVisualStyleBackColor = true;
            // 
            // txtAnoFab
            // 
            this.txtAnoFab.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAnoFab.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAnoFab.BackColor = System.Drawing.SystemColors.Window;
            this.txtAnoFab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAnoFab.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnoFab.Location = new System.Drawing.Point(146, 42);
            this.txtAnoFab.MaxLength = 4;
            this.txtAnoFab.Name = "txtAnoFab";
            this.txtAnoFab.Size = new System.Drawing.Size(100, 22);
            this.txtAnoFab.TabIndex = 4;
            this.txtAnoFab.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAnoFab_KeyDown);
            // 
            // chkPorAnoMod
            // 
            this.chkPorAnoMod.AutoSize = true;
            this.chkPorAnoMod.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.chkPorAnoMod.Location = new System.Drawing.Point(252, 44);
            this.chkPorAnoMod.Name = "chkPorAnoMod";
            this.chkPorAnoMod.Size = new System.Drawing.Size(117, 20);
            this.chkPorAnoMod.TabIndex = 5;
            this.chkPorAnoMod.Text = "Por ano mod.:";
            this.chkPorAnoMod.UseVisualStyleBackColor = true;
            // 
            // chkPorQtePortas
            // 
            this.chkPorQtePortas.AutoSize = true;
            this.chkPorQtePortas.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.chkPorQtePortas.Location = new System.Drawing.Point(12, 72);
            this.chkPorQtePortas.Name = "chkPorQtePortas";
            this.chkPorQtePortas.Size = new System.Drawing.Size(124, 20);
            this.chkPorQtePortas.TabIndex = 7;
            this.chkPorQtePortas.Text = "Por qte portas.:";
            this.chkPorQtePortas.UseVisualStyleBackColor = true;
            // 
            // chkPorQteLugares
            // 
            this.chkPorQteLugares.AutoSize = true;
            this.chkPorQteLugares.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.chkPorQteLugares.Location = new System.Drawing.Point(12, 102);
            this.chkPorQteLugares.Name = "chkPorQteLugares";
            this.chkPorQteLugares.Size = new System.Drawing.Size(128, 20);
            this.chkPorQteLugares.TabIndex = 9;
            this.chkPorQteLugares.Text = "Por qte lugares:";
            this.chkPorQteLugares.UseVisualStyleBackColor = true;
            // 
            // chkPorCor
            // 
            this.chkPorCor.AutoSize = true;
            this.chkPorCor.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.chkPorCor.Location = new System.Drawing.Point(12, 132);
            this.chkPorCor.Name = "chkPorCor";
            this.chkPorCor.Size = new System.Drawing.Size(77, 20);
            this.chkPorCor.TabIndex = 11;
            this.chkPorCor.Text = "Por cor:";
            this.chkPorCor.UseVisualStyleBackColor = true;
            // 
            // chkPorSituacao
            // 
            this.chkPorSituacao.AutoSize = true;
            this.chkPorSituacao.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.chkPorSituacao.Location = new System.Drawing.Point(11, 162);
            this.chkPorSituacao.Name = "chkPorSituacao";
            this.chkPorSituacao.Size = new System.Drawing.Size(110, 20);
            this.chkPorSituacao.TabIndex = 13;
            this.chkPorSituacao.Text = "Por situação:";
            this.chkPorSituacao.UseVisualStyleBackColor = true;
            // 
            // txtAnoMod
            // 
            this.txtAnoMod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAnoMod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAnoMod.BackColor = System.Drawing.SystemColors.Window;
            this.txtAnoMod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAnoMod.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnoMod.Location = new System.Drawing.Point(375, 42);
            this.txtAnoMod.MaxLength = 4;
            this.txtAnoMod.Name = "txtAnoMod";
            this.txtAnoMod.Size = new System.Drawing.Size(100, 22);
            this.txtAnoMod.TabIndex = 6;
            this.txtAnoMod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAnoMod_KeyDown);
            // 
            // cmbQtePortas
            // 
            this.cmbQtePortas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQtePortas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbQtePortas.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbQtePortas.FormattingEnabled = true;
            this.cmbQtePortas.Location = new System.Drawing.Point(146, 70);
            this.cmbQtePortas.Name = "cmbQtePortas";
            this.cmbQtePortas.Size = new System.Drawing.Size(138, 24);
            this.cmbQtePortas.TabIndex = 8;
            // 
            // cmbQteLugares
            // 
            this.cmbQteLugares.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQteLugares.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbQteLugares.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbQteLugares.FormattingEnabled = true;
            this.cmbQteLugares.Location = new System.Drawing.Point(146, 100);
            this.cmbQteLugares.Name = "cmbQteLugares";
            this.cmbQteLugares.Size = new System.Drawing.Size(138, 24);
            this.cmbQteLugares.TabIndex = 10;
            // 
            // cmbCor
            // 
            this.cmbCor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbCor.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCor.FormattingEnabled = true;
            this.cmbCor.Location = new System.Drawing.Point(146, 130);
            this.cmbCor.Name = "cmbCor";
            this.cmbCor.Size = new System.Drawing.Size(138, 24);
            this.cmbCor.TabIndex = 12;
            // 
            // cmbSituacao
            // 
            this.cmbSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSituacao.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbSituacao.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSituacao.FormattingEnabled = true;
            this.cmbSituacao.Location = new System.Drawing.Point(146, 160);
            this.cmbSituacao.Name = "cmbSituacao";
            this.cmbSituacao.Size = new System.Drawing.Size(138, 24);
            this.cmbSituacao.TabIndex = 14;
            // 
            // cmdImprimir
            // 
            this.cmdImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdImprimir.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdImprimir.Image = global::Estancionamento.Properties.Resources.imprimir_p;
            this.cmdImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdImprimir.Location = new System.Drawing.Point(289, 202);
            this.cmdImprimir.Name = "cmdImprimir";
            this.cmdImprimir.Size = new System.Drawing.Size(90, 30);
            this.cmdImprimir.TabIndex = 15;
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
            this.cmdFechar.Location = new System.Drawing.Point(385, 202);
            this.cmdFechar.Name = "cmdFechar";
            this.cmdFechar.Size = new System.Drawing.Size(90, 30);
            this.cmdFechar.TabIndex = 16;
            this.cmdFechar.Text = "Fechar";
            this.cmdFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdFechar.UseVisualStyleBackColor = true;
            this.cmdFechar.Click += new System.EventHandler(this.cmdFechar_Click);
            // 
            // FrmPesq_VeiculosCadastradoscs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 241);
            this.Controls.Add(this.cmdImprimir);
            this.Controls.Add(this.cmdFechar);
            this.Controls.Add(this.cmbSituacao);
            this.Controls.Add(this.cmbCor);
            this.Controls.Add(this.cmbQteLugares);
            this.Controls.Add(this.cmbQtePortas);
            this.Controls.Add(this.txtAnoMod);
            this.Controls.Add(this.chkPorSituacao);
            this.Controls.Add(this.chkPorCor);
            this.Controls.Add(this.chkPorQteLugares);
            this.Controls.Add(this.chkPorQtePortas);
            this.Controls.Add(this.chkPorAnoMod);
            this.Controls.Add(this.chkPorAnoFab);
            this.Controls.Add(this.cmbMarca);
            this.Controls.Add(this.chkPorMarca);
            this.Controls.Add(this.txtAnoFab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPesq_VeiculosCadastradoscs";
            this.Text = "Veículos cadastrados";
            this.Load += new System.EventHandler(this.FrmPesq_VeiculosCadastradoscs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkPorAnoFab;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.CheckBox chkPorMarca;
        private System.Windows.Forms.TextBox txtAnoFab;
        private System.Windows.Forms.CheckBox chkPorAnoMod;
        private System.Windows.Forms.CheckBox chkPorQtePortas;
        private System.Windows.Forms.CheckBox chkPorQteLugares;
        private System.Windows.Forms.CheckBox chkPorCor;
        private System.Windows.Forms.CheckBox chkPorSituacao;
        private System.Windows.Forms.TextBox txtAnoMod;
        private System.Windows.Forms.ComboBox cmbQtePortas;
        private System.Windows.Forms.ComboBox cmbQteLugares;
        private System.Windows.Forms.ComboBox cmbCor;
        private System.Windows.Forms.ComboBox cmbSituacao;
        private System.Windows.Forms.Button cmdImprimir;
        private System.Windows.Forms.Button cmdFechar;
    }
}