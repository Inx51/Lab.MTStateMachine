namespace Lab.MTStateMachine.Contracts;

public class ChopCucumber
{
    public static Uri SendEndpoint = new Uri("queue:ChopCucumber");
    
    public string CucumberId { get; set; }
}