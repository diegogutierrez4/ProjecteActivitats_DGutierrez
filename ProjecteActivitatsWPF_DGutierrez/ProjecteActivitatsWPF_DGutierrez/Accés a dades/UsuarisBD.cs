using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using ProjecteActivitatsWPF_DGutierrez.Model;

namespace ProjecteActivitatsWPF_DGutierrez.Accés_a_dades
{
    public class UsuarisBD
    {
        // Atributs
        private ConnexioBD connexio;

        // Constructors
        public UsuarisBD(ConnexioBD connexio)
        {
            this.connexio = connexio;
        }

        // Propietats
        public ConnexioBD Connexio { get => connexio; set => connexio = value; }

        // Mètodes

        /// <summary>
        /// Aquest mètode s'utilitza per afegir un nou usuari a la base de dades.
        /// </summary>
        /// <param name="nom">El nom de l'usuari.</param>
        /// <param name="cognom">El cognom de l'usuari.</param>
        /// <param name="nomUsuari">El nom d'usuari de l'usuari.</param>
        /// <param name="correu">El correu electrònic de l'usuari.</param>
        /// <param name="contrasenya">La contrasenya de l'usuari.</param>
        /// <param name="dataNaix">La data de naixement de l'usuari.</param>
        /// <param name="modeCreador">Indica si l'usuari té el mode creador habilitat.</param>
        public void AfegirUsuari(string nom, string cognom, string nomUsuari, string correu, string contrasenya, DateTime dataNaix, bool modeCreador)
        {
            try
            {
                string registrarUsuari = $"INSERT INTO usuaris (nom, cognom, nomUsuari, correu, contrasenya, dataNaix, modeCreador) VALUES ('{nom}', '{cognom}', '{nomUsuari}', '{correu}', '{contrasenya}', '{dataNaix.ToString("yyyy-MM-dd")}', {(modeCreador ? 1 : 0)})";
                MySqlCommand command = new MySqlCommand(registrarUsuari, Connexio.Connectar());
                command.ExecuteNonQuery();

                MessageBox.Show("Benvingu@ a l'aplicació oficial de GuiaMe!");
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
        /// Aquest mètode s'utilitza per obtenir la llista de tots els usuaris de la base de dades.
        /// </summary>
        /// <returns>Una llista d'objectes Usuari que conté la informació dels usuaris obtinguts.</returns>
        public List<Usuari> ObtenirUsuaris()
        {
            List<Usuari> llistaUsuaris = new List<Usuari>();

            try
            {
                string obtenirUsuaris = "SELECT * FROM usuaris";
                MySqlCommand command = new MySqlCommand(obtenirUsuaris, Connexio.Connectar());
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(reader.GetOrdinal("id_usuari"));
                    string nom = reader.GetString(reader.GetOrdinal("nom"));
                    string cognom = reader.GetString(reader.GetOrdinal("cognom"));
                    string nomUsuari = reader.GetString(reader.GetOrdinal("nomUsuari"));
                    string correu = reader.GetString(reader.GetOrdinal("correu"));
                    string contrasenya = reader.GetString(reader.GetOrdinal("contrasenya"));
                    DateTime dataNaix = reader.GetDateTime(reader.GetOrdinal("dataNaix"));
                    bool modeCreador = reader.GetBoolean(reader.GetOrdinal("modeCreador"));

                    Usuari usuari = new Usuari(id, nom, cognom, nomUsuari, correu, contrasenya, dataNaix, modeCreador);
                    llistaUsuaris.Add(usuari);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error a l'obtenir els usuaris de la BD: " + ex.Message);
            }
            Connexio.Desconnectar();
            return llistaUsuaris;
        }

        /// <summary>
        /// Aquest mètode s'utilitza per modificar les dades d'un usuari existent a la base de dades.
        /// </summary>
        /// <param name="idUsuari">L'ID de l'usuari que es vol modificar.</param>
        /// <param name="nouNom">El nou nom de l'usuari.</param>
        /// <param name="nouCognom">El nou cognom de l'usuari.</param>
        /// <param name="nouNomUsuari">El nou nom d'usuari de l'usuari.</param>
        /// <param name="nouCorreu">El nou correu electrònic de l'usuari.</param>
        /// <param name="novaContrasenya">La nova contrasenya de l'usuari.</param>
        /// <param name="novaDataNaix">La nova data de naixement de l'usuari.</param>
        /// <param name="nouModeCreador">El mode creador (activat/no activat) de l'usuari.</param>
        public void ModificarUsuari(int idUsuari, string nouNom, string nouCognom, string nouNomUsuari, string nouCorreu, string novaContrasenya, DateTime novaDataNaix, bool nouModeCreador)
        {
            try
            {
                string modificarUsuari = $"UPDATE usuaris SET nom = '{nouNom}', cognom = '{nouCognom}', nomUsuari = '{nouNomUsuari}', correu = '{nouCorreu}', contrasenya = '{novaContrasenya}', dataNaix = '{novaDataNaix.ToString("yyyy-MM-dd")}', modeCreador = {(nouModeCreador ? 1 : 0)} WHERE id_usuari = {idUsuari}";
                MySqlCommand command = new MySqlCommand(modificarUsuari, Connexio.Connectar());
                command.ExecuteNonQuery();

                MessageBox.Show("Usuari modificat correctament!");
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
