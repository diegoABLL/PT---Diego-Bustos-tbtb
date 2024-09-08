using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using P___Gamestb_App.Models;

namespace P___Gamestb_App.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<P___Gamestb_App.Models.Juego> Juego { get; set; } = default!;
        public DbSet<P___Gamestb_App.Models.Desarrolladora> Desarrolladora { get; set; } = default!;

        //public DbSet<P___Gamestb_App.Models.ViewModels.JuegoDesarrolladoraViewModel> JuegoDesarrolladora { get; set; } = default!;
    }
}
