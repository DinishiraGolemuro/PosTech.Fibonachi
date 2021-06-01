using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace PosTech.Fibonachi.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddControllers(options => options.EnableEndpointRouting = false);
            services.AddSingleton(RabbitHutch.CreateBus("host=localhost"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IBus bus, Microsoft.Extensions.Hosting.IApplicationLifetime lifeTime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            var assembly = Assembly.GetExecutingAssembly();
            lifeTime.ApplicationStarted.Register(() =>
            {
                var subscriber = new AutoSubscriber(bus, "fibonachi");
                subscriber.SubscribeAsync(new Assembly[] { assembly });
            });

            lifeTime.ApplicationStopped.Register(() => { bus.Dispose(); });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}