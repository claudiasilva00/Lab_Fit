using Lab_Fit.Controls;
using Lab_Fit.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab_Fit
{
    public class Model
    {
        public Perfil PerfilAtual;
        //delegates
        public delegate void RecebeObjetico(Objetivo objet);
        public delegate void RecebeInt(int num);
        public delegate void RecebeSapatilha(Calcado sap);
        public delegate void RecebeAtividade(Atividade atividade);
        public delegate void RecebeEDaPerfil(Perfil perf);
        public delegate void RecebeAlteracaoFisica(AlteracaoFisica AF);
        //events
        public event RecebeObjetico? AdicObj;
        public event RecebeInt? RemoverObj;
        public event RecebeSapatilha? AdicionarSapatilha;
        public event RecebeAtividade? AdicionaAtividade;
        public event RecebeAtividade? RemoveAtividade;
        public event RecebeEDaPerfil? ModificarPerfilDisplay;
        public event RecebeAlteracaoFisica? AdicionarAlteracaoFisica;
        //exception
        public class FileError : Exception
        {
            public FileError(string message) : base(message) { }
        }


        public Model() {
            PerfilAtual ??= new Perfil();
        }

        public void LoadData() {
            try {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                path = path + "/lab_fit/perfil.json";
                if(File.Exists(path)) {
                    string json = File.ReadAllText(path);
                    PerfilAtual = JsonConvert.DeserializeObject<Perfil>(json) ?? new Perfil();
                } else throw new FileError("Alerta! Erro de leitura de perfil.\nCriando um novo perfil...");
                ModificarPerfilDisplay?.Invoke(PerfilAtual);
                foreach(Calcado sap in PerfilAtual.Sapatilhas) {
                    AdicionarSapatilha?.Invoke(sap);
                }
                foreach(Atividade ativ in PerfilAtual.Atividades) {
                    AdicionaAtividade?.Invoke(ativ);
                }
                foreach(AlteracaoFisica AF in PerfilAtual.alteracoesFisicas) {
                    AdicionarAlteracaoFisica?.Invoke(AF);
                }
                foreach(Objetivo obj in PerfilAtual.objetivos) {
                    AdicObj?.Invoke(obj);
                }
                foreach(Objetivo obj in PerfilAtual.objetivosCompletos) {
                    AdicObj?.Invoke(obj);
                }
            }
            catch(Exception ex) {
                PerfilAtual = new();
                ModificarPerfilDisplay?.Invoke(PerfilAtual);
                Task.Delay(1000);
                Task.Run(() => MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Information));
            }
        }

        public void CallAdicionarAlteracaoFisica(AlteracaoFisica Af) {
            AdicionarAlteracaoFisica?.Invoke(Af);
        }
        public void CallModificarPerfilDisplay(Perfil perf) {
            ModificarPerfilDisplay?.Invoke(perf);
            PerfilAtual.Savechanges(perf);
        }
        public void Setevent() {
            //AdicObj += PerfilAtual.AdicionarObjetivo;
            RemoverObj += PerfilAtual.RemoverObjetivo;
        }

        public void RemoverAtividade(Atividade atividade) {
            RemoveAtividade?.Invoke(atividade);
        }
        public void AdicionarObjetivo(Objetivo objetivo) {
            PerfilAtual.AdicionarObjetivo(objetivo);
            AdicObj?.Invoke(objetivo);//??
        }

        public void CallRemovObj(int IdObjetivo) {
            RemoverObj?.Invoke(IdObjetivo);
        }

        public Objetivo BuscarObjetivoDaLista(int IDdoObjetivo) {
            return PerfilAtual.BuscarObjetivo(IDdoObjetivo);
        }

        public void AdicionaSapatilha(Calcado sap) {
            AdicionarSapatilha?.Invoke(sap);
            PerfilAtual.Sapatilhas.Add(sap);
        }

        public void AdicionarAtividade(Atividade atividade) {
            PerfilAtual.Atividades.Add(atividade);
            AdicionaAtividade?.Invoke(atividade);
            ModificarPerfilDisplay?.Invoke(PerfilAtual);
        }
    }
}
