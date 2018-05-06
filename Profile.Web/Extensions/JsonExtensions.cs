using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Profile.Web.Extensions
{
    //this is an extension method that makes AdminController more readable

    public static class JsonExtensions
    {
        public static string GetElementValue(this JToken jtoken, int elementIndex)
        {
            return jtoken.Children<JToken>().ElementAt(elementIndex).Value<string>();
        }

        public static IEnumerable<JToken> GetSheetRow(this JObject jobject, int rowIndex)
        {
            return jobject.Children<JToken>().ElementAt(rowIndex).Children<JToken>().Values<JToken>();
        }
    }
}
