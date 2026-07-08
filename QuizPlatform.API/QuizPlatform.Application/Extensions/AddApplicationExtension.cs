using Microsoft.Extensions.DependencyInjection;
using QuizPlatform.Application.Interfaces;
using QuizPlatform.Application.Mapper;
using QuizPlatform.Application.Services;

namespace QuizPlatform.Application.Extensions
{
    public static class AddApplicationExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddAutoMapper(cfg => { }, typeof(QuizMapper));
            //services.AddScoped<IAttemptService, AttemptService>();
            services.AddScoped<IQuizService, QuizService>();

            return services;
        }
    }
}
