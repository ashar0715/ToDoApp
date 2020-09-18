using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ToDoApp.Shared.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace ToDoApp
{
    public class Program
    {
        private const string URL = "https://plannerappserver20200228091432.azurewebsites.net";

        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            //adding services to IService collection

            builder.Services.AddScoped<AuthentificationService>(s =>
            {
                return new AuthentificationService(URL);
            });
            builder.Services.AddScoped<PlansService>(s =>
            {
                return new PlansService(URL);
            });
            //for storing data locally in a browser
            builder.Services.AddBlazoredLocalStorage();
            /* Options convert .json (configuration) files into POCO objects
            and make it accessable throuth dependency injection in the App*/
            builder.Services.AddOptions();
            //for user authorization in a browser
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, LocalAuthenticationStateProvider>();
            builder.RootComponents.Add<App>("app");
            builder.Services.AddScoped(sp =>
            new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


            await builder.Build().RunAsync();
        }
    }
}
