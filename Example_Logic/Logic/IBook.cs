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
		List<TBook> GetBooks();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		List<TBook> GetBooks(string name);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		TBook GetBook(string id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        bool Update(TBook book);

        /// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		bool Delete(string id);
    }
}
