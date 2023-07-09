using Lab_Fit.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
    /// Interaction logic for Objetivos.xaml
    /// </summary>
    public partial class Objetivos : Page
    {
        private readonly App app;
        public Objetivos() {
            app = (App)App.Current;
            app.model.AdicObj += PorUmObjetivoNaLista;
            app.model.AdicionaAtividade += ReactToAtividadeAdicionada;
            app.model.RemoveAtividade += ReactToAtividadeRemovida;
            InitializeComponent();
        }

        private void Image_MouseDown(object sender,MouseButtonEventArgs e) {
            NavigationService.Content = new Add_objetivos();
        }

        public void PorUmObjetivoNaLista(Objetivo objet) {
            if (objet.Acabado == false) { atv_list.Items.Add(objet.Nome.ToString() + "(" + objet.TipoObjetivo.Name + ")"); }
            else { Objetivos_Completos.Items.Add(objet.Nome.ToString() + "(" + objet.TipoObjetivo.Name + ")"); }
            if(atv_list.Items.Count == 1) {
                atv_list.SelectedIndex = 0;
                EstadoAtual_Destacado.Text = "Estado atual:" + app.model.BuscarObjetivoDaLista(atv_list.SelectedIndex).EstadoAtual;
                Tipo_Destacado.Text = "Tipo:" + app.model.BuscarObjetivoDaLista(atv_list.SelectedIndex).TipoObjetivo.Name;
                EstadoDesejadoo_Destacado.Text = "Estado Desejado: " + app.model.BuscarObjetivoDaLista(atv_list.SelectedIndex).Meta.ToString();
                if(app.model.BuscarObjetivoDaLista(atv_list.SelectedIndex).DataLimite.ToString("dd/MM/yyyy") != "01.01.0001") {
                    DataLimite_Destacada.Text = "Data Limite: " + app.model.BuscarObjetivoDaLista(atv_list.SelectedIndex).DataLimite.ToString("dd/MM/yyyy");
                } else {
                    DataLimite_Destacada.Text = "Data Limite: Não Definida";
                };
                Nome_Destacado.Text = app.model.BuscarObjetivoDaLista(atv_list.SelectedIndex).Nome + ":";
                Tipo_Selecionado.Text = "Tipo:" + app.model.BuscarObjetivoDaLista(atv_list.SelectedIndex).TipoObjetivo.Name;
                Estado_Desejado_Selecionado.Text = "Estado Desejado: " + app.model.BuscarObjetivoDaLista(atv_list.SelectedIndex).Meta.ToString();
                if(app.model.BuscarObjetivoDaLista(atv_list.SelectedIndex).DataLimite.ToString("dd/MM/yyyy") != "01.01.0001") {
                    Data_Limite_Selecionado.Text = "Data Limite: " + app.model.BuscarObjetivoDaLista(atv_list.SelectedIndex).DataLimite.ToString("dd/MM/yyyy");
                } else {
                    Data_Limite_Selecionado.Text = "Data Limite: Não Definida";
                }
                Nome_Selecionado.Text = app.model.BuscarObjetivoDaLista(atv_list.SelectedIndex).Nome + ":";
                EstadoAtual_Selecionado.Text = "Estado atual:" + app.model.BuscarObjetivoDaLista(atv_list.SelectedIndex).EstadoAtual;
                DataAlcance_Destacada.Text = "";
                Data_Alcance_Selecionada.Text = "";
            }
        }
        private void Atv_list_SelectionChanged(object sender,SelectionChangedEventArgs e) {
            if(atv_list.SelectedIndex != -1) {
                EstadoAtual_Selecionado.Text = "Estado atual:" + app.model.BuscarObjetivoDaLista(atv_list.SelectedIndex).EstadoAtual;
                Tipo_Selecionado.Text = "Tipo:" + app.model.BuscarObjetivoDaLista(atv_list.SelectedIndex).TipoObjetivo.Name;
                Estado_Desejado_Selecionado.Text = "Estado Desejado: " + app.model.BuscarObjetivoDaLista(atv_list.SelectedIndex).Meta.ToString();
                if(app.model.BuscarObjetivoDaLista(atv_list.SelectedIndex).DataLimite.ToString("dd/MM/yyyy") != "01.01.0001") {
                    Data_Limite_Selecionado.Text = "Data Limite: " + app.model.BuscarObjetivoDaLista(atv_list.SelectedIndex).DataLimite.ToString("dd/MM/yyyy");
                } else {
                    Data_Limite_Selecionado.Text = "Data Limite: Não Definida";
                }
                Nome_Selecionado.Text = app.model.BuscarObjetivoDaLista(atv_list.SelectedIndex).Nome + ":";
                if(app.model.BuscarObjetivoDaLista(atv_list.SelectedIndex).Acabado == false) {
                    Data_Alcance_Selecionada.Text = "";//WIP
                } else {
                    Data_Alcance_Selecionada.Text = "Data Alcançe: " + app.model.BuscarObjetivoDaLista(atv_list.SelectedIndex).DataAlcance.ToString();
                }
            }
        }
        public void ReactToAtividadeRemovida(Atividade atividade) {
            int nukeid;
            bool leave;
            do {
                nukeid = 0;
                leave = false;
                foreach(Objetivo objet in app.model.PerfilAtual.objetivosCompletos) {
                    foreach(Atividade ativ in objet.AtividadesUsadas) {
                        if(ativ.Nome == atividade.Nome && ativ.Termino == atividade.Termino && ativ.Descricao == atividade.Descricao && ativ.Ritmo == atividade.Ritmo && ativ.Inicio == atividade.Inicio) {
                            if (objet.TipoObjetivo.Name == "Peso")
                            {
                                objet.EstadoAtual -= atividade.PesoPerdido;
                            }
                            else
                            {
                                objet.EstadoAtual -= atividade.Distancia;
                            }
                            if (objet.EstadoAtual < objet.Meta)
                            {
                                leave = true;
                            }
                            break;
                        }
                    }
                    if(leave) {
                        break;
                    }
                    nukeid++;
                }
                if(leave) {
                    Objetivo objetivo = new Objetivo();
                    objetivo = app.model.PerfilAtual.objetivosCompletos[nukeid];
                    objetivo.Acabado = false;
                    app.model.PerfilAtual.objetivos.Add(objetivo);
                    PorUmObjetivoNaLista(app.model.PerfilAtual.objetivosCompletos[nukeid]);
                    Objetivos_Completos.Items.RemoveAt(nukeid);
                    app.model.PerfilAtual.objetivosCompletos.RemoveAt(nukeid);
                }
            } while(leave);
            //MessageBox.Show(app.model.PerfilAtual.objetivos.Count.ToString());
        }
        public void ReactToAtividadeAdicionada(Atividade atividade) {
            List<int> IdsARemover = new();
            int i = 0;
            foreach(Objetivo objective in app.model.PerfilAtual.objetivos) {
                if(objective.TipoObjetivo.Name == "Peso") {
                    objective.EstadoAtual += atividade.PesoPerdido;
                    objective.AtividadesUsadas.Add(atividade);
                    if(objective.EstadoAtual >= objective.Meta) {
                        objective.DataAlcance = DateTime.Now;
                        objective.Acabado = true;
                        IdsARemover.Add(i);
                    }
                } else if(objective.TipoObjetivo.Name == atividade.Tipoo.Name) {
                    objective.AtividadesUsadas.Add(atividade);
                    objective.EstadoAtual += atividade.Distancia;
                    if(objective.EstadoAtual >= objective.Meta) {
                        objective.DataAlcance = DateTime.Now;
                        objective.Acabado = true;
                        IdsARemover.Add(i);
                        //Objetivos_Completos.Items.Add(objective.nome);
                    }
                }
                i++;
            }
            int i2 = 0;
            foreach(int id in IdsARemover) {
                Objetivos_Completos.Items.Add(atv_list.Items[id - i2]);
                app.model.PerfilAtual.objetivosCompletos.Add(app.model.PerfilAtual.objetivos[id - i2]);
                app.model.CallRemovObj(id - i2);
                atv_list.Items.RemoveAt(id - i2);
                i2++;
            }
        }
        private void Button_Click(object sender,RoutedEventArgs e) {
            if(atv_list.SelectedIndex == -1) {
                MessageBox.Show("Tens que selecionar um objetivo!");
                return;
            } else {
                EstadoAtual_Destacado.Text = "Estado atual:" + app.model.BuscarObjetivoDaLista(atv_list.SelectedIndex).EstadoAtual;
                Tipo_Destacado.Text = "Tipo:" + app.model.BuscarObjetivoDaLista(atv_list.SelectedIndex).TipoObjetivo.Name;
                EstadoDesejadoo_Destacado.Text = "Estado Desejado: " + app.model.BuscarObjetivoDaLista(atv_list.SelectedIndex).Meta.ToString();
                if(app.model.BuscarObjetivoDaLista(atv_list.SelectedIndex).DataLimite.ToString("dd/MM/yyyy") != "1/1/1") {
                    DataLimite_Destacada.Text = "Data Limite: " + app.model.BuscarObjetivoDaLista(atv_list.SelectedIndex).DataLimite.ToString("dd/MM/yyyy");
                } else {
                    DataLimite_Destacada.Text = "Data Limite: Não Definida";
                }
                Nome_Destacado.Text = app.model.BuscarObjetivoDaLista(atv_list.SelectedIndex).Nome + ":";
                if(app.model.BuscarObjetivoDaLista(atv_list.SelectedIndex).Acabado == false) {
                    DataAlcance_Destacada.Text = "";
                } else {
                    DataAlcance_Destacada.Text = "Data Alcançe: " + app.model.BuscarObjetivoDaLista(atv_list.SelectedIndex).DataAlcance.ToString();
                }
            }
        }

        private void Button_Click_1(object sender,RoutedEventArgs e) {
            if(atv_list.SelectedIndex != -1) {
                app.model.CallRemovObj(atv_list.SelectedIndex);
                atv_list.Items.RemoveAt(atv_list.SelectedIndex);
                if(atv_list.SelectedIndex != -1) {
                    //App app = App.Current as App;
                    EstadoAtual_Destacado.Text = "Estado atual:" + app.model.BuscarObjetivoDaLista(atv_list.SelectedIndex).EstadoAtual;
                    Tipo_Destacado.Text = "Tipo:" + app.model.BuscarObjetivoDaLista(atv_list.SelectedIndex).TipoObjetivo.Name;
                    EstadoDesejadoo_Destacado.Text = "Estado Desejado: " + app.model.BuscarObjetivoDaLista(atv_list.SelectedIndex).Meta.ToString();
                    DataLimite_Destacada.Text = "Data Limite: " + app.model.BuscarObjetivoDaLista(atv_list.SelectedIndex).DataLimite.ToString("dd/MM/yyyy");
                    Nome_Destacado.Text = app.model.BuscarObjetivoDaLista(atv_list.SelectedIndex).Nome + ":";
                    //DataAlcance_Destacada.Text = "Data Alcançe: N/A";//Este codigo é repetido algumas vezes, põe numa funcão talvez
                } else {
                    EstadoAtual_Selecionado.Text = "Estado atual:";
                    Nome_Destacado.Text = "Objetivo Destacado:";
                    Tipo_Destacado.Text = "Tipo: ";
                    EstadoDesejadoo_Destacado.Text = "Estado Desejado: ";
                    DataLimite_Destacada.Text = "Data Limite: ";
                    //DataAlcance_Destacada.Text = "Data Alcançe: ";
                    Nome_Selecionado.Text = "Objetivo Selecionado:";
                    Tipo_Selecionado.Text = "Tipo: ";
                    Estado_Desejado_Selecionado.Text = "Estado Desejado: ";
                    Data_Limite_Selecionado.Text = "Data Limite: ";
                    //Data_Alcance_Selecionada.Text = "Data Alcançe: ";
                    EstadoAtual_Selecionado.Text = "Estado Atual: ";
                    EstadoAtual_Destacado.Text = "Estado Atual: ";
                }
            }
        }

        private void Objetivos_Completos_SelectionChanged(object sender,SelectionChangedEventArgs e) {
            if (Objetivos_Completos.SelectedIndex != -1)
            {
                Estado_Desejado_Selecionado.Text = "Estado Desejado: " + app.model.PerfilAtual.objetivosCompletos[Objetivos_Completos.SelectedIndex].Meta.ToString();
                EstadoAtual_Selecionado.Text = "Data Alcance: " + app.model.PerfilAtual.objetivosCompletos[Objetivos_Completos.SelectedIndex].DataAlcance.ToString();
                Data_Limite_Selecionado.Text = "Data Limite: " + app.model.PerfilAtual.objetivosCompletos[Objetivos_Completos.SelectedIndex].DataLimite.ToString();
            }
            else
            {
                Estado_Desejado_Selecionado.Text = "Estado Desejado: ";
                EstadoAtual_Selecionado.Text = "Data Alcance: ";
                Data_Limite_Selecionado.Text = "Data Limite: ";
            }
        }
    }
}
