using ToDoListAPI.Data;
using ToDoListAPI.Services.StatusService;
using ToDoListAPI.Services.TasksService;
using ToDoListAPI.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<ToDoListDB>();

builder.Services.AddScoped<ITasksService, TasksService>();
builder.Services.AddScoped<IStatusService, StatusService>();
builder.Services.AddScoped<IValidator, Validators>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors(options => {
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

app.MapControllers();

app.Run();
