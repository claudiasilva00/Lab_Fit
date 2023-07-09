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
    /// Interaction logic for Login_page.xaml
    /// </summary>
    public partial class Login_page : Page
    {
        public delegate void Callpage(bool login);

        public Login_page() {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender,RoutedEventArgs e) {

        }

        private void UsernameTextBox_KeyDown(object sender,KeyEventArgs e) {
            if(e.Key == Key.Enter) {
                e.Handled = true;
                BtnLogin_Click(sender,e);
            }
        }
    }
}
