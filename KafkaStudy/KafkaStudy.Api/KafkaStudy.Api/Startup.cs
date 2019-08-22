using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KafkaStudy.Api.Rx;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
            services.AddSingleton<IKafkaClient, KafkaClient>();
            services.AddSingleton(typeof(IKafkaRxConsumerStream<>), typeof(KafkaRxConsumerStream<>));
            services.AddMvc();
            services.AddTransient<IKafkaMessageHandler<User>, UserHandler>();
            services.AddTransient<UserHandler>();
         
            services.AddTransient(typeof(IKafkaMessageConsumer<>), typeof(KafkaMessageConsumer<>));

            //services.AddTransient<BackgroundPerPartitionConsumer<User>>();
            //services.AddTransient<IHostedService>(sp => sp.GetRequiredService<BackgroundPerPartitionConsumer<User>>());
            services.AddTransient<BackgroundPerPartitionConsumer<User>>();
            services.AddHostedService<BackgroundPerPartitionConsumer1<User>>();
            services.AddSingleton<IHostedService>(sp => sp.GetRequiredService<BackgroundPerPartitionConsumer<User>>());
            services.AddSingleton<IHostedService>(sp => sp.GetRequiredService<BackgroundPerPartitionConsumer<User>>());
            services.AddSingleton<IHostedService>(sp => sp.GetRequiredService<BackgroundPerPartitionConsumer<User>>());
            services.AddSingleton<IHostedService>(sp => sp.GetRequiredService<BackgroundPerPartitionConsumer<User>>());
            
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