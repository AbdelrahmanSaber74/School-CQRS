﻿namespace School.Infrastructure;
public static class InfrastructureRegistration
{
    public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Add database-related services
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // Register repositories
        services.AddTransient<IDepartmentRepository, DepartmentRepository>();
        services.AddTransient<IInstructorRepository, InstructorRepository>();
        services.AddTransient<IStudentRepository, StudentRepository>();
        services.AddTransient<ISubjectRepository, SubjectRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IAuthenticationRepository, AuthenticationRepository>();

        services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));

        // Register other infrastructure dependencies
        services.AddLogging();

        return services; 
    }
}
