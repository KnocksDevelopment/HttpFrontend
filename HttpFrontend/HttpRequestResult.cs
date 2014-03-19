using System;
using System.Net;

namespace HttpFrontend
{
    public class HttpRequestResult
    {
        protected readonly string ResultBody;
        protected readonly HttpStatusCode ResultCode;
        protected HttpContentType ResultContentType;

        #region Constructors
        /// <summary>
        /// Wrapper for a successfuly HTTP Response.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="?"></param>
        public HttpRequestResult(string data, HttpStatusCode code)
        {
            if (data == null) // shouldn't ever happen
                throw new ArgumentNullException("data");
            this.ResultBody = data;
            this.ResultCode = code;
        }
        #endregion
        #region Accessors

        /// <summary>
        /// Provides access to the returned Request body.
        /// </summary>
        public string Body { get { return ResultBody; } }
        /// <summary>
        /// Provides access to the returned Request code.
        /// </summary>
        public HttpStatusCode Code { get { return ResultCode; } }

        /// <summary>
        /// The given content type of the response.
        /// </summary>
        public HttpContentType ContentType { get { return ResultContentType; }  set { ResultContentType = value; }}

        #endregion
    }
}
