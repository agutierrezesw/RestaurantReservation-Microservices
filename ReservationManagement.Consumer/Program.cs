using ReservationManagement.Application;
using ReservationManagement.Infrastructure;
using RestaurantReservation.Core.Consumer;
using RestaurantReservation.Core.Events;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddEventInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddEventProcessorWorker(builder.Configuration);

var host = builder.Build();
host.Run();