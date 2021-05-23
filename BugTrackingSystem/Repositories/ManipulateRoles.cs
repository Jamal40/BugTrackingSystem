using BugTrackingSystem.Models;
using Nancy.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Repositories
{
    public class ManipulateRoles
    {
        public void AssignRoleToUser(string UserID, string RoleID)
        {
            var client = new RestClient($"https://dev-5rw-rtkk.eu.auth0.com/api/v2/users/{UserID}/roles");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            string accessToken = AccToken.GetAccessToken();
            request.AddHeader("authorization", $"Bearer {accessToken}");
            request.AddHeader("cache-control", "no-cache");
            request.AddParameter("application/json", $"{{ \"roles\": [ \"{RoleID}\", \"{RoleID}\" ] }}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
        }
        public void DeleteRoleFromUser(string UserID, string RoleID)
        {
            var client = new RestClient($"https://dev-5rw-rtkk.eu.auth0.com/api/v2/users/{UserID}/roles");
            string accessToken = AccToken.GetAccessToken();
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", $"Bearer {accessToken}");
            request.AddHeader("cache-control", "no-cache");
            request.AddParameter("application/json", $"{{ \"roles\": [ \"{RoleID}\", \"{RoleID}\" ] }}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
        }
        public Role GetUserRoles(string UserID)
        {
            var client = new RestClient($"https://dev-5rw-rtkk.eu.auth0.com/api/v2/users/{UserID}/roles");
            var request = new RestRequest(Method.GET);
            string accessToken = AccToken.GetAccessToken();
            request.AddHeader("authorization", $"Bearer {accessToken}");
            IRestResponse response = client.Execute(request);

            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            Role userRole = json_serializer.Deserialize<List<Role>>(response.Content).FirstOrDefault();

            return userRole;
        }


    }
}
