using Core.Extensions;
using Core.Validators;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ShopAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .RegisterDbAccess(Configuration)
                .RegisterDomainServics()
                .ConfigureAuthentication(Configuration)
                .RegisterAuthServices()
                .ConfigureCors(Configuration)
                .ConfigureSwagger()
                .RegisterFluentValidators()
                .AddControllers()
                .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<RegisterCustomerRequestValidator>()); ;

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.EnableSwagger()
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .InitializeDatabase()
                .ConfigureExceptionMiddleware()
                .UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
