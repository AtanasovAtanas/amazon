namespace Amazon.Server.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Amazon.Server.Data.Models.Base;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Orders = new HashSet<Order>();
        }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string ModifiedBy { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public int? DeliveryAddressId { get; set; }

        public virtual Address DeliveryAddress { get; set; }

        public virtual IEnumerable<Order> Orders { get; set; }
    }
}
