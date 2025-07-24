using Domain.Models;
using Application.Interfaces;
using Application.Services;     
using Microsoft.OpenApi.Models;
using Application;
using Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// ���������� ��������� ��
builder.Services.AddDatabaseContext();

// ���������� ������������
builder.Services.AddRepositories();

// ���������� �������
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookAPI", Version = "v1" });

    //Optional - ���������� ���������� �� �����������, ���� ���������
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

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
