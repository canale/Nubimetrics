using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Nubimetrics.Application.Contracts;
using Nubimetrics.Infrastructure.Contracts;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Nubimetrics.API.Helpers
{
    public class CurrencyRateStartupActivity : IStartupActivityAsync
    {
        private readonly ICurrencyApplicationService currencyApplicationService;
        private readonly IFileWriter fileWriter;
        private readonly ILogger<CurrencyRateStartupActivity> logger;
        private readonly CurrencyRateActivitySettings settings;

        public CurrencyRateStartupActivity(ICurrencyApplicationService currencyApplicationService, 
                IFileWriter fileWriter, 
                IOptions<CurrencyRateActivitySettings> currencyActivitySettings, 
                ILogger<CurrencyRateStartupActivity> logger)
        {
            if (currencyApplicationService is null)
            {
                throw new ArgumentNullException(nameof(currencyApplicationService));
            }

            if (currencyActivitySettings is null)
            {
                throw new ArgumentNullException(nameof(currencyActivitySettings));
            }

            if (logger is null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            this.currencyApplicationService = currencyApplicationService;
            this.fileWriter = fileWriter;
            this.logger = logger;
            this.settings = currencyActivitySettings.Value;
        }


        public async Task PerformAsync()
        {
            try
            {
                var currencies = await this.currencyApplicationService.GetAllAsync();
                string rates = string.Join(',', currencies.Where(c => c.Rate != null).Select(c => c.Rate.Ratio.ToString(CultureInfo.InvariantCulture)));
                await fileWriter.WriteAsync(opt => {
                    opt
                    .UseAssemblyDirectory(settings.Directory)
                    .AddFileName(settings.FileName);
                }
                ,rates);
            }
            catch (Exception ex)
            {

                logger.LogError(ex, ex.StackTrace, ex.InnerException );
            }
        }
    }
}
