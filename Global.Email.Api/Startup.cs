using Global.Email.Infraestructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Global.Email.Api
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
            services.AddDbContexts(Configuration)
                .AddSwaggerDoc()
                .AddOptions(Configuration)
                .AddServices(Configuration)
                .AddJwt(Configuration)
                .AddFunctions();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var url = Configuration[WebHostDefaults.ServerUrlsKey];

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                //Local iis for subsites
                //options.SwaggerEndpoint("../swagger/v1/swagger.json", "Email Transactions v1");
                //options.RoutePrefix = string.Empty; --comment this line on local

                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Email Transactions v1");
                options.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}