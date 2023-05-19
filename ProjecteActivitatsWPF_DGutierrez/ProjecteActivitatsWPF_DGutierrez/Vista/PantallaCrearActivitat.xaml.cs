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
using MySql.Data.MySqlClient;
using ProjecteActivitatsWPF_DGutierrez.Accés_a_dades;
using ProjecteActivitatsWPF_DGutierrez.Model;

namespace ProjecteActivitatsWPF_DGutierrez.Vista
{
    /// <summary>
    /// Lógica de interacción para PantallaCrearActivitat.xaml
    /// </summary>
    public partial class PantallaCrearActivitat : Window
    {
        ConnexioBD connexio;

        Usuari usuariActual;
        private string nomArxiuSeleccionat;

        public PantallaCrearActivitat(Usuari usuari)
        {
            InitializeComponent();
            MySqlConnection mySqlConnection = new MySqlConnection();
            connexio = new ConnexioBD(mySqlConnection, "localhost", "3306", "root", "", "projectedb");
            MySqlConnection connexioBD = connexio.Connectar();

            usuariActual = usuari;

            textBlock_MissatgeCrarActivitat.Text = $"Crear Activitat: @{usuari.NomUsuari}";
            
            Activitat activitat = new Activitat();

            Array llistaCategories = Enum.GetValues(typeof(Categoria));
            foreach (Categoria categoria in llistaCategories)
            {
                comboBox_Categories.Items.Add(categoria);
            }
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
        private void comboBox_Categories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        // -

        private void Button_Imatge_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp|Todos los archivos|*.*";
            string nomArxiu = "";

            if (openFileDialog.ShowDialog() == true)
            {
                // Obté la ruta completa de l'element seleccionat
                string imagePath = openFileDialog.FileName;

                // Crea la carpeta dins del projecte(si no existeix)
                string folderPath = @"C:\DAW1\ProjecteActivitats_DGutierrez\ProjecteActivitatsWPF_DGutierrez\ProjecteActivitatsWPF_DGutierrez\ImatgesActivitats";
                Directory.CreateDirectory(folderPath);

                // Copia l'arxiu seleccionat a la carpeta
                string destinationPath = System.IO.Path.Combine(folderPath, System.IO.Path.GetFileName(imagePath));
                File.Copy(imagePath, destinationPath, true);

                // Obtenir nom del arxiu
                nomArxiu = System.IO.Path.GetFileName(destinationPath);

                nomArxiuSeleccionat = nomArxiu;
            }
        }
        private void buttonCrearActivitat_Click(object sender, RoutedEventArgs e)
        {
            string nom = textBox_Nom.Text;
            string ubicacio = textBox_Ubicacio.Text;
            string categoria = comboBox_Categories.Text;
            string descripcio = textBox_Descripcio.Text;
            string durada = textBox_Durada.Text;
            decimal preu = Convert.ToDecimal(textBox_Preu.Text);
            int usuariCreador = usuariActual.Id;
            string nomImatge = nomArxiuSeleccionat;

            // Validacions de les dades de crear activitat
            if (nom.Length < 3)
            {
                MessageBox.Show("El nom ha de tenir un mínim de 3 caràcters.");
                return;
            }

            if (ubicacio.Length < 1)
            {
                MessageBox.Show("La ubicació no pot estar buida.");
                return;
            }

            if (categoria == string.Empty)
            {
                MessageBox.Show("Has de seleccionar una categoria.");
                return;
            }

            if (descripcio.Length < 4)
            {
                MessageBox.Show("La descripció ha de tenir un mínim de 4 caràcters.");
                return;
            }

            if (durada.Length < 1)
            {
                MessageBox.Show("La durada no pot estar buida.");
                return;
            }

            ActivitatsBD activitat = new ActivitatsBD(connexio);
            activitat.AfegirActivitat(nom, ubicacio, categoria, descripcio, durada, preu, usuariCreador, nomImatge);

            activitat.AfegirUsuariActivitat(usuariCreador, activitat.obtenirIdActivitat(usuariCreador));
        }
    }
}
