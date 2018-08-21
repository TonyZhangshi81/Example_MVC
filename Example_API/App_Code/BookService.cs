using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace Example_MVC
{
	/// <summary>
	/// 
	/// </summary>
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	public class BookService : IBookService
	{
		private List<BookInfo> bookList;

		private List<BookInfo> GetBookList()
		{
			return bookList;
		}

		private void SetBookList(List<BookInfo> value)
		{
			bookList = value;
		}

		/// <summary>
		/// 
		/// </summary>
		public BookService()
		{
			SetBookList(new List<BookInfo>()
		{
				new BookInfo(){ ID = 1,  Name = "Pilgrimage to the West; Journey to the West", Description = "~/Content/image/books/001.jpg" },
				new BookInfo(){ ID = 2,  Name = "The Romance of the Three Kingdoms", Description = "~/Content/image/books/002.jpg" },
				new BookInfo(){ ID = 3,  Name = "A Dream in Red Mansions (The Story of the Stone)", Description = "~/Content/image/books/003.jpg" },
				new BookInfo(){ ID = 4,  Name = "Heroes of the Marshes; Water Margins", Description = "~/Content/image/books/004.jpg" },
				new BookInfo(){ ID = 5,  Name = "Compendium of Materia Medica", Description = "~/Content/image/books/005.jpg" },
				new BookInfo(){ ID = 6,  Name = "Strange Tales of a Lonely Studio", Description = "~/Content/image/books/006.jpg" },
				new BookInfo(){ ID = 7,  Name = "Analects of Confucius", Description = "~/Content/image/books/007.jpg" },
				new BookInfo(){ ID = 8,  Name = "the Classic of Mountains and Rivers", Description = "~/Content/image/books/008.jpg" },
				new BookInfo(){ ID = 9,  Name = "A Surrounded City", Description = "~/Content/image/books/009.jpg" },
				new BookInfo(){ ID = 10,  Name = "The Romance of West Chamber", Description = "~/Content/image/books/010.jpg" }
		});
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public BookInfo GetData(int id)
		{
			List<BookInfo> result = GetBookList().Where(d => d.ID == id).ToList();
			if (result.Count == 0)
			{
				return null;
			}

			return result[0];
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public int GetCount(int id)
		{
			List<BookInfo> result = GetBookList().Where(d => d.ID == id).ToList();
			return result.Count;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int UpdateMoshikomiInfo(BookInfo info)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}

			return GetBookList().Where(d => d.ID == info.ID).ToList().Count;
		}
	}
}