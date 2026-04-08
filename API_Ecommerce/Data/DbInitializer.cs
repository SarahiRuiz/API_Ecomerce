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
                    PictureUrl = "https://www.minecraft.net/content/dam/minecraftnet/franchise/logos/Homepage_Download-Launcher_Creeper-Logo-Takeover_500x500.png",
                    Type = "Type X"
                },
                new Product
                {
                    Name = "Product Sara",
                    Description = "Description for product 2",
                    Price = 20.99m,
                    PictureUrl = "https://assets.tmecosys.com/image/upload/t_web_rdp_recipe_584x480_1_5x/img/recipe/ras/Assets/2F60018A-7D11-48CA-BB83-B32497E02BF5/Derivates/bc77ea56-073d-4648-82a4-0782bbf1d37c.jpg",
                    Type = "Type Y"
                },
                // Add more products as needed
            };
            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
