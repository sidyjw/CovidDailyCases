using Application.Contracts;
using Application.DailyCases.Queries;
using FluentValidation.AspNetCore;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace API
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
            services.AddCors();
            services.AddControllers()
                .AddFluentValidation(
                config => config
                    .RegisterValidatorsFromAssemblyContaining<GetAllCasesAmountByDate.QueryValidator>());
            
            services.AddDbContext<DailyCasesReportContext>(opt => {
                switch(Configuration["DatabaseSettings:DatabaseProvider"])
                {
                    case "SQLite":
                        opt.UseSqlite(Configuration["DatabaseSettings:ConnectionString"]);
                        break;
                    case "MySQL":
                        opt.UseMySql(Configuration["DatabaseSettings:ConnectionString"], new MySqlServerVersion( new System.Version(8,0)));
                        break;
                }

            });

            services.AddMediatR(typeof(Dates.Handler).Assembly);
            services.AddScoped<IDailyCasesRepository, DailyCasesRepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseRouting();

            app.UseCors(x => x.AllowAnyOrigin());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
