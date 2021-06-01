using Microsoft.AspNetCore.Mvc;
using PosTech.Fibonachi.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PosTech.Fibonachi.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FibonachiController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        public FibonachiController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpPost]
        [Route("calculate")]
        public async Task<IActionResult> Calculate(FibonachiRequest fibonachiRequest)
        {
            var request = new StringContent(JsonSerializer.Serialize(fibonachiRequest),
                Encoding.UTF8, "application/json");

            var client = _clientFactory.CreateClient();
            var response = await client.PostAsync("http://localhost:5003/api/calculate/fibonachicalculate", request);

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}