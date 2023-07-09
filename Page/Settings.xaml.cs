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
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        public App app;
        public Settings() {
            app = (App)App.Current;
            InitializeComponent();
        }

        private void ComboBoxtem_Selected_1(object sender,RoutedEventArgs e) {
            app.Resources.MergedDictionaries[0].Source = new Uri("/Themes/DarkTheme.xaml",UriKind.RelativeOrAbsolute);
        }

        private void ComboBoxItem_Selected(object sender,RoutedEventArgs e) {
            app.Resources.MergedDictionaries[0].Source = new Uri("/Themes/LightTheme.xaml",UriKind.RelativeOrAbsolute);
        }
    }
}