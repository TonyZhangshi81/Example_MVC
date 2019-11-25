using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Example_MVC
{
	// メモ: [リファクター] メニューの [名前の変更] コマンドを使用すると、コードと config ファイルの両方で同時にインターフェイス名 "IService" を変更できます。
	[ServiceContract]
	public interface IBookService
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[OperationContract]
		[WebInvoke(UriTemplate = "/GetCount", Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		int GetCount(string id);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "/GetBooks", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
        //[return: MessageParameter(Name = "MyServiceResponse")]
        List<BookInfo> GetBooks();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
		[WebInvoke(UriTemplate = "/GetBook", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
		BookInfo GetBook(string id);

		/// <summary>
		/// 
		/// </summary>
        /// <param name="id"></param>
		/// <param name="composite"></param>
		/// <returns></returns>
		[OperationContract]
		[WebInvoke(UriTemplate = "/Update", Method = "PUT", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
		bool Update(string id, BookInfo info);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="composite"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "/Delete", Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        bool Delete(string id);
    }

    // サービス操作に複合型を追加するには、以下のサンプルに示すようにデータ コントラクトを使用します。
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
	public class BookInfo
	{
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string ID { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string Name { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string Description { get; set; }

        /// <summary>
		/// 
		/// </summary>
		[DataMember]
        public string ImgUrl { get; set; }
    }
}