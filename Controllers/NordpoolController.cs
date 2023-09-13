using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace veeb_back_end_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NordpoolController : ControllerBase
    {
        //API päring teise rakendusse: Elering hindade kättesaamine

        /*private readonly HttpClient _httpClient;

        public NordpoolController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetNordpoolPrices()
        {
            var response = await _httpClient.GetAsync("https://dashboard.elering.ee/api/nps/price");
            var responseBody = await response.Content.ReadAsStringAsync();
            return Content(responseBody, "application/json");
        }*/

        //API päring teise rakendusse: Elering päringu modifitseerimine

        private readonly HttpClient _httpClient;

        public NordpoolController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("{country}")]
        public async Task<IActionResult> GetNordPoolPrices(string country)
        {
            var response = await _httpClient.GetAsync("https://dashboard.elering.ee/api/nps/price");
            var responseBody = await response.Content.ReadAsStringAsync();
            var jsonDoc = JsonDocument.Parse(responseBody);
            var dataProperty = jsonDoc.RootElement.GetProperty("data");

            if (country == "ee")
            {
                var prices = dataProperty.GetProperty("ee").ToString();
                return Content(prices, "application/json");
            }
            else if (country == "lv")
            {
                var prices = dataProperty.GetProperty("lv").ToString();
                return Content(prices, "application/json");
            }
            else if (country == "lt")
            {
                var prices = dataProperty.GetProperty("lt").ToString();
                return Content(prices, "application/json");
            }
            else if (country == "fi")
            {
                var prices = dataProperty.GetProperty("fi").ToString();
                return Content(prices, "application/json");
            }
            else
            {
                return BadRequest("Invalid country code.");
            }
        }
    }
}
