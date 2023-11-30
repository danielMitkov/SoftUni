﻿using Microsoft.EntityFrameworkCore;
using P02_FootballBetting.Data.Models;

namespace P02_FootballBetting.Data;

public class FootballBettingContext:DbContext
{
    public FootballBettingContext()
    {

    }
    public FootballBettingContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Team> Teams { get; set; } = null!;
    public DbSet<Color> Colors { get; set; } = null!;
    public DbSet<Town> Towns { get; set; } = null!;
    public DbSet<Country> Countries { get; set; } = null!;
    public DbSet<Player> Players { get; set; } = null!;
    public DbSet<Position> Positions { get; set; } = null!;
    public DbSet<PlayerStatistic> PlayersStatistics { get; set; } = null!;
    public DbSet<Game> Games { get; set; } = null!;
    public DbSet<Bet> Bets { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(@"Server=DANIEL\MSSQLSERVER01;Database=FootballBetting;Integrated Security=true;TrustServerCertificate=True;");
        }
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PlayerStatistic>(entity =>
        {
            entity.HasKey(ps => new { ps.GameId,ps.PlayerId });
        });
    }
}
