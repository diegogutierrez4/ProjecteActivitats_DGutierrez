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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using ProjecteActivitatsWPF_DGutierrez.Accés_a_dades;
using ProjecteActivitatsWPF_DGutierrez.Model;

namespace ProjecteActivitatsWPF_DGutierrez.Vista
{
    /// <summary>
    /// Lógica de interacción para PantallaConsultarReserves.xaml
    /// </summary>
    public partial class PantallaConsultarReserves : Window
    {
        ConnexioBD connexio;
        Usuari usuariActual;
        List<ConsultaReserva> llistaConsultaReserves;
        ReservesBD reservesBD;

        public PantallaConsultarReserves(Usuari usuari)
        {
            InitializeComponent();
            MySqlConnection mySqlConnection = new MySqlConnection();
            connexio = new ConnexioBD(mySqlConnection, "localhost", "3306", "root", "", "projectedb");

            usuariActual = usuari;

            reservesBD = new ReservesBD(connexio);
            llistaConsultaReserves = reservesBD.ObtenirReservesUsuari(usuariActual.Id);

            listBoxActivitatsReservades.ItemsSource = llistaConsultaReserves;
        }

        private void buttonSortirClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonMinimitzarClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void listBoxActivitatsReservades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button_CancelarReserva_Click(object sender, RoutedEventArgs e)
        {
            ConsultaReserva reservaCancelar;

            reservaCancelar = (ConsultaReserva)listBoxActivitatsReservades.SelectedItem;

            if (reservaCancelar == null)
                MessageBox.Show("Cap reserva seleccionada!");
            else
            {
                reservesBD.EliminarReserva(reservaCancelar.IdReserva);
                MessageBox.Show("Reserva cancel·lada correctament!");

                llistaConsultaReserves = reservesBD.ObtenirReservesUsuari(usuariActual.Id);
                listBoxActivitatsReservades.ItemsSource = llistaConsultaReserves;
            }
        }
    }
}
