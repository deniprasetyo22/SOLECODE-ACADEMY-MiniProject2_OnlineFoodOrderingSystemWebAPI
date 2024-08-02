using Microsoft.OpenApi.Models;
using MiniProject2_OnlineFoodOrderingSystemWebAPI.Interfaces;
using MiniProject2_OnlineFoodOrderingSystemWebAPI.Models;
using MiniProject2_OnlineFoodOrderingSystemWebAPI.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IOrderService, OrderService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Swagger Documentation Section
var info = new OpenApiInfo()
{
    Title = "MiniProject2_OnlineFoodOrderingSystemWebAPI",
    Version = "v1",
    Description = "MiniProject2_OnlineFoodOrderingSystemWebAPI",
    Contact = new OpenApiContact()
    {
        Name = "Deni Prasetyo",
        Email = "deni.prasetyo@solecode.id",
    }

};

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", info);

    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(u =>
    {
        u.RouteTemplate = "swagger/{documentName}/swagger.json";
    });

    app.UseSwaggerUI(c =>
    {
        c.RoutePrefix = "swagger";
        c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Your API Title or Version");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
