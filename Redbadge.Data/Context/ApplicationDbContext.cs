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
        public DbSet<IndividualResultEntity> IndividualResult { get; set; }

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

            modelBuilder.Entity<PlayerEntity>().HasData(
                new PlayerEntity
                {
                    Id = 1,
                    Name = "John"
                },
                new PlayerEntity
                {
                    Id = 2,
                    Name = "Michael"
                },
                new PlayerEntity
                {
                    Id = 3,
                    Name = "Khadir"
                },
                new PlayerEntity
                {
                    Id = 4,
                    Name = "Bryan"
                },
                new PlayerEntity
                {
                    Id = 5,
                    Name = "Thomas"
                }
            );

            modelBuilder.Entity<OccasionEntity>().HasData(
                    new OccasionEntity
                    {
                        Id = 1,
                        Name = "Bryan's Bachelor Party",
                        DateTime = DateTime.Now                 
                    },
                    new OccasionEntity
                    {
                        Id = 2,
                        Name = "That one time at Kyle's house",
                        DateTime = DateTime.Now

                    },
                    new OccasionEntity
                    {
                        Id = 3,
                        Name = "August 13th, 1998",
                        DateTime = DateTime.Now
                    },
                    new OccasionEntity
                    {
                        Id = 4,
                        Name = "2004 Xmas Party",
                        DateTime = DateTime.Now

                    },
                    new OccasionEntity
                    {
                        Id = 5,
                        Name = "07/04/2021",
                        DateTime = DateTime.Now
                    }
            );

            modelBuilder.Entity<RankEntity>().HasData(
                new RankEntity
                {
                    Id = 1,
                    RankName = "Winner"
                },
                new RankEntity
                {
                    Id = 2,
                    RankName = "Loser"
                },
                new RankEntity
                {
                    Id = 3,
                    RankName = "Gold"
                },
                new RankEntity
                {
                    Id = 4,
                    RankName = "Silver"
                },
                new RankEntity
                {
                    Id = 5,
                    RankName = "Bronze"
                }
            );
        }
    }
}