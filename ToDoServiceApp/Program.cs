using Microsoft.EntityFrameworkCore;
using ToDoServiceApp.Business.Handlers;
using ToDoServiceApp.DataService.DataConection;
using ToDoServiceApp.DataService.ModelsSql;
using ToDoServiceApp.DataService.Utils;

var builder = WebApplication.CreateBuilder(args);
var securedOrigins = "_securedOrigins";
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddEntityFrameworkSqlServer();

// Create instancias dependency injection
builder.Services.AddScoped<ITodoListHandler, ToDoListHandler>();
builder.Services.AddScoped<ITodoListItemHandler, ToDoListItemHandler>();
builder.Services.AddScoped<ITodoListRepository<TodoObject>, TodoListRepository>();
builder.Services.AddScoped<ITodoListItemRepository<TodoItem>, TodoListItemRepository>();

builder.Services.AddDbContextPool<ToDoContext>(options => options.UseSqlServer(Utils.GetConectionString(configuration)));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: securedOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                      });
});

var app = builder.Build();

// global cors policy
app.UseCors(securedOrigins); // allow credentials

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
