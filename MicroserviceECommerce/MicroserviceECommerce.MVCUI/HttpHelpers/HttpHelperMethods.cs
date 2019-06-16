using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroserviceECommerce.MVCUI.HttpHelpers
{
    public class HttpHelperMethods
    {
        public static T GetAll<T>(string host, string resource, Method httpMethod)
                   where T : new()
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, httpMethod);
            var response = client.Execute<T>(request);
            return response.Data;
        }
        public static T GetWithId<T>(string host, string resource, Method httpMethod, string Id)
                  where T : new()
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, httpMethod);
            request.AddParameter("Id", Id);
            var response = client.Execute<T>(request);
            return response.Data;
        }
        public static void Add<T>(string host, string resource, Method Httpmethod, T t)
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, Httpmethod);
            request.AddJsonBody(t);
            client.Execute(request);
        }
        public static void Edit<T>(string host, string resource, Method Httpmethod, T t, string Id)
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, Httpmethod);
            request.AddParameter("Id", Id);
            request.AddJsonBody(t);
            client.Execute(request);
        }
        public static void Delete<T>(string host, string resource, Method Httpmethod, string Id)
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, Httpmethod);
            request.AddParameter("Id", Id);
            client.Execute(request);
        }
    }
}
