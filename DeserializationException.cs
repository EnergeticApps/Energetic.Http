using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Energetic.Http
{
    public class DeserializationException<T> : InvalidOperationException
    {
        public DeserializationException() : base() { }

        public DeserializationException(string message) : base(message) { }

        public DeserializationException(string message, Exception innerException) : base(message, innerException) { }

        public static DeserializationException<T> FromJson(string? json)
        {
            if(string.IsNullOrWhiteSpace(json))
            {
                return new DeserializationException<T>(
                    ExceptionMessages.DeserializingBlankJsonProblem<T>()) 
                { Json = json };
            }
            else
            {
                return new DeserializationException<T>(
                    ExceptionMessages.DeserializationProblem<T>(json))
                { Json = json };
            }
        }


        public string? Json { get; private set;  }

    }
}
