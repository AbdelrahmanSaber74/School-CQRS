namespace School.Api
{
    public static class APIRegistration
    {
        public static IServiceCollection ConfigureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            // Add necessary services for API functionality
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddLocalization(options => options.ResourcesPath = "");

      
            // CORS Configuration
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            // Identity Configuration
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Localization Configuration
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[] { new CultureInfo("en"), new CultureInfo("ar") };

                options.DefaultRequestCulture = new RequestCulture("en");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            return services;
        }
    }
}
