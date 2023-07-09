using Lab_Fit.Controls;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab_Fit.Core
{
    public class Perfil
    {
        public Perfil() {
            Nome = "undifined";
            Sexo = "undifined";
            Peso = 0;
            Altura = 0;
            alteracoesFisicas = new();
            Nascimento = new DateTime(2001,3,11);
            Profilepic = new Uri("/Images/perfil_default.jpg",UriKind.Relative);
            Atividades = new List<Atividade>();
            objetivos = new List<Objetivo>();
            objetivosCompletos = new List<Objetivo>();
            Sapatilhas = new List<Calcado>();
        }

        public Perfil(string nome,string sexo,DateTime nascimento,float peso,int altura) {
            Nome = nome;
            Sexo = sexo;
            Peso = peso;
            Altura = altura;
            Nascimento = nascimento;
            Profilepic = new Uri("/Images/perfil_default.jpg");
            alteracoesFisicas = new();
            objetivos = new List<Objetivo>();
            objetivosCompletos = new List<Objetivo>();
            Sapatilhas = new List<Calcado>();
            Atividades = new List<Atividade>();
        }

        public void Savechanges(Perfil perfil) {
            if(perfil.Profilepic != new Uri("/Images/perfil_default.jpg",UriKind.Relative)) {
                Profilepic = perfil.Profilepic;
            }
            if(perfil.Nome != "undifined") {
                Nome = perfil.Nome;
            }
            if(perfil.Nascimento != new DateTime(2001,3,13)) {
                Nascimento = perfil.Nascimento;
            }
            if(perfil.Sexo != "undifined") {
                Sexo = perfil.Sexo;
            }
            if(perfil.Peso != 0) {
                Peso = perfil.Peso;
            }
            if(perfil.Altura != 0) {
                Altura = perfil.Altura;
            }
            string json = JsonConvert.SerializeObject(this);
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string dir = path + "/lab_fit";
            path = path + "/lab_fit/perfil.json";
            if(File.Exists(path)) {
                File.WriteAllText(path,json);
            } else {
                Directory.CreateDirectory(dir);
                File.WriteAllText(path,json);
            }
        }

        public void AdicionarObjetivo(Objetivo objetivo) {
            objetivos.Add(objetivo);
        }

        public Objetivo BuscarObjetivo(int IddoObjetivo) {
            return objetivos[IddoObjetivo];
        }

        public void RemoverObjetivo(int IddoObjetivo) {
            objetivos.Remove(BuscarObjetivo(IddoObjetivo));
            //MessageBox.Show("DELETED");
        }

        public static Objetivo BuscarOElementoDaListaMaisCompleto() {
            return new Objetivo();//WIP
        }

        public short Idade() {
            return (short)((DateTime.Now - Nascimento).Ticks / (TimeSpan.TicksPerDay * 365.2425));
        }

        public double IMC() {
            double altura = (double)Altura / 100;
            return Peso / (altura * altura);
        }

        #region vars
        public List<AlteracaoFisica> alteracoesFisicas { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public List<Calcado> Sapatilhas { get; set; }
        public double Peso { get; set; } //em kg ->adicionado fora do relatório
        public double Altura { get; set; } //em cm ->adicionado fora do relatório
        public DateTime Nascimento { get; set; }
        public Uri Profilepic { get; set; }
        public List<Atividade> Atividades { get; set; }
        public List<Objetivo> objetivos;
        public List<Objetivo> objetivosCompletos;
        public int numeroDefaultObjetivo;
        #endregion
    }
}
