using Band.Api.Catalog.BandServices;
using Band.Api.Catalog.LoaiVeServices;
using Band.Api.Catalog.ShowServices;
using Band.Api.Catalog.ThanhVienService;
using Band.Api.Catalog.VaiTroServices;
using Band.Data.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Band.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
/*        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
*/
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /*services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);*/
            services.AddDbContext<BandDbContext>(
                options => options.UseSqlServer("name=ConnectionStrings:bandDb"));
            /*services.AddCors(options => options.AddDefaultPolicy(
                builder => builder.AllowAnyOrigin())
            );*/


            //DI
            services.AddTransient<IPublicThanhVienService, PublicThanhVienService>();
            services.AddTransient<IManageThanhVienService, ManageThanhVienService>();
            services.AddTransient<IVaiTroService, VaiTroService>();
            services.AddTransient<ILoaiVeService, LoaiVeService>();
            services.AddTransient<IManageShowService, ManageShowService>();
            services.AddTransient<IPublicShowService, PublicShowService>();
            services.AddTransient<IBandService, BandService>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();
            /*app.UseCors();*/

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
