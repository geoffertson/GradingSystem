using Assessment.Application.Interfaces;
using Assessment.Application.UseCases.FinalizeGrade;
using Assessment.Infrastructure.Messaging;
using Assessment.Infrastructure.Persistence;
using Assessment.Infrastructure.Repositories;
using BuildingBlocks.Application;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Ef Core
builder.Services.AddDbContext<AssessmentDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Application services
builder.Services.AddScoped<FinalizeGradeHandler>();

// Infrastructure bindings
builder.Services.AddScoped<IGradeRepository, GradeRepository>();
builder.Services.AddScoped<IUnitOfWork, AssessmentDbContext>();
builder.Services.AddScoped<IEventPublisher, DomainEventPublisher>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
