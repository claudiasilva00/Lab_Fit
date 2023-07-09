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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab_Fit
{
    /// <summary>
    /// Interaction logic for Minhas_sapatilhas.xaml
    /// </summary>
    public partial class Minhas_sapatilhas : Page
    {
        private readonly App app;
        public Minhas_sapatilhas() {
            app = (App)App.Current;
            InitializeComponent();
            app.model.AdicionarSapatilha += PorNovaSapatilhaEmLV;
        }

        private void Image_MouseDown(object sender,MouseButtonEventArgs e) {
            NavigationService.Content = new Nova_sapatilha();
        }

        public void PorNovaSapatilhaEmLV(Calcado sap) {
            LVSapatilhas.Items.Add(sap);
            wrap_tilhas.Children.Add(new Sapatilha(sap));
        }
    }
}
