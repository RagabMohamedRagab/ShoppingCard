using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using ShoppingCard.DataAcess.DbContext;
using ShoppingCard.DataAcess.IRepositories;
using ShoppingCard.DataAcess.Repositories;
using ShoppingCard.Utility.Services;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using ShoppingCard.Models.Entities;
using ShoppingCard.Utility.Utility;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));
builder.Services.AddIdentity<ApplicationUser,IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IFileService,FileService>();
builder.Services.AddScoped<IDbInitlizar, DbInitlizar>();
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddRazorPages();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
dataseeding();
app.UseAuthentication();;
app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "Area",
      pattern: "{area:exists}/{Controller=Customer}/{Action=Index}/{id?}"
    );
app.MapAreaControllerRoute(
    name: "default",
    areaName: "Customer",
    pattern: "{Controller=Customer}/{Action=Index}/{id?}");
app.MapControllerRoute(
    name: "Last",
      pattern: "{Controller=Home}/{Action=Index}/{id?}"
    );
app.Run();
// Seeding Data 
void dataseeding()
{
    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<IDbInitlizar>();
        db.Initlizar();
    }
}