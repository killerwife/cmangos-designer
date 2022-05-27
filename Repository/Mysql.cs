using Config;
using Data;
using Data.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Repository
{
    public class Mysql : DbContext
    {
        protected readonly DatabaseConfig _config;

        public Mysql(DatabaseConfig config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to mysql with connection string from app settings
            options.UseMySql(_config.ConnectionString, ServerVersion.AutoDetect(_config.ConnectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Map entity to table
            modelBuilder.Entity<Dbscripts>().HasNoKey();
            modelBuilder.Entity<EventAIScript>().ToTable("creature_ai_scripts");
        }

        public DbSet<Dbscripts> Dbscripts { get; set; } = null!;
        public DbSet<EventAIScript> EventAIScripts { get; set; } = null!;
    }
}