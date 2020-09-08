﻿namespace Amazon.Server.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ApplicationDbContextSeeder : ISeeder
    {
        public async Task SeedAsync(AmazonDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            var seeders = new List<ISeeder>
            {
                new UserSeeder(),
            };

            foreach (var seeder in seeders)
            {
                await seeder.SeedAsync(dbContext, serviceProvider);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
