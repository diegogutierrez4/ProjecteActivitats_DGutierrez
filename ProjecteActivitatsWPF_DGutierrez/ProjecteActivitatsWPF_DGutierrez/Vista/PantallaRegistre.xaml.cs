using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            DateTime dataNaix;

            UsuarisBD usuarisBD = new UsuarisBD(connexio);

            List<Usuari> usuaris = usuarisBD.ObtenirUsuaris();

            foreach(Usuari usuari in  usuaris)
            {
                if (usuari.NomUsuari == nomUsuari)
                {
                    MessageBox.Show("El nom d'usuari ja existeix.");
                    return;
                }
            }
            if (!DateTime.TryParse(textBox_DataNaix.Text, out dataNaix))
            {
                MessageBox.Show("La data de naixement no és vàlida.");
                return;
            }
            string correu = textBox_Correu.Text;
            string contrasenya1 = passwordBox_Contrasenya1.Password;
            string contrasenya2 = passwordBox_Contrasenya2.Password;

            // Validacions de les dades de registre
            if (nom.Length < 3 || cognom.Length < 3)
            {
                MessageBox.Show("El nom i el cognom han de tenir almenys 3 caràcters.");
                return;
            }

            if (nomUsuari.Length < 4)
            {
                MessageBox.Show("El nom d'usuari ha de tenir un mínim de 4 caràcters.");
                return;
            }

            if (!ValidarCorreu(correu))
            {
                MessageBox.Show("El correu electrònic no té un format vàlid.");
                return;
            }

            if (contrasenya1.Length < 6)
            {
                MessageBox.Show("La contrasenya ha de tenir un mínim de 6 caràcters.");
                return;
            }

            if (contrasenya1 != contrasenya2)
            {
                MessageBox.Show("Les contrasenyes no coincideixen.");
                return;
            }

            bool modeCreador = false;
            if (checkBox_ModeCreador.IsChecked == true)
                modeCreador = true;

            UsuarisBD nouUsuari = new UsuarisBD(connexio);
            nouUsuari.AfegirUsuari(nom, cognom, nomUsuari, correu, contrasenya1, dataNaix, modeCreador);

            textBox_Nom.Text = "Nom";
            textBox_Cognom.Text = "Cognom";
            textBox_NomUsuari.Text = "Nom d'usuari";
            textBox_DataNaix.Text = "Data de naixement";
            textBox_Correu.Text = "Correu electrònic";
            passwordBox_Contrasenya1.Password = "Contrasenya";
            passwordBox_Contrasenya2.Password = "Contrasenya";
            checkBox_ModeCreador.IsChecked = false;
        }

        private static bool ValidarCorreu(string correu)
        {
            string regex = @"^[^@\s]+@[^@\s]+\.(com|cat|net|org|gov)$";

            return Regex.IsMatch(correu, regex, RegexOptions.IgnoreCase);
        }

        private void button_TornarIniciSessio_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
