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

        /// <summary>
        /// Aquest mètode s'utilitza per afegir una activitat a la base de dades. Requereix diversos paràmetres per especificar les característiques de l'activitat.
        /// </summary>
        /// <param name="nom">El nom de l'activitat.</param>
        /// <param name="ubicacio">El nom de l'activitat.</param>
        /// <param name="categoria">La categoria de l'activitat.</param>
        /// <param name="descripcio">La descripció de l'activitat.</param>
        /// <param name="durada">La durada de l'activitat.</param>
        /// <param name="preu">El preu de l'activitat.</param>
        /// <param name="usuariCreador">L'ID de l'usuari creador de l'activitat.</param>
        /// <param name="imatge">La ruta o l'enllaç de la imatge de l'activitat.</param>
        /// <remarks>Aquest mètode utilitza una transacció per assegurar que les insercions a la base de dades es realitzen de manera coherent. Si alguna operació falla, la transacció es revertirà.</remarks>
        /// <exception cref="MySqlException">Es llença una excepció de tipus MySqlException si hi ha un error en la connexió o en l'execució de les comandes SQL.</exception>
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
                    // Insertar a la taula 'activitats'
                    string registrarActivitat = $"INSERT INTO activitats (nom, ubicacio, categoria, descripcio, durada, preu, usuariCreador, imatge) VALUES ('{nom}', '{ubicacio}', '{categoria}', '{descripcio}', '{durada}', @preu, {usuariCreador}, '{imatge}')";
                    command.CommandText = registrarActivitat;
                    command.Parameters.AddWithValue("@preu", preu);
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

        /// <summary>
        /// Aquest mètode s'utilitza per obtenir una llista de totes les activitats de la base de dades.
        /// </summary>
        /// <returns>Una llista d'objectes de tipus Activitat, que representa les activitats obtingudes.</returns>
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
        public List<int> ObtenirIdActivitats(int idUsuariAct)
        {
            List<int> llistaIdActivitats = new List<int>();

            try
            {
                string obtenirIdActivitat = $"SELECT id_activitat FROM activitats WHERE usuariCreador = {idUsuariAct}";
                MySqlCommand command = new MySqlCommand(obtenirIdActivitat, Connexio.Connectar());
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32("id_activitat");

                    llistaIdActivitats.Add(id);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error a l'obtenir les activitats de la BD: " + ex.Message);
            }
            Connexio.Desconnectar();
            return llistaIdActivitats;
        }
        /// <summary>
        /// Aquest mètode s'utilitza per eliminar una activitat de la base de dades. Requereix l'ID de l'activitat com a paràmetre per identificar l'activitat a eliminar.
        /// </summary>
        /// <param name="idActivitat">L'ID de l'activitat a eliminar.</param>
        public void EliminarActivitat(int idActivitat)
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
                    // Eliminar de la tabla 'reserves' primero
                    string eliminarReserves = $"DELETE FROM reserves WHERE activitat = {idActivitat}";
                    command.CommandText = eliminarReserves;
                    command.ExecuteNonQuery();

                    // Eliminar de la tabla 'usuari_activitat'
                    string eliminarUsuariActivitat = $"DELETE FROM usuari_activitat WHERE activitat_id = {idActivitat}";
                    command.CommandText = eliminarUsuariActivitat;
                    command.ExecuteNonQuery();

                    // Eliminar de la tabla 'activitats'
                    string eliminarActivitat = $"DELETE FROM activitats WHERE id_activitat = {idActivitat}";
                    command.CommandText = eliminarActivitat;
                    command.ExecuteNonQuery();

                    // Confirmar la transacción
                    transaction.Commit();

                    MessageBox.Show("Activitat eliminada correctament!");
                }
                catch (Exception ex)
                {
                    // Revertir la transacción en caso de error
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
        public void ModificarActivitat(int idActivitat, string nom, string ubicacio, string categoria, string descripcio, string durada, decimal preu, int usuariCreador, string imatge)
        {
            try
            {
                string modificarActivitat = $"UPDATE activitats SET nom = '{nom}', ubicacio = '{ubicacio}', categoria = '{categoria}', descripcio = '{descripcio}', durada = '{durada}', preu = @preu, usuariCreador = {usuariCreador}, imatge = '{imatge}' WHERE id_activitat = {idActivitat}";
                MySqlCommand command = new MySqlCommand(modificarActivitat, Connexio.Connectar());
                command.Parameters.AddWithValue("@preu", preu);
                command.ExecuteNonQuery();

                MessageBox.Show("Activitat modificada correctament!");
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
    }
}