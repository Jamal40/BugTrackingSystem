using BugTrackingSystem.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Repositories
{
    public class ManipulateUsers
    {
        public void DeleteUser(string id)
        {
            //https://dev-5rw-rtkk.eu.auth0.com/api/v2/users/bvcb

            var client = new RestClient($"https://dev-5rw-rtkk.eu.auth0.com/api/v2/users/{id}");
            string accessToken = AccToken.GetAccessToken();
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", $"Bearer {accessToken}");
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);
        }
    }
}
