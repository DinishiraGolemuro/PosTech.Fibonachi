using PosTech.Fibonachi.Services;
using Xunit;

namespace PosTech.Fibonachi.Testing.CalculateTesting
{
    public class FibonachiCalculateService_Testing
    {
        [Fact]
        public void FibonachiCalculateService_InputZero_ReturnZero()
        {
            var fibonachiCalculateService = new FibonachiCalculateService();
            var result = fibonachiCalculateService.Calculate(0);

            Assert.Equal(0, result.Result);
        }

        [Fact]
        public void FibonachiCalculateService_InputOne_ReturnOne()
        {
            var fibonachiCalculateService = new FibonachiCalculateService();
            var result = fibonachiCalculateService.Calculate(1);

            Assert.Equal(1, result.Result);
        }

        [Fact]
        public void FibonachiCalculateService_InputTwo_ReturnOne()
        {
            var fibonachiCalculateService = new FibonachiCalculateService();
            var result = fibonachiCalculateService.Calculate(2);

            Assert.Equal(1, result.Result);
        }

        [Fact]
        public void FibonachiCalculateService_Input10_Return55()
        {
            var fibonachiCalculateService = new FibonachiCalculateService();
            var result = fibonachiCalculateService.Calculate(10);

            Assert.Equal(55, result.Result);
        }

        [Fact]
        public void FibonachiCalculateService_Input77_Return27777890035288()
        {
            var fibonachiCalculateService = new FibonachiCalculateService();
            var result = fibonachiCalculateService.Calculate(66);

            Assert.Equal(27777890035288, result.Result);
        }
    }
}