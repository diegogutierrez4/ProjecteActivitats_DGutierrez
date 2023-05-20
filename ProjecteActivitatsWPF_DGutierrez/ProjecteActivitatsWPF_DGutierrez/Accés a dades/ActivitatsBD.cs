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
    public class ActivitatsBD
    {
        // Atributs
        private ConnexioBD connexio;

        // Constructors
        public ActivitatsBD(ConnexioBD connexio)
        {
            this.connexio = connexio;
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

        public List<Activitat> ObtenirActivitats()
        {
            List<Activitat> llistaActivitats = new List<Activitat>();

            try
            {
                string obtenirActivitats = "SELECT * FROM activitats";
                MySqlCommand command = new MySqlCommand(obtenirActivitats, Connexio.Connectar());
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(reader.GetOrdinal("id_activitat"));
                    string nom = reader.GetString(reader.GetOrdinal("nom"));
                    string ubicacio = reader.GetString(reader.GetOrdinal("ubicacio"));
                    Categoria categoria = (Categoria)reader.GetOrdinal("categoria");
                    string descripcio = reader.GetString(reader.GetOrdinal("descripcio"));
                    string durada = reader.GetString(reader.GetOrdinal("durada"));
                    decimal preu = reader.GetDecimal(reader.GetOrdinal("preu"));
                    int usuariCreador = reader.GetInt32(reader.GetOrdinal("usuariCreador"));
                    string nomImatge = "/ImatgesActivitats/" + reader.GetString(reader.GetOrdinal("nomImatge"));


                    Activitat activitat = new Activitat(id, nom, descripcio, ubicacio, categoria, durada, preu, usuariCreador, nomImatge);
                    llistaActivitats.Add(activitat);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error a l'obtenir les activitats de la BD: " + ex.Message);
            }
            Connexio.Desconnectar();
            return llistaActivitats;
        } 
    }
}