using PharmaPro.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
const string localFrontendCorsPolicy = "LocalFrontend";

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddCors(options =>
{
    options.AddPolicy(localFrontendCorsPolicy, policy =>
    {
        policy.WithOrigins(
                "http://localhost:5173",
                "http://127.0.0.1:5173",
                "http://localhost:4173",
                "http://127.0.0.1:4173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Register Hexagonal Architecture Infrastructure & Application dependencies
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors(localFrontendCorsPolicy);
app.UseAuthorization();
app.MapControllers();

app.Run();
