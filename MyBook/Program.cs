using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.OAuth;
using MyBook.Entities;
using MyBook.Infrastructure.Repositories;
using MyBook.Validation;
using Repositories;
using System.Security.Claims;
using MyBook.Infrastructure.Helpers;
using Microsoft.AspNetCore.Authentication;
using MyBook.Services;
using MyBook.Core.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IUserValidator<User>, UserValidator>()
    .AddTransient<IPasswordValidator<User>, PasswordValidator>(serv => new PasswordValidator(6));

builder.Services.AddDbContext<MyBookContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultString"),
            options => options.MigrationsAssembly("MyBook")), ServiceLifetime.Transient)
    .AddScoped<IGenericRepository<Book>, EfGenericRepository<Book>>()
    .AddScoped<IGenericRepository<Author>, EfGenericRepository<Author>>()
    .AddScoped<IGenericRepository<Genre>, EfGenericRepository<Genre>>()
    .AddScoped<EfBookRepository>()
    .AddScoped<EFGenreRepository>()
    .AddScoped<EfAuthorRepository>()
    .AddScoped<IGenericRepository<DownloadLink>, EfGenericRepository<DownloadLink>>()
    .AddScoped<IGenericRepository<MyBook.Entities.Type>, EfGenericRepository<MyBook.Entities.Type>>()
    .AddScoped<EFTypeRepository>().AddScoped<IGenericRepository<object>, EfGenericRepository<object>>()
    .AddScoped<IGenericRepository<BookCenter>, EfGenericRepository<BookCenter>>()
    .AddScoped<EFBookCenterRepository>()
    .AddScoped<IGenericRepository<User>, EfGenericRepository<User>>().AddScoped<EFUserRepository>()
    .AddScoped<IGenericRepository<History>, EfGenericRepository<History>>().AddScoped<EFHistoryRepository>()
    .AddScoped<IGenericRepository<UserSubscr>, EfGenericRepository<UserSubscr>>().AddScoped<EFUserSubscrRepository>()
    .AddScoped<ILanguageFilterGetter, LanguageFilterGetter>()
    .AddScoped<IGenresFilterGetter, GenreFilterGetter>()
    .AddScoped<IMailService, MailService>();

builder.Services.AddIdentity<User, IdentityRole>(options => options.User.RequireUniqueEmail = true).AddEntityFrameworkStores<MyBookContext>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ReadersOnly", policy => policy.RequireClaim(ClaimTypes.Role, "Reader"));
    options.AddPolicy("AdminsOnly", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
});
builder.Services.AddAuthentication().AddOAuth("VK", "VKontakte", config =>
{
    config.ClientId = builder.Configuration["VkAuth:AppId"];
    config.ClientSecret = builder.Configuration["VkAuth:AppSecret"];
    config.ClaimsIssuer = "VKontakte";
    config.CallbackPath = new PathString("/signin-vkontakte-token");
    config.AuthorizationEndpoint = "https://oauth.vk.com/authorize";
    config.TokenEndpoint = "https://oauth.vk.com/access_token";
    config.Scope.Add("email");
    config.Scope.Add("first_name");
    config.Scope.Add("last_name");
    config.Scope.Add("bdate");
    config.ClaimActions.MapJsonKey(ClaimTypes.Name, "first_name");
    config.ClaimActions.MapJsonKey(ClaimTypes.Surname, "last_name");
    config.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "user_id");
    config.ClaimActions.MapJsonKey(ClaimTypes.Email, "email");
    config.ClaimActions.MapJsonKey(ClaimTypes.DateOfBirth, "bdate");
    config.SaveTokens = true;
    config.Events = new OAuthEvents
    {
        OnCreatingTicket = context =>
        {
            context.RunClaimActions(context.TokenResponse.Response.RootElement);
            return Task.CompletedTask;
        }
    };
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
