namespace TokenInputG
{
    partial class TokenInput
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTexto = new System.Windows.Forms.Label();
            this.lblFechar = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmdLink = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.cmdLink)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTexto
            // 
            this.lblTexto.AutoSize = true;
            this.lblTexto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTexto.Location = new System.Drawing.Point(6, 7);
            this.lblTexto.Name = "lblTexto";
            this.lblTexto.Size = new System.Drawing.Size(50, 14);
            this.lblTexto.TabIndex = 0;
            this.lblTexto.Text = "lblTexto";
            // 
            // lblFechar
            // 
            this.lblFechar.AutoSize = true;
            this.lblFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFechar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechar.Location = new System.Drawing.Point(219, 7);
            this.lblFechar.Name = "lblFechar";
            this.lblFechar.Size = new System.Drawing.Size(17, 16);
            this.lblFechar.TabIndex = 1;
            this.lblFechar.Text = "X";
            this.lblFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.lblFechar, "testeI");
            this.lblFechar.Click += new System.EventHandler(this.lblFechar_Click);
            // 
            // cmdLink
            // 
            this.cmdLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdLink.Image = global::Estancionamento.Properties.Resources.icon_link_extern;
            this.cmdLink.Location = new System.Drawing.Point(201, 6);
            this.cmdLink.Name = "cmdLink";
            this.cmdLink.Size = new System.Drawing.Size(19, 16);
            this.cmdLink.TabIndex = 2;
            this.cmdLink.TabStop = false;
            this.cmdLink.Visible = false;
            this.cmdLink.Click += new System.EventHandler(this.cmdLink_Click);
            // 
            // TokenInput
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.cmdLink);
            this.Controls.Add(this.lblFechar);
            this.Controls.Add(this.lblTexto);
            this.Name = "TokenInput";
            this.Size = new System.Drawing.Size(239, 28);
            this.Load += new System.EventHandler(this.TokenInput_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmdLink)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTexto;
        private System.Windows.Forms.Label lblFechar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox cmdLink;
    }
}
