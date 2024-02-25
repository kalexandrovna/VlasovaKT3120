using Microsoft.EntityFrameworkCore;
using VlasovaKt.Database.Configuration;
using VlasovaKt.Models;

namespace VlasovaKt.Database
{
    public class VlasovaDbContext : DbContext
    {
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Group> Group { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
        }
        public VlasovaDbContext(DbContextOptions<VlasovaDbContext> options)
            : base(options)
        {
        }
    }
}
