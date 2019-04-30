using Microsoft.EntityFrameworkCore;

namespace SwWebServiceRabbit.Web.Data
{
    public class ToonContext : DbContext
    {
        private readonly string _connectionString;

        public ToonContext(string connectionString)
            : base()
        {
            _connectionString = connectionString;
        }

        public ToonContext(DbContextOptions<ToonContext> options)
            : base(options)
        {
        }

        public DbSet<Toon> Toons { get; set; }

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
