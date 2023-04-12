﻿using Microsoft.EntityFrameworkCore;
using products_catalogue.Domain.Models;
using products_catalogue.Infrastructure.Data.Seeders;
using System.Configuration;

namespace products_catalogue.Infrastructure.DbContexts
{
    public class SqlServerContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["SqlServer2017_dev_docker"].ConnectionString;
            //TODO: connection
            optionsBuilder.EnableSensitiveDataLogging();
        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany<Product>(p => p.Products);

            modelBuilder.Seed();
        }
    }
}