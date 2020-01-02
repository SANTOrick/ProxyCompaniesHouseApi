using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using ProxyApi.Configuration;
using ProxyApi.DataClient;
using ProxyApi.Filters;

namespace ProxyApiToCompaniesHouseApi
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
            services.AddHttpClient<ICompaniesHouseApi, CompaniesHouseApi>();
            services.Configure<ProxyApiConfiguration>(Configuration.GetSection("proxyApiConfiguration"));
             services.AddMvc(options =>
             {
                 options.Filters.Add(new VerifyAccessFilter(Configuration["authorization:headerName"], Configuration["authorization:apiKey"]));
             })
               .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                  .AddJsonOptions(options =>
                  {
                     
                  });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
