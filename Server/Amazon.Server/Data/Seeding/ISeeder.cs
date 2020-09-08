namespace Amazon.Server.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    public interface ISeeder
    {
        Task SeedAsync(AmazonDbContext dbContext, IServiceProvider serviceProvider);
    }
}
