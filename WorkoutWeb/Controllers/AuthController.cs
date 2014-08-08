using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WorkoutWeb.Helpers;
using WorkoutWeb.Models;

namespace WorkoutWeb.Controllers
{
  public class AuthController : Controller
  {
    //
    // GET: /Auth/

    public ActionResult Index()
    {
      return View();
    }

    public ActionResult Logoff()
    {
      FormsAuthentication.SignOut();
      return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public ActionResult Logon()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Logon(Logon model)
    {
      if (ModelState.IsValid)
      {
        try
        {
          var validated = AuthHelper.ValidateUser(model.UserName, model.Password);
          if (validated)
          {
            FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
          }
          else
          {
            ModelState.AddModelError(String.Empty, "Wrong Password..");
            return View(model);
 
          }
        }
        catch (WorkoutWeb.Helpers.UserNotFoundException)
        {
          ModelState.AddModelError(string.Empty, "User not found..");
          
           return View(model);
        }
        return RedirectToAction("Index","Home");
      }
      return View(model);
    }
  }
}
