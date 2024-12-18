var builder = WebApplication.CreateBuilder(args);

// 1. Add Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLocalization(options => options.ResourcesPath = ""); 

// 2. Dependency Injection Configuration
builder.Services.ConfigureInfrastructure(builder.Configuration)
                .ConfigureServices(builder.Configuration)
                .ConfigureCore(builder.Configuration);

// 3. Localization Configuration
var supportedCultures = new[]
{
    new CultureInfo("en"), // English
    new CultureInfo("ar"), // Arabic
};

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture("en"); // Default culture is English
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

// 4. Identity Configuration
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// 5. Build Application
var app = builder.Build();

// 6. Exception Handling Middleware
app.UseMiddleware<ExceptionHandlingMiddleware>();

// 7. Localization Middleware
var localizationOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value;
app.UseRequestLocalization(localizationOptions);

// 8. Swagger Setup (Development Only)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "School API V1");
        c.RoutePrefix = string.Empty; // Set Swagger UI as the default page
    });
}

// 9. HTTPS and Routing
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// 10. Run Application
app.Run();
