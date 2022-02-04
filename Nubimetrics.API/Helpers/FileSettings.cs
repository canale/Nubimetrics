namespace Nubimetrics.API.Helpers
{
    public class FileSettings
    {
        public string Directory { get; set; }
        public string FileName { get; set; }
    }

    public class CurrencyRateActivitySettings : FileSettings { }
    public class CurrencyActivitySettings : FileSettings { }
}
