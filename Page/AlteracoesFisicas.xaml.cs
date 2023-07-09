using Lab_Fit.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab_Fit
{
    /// <summary>
    /// Interação lógica para AlteracoesFisicas.xam
    /// </summary>
    public partial class AlteracoesFisicas : Page
    {
        private readonly App app;
        public AlteracoesFisicas() {
            app = (App)App.Current;
            app.model.AdicionarAlteracaoFisica += AdicionarAlteracaoFisica;
            InitializeComponent();
        }

        private void ListaAlteracoesFisicas_SelectionChanged(object sender,SelectionChangedEventArgs e) {
            if(ListaAlteracoesFisicas.SelectedIndex != -1) {
                AlturaouPesoTb.Content = app.model.PerfilAtual.alteracoesFisicas[ListaAlteracoesFisicas.SelectedIndex].tipo + ": " + app.model.PerfilAtual.alteracoesFisicas[ListaAlteracoesFisicas.SelectedIndex].Registo.Unidade.ToString();
            }
        }

        private void AdicionarAlteracaoFisica(AlteracaoFisica AF) {
            ListaAlteracoesFisicas.Items.Add(AF.tipo + " " + "(" + AF.Registo.Unidade.ToString() + ") - " + AF.Date.ToShortDateString());
            if(ListaAlteracoesFisicas.Items.Count == 1) {
                AlturaouPesoTb.Content = AF.tipo + ": " + AF.Registo.Unidade.ToString();
            }
        }
        private void Image_MouseDown(object sender,MouseButtonEventArgs e) {
            //trigger event to change page to Edit_profile
            NavigationService.Content = new AdicionarAlteracoesFisicas();
        }


        private void Button_Click_1(object sender,RoutedEventArgs e) {
            if(ListaAlteracoesFisicas.SelectedIndex != -1) {
                if(app.model.PerfilAtual.alteracoesFisicas[ListaAlteracoesFisicas.SelectedIndex].tipo == "Peso") {
                    if(app.model.PerfilAtual.Peso - app.model.PerfilAtual.alteracoesFisicas[ListaAlteracoesFisicas.SelectedIndex].Registo.Unidade > 0) {
                        app.model.PerfilAtual.Peso -= app.model.PerfilAtual.alteracoesFisicas[ListaAlteracoesFisicas.SelectedIndex].Registo.Unidade;
                        app.model.PerfilAtual.alteracoesFisicas.RemoveAt(ListaAlteracoesFisicas.SelectedIndex);
                        ListaAlteracoesFisicas.Items.RemoveAt(ListaAlteracoesFisicas.SelectedIndex);
                        app.model.CallModificarPerfilDisplay(app.model.PerfilAtual);
                    } else {
                        MessageBox.Show("Remover esta alteração física deixaria o seu peso menor ou igual a 0");
                    }
                } else {
                    if(app.model.PerfilAtual.Altura - app.model.PerfilAtual.alteracoesFisicas[ListaAlteracoesFisicas.SelectedIndex].Registo.Unidade > 0) {
                        app.model.PerfilAtual.Altura -= app.model.PerfilAtual.alteracoesFisicas[ListaAlteracoesFisicas.SelectedIndex].Registo.Unidade;
                        app.model.PerfilAtual.alteracoesFisicas.RemoveAt(ListaAlteracoesFisicas.SelectedIndex);
                        ListaAlteracoesFisicas.Items.RemoveAt(ListaAlteracoesFisicas.SelectedIndex);
                        app.model.CallModificarPerfilDisplay(app.model.PerfilAtual);
                    } else {
                        MessageBox.Show("Remover esta alteração física deixaria a sua altura menor ou igual a 0");
                    }
                }
            }
        }
    }
}
