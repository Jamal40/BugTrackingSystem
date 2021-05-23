using Nancy.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Models
{
    public class AccToken
    {
        public string access_token { get; set; }

        public static string GetAccessToken()
        {
            var client = new RestClient("https://dev-5rw-rtkk.eu.auth0.com/oauth/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", "grant_type=client_credentials&client_id=NRjPyKxa7i6c7ep0fWqJZgdpwNkchQTF&client_secret=mupars1gdXzqK4_B7WkG98opmJ4yg-BBhRZ7HN_fwA-qxpZogFg6FkfY0QZ-Nols&audience=https://dev-5rw-rtkk.eu.auth0.com/api/v2/", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            AccToken token = json_serializer.Deserialize<AccToken>(response.Content);
            return token.access_token;
        }
    }
}
