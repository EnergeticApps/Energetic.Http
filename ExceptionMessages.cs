using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Energetic.Http
{
    internal static class ExceptionMessages
    {
        public static string MappingProblem<TSource, TDestination>()
        {
            return $"Could not deserialize object from type {typeof(TSource)} to type {typeof(TDestination)}. Result was null.";
        }

        public static string DeserializationProblem<T>(string json)
        {
            return $"Could not deserialize the JSON into an object of type {typeof(T)}. Result was null. JSON was: {json}";
        }

        public static string DeserializingBlankJsonProblem<T>()
        {
            return $"Could not deserialize a null, empty or whitespace JSON string into an object of type {typeof(T)}. Result was null.";
        }
    }
}
