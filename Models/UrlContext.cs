namespace UrlShort.Models {
    using Microsoft.EntityFrameworkCore;

    public class UrlContext : DbContext {
        public UrlContext(DbContextOptions<UrlContext> options) : base(options) { }

        public DbSet<Url> Urls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder
                .Entity<Url>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
