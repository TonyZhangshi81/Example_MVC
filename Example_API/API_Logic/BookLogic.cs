using Example_Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace API_Logic
{
    /// <summary>
    /// 
    /// </summary>
    public class BookLogic : BookBase, IBookLogic
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResultType Delete(string id)
        {
            if (!this.IsExist(id))
            {
                return ResultType.NoExist;
            }

            bookList.Remove(bookList.Where(d => d.ID == id).First());

            return ResultType.Success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public int GetCount(IDictionary<string, string> conditions)
        {
            return this.Search(conditions).Count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public List<Book> Search(IDictionary<string, string> conditions = null)
        {
            if (conditions == null)
            {
                return bookList;
            }

            List<Book> result = bookList;
            if (conditions.ContainsKey("id"))
            {
                result = bookList.Where(d => d.ID == conditions["id"]).ToList();
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        public ResultType Update(string id, Book info)
        {
            if (!this.IsExist(id))
            {
                return ResultType.NoExist;
            }

            var item = bookList.Where(d => d.ID == id).ToList()[0];
            item.Name = info.Name;
            item.Description = info.Description;

            return ResultType.Success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool IsExist(string id)
        {
            if (!bookList.Any(d => d.ID == id))
            {
                AppandMessage(string.Format("this book[{0}] is not found.", id));
                return false;
            }
            return true;
        }
    }
}
