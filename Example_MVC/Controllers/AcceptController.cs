using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Example_MVC.Controllers
{
	public class AcceptController : Controller
    {
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public ActionResult Index()
        {
			ViewBag.Message = "MVC5示例 Accept  " + DateTime.Now.ToString();
            return View();
        }
    }
}
