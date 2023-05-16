using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjecteActivitatsWPF_DGutierrez.Model
{
    public class Reserva
    {
        // Atributs
        private int id;
        private Usuari usuariReserva;
        private Activitat activitat;
        private DateTime dataReserva;
        private int numPersones;
        private decimal preuFinal;

        // Constructors
        public Reserva() { }
        public Reserva(int id, Usuari usuariReserva, Activitat activitat, DateTime dataReserva, int numPersones, decimal preuFinal)
        {
            this.Id = id;
            this.UsuariReserva = usuariReserva;
            this.Activitat = activitat;
            this.DataReserva = dataReserva;
            this.NumPersones = numPersones;
            this.PreuFinal = preuFinal;
        }

        // Propietats
        public int Id { get => id; set => id = value; }
        public DateTime DataReserva { get => dataReserva; set => dataReserva = value; }
        public int NumPersones { get => numPersones; set => numPersones = value; }
        public decimal PreuFinal { get => preuFinal; set => preuFinal = value; }
        public Usuari UsuariReserva { get => usuariReserva; set => usuariReserva = value; }
        public Activitat Activitat { get => activitat; set => activitat = value; }
    }
}
