namespace School.Service
{
    public static class CoreRegistration
    {
        public static IServiceCollection ConfigureCore(this IServiceCollection services, IConfiguration configuration)
        {
            // Register MediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


            // Register AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());



            return services;
        }
    }
}
