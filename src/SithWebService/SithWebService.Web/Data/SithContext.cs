using Microsoft.EntityFrameworkCore;

namespace SithWebService.Web.Data
{
    public class SithContext : DbContext
    {
        private readonly string _connectionString;

        public SithContext(string connectionString)
            : base()
        {
            _connectionString = connectionString;
        }

        public SithContext(DbContextOptions<SithContext> options)
            : base(options)
        {
        }

        public DbSet<Sith> Siths { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrWhiteSpace(_connectionString))
            {
                optionsBuilder.UseSqlite(_connectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        public void Seed()
        {
        }
    }
}
