# Hubstaff .NET - Integrate Hubstaff API Into Your .NET App

## Getting Started

After you have cloned this repo, start by installing the necessary dependencies. 
Using command line navigate to the .NET app directory and run

    % dotnet restore

## Using the Hubstaff .NET client

**Step 1:** Get your [HUBSTAFF_APP_TOKEN](https://developer.hubstaff.com/my_apps), and use it to to initialize hubstaff class.
```cs
	var app_token = "your hubstaff app token"
	hubstaff.client hubstaff_api = new hubstaff.client(app_token);
```
**Step 2:** Use hubstaff functions in your controllers.

Authentication token generation controller

```cs
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
```


Reports generation controller

```cs
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
```

Screenshots generation controller

```cs
	// Generate the screenshots

	using System;
	using System.Collections.Generic;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Http;
	namespace screenshots_space
	{
	    public class screenshots : Controller
	    {
		public IActionResult Index(){
		    Dictionary <string, string[]> param = new Dictionary <string, string[]>();
		    param["start_time"] = new string[] {"start_time"};
		    param["stop_time"]   = new string[] {"stop_time"};
		    param["offset"]   = new string[] {"offset"};
		    param.Add("options", new string[] {"organizations","projects","users"});

		    Dictionary <string, string> value_type = new Dictionary <string, string>();
		    value_type["organizations"] = "input";
		    value_type["projects"] = "input";
		    value_type["users"] = "input";
		    value_type["offset"] = "input";
		    value_type["start_time"] = "datetime";
		    value_type["stop_time"] = "datetime";

		    ViewBag.param = param;
		    ViewBag.value_type = value_type;
		    return View();
		}
		[HttpPost]
		public ActionResult Index(string start_time, string stop_time,int offset, Dictionary<string, string> options)
		{
		    Dictionary <string, string[]> param = new Dictionary <string, string[]>();
		    param["start_time"] = new string[] {"start_time"};
		    param["stop_time"]   = new string[] {"stop_time"};
		    param["offset"]   = new string[] {"offset"};
		    param.Add("options", new string[] {"organizations","projects","users"});

		    Dictionary <string, string> value_type = new Dictionary <string, string>();
		    value_type["organizations"] = "input";
		    value_type["projects"] = "input";
		    value_type["users"] = "input";
		    value_type["offset"] = "input";
		    value_type["start_time"] = "datetime";
		    value_type["stop_time"] = "datetime";

		    ViewBag.param = param;
		    ViewBag.value_type = value_type;
		    hubstaff.client hubstaff_api = new hubstaff.client("pHR18-G-9c05NoyBtji3a8A2KsFKOuZcSZK4gT5V9vc");
		    hubstaff_api.set_auth_token(HttpContext.Session.GetString("auth_token"));
		    ViewBag.screenshots = hubstaff_api.screehshots(start_time, stop_time, options, offset);

		    return View();
		}

	    }
	}
```

**Step 3:[Your Turn]** Create forms that your users can pass the
required parameters into, so that they retrieve & display the exact data they
want.
