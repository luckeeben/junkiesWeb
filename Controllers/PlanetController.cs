using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using System.Net.Http;
using System.Collections.Generic;
using junkiesWeb.Models;
using Newtonsoft.Json;
using Microsoft.Framework.OptionsModel;

namespace junkiesWeb.Controllers
{
    [Route("[controller]")]
    public class PlanetController : Controller
    {
        private readonly IOptions<AppSettings> _settings;
        
        public PlanetController(IOptions<AppSettings> settings)
        {
            _settings = settings;    
        }
        
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {

            using (var client = new HttpClient())
            {
                var baseUri = _settings.Options.JunkiesApiUri + "/planet";
                //var baseUri = "http://localhost:5000/api/planet";
                client.BaseAddress = new Uri(baseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                var response = await client.GetAsync(baseUri);
                if (response.IsSuccessStatusCode)
                {
                    var responseJson = await response.Content.ReadAsStringAsync();
                    List<Planet> planets = JsonConvert.DeserializeObject<List<Planet>>(responseJson);
                        
                        
                    return View(planets);
                }
            }
            return View();
        }
    }
}