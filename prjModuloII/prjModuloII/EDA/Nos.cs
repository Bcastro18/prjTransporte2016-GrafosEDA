using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prjModuloII.EDA
{
    public class Nos
    {

        #region Propriedades

        /// <summary>
        /// Indica se o nó foi visitado.
        /// </summary>
        public bool Visitado { get; set; }
        /// <summary>
        /// O nome do nó dentro do grafo
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// A informação adicional do nó.
        /// </summary>
        public object Info { get; set; }
        /// <summary>
        /// A lista de arcos associada ao nó.
        /// </summary>
        public List<Arcos> Arcos { get; private set; }
        /// <summary>
        /// Arco que gerou este nó - para o ComplicaTransito
        /// </summary>
        public Arcos SourceArco { get; set; }

        #endregion

        #region Construtores

        /// <summary>
        /// Cria um novo nó e sua lista de arcos
        /// </summary>
        public Nos()
        {
            this.Arcos = new List<Arcos>();
        }

        /// <summary>
        /// Cria um novo nó.
        /// </summary>
        /// <param name="name">O nome do nó.</param>
        /// <param name="info">A informação armazenada no nó.</param>
        public Nos(string nome, object info) : this()
        {
            this.Nome = nome;
            this.Info = info;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Adiciona um arco com nó origem igual ao nó atual, e destino de acordo com os parâmetros.
        /// </summary>
        /// <param name="to">O nó destino.</param>
        public void AddArco(Nos para)
        {
            AddArco(para, 0);
        }

        /// <summary>
        /// Adiciona um arco com nó origem igual ao nó atual; adiciona uma capacidade a ele.
        /// </summary>
        /// <param name="to">O nó destino.</param>
        /// <param capacity="to">Capacidade do arco.</param>
        public void AddArco(Nos to, double capacity, Arcos networkEdge = null)
        {
            var edge = new Arcos(this, to, capacity);
            edge.NetworkEdge = networkEdge;
            this.Arcos.Add(edge);
        }

        /// <summary>
        /// Adiciona um arco com nó origem igual ao nó atual, destino e custo de acordo com os parâmetros.
        /// </summary>
        /// <param name="para">O nó destino.</param>
        /// <param name="custo">O custo associado ao arco.</param>
        public void AddArco(Nos para, double custo)
        {
            this.Arcos.Add(new Arcos(this, para, custo));
        }

        /// <summary>
        /// Adiciona um arco com nó origem igual ao nó atual, e destino, custo, pedágios e condição de acordo com os parâmetros.
        /// </summary>
        /// <param name="para">O nó destino.</param>
        /// <param name="custo">O custo do trânsito.</param>
        /// <param name="pedagios">O valor (R$) dos pedágios.</param>
        /// <param name="condicao">A condição da via.</param>
        public void AddArco(Nos para, double custo, double pedagios, bool condicao, int km)
        {
            this.Arcos.Add(new Arcos(this, para, custo, pedagios, condicao, km));
        }
        /// <summary>
        /// Remove um arco do nó.
        /// </summary>
        /// <param name="edge">O arco a remover.</param>
        public void RemoveArco(Arcos edge)
        {
            this.Arcos.Remove(edge);
        }

        #endregion

    }
}
