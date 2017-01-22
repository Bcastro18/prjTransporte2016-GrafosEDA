using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prjModuloII.EDA
{
    public class ComplicaTransito
    {
        #region Atributos

        /// <summary>
        /// Grafo origem
        /// </summary>
        public Grafo Rede{ get; set; }
        /// <summary>
        /// Grafo residual
        /// </summary>
        public Grafo Residual { get; set; }

        #endregion

        #region Construtores

        /// <summary>
        /// Cria novo fluxo em redes.
        /// </summary>
        public ComplicaTransito()
        {
            //ao invés de criar um novo, faz um igual ao grafo da classe principal, onde eu crio também para o caminho mínimo e para o hamiltoniano
            this.Rede = Principal.grafo;
        }

        #endregion

        #region Métodos Básicos

        /// <summary>
        /// Adiciona um nó no fluxo
        /// </summary>
        /// <param name="name"></param>
        /// <param name="info"></param>
        public void AddNo(string nome, object info)
        {
            info = null;
            this.Rede.AddNo(nome, info);
        }

        /// <summary>
        /// Adiciona um arco ao fluxo.
        /// </summary>
        /// <param name="de">Nó de origem</param>
        /// <param name="para">Nó destino</param>
        /// <param name="capacity">Capacidade do arco</param>
        public void AddArco(string de, string para, int capacity)
        {
            this.Rede.AddArco(de, para, 0);
        }

        #endregion

        #region MaxFlow e Cutting Edges

        public double MaxFlow(string ini, string fim)
        {
            //chamo o método para Construir um grafo Residual
            ConstroiGrafoResidual();

            double maxFlow = 0;
            //pego um caminho do GrafoResidual - ini e fim são meus início e fim da rede (s e t)
            var caminho = PegaGrafoResidual(ini, fim);
            //Executa enquanto houverem caminhos
            while (caminho != null)
            {
                //lembrando que eu utilizo o trânsito para verificar onde causaria o gargalo na rede. Ou seja, um possível congestionamento
                //pego o valor que é o menor entre todas as edges
                var flow = caminho.Min(e => e.Custo);
                // Consome parte do fluxo no grafo origem
                foreach (var edge in caminho)
                {
                    // Consome fluxo no arco origem, do grafo Rede
                    if (edge.NetworkEdge != null)
                    {
                        edge.NetworkEdge.Consome(flow);
                    }
                    // Atualiza o grafo residual
                    AtualizaGrafoResidual(edge, flow);
                }
                //o maxFlow é incrementado
                maxFlow += flow;
                //novamente pego um caminho
                caminho = PegaGrafoResidual(ini, fim);
            }
            return maxFlow;
        }

        /// <summary>
        /// Analisa o fluxo e calcula as informações.
        /// </summary>
        /// <param name="source">O nó origem.</param>
        /// <param name="sink">O nó destino.</param>
        public List<Arcos> CuttingEdges(string source, string sink, double maxFlow)// out double maxFlow)
        {
            var cuttingEdges = new List<Arcos>();
            maxFlow = MaxFlow(source, sink);
            foreach (var node in this.Rede.Nos)
            {
                foreach (var edge in node.Arcos)
                {
                    if (edge.CustoUsado == edge.Custo)
                    {
                        cuttingEdges.Add(edge);
                    }
                }
            }
            return cuttingEdges;
        }

        /// <summary>
        /// Atualiza o grafo residual, após a passagem de "flow" pelo arco.
        /// </summary>
        /// <param name="edge">O arco por onde o fluxo passou.</param>
        /// <param name="flow">O fluxo que passou pelo arco.</param>
        private void AtualizaGrafoResidual(Arcos edge, double flow)
        {
            //pesquisa o arco no grafo residual
            var edges = this.Residual.Pesquisar(edge.Para.Nome, edge.De.Nome);
            //Para cada arco encontrado, aumentar seu fluxo
            if (edges != null && edges.Count > 0)
            {
                edges[0].Custo += flow;
            }
            else
            {
                //se não existir o arco da volta, ele cria um e coloca o flow que já usou
                this.Residual.AddArco(edge.Para.Nome, edge.De.Nome, flow);
            }
            // Atualiza a capacidade e remove o arco se necessário
            edge.Custo -= flow;
            if (edge.Custo == 0)
            {
                this.Residual.RemoveArco(edge);
            }
        }

        /// <summary>
        /// Constroi o grafo residual.
        /// </summary>
        private void ConstroiGrafoResidual()
        {
            // Cria grafo residual
            this.Residual = new Grafo();
            //adiciono os nós ao grafo residual
            foreach (var node in this.Rede.Nos)
            {
                this.Residual.AddNo(node.Nome, node.Info);
            }
            //pra cada nó da rede
            foreach (var node in this.Rede.Nos)
            {
                //eu pego os arcos deles
                foreach (var edge in node.Arcos)
                {
                    //coloco null no ArcoDaRede que eu sei
                    edge.NetworkEdge = null;
                    //Coloco o CustoUsado dele como 0
                    edge.ResetaCapacidade();
                    //adiciono no residual o arco
                    this.Residual.AddArco(edge.De.Nome, edge.Para.Nome, edge.Custo, edge);
                }
            }
        }

        /// <summary>
        /// Obtém um caminho de origem a destino no grafo residual.
        /// </summary>
        /// <returns>A lista de arcos que compõe o caminho.</returns>
        private List<Arcos> PegaGrafoResidual(string source, string sink)
        {
            // Limpa os nós visitados no grafo residual para poder usar de novo 
            foreach (var node in this.Residual.Nos)
            {
                node.SourceArco = null;
                node.Visitado = false;
            }

            // Executa passeio em largura
            var queue = new Queue<Nos>();
            //pego o nó inicial no grafo residual
            var sourceNode = this.Residual.Pesquisar(source);
            // Marca nó como visitado e adiciona a fila
            sourceNode.Visitado = true;
            queue.Enqueue(sourceNode);
            //enquanto tiver nó na fila, ele continua a fazer
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                //comparo se meu nó é o final, se for false ele ignora
                if (String.Compare(node.Nome, sink, false) == 0)
                {
                    Stack<Arcos> stack = new Stack<Arcos>();
                    //enquanto eu não chego no De que gerou todo mundo, eu não paro de adicionar na pilha, ou seja
                    //eu pego do último nó e vou voltando e adicionando na pilha os ARCOS QUE GERARAM O RESPECTIVO NÓ
                    //de Source a Sink, um caminho para poder calcular o maxFlow
                    while (node.SourceArco != null)
                    {
                        stack.Push(node.SourceArco);
                        node = node.SourceArco.De;
                    }
                    // Constroi o caminho
                    return stack.ToList();
                }
                //passo todos os arcos do nó
                foreach (var edge in node.Arcos)
                {
                    // Adiciona a fila e marca como visitado
                    if (!edge.Para.Visitado)
                    {
                        queue.Enqueue(edge.Para);
                        edge.Para.Visitado = true;
                        //coloco no SourceArco o edge do De(from) dele
                        edge.Para.SourceArco = edge;
                    }
                }
            }
            return null;
        }

        #endregion

    }
}
