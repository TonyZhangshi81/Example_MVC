using Api.ServiceModel;
using Api.ServiceModel.Models;
using API_Logic;
using Example_Models.Entities;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;

namespace Example_MVC
{
    /// <summary>
    /// 
    /// </summary>
	[ServiceContract(Namespace = "", SessionMode = SessionMode.NotAllowed)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class BookService : RestServiceBase
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="metadata"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "/Delete", Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        public virtual Message Delete(RequestMetadata metadata, ApiBookWithIdRequest request)
        {
            List<string> errors = null;
            bool isValid = TryValidate(new RequestObject<RequestMetadata, ApiBookWithIdRequest>(metadata, request), out errors);
            if (!isValid)
            {
                var errorResponse = new ResponseObject<ResponseMetadata, ApiDeleteBookWithIdResponse>()
                {
                    Metadata = new ResponseMetadata()
                    {
                        RequestId = metadata.RequestId,
                        Messages = errors,
                        Status = (int)HttpStatusCode.BadRequest,
                        Timestamp = System.DateTime.Now.ToString("yyyyMMddHHmmss.fffff")
                    },
                    Response = new ApiDeleteBookWithIdResponse() { Result = "0" }
                };
                return this.CreateMessage(errorResponse, errorResponse.Metadata.Status);
            }

            var logic = new BookLogic();
            var result = logic.Delete(request.ID);
            var response = new ResponseObject<ResponseMetadata, ApiDeleteBookWithIdResponse>()
            {
                Metadata = new ResponseMetadata()
                {
                    RequestId = metadata.RequestId,
                    Status = (int)HttpStatusCode.OK,
                    Messages = logic.Messages,
                    Timestamp = System.DateTime.Now.ToString("yyyyMMddHHmmss.fffff")
                },
                Response = new ApiDeleteBookWithIdResponse() { Result = result == ResultType.Success ? "1" : "0" }
            };

            return this.CreateMessage(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "/GetBook", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
        public virtual Book GetBook(string id)
        {
            var logic = new BookLogic();

            var conditions = new Dictionary<string, string>()
            {
                { "id", id }
            };
            var result = logic.Search(conditions);
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
        [OperationContract]
        [WebInvoke(UriTemplate = "/GetBooks", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
        public virtual List<Book> GetBooks()
        {
            var logic = new BookLogic();
            var result = logic.Search();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		[OperationContract]
        [WebInvoke(UriTemplate = "/GetCount", Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public virtual int GetCount(string id)
        {
            var logic = new BookLogic();

            var conditions = new Dictionary<string, string>()
            {
                { "id", id }
            };
            var result = logic.GetCount(conditions);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="info"></param>
        /// <returns></returns>
		[OperationContract]
        [WebInvoke(UriTemplate = "/Update", Method = "PUT", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        public virtual bool Update(string id, Book info)
        {
            var logic = new BookLogic();
            logic.Update(id, info);
            return true;
        }
    }
}