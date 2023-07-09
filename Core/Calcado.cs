using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Lab_Fit.Core
{
    public class Calcado
    {
        public Calcado() {
            Marca = " ";
            Modelo = " ";
            Cor = "";
            LimiteQuilometros = 0;
            DataCompra = new();
            Inativo = false;
            Kilometros = 0;
            Image = new Uri("pack://application:,,,/Images/sapatilha_default.jpg");
        }
        public Calcado(string marca,string modelo,string cor,float limiteQuilimetros,DateTime dataCompra,bool inativo,Uri image) {
            Marca = marca;
            Modelo = modelo;
            Cor = cor;
            LimiteQuilometros = limiteQuilimetros;
            DataCompra = dataCompra;
            Inativo = inativo;
            Kilometros = 0;
            Image = image;
        }
        #region vars
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }//Não vejo porque é que isto teria de ser a classe cor se não vamos fazer nada a não ser mostrar o seu valor
        public float LimiteQuilometros { get; set; }
        public DateTime DataCompra { get; set; }
        public bool Inativo { get; set; }
        public float Kilometros { get; set; }
        public Uri Image { get; set; }
        #endregion
    }
}
