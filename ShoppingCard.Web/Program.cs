using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using ShoppingCard.DataAcess.DbContext;
using ShoppingCard.DataAcess.IRepositories;
using ShoppingCard.DataAcess.Repositories;
using ShoppingCard.Utility.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IFileService,FileService>();
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
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

app.UseAuthorization();


app.MapControllerRoute(
    name: "Area",
      pattern: "{area:exists}/{controller=Category}/{action=Index}/{id?}"
    );
app.MapControllerRoute(
    name: "Area",
      pattern: "{area:exists}/{controller=Product}/{action=Index}/{id?}"
    );
app.MapControllerRoute(
    name: "Area",
      pattern: "{area:exists}/{controller=Customer}/{action=Index}/{id?}"
    );
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
