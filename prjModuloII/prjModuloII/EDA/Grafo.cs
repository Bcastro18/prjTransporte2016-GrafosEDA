using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prjModuloII.EDA
{
    public class Grafo
    {
        #region Atributos

        /// <summary>
        /// Lista de nós do grafo
        /// </summary>
        private List<Nos> nos;

        public double valorFinal;

        #endregion

        #region Propriedades

        /// <summary>
        /// Mostra todos os nós do grafo.
        /// </summary>
        public Nos[] Nos
        {
            get { return this.nos.ToArray(); }
        }

        #endregion

        #region Construtores

        /// <summary>
        /// Cria nova instância do grafo.
        /// </summary>
        public Grafo()
        {
            valorFinal = 0;
            this.nos = new List<Nos>();
        }

        #endregion

        #region Métodos
        public void Limpar()
        {

            foreach (Nos n in this.nos)
                n.Visitado = false;
        }

        #endregion

        #region Operações Grafo

        /// <summary>
        /// Encontra o nó através do seu nome.
        /// </summary>
        /// <param name="name">O nome do nó.</param>
        /// <returns>O nó encontrado é nulo caso não encontre nada.</returns>
        public Nos Pesquisar(string nome)
        {
            //return this.nodes.SingleOrDefault(e => e.Name == name);
            foreach (Nos no in this.nos)
            {
                if (no.Nome == nome)
                {
                    return no;
                }
            }
            return null;
        }

        /// <summary>
        /// Encontra o ARCO através do De e Para
        /// </summary>
        /// <param name="from">Nó origem</param>
        /// <param name="to">Nó destino</param>
        public List<Arcos> Pesquisar(string from, string to)
        {
            var edges = new List<Arcos>();
            foreach (var node in this.Nos)
            {
                var result = node.Arcos.Where(e => e.De.Nome == from && e.Para.Nome == to);
                if (result != null)
                {
                    edges.AddRange(result);
                }
            }
            return edges;
        }


        /// <summary>
        /// Adiciona um nó ao grafo.
        /// </summary>
        /// <param name="name">O nome do nó a ser adicionado.</param>
        public void AddNo(string nome)
        {
            AddNo(nome, null);
        }

        /// <summary>
        /// Adiciona um nó ao grafo.
        /// </summary>
        /// <param name="name">O nome do nó a ser adicionado.</param>
        /// <param name="info">A informação a ser armazenada no nó.</param>
        public void AddNo(string nome, object info)
        {
            if (Pesquisar(nome) != null)
            {
                throw new Exception("Um nó com o mesmo nome já foi adicionado a este grafo.");
            }
            this.nos.Add(new Nos(nome, info));
        }

        /// <summary>
        /// Adiciona um nó ao grafo, porém um método para não lançar excessão quando tentar adicionar um nó já existente
        /// </summary>
        /// <param name="name">O nome do nó a ser adicionado.</param>
        /// <param name="info">A informação a ser armazenada no nó.</param>
        public void AddNoAuxiliar(string nome, object info)
        {
            /*if (Pesquisar(nome) != null)
            {
                throw new Exception("Um nó com o mesmo nome já foi adicionado a este grafo.");
            }
            this.nos.Add(new Nos(nome, info));*/
           
            if(Pesquisar(nome) == null){
                this.nos.Add(new Nos(nome, info));
            }
        }
        
        /// <summary>
        /// Remove um nó do grafo.
        /// </summary>
        /// <param name="name">O nome do nó a ser removido.</param>
        public void RemoveNo(string nome)
        {
            Nos NoExistente = Pesquisar(nome);
            if (NoExistente == null)
            {
                throw new Exception("Não foi possível encontrar o nó a ser removido.");
            }
            this.nos.Remove(NoExistente);
        }

        /// <summary>
        /// Remove arco de um nó do grafo
        /// </summary>
        /// <param name="edge">O arco a ser removido</param>
        public void RemoveArco(Arcos edge)
        {
            var node = Pesquisar(edge.De.Nome);
            node.RemoveArco(edge);
        }

        /// <summary>
        /// Adiciona o arco entre dois nós associando determinado custo.
        /// </summary>
        /// <param name="de">O nó de origem.</param>
        /// <param name="para">O nó de destino.</param>
        /// <param name="custo">O custo associado.</param>
        public void AddArco(string de, string para, double custo)
        {
            Nos start = Pesquisar(de);
            Nos end = Pesquisar(para);
            // Verifica se os nós existem..
            if (start == null)
            {
                throw new Exception("Não foi possível encontrar o nó origem no grafo.");
            }
            if (end == null)
            {
                throw new Exception("Não foi possível encontrar o nó destino no grafo.");
            }
            start.AddArco(end, custo);
        }

        /// <summary>
        /// Adiciona o arco entre dois nós associando determinado custo.
        /// </summary>
        /// <param name="de">O nó de origem.</param>
        /// <param name="para">O nó de destino.</param>
        /// <param name="custo">Taxa média de trânsito</param>
        /// <param name="pedagios">O valor R$ dos pedágios da via.</param>
        /// <param name="condicao">Condição da via.</param>
        public void AddArco(string de, string para, double custo, double pedagios, bool condicao, int km)
        {
            Nos start = Pesquisar(de);
            Nos end = Pesquisar(para);
            // Verifica se os nós existem..
            if (start == null)
            {
                throw new Exception("Não foi possível encontrar o nó origem no grafo.");
            }
            if (end == null)
            {
                throw new Exception("Não foi possível encontrar o nó destino no grafo.");
            }
            start.AddArco(end, custo, pedagios, condicao, km);
        }

        /// <summary>
        /// Adiciona o arco entre dois nós associando determinado custo.
        /// </summary>
        /// <param name="from">O nó de origem.</param>
        /// <param name="to">O nó de destino.</param>
        /// <param name="capacity">Capacidade do arco - vinculado ao custo médio do trânsito</param>
        /// <param name="networkEdge">adiciona mesmo que não exista a networkEdge</param>
        public void AddArco(string from, string to, double capacity, Arcos networkEdge = null)
        {
            Nos start = Pesquisar(from);
            Nos end = Pesquisar(to);
            // Verifica se os nós existem..
            if (start == null)
            {
                throw new Exception("Não foi possível encontrar o nó origem no grafo.");
            }
            if (end == null)
            {
                throw new Exception("Não foi possível encontrar o nó destino no grafo.");
            }
            start.AddArco(end, capacity, networkEdge);
        }

        /// <summary>
        /// Obtem todos os nós vizinhos de determinado nó.
        /// </summary>
        /// <param name="node">O nó origem.</param>
        /// <returns></returns>
        public Nos[] GetNeighbours(string de)
        {
            Nos no = Pesquisar(de);
            // Verifica se os nós existem
            if (no == null)
            {
                throw new Exception("Não foi possível encontrar o nó origem no grafo.");
            }
            List<Nos> vizinhos = new List<Nos>();
            foreach (Arcos arco in no.Arcos)
            {
                vizinhos.Add(arco.Para);
            }
            return vizinhos.ToArray();
            //return node.Edges.Select(e => e.To).ToArray();
        }

        #endregion

        #region Buscas

        /// <summary>
        /// Executa o caminho em profundidade buscando o nó alvo.
        /// </summary>
        /// <param name="startNode">O nó inicio.</param>
        /// <returns>A lista de nós visitada.</returns>
        public List<Nos> BuscaEmProfundidade(string noInicial)
        {
            Limpar();
            Stack<Nos> pilha = new Stack<Nos>();
            List<Nos> lista = new List<Nos>();

            Nos n;
            n = Pesquisar(noInicial);
            n.Visitado = true;
            pilha.Push(n);

            while (pilha.Count > 0)
            {

                n = pilha.Pop();
                lista.Add(n);
                foreach (Arcos e in n.Arcos)
                {
                    if (e.Para.Visitado == false)
                    {
                        e.Para.Visitado = true;
                        pilha.Push(e.Para);
                    }
                }

            }
            return lista;
     }

        /// <summary>
        /// Executa o caminho em largura buscando o nó alvo.
        /// </summary>
        /// <param name="startNode">O nó inicio.</param>
        /// <returns>A lista de nós visitada.</returns>
        public List<Nos> PasseioEmLargura(string noInicial)
        {
            Limpar();
            Queue<Nos> fila = new Queue<Nos>();
            List<Nos> lista = new List<Nos>();

            Nos n;
            n = Pesquisar(noInicial);
            n.Visitado = true;
            fila.Enqueue(n);

            while (fila.Count > 0)
            {

                n = fila.Dequeue();
                lista.Add(n);
                foreach (Arcos e in n.Arcos)
                {
                    if (e.Para.Visitado == false)
                    {
                        e.Para.Visitado = true;
                        fila.Enqueue(e.Para);
                    }
                }

            }
            return lista;
        }
        #endregion

        #region Caminhos Mínimos

        //calcula o custo para o caminho mínimo total
        private double PegaCusto(bool condicao, double custoTransito, double pedagios, int km)
        {
            double cost=0;
            cost = custoTransito + pedagios + km / 4;
            if(condicao == true)
            {
                cost /= 1.25;
            }
            return cost;
        }

        /// <summary>
        /// Executa o algoritmo de caminho mínimo (Djkistra) buscando o nó alvo.
        /// </summary>
        /// <param name="startNode">O nó inicio.</param>
        /// <param name="targetNode">O nó alvo.</param>
        /// <returns>A lista de nós visitada.</returns>
        public List<Nos> CaminhoMinimo(string noIni, string noFim, int op)
        {

            Grafo solucao = new Grafo();
            this.Pesquisar(noIni).Visitado = true;
            Nos n = Pesquisar(noIni);
            solucao.AddNoAuxiliar(noIni, 0);
            bool finished = false;

            //faço enquanto o nó destino não estiver no grafo solução
            while (solucao.Pesquisar(noFim) == null && !finished)
            {
                double min = double.MaxValue, edgeCost = 0;
                string from = null, to = null;

                foreach (Nos ns in solucao.nos)
                {
                    Nos no = this.Pesquisar(ns.Nome);

                    foreach (Arcos e in no.Arcos)
                    {
                        if (!e.Para.Visitado)
                        {
                            //faço o custo de acordo com a opção que o cliente solicitou, mais viável de todas, levando em conta apenas os pedágios ou utilizando o caminho com menor trânsito
                            double custo;
                            if (op == 3)
                                custo = Convert.ToDouble(ns.Info) + PegaCusto(e.CondicaoVia, e.Custo, e.Pedagios, e.Km);
                            else if (op == 2)
                                custo = Convert.ToDouble(ns.Info) + e.Custo;
                            else if (op == 4)
                                custo = Convert.ToInt32(ns.Info) + e.Km;
                            else
                                custo = Convert.ToDouble(ns.Info) + e.Pedagios;

                            if (custo < min)
                            {
                                min = custo;
                                edgeCost = e.Custo;
                                from = e.De.Nome;
                                to = e.Para.Nome;
                                valorFinal = custo;
                            }//if
                        }//if

                    }//foreach

                }//foreach
                if (from != null)
                {
                    solucao.AddNoAuxiliar(to, min);
                    solucao.AddArco(to, from, edgeCost);
                    this.Pesquisar(to).Visitado = true;
                }
                else
                {
                    finished = true;
                }

            }//while

            Nos target = solucao.Pesquisar(noFim);
            //List<Nos> lista = new List<Nos>();
            if (target == null)
            {
                return null;
            }
            Stack<Nos> stack = new Stack<Nos>();
            stack.Push(target);
            while (target.Arcos.Count > 0)
            {
                target = target.Arcos[0].Para;
                stack.Push(target);
            }
            this.Limpar();
            return new List<Nos>(stack.ToArray());
        }

        #endregion

        #region Hamiltoniano

        public List<string> HamiltonianPath()
        {
            //alterei o retorno para ao invés de uma única string, retornar uma LISTA para facilitar a exibição
            List<string> retorno = new List<string>();
            foreach (Nos n in this.nos)
            {
                retorno = this.HamiltonianPath(n);
                if (retorno != null) return retorno;
            }
            return null;
        }

        private List<string> HamiltonianPath(Nos n)
        {
            // Cria fila para armazenar o resultado
            Queue<Nos> queue = new Queue<Nos>();
            // Arvore
            Grafo arvore = new Grafo();
            List<string> retorna = new List<string>();
            int id = 0;
            id++;
            arvore.AddNo(id.ToString(), n.Nome);
            queue.Enqueue(arvore.Pesquisar(id.ToString()));

            // Realiza a busca até que não haja mais nós em espera na fila
            while (queue.Count > 0)
            {
                Nos np = queue.Dequeue();
                Nos currentNode = this.Pesquisar(np.Info.ToString());
                if (this.nos.Count == ContaNos(np))
                {
                    string ret = np.Info.ToString();
                    retorna.Add(ret);
                    valorFinal = np.Arcos[0].Custo;
                    while (np.Arcos.Count > 0)
                    {
                        valorFinal += np.Arcos[0].Custo;
                        np = np.Arcos[0].Para;
                        ret = np.Info.ToString();
                        retorna.Add(ret);
                        
                    }

                    return retorna;
                }

                foreach (Arcos arco in currentNode.Arcos)
                {
                    if (!ExisteNo(np, arco.Para.Nome))
                    {
                        id++;
                        arvore.AddNo(id.ToString(), arco.Para.Nome);
                        Nos nf = arvore.Pesquisar(id.ToString());
                        queue.Enqueue(nf);
                        arvore.AddArco(nf.Nome, np.Nome, arco.Km);
                    }
                }
            }

            return null;
        }

        private bool ExisteNo(Nos np, string p)
        {
            if (np == null) return false;
            while (np.Arcos.Count > 0)
            {
                if (np.Info.ToString() == p) return true;
                np = np.Arcos[0].Para;
            }
            return np.Info.ToString() == p;
        }

        private int ContaNos(Nos np)
        {
            if (np == null) return 0;
            int count = 1;
            while (np.Arcos.Count > 0)
            { count++; np = np.Arcos[0].Para; }
            return count;
        }

        #endregion

    }
}
