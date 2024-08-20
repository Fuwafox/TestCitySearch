using Microsoft.EntityFrameworkCore;
using TestCitySearch.Models.DBModels;

namespace TestCitySearch.Data.MariaDB.EF
{
    /// <summary>
    /// Подключение к базе данных и создание таблицы
    /// </summary>
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options) => Database.EnsureCreated();

        // public virtual DbSet<AdddressCity>? AdddressCities { get; set; }
        public DbSet<AddressCity> AddressCitys => Set<AddressCity>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AddressCity>(b =>
            {
                b.ToTable("address");
            });
        }
    }
}
