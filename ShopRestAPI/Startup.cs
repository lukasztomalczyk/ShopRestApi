﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using BussinesAccessLayer;
using BussinesAccessLayer.BusinessObjects;

namespace ShopRestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                BussinesLogic logic = new BussinesLogic();
                var Customer = logic.CustomerService.Create(
                    new CustomerBussinesObject() {
                        FirstName = "Jebus",
                        LastName = "Lukasz",
                        Address = "Armii Krajowej"
                    });

                 logic.CustomerService.Create(
                new BussinesAccessLayer.BusinessObjects.CustomerBussinesObject()
                {
                    FirstName = "Anita",
                    LastName = "Tomalczyk",
                    Address = "Armii Krajowej 23",
                });

                logic.OrderService.Create(
                    new OrderBussinesObject()
                    {
                        DeliveryDate = DateTime.Now.AddMonths(-1),
                        OrderDate = DateTime.Now.AddMonths(+1),
                        Customer = Customer,
                    });


            }

            app.UseMvc();
        }
    }
}
