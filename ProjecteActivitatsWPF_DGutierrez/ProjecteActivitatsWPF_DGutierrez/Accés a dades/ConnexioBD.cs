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
        private string StringConnexio()
        {
            string stringConnexio = $"server={Servidor};port={Port};user={Usuari};password={Password};database={BaseDades};";
            return stringConnexio;
        }
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
                MessageBox.Show(("Error al obrir la BD: " + ex.Message));
            }
            return Conection;
        }
        public void Desconnectar()
        {
            Conection.Close();
        }
        public void AfegirUsuari(string nom, string cognom, string nomUsuari, string correu, string contrasenya, DateTime dataNaix, bool modeCreador)
        {
            try
            {
                string connectionString = "server=localhost;port=3306;user=root;password=;database=projectedb";
                MySqlConnection connexioBD = new MySqlConnection(connectionString);
                connexioBD.Open();

                string registrarUsuari = $"INSERT INTO usuaris (nom, cognom, nomUsuari, correu, contrasenya, dataNaix, modeCreador) VALUES ('{nom}', '{cognom}', '{nomUsuari}', '{correu}', '{contrasenya}', '{dataNaix.ToString("yyyy-MM-dd")}', {(modeCreador ? 1 : 0)})";
                MySqlCommand command = new MySqlCommand(registrarUsuari, connexioBD);
                command.ExecuteNonQuery();

                MessageBox.Show("Usuari afegit!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error l'obrir la BD: " + ex.Message);
            }
            finally
            {
                Conection.Close();
            }
        }

    }
}
