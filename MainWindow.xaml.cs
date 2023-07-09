using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly App app;
        public MainWindow() {
            app = (App)Application.Current;
            InitializeComponent();
            fContainer.Navigate(app.profilepage);
        }

        private void Window_MouseMove(object sender,MouseEventArgs e) {
            if(e.LeftButton == MouseButtonState.Pressed && e.GetPosition(this).Y < 30 && e.GetPosition(this).X > 60) {
                if(WindowState == WindowState.Maximized) // In maximum window state case, window will return normal state and continue moving follow cursor
                {
                    WindowState = WindowState.Normal;
                    Application.Current.MainWindow.Top = 3;// 3 or any where you want to set window location affter return from maximum state
                }
                DragMove();
            }
        }
        private void BG_PreviewMouseLeftButtonDown(object sender,MouseButtonEventArgs e) {
            Tg_Btn.IsChecked = false;
        }

        // Start: MenuLeft PopupButton //
        private void BtnHome_MouseEnter(object sender,MouseEventArgs e) {
            if(Tg_Btn.IsChecked == false) {
                Popup.PlacementTarget = btnHome;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Perfil";
            }
        }

        private void BtnMouseLeave(object sender,MouseEventArgs e) {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void BtnDashboard_MouseEnter(object sender,MouseEventArgs e) {
            if(Tg_Btn.IsChecked == false) {
                Popup.PlacementTarget = btnDashboard;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Objetivos";
            }
        }

        private void BtnProducts_MouseEnter(object sender,MouseEventArgs e) {
            if(Tg_Btn.IsChecked == false) {
                Popup.PlacementTarget = btnProducts;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Calçado";
            }
        }

        private void BtnProductStock_MouseEnter(object sender,MouseEventArgs e) {
            if(Tg_Btn.IsChecked == false) {
                Popup.PlacementTarget = btnProductStock;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Atividades";
            }
        }

        private void BtnOrderList_MouseEnter(object sender,MouseEventArgs e) {
            if(Tg_Btn.IsChecked == false) {
                Popup.PlacementTarget = btnOrderList;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Estatistícas";
            }
        }

        private void BtnAlteracoesFisicas_MouseEnter(object sender,MouseEventArgs e) {
            if(Tg_Btn.IsChecked == false) {
                Popup.PlacementTarget = btnAlteracoesFisicas;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Alteracoes Fisicas";
            }
        }


        private void BtnSetting_MouseEnter(object sender,MouseEventArgs e) {
            if(Tg_Btn.IsChecked == false) {
                Popup.PlacementTarget = btnSetting;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Setting";
            }
        }
        // End: MenuLeft PopupButton //

        // Start: Button Close | Restore | Minimize 
        private void BtnClose_Click(object sender,RoutedEventArgs e) {
            Close();
        }

        private void BtnRestore_Click(object sender,RoutedEventArgs e) {
            if(WindowState == WindowState.Normal) {
                WindowState = WindowState.Maximized;
            } else {
                WindowState = WindowState.Normal;
            }
        }

        private void BtnMinimize_Click(object sender,RoutedEventArgs e) {
            WindowState = WindowState.Minimized;
        }
        // End: Button Close | Restore | Minimize

        private void BtnHome_Click(object sender,RoutedEventArgs e) {
            fContainer.Navigate(app.profilepage);
        }

        private void BtnDashboard_Click(object sender,RoutedEventArgs e) {
            fContainer.Navigate(app.objetivos);
        }

        private void BtnProducts_Click(object sender,RoutedEventArgs e) {
            fContainer.Navigate(app.minhassapatilhas);
        }

        private void BtnProductStock_Click(object sender,RoutedEventArgs e) {
            fContainer.Navigate(app.atividadesrealizadas);
        }

        private void BtnOrderList_Click(object sender,RoutedEventArgs e) {
            fContainer.Navigate(app.estatisticas);
        }

        private void BtnSetting_Click(object sender,RoutedEventArgs e) {
            fContainer.Navigate(app.settings);
        }

        private void BtnAlteracoesFisicas_Click(object sender,RoutedEventArgs e) {
            fContainer.Navigate(app.alteracoesfisicas);
        }


    }
}
