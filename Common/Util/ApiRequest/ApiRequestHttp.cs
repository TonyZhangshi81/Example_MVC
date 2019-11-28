using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Example.Common
{
    public class ApiRequestHttp
    {
        /// <summary>
		/// 
		/// </summary>
		private static Dictionary<string, HttpClient> _innerHttpClients = new Dictionary<string, HttpClient>();

        /// <summary>
		/// 戻り値
		/// </summary>
		private string _outputJson;

        /// <summary>
        /// 
        /// </summary>
        public string OutputJson
        {
            get { return this._outputJson; }
        }

        /// <summary>
		/// API呼出方法（GET）（非同期）
		/// </summary>
		/// <param name="url">パス</param>
		/// <param name="requestAll">リクエスト</param>
		/// <param name="apiKey">APIのキー</param>
		/// <returns>レスポンス</returns>
		public async Task HttpGetAsync(string url, object requestAll, string apiKey)
        {
            var inputJson = DynamicJson.Serialize(requestAll);
            this._outputJson = string.Empty;

            var client = this.GetHttpClient(url);

            HttpResponseMessage response = null;
            var content = new StringContent(inputJson, Encoding.UTF8, "application/json");

            if (client.DefaultRequestHeaders.Contains("x-api-key"))
            {
                client.DefaultRequestHeaders.Remove("x-api-key");
            }

            client.DefaultRequestHeaders.Add("x-api-key", apiKey);

            var sWkJson = HttpUtility.UrlEncode(inputJson);

            // Get
            response = client.GetAsync(url + "?d=" + sWkJson).Result;

            var responseByte = await response.Content.ReadAsByteArrayAsync();

            this._outputJson = Encoding.UTF8.GetString(responseByte);

        }

        /// <summary>
        /// API呼出方法（GET）（同期）
        /// </summary>
        /// <param name="url">パス</param>
        /// <param name="requestAll">リクエスト</param>
        /// <param name="apiKey">APIのキー</param>
        /// <returns>レスポンス</returns>
        public void HttpGetSync(string url, object requestAll, string apiKey)
        {
            var inputJson = DynamicJson.Serialize(requestAll);
            this._outputJson = string.Empty;

            var client = this.GetHttpClient(url);

            HttpResponseMessage response = null;
            var content = new StringContent(inputJson, Encoding.UTF8, "application/json");

            if (client.DefaultRequestHeaders.Contains("x-api-key"))
            {
                client.DefaultRequestHeaders.Remove("x-api-key");
            }

            client.DefaultRequestHeaders.Add("x-api-key", apiKey);

            var sWkJson = HttpUtility.UrlEncode(inputJson);

            // Get
            response = client.GetAsync(url + "?d=" + sWkJson).Result;

            var responseByte = response.Content.ReadAsByteArrayAsync().Result;

            this._outputJson = Encoding.UTF8.GetString(responseByte);
        }

        /// <summary>
        /// API呼出方法（POST）（非同期）
        /// </summary>
        /// <param name="url">パス</param>
        /// <param name="requestAll">レクエスト</param>
        /// <param name="apiKey">APIのキー</param>
        /// <returns>レスポンス</returns>
        public async Task HttpPostAsync(string url, object requestAll, string apiKey)
        {
            var inputJson = DynamicJson.Serialize(requestAll);
            this._outputJson = string.Empty;

            var client = this.GetHttpClient(url);

            HttpResponseMessage response = null;
            var content = new StringContent(inputJson, Encoding.UTF8, "application/json");

            if (client.DefaultRequestHeaders.Contains("x-api-key"))
            {
                client.DefaultRequestHeaders.Remove("x-api-key");
            }

            client.DefaultRequestHeaders.Add("x-api-key", apiKey);

            //post
            response = client.PostAsync(url, content).Result;

            var responseByte = await response.Content.ReadAsByteArrayAsync();

            this._outputJson = Encoding.UTF8.GetString(responseByte);
        }

        /// <summary>
        /// API呼出方法（POST）（同期）
        /// </summary>
        /// <param name="url">パス</param>
        /// <param name="requestAll">レクエスト</param>
        /// <param name="apiKey">APIのキー</param>
        /// <returns>レスポンス</returns>
        public void HttpPostSync(string url, object requestAll, string apiKey)
        {
            var inputJson = DynamicJson.Serialize(requestAll);
            this._outputJson = string.Empty;

            var client = this.GetHttpClient(url);

            HttpResponseMessage response = null;
            var content = new StringContent(inputJson, Encoding.UTF8, "application/json");

            if (client.DefaultRequestHeaders.Contains("x-api-key"))
            {
                client.DefaultRequestHeaders.Remove("x-api-key");
            }

            client.DefaultRequestHeaders.Add("x-api-key", apiKey);

            //post
            response = client.PostAsync(url, content).Result;

            var responseByte = response.Content.ReadAsByteArrayAsync().Result;

            this._outputJson = Encoding.UTF8.GetString(responseByte);
        }

        /// <summary>
        /// API呼出方法（POST）（非同期）
        /// </summary>
        /// <param name="url">パス</param>
        /// <param name="requestAll">レクエスト</param>
        /// <returns>レスポンス</returns>
        public async Task HttpPostAsync(string url, object requestAll)
        {
            var inputJson = DynamicJson.Serialize(requestAll);

            this._outputJson = string.Empty;

            var client = this.GetHttpClient(url);

            HttpResponseMessage response = null;
            var content = new StringContent(inputJson, Encoding.UTF8, "application/json");

            //post
            response = client.PostAsync(url, content).Result;

            var responseByte = await response.Content.ReadAsByteArrayAsync();

            this._outputJson = Encoding.UTF8.GetString(responseByte);
        }

        /// <summary>
        /// API呼出方法（POST）（同期）
        /// </summary>
        /// <param name="url">パス</param>
        /// <param name="requestAll">レクエスト</param>
        /// <returns>レスポンス</returns>
        public void HttpPostSync(string url, object requestAll)
        {
            var inputJson = DynamicJson.Serialize(requestAll);

            this._outputJson = string.Empty;

            var client = this.GetHttpClient(url);

            HttpResponseMessage response = null;
            var content = new StringContent(inputJson, Encoding.UTF8, "application/json");

            //post
            response = client.PostAsync(url, content).Result;

            var responseByte = response.Content.ReadAsByteArrayAsync().Result;

            this._outputJson = Encoding.UTF8.GetString(responseByte);
        }

        /// <summary>
        /// API呼出方法（POST）（同期）
        /// </summary>
        /// <param name="url">パス</param>
        /// <param name="inputJson">レクエスト</param>
        /// <returns>レスポンス</returns>
        public void HttpPostSync(string url, string inputJson)
        {

            this._outputJson = string.Empty;

            var client = this.GetHttpClient(url);

            HttpResponseMessage response = null;
            var content = new StringContent(inputJson, Encoding.UTF8, "application/json");

            //post
            response = client.PostAsync(url, content).Result;

            var responseByte = response.Content.ReadAsByteArrayAsync().Result;

            this._outputJson = Encoding.UTF8.GetString(responseByte);
        }

        /// <summary>
        /// API呼出方法（POST）WithBasic（非同期）
        /// </summary>
        /// <param name="url">パス</param>
        /// <param name="requestAll">レクエスト</param>
        /// <param name="apiKey">APIのキー</param>
        /// <returns>レスポンス</returns>
        public async Task HttpPostAsyncWithBasic(string url, object requestAll, string apiKey)
        {
            var inputJson = DynamicJson.Serialize(requestAll);

            this._outputJson = string.Empty;

            var client = this.GetHttpClient(url);

            HttpResponseMessage response = null;

            var content = new StringContent(inputJson, Encoding.UTF8, "application/json");

            var authValue = new AuthenticationHeaderValue("Basic", apiKey);

            client.DefaultRequestHeaders.Authorization = authValue;

            //post
            response = client.PostAsync(url, content).Result;

            var responseByte = await response.Content.ReadAsByteArrayAsync();

            this._outputJson = Encoding.UTF8.GetString(responseByte);
        }

        /// <summary>
        /// API呼出方法（POST）WithBasic（同期）
        /// </summary>
        /// <param name="url">パス</param>
        /// <param name="requestAll">レクエスト</param>
        /// <param name="apiKey">APIのキー</param>
        /// <returns>レスポンス</returns>
        public void HttpPostSyncWithBasic(string url, object requestAll, string apiKey)
        {
            var inputJson = DynamicJson.Serialize(requestAll);

            this._outputJson = string.Empty;

            var client = this.GetHttpClient(url);

            HttpResponseMessage response = null;

            var content = new StringContent(inputJson, Encoding.UTF8, "application/json");

            var authValue = new AuthenticationHeaderValue("Basic", apiKey);

            client.DefaultRequestHeaders.Authorization = authValue;

            //post
            response = client.PostAsync(url, content).Result;

            var responseByte = response.Content.ReadAsByteArrayAsync().Result;

            this._outputJson = Encoding.UTF8.GetString(responseByte);
        }

        /// <summary>
        /// シリアライズ
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string Serialize(object message)
        {
            return DynamicJson.Serialize(message);
        }

        /// <summary>
        /// デシリアライズする
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string message)
        {
            if (message.Substring(0, 1) != "{")
            {
                message = message.Substring(1);
            }

            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(message)))
            {
                var setting = new DataContractJsonSerializerSettings()
                {
                    UseSimpleDictionaryFormat = true,
                };
                var serializer = new DataContractJsonSerializer(typeof(T), setting);
                return (T)serializer.ReadObject(stream);
            }
        }

        /// <summary>
        /// HttpClientを取得する
        /// </summary>
        /// <param name="url">辞書のキー</param>
        /// <returns>HttpClient</returns>
        private HttpClient GetHttpClient(string url)
        {
            if (!_innerHttpClients.ContainsKey(url))
            {
                _innerHttpClients.Add(url, new HttpClient(new LoggingHandler(new HttpClientHandler())));
            }
            return _innerHttpClients[url];
        }
    }

    /// <summary>
	/// ログハンドラ
	/// </summary>
	public class LoggingHandler : DelegatingHandler
    {
        //private static readonly Common.Logging.ILog Log = Common.Logging.LogManager.GetLogger<LoggingHandler>();

        /// <summary>
        /// ログハンドラ
        /// </summary>
        /// <param name="innerHandler">innerHandler</param>
        public LoggingHandler(HttpMessageHandler innerHandler)
            : base(innerHandler)
        {
        }

        /// <summary>
        /// ログハンドラ
        /// </summary>
        /// <param name="request">レクエスト</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //Log.Info("【REQ】" + request.ToString());
            if (request.Content != null)
            {
                // POSTの場合
                //LogUtil.LogJsonRequestDump(request.Content.ReadAsStringAsync().Result);
            }
            else
            {
                // GETの場合
                const string getQuery = "?d=";
                if (request.RequestUri.Query.StartsWith(getQuery))
                {
                    var getJson = request.RequestUri.Query.Replace(getQuery, string.Empty);
                    getJson = HttpUtility.UrlDecode(getJson);
                    //LogUtil.LogJsonRequestDump(getJson);
                }
            }

            Task<HttpResponseMessage> response = base.SendAsync(request, cancellationToken);

            if (response.Result != null)
            {
                //Log.Info("【RES】" + response.Result.ToString());

                if (response.Result.Content != null)
                {
                    //LogUtil.LogJsonResponseDump(response.Result.Content.ReadAsStringAsync().Result);
                }
            }

            return response;
        }
    }
}
