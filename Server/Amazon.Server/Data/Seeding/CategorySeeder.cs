namespace Amazon.Server.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Amazon.Server.Data.Models;

    public class CategorySeeder : ISeeder
    {
        public async Task SeedAsync(AmazonDbContext dbContext, IServiceProvider serviceProvider)
        {
            var categoryNames = new[]
            {
                "All Departments",
                "Alexa Skills",
                "Amazon Devices",
                "Amazon Global Store",
                "Amazon Warehouse",
                "Apps &amp; Games",
                "Audible Audiobooks",
                "Baby",
                "Beauty",
                "Books",
                "Car &amp; Motorbike",
                "CDs &amp; Vinyl",
                "Classical Music",
                "Clothing",
                "Computers &amp; Accessories",
                "Digital Music ",
                "DIY &amp; Tools",
                "DVD &amp; Blu-ray",
                "Electronics &amp; Photo",
                "Fashion",
                "Garden &amp; Outdoors",
                "Gift Cards",
                "Grocery",
                "Handmade",
                "Health &amp; Personal Care",
                "Home &amp; Business Services",
                "Home &amp; Kitchen",
                "Industrial &amp; Scientific",
                "Jewellery",
                "Kindle Store",
                "Large Appliances",
                "Lighting",
                "Luggage",
                "Musical Instruments &amp; DJ Equipment",
                "PC &amp; Video Games",
                "Pet Supplies",
                "Premium Beauty",
                "Prime Video",
                "Shoes &amp; Bags",
                "Software",
                "Sports &amp; Outdoors",
                "Stationery &amp; Office Supplies",
                "Toys &amp; Games",
                "Watches",
            };

            var categories = categoryNames
                .Select(categoryName =>
                    new Category
                    {
                        Name = categoryName,
                    })
                .ToList();

            await dbContext.Categories.AddRangeAsync(categories);
            await dbContext.SaveChangesAsync();
        }
    }
}
