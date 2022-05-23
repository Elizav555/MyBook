using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;

namespace MyBook.Configuration;

public static class ConfigureVK
{
    public static AuthenticationBuilder AddVkontakte(this AuthenticationBuilder builder,IConfiguration configuration)
    {
        builder.AddOAuth("VK", "VKontakte", config =>
        {
            config.ClientId = configuration["VkAuth:AppId"];
            config.ClientSecret = configuration["VkAuth:AppSecret"];
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

        return builder;
    }
}