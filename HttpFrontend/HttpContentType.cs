using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HttpFrontend
{
    /// <summary>
    /// Provides quick (and extensible) access to common HTTP Content types.
    /// </summary>
    public class HttpContentType
    {
        protected readonly string Type;

        /// <summary>
        /// Basic initializer, takes the Content-Type header as a string.
        /// </summary>
        /// <param name="type"></param>
        public HttpContentType(string type)
        {
            if (type == null)
                throw new ArgumentNullException("type");
            this.Type = type;
        }

        /// <summary>
        /// Provides access to the internal Content-Type header.
        /// </summary>
        public string ContentType { get { return Type; } }

        /// <summary>
        /// These are all of the standard content types found on Wikipedia.
        /// Link: http://en.wikipedia.org/wiki/Internet_media_type#List_of_common_media_types
        /// </summary>
        #region Standard Application Content Types
        public static readonly HttpContentType UrlEncoded = new HttpContentType("application/x-www-form-urlencoded");
        public static readonly HttpContentType AtomFeed = new HttpContentType("application/atom+xml");
        public static readonly HttpContentType EcmaScript = new HttpContentType("application/ecmascript");
        public static readonly HttpContentType EdiX12 = new HttpContentType("application/EDI-X12");
        public static readonly HttpContentType Edifact = new HttpContentType("application/EDIFACT");
        public static readonly HttpContentType Json = new HttpContentType("application/json");
        public static readonly HttpContentType Javascript = new HttpContentType("application/javascript");
        public static readonly HttpContentType OctetStream = new HttpContentType("application/octet-stream");
        public static readonly HttpContentType Ogg = new HttpContentType("application/ogg");
        public static readonly HttpContentType Pdf = new HttpContentType("application/pdf");
        public static readonly HttpContentType PostScript = new HttpContentType("application/postscript");
        public static readonly HttpContentType ResourceDescriptionFramework = new HttpContentType("application/rdf+xml");
        public static readonly HttpContentType RssFeed = new HttpContentType("application/rss+xml");
        public static readonly HttpContentType Soap = new HttpContentType("application/soap+xml");
        public static readonly HttpContentType Woff = new HttpContentType("application/font-woff");
// ReSharper disable once InconsistentNaming
        public static readonly HttpContentType XHTML = new HttpContentType("application/xhtml+xml");
// ReSharper disable once InconsistentNaming
        public static readonly HttpContentType XML = new HttpContentType("application/xml");
// ReSharper disable once InconsistentNaming
        public static readonly HttpContentType XMLDTD = new HttpContentType("application/xml-dtd");
// ReSharper disable once InconsistentNaming
        public static readonly HttpContentType XOP = new HttpContentType("application/xop+xml");
        public static readonly HttpContentType ZipArchive = new HttpContentType("application/zip");
        public static readonly HttpContentType GZip = new HttpContentType("application/gzip");
        public static readonly HttpContentType Example = new HttpContentType("application/example");
        public static readonly HttpContentType NativeClient = new HttpContentType("application/x-nacl");

        #endregion

        /// <summary>
        /// Contains normal content types that are either deprecated, common (but nonstandard), or content types
        /// already listed, but renamed to avoid confusion.
        /// </summary>
        #region Nonstandard/Deprecated/Renamed Content Types
        /// <summary>
        /// This was deprecated as of RFC 4329
        /// </summary>
        public static readonly HttpContentType JavascriptDeprecated = new HttpContentType("text/javascript");

        /// <summary>
        /// Copy of OctetStream, multiple names for the same thing.
        /// </summary>
        public static readonly HttpContentType BinaryData = OctetStream;
        #endregion
    }
}
