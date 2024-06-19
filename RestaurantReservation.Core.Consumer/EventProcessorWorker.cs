using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RestaurantReservation.Core.Events.Contracts;

namespace RestaurantReservation.Core.Consumer;

using MediatR;
using ConsumerBuilder =
    Confluent.Kafka.ConsumerBuilder<Confluent.Kafka.Null,
        Events.Contracts.IIntegrationEvent>;

/// <summary>
/// Event consumer
/// </summary>
public class EventProcessorWorker(
    ILogger<EventProcessorWorker> logger, 
    ConsumerBuilder builder,
    IServiceScopeFactory serviceScopeFactory,
    string topic) : BackgroundService
{
 
    /// <summary>
    /// Read events from kafka cluster and dispatch it as Mediator notifications
    /// </summary>
    /// <param name="stoppingToken"></param>
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var consumer = builder.Build();
        consumer.Subscribe(topic);
        while (!stoppingToken.IsCancellationRequested)
        {
            logger.LogInformation("Waiting for event messages at topic {topic}", topic);

            var consumeResult = consumer.Consume(stoppingToken);
            if (consumeResult is null) continue;

            logger.LogInformation(
                "Event received with timestamp {timestamp}",
                consumeResult.Message.Timestamp
            );
            
            ProcessEvent(consumeResult.Message.Value, stoppingToken);
        }

        consumer.Close();

        return Task.FromCanceled(stoppingToken);
    }

    /// <summary>
    /// Dispatch event to a scoped mediator instance
    /// </summary>
    /// <param name="event"></param>
    /// <param name="stoppingToken"></param>
    private async void ProcessEvent(IIntegrationEvent @event, CancellationToken stoppingToken)
    {
        logger.LogInformation(
            "Dispatching event handler in thread {thread}", 
            Thread.CurrentThread.ManagedThreadId
        );

        using var scope = serviceScopeFactory.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        
        try
        {
            await mediator.Publish(@event, stoppingToken);
        }
        catch(Exception e)
        {
            logger.LogError(e, "Error during event handler execution");  
        }
    }
}