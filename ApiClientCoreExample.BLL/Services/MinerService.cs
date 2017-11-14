using ApiClientCoreExample.BLL.DTO;
using ApiClientCoreExample.BLL.Infrastructure;
using ApiClientCoreExample.BLL.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ApiClientCoreExample.BLL.Services
{
    public class MinerService : IMinerService
    {
        protected string Baseurl = "https://api.ethermine.org";

        public async Task<DataDTO> GetCurrentStats(string miner)
        {

            DataDTO data = null;
            StatsDTO currentStats = null;

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync($"/miner/:{miner}/currentStats");

                //Checking the response is successful or not which is sent using HttpClient  
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    string info = Response;
                    currentStats = JsonConvert.DeserializeObject<StatsDTO>(info, settings);
                }
                if (currentStats.Status.ToLower() == "error")
                {
                    throw new BusinessLogicException(currentStats.Error, "");
                }

                data = currentStats.Data;
            }
            return data;
        }



    }
}
