using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BabyGiftRegisterLibrary.Model;
using Newtonsoft.Json;

namespace WebLogic
{
    public class RestClient
    {
        public static async Task<List<RegisterItem>> GetRegisterItems()
        {
            var httpClient = new HttpClient();
            var contentsTask =
                httpClient.GetStringAsync("http://192.168.0.6/BabyRegisterWeb/api/RegisterItem/GetItemsInRegister");
            var contents = await contentsTask;
            return JsonConvert.DeserializeObject<List<RegisterItem>>(contents);
        }
    }
}