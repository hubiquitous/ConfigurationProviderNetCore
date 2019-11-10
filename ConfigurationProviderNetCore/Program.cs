using System;

namespace ConfigurationProviderNetCore
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var configurationProvider = new ConfigurationProvider();
            Console.WriteLine(configurationProvider.EmailTemplatesPath);
            Console.WriteLine(configurationProvider.PaymentGatewayServiceUrl);
            Console.WriteLine(configurationProvider.FiscalYearStart.ToLongDateString());
            Console.WriteLine(configurationProvider.NotifyOnUpload);

            var dbConnectionInformation = configurationProvider.DbConnectionInformation;
        }
    }
}
