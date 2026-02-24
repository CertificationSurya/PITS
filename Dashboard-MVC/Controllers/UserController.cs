using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Dashboard_MVC.Models;
using Dashboard_MVC.Services;

namespace Dashboard_MVC.Controllers;

public class UserController : Controller
{

    // create form page
    public IActionResult Create()
    {
        ViewBag.Roles = new SelectList(new[] { "Student", "Admin", "Teacher" });
        return View();
    }
    
    // update form page
    [HttpGet("User/Update/{uuid}")]
    public IActionResult Update(string uuid)
    {
        ViewBag.Roles = new SelectList(new[] { "Student", "Admin", "Teacher" });
        UserViewModel user = UserStore.GetUserByUuid(uuid);
        return View(user);
    }

    
    // all user page
    public IActionResult ShowAllUser()
    {
        var users = UserStore.GetAllUser();
        return View(users);
    }
        

    [HttpPost("User/Update/{uuid}")]
    public IActionResult Update(string uuid, UserViewModel model)
    {
        Console.WriteLine("working");
        if (!ModelState.IsValid)
            return View(model);

        model.Uuid = uuid;

        // storing in list
        UserStore.UpdateUser(model);

        // direct to view without its controller
        return View("~/Views/Message/Updated.cshtml", model);
    }

    [HttpPost]
    public IActionResult Create(UserViewModel model)
    {
        ViewBag.Roles = new SelectList(new[] { "Student", "Admin", "Teacher" });
        if (!ModelState.IsValid)
            return View(model);

        // storing in list
        UserStore.AddUser(model);

        // direct to view without its controller
        return View("~/Views/Message/Index.cshtml", model);
    }

}
