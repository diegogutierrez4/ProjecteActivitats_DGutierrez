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
    class ReservesBD
    {
        // Atributs
        private ConnexioBD connexio;

        // Constructors
        public ReservesBD(ConnexioBD connexio)
        {
            this.connexio = connexio;
        }

        // Propietats
        public ConnexioBD Connexio { get => connexio; set => connexio = value; }

        // Mètodes

        /// <summary>
        /// Aquest mètode s'utilitza per afegir una reserva a la base de dades.
        /// </summary>
        /// <param name="usuariReserva">L'ID de l'usuari que fa la reserva.</param>
        /// <param name="activitat">L'ID de l'activitat reservada.</param>
        /// <param name="dataReserva">La data de la reserva.</param>
        /// <param name="numPersones">El nombre de persones per a la reserva.</param>
        /// <param name="preuFinal">El preu final de la reserva.</param>
        public void AfegirReserva(int usuariReserva, int activitat, DateTime dataReserva, int numPersones, decimal preuFinal)
        {
            try
            {
                // Insertar la taula 'reserves'
                string registrarReserva = "INSERT INTO reserves (usuariReserva, activitat, dataReserva, numPersones, preuFinal) VALUES (@usuariReserva, @activitat, @dataReserva, @numPersones, @preuFinal)";
                MySqlCommand command = new MySqlCommand(registrarReserva, Connexio.Connectar());

                command.Parameters.AddWithValue("@usuariReserva", usuariReserva);
                command.Parameters.AddWithValue("@activitat", activitat);
                command.Parameters.AddWithValue("@dataReserva", dataReserva);
                command.Parameters.AddWithValue("@numPersones", numPersones);
                command.Parameters.AddWithValue("@preuFinal", preuFinal);

                command.ExecuteNonQuery();

                MessageBox.Show("Enhorabona, activitat reservada correctament!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error a l'obrir la BD: " + ex.Message);
            }
            Connexio.Desconnectar();
        }

        /// <summary>
        ///  Aquest mètode s'utilitza per obtenir totes les reserves des de la base de dades.
        /// </summary>
        /// <returns>Una llista de reserves que conté les dades de cada reserva.</returns>
        public List<Reserva> ObtenirReserves()
        {
            List<Reserva> llistaReserves = new List<Reserva>();

            try
            {
                string obtenirReserves = "SELECT * FROM reserves";
                MySqlCommand command = new MySqlCommand(obtenirReserves, Connexio.Connectar());
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32("id_reserva");
                    int usuariReserva = reader.GetInt32("usuariReserva");
                    int activitat = reader.GetInt32("activitat");
                    DateTime dataReserva = reader.GetDateTime("dataReserva");
                    int numPersones = reader.GetInt32("numPersones");
                    decimal preuFinal = reader.GetDecimal("preuFinal");

                    Reserva reserva = new Reserva(id, usuariReserva, activitat, dataReserva, numPersones, preuFinal);
                    llistaReserves.Add(reserva);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error a l'obtenir les reserves de la BD: " + ex.Message);
            }
            Connexio.Desconnectar();
            return llistaReserves;
        }

        /// <summary>
        /// Aquest mètode s'utilitza per obtenir les reserves d'un usuari des de la base de dades.
        /// </summary>
        /// <param name="usuariId">L'ID de l'usuari per al qual es volen obtenir les reserves.</param>
        /// <returns>Una llista de ConsultaReserva que conté les dades de cada reserva de l'usuari.</returns>
        public List<ConsultaReserva> ObtenirReservesUsuari(int usuariId)
        {
            List<ConsultaReserva> llistaReserves = new List<ConsultaReserva>();

            try
            {
                string obtenirReserves = $"SELECT a.nom, a.imatge, r.id_reserva, r.dataReserva, r.numPersones, r.preuFinal FROM reserves r " +
                    $"JOIN activitats a ON r.activitat = a.id_activitat WHERE r.usuariReserva = {usuariId}";
                MySqlCommand command = new MySqlCommand(obtenirReserves, Connexio.Connectar());
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ConsultaReserva consultaReserva = new ConsultaReserva();

                    consultaReserva.Nom = reader.GetString("nom");
                    consultaReserva.Imatge = reader.GetString("imatge");
                    consultaReserva.IdReserva = reader.GetInt32("id_reserva");
                    consultaReserva.DataReserva = reader.GetDateTime("dataReserva").Date;
                    consultaReserva.NumPersones = reader.GetInt32("numPersones");
                    consultaReserva.PreuFinal = reader.GetDecimal("preuFinal");

                    llistaReserves.Add(consultaReserva);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error a l'obtenir les reserves de la BD: " + ex.Message);
            }
            Connexio.Desconnectar();
            return llistaReserves;
        }

        /// <summary>
        /// Aquest mètode s'utilitza per eliminar una reserva de la base de dades.
        /// </summary>
        /// <param name="idReserva">L'ID de la reserva a eliminar.</param>
        public void EliminarReserva(int idReserva)
        {
            try
            {
                string eliminarReserva = $"DELETE FROM reserves WHERE id_reserva = {idReserva}";
                MySqlCommand command = new MySqlCommand(eliminarReserva, Connexio.Connectar());
                MySqlDataReader reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error a l'obtenir les reserves de la BD: " + ex.Message);
            }
            Connexio.Desconnectar();
        }
    }
}
