using BusinessLogic.Interface;
using BusinessLogic.Services;
using DataAccess.DataContext;
using DataAccess.Interface;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);










// Add services to the container.
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserData, UserData>();

builder.Services.AddScoped<IRecipieService, RecipieService>();
builder.Services.AddScoped<IRecipieData, RecipieData>();



var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var connectionString = configuration.GetConnectionString("RecipieDb");
builder.Services.AddDbContext<RecipieDbContext>(options => options.UseSqlServer(connectionString).EnableSensitiveDataLogging());

builder.Services.AddAutoMapper(typeof(RecipieDbContext));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
    policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
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

app.UseAuthorization();
app.UseCors();  


app.MapControllers();

app.Run();
