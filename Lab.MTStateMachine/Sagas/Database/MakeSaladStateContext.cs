using Lab.MTStateMachine.Sagas.Database.Maps;
using MassTransit.EntityFrameworkCoreIntegration;
using Microsoft.EntityFrameworkCore;

namespace Lab.MTStateMachine.Sagas.Database;

public class MakeSaladStateContext : SagaDbContext
{
    public MakeSaladStateContext(DbContextOptions options) : base(options)
    {
    }

    protected override IEnumerable<ISagaClassMap> Configurations 
    {
        get { yield return new MakeSaladStateMap(); }
    }
}