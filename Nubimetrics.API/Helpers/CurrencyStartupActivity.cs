using Microsoft.Extensions.Options;
using Nubimetrics.Application.Contracts;
using Nubimetrics.Infrastructure.Contracts;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using Nubimetrics.Infrastructure.Helpers;
using Microsoft.Extensions.Logging;

namespace Nubimetrics.API.Helpers
{
    public class CurrencyStartupActivity : IStartupActivityAsync
    {
        private readonly ICurrencyApplicationService currencyApplicationService;
        private readonly IFileWriter fileWriter;
        private readonly ILogger<CurrencyStartupActivity> logger;
        private readonly CurrencyActivitySettings settings;

        public CurrencyStartupActivity(ICurrencyApplicationService currencyApplicationService, 
                IFileWriter fileWriter, 
                IOptions<CurrencyActivitySettings> currencyActivitySettings, 
                ILogger<CurrencyStartupActivity> logger)
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

                await fileWriter.WriteAsync(opt => {
                    opt
                    .UseAssemblyDirectory(settings.Directory)
                    .AddFileName(settings.FileName);
                }
                ,currencies.ToJson());
            }
            catch (Exception ex)
            {

                logger.LogError(ex, ex.StackTrace, ex.InnerException );
            }
        }
    }
}
