using Microsoft.EntityFrameworkCore;
using XlationASP.Models;

namespace XlationASP.Data
{
    public class DomainDbContext : DbContext
    {
        public DomainDbContext(DbContextOptions<DomainDbContext> options)
            : base(options)
        {
        }

        public DbSet<Xlator> Xlators { get; set; } = null!;
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<MembershipType> MembershipType { get; set; } = null!;
        public DbSet<Genre> Genre { get; set; } = null!;
    }
}
