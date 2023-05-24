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
    /// Lógica de interacción para PantallaModificarUsuari.xaml
    /// </summary>
    public partial class PantallaModificarUsuari : Window
    {
        ConnexioBD connexio;
        Usuari usuariActual;

        public PantallaModificarUsuari(Usuari usuari)
        {
            InitializeComponent();
            MySqlConnection mySqlConnection = new MySqlConnection();
            connexio = new ConnexioBD(mySqlConnection, "localhost", "3306", "root", "", "projectedb");
            MySqlConnection connexioBD = connexio.Connectar();

            usuariActual = usuari;

            textBox_Nom.Text = usuariActual.Nom;
            textBox_Cognom.Text = usuariActual.Cognom;
            textBox_NomUsuari.Text = usuariActual.NomUsuari;
            textBox_Correu.Text = usuariActual.Correu;
            textBox_Contrasenya.Text = usuariActual.Contrasenya;
            textBox_DataNaix.Text = usuariActual.DataNaix.Date.ToString("dd/MM/yyyy");
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

        private void button_ModificarDades_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
