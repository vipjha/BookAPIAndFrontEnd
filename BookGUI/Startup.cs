﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookGUI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace BookGUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<ICoutryRepositoryGUI, CountryRepositoryGUI>();
            services.AddScoped<ICategoyRepositoryGUI, CategoryRepositoryGUI>();
            services.AddScoped<IReviewerRepositoryGUI, ReviewerRepositoryGUI>();
            services.AddScoped<IReviewRespositoryGUI, ReviewRepositoryGUI>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseStatusCodePages();

            app.UseMvc(routes=>
            {
                routes.MapRoute(
                    name: "default",
                    template:"{controller=Home}/{action=Index}/{id?}"
                    ); 
            });

           // app.UseRouting();

            /*app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });*/
        }
    }
}
