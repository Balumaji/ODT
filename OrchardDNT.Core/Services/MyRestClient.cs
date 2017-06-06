using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using OrchardDNT.Core.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OrchardDNT.Core.Services
{
    public interface IMyRestClient
    {
        T Get<T>(string url) where T : new();
        IEnumerable<T> GetAll<T>(string url) where T : new();
        bool Post(string url, UserPost post);
    }

    public class MyRestClient : IMyRestClient
    {
        public T Get<T>(string url) where T : new()
        {
            var restClient = new RestClient(url);
            var restRequest = new RestRequest();

            var response = restClient.Execute<T>(restRequest);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Data;
            }
            throw new ApplicationException("Error fetching from REST API");
        }

        public IEnumerable<T> GetAll<T>(string url) where T:new()
        {
            var restClient = new RestClient(url);
            var restRequest = new RestRequest();

            var response = restClient.Execute<T>(restRequest);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var objCollection = JsonConvert.DeserializeObject<List<T>>(response.Content);
                return objCollection;
            }
            throw new ApplicationException("Error fetching from REST API");
        }

        public bool Post(string url, UserPost post)
        {
            var restClient = new RestClient(url);
            var request = new RestRequest();
            request.AddBody(post);
            var response = restClient.ExecuteAsPost(request, "POST");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;             
        }
    }
}