using API_Logic.Entities;
using System.Collections.Generic;

namespace API_Logic
{
    public abstract class BookBase
    {
        private List<string> _message;

        /// <summary>
        /// 
        /// </summary>
        public BookBase()
        {
            _message = new List<string>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        protected void AppandMessage(string msg)
        {
            _message.Add(msg);
        }

        /// <summary>
        /// 
        /// </summary>
        public List<string> Messages
        {
            get
            {
                return _message;
            }
            private set { }
        }

        /// <summary>
        /// 
        /// </summary>
        public static List<Book> bookList = new List<Book>()
        {
                new Book(){ ID = "001", Name = "Pilgrimage to the West; Journey to the West", Description = "将世界观层面的恐怖推向极致的作品。", ImgUrl = "/Example_MVC/Content/image/books/001.jpg" },
                new Book(){ ID = "002", Name = "The Romance of the Three Kingdoms", Description = "这不是一部励志成功学，作者最不想展露的一面恰恰是成功。", ImgUrl = "/Example_MVC/Content/image/books/002.jpg" },
                new Book(){ ID = "003", Name = "A Dream in Red Mansions (The Story of the Stone)", Description = "他将乌克兰政局的荒谬，社会的破败包裹在一个悬疑色彩的黑色喜剧之下。", ImgUrl = "/Example_MVC/Content/image/books/003.jpg" },
                new Book(){ ID = "004", Name = "Heroes of the Marshes; Water Margins", Description = "从烂熟的颓废中生出的一无牵挂的恬淡和潇洒。", ImgUrl = "/Example_MVC/Content/image/books/004.jpg" },
                new Book(){ ID = "005", Name = "Compendium of Materia Medica", Description = "三十年前的宅男畅想。", ImgUrl = "/Example_MVC/Content/image/books/005.jpg" },
                new Book(){ ID = "006", Name = "Strange Tales of a Lonely Studio", Description = "戴上VR看历史。", ImgUrl = "/Example_MVC/Content/image/books/006.jpg" },
                new Book(){ ID = "007", Name = "Analects of Confucius", Description = "什么样的书会让译者生不如死？", ImgUrl = "/Example_MVC/Content/image/books/007.jpg" },
                new Book(){ ID = "008", Name = "the Classic of Mountains and Rivers", Description = "这“最后的仪式”正是死亡和告别这一反应行为的终极延长。", ImgUrl = "/Example_MVC/Content/image/books/008.jpg" },
                new Book(){ ID = "009", Name = "A Surrounded City", Description = "人和人之间接近于神的救赎。", ImgUrl = "/Example_MVC/Content/image/books/009.jpg" },
                new Book(){ ID = "010", Name = "The Romance of West Chamber", Description = "人们不停地在伦敦追逐，却又被伦敦放逐。", ImgUrl = "/Example_MVC/Content/image/books/010.jpg" }
        };
    }
}
