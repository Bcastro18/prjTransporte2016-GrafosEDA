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
    public partial class AddArcos : Form
    {
        //valor pedagio
        public double quantPedagios { get; set; }
        //condicao da via
        public bool condicaoVia { get; set; }
        //media de transito
        public double custoTransito { get; set; }
        //nome da cidade, pego no list
        public string nomeCidade { get; set; }
        //recebe o tamanho da via
        public int km {get; set;} 

        public AddArcos()
        {
            InitializeComponent();
            foreach (Nos n in Principal.grafo.Nos)
                lstCidades.Items.Add(n.Nome);

            foreach (Nos n in Principal.grafo.Nos)
                 for(int i=0; i<n.Arcos.Count; i++)
                       lstExibeCidades.Items.Add(n.Arcos[i].De.Nome +" -> " +n.Arcos[i].Para.Nome);


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtCustoTransito.Text == "" || txtNumPedagios.Text == "" || txtKm.Text == "" || lstCidades.SelectedItem == null || Convert.ToInt32(txtCustoTransito.Text) < 0 || Convert.ToInt32(txtKm.Text) < 0 || Convert.ToInt32(txtNumPedagios.Text) < 0)
            {
                MessageBox.Show("Insira corretamente os dados!");
            } else {
                int o = lstCidades.SelectedIndex;
                string nomeCidade = lstCidades.Items[o].ToString();

                string aux = txtNumPedagios.Text;
                quantPedagios = Convert.ToInt32(aux);
                string aux2 = txtCustoTransito.Text;
                custoTransito = Convert.ToDouble(aux2);
                string aux3 = txtKm.Text;
                km = Convert.ToInt32(aux3);

                if (rdbTrue.Checked)
                {
                    condicaoVia = true;
                }
                else
                {
                    condicaoVia = false;
                }
                //adiciono o nó DESTINO/PARA no grafo auxiliar
                NomeNo.grafoAuxiliar.AddNoAuxiliar(nomeCidade, 0);
                //adiciono no grafo auxiliar um arco do meu nó, que seria, para alguma das outras cidades
                NomeNo.grafoAuxiliar.AddArco(NomeNo.auxNomeGrafo, nomeCidade, custoTransito, quantPedagios, condicaoVia, km);        
                NomeNo.verifica = true;
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
