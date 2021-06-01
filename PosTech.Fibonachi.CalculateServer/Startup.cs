using EasyNetQ;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PosTech.Fibonachi.Infrastructure;
using PosTech.Fibonachi.Services;

namespace PosTech.Fibonachi.CalculateServer
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers(options => options.EnableEndpointRouting = false);
            services.AddSingleton(RabbitHutch.CreateBus("host=localhost"));
            services.AddScoped<ICalculate, FibonachiCalculateService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IBus bus)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}