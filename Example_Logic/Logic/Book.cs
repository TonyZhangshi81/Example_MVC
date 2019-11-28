using Example.Common;
using Example_Logic.Models;
using System.Collections.Generic;
using System.Linq;

namespace Example_Logic.Logic
{
    /// <summary>
    /// 
    /// </summary>
    public class Book : IBook
    {
        public Book()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Example_Models.Entities.Book> GetBooks()
        {
            var apiRequestHttp = new ApiRequestHttp();
            apiRequestHttp.HttpPostSync(@"http://localhost/BookServer/BookService.svc/GetBooks", string.Empty);

            var json = apiRequestHttp.OutputJson;
            var books = ApiRequestHttp.Deserialize<ApiGetBooksType>(json);

            return books.GetBooksResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Example_Models.Entities.Book> GetBooksWithName(string name)
        {
            var bookList = this.GetBooks();
            if (string.IsNullOrEmpty(name))
            {
                return bookList;
            }
            return bookList.Where(s => s.Name.IndexOf(name) >= 0).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Example_Models.Entities.Book GetBook(string id)
        {
            var apiRequestHttp = new ApiRequestHttp();

            var data = new
            {
                id = id
            };

            apiRequestHttp.HttpPostSync(@"http://localhost/BookServer/BookService.svc/GetBook", data);

            var json = apiRequestHttp.OutputJson;
            var book = ApiRequestHttp.Deserialize<ApiGetBookWithIdType>(json);

            return book.GetBookResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public bool Update(Example_Models.Entities.Book book)
        {
            var item = this.GetBook(book.ID);
            if (item == null)
            {
                return false;
            }

            item.Description = book.Description;

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            var apiRequestHttp = new ApiRequestHttp();

            var requestAll = new
            {
                metadata = new { requestid = "DEL01" },
                request = new { id = id }
            };

            apiRequestHttp.HttpPostSync(@"http://localhost/BookServer/BookService.svc/Delete", requestAll);

            var json = apiRequestHttp.OutputJson;
            var result = ApiRequestHttp.Deserialize<ResponseObject<ResponseMetadata, ApiDeleteBookWithIdResponse>>(json);

            ExtBooleanConverter booleanConverter = new ExtBooleanConverter();
            return (bool)booleanConverter.ConvertFrom(result.Response.Result);
        }
    }
}
