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

namespace Lab_Fit.Controls
{
    /// <summary>
    /// Interaction logic for Sapatilha.xaml
    /// </summary>
    public partial class Sapatilha : UserControl
    {
        private Calcado _calcado;
        public Sapatilha() {
            InitializeComponent();
            tilha_img.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Lab_Fit;component/Images/sapatilha_default.jpg"));
        }

        public Sapatilha(Calcado calcado) {
            InitializeComponent();
            _calcado = calcado;
            tilha_img.ImageSource = new BitmapImage(calcado.Image);
            tilha_name.Content = calcado.Marca;
        }

        private void Tilha_radio_Checked(object sender,RoutedEventArgs e) {
            // Uncheck other RadioButtons in the same WrapPanel
            var parentWrapPanel = (WrapPanel)Parent;
            if(parentWrapPanel != null) {
                foreach(var child in parentWrapPanel.Children) {
                    if(child is Sapatilha sapatilha && sapatilha.tilha_radio != sender) {
                        sapatilha.tilha_radio.IsChecked = false;
                    }
                }
            }
        }

        private void MenuItem_Click(object sender,RoutedEventArgs e) {
            
        }

        private void MenuItem_Click_1(object sender,RoutedEventArgs e) {

        }
    }
}
