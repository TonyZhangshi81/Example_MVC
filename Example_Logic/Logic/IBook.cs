using System.Collections.Generic;

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
        List<Example_Models.Entities.Book> GetBooks();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        List<Example_Models.Entities.Book> GetBooksWithName(string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Example_Models.Entities.Book GetBook(string id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        bool Update(Example_Models.Entities.Book book);

        /// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		bool Delete(string id);
    }
}
