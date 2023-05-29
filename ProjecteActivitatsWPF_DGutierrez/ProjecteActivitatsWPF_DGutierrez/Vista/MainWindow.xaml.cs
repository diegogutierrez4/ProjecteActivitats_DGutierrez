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
using ProjecteActivitatsWPF_DGutierrez.Model;
using System.Runtime.InteropServices;
using System.Windows.Automation;
using System.Windows.Interop;
using System.Diagnostics;

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
        }
        // Sortir
        private void buttonSortirClick(object sender, RoutedEventArgs e)
        {
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
            UsuarisBD usuarisBD = new UsuarisBD(connexio);

            List<Usuari> usuaris = usuarisBD.ObtenirUsuaris();
            Usuari usuariActual = new Usuari();

            string nomUsuari = textBox_NomUsuari.Text;
            string contrasenya = passwordBox_Contrasenya.Password;
            bool usuariExisteix = false;

            foreach(Usuari usuari in usuaris)
            {
                if (usuari.NomUsuari == nomUsuari && usuari.Contrasenya == contrasenya)
                {
                    usuariExisteix = true;
                    usuariActual = usuari;
                }
            }
            if (!usuariExisteix)
            {
                MessageBox.Show("Usuari/contrasenya no vàlid!");
            }
            else
            {
                PantallaPrincipal pantallaPrincipal = new PantallaPrincipal(usuariActual);
                pantallaPrincipal.Show();
                this.Close();
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://www.youtube.com/shorts/oJNZyDeNfgQ";
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string url = "https://www.youtube.com/shorts/mq4eMfRYg0Y";
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string url = "https://www.youtube.com/watch?v=6DcinsRPR5s&list=PL7UKN3Qg8HNO19kHMWhRtpz0g8656sOZI&index=12";
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }
    }
}
