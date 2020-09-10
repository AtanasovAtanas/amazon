namespace Amazon.Server.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Amazon.Server.Data.Models.Base;

    using static ValidationConstants.Address;

    public class Address : BaseModel<int>
    {
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        [Required]
        [MinLength(CityMinLength)]
        [MaxLength(CityMaxLength)]
        public string City { get; set; }

        [Required]
        [RegularExpression(ZipCodeRegExPattern)]
        public string ZipCode { get; set; }

        [Required]
        [MinLength(AddressLineMinLength)]
        public string AddressLine { get; set; }

        [Required]
        [MinLength(PhoneNumberMinLength)]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; }
    }
}
