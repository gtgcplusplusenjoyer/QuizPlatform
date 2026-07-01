using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using QuizPlatform.Application.Dto.User;
using QuizPlatform.Application.Validators;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

namespace QuizPlatform.Application.Extensions
{
    public static class AddValidationExtension
    {
        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();
            services.AddScoped<IValidator<LoginUserDto>, LoginUserDtoValidator>();
            services.AddScoped<IValidator<RefreshTokerRequestDto>, RefreshTokerRequestDtoValidator>();

            services.AddFluentValidationAutoValidation();

            return services;
        }
    }
}
