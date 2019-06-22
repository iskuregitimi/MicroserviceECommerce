using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroserviceECommerce.CoreUI.HttpHelper
{
    public static class CustomerHelper
    {
        public static T GetList<T>(string host, string resource, Method httpMethod)
            where T : new()
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, httpMethod) { RequestFormat = DataFormat.Json };
            var response = client.Execute<T>(request);
            return response.Data;
        }
             
        public static T Add<T>(string host, string resource, object _object, Method httpMethod)
           where T : new()
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, httpMethod) { RequestFormat = DataFormat.Json };
            request.AddJsonBody(_object);
            var response = client.Execute<T>(request).Data;
            return response;
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
        public static T Update<T>(string host, string resource, Method httpMethod, object _object)
          where T : new()
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, httpMethod) { RequestFormat = DataFormat.Json };
            request.AddJsonBody(_object);
            var response2 = client.Execute<T>(request).Data;
            return response2;
        }
        public static T Delete<T>(string host, string resource, Method httpMethod, string id)
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