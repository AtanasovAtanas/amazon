namespace Amazon.Server.Data.Models.Enums
{
    public enum OrderStatus
    {
        New = 1,
        PendingPayment = 2,
        PaymentReceived = 3,
        PaymentFailed = 4,
        Shipping = 5,
        Shipped = 6,
        Finished = 7,
    }
}
