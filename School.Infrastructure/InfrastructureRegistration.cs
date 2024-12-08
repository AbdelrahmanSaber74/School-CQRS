namespace School.Infrastructure;
public static class InfrastructureRegistration
{
    public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Add database-related services
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // Register repositories
        services.AddTransient<IStudentRepository, StudentRepository>();

        // Register other infrastructure dependencies
        services.AddLogging();

        return services; 
    }
}
