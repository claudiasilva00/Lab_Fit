using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Fit.Core
{
    public class Atividade
    {
        public Atividade() {
            Tipoo = new();
            Descricao = " ";
            Inicio = new();
            Termino = new();
            Distancia = 0;
            Sapatilhas = new();
            Ritmo = 0;
            Nome = "NovaAtividade";
            PesoPerdido = 0;
        }

        public Atividade(Tipo tipo,string descricao,DateTime inicio,DateTime termino,float distancia,float ritmo,string nome,float pesoPerdido) {
            Tipoo = tipo;
            Descricao = descricao;
            Inicio = inicio;
            Sapatilhas = null;
            Termino = termino;
            Distancia = distancia;
            Ritmo = ritmo;
            Nome = nome;
            PesoPerdido = pesoPerdido;
        }

        public Atividade(int MudancaDePeso,int MudancaDeTamanho) {
            Inicio = DateTime.Now;
            Termino = DateTime.Now;
            Distancia = MudancaDePeso;//Para ManterOCodigoMaisLimpo
            PesoPerdido = MudancaDePeso;
            Tipoo = new Tipo("Alteracao Fisica");
        }

        public Atividade(Tipo tipo,string descricao,DateTime inicio,DateTime termino,float distancia,Calcado sapatilha,float ritmo,string nome,float pesoPerdido) {
            Tipoo = tipo;
            Descricao = descricao;
            Inicio = inicio;
            Termino = termino;
            Distancia = distancia;
            Sapatilhas = sapatilha;
            Ritmo = ritmo;
            Nome = nome;
            PesoPerdido = pesoPerdido;
        }

        #region vars
        public string Nome { set; get; }
        public Tipo Tipoo { get; set; }
        public string Descricao { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Termino { get; set; }
        public float Distancia { get; set; }
        public Calcado? Sapatilhas { get; set; }
        public float Ritmo { get; set; }
        public float PesoPerdido { get; set; }
        #endregion
    }
}
