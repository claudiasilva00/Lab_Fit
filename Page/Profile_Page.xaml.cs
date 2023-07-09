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
    /// Interaction logic for Profile_Page.xaml
    /// </summary>
    public partial class Profile_Page : Page
    {
        private readonly App app;

        public Profile_Page() {
            InitializeComponent();
            app = (App)Application.Current;
            app.model.AdicObj += PesoMudouPorObjetivo;
            app.model.ModificarPerfilDisplay += Loadperfil;
        }

        public void PesoMudouPorObjetivo(Objetivo objetivo) {
            tbpeso.Content = app.model.PerfilAtual.Peso;
        }

        public void Loadperfil(Perfil perfil) {
            tbnome.Content = "Nome: " + perfil.Nome;
            tbidade.Content = "Idade: " + perfil.Idade();//calcular idade atraves da data de nascimento
            tbbday.Content = "Data de Nascimento: " + perfil.Nascimento.ToShortDateString();
            tbsexo.Content = "Genero: " + perfil.Sexo;
            imgprofile.Source = new BitmapImage(perfil.Profilepic);
            if(perfil.Peso != 0) { tbpeso.Content = "Peso (Kg): " + perfil.Peso.ToString(); }
            if(perfil.Altura != 0) { tbaltura.Content = "Altura (Cm): " + perfil.Altura.ToString(); }
            if(perfil.Peso != 0 && perfil.Altura != 0) { tbimc.Content = "IMC: " + String.Format("{0:0.00}",perfil.IMC()); }
        }

        private void Image_MouseDown(object sender,MouseButtonEventArgs e) {
            NavigationService.Content = new Edit_profile(app.model.PerfilAtual);
        }
    }
}
// Enviroment.SpecialFolder.LocalApplicationData
//path para guardar o ficheiro