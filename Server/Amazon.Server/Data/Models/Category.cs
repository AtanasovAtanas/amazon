namespace Amazon.Server.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Amazon.Server.Data.Models.Base;

    using static ValidationConstants.Category;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }

        [Required]
        [MinLength(NameMinLength, ErrorMessage = NameMinLengthErrorMessage)]
        [MaxLength(NameMaxLength, ErrorMessage = NameMaxLengthErrorMessage)]
        public string Name { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }
    }
}
