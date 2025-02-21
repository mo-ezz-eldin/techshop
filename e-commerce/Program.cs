using e_commerce;
using e_commerce.interfaces;
using e_commerce.Models;
using e_commerce.Reposatory;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<appdb>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<Icategory, categoryrepo>();
builder.Services.AddScoped<Iprodeuct,productrepo>();
builder.Services.AddScoped<Iwishlist,wishrepo>();
builder.Services.AddIdentity<appuser, IdentityRole>(option =>
{
	option.Password.RequiredLength = 14;
	option.Password.RequireNonAlphanumeric= true;
	option.Password.RequireUppercase= false;
	option.Password.RequiredUniqueChars = 2;
	option.Password.RequireDigit = true;
	option.Password.RequireLowercase = true;
	option.User.RequireUniqueEmail = true;
	

}).AddEntityFrameworkStores<appdb>();



var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
