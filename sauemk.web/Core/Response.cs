using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sauemk.web.Core
{
    public class Response
    {
        public Structure Data(dynamic data)
        {
            Structure response = new Structure();
            response.error = false;
            response.data = data;
            return response;
        }
        public Structure Error(dynamic error)
        {
            Structure response = new Structure();
            response.error = error;
            response.data = null;
            return response;
        }
        public Structure ModelError()
        {
            Structure response = new Structure();
            response.error = "Model is not valid";
            response.data = null;
            return response;
        }
        public Structure AuthorizeError()
        {
            Structure response = new Structure();
            response.error = 401;
            response.data = null;
            return response;
        }
    }
}