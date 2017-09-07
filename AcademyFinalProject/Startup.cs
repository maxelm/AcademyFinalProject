﻿using System;
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
using AcademyFinalProject.Models;

namespace AcademyFinalProject
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            // Local SQL server
            var connString = "Data Source=(localdb)/MSSQLLocalDB;Initial Catalog=AcademyFinalProjectDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            //services.AddDbContext<AcademyDbContext>(o => o.UseSqlServer(connString));


            services.AddDbContextPool<AcademyDbContext>(o => o.UseSqlServer(connString));  //TODO: Add server retry + Ask if contextPOOL makes a difference
            services.AddMvc();
            //services.AddSingleton<IContentService, DevContentService>(); //using dev
            services.AddSingleton<IContentService, ReleaseContentService>(); //using Release

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

        }
    }
}
