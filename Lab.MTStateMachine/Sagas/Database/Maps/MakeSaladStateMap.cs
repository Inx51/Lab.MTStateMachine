using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab.MTStateMachine.Sagas.Database.Maps;

public class MakeSaladStateMap : SagaClassMap<MakeSaladState>
{
    protected override void Configure(EntityTypeBuilder<MakeSaladState> entity, ModelBuilder model)
    {
        entity.Property(x => x.CurrentState).HasMaxLength(64);
        entity.Property(x => x.VegId).IsRequired(false);
        entity.Property(x => x.SaladeEventStatus).IsRequired();

        // If using Optimistic concurrency, otherwise remove this property
        entity.Property(x => x.RowVersion).IsRowVersion().IsRequired(false);
    }
}