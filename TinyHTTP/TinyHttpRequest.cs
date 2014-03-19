using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace TinyHTTP
{
    /// <summary>
    /// The main class needed to make HTTP requests with TinyHTTP
    /// </summary>
    public class TinyHttpRequest
    {
        protected readonly string Url;
        protected readonly HttpRequestData Data;
        protected readonly Dictionary<string, string> Parameters = new Dictionary<string, string>();
        protected readonly Dictionary<string, string> Headers = new Dictionary<string, string>();

        protected IWebProxy WebProxy = null;
        protected HttpContentType RequestContentType = HttpContentType.UrlEncoded;
        protected Encoding RequestEncoding = Encoding.ASCII;

        #region Constructors
        /// <summary>
        /// Initializes a TinyHttpRequest instance with only the URL, defaults to an unencrypted GET request.
        /// </summary>
        /// <param name="url"></param>
        public TinyHttpRequest(string url)
            : this(url, new HttpRequestData(HttpRequestType.Get, HttpEncryptionLevel.Http))
        {

        }

        /// <summary>
        /// Initializes a TinyHttpRequest instance with an URL and a user-defined HttpRequestData instance.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        public TinyHttpRequest(string url, HttpRequestData data)
        {
            if (url == null)
                throw new ArgumentNullException("url");
            if (data == null)
                throw new ArgumentNullException("data");
            if (url.Length == 0)
                throw new ArgumentException("url");
            this.Url = url;
            this.Data = data;
        }

        /// <summary>
        /// Initializes a TinyHttpRequest instance with a user-defined HttpRequestType and a user-defined HttpEncryptionLevel.
        /// Basically the same thing as using TinyHttpRequest(string, HttpRequestData).
        /// </summary>
        /// <param name="url"></param>
        /// <param name="reqType"></param>
        /// <param name="encLevel"></param>
        public TinyHttpRequest(string url, HttpRequestType reqType, HttpEncryptionLevel encLevel)
            : this(url, new HttpRequestData(reqType, encLevel))
        {
            
        }

        /// <summary>
        /// Initializes a TinyHttpRequest instance with a user-defined HttpRequestType, with no encryption
        /// </summary>
        /// <param name="url"></param>
        /// <param name="reqType"></param>
        public TinyHttpRequest(string url, HttpRequestType reqType)
            : this(url, new HttpRequestData(reqType, HttpEncryptionLevel.Http))
        {
            
        }

        /// <summary>
        /// Initializes a TinyHttpRequest instance with a user-defined HttpEncryptionLevel, and a GET request type.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="encryptionLevel"></param>
        public TinyHttpRequest(string url, HttpEncryptionLevel encryptionLevel)
            : this(url, new HttpRequestData(HttpRequestType.Get, encryptionLevel))
        {

        }
        #endregion
        #region Accessors/Mutators
        /// <summary>
        /// A readonly version of the Request URL
        /// </summary>
        public string RequestUrl { get { return Url; } }
        /// <summary>
        /// A readonly version of the Request Data
        /// </summary>
        public HttpRequestData RequestData { get { return Data; } }
        /// <summary>
        /// A readonly version of the Request Parameters.
        /// Allows Dictionary modification without using methods.
        /// </summary>
        public Dictionary<string, string> RequestParameters { get { return Parameters; } }
        /// <summary>
        /// A readonly version of the Request Headers.
        /// Allows Dictionary modification without using methods.
        /// </summary>
        public Dictionary<string, string> RequestHeaders { get { return Headers; } }
        /// <summary>
        /// Provides the ability to modify the requests proxy.
        /// </summary>
        public IWebProxy Proxy { get { return WebProxy; } set { WebProxy = value; } }
        /// <summary>
        /// Provides the ability to modify the Content Type of the request.
        /// </summary>
        public HttpContentType ContentType { get { return RequestContentType; } set { RequestContentType = value; } }
        /// <summary>
        /// Provides the ability to modify the request encoding.
        /// </summary>
        public Encoding Encoding { get { return RequestEncoding; } set { RequestEncoding = value; } }
        #endregion
        #region Events
        public event ProcessSuccessfulRequest OnSuccessfulRequest;
        public event ProcessFailedRequest OnFailedRequest;
        /// <summary>
        /// Callback delegate for processing successful requests.
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public delegate string ProcessSuccessfulRequest(HttpRequestResult result);
        /// <summary>
        /// Callback delegate for handling failed requests.
        /// </summary>
        /// <param name="failure"></param>
        public delegate void ProcessFailedRequest(Exception failure);
        #endregion
        #region Encoding and Setup
        /// <summary>
        /// Returns the Dictionary values of the RequestParameters joined in the correct
        /// format for making HTTP Requests
        /// </summary>
        /// <returns>Joined Parameters</returns>
        public string GetJoinedParameters()
        {
            var sb = new StringBuilder();
            sb.Append(Data.RequestType.Equals(HttpRequestType.Get) ? "?" : "");
            foreach (var pair in RequestParameters)
            {
                sb.Append(pair.Key + "=" + pair.Value);
                sb.Append("&");
            }
            return sb.Length > 1 ? sb.ToString().Substring(0, sb.Length - 1) : "";
        }
        #endregion
        #region Unthreaded Request Methods

        /// <summary>
        /// Makes an unthreaded HTTP request with the joined parameters.
        /// </summary>
        /// <returns>The result of the HTTP Request</returns>
        public HttpRequestResult MakeUnthreadedRequest()
        {
            return MakeUnthreadedRequest(this.GetJoinedParameters());
        }

        /// <summary>
        /// Makes an unthreaded HTTP request with the given raw data. Any and all
        /// exceptions need to be handled by the user.
        /// </summary>
        /// <param name="rawData"></param>
        /// <returns></returns>
        public HttpRequestResult MakeUnthreadedRequest(string rawData)
        {
            var requestUrl = Data.EncryptionLevel.UrlPrefix + Url;
            if (Data.RequestType.Equals(HttpRequestType.Get))
                requestUrl += (rawData.StartsWith("?") ? rawData : "?" + rawData);
            // create the request
            var request = WebRequest.CreateHttp(requestUrl);
            request.Accept = "*"; // avoid conflicts now, who even uses the accept header in other ways?
            request.Method = Data.RequestType.RequestType;
            foreach (var pair in RequestHeaders)
            {
                // assign all of the headers
                request.Headers.Add(pair.Key, pair.Value);
            }
            // treat GET like a special f-ing snowflake
            if (!Data.RequestType.Equals(HttpRequestType.Get))
            {
                request.ContentLength = rawData.Length;
                var writeStream = request.GetRequestStream();
                using (var writer = new StreamWriter(writeStream, RequestEncoding))
                {
                    writer.Write("content=" + rawData);
                }
            }
            // begin the process of getting the response (make the request)

            string responseBody;
            HttpStatusCode responseCode;
            using (var response = (HttpWebResponse) request.GetResponse())
            {
                responseCode = response.StatusCode;
// ReSharper disable once AssignNullToNotNullAttribute
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    responseBody = reader.ReadToEnd();
                }
            }
            return new HttpRequestResult(responseBody, responseCode);
        }
        #endregion
    }
}
