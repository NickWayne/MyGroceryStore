using Microsoft.EntityFrameworkCore;
using MyGroceryStore.BusinessLogic.Interfaces;
using MyGroceryStore.BusinessLogic.Services;
using MyGroceryStore.DataAccess;
using MyGroceryStore.WebAPI.Helpers;
using MyGroceryStore.WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ISeedDataService, SeedDataService>();

builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IDepartmentService, DepartmentService>();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IProductService,  ProductService>();

builder.Services.AddDbContext<GroceryDbContext>(opt =>
    opt.UseInMemoryDatabase("GroceryDatabase"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.SeedData();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
