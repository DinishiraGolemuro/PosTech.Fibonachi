using Microsoft.AspNetCore.Mvc;
using PosTech.Fibonachi.Infrastructure;
using PosTech.Fibonachi.Models;

namespace PosTech.Fibonachi.CalculateServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculateController : ControllerBase
    {
        private readonly ICalculate _calculate;

        public CalculateController(ICalculate calculate)
        {
            _calculate = calculate;
        }

        /// <summary>
        /// Рассчёт чисел Фибоначи
        /// </summary>
        /// <param name="num">Количество чисел</param>
        [HttpPost]
        [Route("fibonachicalculate")]
        public void FibonachiCalculate(FibonachiRequest fibonachiRequest)
        {
            _calculate.Calculate(fibonachiRequest);
        }
    }
}