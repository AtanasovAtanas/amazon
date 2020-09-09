namespace Amazon.Server.Data.Models
{
    public class ValidationConstants
    {
        public class Category
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;
            public const string NameMinLengthErrorMessage = "The category name must be at least 3 characters.";
            public const string NameMaxLengthErrorMessage = "The category name must not be longer than 50 characters.";
        }

        public class Product
        {
            public const int TitleMinLength = 3;
            public const string TitleMinLengthErrorMessage = "The product title must be at least 3 characters.";
            public const int TitleMaxLength = 200;
            public const string TitleMaxLengthErrorMessage = "The product title must not be longer than 200 characters.";

            public const int AboutMinLength = 100;
            public const string AboutMinLengthErrorMessage = "The product description must be at least 100 characters.";

            public const string PriceMinValue = "0";
            public const string PriceMaxValue = "2147483647";
            public const string PriceErrorMessage = "Price must be a positive number";
        }
    }
}
