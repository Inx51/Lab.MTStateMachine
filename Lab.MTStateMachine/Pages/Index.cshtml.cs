using Lab.MTStateMachine.Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab.MTStateMachine.Pages;
[IgnoreAntiforgeryToken(Order = 1001)]
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IBus _bus;

    public IndexModel(ILogger<IndexModel> logger, IBus bus)
    {
        _logger = logger;
        _bus = bus;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    public async Task<IActionResult> OnPost(string button)
    {
        if (button == "Chop Tomato")
        {
            var chopTomato = new ChopTomato
            {
                TomatoId = Request.Form["Tomato"]!
            };
            var sendEndpoint = await _bus.GetSendEndpoint(ChopTomato.SendEndpoint);
            await sendEndpoint.Send(chopTomato);
        }
        
        if (button == "Chop Cucumber")
        {
            var chopCucumber = new ChopCucumber
            {
                CucumberId = Request.Form["Cucumber"]!
            };
            var sendEndpoint = await _bus.GetSendEndpoint(ChopCucumber.SendEndpoint);
            await sendEndpoint.Send(chopCucumber);
        }
        
        return Page();
    }
}