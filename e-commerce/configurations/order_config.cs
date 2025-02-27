using Microsoft.EntityFrameworkCore;
using e_commerce.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace e_commerce.configurations
{
    public class order_config : IEntityTypeConfiguration<order>
    {
        public void Configure(EntityTypeBuilder<order> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x=>x.Id).UseIdentityColumn().IsRequired();
            builder.Property(x => x.user_id).IsRequired();
            builder.Property(x=>x.product_id).IsRequired();
            builder.HasOne(x=>x.product).WithMany(x=>x.orders).HasForeignKey(product => product.product_id);
            builder.HasOne(x => x.user).WithMany(x => x.orders).HasForeignKey(order=>order.user_id);
        }
    }
}
