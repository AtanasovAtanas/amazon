namespace Amazon.Server.Features.Categories.Models
{
    using Amazon.Server.Data.Models;
    using Amazon.Server.Infrastructure.Mapping;

    public class CategoryListingResponseModel : IMapFrom<Category>
    {
        public string Name { get; set; }
    }
}
