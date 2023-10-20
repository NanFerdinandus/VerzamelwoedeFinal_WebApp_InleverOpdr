using Microsoft.EntityFrameworkCore;
using WebApp_TestApp_W3_InlvrOpdr.Models;

namespace WebApp_TestApp_W3_InlvrOpdr.Models
{
    public class AppDBContext : DbContext
    {
        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Postzegel> Postzegels { get; set; }
        public DbSet<Categorie> Categorieën { get; set; }
        public DbSet<Favoriet> Favorieten { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gebruiker>()
                .HasMany(gebruiker => gebruiker.Postzegels)
                .WithOne(postzegel => postzegel.Eigenaar)
                .IsRequired();

            modelBuilder.Entity<Favoriet>() // Veranderd naar Favoriet
                .HasOne(favoriet => favoriet.Eigenaar)  // Favoriet heeft één Eigenaar
                .WithMany(gebruiker => gebruiker.Favorieten)  // Een gebruiker heeft veel favorieten
                .HasForeignKey(favoriet => favoriet.GebruikerId) // GebruikerId wordt gebruikt als foreign key
                .IsRequired(); // De relatie is vereist

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<WebApp_TestApp_W3_InlvrOpdr.Models.Forum> Forum { get; set; } = default!;

        public DbSet<WebApp_TestApp_W3_InlvrOpdr.Models.Bericht> Bericht { get; set; } = default!;
    }
}
