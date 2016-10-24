using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace reports_space
{
    public class reports : Controller
    {
        public IActionResult Index(){

            Dictionary <string, string[]> param = new Dictionary <string, string[]>();
            param["start_date"] = new string[] {"start_date"};
            param["end_date"]   = new string[] {"end_date"};
            param.Add("options", new string[] {"organizations","projects","users","show_tasks","show_notes","show_activity","include_archived"});
            
            Dictionary <string, string> value_type = new Dictionary <string, string>();
            value_type["organizations"] = "input";
            value_type["projects"] = "input";
            value_type["users"] = "input";
            value_type["start_date"] = "datetime";
            value_type["end_date"] = "datetime";
            value_type["show_tasks"] = "select";
            value_type["show_notes"] = "select";
            value_type["show_activity"] = "select";
            value_type["include_archived"] = "select";
            
            ViewBag.param = param;
            ViewBag.value_type = value_type;
            return View();
        }
        [HttpPost]
        public ActionResult Index(string start_date, string end_date, Dictionary<string, string> options)
        {
            Dictionary <string, string[]> param = new Dictionary <string, string[]>();
            param["start_date"] = new string[] {"start_date"};
            param["end_date"]   = new string[] {"end_date"};
            param.Add("options", new string[] {"organizations","projects","users","show_tasks","show_notes","show_activity","include_archived"});

            Dictionary <string, string> value_type = new Dictionary <string, string>();
            value_type["organizations"] = "input";
            value_type["projects"] = "input";
            value_type["users"] = "input";
            value_type["start_date"] = "datetime";
            value_type["end_date"] = "datetime";
            value_type["show_tasks"] = "select";
            value_type["show_notes"] = "select";
            value_type["show_activity"] = "select";
            value_type["include_archived"] = "select";

            ViewBag.param = param;
            ViewBag.value_type = value_type;
            hubstaff.client hubstaff_api = new hubstaff.client("pHR18-G-9c05NoyBtji3a8A2KsFKOuZcSZK4gT5V9vc");
            hubstaff_api.set_auth_token(HttpContext.Session.GetString("auth_token"));
            ViewBag.reports = hubstaff_api.custom_date_team(start_date, end_date, options);

            return View();
        }

    }
}