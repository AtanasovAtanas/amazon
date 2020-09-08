namespace Amazon.Server.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using Amazon.Server.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class UserSeeder : ISeeder
    {
        public async Task SeedAsync(AmazonDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            var users = new[]
            {
                new User
                {
                    Email = "a.atanasov@gmail.com",
                    UserName = "AtanasAtanasov",
                },
                new User
                {
                    Email = "a.sarambelieva@gmail.com",
                    UserName = "AnnaSarambelieva",
                },
            };

            foreach (var user in users)
            {
                var result = await userManager
                    .CreateAsync(
                        user,
                        "123456");

                if (!result.Succeeded)
                {
                    throw new InvalidOperationException(
                        string.Join(
                            Environment.NewLine,
                            result.Errors));
                }
            }
        }
    }
}
