using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Projet_yassine.Models
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<CategorieProduit> CategorieProduits { get; set; }
        public DbSet<Fournisseur> Fournisseurs { get; set; }
    }
}
