namespace Amazon.Server.Data.Models
{
    using Amazon.Server.Data.Models.Base;
    using Amazon.Server.Data.Models.Enums;

    public class OrderHistory : BaseModel<int>
    {
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        public OrderStatus? OldStatus { get; set; }

        public OrderStatus NewStatus { get; set; }
    }
}
