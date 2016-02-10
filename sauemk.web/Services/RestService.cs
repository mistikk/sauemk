using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sauemk.web.Models;
using Newtonsoft.Json.Linq;
using sauemk.web.Core;

namespace sauemk.web.Services
{
    public class RestService
    {
        RestClient client = new RestClient("http://localhost:4242/");

        public Structure Get<T>(string res) where T : new()
        {
            var request = new RestRequest();
            request.Resource = res;
            return Execute<T>(request);
        }

        public Structure login(string username, string password)
        {
            Response result = new Response();
            var request = new RestRequest("token", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("grant_type", "password");
            request.AddParameter("userName", username);
            request.AddParameter("password", password);
            var response = client.Execute<TokenModel>(request);
            if (response.StatusDescription == "Bad Request")
            {
                return result.Error("BadRequest");
            }

            return result.Data(response.Data);
        }



        private Structure Execute<T>(RestRequest request) where T : new()
        {
            Response result = new Response();
            var response = client.Execute<T>(request);

            if (response.StatusDescription == "Unauthorized")
            {
                return result.AuthorizeError();
            }

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var twilioException = new ApplicationException(message, response.ErrorException);
                throw twilioException;
            }
            return result.Data(response.Data);
        }
        

    }
}