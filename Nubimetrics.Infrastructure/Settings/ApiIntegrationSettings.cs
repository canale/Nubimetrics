
namespace Nubimetrics.Infrastructure.Settings
{
    public abstract class ApiIntegrationSettings
    {
        public string UriService { get; set; }
        public string Resource { get; set; }
    }

    public class ClassifiedLocationSettings : ApiIntegrationSettings { }
    public class CurrencySettings : ApiIntegrationSettings { }
    public class CurrencyConversionSettings : ApiIntegrationSettings { }
}
