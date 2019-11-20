using Example_Logic.Logic;
using Example_Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Example_MVC.Controllers
{
	public class BookController : Controller
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public ActionResult Show(string id)
		{
			var book = this.GetBookInfo(id.PadLeft(3, '0'));
			return View("Show", book);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="bookName"></param>
		/// <returns></returns>
		public ActionResult HomeDisplay(string bookName)
		{
			return RedirectToAction("Display", "Home", new { name = bookName });
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		private TBook GetBookInfo(string id)
		{
			var logic = new Book();
			return logic.GetBook(id);
		}
	}
}
