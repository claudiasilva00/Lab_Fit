using Lab_Fit.Controls;
using Lab_Fit.Core;
using Microsoft.Win32;
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
    /// Interaction logic for Nova_sapatilha.xaml
    /// </summary>
    public partial class Nova_sapatilha : Page
    {
        private readonly App app;
        public Nova_sapatilha() {
            InitializeComponent();
            app = (App)App.Current;
            date.SelectedDate = DateTime.Now;
            foreach(Calcado shoe in app.model.PerfilAtual.Sapatilhas) {
                ListaCalcado.Items.Add(shoe.Marca + " " + shoe.Modelo);
            }
        }

        private void Imgsapatilhas_MouseDown(object sender,MouseButtonEventArgs e) {
            OpenFileDialog op = new() {
                Title = "Select a picture",
                Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                        "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                        "Portable Network Graphic (*.png)|*.png"
            };
            if(op.ShowDialog() == true) {
                imgsapatilhas.Source = new BitmapImage(new Uri(op.FileName));
            }
        }

        private void Button_Click(object sender,RoutedEventArgs e) {
            if(Check_in()) { return; }
            Calcado sap = new(MarcaTB.Text,ModeloTB.Text,CorTB.Text,float.Parse(LimiteKMTB.Text),date.SelectedDate!.Value,false,new Uri(imgsapatilhas.Source.ToString()));
            app.model.AdicionaSapatilha(sap);
            NavigationService.GoBack();
        }

        private bool Check_in() {
            if(MarcaTB.Text == "") { MessageBox.Show("Por favor, preencha o campo do Marca."); return true; }
            if(ModeloTB.Text == "") { MessageBox.Show("Por favor, preencha o campo do Modelo."); return true; }
            if(CorTB.Text == "") { MessageBox.Show("Por favor, preencha o campo do Cor."); return true; }
            if(CorTB.Text.Any(char.IsDigit)) { MessageBox.Show("Por favor,o campo Cor não pode conter números"); return true; }
            if(date.SelectedDate == null) { MessageBox.Show("Por favor, selecione uma data."); return true; }
            if(date.SelectedDate > DateTime.Now) { MessageBox.Show("Por favor, a data de compra não pode ser posterior a hoje."); return true; }
            if(LimiteKMTB.Text == "") { MessageBox.Show("Por favor, preencha o campo Limite de Quilómetros."); return true; }
            if(!float.TryParse(LimiteKMTB.Text,out float x)) { MessageBox.Show("Por favor,o campo Limite de Quilómetros tem que ser um valor numérico."); return true; }
            return false;
        }

        private void ListBox_SelectionChanged(object sender,SelectionChangedEventArgs e) {

        }
    }
}
