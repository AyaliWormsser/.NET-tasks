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
        builder.WithOrigins("http://localhost:3000") // כתובת ה-Origin ללא סלאש בסוף
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials(); // אם יש צורך
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

app.UseRouting(); // הוספת UseRouting לפני UseCors

app.UseCors("AllowAllOrigins"); // השתמש בפוליסה בשם הנכון

app.UseAuthorization();

app.MapControllers();

app.Run();
