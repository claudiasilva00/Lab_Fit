using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Fit.Core
{
    public class Objetivo
    {
        public Objetivo() {
            Nome = "Objetivo";
            Meta = 0;
            TipoObjetivo = new();
            DataLimite = DateTime.Now;
            DataAlcance = DateTime.Now;//WIP
            EstadoAtual = 0;
            AtividadesUsadas = new();
            Acabado = false;
        }

        public Objetivo(float meta,Tipo tipo,string nome) {
            Meta = meta;
            TipoObjetivo = tipo;
            DataLimite = new DateTime(1,1,1);
            DataAlcance = DateTime.Now;
            Nome = nome;
            AtividadesUsadas = new();
            EstadoAtual = 0;
        }

        public Objetivo(float meta,Tipo tipo,DateTime dataLimite,string nome) {
            Meta = meta;
            TipoObjetivo = tipo;
            DataLimite = dataLimite;
            DataAlcance = DateTime.Now;
            Nome = nome;
            AtividadesUsadas = new();
            EstadoAtual = 0;
        }
        #region vars
        public string Nome { get; set; }
        public bool Acabado { get; set; }
        public List<Atividade> AtividadesUsadas { get; set; }
        public float EstadoAtual { get; set; }
        public Tipo TipoObjetivo { get; set; }
        public float Meta { get; set; }
        public DateTime DataLimite { get; set; }
        public DateTime DataAlcance { get; set; }
        #endregion
    }
}
