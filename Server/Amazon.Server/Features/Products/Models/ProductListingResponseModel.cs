namespace Amazon.Server.Features.Products.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using Amazon.Server.Data.Models;
    using Amazon.Server.Infrastructure.Mapping;
    using AutoMapper;

    public class ProductListingResponseModel : IMapFrom<Product>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public string About { get; set; }

        public decimal Price { get; set; }

        public List<string> Pictures { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Product, ProductListingResponseModel>()
                .ForMember(dest => dest.Pictures, options =>
                {
                    options.MapFrom(
                        product => product
                            .Pictures
                            .Select(p => p.ImageUrl)
                            .ToList());
                });
        }
    }
}
