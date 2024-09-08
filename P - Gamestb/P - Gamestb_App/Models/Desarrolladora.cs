using System.ComponentModel.DataAnnotations;

namespace P___Gamestb_App.Models
{
    public class Desarrolladora
    {

        [Key] public int DesarrolladoraID { get; set; }
        public String Nombre { get; set; }

        public ICollection<Juego> Juegos { get; set; }

        public Desarrolladora()
        {
            
        }
    }

    
}
