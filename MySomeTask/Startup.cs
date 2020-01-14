using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySomeTask.Cache;
using MySomeTask.CommandHandlers;
using MySomeTask.DataBase;
using MySomeTask.DomainEventHandlers;
using MySomeTask.Loggers;
using MySomeTask.Middlewares;
using MySomeTask.QueryHandlers;
using MySomeTask.Services;
using System;
using System.Linq;

namespace MySomeTask
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

      if (!services.Any(x => x.ServiceType == typeof(AccountContext)))
      {
        services.AddDbContextPool<AccountContext>(options =>
        options.UseSqlServer(Configuration["Data:ConnectionString"]));
      }

      services.AddOptions();
      services.Configure<Configurations.Cache>(Configuration.GetSection("Cache"));
      services.Configure<Configurations.NotificationsGateway>(Configuration.GetSection("NotificationsGateway"));
      services.Configure<Configurations.Registration>(Configuration.GetSection("Registration"));
      
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

			// In production, the Angular files will be served from this directory
			services.AddSpaStaticFiles(configuration =>
			{
				configuration.RootPath = "ClientApp/dist";
			});

      #region Cache
      var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
      if (Configuration["Cache:Type"] == "Redis" && environmentName != "test")
        services.AddStackExchangeRedisCache(options =>
        {
          options.Configuration = Configuration["Cache:Redis:ConnectionString"];
        });
      else
        services.AddDistributedMemoryCache();

      services.AddTransient<CountryCache>();
      services.AddTransient<ProvinceCache>();
      #endregion Cache

      #region Services
      services.AddTransient<IActivationCodeService, ActivationCodeService>();
      services.AddTransient<IPasswordService, PasswordService>();
      #endregion Services

      #region CommandHandlers 
      services.Scan(scan => scan.FromCallingAssembly()
                                .AddClasses(c => c.AssignableTo<ICommandHandler>())
                                                  .AsImplementedInterfaces()
                                                  .WithTransientLifetime());
      #endregion CommandHandlers

      #region QueryHandlers
      services.Scan(scan => scan.FromCallingAssembly()
                                .AddClasses(c => c.AssignableTo<IQueryHandler>())
                                                  .AsImplementedInterfaces()
                                                  .WithTransientLifetime());
      #endregion QueryHandlers        

      #region DomainEventHandlers
      services.Scan(scan => scan.FromCallingAssembly()
                                .AddClasses(c => c.AssignableTo<IDomainEventHandler>())
                                                  .AsImplementedInterfaces()
                                                  .WithTransientLifetime());

      services.AddTransient<IDomainEventHandlerFactory, ContainerDomainEventHandlerFactory>();
      services.AddTransient<IDomainEventDispatcher, DefaultDomainEventDispatcher>();
      #endregion DomainEventHandlers

      #region Loggers
      services.AddSingleton<ILoggerService, SerilogLoggerService>();
      #endregion Loggers
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
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseSpaStaticFiles();


      #region custom middleware
      // обработка CommandHandlerException
      app.UseCommandHandlerExceptionMiddleware();
      // логирование ошибок
      //app.UseExceptionMiddleware();            
      #endregion custom middleware

      app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller}/{action=Index}/{id?}");
			});

      

      app.UseSpa(spa =>
			{
				// To learn more about options for serving an Angular SPA from ASP.NET Core,
				// see https://go.microsoft.com/fwlink/?linkid=864501

				spa.Options.SourcePath = "ClientApp";

				if (env.IsDevelopment())
				{
					spa.UseAngularCliServer(npmScript: "start");
				}
			});
		}
	}
}
