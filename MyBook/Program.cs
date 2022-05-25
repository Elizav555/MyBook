using MyBook.Configuration;
using MyBook.Infrastructure.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.ConfigureServices(builder.Configuration);
builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
});

var app = builder.Build();
app.UseResponseCompression();
app.UseCors(builder => builder.WithOrigins("https://my-book-app-kpfu-proj.herokuapp.com"));
app.UseCookiePolicy(new CookiePolicyOptions()
{
    MinimumSameSitePolicy = SameSiteMode.Lax
});
app.UseSession();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapHub<NotificationHub>("/NotificationHub");
app.MapHub<NotificationUserHub>("/NotificationUserHub");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
