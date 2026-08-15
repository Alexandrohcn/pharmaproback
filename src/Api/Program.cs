using PharmaPro.Api.Configuration;
using PharmaPro.Infrastructure;

DotEnvLoader.Load();

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();

// Add services to the container.
const string localFrontendCorsPolicy = "LocalFrontend";

var port = Environment.GetEnvironmentVariable("PORT");
if (!string.IsNullOrWhiteSpace(port))
{
    builder.WebHost.UseUrls($"http://0.0.0.0:{port}");
}

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddCors(options =>
{
    options.AddPolicy(localFrontendCorsPolicy, policy =>
    {
        // En produccion/VPS configurar Cors__AllowedOrigins__0, Cors__AllowedOrigins__1 via variables de entorno o .env
        // En desarrollo local, si no hay configuracion, se usan los origenes locales como fallback.
        var configuredOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();

        var allowedOrigins = configuredOrigins is { Length: > 0 }
            ? configuredOrigins
            : builder.Environment.IsDevelopment()
                ? new[] { "http://localhost:5173", "http://127.0.0.1:5173", "http://localhost:4173", "http://127.0.0.1:4173" }
                : Array.Empty<string>();

        if (allowedOrigins.Length == 0)
        {
            // En produccion sin configurar CORS, bloquear todo origen.
            policy.SetIsOriginAllowed(_ => false);
        }
        else
        {
            policy.WithOrigins(allowedOrigins)
                .AllowAnyHeader()
                .AllowAnyMethod();
        }
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
