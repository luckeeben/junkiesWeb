using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using junkiesWeb.Services;
using junkiesWeb.Models;

namespace junkiesWeb.Controllers
{
    [Route("[controller]")]
    public class QuadrantController : Controller
    {
        private static RestService RestService;
        
        public QuadrantController(RestService restservice)
        {
            RestService = restservice;
        }
        
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        //public IActionResult Index()
        {
            List<Quadrant> quadrants = await RestService.GetAsync<List<Quadrant>>("/quadrant");
            if (quadrants != null)
            {
                return View(quadrants);
            }

            return View();
        }
    }
}
