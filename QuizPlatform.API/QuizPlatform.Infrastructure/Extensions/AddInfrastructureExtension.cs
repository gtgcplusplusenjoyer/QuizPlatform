using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuizPlatform.Core.Repositories;
using QuizPlatform.Infrastructure.Context;

namespace QuizPlatform.Infrastructure.Extensions
{
    public static class AddInfrastructureExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserRepository, IUserRepository>();

            services.AddDbContext<QuizPlatformDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString(nameof(QuizPlatformDbContext)));
            });

            return services;
        }
    }
}
