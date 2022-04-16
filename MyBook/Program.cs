using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyBook.Entities;
using MyBook.Infrastructure.Repositories;
using MyBook.Validation;
using Repositories;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IUserValidator<User>, UserValidator>()
    .AddTransient<IPasswordValidator<User>, PasswordValidator>(serv => new PasswordValidator(6));

builder.Services.AddDbContext<MyBookContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultString"), options => options.MigrationsAssembly("MyBook")), ServiceLifetime.Transient)
    .AddScoped<IGenericRepository<Book>, EfGenericRepository<Book>>()
    .AddScoped<IGenericRepository<Author>, EfGenericRepository<Author>>()
    .AddScoped<IGenericRepository<Genre>, EfGenericRepository<Genre>>()
    .AddScoped<EfBookRepository>()
    .AddScoped<EfAuthorRepository>().AddScoped<IGenericRepository<MyBook.Entities.Type>, EfGenericRepository<MyBook.Entities.Type>>()
    .AddScoped<EFTypeRepository>().AddScoped<IGenericRepository<object>, EfGenericRepository<object>>()
    .AddScoped<IGenericRepository<BookCenter>, EfGenericRepository<BookCenter>>()
    .AddScoped<EFBookCenterRepository>();

builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<MyBookContext>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ReadersOnly", policy => policy.RequireClaim(ClaimTypes.Role, "Reader"));
    options.AddPolicy("AdminsOnly", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
});
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
