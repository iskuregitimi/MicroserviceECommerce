using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;

namespace MicroserviceECommerce.MVCUI
{
    public static class HTTPHelper
    {
        public static T SendRequest<T>(string host, string resource, Method httpMethod)
            where T :new()
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, httpMethod);
            var response2 = client.Execute<T>(request);
            return response2.Data;
        }
        public static T GetDetail<T>(string host, string resource, Method httpMethod, string id) where T : new()
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, httpMethod);
            request.AddParameter("id", id);
            var response2 = client.Execute<T>(request);
            return response2.Data;
        }
    }
}