using System;
using System.Collections.Generic;
using System.IO;
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
    /// Lógica de interacción para PantallaPrincipal.xaml
    /// </summary>
    public partial class PantallaPrincipal : Window
    {
        Usuari usuariActual;
        ConnexioBD connexio;

        public PantallaPrincipal(Usuari usuari)
        {
            InitializeComponent();
            MySqlConnection mySqlConnection = new MySqlConnection();
            connexio = new ConnexioBD(mySqlConnection, "localhost", "3306", "root", "", "projectedb");

            usuariActual = usuari;
            DataContext = this;

            Array llistaCategories = Enum.GetValues(typeof(Categoria));
            foreach (Categoria categoria in llistaCategories)
            {
                comboBox_OrdenarPerCategories.Items.Add(categoria);
            }

            ActivitatsBD activitatsBD = new ActivitatsBD(connexio);
            List<Activitat> llistaActivitats = activitatsBD.ObtenirActivitats();

            listBoxActivitats.ItemsSource = llistaActivitats;

            if (!usuariActual.ModeCreador)
            {
                button_AfegirActivitat.Visibility = Visibility.Hidden;
            }
        }

        // Botons
        private void buttonSortirClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void buttonMinimitzarClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void button_TornarIniciSessio_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        // -
        private void button_AfegirActivitat_Click(object sender, RoutedEventArgs e)
        {
            PantallaCrearActivitat pantallaCrearActivitat = new PantallaCrearActivitat(usuariActual);
            pantallaCrearActivitat.Show();
            this.Close();
        }

        private void buttonReservarActivitat_Click(object sender, RoutedEventArgs e)
        {
            Activitat activitatReservar;

            activitatReservar = (Activitat)listBoxActivitats.SelectedItem;

            if (activitatReservar == null)
                MessageBox.Show("Cap activitat seleccionada!");
            else
            {
                PantallaReserva reservaActivitat = new PantallaReserva(usuariActual, activitatReservar);
                reservaActivitat.Show();
                this.Close();
            }

        }

        private void listBoxActivitats_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        // Filtrar

        private void textBox_Ubicacio_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_OrdenarPerUbicacio_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox_OrdenarPerUbicacio.Clear();
        }

        private void comboBox_Categories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void textBox_OrdenarPerDurada_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox_OrdenarPerDurada.Clear();
        }

        private void radioButton_OrdenarPreuAsc_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void radioButton_OrdenarPreuDesc_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void button_Filtrar_Click(object sender, RoutedEventArgs e)
        {
            string ubicacioOrdenar = textBox_OrdenarPerUbicacio.Text;
            string duradaOrdenar = textBox_OrdenarPerDurada.Text;
            string categoriaOrdenar = comboBox_OrdenarPerCategories.Text;

            ActivitatsBD activitatsBD = new ActivitatsBD(connexio);
            List<Activitat> llistaActivitats = activitatsBD.ObtenirActivitats();

            List<Activitat> llistaActivitatFiltrada = llistaActivitats.ToList();

            foreach(Activitat activitat in llistaActivitats)
            {
                if (activitat.Ubicacio != ubicacioOrdenar && ubicacioOrdenar != "Ubicació")
                    llistaActivitatFiltrada.Remove(activitat);
                if (activitat.Durada != duradaOrdenar && duradaOrdenar != "Durada")
                    llistaActivitatFiltrada.Remove(activitat);
                if (activitat.Categoria.ToString() != categoriaOrdenar)
                    llistaActivitatFiltrada.Remove(activitat);
            }

            if (radioButton_OrdenarPreuAsc.IsChecked == true)
                llistaActivitatFiltrada.OrderBy(activitat => activitat.Preu);
            if (radioButton_OrdenarPreuDesc.IsChecked == true)
            {
                llistaActivitatFiltrada.OrderBy(activitat => activitat.Preu);
                llistaActivitatFiltrada.Reverse();
            }
            
            listBoxActivitats.ItemsSource = llistaActivitatFiltrada;

            textBox_OrdenarPerUbicacio.Text = "Ubicació";
            textBox_OrdenarPerDurada.Text = "Durada";
            comboBox_OrdenarPerCategories.SelectedItem = null;
        }
    }
}
