using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acme.Api.AppConfig;
using Acme.Api.AppHelpers.Extensions;
using Acme.Api.AppHelpers.Filters;
using Acme.Business.Data.BusinessContracts;
using Acme.Business.Data.Contracts;
using Acme.Business.Services;
using Acme.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using static Acme.Api.AppHelpers.Constants.ProjectApiConstants;

namespace Acme.Api
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
            //Database context Service
            var conStr = Configuration.GetConnectionString("SchoolDatabase");
            services.AddDbContext<ISchoolContext, SchoolContext>(options => options.UseSqlServer(conStr));

            //Business services
            services.AddScoped<ICourseBusiness, CourseBusiness>();

            //Automapper Service
            var config = new AutoMapper.MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperConfig()));
            services.AddSingleton(config.CreateMapper());

            //Cors
            services.AddCorsPolicy(AcmeCorsPolicyName);

            services.AddMvc( options =>
            {
                options.Filters.Add<ApplicationExceptionFilter>();
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(AcmeCorsPolicyName);
            app.UseMvc();
        }
    }
}
