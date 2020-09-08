namespace Amazon.Server
{
    using System.Reflection;

    using Amazon.Server.Data;
    using Amazon.Server.Data.Seeding;
    using Amazon.Server.Infrastructure.Extensions;
    using Amazon.Server.Infrastructure.Mapping;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddDatabase(this.Configuration)
                .AddIdentity()
                .AddJwtAuthentication(services.GetApplicationSettings(this.Configuration))
                .AddApplicationServices()
                .AddSwagger()
                .AddApiControllers();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                using (var serviceScope = app.ApplicationServices.CreateScope())
                {
                    var dbContext = serviceScope
                        .ServiceProvider
                        .GetRequiredService<AmazonDbContext>();

                    dbContext.Database.EnsureDeleted();
                    dbContext.Database.Migrate();

                    new ApplicationDbContextSeeder()
                        .SeedAsync(dbContext, serviceScope.ServiceProvider)
                        .GetAwaiter()
                        .GetResult();
                }
            }

            AutoMapperConfig.RegisterMappings(typeof(Program).GetTypeInfo().Assembly);

            app
                .UseSwaggerUI()
                .UseRouting()
                .UseCors(options => options
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod())
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                })
                .ApplyMigrations();
        }
    }
}
