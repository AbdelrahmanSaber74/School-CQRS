namespace School.Service
{
    public static class CoreRegistration
    {
        public static IServiceCollection ConfigureCore(this IServiceCollection services, IConfiguration configuration)
        {
            // Register MediatR services from the current assembly
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            // Register FluentValidation validators from the current assembly
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // Register the ValidationBehavior as a pipeline behavior in MediatR
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            // Register AutoMapper and scan the current assembly for profiles
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
