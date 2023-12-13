using Lab.MTStateMachine.Contracts.Events;
using MassTransit;
using MassTransit.Internals;

namespace Lab.MTStateMachine.Sagas;

public class MakeSaladSaga : MassTransitStateMachine<MakeSaladState>
{
    public State TomatoAdded { get; set; }
    public State CucumberAdded { get; set; }
    public State SaladDone { get; set; } 
    
    public Event<TomatoChopped> TomatoChopped { get; set; } 
    public Event<CucumberChopped> CucumberChopped { get; set; }

    public Event SaladCreated { get; set; }
    
    public MakeSaladSaga(ILogger<MakeSaladSaga> logger)
    {
        InstanceState(x => x.CurrentState, TomatoAdded, CucumberAdded, SaladDone);
        
        Event(() => TomatoChopped, e => e
            .CorrelateBy(i => i.VegId, x => x.Message.TomatoId)
            .SelectId(x => x.CorrelationId ?? NewId.NextGuid()));
        
        Event(() => CucumberChopped, e => e
            .CorrelateBy(i => i.VegId, x => x.Message.CucumberId)
            .SelectId(x => x.CorrelationId ?? NewId.NextGuid()));
        
        Initially(
            When(TomatoChopped)
                .Then(x => x.Saga.VegId = x.Message.TomatoId)
                .Then(x => logger.LogInformation($"Adding tomato from id:{x.Message.TomatoId}"))
                .TransitionTo(TomatoAdded),
            When(CucumberChopped)
                .Then(x => x.Saga.VegId = x.Message.CucumberId)
                .Then(x => logger.LogInformation($"Adding cucumber from id:{x.Message.CucumberId}"))
                .TransitionTo(CucumberAdded)
        );
        
        //Could this be rewritten as a composite event?
        During(TomatoAdded,
            When(CucumberChopped)
                .TransitionTo(SaladDone));
        
        During(CucumberAdded,
            When(TomatoChopped)
                .TransitionTo(SaladDone));
        ////
        
        //If yes, then how?
        CompositeEvent(() => SaladCreated, x => x.SaladeEventStatus, CucumberChopped, TomatoChopped);

        WhenEnter(SaladDone, x => x
            .Then(_ => logger.LogInformation("SALAD DONE!"))
            .Finalize());
        
        SetCompletedWhenFinalized();
    }
}

public class MakeSaladState : SagaStateMachineInstance
{
    public Guid CorrelationId { get; set; }
    public int CurrentState { get; set; }
    public int SaladeEventStatus { get; set; }
    
    public string? VegId { get; set; }
    
    public byte[]? RowVersion { get; set; }
}