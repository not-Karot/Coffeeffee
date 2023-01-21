using Microsoft.Extensions.DependencyInjection;
using System;
using Coffeeffee.Interfaces;
using Coffeeffee.Services;
using Coffeeffee.ViewModels;

namespace Coffeeffee
{
	public static class Startup
	{
        private static IServiceProvider serviceProvider;
        public static void ConfigureServices()
        {
            var services = new ServiceCollection();

            //add services
            services.AddHttpClient<IClient, ApiClient>(c =>
            {
                c.BaseAddress = new Uri("http://whitesite.fly.dev/");
                c.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            services.AddHttpClient<ITeethColor, ApiTeethColor>(c =>
            {
                c.BaseAddress = new Uri("http://whitesite.fly.dev/");
                c.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            //add viewmodels
            services.AddTransient<ClientsViewModel>();
            services.AddTransient<AddClientViewModel>();
            services.AddTransient<ClientDetailsViewModel>();
            services.AddTransient<TeethColorViewModel>();

            serviceProvider = services.BuildServiceProvider();
        }

        public static T Resolve<T>() => serviceProvider.GetService<T>();
    }
}


