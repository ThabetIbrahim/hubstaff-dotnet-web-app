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
**Step 3:[Your Turn]** Create forms that your users can pass the
required parameters into, so that they retrieve & display the exact data they
want.
