using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroserviceECommerce.MVCUI.HTTPHelperMethpds
{
    public class HTTPHelpers
    {
        public static T GetListMethod<T>(string host, string resource, Method httpMethod)
            where T : new()
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, httpMethod);
            var response2 = client.Execute<T>(request);
            return response2.Data;
        }

        public static void PostMethod(string host, string resource, Method Httpmethod, object obj)
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, Httpmethod);
            request.AddJsonBody(obj);
            client.Execute(request);
        }

        public static T GetMethod<T>(string host, string resource, Method httpMethod, string id)
           where T : new()
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, httpMethod);
            request.AddParameter("id", id);
            var response2 = client.Execute<T>(request);
            return response2.Data;
        }

        public static void DeleteMethod(string host, string resource, Method Httpmethod, string id)
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, Httpmethod);
            request.AddParameter("id", id);
            client.Execute(request);
        }
    }
}