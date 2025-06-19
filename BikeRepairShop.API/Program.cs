using BikeRepairShop.API.Contexts;
using BikeRepairShop.API.Data;
using BikeRepairShop.API.Helpers;
using BikeRepairShop.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

if (!builder.Environment.IsDevelopment())
{
    builder.Services.AddHttpsRedirection(options =>
    {
        options.HttpsPort = 443;
    });
}

builder.Services.AddDbContext<CustomDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<BookingHandler>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<CustomerHandler>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<BikeBrandHandler>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy
            .WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

if (builder.Environment.IsEnvironment("Docker"))
{
    builder.WebHost.UseUrls("http://+:80");
}
else
{
    builder.Services.AddHttpsRedirection(options =>
    {
        options.HttpsPort = 443;
    });
}

var app = builder.Build();

if (!app.Environment.IsEnvironment("Docker"))
{
    app.UseHttpsRedirection();
}
//app.UseHttpsRedirection();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.UseRouting();
app.UseCors("AllowFrontend");
app.Run();
