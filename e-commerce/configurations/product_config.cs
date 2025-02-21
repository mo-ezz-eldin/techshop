using e_commerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.FileSystemGlobbing;
using NuGet.Packaging.Signing;
using static System.Reflection.Metadata.BlobBuilder;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.IO;

namespace e_commerce.configurations
{
	public class product_config : IEntityTypeConfiguration<product>
	{
		public void Configure(EntityTypeBuilder<product> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x=>x.Id).IsRequired().UseIdentityColumn();
			builder.Property(x => x.Name).IsRequired().HasColumnType("varchar").HasMaxLength(100);
			builder.Property(x=>x.quatity).IsRequired();
			builder.Property(x => x.Price).IsRequired().HasColumnType("int");
			builder.Property(x => x.category_id).IsRequired();
			builder.Property(x => x.Description).IsRequired().HasColumnType("varchar").HasMaxLength(200);
			builder.Property(x => x.imgsource).IsRequired().HasColumnType("varchar").HasMaxLength(200);
			builder.HasData(new List<product>()
			{
                new product
        {
            Id = 1,
            Name = "Wireless Bluetooth Headphones",
            category_id = 1,
            Price = 100,
            quatity = 1002,
            imgsource = "/images/wireless-bluetooth.jpg",
            Description = "Wireless Bluetooth 5.0 headphones with 30-hour battery, noise cancellation, and ergonomic design."
        },
        new product
        {
            Id = 2,
            Name = "4K Smart TV",
            category_id = 1,
            Price = 8000,
            quatity = 200,
            imgsource = "/images/4k-smart-tv.jpg",
            Description = "4K Ultra HD Smart TV with HDR10+, Android OS, Netflix/Prime Video, HDMI 2.1."
        },

        // Category 2: Clothing & Apparel
        new product
        {
            Id = 3,
            Name = "Men's Cotton T-Shirt",
            category_id = 2,
            Price = 20,
            quatity = 500,
            imgsource = "/images/mens-tshirt.jpg",
            Description = "Premium cotton crew-neck T-shirt for men. Available in multiple colors."
        },

        // Category 3: Home & Living
        new product
        {
            Id = 4,
            Name = "Ceramic Table Lamp",
            category_id = 3,
            Price = 45,
            quatity = 150,
            imgsource = "/images/table-lamp.jpg",
            Description = "Modern ceramic lamp with fabric shade. Perfect for living rooms."
        },

        // Category 4: Beauty & Personal Care
        new product
        {
            Id = 5,
            Name = "Hydrating Facial Serum",
            category_id = 4,
            Price = 35,
            quatity = 300,
            imgsource = "/images/facial-serum.jpg",
            Description = "Vitamin C serum for glowing skin. Suitable for all skin types."
        },

        // Category 5: Books & Stationery
        new product
        {
            Id = 6,
            Name = "Leather Journal Notebook",
            category_id = 5,
            Price = 19,
            quatity = 200,
            imgsource = "/images/leather-journal.jpg",
            Description = "Handcrafted leather-bound notebook with lined pages."
        },

        // Category 6: Toys & Games
        new product
        {
            Id = 7,
            Name = "Building Blocks Set",
            category_id = 6,
            Price = 30,
            quatity = 400,
            imgsource = "/images/building-blocks.jpg",
            Description = "500-piece plastic building blocks for creative play."
        },

        // Category 7: Sports & Outdoors
        new product
        {
            Id = 8,
            Name = "Camping Tent (4-Person)",
            category_id = 7,
            Price = 150,
            quatity = 100,
            imgsource = "/images/camping-tent.jpg",
            Description = "Weather-resistant tent with easy setup. Includes carry bag."
        },

        // Category 8: Automotive Parts & Accessories
        new product
        {
            Id = 9,
            Name = "Car Phone Mount",
            category_id = 8,
            Price = 16,
            quatity = 600,
            imgsource = "/images/car-mount.jpg",
            Description = "Adjustable dashboard phone holder with strong suction."
        },

        // Category 9: Groceries & Gourmet Foods
        new product
        {
            Id = 10,
            Name = "Organic Coffee Beans (1kg)",
            category_id = 9,
            Price = 20,
            quatity = 250,
            imgsource = "/images/coffee-beans.jpg",
            Description = "Arabica coffee beans, medium roast. Sustainably sourced."
        },

        // Category 10: Health & Wellness
        new product
        {
            Id = 11,
            Name = "Yoga Mat",
            category_id = 10,
            Price = 25,
            quatity = 350,
            imgsource = "/images/yoga-mat.jpg",
            Description = "Eco-friendly non-slip mat. Includes carrying strap."
        },

        // Category 11: Jewelry & Watches
        new product
        {
            Id = 12,
            Name = "Silver Pendant Necklace",
            category_id = 11,
            Price = 90,
            quatity = 120,
            imgsource = "/images/silver-necklace.jpg",
            Description = "925 sterling silver pendant necklace with chain."
        },

        // Category 12: Pet Supplies
        new product
        {
            Id = 13,
            Name = "Dog Chew Toy",
            category_id = 12,
            Price = 10,
            quatity = 800,
            imgsource = "/images/dog-toy.jpg",
            Description = "Durable rubber chew toy for medium/large dogs."
        },

        // Category 13: Office Supplies
        new product
        {
            Id = 14,
            Name = "Ballpoint Pen Set",
            category_id = 13,
            Price = 10,
            quatity = 1000,
            imgsource = "/images/pen-set.jpg",
            Description = "12-pack of smooth-writing black ink pens."
        },

        // Category 14: Baby & Kids
        new product
        {
            Id = 15,
            Name = "Baby Stroller",
            category_id = 14,
            Price = 120,
            quatity = 80,
            imgsource = "/images/baby-stroller.jpg",
            Description = "Lightweight stroller with reclining seat and sunshade."
        },

        // Category 15: Furniture
        new product
        {
            Id = 16,
            Name = "Wooden Dining Table",
            category_id = 15,
            Price = 300,
            quatity = 50,
            imgsource = "/images/dining-table.jpg",
            Description = "Solid oak table. Seats 6. Modern farmhouse design."
        },

        // Category 16: Art & Crafts
        new product
        {
            Id = 17,
            Name = "Acrylic Paint Set",
            category_id = 16,
            Price = 25,
            quatity = 200,
            imgsource = "/images/paint-set.jpg",
            Description = "24-color set with brushes. Non-toxic and washable."
        },

        // Category 17: Musical Instruments
        new product
        {
            Id = 18,
            Name = "Acoustic Guitar",
            category_id = 17,
            Price = 200,
            quatity = 30,
            imgsource = "/images/acoustic-guitar.jpg",
            Description = "Full-size guitar with spruce top. Includes gig bag."
        },

        // Category 18: Travel & Luggage
        new product
        {
            Id = 19,
            Name = "Carry-On Suitcase",
            category_id = 18,
            Price = 80,
            quatity = 150,
            imgsource = "/images/suitcase.jpg",
            Description = "Hard-shell spinner luggage. FAA-approved size."
        },

        // Category 19: Garden & Outdoor
        new product
        {
            Id = 20,
            Name = "Patio Umbrella",
            category_id = 19,
            Price = 60,
            quatity = 90,
            imgsource = "/images/patio-umbrella.jpg",
            Description = "9-foot UV-resistant umbrella with tilt function."
        },

        // Category 20: Fitness & Exercise
        new product
        {
            Id = 21,
            Name = "Adjustable Dumbbells",
            category_id = 20,
            Price = 100,
            quatity = 70,
            imgsource = "/images/dumbbells.jpg",
            Description = "5–25 kg adjustable set with ergonomic grips."
        },

        // Category 21: Watches & Accessories
        new product
        {
            Id = 22,
            Name = "Stainless Steel Watch",
            category_id = 21,
            Price = 200,
            quatity = 40,
            imgsource = "/images/stainless-watch.jpg",
            Description = "Water-resistant chronograph watch with date display."
        },

        // Category 22: Party Supplies
        new product
        {
            Id = 23,
            Name = "Balloon Decoration Kit",
            category_id = 22,
            Price = 15,
            quatity = 300,
            imgsource = "/images/balloon-kit.jpg",
            Description = "50-piece kit with pump, strings, and assorted balloons."
        },

        // Category 23: Industrial & Scientific
        new product
        {
            Id = 24,
            Name = "Digital Caliper",
            category_id = 23,
            Price = 35,
            quatity = 120,
            imgsource = "/images/digital-caliper.jpg",
            Description = "Precision measuring tool with LCD screen. 0–150mm range."
        },

        // Category 24: Shoes & Footwear
        new product
        {
            Id = 25,
            Name = "Running Sneakers",
            category_id = 24,
            Price = 80,
            quatity = 250,
            imgsource = "/images/running-shoes.jpg",
            Description = "Lightweight breathable shoes with cushioned sole."
        },

        // Category 25: Seasonal & Holiday Decor
        new product
        {
            Id = 26,
            Name = "LED Christmas Lights",
            category_id = 25,
            Price = 25,
            quatity = 500,
            imgsource = "/images/christmas-lights.jpg",
            Description = "10-meter string lights with 8 lighting modes."
        }
    });

        }
	}
}
