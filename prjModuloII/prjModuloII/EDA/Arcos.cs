using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prjModuloII.EDA
{
    public class Arcos
    {
        #region Propriedades/Atributos
        /// <summary>
        /// O nó origem do arco
        /// </summary>
        public Nos De { get; set; }

        /// <summary>
        /// O nó destino do arco
        /// </summary>
        public Nos Para { get; set; }

        /// <summary>
        /// Transito - media de transito para a via, e com redes foi usado como o CAPACITY
        /// </summary>
        public double Custo { get; set; }

        /// <summary>
        /// Qual o tamanho da via
        /// </summary>
        public int Km { get; set; }

        /// <summary>
        /// Usado para a rede
        /// </summary>
        public Arcos NetworkEdge { get; set; }

        /// <summary>
        /// Condição da via - se ela é boa ou ruim quanto ao estado de conservação
        /// </summary>
        public bool CondicaoVia { get; set; }

        /// <summary>
        /// Pedágios - Soma do valor(monetário) dos pedágios
        ///</summary>
        public double Pedagios { get; set; }

        /// <summary>
        /// A capacidae usada do arco 0 - utilizado para o ComplicaTransito
        /// </summary>
        public double CustoUsado { get; set; }


        #endregion

        #region Construtores

        /// <summary>
        /// Cria um novo arco entre os nós
        /// </summary>
        /// <param name="from">nó origem</param>
        /// <param name="to">nó destino</param>
        /// <param name="cost">custo</param>
        public Arcos(Nos de, Nos para) : this(de, para, 0)
        {
        }

        /// <summary>
        /// Cria um novo arco entre os nós
        /// </summary>
        /// <param name="from">nó origem</param>
        /// <param name="to">nó destino</param>
        /// <param name="cost">custo (trânsito) em inteiro para diferenciar do método de Arcos com double </param>
        public Arcos(Nos de, Nos para, int custo)
        {
            this.De = de;
            this.Para = para;
            this.Custo = custo;
        }

        /// <summary>
        /// Cria um novo arco entre os nós
        /// </summary>
        /// <param name="de">nó origem</param>
        /// <param name="para">nó destino</param>
        /// <param name="custo">custo (trânsito) em double para o valor monetário</param>
        public Arcos(Nos de, Nos para, double custo)
        {
            this.De = de;
            this.Para = para;
            this.Custo = custo;
        }

        /// <summary>
        /// Cria um novo arco entre os nós
        /// </summary>
        /// <param name="de">nó origem</param>
        /// <param name="para">nó destino</param>
        /// <param name="custo">custo do trânsito</param>
        /// <param name="pedagios">custo do pedágio, dinheiro</param>
        /// <param name="condicao">estado da via, bom ou ruim</param>
        /// <param name="km">tamanho da via</param>
        public Arcos(Nos de, Nos para, double custo, double pedagios, bool condicao, int km)
        {
            this.De = de;
            this.Para = para;
            this.Custo = custo;
            this.CondicaoVia = condicao;
            this.Pedagios = pedagios;
            this.Km = km;
        }


        #endregion

        #region Métodos (principalmente para ComplicaTransito)

        /// <summary>
        /// Consome parte da capacidade do arco
        /// </summary>
        /// <param name="flow">A quantidade de fluxo a consumir do arco</param>
        public void Consome(double flow)
        {
            this.CustoUsado += flow;
        }

        /// <summary>
        /// Restaura a capacidade do arco
        /// </summary>
        public void ResetaCapacidade()
        {
            this.CustoUsado = 0;
        }

        #endregion







    }
}
