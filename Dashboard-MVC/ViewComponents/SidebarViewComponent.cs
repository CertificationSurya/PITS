using Microsoft.AspNetCore.Mvc;

namespace Dashboard_MVC.ViewComponents;

public class SidebarViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        Console.WriteLine("Sidebar invoked");
        // not mentioned? goes for Default.cshtml
        return View("Sidebar");
    }
}