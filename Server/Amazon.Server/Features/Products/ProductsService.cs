namespace Amazon.Server.Features.Products
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Amazon.Server.Data.Models;
    using Amazon.Server.Data.Repositories.Contracts;
    using Amazon.Server.Infrastructure.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class ProductsService : IProductsService
    {
        private readonly IDeletableEntityRepository<Product> productsRepository;

        public ProductsService(IDeletableEntityRepository<Product> productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public async Task<IEnumerable<TModel>> GetAllByCategoryName<TModel>(string categoryName)
            => await this.productsRepository
                .All()
                .Where(p => p.Category.Name == categoryName)
                .To<TModel>()
                .ToListAsync();
    }
}
