using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
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
            textBox_Nom.Text = "Nom";
            textBox_Ubicacio.Text = "Ubicació";
            textBox_Descripcio.Text = "Descripció";
            textBox_Durada.Text = "Durada";
            textBox_Preu.Text = "Preu";
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
        // Dades de crear Activitat

        private void textBox_Nom_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_Nom_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox_Nom.Clear();
        }
        // -

        private void textBox_Ubicacio_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_Ubciacio_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox_Ubicacio.Clear();
        }
        // -

        private void textBox_Descripcio_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_Descripcio_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox_Descripcio.Clear();
        }
        // -

        private void textBox_Durada_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_Durada_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox_Durada.Clear();
        }
        // -

        private void textBox_Preu_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_Preu_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox_Preu.Clear();
        }
        // -

        private void Button_Imatge_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp|Todos los archivos|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                // Obtén la ruta completa del archivo seleccionado
                string imagePath = openFileDialog.FileName;

                // Crea la carpeta dentro de tu proyecto (si no existe)
                string folderPath = @"C:\DAW1\ProjecteActivitats_DGutierrez\ProjecteActivitatsWPF_DGutierrez\ProjecteActivitatsWPF_DGutierrez\ImatgesActivitats";
                Directory.CreateDirectory(folderPath);

                // Copia el archivo seleccionado a la carpeta
                string destinationPath = System.IO.Path.Combine(folderPath, System.IO.Path.GetFileName(imagePath));
                File.Copy(imagePath, destinationPath, true);
            }
        }
        private void buttonCrearActivitat_Click(object sender, RoutedEventArgs e)
        {

        } 
    }
}
