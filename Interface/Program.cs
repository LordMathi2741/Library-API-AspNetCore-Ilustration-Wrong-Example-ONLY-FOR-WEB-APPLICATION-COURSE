using System.Reflection;
using Application.Library.Internal.BookCommandServices;
using Application.Library.Internal.BookQueryServices;
using Domain.Library.Repositories;
using Domain.Library.Service;
using Domain.Shared.Repositories;
using Infrastructure.Library.Persistence.EFC.Repositories;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;
using Interface.Shared.ASP.Configuration;
using Interface.Shared.Middleware;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// configure kebab case route naming convention
builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new KebabCaseRouteNamingConvention());
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Library API",
        Description = "An ASP.NET Core Web API for ilustration topics like DDD, CQRS, Documentation and more.",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

// adding database connection
var connectionString = builder.Configuration.GetConnectionString("LibraryDb");

// Configure Database Context and Logging Levels
builder.Services.AddDbContext<AppDbContext>(
    dbContextOptions =>
    {
        dbContextOptions.UseMySql(connectionString, 
            ServerVersion.AutoDetect(connectionString) 
        );
    });


// configure lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// shared bounded context injection configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// news bounded context injection configuration DEPENDENCY INJECTION
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookCommandService, BookCommandService>();
builder.Services.AddScoped<IBookQueryService, BookQueryService>();
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

//EF
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

app.UseCors(b => b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();