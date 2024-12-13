using School.Core.Behaviors;

namespace School.Service
{
    public static class CoreRegistration
    {
        public static IServiceCollection ConfigureCore(this IServiceCollection services, IConfiguration configuration)
        {
            // Register MediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


            // Register AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());



            return services;
        }
    }
}
