using Microsoft.EntityFrameworkCore;
using proiectMP.Models;

namespace proiectMP.Data
{
    public class proiectMPContext : DbContext
    {
        public proiectMPContext(DbContextOptions<proiectMPContext> options)
            : base(options)
        {
        }

        public DbSet<proiectMP.Models.Product> Product { get; set; } = default!;

        public DbSet<proiectMP.Models.Ingredient> Ingredient { get; set; } = default!;

        public DbSet<proiectMP.Models.Allergen> Allergen { get; set; } = default!;

        public DbSet<proiectMP.Models.Category> Category { get; set; } = default!;

        public DbSet<proiectMP.Models.Client> Client { get; set; } = default!;

        public DbSet<proiectMP.Models.Comment> Comment { get; set; } = default!;

        public DbSet<proiectMP.Models.Reservation> Reservation { get; set; } = default!;
    }
}
