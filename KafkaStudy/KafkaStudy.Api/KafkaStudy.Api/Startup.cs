using KafkaStudy.Api.Configuration;
using KafkaStudy.Api.Rx;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace KafkaStudy.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddKafkaProducers(options =>
            { 
                options.AddProducer<User>();
            });

            services
                .AddKafkaConsumer(options =>
                {
                    options.PartitionCount = 4;
                    options.AddTopic<User>("my-topic");
                })
                .AddKafkaConsumer(options =>
                {
                    options.PartitionCount = 1;
                    options.AddTopic<User>("my-second-topic");
                });
            
            services.AddSingleton(typeof(IKafkaRxConsumerStream<>), typeof(KafkaRxConsumerStream<>));
            services.AddMvc();
            services.AddTransient<IKafkaMessageHandler<User>, UserHandler>();
            services.AddTransient<UserHandler>();
         
            services.AddTransient<IKafkaMessageConsumer, KafkaMessageConsumer<User>>();
            services.AddTransient<KafkaMessageConsumer<User>>();
            services.AddTransient<IKafkaMessageConsumerFactory, KafkaMessageConsumerFactory>();

            services.AddTransient(typeof(IMessageSerializer<>), typeof(ProtobufSerializer<>));
            
            //services.AddTransient<BackgroundPerPartitionConsumer<User>>();
            //services.AddTransient<IHostedService>(sp => sp.GetRequiredService<BackgroundPerPartitionConsumer<User>>());
            services.AddTransient<BackgroundPerPartitionConsumer>();
            services.AddSingleton<IHostedService>(sp => sp.GetRequiredService<BackgroundPerPartitionConsumer>());
            services.AddSingleton<IHostedService>(sp => sp.GetRequiredService<BackgroundPerPartitionConsumer>());
            services.AddSingleton<IHostedService>(sp => sp.GetRequiredService<BackgroundPerPartitionConsumer>());
            services.AddSingleton<IHostedService>(sp => sp.GetRequiredService<BackgroundPerPartitionConsumer>());
            
            //services.AddHostedService<BackgroundPerPartitionConsumer<User>>();

            services.AddHttpClient();
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
