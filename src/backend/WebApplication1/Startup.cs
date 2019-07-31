using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AHP.Service;
using AHP.Service.Common;
using Model;
using DAL;
using Repository;
using Repository.Common;
using AutoMapper;
using WebAPI;

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(env.ContentRootPath)
             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
             .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
             .AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            services.AddDbContextPool<AHPContext>(options => options.UseSqlServer(this.Configuration.GetConnectionString("connectionString")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
			
			services.AddCors();//za server

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new RepositoryProfile());
                cfg.AddProfile(new WebAPIProfile());
            });

            var mapper = config.CreateMapper();

            //services.AddSingleton(mapper);

            var builder = new Autofac.ContainerBuilder();
            ModuleService.ConfigureServiceModule(builder);
            ModelModule.ConfigureModelModule(builder);
            RepositoryModule.ConfigureRepositoryModule(builder);
            builder.RegisterInstance(mapper).As<IMapper>();

            builder.Populate(services);

            var container = builder.Build();

            return container.Resolve<IServiceProvider>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
			app.UseCors(builder =>
               builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
           );

            app.UseMvc();
        }
    }
}
