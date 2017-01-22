using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using prjModuloII.EDA;
using System.IO;

namespace prjModuloII
{
    public partial class Principal : Form
    {
        //lista de nós no pcture box de exibição do form
        private List<Point> nos;

        //lista de pontos dos arcos, APENAS PARA VISUALIZAÇÃO
        private List<Point> pontosArcos; 

        //grafo geral - IMPORTANTE
        public static Grafo grafo;

        //pictureBox visual no form
        private static PictureBox pbMaze;


        public Principal()
        {
            InitializeComponent();
            
            //propriedades dos botões 
            btnReiniciar.Visible = false;
            btnCongestionamento.Enabled = false;
            btnMinimo.Enabled = false;
            btnHamiltonian.Enabled = false;
            btnRenomear.Enabled = false;
            btnVisualizar.Enabled = false;
        
            //inicializa propriedades
            nos = new List<Point>();
            pontosArcos = new List<Point>();
            pbMaze = new PictureBox();

            //inicializa o picture box
            ((System.ComponentModel.ISupportInitialize)(pbMaze)).BeginInit();
            pbMaze.Location = new System.Drawing.Point(3, 2);
            pbMaze.Margin = new System.Windows.Forms.Padding(4);
            pbMaze.Name = "pbMaze";
            pbMaze.Size = new System.Drawing.Size(800, 504);
            pbMaze.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbMaze_MouseDown);
            this.Controls.Add(pbMaze);
            //conclui a inicialização
            ((System.ComponentModel.ISupportInitialize)(pbMaze)).EndInit();  
            //atualiza de acordo com a Gui
            pbMaze.Image = GUI.CriaMapa(nos, pontosArcos);
        }

        private void pbMaze_MouseDown(object sender, MouseEventArgs e)
        {

            int x = e.X / 25;
            int y = e.Y / 25;
            int indiceNo = FindNo(x, y);

            if (indiceNo >= 0)
            {
                if (rbNo.Checked)
                    nos.RemoveAt(indiceNo);
                else if (rdbConexao.Checked)
                    pontosArcos.RemoveAt(indiceNo);
            }

            if (rbNo.Checked && indiceNo < 0)
            {
                nos.Add(new Point(x, y));
            }
            if (rdbConexao.Checked && indiceNo < 0)
            {
                pontosArcos.Add(new Point(x, y));   
            }
            //atualiza o mapa
            pbMaze.Image = GUI.CriaMapa(nos, pontosArcos);
        }

        //usado na hora de encontrar os locais das cidades quando se cria o grafo
        private int FindCidade(int x, int y)
        {
            for (int i = nos.Count - 1; i >= 0; i--)
            {
                if (nos[i].X == x && nos[i].Y == y)
                {
                    return i;
                }
            }
            return -1;
        }

