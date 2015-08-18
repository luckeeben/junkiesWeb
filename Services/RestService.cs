using System.Threading.Tasks;
using RestSharp;

namespace junkiesWeb.Services
{
        public class RestService
	{
        private string baseuri = "http://localhost:5000/api";       
                   
        public async Task<T> GetAsync<T>(string resource) 
        {
            var client = new RestClient(baseuri);
            var request = new RestRequest(resource, Method.GET);
            var response = await client.ExecuteTaskAsync<T>(request);           
            return response.Data;    
        }
	}
	
}


