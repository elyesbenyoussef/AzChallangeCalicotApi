using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace AzChallangeCalicotApi.Data.Entities
{
    public partial class CalicotContext : DbContext
    {
        private DbContextOptions<CalicotContext> dbContextOptions;

        public CalicotContext(DbContextOptions<CalicotContext> dbContextOptions)
        {
            this.dbContextOptions = dbContextOptions;
        }

        public virtual DbSet<Produit> Produit { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:azchallengesql.database.windows.net,1433;Initial Catalog=calicot;Persist Security Info=False;User ID=CalicotUser;Password=Calicot001;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produit>(entity =>
            {
                entity.ToTable("Produit");

                entity.Property(e => e.ProduitId).HasColumnName("ProductId");

                entity.Property(e => e.DateHeureCreation).HasColumnType("datetime");

                entity.Property(e => e.DateHeureModification).HasColumnType("datetime");

                entity.Property(e => e.DateHeureSuppression).HasColumnType("datetime");

                entity.Property(e => e.NumeroUniqueGUID)
                    .HasColumnName("NumeroUniqueGUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.UsagerCreation)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.UsagerModification).HasMaxLength(128);

                entity.Property(e => e.UsagerSuppression).HasMaxLength(128);
            });
        }
    }
}
