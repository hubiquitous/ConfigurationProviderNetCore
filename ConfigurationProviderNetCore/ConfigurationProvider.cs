using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigurationProviderNetCore
{
    internal sealed class ConfigurationProvider : ConfigurationProviderBase
    {
        private const string appSettingsSection = "AppSettings";
        private readonly IConfigurationRoot _configurationRoot;

        public ConfigurationProvider()
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json");
            _configurationRoot = configurationBuilder.Build();
        }

        internal ConfigurationProvider(IConfigurationRoot configurationRoot)
        {
            _configurationRoot = configurationRoot;
        }

        protected override string GetConfigurationSettingValue(string configurationSettingKey)
        {
            return _configurationRoot.GetSection($"{appSettingsSection}:{configurationSettingKey}").Value;
        }

        protected override DbConnectionInformation GetDbConnectionInformationCore(string connectionStringName)
        {
            var connectionString = GetConfigurationSettingValueThrowIfNotFound(connectionStringName);
            return new DbConnectionInformation(connectionStringName, connectionString, "System.Data.SqlClient");
        }
    }
}
