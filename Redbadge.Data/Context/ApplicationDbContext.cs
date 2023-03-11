using Microsoft.EntityFrameworkCore;
using Redbadge.Data.Entities;

namespace Redbadge.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<GameEntity> Game { get; set; }
        public DbSet<OccasionEntity> Occasion { get; set; }
        public DbSet<PlayerEntity> Player { get; set; }
        public DbSet<RankEntity> Rank { get; set; }
        public DbSet<IndividualResultsEntity> IndividualResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<GameEntity>().HasData(
                new GameEntity
                {
                    Id = 1,
                    Name = "Rock, Paper, Scissors"
                },
                new GameEntity
                {
                    Id = 2,
                    Name = "Mario Kart 8"
                },
                new GameEntity
                {
                    Id = 3,
                    Name = "Jenga"
                },
                new GameEntity
                {
                    Id = 4,
                    Name = "Pool"
                },
                new GameEntity
                {
                    Id = 5,
                    Name = "Odd Ball, Halo Infinite"
                }
            );
        }
    }
}