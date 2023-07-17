using Microsoft.EntityFrameworkCore;
using WebApiToDo.Repository;
using WebApiToDo.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddTransient<IWebApiToDoRepository, WebApiToDoRepository>();
builder.Services.AddTransient<IWebApiToDoService, WebApiToDoService>();

builder.Services.AddTransient<ITasksNotesRepository, TasksNotesRepository>();
builder.Services.AddTransient<ITasksNotesService, TasksNotesService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ToDoTaskAPIDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
