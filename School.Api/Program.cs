var builder = WebApplication.CreateBuilder(args);

// 1. Add Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLocalization(options => options.ResourcesPath = "");

// 2. CORS Configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()  // Allows any origin
              .AllowAnyHeader()  // Allows any header
              .AllowAnyMethod(); // Allows any HTTP method
    });
});

// 3. Dependency Injection Configuration
builder.Services.ConfigureInfrastructure(builder.Configuration)
                .ConfigureServices(builder.Configuration)
                .ConfigureCore(builder.Configuration);

// 4. Localization Configuration
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

// 5. Identity Configuration
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// 6. Build Application
var app = builder.Build();

// 7. Exception Handling Middleware
app.UseMiddleware<ExceptionHandlingMiddleware>();

// 8. Localization Middleware
var localizationOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value;
app.UseRequestLocalization(localizationOptions);

// 9. Swagger Setup (Development Only)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "School API V1");
        c.RoutePrefix = string.Empty; // Set Swagger UI as the default page
    });
}

// 10. CORS Middleware
app.UseCors("AllowAll"); // Apply CORS policy

// 11. HTTPS and Routing
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// 12. Run Application
app.Run();
