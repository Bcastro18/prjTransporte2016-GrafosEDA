namespace prjModuloII
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.btnMinimo = new System.Windows.Forms.Button();
            this.btnHamiltonian = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbConexao = new System.Windows.Forms.RadioButton();
            this.rbNo = new System.Windows.Forms.RadioButton();
            this.btnGrafo = new System.Windows.Forms.Button();
            this.lstResp = new System.Windows.Forms.ListBox();
            this.lblResp = new System.Windows.Forms.Label();
            this.btnCongestionamento = new System.Windows.Forms.Button();
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.ptbLogo = new System.Windows.Forms.PictureBox();
            this.btnVisualizar = new System.Windows.Forms.Button();
            this.btnRenomear = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMinimo
            // 
            this.btnMinimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimo.Location = new System.Drawing.Point(655, 375);
            this.btnMinimo.Name = "btnMinimo";
            this.btnMinimo.Size = new System.Drawing.Size(133, 53);
            this.btnMinimo.TabIndex = 7;
            this.btnMinimo.Text = "Melhor Rota";
            this.btnMinimo.UseVisualStyleBackColor = true;
            this.btnMinimo.Click += new System.EventHandler(this.btnMinimo_Click);
            // 
            // btnHamiltonian
            // 
            this.btnHamiltonian.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHamiltonian.Location = new System.Drawing.Point(794, 375);
            this.btnHamiltonian.Name = "btnHamiltonian";
            this.btnHamiltonian.Size = new System.Drawing.Size(132, 52);
            this.btnHamiltonian.TabIndex = 8;
            this.btnHamiltonian.Text = "Rota Total";
            this.btnHamiltonian.UseVisualStyleBackColor = true;
            this.btnHamiltonian.Click += new System.EventHandler(this.btnHamiltonian_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbConexao);
            this.groupBox1.Controls.Add(this.rbNo);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(526, 211);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(101, 95);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Adicionar Cidade:";
            // 
            // rdbConexao
            // 
            this.rdbConexao.Location = new System.Drawing.Point(4, 67);
            this.rdbConexao.Margin = new System.Windows.Forms.Padding(4);
            this.rdbConexao.Name = "rdbConexao";
            this.rdbConexao.Size = new System.Drawing.Size(91, 20);
            this.rdbConexao.TabIndex = 1;
            this.rdbConexao.Text = "Conexão";
            this.rdbConexao.UseVisualStyleBackColor = true;
            // 
            // rbNo
            // 
            this.rbNo.Checked = true;
            this.rbNo.Location = new System.Drawing.Point(4, 43);
            this.rbNo.Margin = new System.Windows.Forms.Padding(4);
            this.rbNo.Name = "rbNo";
            this.rbNo.Size = new System.Drawing.Size(75, 20);
            this.rbNo.TabIndex = 0;
            this.rbNo.TabStop = true;
            this.rbNo.Text = "Local";
            this.rbNo.UseVisualStyleBackColor = true;
            // 
            // btnGrafo
            // 
            this.btnGrafo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrafo.Location = new System.Drawing.Point(526, 374);
            this.btnGrafo.Name = "btnGrafo";
            this.btnGrafo.Size = new System.Drawing.Size(123, 53);
            this.btnGrafo.TabIndex = 10;
            this.btnGrafo.Text = "Gerar Mapa";
            this.btnGrafo.UseVisualStyleBackColor = true;
            this.btnGrafo.Click += new System.EventHandler(this.btnGrafo_Click);
            // 
            // lstResp
            // 
            this.lstResp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstResp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstResp.FormattingEnabled = true;
            this.lstResp.ItemHeight = 16;
            this.lstResp.Location = new System.Drawing.Point(643, 26);
            this.lstResp.Name = "lstResp";
            this.lstResp.Size = new System.Drawing.Size(283, 340);
            this.lstResp.TabIndex = 11;
            this.lstResp.Visible = false;
            this.lstResp.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstResp_MouseDoubleClick);
            // 
            // lblResp
            // 
            this.lblResp.AutoSize = true;
            this.lblResp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResp.Location = new System.Drawing.Point(640, 5);
            this.lblResp.Name = "lblResp";
            this.lblResp.Size = new System.Drawing.Size(298, 18);
            this.lblResp.TabIndex = 12;
            this.lblResp.Text = "Resposta (Clique 2x para gerar em arquivo):";
            this.lblResp.Visible = false;
            // 
            // btnCongestionamento
            // 
            this.btnCongestionamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCongestionamento.Location = new System.Drawing.Point(526, 433);
            this.btnCongestionamento.Name = "btnCongestionamento";
            this.btnCongestionamento.Size = new System.Drawing.Size(178, 51);
            this.btnCongestionamento.TabIndex = 13;
            this.btnCongestionamento.Text = "Congestionamentos";
            this.btnCongestionamento.UseVisualStyleBackColor = true;
            this.btnCongestionamento.Click += new System.EventHandler(this.btnCongestionamento_Click);
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReiniciar.Location = new System.Drawing.Point(526, 313);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(101, 53);
            this.btnReiniciar.TabIndex = 14;
            this.btnReiniciar.Text = "Reiniciar";
            this.btnReiniciar.UseVisualStyleBackColor = true;
            this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);
            // 
            // ptbLogo
            // 
            this.ptbLogo.Image = ((System.Drawing.Image)(resources.GetObject("ptbLogo.Image")));
            this.ptbLogo.Location = new System.Drawing.Point(591, 26);
            this.ptbLogo.Name = "ptbLogo";
            this.ptbLogo.Size = new System.Drawing.Size(346, 191);
            this.ptbLogo.TabIndex = 15;
            this.ptbLogo.TabStop = false;
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVisualizar.Location = new System.Drawing.Point(710, 433);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(111, 51);
            this.btnVisualizar.TabIndex = 16;
            this.btnVisualizar.Text = "Visualizar Mapa";
            this.btnVisualizar.UseVisualStyleBackColor = true;
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            // 
            // btnRenomear
            // 
            this.btnRenomear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRenomear.Location = new System.Drawing.Point(827, 433);
            this.btnRenomear.Name = "btnRenomear";
            this.btnRenomear.Size = new System.Drawing.Size(99, 51);
            this.btnRenomear.TabIndex = 17;
            this.btnRenomear.Text = "Alterar";
            this.btnRenomear.UseVisualStyleBackColor = true;
            this.btnRenomear.Click += new System.EventHandler(this.btnRenomear_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(938, 505);
            this.Controls.Add(this.btnRenomear);
            this.Controls.Add(this.btnVisualizar);
            this.Controls.Add(this.ptbLogo);
            this.Controls.Add(this.btnReiniciar);
            this.Controls.Add(this.btnCongestionamento);
            this.Controls.Add(this.lblResp);
            this.Controls.Add(this.lstResp);
            this.Controls.Add(this.btnGrafo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnHamiltonian);
            this.Controls.Add(this.btnMinimo);
            this.Name = "Principal";
            this.Text = "BC Cargas";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMinimo;
        private System.Windows.Forms.Button btnHamiltonian;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbNo;
        private System.Windows.Forms.Button btnGrafo;
        private System.Windows.Forms.ListBox lstResp;
        private System.Windows.Forms.Label lblResp;
        private System.Windows.Forms.Button btnCongestionamento;
        private System.Windows.Forms.Button btnReiniciar;
        private System.Windows.Forms.RadioButton rdbConexao;
        private System.Windows.Forms.PictureBox ptbLogo;
        private System.Windows.Forms.Button btnVisualizar;
        private System.Windows.Forms.Button btnRenomear;
    }
}