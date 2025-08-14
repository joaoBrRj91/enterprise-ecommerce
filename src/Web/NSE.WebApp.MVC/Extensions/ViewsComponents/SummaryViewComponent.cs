using Microsoft.AspNetCore.Mvc;

namespace NSE.WebApp.MVC.Extensions.ViewsComponents;

public class SummaryViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View();
    }
}