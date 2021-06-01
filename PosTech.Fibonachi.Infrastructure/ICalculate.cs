using PosTech.Fibonachi.Models;

namespace PosTech.Fibonachi.Infrastructure
{
    public interface ICalculate
    {
        void Calculate(FibonachiRequest fibonachiRequest);
    }
}