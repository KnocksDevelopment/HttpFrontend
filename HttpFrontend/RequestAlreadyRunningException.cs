using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpFrontend
{
    public class RequestAlreadyRunningException : Exception
    {
        protected readonly string Url;

        public RequestAlreadyRunningException(string message, string url) : base(message)
        {
            this.Url = url;
        }

        /// <summary>
        /// Allows access to the failed Request URL.
        /// </summary>
        public string RequestUrl { get { return Url; } }
    }
}
