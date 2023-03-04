﻿using Microsoft.EntityFrameworkCore;
using Redbadge.Data.Entities;

namespace Redbadge.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<GameEntity> Game { get; set; }
        public DbSet<OccasionEntity> Occasion { get; set; }
        public DbSet<PlayerEntity> Player { get; set; }
        public DbSet<Rank> Rank { get; set; }
        public DbSet<IndividualResults> IndividualResults { get; set; }
    }
}