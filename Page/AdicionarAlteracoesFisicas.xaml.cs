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
    /// Interação lógica para AdicionarAlteracoesFisicas.xam
    /// </summary>
    public partial class AdicionarAlteracoesFisicas : Page
    {
        private readonly App app;
        public AdicionarAlteracoesFisicas() {
            InitializeComponent();
            app = (App)App.Current;
        }

        private void Button_Click(object sender,RoutedEventArgs e) {
            if(int.TryParse(ValorTB.Text,out int _)) {
                if(ComboBoxTipo.SelectedIndex == -1) {
                    MessageBox.Show("Por favor selecione o tipo da alteração física.");
                } else if(ComboBoxTipo.SelectedIndex == 0) {
                    if(app.model.PerfilAtual.Peso + Convert.ToInt64(ValorTB.Text) <= 0) {
                        MessageBox.Show("O valor introduzido deixa o seu peso menor ou igual a 0");
                    } else {
                        app.model.PerfilAtual.alteracoesFisicas.Add(new AlteracaoFisica(Convert.ToInt64(ValorTB.Text),"Peso"));
                        app.model.CallAdicionarAlteracaoFisica(new AlteracaoFisica(Convert.ToInt64(ValorTB.Text),"Peso"));
                        app.model.PerfilAtual.Peso += Convert.ToInt64(ValorTB.Text);
                        app.model.CallModificarPerfilDisplay(app.model.PerfilAtual);
                        NavigationService.GoBack();
                    }
                } else {
                    if(app.model.PerfilAtual.Altura + Convert.ToInt64(ValorTB.Text) <= 0) {
                        MessageBox.Show("O valor introduzido deixa a sua altura menor ou igual a 0");
                    } else {
                        app.model.PerfilAtual.alteracoesFisicas.Add(new AlteracaoFisica(Convert.ToInt64(ValorTB.Text),"Altura"));
                        app.model.CallAdicionarAlteracaoFisica(new AlteracaoFisica(Convert.ToInt64(ValorTB.Text),"Altura"));
                        app.model.PerfilAtual.Altura += Convert.ToInt64(ValorTB.Text);
                        app.model.CallModificarPerfilDisplay(app.model.PerfilAtual);
                        NavigationService.GoBack();
                    }
                }
            } else {
                MessageBox.Show("Peso e Altura têm de ser números.");
            }
        }
    }
}
