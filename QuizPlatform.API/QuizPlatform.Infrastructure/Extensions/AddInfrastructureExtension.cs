using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuizPlatform.Core.External;
using QuizPlatform.Core.Repositories;
using QuizPlatform.Infrastructure.Context;
using QuizPlatform.Infrastructure.External;
using QuizPlatform.Infrastructure.Repositories;
using QuizPlatform.Infrastructure.Settings;

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

            return services;
        }
    }
}
