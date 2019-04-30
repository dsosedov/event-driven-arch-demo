using Microsoft.EntityFrameworkCore;

namespace JediWebSerivce.Web.Data
{
    public class JediContext : DbContext
    {
        private readonly string _connectionString;

        public JediContext(string connectionString)
            : base()
        {
            _connectionString = connectionString;
        }

        public JediContext(DbContextOptions<JediContext> options)
            : base(options)
        {
        }

        public DbSet<Jedi> Jedis { get; set; }

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
