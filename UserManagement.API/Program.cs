using UserManagement.API.RouteHandlerExtensions;
using UserManagement.Application;
using UserManagement.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add application injections
builder.Services.AddApplication();
// Add infrastructure injections
builder.Services.AddInfrastructure(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // REMARK: Uncomment if you want to apply migrations automatically.
    //app.ApplyMigrations();

    // REMARK: Uncomment if you want to seed initial data.
    //app.SeedData();
}

app.UseHttpsRedirection();

app.AddMinimalAPIRouteHandlerMappings();

app.Run();

