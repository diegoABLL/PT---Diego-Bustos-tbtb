

using System.ComponentModel.DataAnnotations;

namespace P___Gamestb_App.Models.ViewModels
{
    public class JuegoDesarrolladoraViewModel
    {
        public int JuegoID { get; set; }

        [Required(ErrorMessage = "El nombre del juego es obligatorio")]
        public string Nombre { get; set; }

        [Required]
        [Range(-0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        public decimal Precio { get; set; }

        public int DesarrolladoraID { get; set; }
        
        [Required(ErrorMessage = "El nombre del desarrollador es obligatorio")]
        public string DesarrolladoraNombre { get; set; }

       
    }
}
