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

        public class Address
        {
            public const int CityMinLength = 1;
            public const int CityMaxLength = 85;
            public const string ZipCodeRegExPattern = @"(?i)^[a-z0-9][a-z0-9\- ]{0,10}[a-z0-9]$";
            public const int AddressLineMinLength = 5;
            public const int PhoneNumberMinLength = 8;
            public const int PhoneNumberMaxLength = 15;
        }
    }
}
