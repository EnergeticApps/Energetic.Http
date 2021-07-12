using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Energetic.Http
{
    public class UnexpectedHttpResponseException : InvalidOperationException
    {
        public UnexpectedHttpResponseException(HttpStatusCode unexpectedCode, string reasonPhrase) :
            base($"An unexpected response was received from an API. Status code: {unexpectedCode}.")
        {
            ResponseStatusCode = unexpectedCode;
            ResponseReasonPhrase = reasonPhrase;
        }


        public HttpStatusCode ResponseStatusCode { get; private set; }

        public string ResponseReasonPhrase { get; private set;  }
    }
}
