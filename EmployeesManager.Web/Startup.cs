using EmployeesManager.Infrastructure.IoC;
using EmployeesManager.Infrastructure.Service;
using EmployeesManager.Infrastructure.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace EmployeesManager.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env) 
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsetings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            this.Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; private set; }
        //public IHostingEnvironment HostingEnvironment { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given EmployeeDto.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.ConfigureSettings(this.Configuration);
            services.ConfigureDependencyInjection();
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                    .AddRazorPagesOptions( options =>
                    {
                        options.Conventions.AddPageRoute("/Home","");
                    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP EmployeeDto pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IDataInitializer dataInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            var settings = app.ApplicationServices.GetService<IOptions<XmlRepositorySettings>>();
            if(settings.Value.SeedData)
            {
                dataInitializer.SeedData();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}
