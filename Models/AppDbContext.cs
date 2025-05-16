using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace projectoFinalV2.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Film> Films { get; set; }
        public DbSet<People> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Converter genérico JSON <-> List<string>
            var listToJsonConverter = new ValueConverter<List<string>, string>(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<string>>(v) ?? new List<string>());

            // Aplica la conversión a las propiedades que son List<string>
            modelBuilder.Entity<Film>()
                .Property(f => f.people)
                .HasConversion(listToJsonConverter);
            
            modelBuilder.Entity<Film>()
                .Property(f => f.species)
                .HasConversion(listToJsonConverter);

            modelBuilder.Entity<Film>()
                .Property(f => f.locations)
                .HasConversion(listToJsonConverter);

            modelBuilder.Entity<Film>()
                .Property(f => f.vehicles)
                .HasConversion(listToJsonConverter);

            modelBuilder.Entity<People>()
                .Property(p => p.films)
                .HasConversion(listToJsonConverter);
        }
    }
}
