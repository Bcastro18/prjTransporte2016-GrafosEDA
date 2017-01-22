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
    public partial class formRenomear : Form
    {
        public static Nos novo;

        public formRenomear()
        {
            InitializeComponent();
            foreach (Nos n in Principal.grafo.Nos)
            {
                lstCidades.Items.Add(n.Nome);
            }


        }

        private void lstCidades_MouseClick(object sender, MouseEventArgs e)
        {
            lstConexoes.Items.Clear();
            lstConexoes.Refresh();
            novo =  Principal.grafo.Pesquisar(lstCidades.SelectedItem.ToString());

            foreach(Arcos a in novo.Arcos)
            {
                lstConexoes.Items.Add(a.De.Nome+ "->" + a.Para.Nome);
            }
            lstConexoes.Refresh();
                
        }

        private void lstCidades_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            novo = Principal.grafo.Pesquisar(lstCidades.SelectedItem.ToString());
            NomeNo nn = new NomeNo();
            //chamo a função que ativa o botão que remove
            nn.ShowDialog(); 
            novo.Nome = nn.NomeA;
            if (nn.listaCidades != null)
            {
                double quantPedagios = nn.quantPedagios;
                bool condicaoVia = nn.condicaoVia;
                double custoTransito = nn.custoTransito;
                int km = nn.km;
                //adiciono a cópia dos arcos vindos do nomeNo ao grafo original
                foreach (Arcos a in nn.listaCidades)
                {
                    //adiciono o arco da ida e da volta - sem isso dá problema no hamiltoniano, e adere o fator de LÓGICA
                    //ou seja, vias de mão dupla entre cidades
                    Principal.grafo.AddArco(novo.Nome, a.Para.Nome, a.Custo, a.Pedagios, a.CondicaoVia, a.Km);
                    Principal.grafo.AddArco(a.Para.Nome, novo.Nome, a.Custo, a.Pedagios, a.CondicaoVia, a.Km);

                }
            }

        }
    }
}
