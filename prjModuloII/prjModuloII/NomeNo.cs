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
    public partial class NomeNo : Form
    {
        public string nomeA;
        public string NomeA
        {

            get { return nomeA; }
            set { nomeA = value; }

        }

        public List<Arcos> listaCidades = new List<Arcos>();

        public double quantPedagios {get; set;}

        public int km { get; set; }

        public bool condicaoVia {get; set;}

        //variável auxiliar para poder fazer a adição dos arcos no form AddArcos
        public static string auxNomeGrafo {get;set;}


        public double custoTransito {get; set;}


        public string nomeCidade { get; set; }

        //grafo auxiliar que eu criei pra poder fazer uma adição de arcos e depois copiá-los para o grafo no form da classe Principal
        public static Grafo grafoAuxiliar { get; set; }

        //evitar erro com o form do EscolheAB - se ele foi executado corretamente, variável Lock
        public static bool verifica { get; set; }

        public NomeNo()
        {    
            InitializeComponent();
            verifica = false;
            grafoAuxiliar = new Grafo();
        }

        public void btnAddNode_Click(object sender, EventArgs e)
        {

            if (txtNodeName.Text == "")
            {
                MessageBox.Show("Não é permitido campos nulos!");
            }
            else
            {
                
                nomeA = txtNodeName.Text;
                if(Principal.grafo.Pesquisar(nomeA)  != null){
                    MessageBox.Show("Esse nome ja existe! Digite outro!");
                }else{
                    //pesquiso dentro de todos os nós do grafo auxiliar os arcos existentes, basicamente esse grafo funciona como uma árvore
                    if (verifica == true)
                    {
                        foreach (Nos a in grafoAuxiliar.Nos)
                            for (int f = 0; f < a.Arcos.Count; f++)
                            {
                                //adiciona na lista de arcos os arcos que eu peguei do form addArcos
                                listaCidades.Add(a.Arcos[f]);
                            }
                    }
                
                    this.Close();
               
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            nomeA = "erro";
            Application.Exit();
        }

        private void btnChamaArco_Click(object sender, EventArgs e)
        {
            //pego o nome que está no txt para depois adicioná-lo
            auxNomeGrafo = txtNodeName.Text;
            //se a pessoa não digitar algo na caixa de texto ele não deixa chamar o outro formulário
            if (auxNomeGrafo == "")
                MessageBox.Show("Impossível adicionar vias sem ao menos digitar um possível nome para a cidade de origem!");
            else
            {
                grafoAuxiliar.AddNoAuxiliar(auxNomeGrafo, 0);
                AddArcos ad = new AddArcos();
                ad.ShowDialog();
                quantPedagios = ad.quantPedagios;
                custoTransito = ad.custoTransito;
                condicaoVia = ad.condicaoVia;
                nomeCidade = ad.nomeCidade;
                km = ad.km;
            }

        }

    }
}