        private void btnGrafo_Click(object sender, EventArgs e)
        {
                grafo = new Grafo();
                NomeNo nomeNo;
                
                
                //Adicionando nós percorrendo todos os pontos do pbMaze
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {                        
                        if (FindCidade(i, j) >= 0)
                        {
                            nomeNo = new NomeNo();
                            nomeNo.ShowDialog();
                            double quantPedagios = nomeNo.quantPedagios;
                            bool condicaoVia = nomeNo.condicaoVia;
                            double custoTransito = nomeNo.custoTransito;
                            int km = nomeNo.km;
                            string nomeCid = "("+i.ToString() + "-" + j.ToString()+")" + nomeNo.NomeA;

                            grafo.AddNoAuxiliar(nomeCid, nomeCid.ToString());

                            //adiciono a cópia dos arcos vindos do nomeNo ao grafo original
                            foreach (Arcos a in nomeNo.listaCidades)
                            {
                                //adiciono o arco da ida e da volta - sem isso dá problema no hamiltoniano, e adere o fator de LÓGICA
                                //ou seja, vias de mão dupla entre cidades
                                grafo.AddArco(nomeCid, a.Para.Nome, a.Custo, a.Pedagios, a.CondicaoVia, a.Km);
                                grafo.AddArco(a.Para.Nome, nomeCid, a.Custo, a.Pedagios, a.CondicaoVia, a.Km);
   
                            }
                        }
                            
                    }
                }
                //pbMaze.Image = GUI.CriaMapa(nos, arcos, noA, noB);
                //propriedades dos botões    
                btnGrafo.Enabled = false;
                btnReiniciar.Visible = true;
                groupBox1.Visible = false;
                btnVisualizar.Enabled = true;
                btnRenomear.Enabled = true;
                pbMaze.Enabled = false;
                btnCongestionamento.Enabled = true;
                btnMinimo.Enabled = true;
                btnHamiltonian.Enabled = true;
                btnGrafo.Enabled = true;
                
        }

        //encontrar pontos no pbMaze que eventualmente não sejam cidades
        private int FindNo(int x, int y)
        {
            if (rbNo.Checked)
            {
                for (int i = nos.Count - 1; i >= 0; i--)
                {
                    if (nos[i].X == x && nos[i].Y == y)
                    {
                        return i;
                    }
                }
                return -1;
            }//if
            else if(rdbConexao.Checked)
            {
                for (int i = pontosArcos.Count - 1; i >= 0; i--)
                {
                    if (pontosArcos[i].X == x && pontosArcos[i].Y == y)
                    {
                        return i;
                    }
                }
                return -1;
            }//else if
            return -1;
        }//método

        private void btnMinimo_Click(object sender, EventArgs e)
        {
                EscolheAB escolheAB = new EscolheAB();
                escolheAB.ShowDialog();

                //verifica se o formulario escolheAB foi executado ou teve sua execução cancelada, NECESSITA esta verificação
                if (escolheAB.verifica == false)
                {
                    List<Nos> caminho = new List<Nos>();
                    int opcao = escolheAB.rdbs;
                    string nome = escolheAB.NomeA;
                    string sai = escolheAB.NomeB;
                    if (grafo != null)
                    {
                        //gera o caminho mínimo com a opção que o usuário quer
                        caminho = grafo.CaminhoMinimo(nome, sai, opcao);
                    }

                    lstResp.Items.Clear();
                    if (caminho != null)
                    {
                        foreach (Nos n in caminho)
                            lstResp.Items.Add(n.Nome);

                        //propriedades dos botões
                        lstResp.Visible = true;
                        lblResp.Visible = true;
                        ptbLogo.Visible = false;
                        MessageBox.Show("O valor final será: " + grafo.valorFinal.ToString());
                    } else 
                        MessageBox.Show("Impossível fazer uma rota que passe por todas as cidades!");
                }

          
        }

        private void btnHamiltonian_Click(object sender, EventArgs e)
        {
                recebeValorCombustivel rvc = new recebeValorCombustivel();
                rvc.ShowDialog();
                double valorCombustivel = rvc.valorCombustivel;

                if (rvc.verifica == true)
                {
                    List<string> resp = new List<string>();

                    if (grafo != null)
                        resp = grafo.HamiltonianPath();

                    lstResp.Items.Clear();
                    if (resp != null)
                    {
                        foreach (string nome in resp)
                            lstResp.Items.Add(nome);

                        //propriedades dos botões
                        lstResp.Visible = true;
                        lblResp.Visible = true;
                        ptbLogo.Visible = false;
                        MessageBox.Show("O valor gasto será de R$" + (grafo.valorFinal * valorCombustivel).ToString() + ",00 reais em " + grafo.valorFinal + " km.");
                    }
                    else
                        MessageBox.Show("Impossível fazer uma rota que passe por todas as cidades!");
                }
        }

        private void btnCongestionamento_Click(object sender, EventArgs e)
        {

                EscolheAB ab = new EscolheAB();
                ab.VisibleFalseGroupBox();
                ab.ShowDialog();

                ComplicaTransito ct = new ComplicaTransito();

                string nome = ab.NomeA;
                string sai = ab.NomeB;

                double flow = ct.MaxFlow(nome, sai);

                List<Arcos> listaCongestionados = new List<Arcos>();

                listaCongestionados = ct.CuttingEdges(nome, sai, flow);

                lstResp.Items.Clear();
                if (listaCongestionados != null)
                {
                    foreach (Arcos a in listaCongestionados)
                        lstResp.Items.Add(a.De.Nome + " -> " + a.Para.Nome);

                    //propriedades dos botões
                    lstResp.Visible = true;
                    lblResp.Visible = true;
                    ptbLogo.Visible = false;
                } else
                        MessageBox.Show("Impossível fazer uma rota que passe por todas as cidades!");
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            grafo = new Grafo();
            pbMaze.Enabled = true;
            ptbLogo.Visible = true;
            lblResp.Visible = false;
            groupBox1.Visible = true;
            lstResp.Visible = false;
            btnGrafo.Enabled = true;
            btnVisualizar.Enabled = false;
            btnRenomear.Visible = false;
            btnReiniciar.Visible = false;
            btnCongestionamento.Enabled = false;
            btnMinimo.Enabled = false;
            btnHamiltonian.Enabled = false;
            pbMaze.ResetText();
        }

        private void btnRenomear_Click(object sender, EventArgs e)
        {
            formRenomear fm = new formRenomear();
            fm.ShowDialog();

        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            VisualizarMapa vm = new VisualizarMapa();
            vm.ShowDialog();
        }

        private void lstResp_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TextWriter grava = new StreamWriter("Rota.doc");
            grava.Write("A ordem das cidades seria:");
            grava.Write(grava.NewLine);
            foreach(string linha in lstResp.Items)
            {
                grava.WriteLine(linha);
            }
            grava.Write(grava.NewLine);
            grava.Write("Se beber não dirija! Tenha uma boa viagem!");
            grava.Write(grava.NewLine);
            grava.Write(grava.NewLine);
            grava.Write("Bruno de Castro Celestino - Developer");
            grava.Flush();
            grava.Close();
            MessageBox.Show("Salvo!");
         
        }
        
    }
}
