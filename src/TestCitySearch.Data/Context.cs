using Microsoft.EntityFrameworkCore;
using TestCitySearch.Models.DBModels;

namespace TestCitySearch.Data.MariaDB
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        { }

        public virtual DbSet<AdddressCity>? AdddressCities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AdddressCity>(b =>
            {
                b.ToTable("address");
            });
        }
    }
}
