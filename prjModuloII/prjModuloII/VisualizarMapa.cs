using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using prjModuloII.EDA;
using Glee = Microsoft.Glee.Drawing;
using GleeUI = Microsoft.Glee.GraphViewerGdi;

namespace prjModuloII
{
    public partial class VisualizarMapa : Form
    {
        public Grafo grafoVisualiza;

        public VisualizarMapa()
        {
            grafoVisualiza = Principal.grafo;
            InitializeComponent();
            DesenhaGrafo();
        }

        public void DesenhaGrafo()
        {
            List<Arcos> arcos = new List<Arcos>();
            Glee.Graph desenhaGrafo = new Glee.Graph("Mapa");

            // Adiciona nós ao grafo que visualiza
            foreach (Nos no in this.grafoVisualiza.Nos)
            {
                //atributos da cidade no desenho, desenho dos nós
                Glee.Node desenhaNo = desenhaGrafo.AddNode(no.Nome);
                desenhaNo.Attr.Shape = Glee.Shape.Circle;
                desenhaNo.Attr.Fillcolor = Glee.Color.Black;
                desenhaNo.Attr.Label = String.Format("{0}", no.Nome);
                desenhaNo.Attr.Fontcolor = Glee.Color.Yellow;
                desenhaNo.Attr.AddStyle(Glee.Style.Bold);
                
                //Adiciono os arcos do nó na lista total de arcos
                arcos.AddRange(no.Arcos);
            }
            foreach (Arcos arco in arcos)
            {
                Glee.Edge desenhaArco = desenhaGrafo.AddEdge(arco.De.Nome, arco.Para.Nome);
                desenhaArco.Attr.Label = String.Format("{0} ; {1} ; {2}", "P: " + arco.Pedagios, "T:" + arco.Custo, "D: " + arco.Km);
                desenhaArco.EdgeAttr.AddStyle(Glee.Style.Bold);

            }

            GleeUI.GViewer viewer = new GleeUI.GViewer();
            viewer.NavigationVisible = false;
            viewer.OutsideAreaBrush = Brushes.White;
            viewer.RemoveToolbar();
            viewer.Graph = desenhaGrafo;
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlVisualiza.Controls.Clear();
            pnlVisualiza.Controls.Add(viewer);


        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(this.pnlVisualiza.Width, this.pnlVisualiza.Height);

            this.pnlVisualiza.DrawToBitmap(bmp, new Rectangle(0, 0, this.pnlVisualiza.Width, this.pnlVisualiza.Height));

            bmp.Save("MapaCidades.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

            MessageBox.Show("Salvo!");
        }
    }
}
