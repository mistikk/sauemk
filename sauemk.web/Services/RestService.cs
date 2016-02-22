using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sauemk.web.Models;
using Newtonsoft.Json.Linq;
using sauemk.web.Core;
using System.Web.Mvc;

namespace sauemk.web.Services
{
    public class RestService : Controller
    {
        RestClient client = new RestClient("http://localhost:4545/");

        public Structure Get<T>(string res) where T : new()
        {
            var request = new RestRequest();
            request.Resource = res;
            return Execute<T>(request);
        }
        public Structure Get<T>(string res, string token) where T : new()
        {
            var request = new RestRequest();
            request.Resource = res;
            return Execute<T>(request, token);
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

        public Structure Execute<T>(RestRequest request) where T : new()
        {
            Response result = new Response();
            //var sa = Request.Headers["Authorization"];
            //request.AddParameter("Authorization", string.Format(sa), ParameterType.HttpHeader);

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
        public Structure Execute<T>(RestRequest request, string token) where T : new()
        {
            Response result = new Response();
            if (token != null)
            {
                request.AddParameter("Authorization", string.Format(token), ParameterType.HttpHeader);
            }

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