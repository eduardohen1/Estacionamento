namespace Estancionamento
{
    partial class FrmSuportes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSuportes));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoSuporte02 = new System.Windows.Forms.RadioButton();
            this.rdoSuporte = new System.Windows.Forms.RadioButton();
            this.cmdOK = new System.Windows.Forms.Button();
            this.rdoSuporte03 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoSuporte03);
            this.groupBox1.Controls.Add(this.rdoSuporte02);
            this.groupBox1.Controls.Add(this.rdoSuporte);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 103);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // rdoSuporte02
            // 
            this.rdoSuporte02.AutoSize = true;
            this.rdoSuporte02.Location = new System.Drawing.Point(7, 43);
            this.rdoSuporte02.Name = "rdoSuporte02";
            this.rdoSuporte02.Size = new System.Drawing.Size(155, 17);
            this.rdoSuporte02.TabIndex = 1;
            this.rdoSuporte02.Text = "Cadastrar acesso ao banco";
            this.rdoSuporte02.UseVisualStyleBackColor = true;
            // 
            // rdoSuporte
            // 
            this.rdoSuporte.AutoSize = true;
            this.rdoSuporte.Checked = true;
            this.rdoSuporte.Location = new System.Drawing.Point(7, 20);
            this.rdoSuporte.Name = "rdoSuporte";
            this.rdoSuporte.Size = new System.Drawing.Size(135, 17);
            this.rdoSuporte.TabIndex = 0;
            this.rdoSuporte.TabStop = true;
            this.rdoSuporte.Text = "Cadastrar Superusuário";
            this.rdoSuporte.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(197, 121);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 1;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // rdoSuporte03
            // 
            this.rdoSuporte03.AutoSize = true;
            this.rdoSuporte03.Enabled = false;
            this.rdoSuporte03.Location = new System.Drawing.Point(7, 66);
            this.rdoSuporte03.Name = "rdoSuporte03";
            this.rdoSuporte03.Size = new System.Drawing.Size(136, 17);
            this.rdoSuporte03.TabIndex = 2;
            this.rdoSuporte03.Text = "Limpar banco de dados";
            this.rdoSuporte03.UseVisualStyleBackColor = true;
            // 
            // FrmSuportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 150);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSuportes";
            this.Text = "Suporte técnico";
            this.Load += new System.EventHandler(this.FrmSuportes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoSuporte;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.RadioButton rdoSuporte02;
        private System.Windows.Forms.RadioButton rdoSuporte03;
    }
}