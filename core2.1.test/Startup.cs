﻿using System.IO;
using System.Linq;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace core2._1.test {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;

            Repository = LogManager.CreateRepository("NETCoreRepository");
            XmlConfigurator.Configure(Repository, new FileInfo("log4netConfig.xml"));
            Log = LogManager.GetLogger(Repository.Name, typeof(Startup));
            Log.Info("=============Log4net start===============");
        }

        public static ILoggerRepository Repository { get; set; }
        public static ILog Log { get; set; }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddResponseCompression(options => {
                options.Providers.Add<BrotliCompressionProvider>();
                // 现在设置了两种需求，以后开需要在添加
                options.MimeTypes =
                    ResponseCompressionDefaults.MimeTypes.Concat(new[]
                        {"image/svg+xml", "application/json"});
            });
            // 添加后台运行程序
            services.AddSingleton<IHostedService, BackgroundServiceTmp>();
            //services.AddSingleton<BackgroundService, HostService>();
            services.AddHostedService<HostService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseResponseCompression();
            app.UseStaticFiles();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
