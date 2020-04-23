using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Store.BLL.Contracts;
using Store.BLL.Implementation;
using Store.DataAccess.Context;
using Store.DataAccess.Contracts;
using Store.DataAccess.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Store.DataAccess;

namespace Store
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
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            //BLL
            services.Add(new ServiceDescriptor(typeof(IBookCreateService), typeof(BookCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IBookGetService), typeof(BookGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IBookUpdateService), typeof(BookUpdateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IClientCreateService), typeof(ClientCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IClientGetService), typeof(ClientGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IClientUpdateService), typeof(ClientUpdateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IOrderCreateService), typeof(OrderCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IOrderGetService), typeof(OrderGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IOrderUpdateService), typeof(OrderUpdateService), ServiceLifetime.Scoped));

            //DataAccess
            services.Add(new ServiceDescriptor(typeof(IBookDataAccess), typeof(BookDataAccess), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IClientDataAccess), typeof(ClientDataAccess), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IOrderDataAccess), typeof(OrderDataAccess), ServiceLifetime.Transient));

            //DB Contexts
            services.AddDbContext<BookStoreContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("Store")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<BookStoreContext>();
                context.Database.EnsureCreated(); 
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
