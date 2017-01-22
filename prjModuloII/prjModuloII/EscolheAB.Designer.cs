namespace prjModuloII
{
    partial class EscolheAB
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
            this.cmbNodeA = new System.Windows.Forms.ComboBox();
            this.cmbNodeB = new System.Windows.Forms.ComboBox();
            this.btnEscolher = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbAll = new System.Windows.Forms.RadioButton();
            this.rdbTransito = new System.Windows.Forms.RadioButton();
            this.rdbCustoPedagio = new System.Windows.Forms.RadioButton();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.rdbDistancia = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbNodeA
            // 
            this.cmbNodeA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNodeA.FormattingEnabled = true;
            this.cmbNodeA.Location = new System.Drawing.Point(15, 30);
            this.cmbNodeA.Name = "cmbNodeA";
            this.cmbNodeA.Size = new System.Drawing.Size(124, 21);
            this.cmbNodeA.TabIndex = 6;
            // 
            // cmbNodeB
            // 
            this.cmbNodeB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNodeB.FormattingEnabled = true;
            this.cmbNodeB.Location = new System.Drawing.Point(199, 32);
            this.cmbNodeB.Name = "cmbNodeB";
            this.cmbNodeB.Size = new System.Drawing.Size(119, 21);
            this.cmbNodeB.TabIndex = 7;
            // 
            // btnEscolher
            // 
            this.btnEscolher.BackColor = System.Drawing.Color.SkyBlue;
            this.btnEscolher.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEscolher.Location = new System.Drawing.Point(111, 206);
            this.btnEscolher.Name = "btnEscolher";
            this.btnEscolher.Size = new System.Drawing.Size(117, 53);
            this.btnEscolher.TabIndex = 8;
            this.btnEscolher.Text = "Escolher";
            this.btnEscolher.UseVisualStyleBackColor = false;
            this.btnEscolher.Click += new System.EventHandler(this.btnEscolher_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "Cidade inicial:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(196, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "Cidade final:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbAll);
            this.groupBox1.Controls.Add(this.rdbDistancia);
            this.groupBox1.Controls.Add(this.rdbTransito);
            this.groupBox1.Controls.Add(this.rdbCustoPedagio);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(35, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 141);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modelo:";
            // 
            // rdbAll
            // 
            this.rdbAll.AutoSize = true;
            this.rdbAll.Location = new System.Drawing.Point(16, 76);
            this.rdbAll.Name = "rdbAll";
            this.rdbAll.Size = new System.Drawing.Size(237, 22);
            this.rdbAll.TabIndex = 1;
            this.rdbAll.TabStop = true;
            this.rdbAll.Text = "Mais viável (Pedágio + Trânsito)";
            this.rdbAll.UseVisualStyleBackColor = true;
            // 
            // rdbTransito
            // 
            this.rdbTransito.AutoSize = true;
            this.rdbTransito.Location = new System.Drawing.Point(16, 48);
            this.rdbTransito.Name = "rdbTransito";
            this.rdbTransito.Size = new System.Drawing.Size(80, 22);
            this.rdbTransito.TabIndex = 1;
            this.rdbTransito.TabStop = true;
            this.rdbTransito.Text = "Trânsito";
            this.rdbTransito.UseVisualStyleBackColor = true;
            // 
            // rdbCustoPedagio
            // 
            this.rdbCustoPedagio.AutoSize = true;
            this.rdbCustoPedagio.Checked = true;
            this.rdbCustoPedagio.Location = new System.Drawing.Point(16, 20);
            this.rdbCustoPedagio.Name = "rdbCustoPedagio";
            this.rdbCustoPedagio.Size = new System.Drawing.Size(122, 22);
            this.rdbCustoPedagio.TabIndex = 0;
            this.rdbCustoPedagio.TabStop = true;
            this.rdbCustoPedagio.Text = "Custo pedágio";
            this.rdbCustoPedagio.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(234, 233);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(104, 26);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // rdbDistancia
            // 
            this.rdbDistancia.AutoSize = true;
            this.rdbDistancia.Location = new System.Drawing.Point(16, 104);
            this.rdbDistancia.Name = "rdbDistancia";
            this.rdbDistancia.Size = new System.Drawing.Size(87, 22);
            this.rdbDistancia.TabIndex = 1;
            this.rdbDistancia.TabStop = true;
            this.rdbDistancia.Text = "Distância";
            this.rdbDistancia.UseVisualStyleBackColor = true;
            // 
            // EscolheAB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(341, 271);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEscolher);
            this.Controls.Add(this.cmbNodeB);
            this.Controls.Add(this.cmbNodeA);
            this.Name = "EscolheAB";
            this.Text = "Origem e Destino";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbNodeA;
        private System.Windows.Forms.ComboBox cmbNodeB;
        private System.Windows.Forms.Button btnEscolher;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbAll;
        private System.Windows.Forms.RadioButton rdbTransito;
        private System.Windows.Forms.RadioButton rdbCustoPedagio;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.RadioButton rdbDistancia;
    }
}