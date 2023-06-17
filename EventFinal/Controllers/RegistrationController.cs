using EventFinal.Models;
using EventFinal.Repositories;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EventFinal.Controllers
{
    [AllowAnonymous]
    public class RegistrationController : Controller
    {
        IRegistrationRepository _registrationRepository;
        IDropdownCommonRepository _dropdownCommonRepository;
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public RegistrationController(ILogger<HomeController> logger,
            IRegistrationRepository registrationRepository, IDropdownCommonRepository dropdownCommonRepository,
            IConfiguration configuration)
        {
            _logger = logger;
            _registrationRepository = registrationRepository;
            _configuration = configuration;
            _dropdownCommonRepository = dropdownCommonRepository;
        }

        public ActionResult Registration()
        {
            try
            {
               // AddCookie_For_API_Validation(4); //Anonymous 
                List<SelectListItem> _countrylist = _dropdownCommonRepository.GetCountry()
               .Select(n =>
               new SelectListItem
               {
                   Value = Convert.ToString(n.CountryID),
                   Text = n.Name
               }).ToList();
                var selectListItem = new SelectListItem()
                {
                    Value = null,
                    Text = "--- select country ---"
                };
                _countrylist.Insert(0, selectListItem);
                TempData["country"] = _countrylist;
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

 

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Registration(Registration registration)
        {
            try
            {
                if (registration != null)
                {
                   // registration.Password = EncryptionLibrary.EncryptText(registration.Password);
                   // registration.ConfirmPassword = EncryptionLibrary.EncryptText(registration.ConfirmPassword);
                    var result = _registrationRepository.CreateUser(registration);
                    return RedirectToAction("Login", "Login");
                }
                TempData.Keep("country");
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }
         [HttpGet]
        public JsonResult GetState(int id)
        {
            List<SelectListItem> _statelist = _dropdownCommonRepository.GetStatebyID(id)
               .Select(n =>
               new SelectListItem
               {
                   Value = Convert.ToString(n.StateID),
                   Text = n.StateName
               }).ToList();
            var selectListItem = new SelectListItem()
            {
                Value = null,
                Text = "--- select state ---"
            };
            _statelist.Insert(0, selectListItem);
          // TempData["state"] = _statelist;
            return Json(_statelist);
        }
        [HttpGet]
        public JsonResult GetCity(int id)
        {
            List<SelectListItem> _citylist = _dropdownCommonRepository.GetCitybyID(id)
               .Select(n =>
               new SelectListItem
               {
                   Value = Convert.ToString(n.CityID),
                   Text = n.CityName
               }).ToList();
            var selectListItem = new SelectListItem()
            {
                Value = null,
                Text = "--- select city ---"
            };
            _citylist.Insert(0, selectListItem);
            return Json(_citylist);
        }
        //public void AddCookie_For_API_Validation(int ID)
        //{
        //    try
        //    {
        //        AntiForgeryValidate antiForgeryValidate = new AntiForgeryValidate(_configuration);
        //        string cookieToken = antiForgeryValidate.GenerateJSONWebToken();
        //        string formToken = cookieToken;
        //        //AntiForgery.GetTokens(null, out cookieToken, out formToken);
        //        ViewBag.cookieToken = cookieToken;
        //        ViewBag.formToken = formToken;
        //        Random rm = new Random();
        //        CookieOptions options = new CookieOptions();
        //        options.Expires = DateTime.Now.AddDays(7);
        //        options.Secure = true;
        //        options.HttpOnly = true;
        //        string value = ID + "*" + cookieToken + "*" + formToken + "*" + DateTime.Now.Date.ToShortDateString() + "*" + DateTime.Now.Date.ToShortTimeString();
        //        Response.Cookies.Append("EventChannel", value, options);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }


    //public class RegistrationController : Controller
    //{
    //    IRegistrationRepository registrationRepository;
    //    private readonly IConfiguration _configuration;
    //    public RegistrationController(IRegistrationRepository registration,IConfiguration configuration)
    //    {
    //        registrationRepository = registration;
    //        _configuration = configuration;
    //    }
    //    public IActionResult Registration()
    //    {
    //        return View();
    //    }
    //    [HttpPost]
    //    public IActionResult Registration(Registration model)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            registrationRepository.AddRegistration(model);
    //            return RedirectToAction("Home", "Index");
    //        }
    //        return View();
    //    }
    //}
}
