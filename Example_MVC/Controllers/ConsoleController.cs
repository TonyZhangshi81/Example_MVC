﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Example_MVC.Controllers
{
	public class ConsoleController : Controller
    {
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public ActionResult Index()
        {
			ViewBag.Message = "MVC4示例 Console  " + DateTime.Now.ToString();
            return View();
        }
    }
}
