using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace AddressBook
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            /*
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddOpenIdConnect(options =>
            {
                _configuration.Bind("AzureAD", options);
            })
            .AddCookie();
            */

            services.AddScoped<IAddressData, InMemoryAddressBook>();
            services.AddMvc()            
                .AddJsonOptions(o =>
                {
            	    if (o.SerializerSettings.ContractResolver != null)
            	    {
            		    var castedResolver = o.SerializerSettings.ContractResolver as DefaultContractResolver;
            		    castedResolver.NamingStrategy = null;
            	    }
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseRewriter(new RewriteOptions().AddRedirectToHttpsPermanent());
            //app.UseStaticFiles();
            //app.UseNodeModules(env.ContentRootPath);
            //app.UseScripts(env.ContentRootPath);
            //app.UseData(env.ContentRootPath);
            //app.UseAuthentication();

            app.UseMvc(ConfigureRoutes);
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            //routeBuilder.MapRoute("Default", "{controller=Address}/{action=GetGrouped}");
        }

    }
}
