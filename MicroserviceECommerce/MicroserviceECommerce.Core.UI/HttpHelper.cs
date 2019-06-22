using MicroserviceECommerce.Core.UI.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroserviceECommerce.Core.UI
{
    public static class HttpHelper
    {
        public static T GetData<T>(string host, string resource, Method httpMethod)
            where T : new()
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, httpMethod);
            var response2 = client.Execute<T>(request);
            return response2.Data;
        }

        public static T SendIdGetData<T>(string host, string resource, Method httpMethod, string id)
           where T : new()
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, httpMethod);
            request.AddParameter("id", id);
            var response2 = client.Execute<T>(request);
            return response2.Data;
        }

        public static void SendData(string host, string resource, Method httpMethod, object data)
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, httpMethod);
            request.AddJsonBody(data);
            var response2 = client.Execute(request);
        }

        public static void SendId(string host, string resource, Method httpMethod, string id)
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, httpMethod);
            request.AddParameter("id", id);
            var response2 = client.Execute(request);
        }

    }
}