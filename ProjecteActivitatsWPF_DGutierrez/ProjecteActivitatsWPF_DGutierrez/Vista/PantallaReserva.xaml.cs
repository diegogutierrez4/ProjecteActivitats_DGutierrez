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
    /// Lógica de interacción para PantallaReserva.xaml
    /// </summary>
    public partial class PantallaReserva : Window
    {
        Usuari usuariActual;
        int usuariAct;
        ConnexioBD connexio;
        Activitat activitatSeleccionada;
        public PantallaReserva(Usuari usuari, Activitat activitatReservar)
        {
            InitializeComponent();

            gridResumReserva.Visibility = Visibility.Hidden;

            MySqlConnection mySqlConnection = new MySqlConnection();
            connexio = new ConnexioBD(mySqlConnection, "localhost", "3306", "root", "", "projectedb");

            usuariAct = usuari.Id;
            usuariActual = usuari;

            activitatSeleccionada = activitatReservar;
        }

        private void buttonSortirClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void buttonMinimitzarClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void button_TornarPantallaActivitats_Click(object sender, RoutedEventArgs e)
        {
            PantallaPrincipal pantallaPrincipal = new PantallaPrincipal(usuariActual);
            pantallaPrincipal.Show();
            this.Close();
        }
        // Dades de la reserva
        private void textBox_NumPersones_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox_NumPersones.Clear();
        }

        private void textBox_Durada_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        //--

        private void button_ReservarActivitat_Click(object sender, RoutedEventArgs e)
        {
            DateTime dataReserva = (DateTime)datePicker_DataReserva.SelectedDate;
            int numPersones = Convert.ToInt32(textBox_NumPersones.Text);

            if (numPersones < 1 || numPersones > 40)
            {
                MessageBox.Show("El nombre de persones ha de ser major d'1 i menor de 40.");
                return;
            }
            if (dataReserva == DateTime.MinValue)
            {
                MessageBox.Show("La data de reserva no pot estar buida.");
                return;
            }
            if (dataReserva < DateTime.Now)
            {
                MessageBox.Show("La date de reserva no pot ser anterior a la data actual.");
                return;
            }

            decimal preuFinal = activitatSeleccionada.Preu * numPersones;
            ReservesBD reserves = new ReservesBD(connexio);

            textBlock_ResumNomActivitat.Text = activitatSeleccionada.Nom;
            textBlock_ResumData.Text = dataReserva.ToString();
            textBlock_ResumNumPersones.Text = numPersones.ToString();
            textBlock_ResumPreuActivitat.Text = activitatSeleccionada.Preu.ToString();
            textBlock_ResumPreuFinal.Text = preuFinal.ToString();

            gridResumReserva.Visibility = Visibility.Visible;

            reserves.AfegirReserva(usuariAct, activitatSeleccionada.Id, dataReserva, numPersones, preuFinal);
        }
    }
}
