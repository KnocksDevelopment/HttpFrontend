using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpFrontend
{
    public class HttpRequestData
    {
        protected readonly HttpRequestType Type;
        protected readonly HttpEncryptionLevel Level;

        #region Constructor
        public HttpRequestData(HttpRequestType type, HttpEncryptionLevel encryptionLevel)
        {
            this.Type = type;
            this.Level = encryptionLevel;
        }
        #endregion
        #region Accessors/Mutators
        public HttpRequestType RequestType { get { return Type; } }
        public HttpEncryptionLevel EncryptionLevel { get { return Level; } }
        #endregion
    }
}
