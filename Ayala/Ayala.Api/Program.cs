using Ayala.Data.Repositories;
using Ayala.Data;
using Ayala.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<Ayala.Core.Services.ITaskService, TaskService>();
builder.Services.AddScoped<Ayala.Core.Repositories.ITaskRepository, TaskRepository>();
builder.Services.AddDbContext<DataContext>();

// Add CORS policy with a name
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.WithOrigins("http://localhost:3000") // ����� �-Origin ��� ���� ����
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials(); // �� �� ����
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting(); // ����� UseRouting ���� UseCors

app.UseCors("AllowAllOrigins"); // ����� ������� ��� �����

app.UseAuthorization();

app.MapControllers();

app.Run();
