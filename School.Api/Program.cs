var builder = WebApplication.CreateBuilder(args);


// 2. Dependency Injection Configuration
builder.Services.ConfigureInfrastructure(builder.Configuration)
                .ConfigureServices(builder.Configuration)
                .ConfigureCore(builder.Configuration)
                .ConfigureAPI(builder.Configuration);


// 5. Build Application
var app = builder.Build();

// 6. Middleware Configuration
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

// 9. Middleware: CORS, HTTPS, Authorization, and Routing
app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// 10. Run Application
app.Run();
