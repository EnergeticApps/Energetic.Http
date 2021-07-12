using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Energetic.Http
{
    public class DeserializationException<T> : InvalidOperationException
    {
        public DeserializationException(string jsonString) : base($"Couldn't deserialize \"{jsonString}\" to {typeof(T)}.") { }

    }
}
