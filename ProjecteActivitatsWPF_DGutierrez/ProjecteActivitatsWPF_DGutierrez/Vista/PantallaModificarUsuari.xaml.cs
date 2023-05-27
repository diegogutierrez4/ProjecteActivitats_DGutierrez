using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para PantallaModificarUsuari.xaml
    /// </summary>
    public partial class PantallaModificarUsuari : Window
    {
        ConnexioBD connexio;
        Usuari usuariActual;
        Usuari usuariActualModificat;

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
            passwordBox_Contrasenya.Password = usuariActual.Contrasenya;
            textBox_DataNaix.Text = usuariActual.DataNaix.Date.ToString("dd/MM/yyyy");
            checkBox_ModeCreador.IsChecked = false;

            if (usuariActual.ModeCreador == true)
            {
                checkBox_ModeCreador.IsChecked = true;
            }

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
            if (usuariActualModificat != null)
            {
                pantallaPrincipal = new PantallaPrincipal(usuariActualModificat);
            }
            pantallaPrincipal.Show();
            this.Close();
        }

        private void button_ModificarDades_Click(object sender, RoutedEventArgs e)
        {
            string nom = textBox_Nom.Text;
            string cognom= textBox_Cognom.Text;
            string nomUsuari = textBox_NomUsuari.Text;
            DateTime dataNaix;

            UsuarisBD usuarisBD = new UsuarisBD(connexio);

            List<Usuari> usuaris = usuarisBD.ObtenirUsuaris();

            foreach (Usuari usuari in usuaris)
            {
                if (usuari.NomUsuari == nomUsuari && nomUsuari != usuariActual.NomUsuari)
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
            string contrasenya = passwordBox_Contrasenya.Password;

            // Validacions de les dades modificades
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

            if (contrasenya.Length < 6)
            {
                MessageBox.Show("La contrasenya ha de tenir un mínim de 6 caràcters.");
                return;
            }

            bool modeCreador = false;
            if (checkBox_ModeCreador.IsChecked == true)
                modeCreador = true;

            usuarisBD.ModificarUsuari(usuariActual.Id, nom, cognom, nomUsuari, correu, contrasenya, dataNaix, modeCreador);
            usuariActualModificat = new Usuari(usuariActual.Id, nom, cognom, nomUsuari, correu, contrasenya, dataNaix, modeCreador);
        }
        private static bool ValidarCorreu(string correu)
        {
            string regex = @"^[^@\s]+@[^@\s]+\.(com|cat|net|org|gov)$";

            return Regex.IsMatch(correu, regex, RegexOptions.IgnoreCase);
        }
    }
}
