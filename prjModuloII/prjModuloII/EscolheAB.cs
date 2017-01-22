using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using prjModuloII.EDA;

namespace prjModuloII
{
    public partial class EscolheAB : Form
    {

        private string nomeA;
        public string NomeA
        {

            get { return nomeA; }
            set { nomeA = value; }

        }

        public int rdbs { get; set; }

        //verifica se o form foi fechado - como se fosse um lock
        public bool verifica {get; set;}

        private string nomeB;
        public string NomeB
        {

            get { return nomeB; }
            set { nomeB = value; }

        }
 
        public EscolheAB()
        {
            InitializeComponent();
            verifica = false;

            foreach (Nos n in Principal.grafo.Nos)
            {
                cmbNodeA.Items.Add(n.Nome);
                cmbNodeB.Items.Add(n.Nome);
            }

        }
        public void VisibleFalseGroupBox()
        {
            groupBox1.Visible = false;
        }

        private void btnEscolher_Click(object sender, EventArgs e)
        {

            if (cmbNodeA.SelectedItem == null || cmbNodeB.SelectedItem == null)
            {
                MessageBox.Show("escolha os campos corretamente!");
            }
            else
            {
                nomeA = (string)cmbNodeA.SelectedItem.ToString();
                nomeB = (string)cmbNodeB.SelectedItem.ToString();
                if (rdbAll.Checked)
                    rdbs = 3;
                else if (rdbCustoPedagio.Checked)
                    rdbs = 1;
                else if (rdbTransito.Checked)
                    rdbs = 2;
                else if (rdbDistancia.Checked)
                    rdbs = 4;

                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            verifica = true;
            this.Close();
        }

       
    }
}
