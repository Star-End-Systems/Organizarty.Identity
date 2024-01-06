using Organizarty.Identity.DependencyInversion;
using Organizarty.Identity.UI.Middlewares;

using Organizarty.Web.Utils.ServicesConfigurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services
                .AddEnvironment()
                .AddRepositories()
                .AddProviders()
                .AddUseCases();

if (builder.Environment.IsProduction())
{
    builder.Services.AddTextCompression();
}

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerConfiguration();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseHsts();
}
else if (app.Environment.IsProduction())
{
    app.UseResponseCompression();
}

app.UseSwaggerConfiguration();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ErrorHandleMiddleware>();

app.Run();
