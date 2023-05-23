using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ProjecteActivitatsWPF_DGutierrez.Model
{
    public enum Categoria
    {
        EsportsExtrems,
        Cultural,
        Gastronòmica,
        Ecoturisme
    }
    public class Activitat
    {
        // Atributs
        private int id;
        private string nom;
        private string descripcio;
        private string ubicacio;
        private Categoria categoria;
        private string durada;
        private decimal preu;
        private int usuariCreador;
        private string imatge;

        // Constructors
        public Activitat() { }
        public Activitat(int id, string nom, string descripcio, string ubicacio, Categoria categoria, string durada, decimal preu, int usuariCreador, string imatge)
        {
            this.Id = id;
            this.Nom = nom;
            this.Descripcio = descripcio;
            this.Ubicacio = ubicacio;
            this.Categoria = categoria;
            this.Durada = durada;
            this.Preu = preu;
            this.UsuariCreador = usuariCreador;
            this.Imatge = imatge;
        }

        // Propietats
        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Descripcio { get => descripcio; set => descripcio = value; }
        public string Ubicacio { get => ubicacio; set => ubicacio = value; }
        public string Durada { get => durada; set => durada = value; }
        public decimal Preu { get => preu; set => preu = value; }
        public Categoria Categoria { get => categoria; set => categoria = value; }
        public int UsuariCreador { get => usuariCreador; set => usuariCreador = value; }
        public string Imatge { get => imatge; set => imatge = value; }
    }
}
