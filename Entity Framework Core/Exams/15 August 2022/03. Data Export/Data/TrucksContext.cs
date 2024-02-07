﻿namespace Trucks.Data
{
    using Microsoft.EntityFrameworkCore;
    using Trucks.Data.Models;

    public class TrucksContext:DbContext
    {
        public TrucksContext()
        {
        }

        public TrucksContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<ClientTruck> ClientsTrucks { get; set; }

        public DbSet<Despatcher> Despatchers { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Truck> Trucks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientTruck>(builder =>
            {
                builder.HasKey(ct => new { ct.TruckId,ct.ClientId });
            });
        }
    }
}
