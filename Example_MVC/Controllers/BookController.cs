using Example_Logic.Logic;
using Example_Logic.Models;
using System.Web.Mvc;

namespace Example_MVC.Controllers
{
    public class BookController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Show()
        {
            return this.Display("Show");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public ActionResult Edit()
        {
            return this.Display("Edit");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public ActionResult Delete()
        {
            return this.Display("Delete");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewName"></param>
        /// <returns></returns>
        private ActionResult Display(string viewName)
        {
            TBook book = (TBook)TempData["book"];
            return View(viewName, book);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        /// <param name="commandName"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(TBook book, string commandName)
        {
            if ("close".Equals(commandName))
            {
                return this.Close();
            }

            if (ModelState.IsValid)
            {
                var id = Request.Form["ID"];
                var description = Request.Form["Description"];

                ViewBag.Result = "0";
                var isSuccess = this.Update(id, description);
                if (!isSuccess)
                {
                    ViewBag.Result = "1";
                }
            }

            return View(book);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        /// <param name="commandName"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(TBook book, string commandName)
        {
            if ("close".Equals(commandName))
            {
                return this.Close();
            }

            ViewBag.Result = "0";
            var isSuccess = this.Delete(book.ID);
            if (!isSuccess)
            {
                ViewBag.Result = "1";
                return View("Delete", book);
            }
            return this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private ActionResult Close()
        {
            return RedirectToAction("DisplayAll", "Home");
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        private bool Update(string id, string description)
        {
            var logic = new Book();
            return logic.Update(new TBook { ID = id, Description = description });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool Delete(string id)
        {
            var logic = new Book();
            return logic.Delete(id);
        }
    }
}
