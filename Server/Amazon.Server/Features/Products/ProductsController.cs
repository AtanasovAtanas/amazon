namespace Amazon.Server.Features.Products
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Amazon.Server.Features.Products.Models;
    using Microsoft.AspNetCore.Mvc;

    using static Amazon.Server.Infrastructure.RoutesConstants.Product;

    public class ProductsController : ApiController
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [HttpGet]
        [Route(GetProductsByCategory)]
        public async Task<IEnumerable<ProductListingResponseModel>> GetProductsByCategoryName(
            [FromRoute] string categoryName)
        {
            return await this.productsService.GetAllByCategoryName<ProductListingResponseModel>(categoryName);
        }
    }
}
