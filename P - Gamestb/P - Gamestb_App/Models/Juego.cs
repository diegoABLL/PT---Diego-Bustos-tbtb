using System.ComponentModel.DataAnnotations;

namespace P___Gamestb_App.Models
{
    public class Juego
    {


        [Key] public int JuegoID { get; set; }

        public string Nombre { get; set; }

        public decimal Precio { get; set; }

        public int DesarrolladoraID { get; set; }

        public Desarrolladora Desarrolladora { get; set; }
        public Juego()
        {

        }




    }
}
