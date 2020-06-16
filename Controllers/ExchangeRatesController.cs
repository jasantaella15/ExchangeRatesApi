using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ExchangeRateApi.Models;
using ExchangeRateApi.Services;
using System.Net.Http;
using ExchangeRateApi.Data;
using System.Runtime.CompilerServices;
using System.Text.Json;
using ExchangeRateApi.Dtos;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace ExchangeRateApi.Controllers
{
    [ApiController]
    [Route("api/currencies")]
    public class ExchangeRatesController : ControllerBase
    {
        private readonly ILogger<ExchangeRatesController> _logger;
        private readonly ExchangeRatesService _exchangeRates;
        private readonly IMapper _mapper;

        public ExchangeRatesController(ILogger<ExchangeRatesController> logger, ExchangeRatesService exchangeRates , IMapper mapper)
        {
            _logger = logger;
            _exchangeRates = exchangeRates;
            _mapper = mapper;

        }


        //GET /api/currencies
        [HttpGet]
        public async Task<ActionResult<CurrenciesReadDto>> GetRatesAsync()
        {
            var response = await _exchangeRates.GetRates();
            if (response == null) return NotFound();
            return Ok(_mapper.Map<CurrenciesReadDto>(response).Currencies);
        }

        //GET /api/currencies/{baseCurrency}
        [HttpGet("{{baseCurrency}}")]
        public async Task<ActionResult<RastesReadDto>> GetRatesById([RegularExpression(@"^[A-Z]{3}")] string baseCurrency)
        {
            var response = await _exchangeRates.GetRatesById(baseCurrency);
            if (response == null) return NotFound();
            return Ok(_mapper.Map<RastesReadDto>(response).Rates);
        }

        //POST /api/currencies

        [HttpPost]
        public async Task<ActionResult<ConvertionResponseDto>> Convertion(ConvertionReadDto convertion)
        {
            var response = await _exchangeRates.GetConvertion(_mapper.Map<Convertion>(convertion));
            if (response == null) return NotFound();
            return Ok(
                new ConvertionResponseDto{
                    FromCurrency = response.fromCurrency,
                    ToCurrency = response.toCurrency,
                    BaseValue = response.Value,
                    Result = response.Result
                });
        }

        //GET /api/currencies/historic/{days}
        [HttpGet("/historic/{days}")]
        public async Task<ActionResult<RastesReadDto>> GetRatesByDay([RegularExpression(@"^[0-9]*$")] int days)
        {
            var response = await _exchangeRates.GetRatesByDay(days);
            if (response == null) return NotFound();
            return Ok(_mapper.Map<RastesReadDto>(response).Rates);

        }
    }
}
