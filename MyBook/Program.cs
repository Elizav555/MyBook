using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyBook.Entities;
using Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyBookContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultString")), ServiceLifetime.Transient)
    .AddScoped<IGenericRepository<Book>, EFGenericRepository<Book>>()
    .AddScoped<IGenericRepository<Author>, EFGenericRepository<Author>>()
    .AddScoped<IGenericRepository<Genre>, EFGenericRepository<Genre>>();

builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<MyBookContext>();
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
