namespace Amazon.Server.Data.Configurations
{
    using Amazon.Server.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(o => o.Changes)
                .WithOne(oh => oh.Order)
                .HasForeignKey(oh => oh.OrderId);
        }
    }
}
