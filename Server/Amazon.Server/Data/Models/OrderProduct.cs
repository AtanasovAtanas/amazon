﻿namespace Amazon.Server.Data.Models
{
    using System;

    using Amazon.Server.Data.Models.Base;

    public class OrderProduct : IAuditInfo
    {
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
