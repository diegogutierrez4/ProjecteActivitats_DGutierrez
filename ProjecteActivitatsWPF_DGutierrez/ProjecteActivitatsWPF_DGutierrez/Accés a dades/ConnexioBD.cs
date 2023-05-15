using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace ProjecteActivitatsWPF_DGutierrez.Accés_a_dades
{
    public class ConnexioBD
    {
        //Atributs
        MySqlConnection conection;
        private string servidor;
        private string port;
        private string usuari;
        private string password;
        private string baseDades;

        public ConnexioBD()
        {
            conection = new MySqlConnection();
            //EmplenarValorsDefecte();
        }

        public ConnexioBD(MySqlConnection conection, string servidor, string port, string usuari, string password, string baseDades)
        {
            this.conection = conection;
            this.servidor = servidor;
            this.port = port;
            this.usuari = usuari;
            this.password = password;
            this.baseDades = baseDades;
        }
        private string StringConnexio()
        {
            string stringConnexio = $"server={servidor};port={port};user={usuari};password={password};database={baseDades};";
            return stringConnexio;
        }
        public MySqlConnection Connectar()
        {
            try
            {
                conection.ConnectionString = StringConnexio();
                conection.Open();
                MessageBox.Show("Connexió oberta OK!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(("Error al obrir la BD: " + ex.Message));
            }
            return conection;
        }
        public void Desconnectar()
        {
            MessageBox.Show("!");
            conection.Close();
        }

    }
}
