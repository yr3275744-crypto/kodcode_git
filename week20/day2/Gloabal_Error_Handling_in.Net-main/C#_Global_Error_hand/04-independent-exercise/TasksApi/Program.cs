using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json.Serialization;
using TasksApi.Middelware;
using TasksApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers().AddJsonOptions(x =>
x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ITaskRepository, TaskRepository>();
//builder.Services.AddSingleton<ExceptionHandlerMiddleware>
builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ExceptionHandlingMiddelware>();
app.MapControllers();

app.Run();

