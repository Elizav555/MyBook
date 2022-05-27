using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyBook.Core.Interfaces;
using MyBook.Entities;
using MyBook.Infrastructure.Helpers;
using MyBook.Infrastructure.Repositories;
using MyBook.Services;
using MyBook.Validation;
using Repositories;

namespace MyBook.Configuration;

public static class ServicesConfiguration
{
    public static IServiceCollection ConfigureServices(this WebApplicationBuilder builder, IConfiguration configuration)
    {
        builder.Services.AddTransient<IUserValidator<User>, UserValidator>()
            .AddTransient<IPasswordValidator<User>, PasswordValidator>(serv => new PasswordValidator(6));
        
        var defaultConnectionString = GetConnectionString(builder);
        builder.Services.AddDbContext<MyBookContext>(options =>
                options.UseNpgsql(defaultConnectionString,
                    options => options.MigrationsAssembly("MyBook.Infrastructure")), ServiceLifetime.Transient)
            .AddScoped<EfBookRepository>()
            .AddScoped<EFGenreRepository>()
            .AddScoped<EfAuthorRepository>()
            .AddScoped<EFTypeRepository>()
            .AddScoped<EFBookCenterRepository>()
            .AddScoped<EFUserRepository>()
            .AddScoped<EFHistoryRepository>()
            .AddScoped<EFUserSubscrRepository>()
            .AddScoped<ILanguageFilterGetter, LanguageFilterGetter>()
            .AddScoped<IGenresFilterGetter, GenreFilterGetter>()
            .AddScoped<IMailService, MailService>()
            .AddSingleton<IUserConnectionManager, UserConnectionManager>()
            .AddScoped<INotificationService, NotificationService>()
            .AddScoped<IRecommendationsService, RecommendationsService>()
            .AddSingleton<IPaymentService, PaymentService>()
            .AddScoped(typeof(IGenericRepository<>), typeof(EfGenericRepository<>))
            .AddTransient<IUserValidator<User>, UserValidator>()
            .AddTransient<IPasswordValidator<User>, PasswordValidator>(serv => new PasswordValidator(6));
        var serviceProvider = builder.Services.BuildServiceProvider();
        try
        {
            var dbContext = serviceProvider.GetRequiredService<MyBookContext>();
            dbContext.Database.Migrate();
        }
        catch
        {
        }

        builder.Services.AddSignalR();
        builder.Services.AddDistributedMemoryCache();
        
        builder.Services.AddSession(options =>
        {
            options.Cookie.Name = ".MyBook.Session";
            options.IdleTimeout = TimeSpan.FromSeconds(3600);
        });
        builder.Services.AddIdentity<User, IdentityRole>(options => options.User.RequireUniqueEmail = true)
            .AddEntityFrameworkStores<MyBookContext>();
        builder.Services.AddControllersWithViews();
        builder.Services.AddAuthentication();
        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("ReadersOnly", policy => policy.RequireClaim(ClaimTypes.Role, "Reader"));
            options.AddPolicy("AdminsOnly", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
        });
        builder.Services.AddAuthentication().AddVkontakte(builder.Configuration);
        return builder.Services;
    }

    static string GetConnectionString(WebApplicationBuilder webApplicationBuilder)
    {
        if (webApplicationBuilder.Environment.EnvironmentName != "Development")
        {
            var connectionUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

            connectionUrl = connectionUrl.Replace("postgres://", string.Empty);
            var userPassSide = connectionUrl.Split("@")[0];
            var hostSide = connectionUrl.Split("@")[1];

            var user = userPassSide.Split(":")[0];
            var password = userPassSide.Split(":")[1];
            var host = hostSide.Split("/")[0];
            var database = hostSide.Split("/")[1].Split("?")[0];

            return
                $"Host={host};Database={database};Username={user};Password={password};SSL Mode=Require;Trust Server Certificate=true";
        }

        return webApplicationBuilder.Configuration.GetConnectionString("DefaultString");
    }
}