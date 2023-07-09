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
    /// Interação lógica para AdicionarAtividades.xam
    /// </summary>
    public partial class AdicionarAtividades : Page
    {
        private readonly App app;
        private DateTime init, fin;
        private TimeSpan interval;
        private float ritmo;
        public AdicionarAtividades() {
            InitializeComponent();
            app = (App)App.Current;
            date_inicio.SelectedDate = DateTime.Now;
            date_fim.SelectedDate = DateTime.Now;
            Time_inicio.SelectedTime = DateTime.Now;
            Time_fim.SelectedTime = DateTime.Now;
            foreach(Calcado shoe in app.model.PerfilAtual.Sapatilhas) {
                Calcado_usado.Items.Add(shoe.Marca + " " + shoe.Modelo);
            }
        }

        private void Button_Click(object sender,RoutedEventArgs e) {
            Tipo type = new();
            init = date_inicio.SelectedDate!.Value.Date + Time_inicio.SelectedTime!.Value.TimeOfDay;
            fin = date_fim.SelectedDate!.Value.Date + Time_fim.SelectedTime!.Value.TimeOfDay;
            interval = fin - init;
            ritmo = Convert.ToSingle(Progresso.Text) / Convert.ToSingle(interval.TotalHours);
            if(Check()) { return; }
            if(TipoBox.SelectedIndex == 0) {
                type.Name = "Caminhada";
            } else {
                type.Name = "Corrida";
            }
            if(Calcado_usado.SelectedIndex > 0) {
                app.model.PerfilAtual.Sapatilhas[Calcado_usado.SelectedIndex - 1].Kilometros += Convert.ToInt64(Progresso.Text);
            }
            app.model.PerfilAtual.Peso -= Convert.ToInt64(PesoPerdido.Text);
            if(Calcado_usado.SelectedIndex > 0) {
                app.model.AdicionarAtividade(new Atividade(type,Descricao.Text,init,fin,Convert.ToInt64(Progresso.Text),app.model.PerfilAtual.Sapatilhas[Calcado_usado.SelectedIndex - 1],ritmo,Nome.Text,Convert.ToInt64(PesoPerdido.Text)));
            } else {
                app.model.AdicionarAtividade(new Atividade(type,Descricao.Text,init,fin,Convert.ToInt64(Progresso.Text),ritmo,Nome.Text,Convert.ToInt64(PesoPerdido.Text)));
            }
            NavigationService.GoBack();
        }

        private bool Check() {
            if(Nome.Text == "") { MessageBox.Show("Por favor, insira um nome para a atividade."); return true; }
            if(Descricao.Text == "") { MessageBox.Show("Por favor, insira uma descrição."); return true; }
            if(TipoBox.SelectedIndex == -1) { MessageBox.Show("Por favor, selecione um tipo."); return true; }
            if(date_inicio.SelectedDate == null) { MessageBox.Show("Por favor, selecione uma data de inicio."); return true; }
            if(date_fim.SelectedDate == null) { MessageBox.Show("Por favor, selecione uma data de fim."); return true; }
            if(init > fin) { MessageBox.Show("A data de inicio tem que ser anterior à data de fim."); return true; }
            if(Progresso.Text == "") { MessageBox.Show("Por favor, insira o progresso da atividade."); return true; }
            if(!int.TryParse(Progresso.Text,out int _)) { MessageBox.Show("Por favor, o campo Distancia tem que ser um valor numerico."); return true; }
            if(Calcado_usado.SelectedIndex == -1) { MessageBox.Show("Por favor, selecione um calçado."); return true; }
            if(PesoPerdido.Text == "") { MessageBox.Show("Por favor, insira o peso perdido."); return true; }
            if(Convert.ToInt64(PesoPerdido.Text) < 0) { MessageBox.Show("Por favor, não pode ganhar peso com uma atividade."); }
            if(!int.TryParse(PesoPerdido.Text,out int x) && x > 0) { MessageBox.Show("Por favor, o campo Peso Perdido tem que ser um valor numerico."); return true; }
            if(app.model.PerfilAtual.Peso - Convert.ToInt32(PesoPerdido.Text) <= 0) { MessageBox.Show("Por favor, o seu Peso tem que ser superior a 0."); return true; }
            return false;
        }
    }
}