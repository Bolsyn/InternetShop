using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Extensions.Configuration;


namespace InternetShop.Services
{
    public static class ConfigurationService
    {
        public static IConfiguration Configuration { get; private set; }

        public static void Init()
        {
            if(DbProviderFactories.GetFactory("ConnectedProvider") == null)
            {
                DbProviderFactories.RegisterFactory("ConnectedProvider", SqlClientFactory.Instance);
            }
            if(Configuration == null)
            {
                var configuratonBuilder = new ConfigurationBuilder();
                var configuration = configuratonBuilder.AddJsonFile("appSetting.json").Build();
            }
        }
    }
}
