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
	public class Book : IBook
	{
		private List<TBook> _all;

		public Book()
		{
			this._all = new List<TBook>()
									{
										new TBook(){ ID = 1,  Name = "Pilgrimage to the West; Journey to the West", Description = "~/Content/image/books/001.jpg" },
										new TBook(){ ID = 2,  Name = "The Romance of the Three Kingdoms", Description = "~/Content/image/books/002.jpg" },
										new TBook(){ ID = 3,  Name = "A Dream in Red Mansions (The Story of the Stone)", Description = "~/Content/image/books/003.jpg" },
										new TBook(){ ID = 4,  Name = "Heroes of the Marshes; Water Margins", Description = "~/Content/image/books/004.jpg" },
										new TBook(){ ID = 5,  Name = "Compendium of Materia Medica", Description = "~/Content/image/books/005.jpg" },
										new TBook(){ ID = 6,  Name = "Strange Tales of a Lonely Studio", Description = "~/Content/image/books/006.jpg" },
										new TBook(){ ID = 7,  Name = "Analects of Confucius", Description = "~/Content/image/books/007.jpg" },
										new TBook(){ ID = 8,  Name = "the Classic of Mountains and Rivers", Description = "~/Content/image/books/008.jpg" },
										new TBook(){ ID = 9,  Name = "A Surrounded City", Description = "~/Content/image/books/009.jpg" },
										new TBook(){ ID = 10,  Name = "The Romance of West Chamber", Description = "~/Content/image/books/010.jpg" }
									};
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public List<TBook> GetBooks()
		{
			return this.GetBooks(string.Empty);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public List<TBook> GetBooks(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				return this._all;
			}
			return this._all.Where(s => s.Name.IndexOf(name) >= 0).ToList();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public TBook GetBook(int id)
		{
			return this._all.Where(d => d.ID == id).First();
		}
	}
}
