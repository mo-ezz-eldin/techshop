using e_commerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_commerce.configurations
{
	public class category_config : IEntityTypeConfiguration<category>
	{
		public void Configure(EntityTypeBuilder<category> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x=>x.Id).IsRequired().UseIdentityColumn();
			builder.Property(x => x.Name).IsRequired().HasColumnType("varchar").HasMaxLength(125);
			builder.HasMany(x=>x.Products).WithOne(x=>x.cat).HasForeignKey(x=>x.category_id);
			builder.HasData(new List<category>
			{
	new category { Id = 1, Name = "Electronics" },
	new category { Id = 2, Name = "Clothing & Apparel" },
	new category { Id = 3, Name = "Home & Living" },
	new category { Id = 4, Name = "Beauty & Personal Care" },
	new category { Id = 5, Name = "Books & Stationery" },
	new category { Id = 6, Name = "Toys & Games" },
	new category { Id = 7, Name = "Sports & Outdoors" },
	new category { Id = 8, Name = "Automotive Parts & Accessories" },
	new category { Id = 9, Name = "Groceries & Gourmet Foods" },
	new category { Id = 10, Name = "Health & Wellness" },
	new category { Id = 11, Name = "Jewelry & Watches" },
	new category { Id = 12, Name = "Pet Supplies" },
	new category { Id = 13, Name = "Office Supplies" },
	new category { Id = 14, Name = "Baby & Kids" },
	new category { Id = 15, Name = "Furniture" },
	new category { Id = 16, Name = "Art & Crafts" },
	new category { Id = 17, Name = "Musical Instruments" },
	new category { Id = 18, Name = "Travel & Luggage" },
	new category { Id = 19, Name = "Garden & Outdoor" },
	new category { Id = 20, Name = "Fitness & Exercise" },
	new category { Id = 21, Name = "Watches & Accessories" },
	new category { Id = 22, Name = "Party Supplies" },
	new category { Id = 23, Name = "Industrial & Scientific" },
	new category { Id = 24, Name = "Shoes & Footwear" },
	new category { Id = 25, Name = "Seasonal & Holiday Decor" }
			});
		}
	}
}
