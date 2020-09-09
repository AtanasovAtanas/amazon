namespace Amazon.Server.Infrastructure
{
    public class RoutesConstants
    {
        public class Common
        {
            public const string Id = "{id}";
        }

        public class Category
        {
            public const string GetAll = "All";
        }

        public class Product
        {
            public const string GetProductsByCategory = "/{categoryName}/Products";
        }
    }
}
