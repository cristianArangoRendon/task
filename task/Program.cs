using Scalar.AspNetCore;
using task.Extensions;
using task.infraestructure.DependencyInversion;
using task.infraestructure.Extensions;
using task.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddDependencies(configuration);
builder.Services.AddJwtAuthentication(configuration);
builder.Services.AddCorsPolicies();
builder.Services.AddControllers();
builder.Services.AddApiDocumentation();

var app = builder.Build();


app.UseApiDocumentation("Task", ScalarTheme.Default);
app.UseScalarBrowserLauncher();

app.UseHttpsRedirection();
app.UseCorsPolicies(); 

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();