using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using AcademyFinalProject.Models.Entities;

namespace AcademyFinalProject
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            // Local copy of Azure DB
            var connString = "Data Source=ACADEMY-7115W44;Initial Catalog=AcademyFinalProjectDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            services.AddDbContextPool<AcademyDbContext>(o => o.UseSqlServer(connString));  //TODO: Add server retry + Ask if contextPOOL makes a difference
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseMvcWithDefaultRoute();

        }
    }
}
