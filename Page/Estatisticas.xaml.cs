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
    /// Interaction logic for Estatisticas.xaml
    /// </summary>
    public partial class Estatisticas : Page
    {
        private readonly App app;
        public Estatisticas() {
            InitializeComponent();
            app = (App)App.Current;
        }

        private void Fdate_DataContextChanged(object sender,SelectionChangedEventArgs e) {
            if(idate.SelectedDate == null || fdate.SelectedDate == null)
                return;
            DateTime startdate = idate.SelectedDate.Value;
            DateTime enddate = fdate.SelectedDate.Value;
            TimeSpan duration = enddate - startdate;
            totaltime.Content = duration.Days.ToString() + "dias, ";
            float maior = -1;
            float KilMaisRapido = float.MaxValue;
            TimeSpan maisLonga = TimeSpan.MinValue;
            float Kil10MaisRapido = float.MaxValue;
            foreach(Atividade ativ in app.model.PerfilAtual.Atividades) {
                if(ativ.Inicio >= idate.SelectedDate && ativ.Termino <= fdate.SelectedDate) {
                    if(ativ.Distancia > maior) {
                        maior = ativ.Distancia;
                    }
                    if(ativ.Termino - ativ.Inicio > maisLonga) {
                        maisLonga = ativ.Termino - ativ.Inicio;
                    }
                    if(ativ.Tipoo.Name != "Peso") {
                        //Como distancia esta em metros, devolvendo em km/s acho, depende de como medirem o ritmo, depois muda-se se for necessario, eu vou assumir que ritmo esta em metros por segundo
                        if(ativ.Distancia > 10 && (ativ.Ritmo) < Kil10MaisRapido) {
                            Kil10MaisRapido = (ativ.Ritmo);
                        }
                        if( (ativ.Ritmo) < KilMaisRapido) {
                            KilMaisRapido = (ativ.Ritmo);
                        }
                        /*
                        if ((ativ.Distancia/1000)/((TransformarTimeSpanEmSegundos(ativ.Termino - ativ.Inicio))/3600) < KilMaisRapido)
                        {
                            KilMaisRapido = (ativ.Distancia / 1000) / ((TransformarTimeSpanEmSegundos(ativ.Termino - ativ.Inicio)) / 3600);
                        }
                        if(ativ.Distancia/1000 > 10 && (ativ.Distancia / 10000) / ((TransformarTimeSpanEmSegundos(ativ.Termino - ativ.Inicio)) / 3600) < Kil10MaisRapido)
                        {
                            Kil10MaisRapido = (ativ.Distancia / 10000) / ((TransformarTimeSpanEmSegundos(ativ.Termino - ativ.Inicio)) / 3600);
                        }
                        */
                    }
                }
            }
            if(Kil10MaisRapido != float.MaxValue) {
                fasterdezkm.Content = Kil10MaisRapido.ToString();
            } else {
                fasterdezkm.Content = "N/A";
            }
            if(KilMaisRapido != float.MaxValue) {
                fasterkm.Content = Convert.ToSingle(KilMaisRapido).ToString();
            } else {
                fasterkm.Content = "N/A";
            }
            if(maior != -1) {
                longerdistance.Content = maior.ToString();
            } else {
                longerdistance.Content = "N/A";
            }
            if(maisLonga != TimeSpan.MinValue) {
                longertime.Content = maisLonga.ToString();
            } else {
                longertime.Content = "N/A";
            }
        }


    }
}
