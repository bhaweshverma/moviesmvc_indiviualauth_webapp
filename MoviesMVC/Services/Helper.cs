using System;  
using System.Net.Http;  
using System.Net.Http.Headers;  
using MoviesMVC.Models;
  
namespace MoviesMVC.Services.Helper  
{  
    public class UserAPI  
    {  
        private string _apiBaseURI = "http://localhost:5002";  
        public HttpClient InitializeClient()  
        {  
            var client = new HttpClient();  
            //Passing service base url    
            client.BaseAddress = new Uri(_apiBaseURI);  
  
            client.DefaultRequestHeaders.Clear();  
            //Define request data format    
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));  
  
            return client;  
        }  
    }     
}  