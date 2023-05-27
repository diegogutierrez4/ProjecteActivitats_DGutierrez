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
        MySqlConnection connection;
        private string servidor;
        private string port;
        private string usuari;
        private string password;
        private string baseDades;

        // Constructors
        public MySqlConnection Conection { get => connection; set => connection = value; }
        public string Servidor { get => servidor; set => servidor = value; }
        public string Port { get => port; set => port = value; }
        public string Usuari { get => usuari; set => usuari = value; }
        public string Password { get => password; set => password = value; }
        public string BaseDades { get => baseDades; set => baseDades = value; }

        public ConnexioBD()
        {
            Conection = new MySqlConnection();
            //EmplenarValorsDefecte();
        }

        public ConnexioBD(MySqlConnection conection, string servidor, string port, string usuari, string password, string baseDades)
        {
            this.Conection = conection;
            this.Servidor = servidor;
            this.Port = port;
            this.Usuari = usuari;
            this.Password = password;
            this.BaseDades = baseDades;
        }
        /// <summary>
        /// Aquest mètode és un mètode auxiliar privat que construeix i retorna la cadena de connexió a la base de dades.
        /// </summary>
        /// <returns>Una cadena de connexió que conté les dades del servidor, port, usuari, contrasenya i base de dades.</returns>
        private string StringConnexio()
        {
            string stringConnexio = $"server={Servidor};port={Port};user={Usuari};password={Password};database={BaseDades};";
            return stringConnexio;
        }
        /// <summary>
        /// Aquest mètode s'utilitza per connectar-se a la base de dades.
        /// </summary>
        /// <returns>Un objecte MySqlConnection que representa la connexió establerta amb la base de dades.</returns>
        public MySqlConnection Connectar()
        {
            Conection.Close();
            try
            {
                Conection.ConnectionString = StringConnexio();
                Conection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(("Error l'obrir la BD: " + ex.Message));
            }
            return Conection;
        }
        // Aquest mètode s'utilitza per desconnectar-se de la base de dades.
        public void Desconnectar()
        {
            Conection.Close();
        }
    }
}
