﻿namespace Amazon.Server.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Amazon.Server.Data.Models.Base;

    using static ValidationConstants.Product;

    public class Product : BaseDeletableModel<int>
    {
        public Product()
        {
            this.Pictures = new HashSet<Picture>();
            this.Orders = new HashSet<OrderProduct>();
        }

        [Required]
        [MinLength(TitleMinLength, ErrorMessage = TitleMinLengthErrorMessage)]
        [MaxLength(TitleMaxLength, ErrorMessage = TitleMaxLengthErrorMessage)]
        public string Title { get; set; }

        [Required]
        [MinLength(AboutMinLength, ErrorMessage = AboutMinLengthErrorMessage)]
        public string About { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Range(typeof(decimal), PriceMinValue, PriceMaxValue, ErrorMessage = PriceErrorMessage)]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Required]
        public string SellerId { get; set; }

        public virtual User Seller { get; set; }

        public virtual IEnumerable<Picture> Pictures { get; set; }

        public virtual IEnumerable<OrderProduct> Orders { get; set; }
    }
}
