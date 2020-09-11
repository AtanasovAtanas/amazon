namespace Amazon.Server.Features.Products.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using Amazon.Server.Data.Models;
    using Amazon.Server.Infrastructure.Mapping;
    using Amazon.Server.Services.Slug;
    using AutoMapper;

    public class ProductDetailsResponseModel : IMapFrom<Product>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Slug { get; set; }

        public string Title { get; set; }

        public string About { get; set; }

        public decimal Price { get; set; }

        public string SellerEmail { get; set; }

        public IEnumerable<string> Pictures { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Product, ProductDetailsResponseModel>()
                   .ForMember(dest => dest.Pictures, options =>
                   {
                       options.MapFrom(
                           product => product
                               .Pictures
                               .Select(p => p.ImageUrl)
                               .ToList());
                   })
                   .ForMember(dest => dest.Slug, options =>
                   {
                       options.MapFrom(
                           product => new SlugGenerator().GenerateSlug(product.Title));
                   });
        }
    }
}
