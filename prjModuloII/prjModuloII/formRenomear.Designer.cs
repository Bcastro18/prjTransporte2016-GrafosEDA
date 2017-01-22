namespace prjModuloII
{
    partial class formRenomear
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
            this.lstCidades = new System.Windows.Forms.ListBox();
            this.lstConexoes = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstCidades
            // 
            this.lstCidades.FormattingEnabled = true;
            this.lstCidades.Location = new System.Drawing.Point(16, 41);
            this.lstCidades.Name = "lstCidades";
            this.lstCidades.ScrollAlwaysVisible = true;
            this.lstCidades.Size = new System.Drawing.Size(224, 173);
            this.lstCidades.TabIndex = 0;
            this.lstCidades.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstCidades_MouseClick);
            this.lstCidades.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstCidades_MouseDoubleClick);
            // 
            // lstConexoes
            // 
            this.lstConexoes.FormattingEnabled = true;
            this.lstConexoes.Location = new System.Drawing.Point(277, 41);
            this.lstConexoes.Name = "lstConexoes";
            this.lstConexoes.ScrollAlwaysVisible = true;
            this.lstConexoes.Size = new System.Drawing.Size(224, 173);
            this.lstConexoes.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cidades:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(273, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Conexões:";
            // 
            // formRenomear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(523, 236);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstConexoes);
            this.Controls.Add(this.lstCidades);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "formRenomear";
            this.Text = "Alterar Cidades e Vias";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstCidades;
        private System.Windows.Forms.ListBox lstConexoes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}