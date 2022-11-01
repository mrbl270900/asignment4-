using DataLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper();
builder.Services.AddSingleton<IDataService, DataService>();

var app =  builder.Build();

app.MapControllers();

app.Run();