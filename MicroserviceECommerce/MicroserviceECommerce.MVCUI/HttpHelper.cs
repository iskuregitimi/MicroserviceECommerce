using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroserviceECommerce.MVCUI
{
    public static class HttpHelper
    {
        public static T GetList<T>(string host, string resource, Method httpMethod)
            where T : new()
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, httpMethod) { RequestFormat = DataFormat.Json };
            var response = client.Execute<T>(request);
            return response.Data;
        }
        public static T GetList<T>(string host, string resource, Method httpMethod, string id)
           where T : new()
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, httpMethod) { RequestFormat = DataFormat.Json };
            request.AddParameter("id", id);
            var response = client.Execute<T>(request);
            return response.Data;
        }

        public static T GetList<T>(string host, string resource, Method httpMethod, int id)
          where T : new()
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, httpMethod) { RequestFormat = DataFormat.Json };
            request.AddParameter("id", id);
            var response = client.Execute<T>(request);
            return response.Data;
        }
        public static T Add<T>(string host, string resource, object _object, Method httpMethod)
           where T : new()
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, httpMethod) { RequestFormat = DataFormat.Json };
            //request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(_object);
            var response = client.Execute<T>(request).Data;
            return response;
        }
        public static T Add<T>(string host, string resource, object _object, int id, Method httpMethod)
          where T : new()
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource + "?id={id}", httpMethod);
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(_object);
            request.AddParameter("id", id, ParameterType.UrlSegment);
            var response = client.Execute<T>(request).Data;
            return response;
        }

        public static T GetDetail<T>(string host, string resource, Method httpMethod, int id)
            where T : new()
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, httpMethod) { RequestFormat = DataFormat.Json };
            request.AddParameter("id", id);
            var response2 = client.Execute<T>(request).Data;
            return response2;
        }

        public static T GetDetail<T>(string host, string resource, Method httpMethod, string id)
           where T : new()
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, httpMethod) { RequestFormat = DataFormat.Json };
            request.AddParameter("id", id);
            var response2 = client.Execute<T>(request).Data;
            return response2;
        }
    }
}