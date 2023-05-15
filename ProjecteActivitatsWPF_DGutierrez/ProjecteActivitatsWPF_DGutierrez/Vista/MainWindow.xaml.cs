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
using MySql.Data.MySqlClient;
using ProjecteActivitatsWPF_DGutierrez.Accés_a_dades;

namespace ProjecteActivitatsWPF_DGutierrez.Vista
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ConnexioBD connexio;
        public MainWindow()
        {
            InitializeComponent();
            MySqlConnection mySqlConnection = new MySqlConnection();
            connexio = new ConnexioBD(mySqlConnection, "localhost",  "3306", "root", "", "projectedb");
            MySqlConnection connexioBD = connexio.Connectar();

            string sqlQuery = "SELECT * FROM usuaris";
            MySqlCommand command = new MySqlCommand(sqlQuery, connexioBD);

        }

        // Tancar app
        private void buttonSortirClick(object sender, RoutedEventArgs e)
        {
            connexio.Desconnectar();
            Application.Current.Shutdown();
        }

        // Minimitzar
        private void buttonMinimitzarClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        // Dades inici de sessió


        private void textBox_NomUsuari_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void passwordBox_Contrasenya_TextChanged(object sender, RoutedEventArgs e)
        {

        }

        // Registre
        private void buttonRegistre_Click(object sender, RoutedEventArgs e)
        {
            RegistreWindow pantallaRegistre = new RegistreWindow();
            pantallaRegistre.Show();
            this.Close();
        }

        // Iniciar sessió
        private void buttonIniciarSessio_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
