using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace EmployeeClientWithBlazor.Services
{
    public class EmployeeService<T> : IEmployeeService<T>
    {

        public HttpClient _httpClient { get; }

        public EmployeeService(HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Add("User-Agent", "BlazorServer");
            _httpClient = httpClient;
        }

        async Task<T[]> IEmployeeService<T>.GetAllEmployeeAsync(string requestUri)
        {
            Console.WriteLine("********* I am in get all employee service");

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);

            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;

            if (responseStatusCode.ToString() == "OK")
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return await Task.FromResult(JsonConvert.DeserializeObject<T[]>(responseBody));
            }
            else
                return null;
        }

        async Task<T> IEmployeeService<T>.GetEmployeeByIdAsync(string requestUri, int Id)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri + Id);

            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            return await Task.FromResult(JsonConvert.DeserializeObject<T>(responseBody));
        }

        async Task<bool> IEmployeeService<T>.SaveEmployeeAsync(string requestUri, T obj)
        {
            string serializedEmployeeObject = JsonConvert.SerializeObject(obj);

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri);


            requestMessage.Content = new StringContent(serializedEmployeeObject);

            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            return (response.StatusCode.ToString() == "OK");
        }

        async Task<bool> IEmployeeService<T>.UpdateEmployeeAsync(string requestUri, int Id, T obj)
        {
            string serializedEmployee = JsonConvert.SerializeObject(obj);

            var requestMessage = new HttpRequestMessage(HttpMethod.Put, requestUri + Id);
           
            requestMessage.Content = new StringContent(serializedEmployee);

            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            return (response.StatusCode.ToString() == "OK");
        }

        async Task<bool> IEmployeeService<T>.DeleteEmployeeAsync(string requestUri, int Id)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, requestUri + Id);

            var response = await _httpClient.SendAsync(requestMessage);

            return (response.StatusCode.ToString() == "OK");
        }
    }
}
