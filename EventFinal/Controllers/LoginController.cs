using EventFinal.Repositories;
using EventFinal.ViewModel;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace EventFinal.Controllers
{
    public class LoginController : Controller
    {
        public IConfiguration Config = null;
        private readonly ILoginRepository repos;
        // private readonly ILoginRepository repo;
      //  private readonly ILogger<LoginController> logger;
        public LoginController(ILogger<LoginController> logger, IConfiguration configuration, ILoginRepository loginRepository)
        {
            Config = configuration;
            repos = loginRepository;
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            //if (HttpContext.Session.IsAvailable)
            //{
            //    string RoleID = HttpContext.Session.GetString("RoleID");
            //    if (RoleID != null)
            //    {
            //        return UserRedirectToDashBoard(int.Parse(RoleID));
            //    }
            //}
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                //  model.Password = EncryptionLibrary
                // model.Password = EncryptionLibrary.EncryptText(model.Password);
                // EncryptionLibrary.EncryptText

                var result = repos.Login(model.Username, model.Password);
                if (result != null)
                {
                    if (result.ID == 0 || result.ID < 0)
                    {
                        ViewBag.msg = "Enter Innvalid Username And Password";
                    }
                    else
                    {
                        // var RoleID = result.ID;
                        // HttpContext.Session.SetString("ID", Convert.ToString(result.ID));
                        //  HttpContext.Session.SetString("RoleID", Convert.ToString(result.RoleID));
                        ViewBag.alertmsg = "Login SuccessFully";
                        
                        return RedirectToAction("Registration", "Registration");

                    }
                   
                }
                else
                {
                    ViewBag.msg = "Invalid Username And Password";
                    return View();
                }
            }
            return View();
        }

        private RedirectToActionResult UserRedirectToDashBoard(int? RoleID)
        {
            string ActionName = string.Empty;
            if (RoleID == 1)
            {
                ActionName = "Admin";
            }
            else if (RoleID == 2)
            {
                ActionName = "CustomerDashBoard";
            }
            else if (RoleID == 3)
            {
                ActionName = "SuperAdmin";
            }
            return RedirectToAction("Index", ActionName);
        }
    }
}
