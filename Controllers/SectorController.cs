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
    public class SectorController : Controller
    {
        private readonly IOptions<AppSettings> _settings;
        
        public SectorController(IOptions<AppSettings> settings)
        {
            _settings = settings;    
        }
        
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {

            using (var client = new HttpClient())
            {
                var baseUri = _settings.Options.JunkiesApiUri + "/sector";
                //var baseUri = "http://localhost:5000/api/sector";
                client.BaseAddress = new Uri(baseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                var response = await client.GetAsync(baseUri);
                if (response.IsSuccessStatusCode)
                {
                    var responseJson = await response.Content.ReadAsStringAsync();
                    List<Sector> sectorList = JsonConvert.DeserializeObject<List<Sector>>(responseJson);
                    
                    List<SectorViewModel> sectorvmList = new List<SectorViewModel>();
                    
                    foreach (var sector in sectorList)
                    {
                        SectorViewModel sectorvm = new SectorViewModel(sector);
                        sectorvmList.Add(sectorvm);
                    }    
                        
                    return View(sectorvmList);
                }
            }
            return View();
        }
    }
}