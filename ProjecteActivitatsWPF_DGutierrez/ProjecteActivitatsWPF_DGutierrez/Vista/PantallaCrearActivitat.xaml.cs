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
using Microsoft.Win32;
using ProjecteActivitatsWPF_DGutierrez.Model;

namespace ProjecteActivitatsWPF_DGutierrez.Vista
{
    /// <summary>
    /// Lógica de interacción para PantallaCrearActivitat.xaml
    /// </summary>
    public partial class PantallaCrearActivitat : Window
    {
        Usuari usuariActual;
        public PantallaCrearActivitat(Usuari usuari)
        {
            InitializeComponent();
            usuariActual = usuari;

            textBlock_MissatgeCrarActivitat.Text = $"Crear Activitat: @{usuari.NomUsuari}";
        }

        private void button_TornarPantallaActivitats_Click(object sender, RoutedEventArgs e)
        {
            PantallaPrincipal pantallaPrincipal = new PantallaPrincipal(usuariActual);
            pantallaPrincipal.Show();
            this.Close();
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

        private void textBox_Nom_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_Nom_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void textBox_Ubicacio_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_Ubciacio_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void textBox_Descripcio_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_Descripcio_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void textBox_Durada_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_Durada_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void textBox_Preu_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_Preu_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Imatge_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonCrearActivitat_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
