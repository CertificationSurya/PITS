using Microsoft.AspNetCore.Mvc;

namespace Dashboard_MVC.ViewComponents;

public class SidebarViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        // not mentioned? goes for Default.cshtml
        return View("Sidebar");
    }
}