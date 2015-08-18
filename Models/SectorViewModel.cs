using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace junkiesWeb.Models
{
    public class SectorViewModel
    {
        private Sector sector;
        private IEnumerable<int> warps;
        
        public SectorViewModel(Sector s)
        {
            sector = s;
            warps = GetSectorWarps(sector.Id).Result;
        }
        
        public int Id
        {
            get { return sector.Id; }
        }
        public int No
        {
            get { return sector.No; }
        }
        
        public IEnumerable<int> Warps
        {
            get { return warps; }
        }
        
        public int QuadrantId
        {
            get { return sector.QuadrantId; }
        }
        
        
        private async Task<IEnumerable<int>> GetSectorWarps(int sectorId)
        {
            using (var client = new HttpClient())
            {
                var baseUri = "http://localhost:5000/api/Sector/" + sectorId + "/Warps";
                client.BaseAddress = new Uri(baseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                var response = await client.GetAsync(baseUri);
                if (response.IsSuccessStatusCode)
                {
                    var responseJson = await response.Content.ReadAsStringAsync();
                    List<int> warps = JsonConvert.DeserializeObject<List<int>>(responseJson);
                        
                    return warps;
                }
            }
            return null;
        }
    }
}