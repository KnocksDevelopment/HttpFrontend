namespace HttpFrontend
{
    public class HttpRequestType
    {
        protected string Type;

        private HttpRequestType(string type)
        {
            Type = type;
        }

        public string RequestType { get { return Type; } }

        public static readonly HttpRequestType Get = new HttpRequestType("GET");
        public static readonly HttpRequestType Post = new HttpRequestType("POST");
        public static readonly HttpRequestType Head = new HttpRequestType("HEAD");
        public static readonly HttpRequestType Options = new HttpRequestType("OPTIONS");
        public static readonly HttpRequestType Put = new HttpRequestType("PUT");
        public static readonly HttpRequestType Delete = new HttpRequestType("DELETE");
    }
}
