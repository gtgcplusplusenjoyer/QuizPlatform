using Microsoft.Extensions.DependencyInjection;
using QuizPlatform.Application.Interfaces;
using QuizPlatform.Application.Services;

namespace QuizPlatform.Application.Extensions
{
    public static class AddApplicationExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAttemptService, AttemptService>();
            services.AddScoped<IQuizService, QuizService>();

            return services;
        }
    }
}
