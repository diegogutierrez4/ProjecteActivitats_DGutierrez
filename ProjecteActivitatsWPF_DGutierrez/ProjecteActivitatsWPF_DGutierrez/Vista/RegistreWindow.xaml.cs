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

namespace ProjecteActivitatsWPF_DGutierrez.Vista
{
    /// <summary>
    /// Lógica de interacción para RegistreWindow.xaml
    /// </summary>
    public partial class RegistreWindow : Window
    {
        public RegistreWindow()
        {
            InitializeComponent();
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

        private void textBox_Cognom_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_NomUsuari_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_DataNaix_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_Correu_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_Contrasenya1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_Contrasenya2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void buttonRegistre_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
