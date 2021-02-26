using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;

using Microsoft.Extensions.Configuration;

namespace Netcoreconf.Keyvault
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello NetCoreConf!");
            Console.WriteLine();

            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true);

            var configuration = builder.Build();
            var appSettings = configuration.GetSection("AppSettings");
            var keyVaultName = appSettings["VaultName"];

            string secretName = "FullAccessPassword";

            var kvUri = "https://" + keyVaultName + ".vault.azure.net";
            var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());

            Console.WriteLine($"Retrieving your secret from {keyVaultName}");

            KeyVaultSecret secret = client.GetSecret(secretName);

            Console.Write("Your secret is: ");
            ConsoleUtils.WriteInfo(secret.Value);
        }
    }
}
