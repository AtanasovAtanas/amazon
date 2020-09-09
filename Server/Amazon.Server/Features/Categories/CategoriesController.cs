namespace Amazon.Server.Features.Categories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Amazon.Server.Features.Categories.Models;
    using Amazon.Server.Infrastructure;
    using Microsoft.AspNetCore.Mvc;

    using static Amazon.Server.Infrastructure.RoutesConstants;

    public class CategoriesController : ApiController
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        [HttpGet]
        [Route(Category.GetAll)]
        public async Task<IEnumerable<CategoryListingResponseModel>> GetAll() =>
            await this.categoriesService.GetAllAsync<CategoryListingResponseModel>();
    }
}
