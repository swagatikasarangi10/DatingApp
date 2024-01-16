using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace API;

public static class IdentityServiceExtensions
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services,IConfiguration config)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
AddJwtBearer(options=>{
    options.TokenValidationParameters= new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey= new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(config.Configuration["TokenKey"])),
        ValidateIssuer=false,
        ValidateAudience=false
    };
});
return services;
    }

}
