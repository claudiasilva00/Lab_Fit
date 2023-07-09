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
    /// Interação lógica para Edit_profile.xam
    /// </summary>
    public partial class Edit_profile : Page
    {
        private readonly App app;
        public Edit_profile(Perfil perfil) {
            InitializeComponent();
            app = (App)Application.Current;
            Load_edit(perfil);
        }

        private void Load_edit(Perfil perfil) {
            UsernameTextBox.Text = perfil.Nome;
            B_date.SelectedDate = perfil.Nascimento;
            if(perfil.Sexo == "Masculino") {
                Masculino.IsChecked = true;
            } else if(perfil.Sexo == "Feminino") {
                Feminino.IsChecked = true;
            } else {
                Outro.IsChecked = true;
            }
            editpimg.Source = new BitmapImage(perfil.Profilepic);
            if(perfil.Peso != 0) {
                etbpeso.Text = perfil.Peso.ToString();
            }

            if(perfil.Altura != 0) {
                etbaltura.Text = perfil.Altura.ToString();
            }
        }

        private void Cancelarbtn_Click(object sender,RoutedEventArgs e) {
            NavigationService.GoBack();
        }

        private void Savebtn_Click(object sender,RoutedEventArgs e) {
            Perfil perfil = new();
            if(editpimg.Source != null) {
                perfil.Profilepic = new Uri(editpimg.Source.ToString());
            }
            if(UsernameTextBox.Text != "Nome Do Usuário") {
                perfil.Nome = UsernameTextBox.Text;
            }
            if(B_date.SelectedDate != null)
                perfil.Nascimento = B_date.SelectedDate.Value;
            if(Masculino.IsChecked == true) {
                perfil.Sexo = "Masculino";
            } else if(Feminino.IsChecked == true) {
                perfil.Sexo = "Feminino";
            } else if(Outro.IsChecked == true) {
                perfil.Sexo = "Outro";
            }
            if(Double.TryParse(etbpeso.Text,out double d) && d > 0) {
                perfil.Peso = d;
            } else if(etbpeso.SelectedText == "") {
                MessageBox.Show("Peso Inválido");
            }
            if(int.TryParse(etbaltura.Text,out int i) && i > 0) {
                perfil.Altura = i;
            } else if(etbaltura.SelectedText == "") {
                MessageBox.Show("Altura Inválida");
            }
            app.model.CallModificarPerfilDisplay(perfil);
            NavigationService.GoBack();
        }

        private void Imgperfil_MouseDown(object sender,MouseButtonEventArgs e) {
            OpenFileDialog op = new() {
                Title = "Select a picture",
                Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png"
            };
            if(op.ShowDialog() == true) {
                editpimg.Source = new BitmapImage(new Uri(op.FileName));
            }
        }

        private void Got_Focus(object sender,RoutedEventArgs e) {
            ((TextBox)sender).SelectedText = "";
        }

        private void Lost_Focus(object sender,RoutedEventArgs e) {
            TextBox tb = (TextBox)sender;
            if(tb.Text == "") {
                if(tb.Name == "UsernameTextBox") {
                    tb.SelectedText = "Username";
                } else if(tb.Name == "etbpeso") {
                    tb.SelectedText = "Peso (Kg)";
                } else if(tb.Name == "etbaltura") {
                    tb.SelectedText = "Altura (Cm)";
                }
            }
        }
    }
}
