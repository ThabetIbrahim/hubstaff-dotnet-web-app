using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
namespace home_space
{
    public class Home : Controller
    {
        public hubstaff.client hubstaff_api = new hubstaff.client("pHR18-G-9c05NoyBtji3a8A2KsFKOuZcSZK4gT5V9vc");
        [HttpGet("/")]
        public IActionResult Index(){
            if( HttpContext.Session.GetString("auth_token") != "")
            {
                ViewBag.auth_token = HttpContext.Session.GetString("auth_token");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Index(string email, string password, string operation)
        {
            hubstaff_api.auth(email,password);
            string token = hubstaff_api.get_auth_token();
            HttpContext.Session.SetString("auth_token", token);
            ViewBag.auth_token = token;
            ViewBag.email = email;
            ViewBag.password = password;

            return View();
        }
    }
}