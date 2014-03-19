using System;

namespace TinyHTTP
{
    public class HttpEncryptionLevel
    {
        protected readonly string Prefix;
        private HttpEncryptionLevel(string urlprefix)
        {
            if (urlprefix == null) // we should never need this lol
                throw new ArgumentNullException("urlprefix");
            Prefix = urlprefix;
        }

        public string UrlPrefix { get { return Prefix; } }

        public static readonly HttpEncryptionLevel Http = new HttpEncryptionLevel("http://");
        public static readonly HttpEncryptionLevel Https = new HttpEncryptionLevel("https://");
    }
}
