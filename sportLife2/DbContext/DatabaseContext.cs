using Microsoft.EntityFrameworkCore;

using sportLife2.DbModel;


namespace sportLife2.Properties.Models
{
    public class DataBaseContext : DbContext
    {

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("PostgreSqlConnectionString");
            optionsBuilder.UseNpgsql(connectionString);
        }

        public DbSet<Pitch> Pitches { get; set; }
        public DbSet<Rezervation> Rezervations { get; set; }
        public DbSet<Session> Sessions { get; set; }
    }
}
