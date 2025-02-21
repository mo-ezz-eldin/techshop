using e_commerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_commerce.configurations
{
    public class wishlist_config : IEntityTypeConfiguration<wishlist>
    {
        public void Configure(EntityTypeBuilder<wishlist> builder)
        {
           builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().UseIdentityColumn();
            builder.Property(x=>x.user_id).IsRequired();
            builder.Property(x => x.product_id).IsRequired();
            builder.HasOne(x => x.user).WithMany(x => x.wishlist).HasForeignKey(x => x.user_id);
            builder.HasOne(x => x.product).WithMany(x=>x.wishlist).HasForeignKey(x=>x.product_id);
        }
    }
}
 