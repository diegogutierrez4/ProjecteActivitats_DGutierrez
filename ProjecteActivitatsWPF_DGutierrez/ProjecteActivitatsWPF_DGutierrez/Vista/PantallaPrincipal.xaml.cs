﻿using System;
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
using ProjecteActivitatsWPF_DGutierrez.Model;

namespace ProjecteActivitatsWPF_DGutierrez.Vista
{
    /// <summary>
    /// Lógica de interacción para PantallaPrincipal.xaml
    /// </summary>
    public partial class PantallaPrincipal : Window
    {
        Usuari usuariActual;
        public PantallaPrincipal(Usuari usuari)
        {
            InitializeComponent();
            usuariActual = usuari;

            if (!usuariActual.ModeCreador)
            {
                button_AfegirActivitat.Visibility = Visibility.Hidden;
            }
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

        private void button_TornarIniciSessio_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        // -
        private void button_AfegirActivitat_Click(object sender, RoutedEventArgs e)
        {
            PantallaCrearActivitat pantallaCrearActivitat = new PantallaCrearActivitat(usuariActual);
            pantallaCrearActivitat.Show();
            this.Close();
        }

    }
}