using BikeRepairShop.API.Contexts;
using BikeRepairShop.API.Data;
using BikeRepairShop.API.Helpers;
using BikeRepairShop.API.Models.Dtos;
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
builder.Services.AddScoped<IBikeRepairBookingService, BikeRepairBookingService>();
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

// Usage of minimal api for booking instead of controller :) 
//TODO do for othe controllers as well

var bookings = app.MapGroup("/api/bookings").WithTags("bookings");

bookings.MapGet("/{id:int}", async (int id, IBikeRepairBookingService bookingService, ILoggerFactory loggerFactory) =>
{
    var loggger = loggerFactory.CreateLogger(nameof(bookingService));
    try
    {
        loggger.LogInformation("getting booking");
        var booking = await bookingService.GetBookingByIdAsync(id);

        return Results.Ok(booking);
    }
    catch(Exception ex)
    {
        loggger.LogError(ex.Message);
        return Results.NotFound();
    }
});

bookings.MapGet("/", async (IBikeRepairBookingService bookingService, ILoggerFactory loggerFactory) =>
{
    var logger = loggerFactory.CreateLogger(nameof(bookingService));
    try
    {
        logger.LogInformation("getting all booking");
        var bookings = await bookingService.GetAllBookingsAsync();
        return Results.Ok(bookings);    
    }
    catch(Exception ex)
    {
        logger.LogError(ex.Message);
        return Results.NotFound(ex.Message);
    }
});

bookings.MapPost("/", async (BikeRepairBookingCreateDto bookingCreateDto,IBikeRepairBookingService bookingService, ILoggerFactory loggerFactory) =>
{
    var logger = loggerFactory.CreateLogger(nameof(BikeRepairBookingService));

    try
    {
        logger.LogInformation("adding a booking");
        await bookingService.AddBookingAsync(bookingCreateDto);
        return Results.Ok();
    }
    catch(Exception ex)
    {
        logger.LogError(ex.Message);
        return Results.BadRequest();
    }
});

app.MapPut("/", async (BikeRepairBookingDto bookingDto, IBikeRepairBookingService bookingService, ILoggerFactory loggerFactory) =>
{
    var logger = loggerFactory.CreateLogger(typeof(BikeRepairBookingService));
    try
    {
        logger.LogInformation("updating booking");

        await bookingService.UpdateBookingAsync(bookingDto);
        return Results.Ok();
    }
    catch(Exception ex)
    {
        logger.LogError(ex.Message);
        return Results.BadRequest(ex.Message);
    }
});

app.MapDelete("/{id:int}", async (int id, IBikeRepairBookingService bookingService, ILoggerFactory loggerFactory) =>
{
    var logger = loggerFactory.CreateLogger("nameof(booking)");
    try
    {
        logger.LogInformation("Deleting bookings");
        await bookingService.DeleteBookingAsync(id);
        return Results.Ok($"Booking with id {id} deleted");
    }
    catch (Exception ex)
    {
        logger.LogError(ex.Message);
        return Results.BadRequest(ex.Message);
    }
});

app.Run();
