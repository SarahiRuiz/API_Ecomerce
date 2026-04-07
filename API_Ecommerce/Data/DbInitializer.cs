using API_Ecommerce.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_Ecommerce.Data
{
    public class DbInitializer
    {
        public static void InitDb(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<StoreContext>()
                ?? throw new InvalidOperationException("Failed to retrieve store context");
            SeedData(context);
        }
        //adding dummy data to the database
        private static void SeedData(StoreContext context)
        {
            //restart the database and apply any pending migrations
            context.Database.Migrate();
            if(context.Products.Any()) return;

            var products = new List<Product>
            {
                new Product
                {
                    Name = "Product Ale",
                    Description = "Description for product 1",
                    Price = 10.99m,
                    PictureUrl = "https://example.com/product1.jpg",
                    Brand = "Brand A",
                    Type = "Type X"
                },
                new Product
                {
                    Name = "Product Sara",
                    Description = "Description for product 2",
                    Price = 20.99m,
                    PictureUrl = "https://example.com/product2.jpg",
                    Brand = "Brand B",
                    Type = "Type Y"
                },
                // Add more products as needed
            };
            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
