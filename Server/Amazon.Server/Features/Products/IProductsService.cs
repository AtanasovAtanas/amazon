namespace Amazon.Server.Features.Products
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductsService
    {
        Task<IEnumerable<TModel>> GetAllByCategoryName<TModel>(string categoryName);

        Task<TModel> GetProductById<TModel>(int id);
    }
}
