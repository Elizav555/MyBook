using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyBook.Entities;
using MyBook.Infrastructure.Repositories;
using Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyBookContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultString")), ServiceLifetime.Transient)
    .AddScoped<IGenericRepository<Book>, EfGenericRepository<Book>>()
    .AddScoped<IGenericRepository<Author>, EfGenericRepository<Author>>()
    .AddScoped<IGenericRepository<Genre>, EfGenericRepository<Genre>>()
    .AddScoped<EfBookRepository>()
    .AddScoped<EfAuthorRepository>();

builder.Services.AddIdentity<UserIdentity, IdentityRole>().AddEntityFrameworkStores<MyBookContext>();
// Add services to the container.
builder.Services.AddControllersWithViews();
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
