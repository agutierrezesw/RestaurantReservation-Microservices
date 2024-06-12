using UserManagement.API.RouteHandlerExtensions;
using UserManagement.Application;
using UserManagement.Infrastructure;
using UserManagement.Infrastructure.DataSeeds;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add application injections
builder.Services.AddApplication();
// Add infrastructure injections
builder.Services.AddInfrastructure(builder.Configuration);

// builder.WebHost.ConfigureKestrel(options =>
// {
//     options.ListenAnyIP(5000); // HTTP:localhost:5000 /swager/
//     options.ListenAnyIP(5001, listenOptions => listenOptions.UseHttps()); // HTTPS
// });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // Uncomment if you want to apply migrations automatically.
    //app.ApplyMigrations();

    // Uncomment if you want to seed initial data.
    app.SeedData(builder.Services);
}

app.UseHttpsRedirection();

app.AddMinimalAPIRouteHandlerMappings();

app.Run();

