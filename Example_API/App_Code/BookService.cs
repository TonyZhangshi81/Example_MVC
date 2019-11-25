using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;

namespace Example_MVC
{
    /// <summary>
    /// 
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class BookService : IBookService
    {
        public static List<BookInfo> bookList = new List<BookInfo>()
        {
                new BookInfo(){ ID = "001", Name = "Pilgrimage to the West; Journey to the West", Description = "将世界观层面的恐怖推向极致的作品。", ImgUrl = "/Example_MVC/Content/image/books/001.jpg" },
                new BookInfo(){ ID = "002", Name = "The Romance of the Three Kingdoms", Description = "这不是一部励志成功学，作者最不想展露的一面恰恰是成功。", ImgUrl = "/Example_MVC/Content/image/books/002.jpg" },
                new BookInfo(){ ID = "003", Name = "A Dream in Red Mansions (The Story of the Stone)", Description = "他将乌克兰政局的荒谬，社会的破败包裹在一个悬疑色彩的黑色喜剧之下。", ImgUrl = "/Example_MVC/Content/image/books/003.jpg" },
                new BookInfo(){ ID = "004", Name = "Heroes of the Marshes; Water Margins", Description = "从烂熟的颓废中生出的一无牵挂的恬淡和潇洒。", ImgUrl = "/Example_MVC/Content/image/books/004.jpg" },
                new BookInfo(){ ID = "005", Name = "Compendium of Materia Medica", Description = "三十年前的宅男畅想。", ImgUrl = "/Example_MVC/Content/image/books/005.jpg" },
                new BookInfo(){ ID = "006", Name = "Strange Tales of a Lonely Studio", Description = "戴上VR看历史。", ImgUrl = "/Example_MVC/Content/image/books/006.jpg" },
                new BookInfo(){ ID = "007", Name = "Analects of Confucius", Description = "什么样的书会让译者生不如死？", ImgUrl = "/Example_MVC/Content/image/books/007.jpg" },
                new BookInfo(){ ID = "008", Name = "the Classic of Mountains and Rivers", Description = "这“最后的仪式”正是死亡和告别这一反应行为的终极延长。", ImgUrl = "/Example_MVC/Content/image/books/008.jpg" },
                new BookInfo(){ ID = "009", Name = "A Surrounded City", Description = "人和人之间接近于神的救赎。", ImgUrl = "/Example_MVC/Content/image/books/009.jpg" },
                new BookInfo(){ ID = "010", Name = "The Romance of West Chamber", Description = "人们不停地在伦敦追逐，却又被伦敦放逐。", ImgUrl = "/Example_MVC/Content/image/books/010.jpg" }
        };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            
            if (!bookList.Any(d => d.ID == id))
            {
                return false;
            }
            bookList.Remove(bookList.Where(d => d.ID == id).First());
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BookInfo GetBook(string id)
        {
            List<BookInfo> result = bookList.Where(d => d.ID == id).ToList();
            if (result.Count == 0)
            {
                return null;
            }

            return result[0];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<BookInfo> GetBooks()
        {
            return bookList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetCount(string id)
        {
            List<BookInfo> result = bookList.Where(d => d.ID == id).ToList();
            return result.Count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool Update(string id, BookInfo info)
        {
            if (info == null)
            {
                return false;
            }

            var item = this.GetBook(id);
            item.Name = info.Name;
            item.Description = info.Description;

            return true;
        }
    }
}