using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjecteActivitatsWPF_DGutierrez.Model
{
    public class ConsultaReserva
    {
        //Atributs
        public int IdReserva { get; set; }
        public string Nom { get; set; }
        public string Imatge { get; set; }
        public DateTime DataReserva { get; set; }
        public int NumPersones { get; set; }
        public decimal PreuFinal { get; set; }
    }
}
