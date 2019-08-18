using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CrabZinc.Common.Entities;
using CrabZinc.Common.ViewModels;
using CrabZinc.Data;
using CrabZinc.Logic.Services;
using CrabZinc.Web.Configuration;
using CrabZinc.Web.Converters;
using CrabZinc.Web.Util;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OwlTin.Common.Converters;

namespace CrabZinc.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("dbConfig.json")
                .AddJsonFile("deploymentConfig.json");

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddOptions();

            services.AddDbContext<CrabZincDbContext>(options =>
                options.UseMySql(Configuration.GetSection("connectionString").Value)
            );

            var rootPathPrefix = Configuration.GetValue<string>("rootPathPrefix", "");
            
            var applicationConfig = new ApplicationConfiguration()
            {
                RootPathPrefix = rootPathPrefix
            };
            services.AddSingleton(applicationConfig);

            services.AddTransient<PostService>();

            services.AddSingleton<MarkdownRenderer>();

            var entityMapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Post, PostViewModel>();
            });
            var entityMapper = new Mapper(entityMapperConfig);
            services.AddSingleton<IMapper>(entityMapper);


            services.AddMvc().AddJsonOptions(options =>
            {
                //General Serializers
                options.SerializerSettings.Converters.Add(new JsonDateEpochConverter());

                //Entity Serializers
                options.SerializerSettings.Converters.Add(new MapperJsonConverter<Post, PostViewModel>(entityMapper));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
