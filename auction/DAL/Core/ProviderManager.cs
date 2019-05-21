using System.Data.Common;
namespace auction.DAL.Core
{
    public class ProviderManager
    {

        public string ProviderName { get; set; }
        public DbProviderFactory Factory
        {
            get
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory(ProviderName);
                return factory;
            }
        }

        public ProviderManager()
        {
            ProviderName = ConfigurationSettings.GetProviderName(ConfigurationSettings.DefaultConnection);
        }
        public ProviderManager(string providerName)
        {
            ProviderName = providerName;

        }
    }
}