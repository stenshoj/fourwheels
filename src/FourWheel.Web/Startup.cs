using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using FourWheel.Web.Repositories;
using FourWheel.Web.Repositories.Fakes;
using FourWheel.Web.DataContext;
using Microsoft.EntityFrameworkCore;
using FourWheel.Web.Models;

namespace FourWheel.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FourWheelContext>(options => 
                options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=FourWheel;Integrated Security=true;MultipleActiveResultSets=true"));
            services.AddMvc();
            services.AddTransient<IRegisteredCarRepository, RegisteredCarRepositoryFake>();
            services.AddTransient<ITaskViewModelRepository, TaskViewModelRepository>();
            services.AddTransient<IMechanicRepository, MechanicRepositoryFake>();
            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<ITaskManager, TaskManager>();
            services.AddTransient<IMechanicStartViewModelRepository, MechanicStartViewModelRepository>();
            services.AddTransient<ISparePartRepository, SparePartRepositoryMock>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            DbInitializer.Seed(app);
        }
    }
}
