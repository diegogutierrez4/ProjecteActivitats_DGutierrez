using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ProjecteActivitatsWPF_DGutierrez.Model;
using System.Windows;

namespace ProjecteActivitatsWPF_DGutierrez.Accés_a_dades
{
    class ActivitatsBD
    {
        // Atributs
        private ConnexioBD connexio;

        // Constructors
        public ActivitatsBD(ConnexioBD connexio)
        {
            this.Connexio = connexio;
        }

        // Propietats
        public ConnexioBD Connexio { get => connexio; set => connexio = value; }

        // Mètodes
        public void AfegirActivitat(string nom, string ubicacio, string categoria, string descripcio, string durada, decimal preu, int usuariCreador, string nomImatge)
        {
            try
            {
                string registrarActivitat = $"INSERT INTO activitats (nom, ubicacio, categoria, descripcio, durada, preu, usuariCreador, nomImatge) VALUES ('{nom}', '{ubicacio}', '{categoria}', '{descripcio}', '{durada}', '{preu}', {usuariCreador}, '{nomImatge}')";
                MySqlCommand command = new MySqlCommand(registrarActivitat, Connexio.Connectar());
                command.ExecuteNonQuery();

                MessageBox.Show("Enhorabona, activitat creada correctament!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error a l'obrir la BD: " + ex.Message);
            }
            finally
            {
                Connexio.Desconnectar();
            }
        }

        public void AfegirUsuariActivitat(int usuariId, int activitatId)
        {
            try
            {
                string relacioUsuariActivitat = $"INSERT INTO usuari_activitat (usuari_id, activitat_id) VALUES ({usuariId}, {activitatId})";
                MySqlCommand command = new MySqlCommand(relacioUsuariActivitat, Connexio.Connectar());
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error a l'obrir la BD: " + ex.Message);
            }
            finally
            {
                Connexio.Desconnectar();
            }
        }

        public int obtenirIdActivitat(int idUsuari)
        {
            int idActivitat = 0;
            try
            {
                string comandaObtenirIdActivitat = $"SELECT activitat_id FROM activitats WHERE usuariCreador = {idUsuari}";
                MySqlCommand command = new MySqlCommand(comandaObtenirIdActivitat, Connexio.Connectar());
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    idActivitat = reader.GetInt32(reader.GetOrdinal("usuari_id"));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error a l'obtenir activitat de la BD: " + ex.Message);
            }
            Connexio.Desconnectar();

            return idActivitat;
        }
        //public List<Usuari> ObtenirUsuaris()
        //{
        //    List<Usuari> llistaUsuaris = new List<Usuari>();

            //    try
            //    {
            //        string obtenirUsuaris = "SELECT * FROM usuaris";
            //        MySqlCommand command = new MySqlCommand(obtenirUsuaris, Connexio.Connectar());
            //        MySqlDataReader reader = command.ExecuteReader();

            //        while (reader.Read())
            //        {
            //            int id = reader.GetInt32(reader.GetOrdinal("id_usuari"));
            //            string nom = reader.GetString(reader.GetOrdinal("nom"));
            //            string cognom = reader.GetString(reader.GetOrdinal("cognom"));
            //            string nomUsuari = reader.GetString(reader.GetOrdinal("nomUsuari"));
            //            string correu = reader.GetString(reader.GetOrdinal("correu"));
            //            string contrasenya = reader.GetString(reader.GetOrdinal("contrasenya"));
            //            DateTime dataNaix = reader.GetDateTime(reader.GetOrdinal("dataNaix"));
            //            bool modeCreador = reader.GetBoolean(reader.GetOrdinal("modeCreador"));

            //            Usuari usuari = new Usuari(id, nom, cognom, nomUsuari, correu, contrasenya, dataNaix, modeCreador);
            //            llistaUsuaris.Add(usuari);
            //        }
            //        reader.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Error a l'obtenir els usuaris de la BD: " + ex.Message);
            //    }
            //    Connexio.Desconnectar();
            //    return llistaUsuaris;
            //}
    }
}