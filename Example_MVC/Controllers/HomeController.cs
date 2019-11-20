using Example_Logic.Logic;
using Example_Logic.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Example_MVC.Controllers
{
	/// <summary>
	/// 
	/// </summary>
	public class HomeController : Controller
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="commandName"></param>
		/// <returns></returns>
		public ActionResult Index(string commandName)
		{
			switch (commandName)
			{
				case "Go":
					//return RedirectToAction("Show", new RouteValueDictionary(new { controller = "Play", action = "Show" }));
					var paramater = this.Request.Form["txtName"].ToString();
					return RedirectToAction("Show", "Play", new { id = 1, type = paramater });
				case "All":
					ViewBag.Message = DateTime.Now.ToString();

					var name = this.Request.Form["txtBookName"].ToString();
					var books = this.GetBooks(name);
					this.ViewData.Add("books", books);

					return View("Display");
			}

			ViewBag.Message = "ASP.NET MVC4示例 " + DateTime.Now.ToString();
			return View();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public ActionResult Display(string name)
		{
			ViewBag.Message = DateTime.Now.ToString();

			var books = this.GetBooks(name);
			this.ViewData.Add("books", books);

			return View("Display");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		private List<TBook> GetBooks(string name)
		{
			var logic = new Book();

			if (string.IsNullOrEmpty(name))
			{
				return logic.GetBooks();
			}
			else
			{
				return logic.GetBooks(name);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public ActionResult About(int id, string type)
		{
			return RedirectToAction("Index", "About", new { id = id, type = type });
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="openid"></param>
		/// <returns></returns>
		public ActionResult ToBook(int openid)
		{
			return RedirectToAction("Show", "Book", new { id = openid });
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult DisplayMsg(string name)
		{
			string result = name + " <- " + System.DateTime.Now.ToString();
			return Json(new { Message = result });
		}
	}
}
