using Microsoft.OpenApi.Models;
using Web.Api.Controllers;
using Web.Api.Services.Abstract;
using Web.Api.Services.Implementations;
using Store.DI;
using Web.Api.Infrastructure.Automapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IQuestionCardsService, QuestionCardsService>();

var connectionString = builder.Configuration.GetConnectionString("Default")
                                ?? throw new ArgumentNullException("Connection string is null");

builder.Services.AddAutoMapper(x => x.AddProfile<ApiProfile>());

builder.Services.AddStoreServices(connectionString);

builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{typeof(QuestionCardsController).Assembly.GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    c.IncludeXmlComments(xmlPath);

    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Demo API",
        Version = "v1"
    });
}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
