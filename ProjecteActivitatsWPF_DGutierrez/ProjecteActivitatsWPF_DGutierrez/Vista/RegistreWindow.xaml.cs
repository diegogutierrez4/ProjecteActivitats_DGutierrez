using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace ProjecteActivitatsWPF_DGutierrez.Vista
{
    /// <summary>
    /// Lógica de interacción para RegistreWindow.xaml
    /// </summary>
    public partial class RegistreWindow : Window
    {
        ConnexioBD connexio;
        public RegistreWindow()
        {
            InitializeComponent();
            MySqlConnection mySqlConnection = new MySqlConnection();
            connexio = new ConnexioBD(mySqlConnection, "localhost", "3306", "root", "", "projectedb");
            MySqlConnection connexioBD = connexio.Connectar();
        }

        // Sortir i minimitzar
        private void buttonSortirClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void buttonMinimitzarClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        // Dades Registre

        private void textBox_Nom_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void textBox_Nom_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox_Nom.Clear();
        }
        // -
        private void textBox_Cognom_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void textBox_Cognom_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox_Cognom.Clear();
        }
        // -

        private void textBox_NomUsuari_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void textBox_NomUsuari_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox_NomUsuari.Clear();
        }
        //-
        private void textBox_DataNaix_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void textBox_DataNaix_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox_DataNaix.Clear();
        }
        // -

        private void textBox_Correu_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void textBox_Correu_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox_Correu.Clear();
        }
        // -
        private void textBox_Contrasenya1_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }
        private void textBox_Contrasenya1_GotFocus(object sender, RoutedEventArgs e)
        {
            passwordBox_Contrasenya1.Clear();
        }
        // -
        private void textBox_Contrasenya2_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }
        private void textBox_Contrasenya2_GotFocus(object sender, RoutedEventArgs e)
        {
            passwordBox_Contrasenya2.Clear();
        }
        // -

        private void buttonRegistre_Click(object sender, RoutedEventArgs e)
        {
            string nom = textBox_Nom.Text;
            string cognom = textBox_Cognom.Text;
            string nomUsuari = textBox_NomUsuari.Text;
            DateTime dataNaix = Convert.ToDateTime(textBox_DataNaix.Text);
            string correu = textBox_Correu.Text;
            string contrasenya = passwordBox_Contrasenya1.Password;

            UsuarisBD nouUsuari = new UsuarisBD(connexio);
            nouUsuari.AfegirUsuari(nom, cognom, nomUsuari, correu, contrasenya, dataNaix, true);

            textBox_Nom.Text = "Nom";
            textBox_Cognom.Text = "Cognom";
            textBox_NomUsuari.Text = "Nom d'usuari";
            textBox_DataNaix.Text = "Data de naixement";
            textBox_Correu.Text = "Correu electònic";
            passwordBox_Contrasenya1.Password = "Contrasenya";
            passwordBox_Contrasenya2.Password = "Contrasenya";
        }

        private void button_TornarIniciSessio_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
