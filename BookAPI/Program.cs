using Domain.Models;
using Application.Interfaces;     
using Microsoft.OpenApi.Models;
using Application;
using Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// ���������� ��������� ��
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDatabaseContext(connectionString);

// ���������� ������������
builder.Services.AddRepositories();

// ���������� �������
builder.Services.AddSwaggerGen();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// ������� BookService
// builder.Services.AddScoped<IBookService, BookService>();

//���������� ��������
builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{ 
    app.MapOpenApi();

    //���������� ��������
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookAPI");
        c.RoutePrefix = string.Empty; // ����� Swagger UI ���������� � ����� ����������
    });
}

// ������� �������� ��� �����������
app.MapGet("/api/hello", () => "Hello, Backend!");

app.MapGet("/api/info", () => "This is CRUD API for library");


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
