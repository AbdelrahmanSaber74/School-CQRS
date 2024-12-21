namespace School.Service
{
    public static class ServiceRegistration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {

        //    Register repositories with their interfaces
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ISubjectService, SubjectsService>();

          //  Register other infrastructure dependencies
            services.AddLogging();


            return services;
        }
    }
}
