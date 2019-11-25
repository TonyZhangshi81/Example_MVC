using Example_Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_Logic.Logic
{
	/// <summary>
	/// 
	/// </summary>
	public interface IBook
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		List<BookInfo> GetBooks();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		List<BookInfo> GetBooksWithName(string name);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		BookInfo GetBook(string id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        bool Update(BookInfo book);

        /// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		bool Delete(string id);
    }
}
