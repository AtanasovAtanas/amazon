namespace Amazon.Server.Features.Categories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Amazon.Server.Data.Models;
    using Amazon.Server.Data.Repositories.Contracts;
    using Amazon.Server.Infrastructure.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;

        public CategoriesService(IDeletableEntityRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public async Task<IEnumerable<TModel>> GetAllAsync<TModel>()
            => await this.categoriesRepository
                .All()
                .To<TModel>()
                .ToListAsync();
    }
}
