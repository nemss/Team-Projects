using Models;

namespace Data
{
    using System.Data.Entity;

    public partial class TheTieSilincerContext : DbContext
    {
        public DbSet<PlayerDbEntity> Players { get; set; }
        public DbSet<Score> Scores { get; set; }

        public TheTieSilincerContext()
            : base("name=TheTieSilincerContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}