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
    /// Lógica de interacción para PantallaConsultarReserves.xaml
    /// </summary>
    public partial class PantallaConsultarReserves : Window
    {
        public PantallaConsultarReserves()
        {
            InitializeComponent();
        }

        private void buttonSortirClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void buttonMinimitzarClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void listBoxActivitatsReservades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
