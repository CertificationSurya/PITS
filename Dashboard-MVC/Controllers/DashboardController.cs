using Microsoft.AspNetCore.Mvc;

namespace Dashboard_MVC.Controllers;

public class DashboardController : Controller
{

    public IActionResult Index()
    {
        // return RedirectToAction("Auth", "Auth");

        return View();
    }

}
