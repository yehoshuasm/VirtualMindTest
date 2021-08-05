using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace VirtualMindApi.Providers.BancoProvincia
{
    public class BancoProvinciaDollarExchangeRateProvider : IDollarExchangeRateProvider
    {
        public async Task<decimal> GetExchangeRate()
        {
            const string url = "http://www.bancoprovincia.com.ar/Principal/Dolar";

            var httpClient = new HttpClient();

            var stringResponse = await httpClient.GetStringAsync(url);

            var deserializedResponse = JsonConvert.DeserializeObject<string[]>(stringResponse);

            var dollarRate = deserializedResponse[0];

            return decimal.Parse(dollarRate);
        }
    }
}
