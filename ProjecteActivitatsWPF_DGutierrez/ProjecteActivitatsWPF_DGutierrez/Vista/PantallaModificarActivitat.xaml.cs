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
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using ProjecteActivitatsWPF_DGutierrez.Accés_a_dades;
using ProjecteActivitatsWPF_DGutierrez.Model;

namespace ProjecteActivitatsWPF_DGutierrez.Vista
{
    /// <summary>
    /// Lógica de interacción para PantallaModificarActivitat.xaml
    /// </summary>
    public partial class PantallaModificarActivitat : Window
    {
        ConnexioBD connexio;
        Activitat activitatModificar;
        Usuari usuariActual;
        string nomArxiuSeleccionat;

        public PantallaModificarActivitat(Usuari usuari, Activitat activitat)
        {
            InitializeComponent();
            MySqlConnection mySqlConnection = new MySqlConnection();
            connexio = new ConnexioBD(mySqlConnection, "localhost", "3306", "root", "", "projectedb");
            MySqlConnection connexioBD = connexio.Connectar();

            activitatModificar = activitat;
            usuariActual = usuari;
            nomArxiuSeleccionat = activitat.Imatge;

            Array llistaCategories = Enum.GetValues(typeof(Categoria));
            foreach (Categoria categoria in llistaCategories)
            {
                comboBox_ModificarCategories.Items.Add(categoria);
            }

            textBox_ModificarNom.Text = activitatModificar.Nom;
            textBox_ModificarUbicacio.Text = activitatModificar.Ubicacio;
            comboBox_ModificarCategories.SelectedItem = activitatModificar.Categoria;
            textBox_ModificarDescripcio.Text = activitatModificar.Descripcio;
            textBox_ModificarDurada.Text = activitatModificar.Durada;
            textBox_ModificarPreu.Text = activitatModificar.Preu.ToString();
        }

        private void buttonMinimitzarClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void buttonSortirClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void button_TornarPantallaActivitats_Click(object sender, RoutedEventArgs e)
        {
            PantallaPrincipal pantallaPrincipal = new PantallaPrincipal(usuariActual);
            pantallaPrincipal.Show();
            this.Close();
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
                string rutaImatgeUsuari = openFileDialog.FileName;

                string carpetaGuardar = @"C:\DAW1\ProjecteActivitats_DGutierrez\ProjecteActivitatsWPF_DGutierrez\ProjecteActivitatsWPF_DGutierrez\ImatgesActivitat\";
                // Crea la carpeta dins del projecte(si no existeix)matgesActivitats";
                Directory.CreateDirectory(carpetaGuardar);

                // Copia l'arxiu seleccionat a la carpeta
                string rutaDesti = System.IO.Path.Combine(carpetaGuardar, System.IO.Path.GetFileName(rutaImatgeUsuari));
                File.Copy(rutaImatgeUsuari, rutaDesti, true);

                // Obtenir nom del arxiu
                nomArxiu = System.IO.Path.GetFileName(rutaDesti);

                nomArxiuSeleccionat = "/ImatgesActivitat/" + nomArxiu;
            }
        }

        private void buttonModificarActivitat_Click(object sender, RoutedEventArgs e)
        {
            string nom = textBox_ModificarNom.Text;
            string ubicacio = textBox_ModificarUbicacio.Text;
            string categoria = comboBox_ModificarCategories.Text;
            string descripcio = textBox_ModificarDescripcio.Text;
            string durada = textBox_ModificarDurada.Text;
            decimal preu = Convert.ToDecimal(textBox_ModificarPreu.Text);
            int usuariCreador = usuariActual.Id;
            string imatge = nomArxiuSeleccionat;

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
            activitat.ModificarActivitat(activitatModificar.Id, nom, ubicacio, categoria, descripcio, durada, preu, usuariCreador, imatge);
        }
    }
}
