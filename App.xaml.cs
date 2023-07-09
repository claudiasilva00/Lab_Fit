using Lab_Fit.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Lab_Fit
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>

    public partial class App : Application
    {
        //Model 
        public Model model;
        //pages
        public Profile_Page profilepage;
        public Minhas_sapatilhas minhassapatilhas;
        public Objetivos objetivos;
        public AtividadesRealizadas atividadesrealizadas;
        public Estatisticas estatisticas;
        public AlteracoesFisicas alteracoesfisicas;
        public Settings settings;

        private App() {
            model = new();
            profilepage = new();
            objetivos = new();
            minhassapatilhas = new();
            atividadesrealizadas = new();
            estatisticas = new();
            settings = new();
            alteracoesfisicas = new();
            model.LoadData();
            model.Setevent();
        }
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            this.model.PerfilAtual.Savechanges(this.model.PerfilAtual);
        }
    }
}
