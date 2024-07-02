using si730ebu20221b127.API.Shared.Interfaces.ASP.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using si730ebu20221b127.API.Assessment.Application.Internal.CommandServices;
using si730ebu20221b127.API.Assessment.Application.Internal.OutboundServices.ACL;
using si730ebu20221b127.API.Assessment.Application.Internal.QueryServices;
using si730ebu20221b127.API.Assessment.Domain.Repositories;
using si730ebu20221b127.API.Assessment.Domain.Services;
using si730ebu20221b127.API.Assessment.Infrastructure.Persistence.EFC.Repositories;
using si730ebu20221b127.API.Personnel.Application.Internal.CommandServices;
using si730ebu20221b127.API.Personnel.Application.Internal.QueryServices;
using si730ebu20221b127.API.Personnel.Domain.Repositories;
using si730ebu20221b127.API.Personnel.Domain.Services;
using si730ebu20221b127.API.Personnel.Infrastructure.Persistence.EFC.Repositories;
using si730ebu20221b127.API.Personnel.Interfaces.ACL;
using si730ebu20221b127.API.Personnel.Interfaces.ACL.Services;
using si730ebu20221b127.API.Shared.Domain.Repositories;
using si730ebu20221b127.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using si730ebu20221b127.API.Shared.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers( options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Database Context and Logging Levels

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "HIGNPlatform.API",
                Version = "v1",
                Description = "HIGN Center Platform API",
                TermsOfService = new Uri("https://hign-center.com/tos"),
                Contact = new OpenApiContact
                {
                    Name = "HIGN Studios",
                    Email = "contact@hign.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
        c.EnableAnnotations();
    });

// Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Add CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Configure Dependency Injection

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Personnel Bounded Context Injection Configuration
builder.Services.AddScoped<IExaminerRepository, ExaminerRepository>();
builder.Services.AddScoped<IExaminerCommandService, ExaminerCommandService>();
builder.Services.AddScoped<IExaminerQueryService, ExaminerQueryService>();
builder.Services.AddScoped<IPersonnelContextFacade, PersonnelContextFacade>(); // ACL Context Facade

// Assessment Bounded Context Injection Configuration
builder.Services.AddScoped<IMentalStateExamRepository, MentalStateExamRepository>();
builder.Services.AddScoped<IMentalStateExamCommandService, MentalStateExamCommandService>();
builder.Services.AddScoped<IMentalStateExamQueryService, MentalStateExamQueryService>();
builder.Services.AddScoped<ExternalPersonnelService>(); // ACL External Service

var app = builder.Build();

// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();