namespace Gare
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GareContest : DbContext
    {
        public GareContest()
            : base("name=GareContest")
        {
        }

        public virtual DbSet<CodePostal> CodePostals { get; set; }
        public virtual DbSet<Gare> Gares { get; set; }
        public virtual DbSet<Ligne> Lignes { get; set; }
        public virtual DbSet<Nature> Natures { get; set; }
        public virtual DbSet<Ville> Villes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gare>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<Gare>()
                .Property(e => e.wgs84)
                .IsUnicode(false);

            modelBuilder.Entity<Gare>()
                .HasMany(e => e.Natures)
                .WithMany(e => e.Gares)
                .Map(m => m.ToTable("dessert").MapLeftKey("IdGare").MapRightKey("IDnature"));

         
            modelBuilder.Entity<Ligne>()
                .HasMany(e => e.Gares)
                .WithMany(e => e.Lignes)
                .Map(m => m.ToTable("opere").MapLeftKey("CodeLigne").MapRightKey("IdGare"));

            modelBuilder.Entity<Nature>()
                .Property(e => e.nomNature)
                .IsUnicode(false);

            modelBuilder.Entity<Ville>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<Ville>()
                .HasMany(e => e.CodePostals)
                .WithRequired(e => e.Ville)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ville>()
                .HasMany(e => e.Gares)
                .WithRequired(e => e.Ville)
                .WillCascadeOnDelete(false);
        }
    }
}
