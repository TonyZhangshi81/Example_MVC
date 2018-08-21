using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Example_MVC.Controllers
{
	public class AboutController : Controller
    {
		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="type"></param>
		/// <returns></returns>
		public ActionResult Index(int id, string type)
        {
			var paramters = new StringBuilder();
			paramters.AppendFormat("id: {0} type: '{1}'", id, type);
			ViewBag.Message = "MVC4示例 param:" + paramters.ToString() + "  " + DateTime.Now.ToString();
            return View();
        }
    }
}
