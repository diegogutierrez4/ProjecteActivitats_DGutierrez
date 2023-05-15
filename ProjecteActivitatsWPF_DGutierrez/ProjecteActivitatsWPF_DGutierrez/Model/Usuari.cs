using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjecteActivitatsWPF_DGutierrez.Model
{
    class Usuari
    {
        // Atributs
        private int id;
        private string nom;
        private string cognom;
        private string nomUsuari;
        private string correu;
        private string contrasenya;
        private DateTime dataNaix;
        private bool modeCreador;
        private List<Activitat> llistaActivitats;
        private List<Reserva> llsitaReserves;

        // Constructors
        public Usuari() { }
        public Usuari(int id, string nom, string cognom, string nomUsuari, string correu, string contrasenya, DateTime dataNaix, bool modeCreador, List<Activitat> llistaActivitats, List<Reserva> llsitaReserves)
        {
            this.Id = id;
            this.Nom = nom;
            this.Cognom = cognom;
            this.NomUsuari = nomUsuari;
            this.Correu = correu;
            this.Contrasenya = contrasenya;
            this.DataNaix = dataNaix;
            this.ModeCreador = modeCreador;
            this.LlistaActivitats = llistaActivitats;
            this.LlsitaReserves = llsitaReserves;
        }

        // Propietats
        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Cognom { get => cognom; set => cognom = value; }
        public string NomUsuari { get => nomUsuari; set => nomUsuari = value; }
        public string Correu { get => correu; set => correu = value; }
        public string Contrasenya { get => contrasenya; set => contrasenya = value; }
        public DateTime DataNaix { get => dataNaix; set => dataNaix = value; }
        public bool ModeCreador { get => modeCreador; set => modeCreador = value; }
        internal List<Activitat> LlistaActivitats { get => llistaActivitats; set => llistaActivitats = value; }
        internal List<Reserva> LlsitaReserves { get => llsitaReserves; set => llsitaReserves = value; }
    }
}
