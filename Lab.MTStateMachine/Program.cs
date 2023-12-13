using System.Reflection;
using Lab.MTStateMachine.Sagas;
using Lab.MTStateMachine.Sagas.Database;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMassTransit(config =>
{
    config.UsingInMemory((ctx, busConfig) =>
    {
        busConfig.ConfigureEndpoints(ctx);
    });
    
    config.AddConsumers(typeof(Program).Assembly);
    
    config.AddSagaStateMachine<MakeSaladSaga, MakeSaladState>()
        .InMemoryRepository();
        // .EntityFrameworkRepository(r =>
        // {
        //     r.ConcurrencyMode = ConcurrencyMode.Optimistic; // or use Pessimistic, which does not require RowVersion
        //
        //     r.AddDbContext<DbContext, MakeSaladStateContext>((provider,builder) =>
        //     {
        //         builder.UseSqlite($"Data Source={AppContext.BaseDirectory}/state.db", m =>
        //         {
        //             m.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
        //             m.MigrationsHistoryTable($"__{nameof(MakeSaladStateContext)}");
        //         });
        //     });
        // });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

partial class Program
{
    
}