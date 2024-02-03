using ECommerceSample.Filters;
using ECommerceSample.Middlewares;
using ECommerceSampleClassLibrary.Context;
using ECommerceSampleClassLibrary.Domains;
using ECommerceSampleClassLibrary.Implementations;
using ECommerceSampleClassLibrary.Interfaces;
using ECommerceSampleClassLibrary.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers();

//registering filters
builder.Services.AddMvc(options =>
{
    options.Filters.Add<InventoryCheckFilter>();
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//registering dependencies
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IRepository<Product>, Repository<Product>>();
builder.Services.AddScoped<IRepository<Customer>, Repository<Customer>>();
builder.Services.AddScoped<IRepository<Order>, Repository<Order>>();
builder.Services.AddScoped<IRepository<Category>, Repository<Category>>();
builder.Services.AddScoped<IRepository<OrderProduct>, Repository<OrderProduct>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//applying migrations
void ApplyMigration()
{
    using (var scope = app?.Services.CreateScope())
    {
        var _db = scope?.ServiceProvider.GetRequiredService<AppDbContext>();

        if (_db?.Database.GetPendingMigrations().Count() > 0)
        {
            _db.Database.Migrate();
        }
    }
}

ApplyMigration();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseEntityNotFoundMiddleware(); //custom middleware to display error

app.MapControllers();

app.Run();
