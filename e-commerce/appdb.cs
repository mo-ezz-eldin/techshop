using e_commerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace e_commerce
{
    public class appdb:IdentityDbContext<appuser,IdentityRole,string>
	{
		public DbSet<wishlist> wishlist { get; set; }
		public DbSet<category> categories {  get; set; }
		public DbSet<product> products { get; set; }
        public appdb(DbContextOptions<appdb> options) : base(options) { }

        public appdb()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	
	}
}
