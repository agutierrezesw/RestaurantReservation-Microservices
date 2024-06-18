using Confluent.Kafka;
using MediatR;
using ReservationManagement.Application;
using ReservationManagement.Consumer;
using ReservationManagement.Infrastructure;
using RestaurantReservation.Core.Events;
using RestaurantReservation.Core.Events.Contracts;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddEventInfrastructure(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddHostedService<Worker>(serviceProvider => new Worker(
    logger: serviceProvider.GetRequiredService<ILogger<Worker>>(),
    builder: serviceProvider.GetRequiredService<ConsumerBuilder<Null, IIntegrationEvent>>(),
    mediator: serviceProvider.GetRequiredService<IMediator>(),
    topic: builder.Configuration["ApacheKafka:SubscribedTopic"]!
));


var host = builder.Build();
host.Run();