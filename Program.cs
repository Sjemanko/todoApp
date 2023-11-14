global using todoApp.Models;
global using todoApp.Services.TodoItemsService;
global using todoApp.Dtos.TodoItem;
global using Microsoft.EntityFrameworkCore;
global using todoApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);


builder.Services.AddScoped<ITodoItemsService, TodoItemsService>(); // DI registration to TodoItemService (we can change service classes with ITodoItemsService there)

// builder.Services.AddTransient<ITodoItemsService, TodoItemsService>(); // Provides new instance to every controller and every service, even within the same request

// builder.Services.AddSingleton<ITodoItemsService, TodoItemsService>(); // Creates only one instance used for every request

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
