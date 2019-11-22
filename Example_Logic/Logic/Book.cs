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
        public static List<TBook> bookList = new List<TBook>()
        {
                new TBook(){ ID = "001", Name = "Pilgrimage to the West; Journey to the West", Description = "将世界观层面的恐怖推向极致的作品。", ImgUrl = "/Example_MVC/Content/image/books/001.jpg" },
                new TBook(){ ID = "002", Name = "The Romance of the Three Kingdoms", Description = "这不是一部励志成功学，作者最不想展露的一面恰恰是成功。", ImgUrl = "/Example_MVC/Content/image/books/002.jpg" },
                new TBook(){ ID = "003", Name = "A Dream in Red Mansions (The Story of the Stone)", Description = "他将乌克兰政局的荒谬，社会的破败包裹在一个悬疑色彩的黑色喜剧之下。", ImgUrl = "/Example_MVC/Content/image/books/003.jpg" },
                new TBook(){ ID = "004", Name = "Heroes of the Marshes; Water Margins", Description = "从烂熟的颓废中生出的一无牵挂的恬淡和潇洒。", ImgUrl = "/Example_MVC/Content/image/books/004.jpg" },
                new TBook(){ ID = "005", Name = "Compendium of Materia Medica", Description = "三十年前的宅男畅想。", ImgUrl = "/Example_MVC/Content/image/books/005.jpg" },
                new TBook(){ ID = "006", Name = "Strange Tales of a Lonely Studio", Description = "戴上VR看历史。", ImgUrl = "/Example_MVC/Content/image/books/006.jpg" },
                new TBook(){ ID = "007", Name = "Analects of Confucius", Description = "什么样的书会让译者生不如死？", ImgUrl = "/Example_MVC/Content/image/books/007.jpg" },
                new TBook(){ ID = "008", Name = "the Classic of Mountains and Rivers", Description = "这“最后的仪式”正是死亡和告别这一反应行为的终极延长。", ImgUrl = "/Example_MVC/Content/image/books/008.jpg" },
                new TBook(){ ID = "009", Name = "A Surrounded City", Description = "人和人之间接近于神的救赎。", ImgUrl = "/Example_MVC/Content/image/books/009.jpg" },
                new TBook(){ ID = "010", Name = "The Romance of West Chamber", Description = "人们不停地在伦敦追逐，却又被伦敦放逐。", ImgUrl = "/Example_MVC/Content/image/books/010.jpg" }
        };

        public Book()
        {
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
                return bookList;
            }
            return bookList.Where(s => s.Name.IndexOf(name) >= 0).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TBook GetBook(string id)
        {
            return bookList.Where(d => d.ID == id).First();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public bool Update(TBook book)
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
            var item = this.GetBook(id);
            if (item == null)
            {
                return false;
            }

            bookList.Remove(item);

            return true;
        }
    }
}
