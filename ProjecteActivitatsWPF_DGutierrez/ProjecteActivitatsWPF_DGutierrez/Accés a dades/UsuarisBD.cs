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
