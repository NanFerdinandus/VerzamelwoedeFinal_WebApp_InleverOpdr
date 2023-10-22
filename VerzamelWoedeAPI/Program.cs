using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure Swagger/OpenAPI
if (builder.Environment.IsDevelopment())
{
    // Register the Swagger generator, defining one or more Swagger documents
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "VerzamelWoedeAPI", Version = "v1" });
    });
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable Swagger and Swagger UI
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "VerzamelWoedeAPI V1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Map your controllers, including the custom PostzegelsAPIController
app.MapControllers();

app.Run();
