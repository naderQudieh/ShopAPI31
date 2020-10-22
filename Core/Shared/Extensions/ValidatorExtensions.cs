using System.Linq;
using Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions
{
    public static class AddValidatorsExtensions
    {
        public static IServiceCollection RegisterFluentValidators(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (context) =>
                {
                    var errors = context.ModelState.Values.SelectMany(x => x.Errors.Select(e => e.ErrorMessage)).ToList();
                    throw new InValidInputException($"Request validation failed: Errors: {string.Join(",",errors)}");
                };
            });
            return services;
        }


    }
}
