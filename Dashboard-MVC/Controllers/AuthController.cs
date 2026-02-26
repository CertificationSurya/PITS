using Microsoft.AspNetCore.Mvc;

namespace Dashboard_MVC.Controllers;


public class AuthController : Controller {

    public IActionResult Auth(){
        return View("Login");
    }

}