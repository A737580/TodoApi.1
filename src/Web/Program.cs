
using TodoApi.Infrastructure; 
using Microsoft.EntityFrameworkCore; 
using FluentValidation; 
using TodoApi.Application.Common.Behaviours;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TodoApi.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("TaskMangerDb"),
        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));


builder.Services.AddInfrastructureServices(builder.Configuration); 


builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(TodoApi.Application.Common.Interfaces.IApplicationDbContext).Assembly);
    cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
});
builder.Services.AddValidatorsFromAssembly(typeof(TodoApi.Application.Common.Interfaces.IApplicationDbContext).Assembly);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(configure =>
        {
            configure.Title = "Task Manager API";
            configure.Version = "v1";
        });



var app = builder.Build();

app.UseOpenApi(settings =>
{
    settings.Path = "/api/specification.json";
});

app.UseSwaggerUi(settings =>
{
    settings.Path = "/api";  
    settings.DocumentPath = "/api/specification.json";  
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.Map("/", () => Results.Redirect("/api"));

app.MapControllers();

app.Run();