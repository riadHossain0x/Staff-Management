using Microsoft.EntityFrameworkCore;
using Staff.Infrustructure.DbContexts;
using Staff.Infrustructure.Repositories;
using Staff.Infrustructure.UnitOfWorks;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var assemblyName = typeof(Program).Assembly.FullName;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EmployeeDbContext>(options =>
{
    options.UseSqlServer(connectionString, m => m.MigrationsAssembly(assemblyName));
});

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeDbContext, EmployeeDbContext>();
builder.Services.AddScoped<IEmployeeUnitOfWork, EmployeeUnitOfWork>();

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
