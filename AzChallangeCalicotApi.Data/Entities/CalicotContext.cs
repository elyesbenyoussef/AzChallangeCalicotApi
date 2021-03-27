using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace AzChallangeCalicotApi.Data.Entities
{
    public partial class CalicotContext : DbContext
    {
        private DbContextOptions<CalicotContext> dbContextOptions;

        public CalicotContext(DbContextOptions<CalicotContext> dbContextOptions, IConfiguration configuration = null) : base(dbContextOptions)
        {
            if (configuration != null && configuration.GetValue<bool>("GetToken"))
            {
                var conn = (SqlConnection)Database.GetDbConnection();
                conn.AccessToken = GetToken(configuration).Result;
            }
        }

        public virtual DbSet<Produit> Produit { get; set; }
        public virtual DbSet<Image> Image { get; set; }

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

                entity.Property(e => e.DateHeureCreation).HasColumnType("datetime")
                .HasDefaultValueSql("(GETDATE())");

                entity.Property(e => e.DateHeureModification).HasColumnType("datetime");

                entity.Property(e => e.DateHeureSuppression).HasColumnType("datetime");

                entity.Property(e => e.NumeroUniqueGUID)
                    .HasColumnName("NumeroUniqueGUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.UsagerCreation)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValue("defaultuser");

                entity.Property(e => e.UsagerModification).HasMaxLength(128);

                entity.Property(e => e.UsagerSuppression).HasMaxLength(128);
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("Image");

                entity.Property(e => e.ImageId).HasColumnName("ImageId");

                entity.Property(e => e.ProduitId).HasColumnName("ProductId");

                entity.Property(e => e.DateHeureCreation).HasColumnType("datetime")
                .HasDefaultValueSql("(GETDATE())");

                entity.Property(e => e.DateHeureModification).HasColumnType("datetime");

                entity.Property(e => e.DateHeureSuppression).HasColumnType("datetime");

                entity.Property(e => e.NumeroUniqueGUID)
                    .HasColumnName("NumeroUniqueGUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.UsagerCreation)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValue("defaultuser");

                entity.Property(e => e.UsagerModification).HasMaxLength(128);

                entity.Property(e => e.UsagerSuppression).HasMaxLength(128);

                entity.HasOne(p => p.Produit)
                .WithMany(i => i.Images)
                .HasForeignKey(c => c.ProduitId)
                .HasConstraintName("FK_ImageProduit");
            });
        }

        internal async Task<string> GetToken(IConfiguration configuration)
        {
            string userIdentity = configuration.GetValue<string>("UserAssignedIdentity");
            return await new AzureServiceTokenProvider($"RunAs=App;AppId={userIdentity}").GetAccessTokenAsync(
                "https://database.windows.net/");
        }
    }
}
