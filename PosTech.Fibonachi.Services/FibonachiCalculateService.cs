using EasyNetQ;
using PosTech.Fibonachi.Infrastructure;
using PosTech.Fibonachi.Models;
using System.Linq;

namespace PosTech.Fibonachi.Services
{
    public class FibonachiCalculateService : ICalculate
    {
        private readonly IBus _bus;
        private readonly double[] _prevValues;

        public FibonachiCalculateService(IBus bus)
        {
            _bus = bus;
            _prevValues = new double[2] { 1, 1 };
        }

        public void Calculate(FibonachiRequest fibonachiRequest)
        {
            Enumerable.Range(0, fibonachiRequest.SequenceLength).ToList()
                .ForEach(async x =>
                {
                    if (x == 0)
                    {
                        var result = new FibonachiResponse(0);
                        await _bus.PubSub.PublishAsync(result, "fibonachi");
                    }
                    else if (x > 0 && x < 3)
                    {
                        var result = new FibonachiResponse(1);
                        await _bus.PubSub.PublishAsync(result, "fibonachi");
                    }
                    else
                    {
                        var nextValue = _prevValues[0] + _prevValues[1];

                        _prevValues[0] = _prevValues[1];
                        _prevValues[1] = nextValue;

                        var result = new FibonachiResponse(_prevValues.Last());
                        await _bus.PubSub.PublishAsync(result, "fibonachi");
                    }
                });
        }
    }
}