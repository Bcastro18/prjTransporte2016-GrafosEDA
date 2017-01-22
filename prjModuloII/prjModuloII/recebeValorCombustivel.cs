using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace prjModuloII
{
    public partial class recebeValorCombustivel : Form
    {
        public double valorCombustivel { get; set; }
        //autoriza a continuação no form principal
        public bool verifica {get; set;}

        public recebeValorCombustivel()
        {
            verifica = false;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtRecebe.Text != "")
            {
                valorCombustivel = Convert.ToInt32(txtRecebe.Text);
                verifica = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Insira um valor no campo!");
            }
        }
    }
}
