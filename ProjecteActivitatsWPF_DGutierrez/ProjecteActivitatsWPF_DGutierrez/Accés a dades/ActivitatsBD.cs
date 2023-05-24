using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ProjecteActivitatsWPF_DGutierrez.Model;
using System.Windows;
using System.Data;
using System.Windows.Media.Imaging;
using ProjecteActivitatsWPF_DGutierrez.Vista;
using System.IO;
using Org.BouncyCastle.Utilities;
using System.Windows.Media;
using System.Drawing;

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
        public void AfegirActivitat(string nom, string ubicacio, string categoria, string descripcio, string durada, decimal preu, int usuariCreador, string imatge)
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
                    string registrarActivitat = $"INSERT INTO activitats (nom, ubicacio, categoria, descripcio, durada, preu, usuariCreador, imatge) VALUES ('{nom}', '{ubicacio}', '{categoria}', '{descripcio}', '{durada}', '{preu}', {usuariCreador}, '{imatge}')";
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
                    int id = reader.GetInt32("id_activitat");
                    string nom = reader.GetString("nom");
                    string ubicacio = reader.GetString("ubicacio");
                    string categoriaString = reader.GetString(reader.GetOrdinal("categoria"));
                    Categoria categoria = (Categoria)Enum.Parse(typeof(Categoria), categoriaString);
                    string descripcio = reader.GetString("descripcio");
                    string durada = reader.GetString("durada");
                    decimal preu = reader.GetDecimal("preu");
                    int usuariCreador = reader.GetInt32("usuariCreador");
                    string imatge = reader.GetString("imatge");

                    
                    Activitat activitat = new Activitat(id, nom, descripcio, ubicacio, categoria, durada, preu, usuariCreador, imatge);
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