﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MicroserviceECommerce.Customer.CoreApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}

//// This method gets called by the runtime. Use this method to add services to the container.
//public void ConfigureServices(IServiceCollection services)
//{
//    services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info { Title = "TestAPI", Version = "V1" }); });
//    services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
//}

//// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//public void Configure(IApplicationBuilder app, IHostingEnvironment env)
//{
//    if (env.IsDevelopment())
//    {

//        app.UseDeveloperExceptionPage();
//    }
//    app.UseSwagger();
//    app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "post API V!"); });
//    app.UseMvc();


//}
