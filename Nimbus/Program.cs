using AutoYa_Backend.AutoYa.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Nimbus.Nimbus.Domain.Repositories;
using Nimbus.Nimbus.Domain.Services;
using Nimbus.Nimbus.Persistence.Repositories;
using Nimbus.Nimbus.Services;
using Nimbus.Shared.Persistance.Contexts;
using Nimbus.Shared.Persistance.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




//ADD Database Connection MYSQL

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(
    options=>options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine,LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());


//Add lowercase routes

builder.Services.AddRouting(options => options.LowercaseUrls = true);


//shared Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Dependency Injection CONFIGURATION

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProveedorRepository, ProveedorRepository>();

builder.Services.AddScoped<IProveedorService, ProveedorServices>();
builder.Services.AddScoped<ICategoryService, CategoryServices>();
builder.Services.AddScoped<IProductService, ProductServices>();

//AutoMapper Configuration



builder.Services.AddAutoMapper(

    typeof(Nimbus.Nimbus.Mapping.ModelToResourceProfile),
    typeof(Nimbus.Nimbus.Mapping.ResourceToModelProfile));

var app = builder.Build();

//Validation FOR ensuring Database Objects are created

using(var scope=app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("v1/swagger.json", "v1");
        options.RoutePrefix = "swagger";
        
    });
}

// Configure CORS
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();











