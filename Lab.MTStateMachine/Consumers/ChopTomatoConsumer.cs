using Lab.MTStateMachine.Contracts;
using Lab.MTStateMachine.Contracts.Events;
using MassTransit;

namespace Lab.MTStateMachine.Consumers;

public class ChopTomatoConsumer : IConsumer<ChopTomato>
{
    private readonly ILogger<ChopTomatoConsumer> _logger;
    
    public ChopTomatoConsumer(ILogger<ChopTomatoConsumer> logger)
    {
        _logger = logger;
    }
    
    public Task Consume(ConsumeContext<ChopTomato> context)
    {
        _logger.LogInformation($"Tomato with id: {context.Message.TomatoId} has been chopped!");
        var tomatoChopped = new TomatoChopped
        {
            TomatoId = context.Message.TomatoId
        };
        context.Publish(tomatoChopped);
        return Task.CompletedTask;
    }
}

public class ChopTomatoConsumerDefinition : ConsumerDefinition<ChopTomatoConsumer>
{
    public ChopTomatoConsumerDefinition()
    {
        EndpointName = ChopTomato.SendEndpoint.AbsolutePath;

        ConcurrentMessageLimit = 4;
    }
}