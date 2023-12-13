using Lab.MTStateMachine.Contracts;
using Lab.MTStateMachine.Contracts.Events;
using MassTransit;

namespace Lab.MTStateMachine.Consumers;

public class ChopCucumberConsumer : IConsumer<ChopCucumber>
{
    private readonly ILogger<ChopCucumberConsumer> _logger;
    
    public ChopCucumberConsumer(ILogger<ChopCucumberConsumer> logger)
    {
        _logger = logger;
    }
    
    public Task Consume(ConsumeContext<ChopCucumber> context)
    {
        _logger.LogInformation($"Cucumber with id: {context.Message.CucumberId} has been chopped!");
        var cucumberChopped = new CucumberChopped
        {
            CucumberId = context.Message.CucumberId
        };
        context.Publish(cucumberChopped);
        return Task.CompletedTask;
    }
}

public class ChopCucumberConsumerDefinition : ConsumerDefinition<ChopCucumberConsumer>
{
    public ChopCucumberConsumerDefinition()
    {
        EndpointName = ChopCucumber.SendEndpoint.AbsolutePath;
        
        ConcurrentMessageLimit = 4;
    }
}