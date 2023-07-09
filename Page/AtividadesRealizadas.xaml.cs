using Lab_Fit.Controls;
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
using System.Windows.Shapes;

namespace Lab_Fit
{
    /// <summary>
    /// Interaction logic for AtividadesRealizadas.xaml
    /// </summary>
    public partial class AtividadesRealizadas : Page
    {
        private readonly App app;
        public AtividadesRealizadas() {
            app = (App)App.Current;
            app.model.AdicionaAtividade += AdicionarAtividadeABox;
            InitializeComponent();
        }
        private void Image_MouseDown(object sender,MouseButtonEventArgs e) {
            //trigger event to change page to Edit_profile
            NavigationService.Content = new AdicionarAtividades();
        }

        public void AdicionarAtividadeABox(Atividade atividade) {
            AtividadesLB.Items.Add(atividade.Nome);
            if(AtividadesLB.Items.Count == 1) {
                Nome_Ativ.Content = app.model.PerfilAtual.Atividades[0].Nome + ":";
                Descricao_atividade.Content = "Descrição: " + app.model.PerfilAtual.Atividades[0].Descricao;
                Tipo_Atividade.Content = "Tipo: " + app.model.PerfilAtual.Atividades[0].Tipoo.Name;
                Data_inicio.Content = "Data de Início: " + app.model.PerfilAtual.Atividades[0].Inicio.ToString();
                Data_fim.Content = "Data de Fim: " + app.model.PerfilAtual.Atividades[0].Termino.ToString();
                Distancia.Content = "Distancia: " + app.model.PerfilAtual.Atividades[0].Distancia.ToString();
                Peso_Perdido.Content = "Peso Perdido: " + app.model.PerfilAtual.Atividades[0].PesoPerdido.ToString();
            }
        }

        private void Button_Click_1(object sender,RoutedEventArgs e) {
            if(AtividadesLB.SelectedIndex != -1) {
                app.model.RemoverAtividade(app.model.PerfilAtual.Atividades[AtividadesLB.SelectedIndex]);
                app.model.PerfilAtual.Atividades.RemoveAt(AtividadesLB.SelectedIndex);
                AtividadesLB.Items.RemoveAt(AtividadesLB.SelectedIndex);
            }
        }

        private void AtividadesLB_SelectionChanged(object sender,SelectionChangedEventArgs e) {
            if(AtividadesLB.SelectedIndex != -1) {
                Nome_Ativ.Content = app.model.PerfilAtual.Atividades[AtividadesLB.SelectedIndex].Nome + ":";
                Descricao_atividade.Content = "Descrição: " + app.model.PerfilAtual.Atividades[AtividadesLB.SelectedIndex].Descricao;
                Tipo_Atividade.Content = "Tipo: " + app.model.PerfilAtual.Atividades[AtividadesLB.SelectedIndex].Tipoo.Name;
                Data_inicio.Content = "Data de Início: " + app.model.PerfilAtual.Atividades[AtividadesLB.SelectedIndex].Inicio.ToString();
                Data_fim.Content = "Data de Fim: " + app.model.PerfilAtual.Atividades[AtividadesLB.SelectedIndex].Termino.ToString();
                Distancia.Content = "Distancia: " + app.model.PerfilAtual.Atividades[AtividadesLB.SelectedIndex].Distancia.ToString();
                Peso_Perdido.Content = "Peso Perdido: " + app.model.PerfilAtual.Atividades[AtividadesLB.SelectedIndex].PesoPerdido.ToString();
                if(app.model.PerfilAtual.Atividades[AtividadesLB.SelectedIndex].Sapatilhas != null) {
                    Calcado_usado.Content = "Calçado Usado: " + app.model.PerfilAtual.Atividades[AtividadesLB.SelectedIndex].Sapatilhas.Marca + " " + app.model.PerfilAtual.Atividades[AtividadesLB.SelectedIndex].Sapatilhas.Modelo;
                } else {
                    Calcado_usado.Content = "Calçado Usado: N/A";
                }
                Ritmo.Content = "Ritmo: " + app.model.PerfilAtual.Atividades[AtividadesLB.SelectedIndex].Ritmo.ToString() + " Km/h";
            } else {
                Nome_Ativ.Content = "Atividade: ";
                Descricao_atividade.Content = "Descrição: ";
                Tipo_Atividade.Content = "Tipo: ";
                Data_inicio.Content = "Data de Início: ";
                Data_fim.Content = "Data de Fim: ";
                Distancia.Content = "Distancia: ";
                Calcado_usado.Content = "Calçado Usado: ";
                Ritmo.Content = "Ritmo: ";
            }
        }
    }
}
