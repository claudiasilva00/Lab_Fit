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
using static System.Net.Mime.MediaTypeNames;

namespace Lab_Fit
{
    /// <summary>
    /// Interaction logic for Add_objetivos.xaml
    /// </summary>
    public partial class Add_objetivos : Page
    {
        private readonly App app;
        public Add_objetivos() {
            app = (App)App.Current;
            InitializeComponent();
            //date.SelectedDate = DateTime.Now;
            date.SelectedDate = DateTime.Now;
            time.SelectedTime = DateTime.Now;
        }
        private void Adcionar_Click(object sender,RoutedEventArgs e) {
            Tipo tipo;
            if(SelecTipo.Text == "Peso") {
                tipo = new Tipo("Peso");
            } else if(SelecTipo.Text == "Caminhada") {
                tipo = new Tipo("Caminhada");
            } else if(SelecTipo.Text == "Corrida") {
                tipo = new Tipo("Corrida");
            } else {
                MessageBox.Show("Por favor selecione o tipo");
                return;
            }
            if(Meta.Text == "") { MessageBox.Show("Por favor, preencha o campo Meta"); return; }
            if(!int.TryParse(Meta.Text,out int _)) { MessageBox.Show("Por favor, o campo Meta tem que ser um valor numérico"); return; }
            if(date.SelectedDate == null) { app.model.AdicionarObjetivo(new Objetivo(int.Parse(Meta.Text),tipo,NomeDoObjetivo.Text.ToString())); } else {
                DateTime data = date.SelectedDate.Value.Date + time.SelectedTime!.Value.TimeOfDay;
                app.model.AdicionarObjetivo(new Objetivo(int.Parse(Meta.Text),tipo,data,NomeDoObjetivo.Text.ToString()));
            }
            NavigationService.GoBack();
        }
        private void ClearText(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null && (textBox.Text == "NovoObjetivo" || textBox.Text == "Km"))
            {
                textBox.Text = "";
            }
        }

        private void RestoreDefaultText(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox.Name == "NomeDoObjetivo")
                {
                    textBox.Text = "NovoObjetivo";
                }
                else if (textBox.Name == "Meta")
                {
                    textBox.Text = "Km";
                }
            }
        }
    }
}
