using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TaskManagerAPI.Core.Interfaces;
using TaskManagerAPI.Core.Models;
using TaskManagerAPI.Infrastructure;
using TaskManagerAPI.Models;

namespace TaskManagerAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(option =>
                {
                    var resolver = option.SerializerSettings.ContractResolver;
                    if (resolver != null)
                    {
                        (resolver as Newtonsoft.Json.Serialization.DefaultContractResolver).NamingStrategy = null;
                    }
                    option.SerializerSettings.DateFormatString = "MM-dd-yyyy";
                });

            //services.AddDbContext<TaskDetailsContext>(
            //    options => options.UseSqlServer(
            //        Configuration.GetConnectionString("DevConnection")));

            services.AddScoped<ITaskDetailsRepository, TaskDetailsRepository>();

            services.AddDbContext<TaskDetailsContext>(
                options => options.UseSqlServer(
                    Configuration.GetConnectionString("DevConnection")));

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                //{
                //    //  InitializeDatabaseAsync.InitializeData(app.ApplicationServices);
                //}
                var repository = app.ApplicationServices.GetService<ITaskDetailsRepository>();
                InitializeDatabaseAsync(repository).Wait();

                app.UseDeveloperExceptionPage();
            }

            app.UseCors(option =>
            option.WithOrigins("http://localhost:4200", "http://localhost:9876")
            //option.WithOrigins("*")
            .AllowAnyHeader()
            .AllowAnyMethod());

            app.UseMvc();
        }

        //public static void InitializeData(IServiceProvider serviceProvider)
        //{
        //    var context = serviceProvider.GetService<StoreContext>();
        //    InitializeData(context);
        //}

        public async Task InitializeDatabaseAsync(ITaskDetailsRepository repo)
        {
            var taskList = await repo.ListAsync();
            if (!taskList.Any())
            {
                await repo.AddAsync(GetTestTasks());
            }
        }

        public static TaskDetail GetTestTasks()
        {
            return new TaskDetail() { };
        }
    }
}
