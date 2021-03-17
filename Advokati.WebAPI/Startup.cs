using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Advokati.WebAPI.EF;
using Advokati.WebAPI.Filters;
using Advokati.WebAPI.Security;
using Advokati.WebAPI.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Advokati.WebAPI
{



    public class BasicAuthDocumentFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            var securityRequirements = new Dictionary<string, IEnumerable<string>>()
        {
            { "basic", new string[] { } }  // in swagger you specify empty list unless using OAuth2 scopes
        };

            swaggerDoc.Security = new[] { securityRequirements };
        }
    }
    public class Startup
    {

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(x=>x.Filters.Add<ErrorFilter>()).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddCors(o => o.AddPolicy("AllowOrigin", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build();
            }));


            services.AddDbContext<AdvokatiContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("conn_string")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
                c.AddSecurityDefinition("basic", new BasicAuthScheme() { Type = "basic" });
                c.DocumentFilter<BasicAuthDocumentFilter>();
            });


            services.Configure<FormOptions>(o => {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });



            services.AddAutoMapper();

            services.AddAuthentication("BasicAuthentication")
                         .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);


            services.AddScoped<IZaposleniciService, ZaposleniciService>();
            services.AddScoped<IPredmetiService, PredmetiService>();
            services.AddScoped<IRocistaService, RocistaService>();
            services.AddScoped<IKlijentiService, KlijentiService>();
            services.AddScoped<ITroskoviService, TroskoviService>();
            services.AddScoped<ISastanciService, SastanciService>();
            services.AddScoped<IUredService, UredService>();
            services.AddScoped<IZadaciService, ZadaciService>();
            services.AddScoped<IUgovoriService, UgovoriService>();
            services.AddScoped<IRadniSatiService, RadniSatiService>();
            services.AddScoped<IUlogeService, UlogeService>();
            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<IVrstaUslugeService, VrstaUslugeService>();
            services.AddScoped<IFajloviService, FajloviService>();
            services.AddScoped<IKontaktlistaService, KontaktlistaService>();
            services.AddScoped<IDokumentiService, DokumentiService>();
            services.AddScoped<IKategorijeDokumenataService, KategorijeDokumenataService>();
            services.AddScoped<IOcjeneService, OcjeneService>();
            services.AddScoped<IPostavkeService,PostavkeService>();
            services.AddScoped<IZapisnikRocistaService, ZapisnikRocistaService>();





        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
              
            }
            
            app.UseAuthentication();

            app.UseCors("AllowOrigin");


            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
                RequestPath = new PathString("/Resources")
            });

            //app.UseHttpsRedirection();

            app.UseMvc();


            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {

                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });


            


        }
    }
}
