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
using AcademyFinalProject.Models;
using System.Globalization;

namespace AcademyFinalProject
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            var connString = @"Server =tcp:academyfinalprojectdb.database.windows.net,1433;Initial Catalog=AcademyFinalProjectDB;Persist Security Info=False;User ID=Academy;Password=MDNmdn123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

            services.AddDbContext<AcademyDbContext>(o => o.UseSqlServer(connString));  //TODO: Add server retry + Ask if contextPOOL makes a difference
            services.AddMvc();
            //services.AddScoped<IContentService, DevContentService>(); //using dev
            services.AddScoped<IContentService, ReleaseContentService>(); //using Release

            var cultureInfo = new CultureInfo("sv-SE");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error/ServerError");
            }

            app.UseStatusCodePagesWithRedirects("/Error/HttpError/{0}");

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
