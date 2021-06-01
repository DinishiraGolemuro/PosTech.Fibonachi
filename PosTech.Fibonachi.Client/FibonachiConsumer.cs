using EasyNetQ.AutoSubscribe;
using PosTech.Fibonachi.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PosTech.Fibonachi.Client
{
    public class FibonachiConsumer : IConsumeAsync<FibonachiResponse>
    {
        [AutoSubscriberConsumer(SubscriptionId = "fibonachi")]
        public Task ConsumeAsync(FibonachiResponse message, CancellationToken cancellationToken = default)
        {
            Console.WriteLine(message.Result);
            return Task.FromResult(1);
        }
    }
}