using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Dashboard_MVC.Models;
using Dashboard_MVC.Services.Interfaces;


namespace Dashboard_MVC.Controllers;

public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController (IUserService userService){
        _userService = userService;
    }

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
        UserViewModel user = _userService.GetUserByUuid(uuid);
        return View(user);
    }

    
    // all user page
    public IActionResult ShowAllUser()
    {
        var users = _userService.GetAllUser();
        return View(users);
    }

     

    [HttpPost]
    public IActionResult Create(UserViewModel model)
    {
        Console.WriteLine("working");
        ViewBag.Roles = new SelectList(new[] { "Student", "Admin", "Teacher" });
        
        if (!ModelState.IsValid){
            return View(model);
        }

        // storing in list
        _userService.AddUser(model);

        // direct to view without its controller
        return View("CreateSuccess", model);
    }   



    [HttpPost("User/Update/{uuid}")]
    public IActionResult Update(string uuid, UserViewModel? model)
    {
        try{

            if (!ModelState.IsValid)
                return View(model);

            model.Uuid = uuid;

            // storing in list
            _userService.UpdateUser(model);

        }
        catch (Exception e) {
            Console.WriteLine("ee");
        }
        return View("UpdateSuccess", model);
    }

    // TODO: check dis, no disk space PC

    [HttpPost("User/ChangeStatus/{uuid}")]
    public IActionResult ChangeStatus(string uuid, UserViewModel? model)
    {
        try{
            _userService.ChangeUserStatus(uuid);
            UserViewModel user = _userService.GetUserByUuid(uuid);
            return View("UpdateSuccess", user);
        }
        catch (Exception e) {
            Console.WriteLine("ee");
        }
        
        // direct to view without its controller
        return View("UpdateSuccess", model);
    }
}
