using CitiesApi.DAL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CitiesApi.DAL
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<DatabaseContext> _logger;

        public DatabaseContext(DbContextOptions options, IConfiguration configuration, ILogger<DatabaseContext> logger)
            : base(options)
        {
            _configuration = configuration;
            _logger = logger;

            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        public DbSet<City> Cities { get; set; }

        public Task<IDbContextTransaction> BeginTransaction(IsolationLevel isolationLevel)
        {
            return Database.BeginTransactionAsync(isolationLevel);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {
                var cityList = GetCitiesFromFile();
                modelBuilder.Entity<City>().HasData(cityList.Select((c, i) => new City { Id = i + 1, Name = c }));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initializing the database from file.");
            }
            base.OnModelCreating(modelBuilder);
        }

        private IEnumerable<string> GetCitiesFromFile()
        {
            var filePath = _configuration["citiesInitFilePath"];
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
                throw new InvalidOperationException("File path is invalid. Value: " + filePath);

            return File.ReadLines(filePath);
        }
    }
}
