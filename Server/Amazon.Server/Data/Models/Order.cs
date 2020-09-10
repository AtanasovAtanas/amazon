namespace Amazon.Server.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Amazon.Server.Data.Models.Base;
    using Amazon.Server.Data.Models.Enums;

    public class Order : BaseModel<int>
    {
        public Order()
        {
            this.Products = new HashSet<OrderProduct>();
            this.Changes = new HashSet<OrderHistory>();
        }

        [Required(AllowEmptyStrings = false)]
        public string CustomerId { get; set; }

        public virtual User Customer { get; set; }

        public OrderStatus Status { get; set; }

        public virtual IEnumerable<OrderProduct> Products { get; set; }

        public virtual IEnumerable<OrderHistory> Changes { get; set; }
    }
}
