using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroserviceECommerce.MVCUI
{
	public class HttpHelper
	{
        public static T SendRequest<T>(string host, string resource, Method httpMethod)
          where T : new()
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, httpMethod);

            var response2 = client.Execute<T>(request);

            if (response2.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw response2.ErrorException;
            }

            return response2.Data;
        }

        public static T GetDetail<T>(string host, string id, string resource,  Method httpMethod)
           where T : new()
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, httpMethod) { RequestFormat = DataFormat.Json };
            request.AddParameter("id", id);


            var response2 = client.Execute<T>(request);

            if (response2.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw response2.ErrorException;
            }

            return response2.Data;
        }
     

        public static T AddRequestParam<T>(string host, string resource, object model, Method httpMethod)
           where T : new()
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, httpMethod);

            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(model);

            var response2 = client.Execute<T>(request);
            return response2.Data;
        }
        public static T AddRequestParam11<T>(string host, string resource, object model, string id, Method httpMethod)
          where T : new()
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, httpMethod);
            request.AddHeader("Content-type", "application/json");
            request.AddParameter("id", id, ParameterType.UrlSegment);
            request.AddJsonBody(model);

            var response2 = client.Execute<T>(request);
            return response2.Data;
        }
    }
}