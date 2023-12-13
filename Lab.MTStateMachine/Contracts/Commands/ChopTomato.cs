namespace Lab.MTStateMachine.Contracts;

public class ChopTomato
{
    public static Uri SendEndpoint = new Uri("queue:ChopTomato");
    
    public string TomatoId { get; set; }
}