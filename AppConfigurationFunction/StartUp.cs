using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

[assembly: FunctionsStartup(typeof(AppConfigurationFunction.Startup))]

namespace AppConfigurationFunction
{
    /// <summary>
    /// The Startup class.
    /// </summary>
    public class Startup : FunctionsStartup
    {
        /// <summary>
        /// The method used for configuring app configuration sources and services.
        /// </summary>
        /// <param name="builder">The Functions Host builder.</param>
        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            string connectionString = Environment.GetEnvironmentVariable("appConfigurationConnectionString");
            builder.ConfigurationBuilder.AddAddAzureAppConfiguration(connectionString);
        }

        /// <summary>
        /// The method used for registration of services.
        /// </summary>
        /// <param name="builder">The Functions Host builder.</param>
        public override void Configure(IFunctionsHostBuilder builder)
        {
            // do nothing.
        }
    }
}