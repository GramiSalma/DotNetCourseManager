using DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class MyDbContext : DbContext
    {

        public DbSet<Categorie> Categories { get; set; }

        public DbSet<Cours> Cours { get; set; }
        public DbSet<Commentaire> Commentaire { get; set; }
        public DbSet<Admin> Admins { get; set; }


        protected override void OnConfiguring
                (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                (@"Data Source=DESKTOP-2J09NM6;Initial Catalog=miniprojetdotnet1;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");
        }
     

            
    }
}

