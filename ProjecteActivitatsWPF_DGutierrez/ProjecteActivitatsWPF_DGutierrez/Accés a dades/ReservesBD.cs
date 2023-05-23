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
        public void AfegirReserva(int usuariReserva, int activitat, DateTime dataReserva, int numPersones, decimal preuFinal)
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
                    // Insertar la taula 'reserves'
                    string registrarReserva = "INSERT INTO reserves (usuariReserva, activitat, dataReserva, numPersones, preuFinal) VALUES (@usuariReserva, @activitat, @dataReserva, @numPersones, @preuFinal)";
                    command.CommandText = registrarReserva;

                    command.Parameters.AddWithValue("@usuariReserva", usuariReserva);
                    command.Parameters.AddWithValue("@activitat", activitat);
                    command.Parameters.AddWithValue("@dataReserva", dataReserva);
                    command.Parameters.AddWithValue("@numPersones", numPersones);
                    command.Parameters.AddWithValue("@preuFinal", preuFinal);

                    command.ExecuteNonQuery();

                    // Obtener ID de la reserva insertada anteriorment
                    int idReserva = (int)command.LastInsertedId;

                    // Insertar a la taula 'usuari_activitat'
                    string registrarUsuariReserva = $"INSERT INTO usuari_reserva (usuari_id, reserva_id) VALUES ({usuariReserva}, {idReserva})";
                    command.CommandText = registrarUsuariReserva;
                    command.ExecuteNonQuery();

                    // Confirmar la transaction
                    transaction.Commit();

                    MessageBox.Show("Enhorabona, activitat reservada correctament!");
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
    }
}
