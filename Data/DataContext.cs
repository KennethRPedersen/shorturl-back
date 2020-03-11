using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LenesKlinik.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UrlRelation>()
                .HasKey(rel => rel.Id);
        }

        public DbSet<UrlRelation> Url { get; set; }
    }
}