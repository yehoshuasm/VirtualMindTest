using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;
using VirtualMindApi.Services;

namespace VirtualMindApi.Controllers
{
    [ApiController]
    [Route("api/exchange")]
    public class ExchangeController : ControllerBase
    {
        private readonly ICurrencyExchangeServiceFactory currencyExchangeServiceFactory;
        private readonly ICurrencyPurchasingService currencyPurchasingService;
        private readonly ILogger<ExchangeController> _logger;

        public ExchangeController(ICurrencyExchangeServiceFactory currencyExchangeServiceFactory, 
            ICurrencyPurchasingService currencyPurchasingService,
            ILogger<ExchangeController> logger)
        {
            this.currencyExchangeServiceFactory = currencyExchangeServiceFactory;
            this.currencyPurchasingService = currencyPurchasingService;
            _logger = logger;
        }

        [HttpGet("rates/{currencyCode}")]
        public async Task<IActionResult> GetCurrencyExchangeRate(string currencyCode)
        {
            try
            {
                var currencyExchangeService = currencyExchangeServiceFactory.GetCurrencyExchangeRateService(currencyCode);

                if(currencyExchangeService is null)
                {
                    return BadRequest($"Currency {currencyCode} is not supported");
                }

                var result = await currencyExchangeService.GetCurrencyExchangeRate();

                return Ok(result);
            }
            catch(Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost("purchasing/{userId}")]
        public async Task<IActionResult> PostCurrencyPurchase(int userId, CurrencyPurchaseOrder currencyPurchaseOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var result = await currencyPurchasingService.ExecuteCurrencyPurchase(userId, currencyPurchaseOrder);

                return Ok(result);
            }
            catch(Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
