using Organizarty.Identity.DependencyInversion;
using Organizarty.Identity.UI.Middlewares;

using Organizarty.Web.Utils.ServicesConfigurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTextCompression();

builder.Services
                .AddEnvironment()
                .AddRepositories()
                .AddProviders()
                .AddUseCases();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

app.UseResponseCompression();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseSwaggerConfiguration();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ErrorHandleMiddleware>();

app.Run();
