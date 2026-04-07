using API_Ecommerce.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_Ecommerce.Data
{
    public class StoreContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }
    }
}
