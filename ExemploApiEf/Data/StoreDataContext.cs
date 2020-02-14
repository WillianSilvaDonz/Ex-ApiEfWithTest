using Microsoft.EntityFrameworkCore;
using Store.Data.Maps;
using Store.Models;

namespace Store.Data
{
    public class StoreDataContext: DbContext
    {
        public StoreDataContext(){}

        public StoreDataContext(DbContextOptions<StoreDataContext> options):base(options){}

        public DbSet<Product> Products {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseInMemoryDatabase("Teste");
        }

        protected override void OnModelCreating(ModelBuilder builder){
            builder.ApplyConfiguration(new ProductMap());
        }
    }
}