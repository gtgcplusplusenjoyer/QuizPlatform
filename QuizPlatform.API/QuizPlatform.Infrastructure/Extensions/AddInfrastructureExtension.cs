using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using QuizPlatform.Core.External;
using QuizPlatform.Core.Repositories;
using QuizPlatform.Infrastructure.Context;
using QuizPlatform.Infrastructure.External;
using QuizPlatform.Infrastructure.Repositories;
using QuizPlatform.Infrastructure.Settings;
using System.Text;

namespace QuizPlatform.Infrastructure.Extensions
{
    public static class AddInfrastructureExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();

            services.AddDbContext<QuizPlatformDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString(nameof(QuizPlatformDbContext)));
            });

            services.Configure<AuthSettings>(configuration.GetSection("JwtSettings"));
            services.AddAuthExtension(configuration);

            return services;
        }
        public static IServiceCollection AddAuthExtension(this IServiceCollection services, IConfiguration configuration)
        {
            var authSettings = configuration.GetSection("JwtSettings").Get<AuthSettings>();

            services.Configure<AuthSettings>(configuration.GetSection("JwtSettings"));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = authSettings?.Issuer,
                        ValidateAudience = true,
                        ValidAudience = authSettings?.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(authSettings?.Secret ?? "fallback-secret-key-32-chars-long!!!")),
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });

            return services;
        }
    }
}
