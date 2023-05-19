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
                MySqlConnection connection = Connexio.Connectar();
                MySqlCommand command = connection.CreateCommand();
                MySqlTransaction transaction;

                // Iniciar transaction
                transaction = connection.BeginTransaction();
                command.Connection = connection;
                command.Transaction = transaction;

                try
                {
                    // Insertar la taula 'activitats'
                    string registrarActivitat = $"INSERT INTO activitats (nom, ubicacio, categoria, descripcio, durada, preu, usuariCreador, nomImatge) VALUES ('{nom}', '{ubicacio}', '{categoria}', '{descripcio}', '{durada}', '{preu}', {usuariCreador}, '{nomImatge}')";
                    command.CommandText = registrarActivitat;
                    command.ExecuteNonQuery();

                    // Obtener ID de l'actividad insertada anteriorment
                    int idActivitat = (int)command.LastInsertedId;

                    // Insertar a la taula 'usuari_activitat'
                    string registrarUsuariActivitat = $"INSERT INTO usuari_activitat (usuari_id, activitat_id) VALUES ({usuariCreador}, {idActivitat})";
                    command.CommandText = registrarUsuariActivitat;
                    command.ExecuteNonQuery();

                    // Confirmar la transaction
                    transaction.Commit();

                    MessageBox.Show("Enhorabona, activitat creada correctament!");
                }
                catch (Exception ex)
                {
                    // Revertir la transaction en cas d'error
                    transaction.Rollback();
                    MessageBox.Show("Error en l'execució de la transacció: " + ex.Message);
                }
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