using System;
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
using DataAccessLayer.Entities;

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

                AddressBussinesObject address = logic.AddressService.Create(
                    new AddressBussinesObject()
                    {
                        City = "myslowice",
                        Street = "armii",
                        Number = "21"
                    });

                var Customer = logic.CustomerService.Create(
                    new CustomerBussinesObject() {
                        FirstName = "Jebus",
                        LastName = "Lukasz",
                        Addresses = new List<AddressBussinesObject>() { address }
                    });

                 logic.CustomerService.Create(
                new CustomerBussinesObject()
                {
                    FirstName = "Anita",
                    LastName = "Tomalczyk",
                    Addresses = new List<AddressBussinesObject>() { address }
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
