using KafkaStudy.Api.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace KafkaStudy.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddKafka(options =>
            {
                options.AddProducers(producerOptions => producerOptions.AddProducer<User>());

                options.AddConsumer(consumerOptions =>
                {
                    consumerOptions.PartitionCount = 4;
                    consumerOptions.AddTopic<User>("my-topic");
                    consumerOptions.AddTopic<User>("my-second-topic");
                    consumerOptions.AddTopic<User>();
                });
                
                options.UseProtoBufSerializer();
            });
            
            services.AddMvc();
            services.AddHttpClient();
            
            services.AddTransient<IKafkaMessageHandler<User>, UserHandler>();
            services.AddTransient<UserHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
