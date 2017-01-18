using Api_Game.Configuration;
using Api_Game.Interfaces;
using Api_Game.Services;
using Api_Game.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Api_Game
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            // Add our Config object so it can be injected
            var gameApiSettings = Configuration.GetSection(nameof(GameApiSettings)).Get<GameApiSettings>();
            var translatorSettings = Configuration.GetSection(nameof(TranslatorSettings)).Get<TranslatorSettings>();
            var tcseSettings = Configuration.GetSection(nameof(TcseSettings)).Get<IList<TcseSettings>>();
            var storageSettings = Configuration.GetSection(nameof(StorageBlobSettings)).Get<StorageBlobSettings>();

            tcseSettings = ConfigurationMerger.SetClasificationImageUrls(storageSettings, tcseSettings);

            services.AddScoped<IClasificationTableService, ClasificationTableService>(x => new ClasificationTableService(tcseSettings));
            services.AddScoped<IGameService, GameService>(x => new GameService(gameApiSettings));
            services.AddScoped<ITranslatorService, TranslatorService>(x => new TranslatorService(translatorSettings));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}