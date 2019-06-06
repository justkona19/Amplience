using System;
using Amplience.Model;
using RestSharp;

namespace Amplience.API.Utilities
{
    public class Services
    {
        public static IRestResponse<GitHubUserDetails> GetUserDetails(string url, string Userid)
        {
            var client = new RestClient(url);

            var request = new RestRequest("users/{id}", Method.GET);
            request.AddUrlSegment("id", Userid);

            var response = client.Execute<GitHubUserDetails>(request);
            return response;
        }

        public static int GetStatusCode(string url, string Userid)
        {
           var response = GetUserDetails(url,Userid);
           return (int)response.StatusCode;
        }
    }
}
