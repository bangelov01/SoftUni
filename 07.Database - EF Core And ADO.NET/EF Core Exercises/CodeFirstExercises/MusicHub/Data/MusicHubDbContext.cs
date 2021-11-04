namespace MusicHub.Data
{
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Models;

    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        {
        }

        public MusicHubDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<Writer> Writers { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }
        public virtual DbSet<Performer> Performers { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<SongPerformer> SongsPerformers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }

            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SongPerformer>(spe =>
            {
                spe.HasKey(sp => new { sp.SongId, sp.PerformerId });

                spe.HasOne(sp => sp.Song)
                .WithMany(s => s.SongPerformers)
                .HasForeignKey(sp => sp.SongId)
                .OnDelete(DeleteBehavior.Restrict);

                spe.HasOne(sp => sp.Performer)
                .WithMany(p => p.PerformerSongs)
                .HasForeignKey(sp => sp.PerformerId)
                .OnDelete(DeleteBehavior.Restrict);
            });              
        }
    }
}
