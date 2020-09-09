namespace Amazon.Server.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Amazon.Server.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class ProductSeeder : ISeeder
    {
        public async Task SeedAsync(AmazonDbContext dbContext, IServiceProvider serviceProvider)
        {
            var categories = await dbContext
                .Categories
                .Select(c => c.Id)
                .ToListAsync();

            var userId = await dbContext
                .Users
                .Select(u => u.Id)
                .FirstOrDefaultAsync();

            var products = new List<Product>();
            var random = new Random();

            for (int i = 0; i < 100; i++)
            {
                var product = new Product
                {
                    Title = "Oculus Rift S PC-Powered VR Gaming Headset",
                    About = @"Ships from and sold by Amazon.com.
                    Top VR gaming library: Blast, slash and soar your way through the top library in VR gaming. Oculus Rift S lets you play hundreds of games and exclusives already available in the Oculus store, with so much more to come.
                    Improved optics: Stare down the competition with next-generation lenses and a sharper display.Improved optics deliver bright, vivid colors and reduced “screen - door” effect.
                    Ergonomic design: keep your head in the game thanks to a Halo headband redesigned with speed in mind.Rift S stays securely and comfortably in place with a quick twist of the Fit wheel, so it can take-or double take-your fastest reactions.
                    Oculus touch controllers: arm yourself with our updated Oculus touch controllers. Your slashes, throws and grab appear in VR with intuitive, realistic Precision, transporting your hands and gestures right into the game.
                    Oculus insight tracking: take a step forward with Oculus insight.It translates your movements into VR No matter which way you're facing and provides room-scale tracking without external Sensors.
                    ",
                    CategoryId = categories[random.Next(categories.Count)],
                    Pictures = new HashSet<Picture>
                    {
                        new Picture
                        {
                            ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/71URNvzoWqL._SL1500_.jpg",
                        },
                        new Picture
                        {
                            ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/71rKrBA2eDL._SL1500_.jpg",
                        },
                        new Picture
                        {
                            ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/716-fayZAQL._SL1500_.jpg",
                        },
                        new Picture
                        {
                            ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/71byGcUN9iL._SL1500_.jpg",
                        },
                    },
                    Price = 399.99M,
                    SellerId = userId,
                };

                products.Add(product);
            }

            await dbContext.Products.AddRangeAsync(products);
            await dbContext.SaveChangesAsync();
        }
    }
}
