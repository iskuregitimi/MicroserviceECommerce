﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroserviceECommerce.MVCUI
{
    public class HTTPHELPER
    {
        //Listeleme işlemleri için 
        public static T SendRequestList<T>(string host, string resource, Method httpMethod)
          where T : new()
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, httpMethod);

            var response2 = client.Execute<T>(request);
            return response2.Data;
        }
        public static T SendRequestCreate<T>(string host, string resource, object model, Method httpMethod)
        where T : new()
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, httpMethod);

            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(model);

            var response2 = client.Execute<T>(request);
            return response2.Data;
        }
        public static T SendRequestParam<T>(string host, string resource, string id, Method httpMethod)
           where T : new()
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource + "?id={id}", httpMethod);
            request.AddParameter("id",id, ParameterType.UrlSegment);
            var response2 = client.Execute<T>(request);
            return response2.Data;
        }

        public static T SendRequestParamdetail<T>(string host, string resource, int id, Method httpMethod)
         where T : new()
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource + "?id={id}", httpMethod);
            request.AddParameter("id", id, ParameterType.UrlSegment);
            var response2 = client.Execute<T>(request);
            return response2.Data;
        }
    }
}