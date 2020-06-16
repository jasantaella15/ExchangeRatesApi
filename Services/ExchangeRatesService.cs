using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using ExchangeRateApi.Models;
using System.Net.Http;
using ExchangeRateApi.Data;
using Newtonsoft.Json;
using System.Linq;
using ExchangeRateApi.Dtos;

namespace ExchangeRateApi.Services
{
    public class ExchangeRatesService : IExchangeRates
    {
        private readonly HttpClient _client;
        public readonly string _uri = "https://api.exchangeratesapi.io/";
        public const string _default = "EUR";
        public ExchangeRates Rates;

        public ExchangeRatesService(HttpClient client)
        {
            client.BaseAddress = new Uri(_uri);
            _client = client;
        }

        public async Task<Convertion> GetConvertion(Convertion convertion)
        {
            var exchangeRates = await GetRatesById(convertion.fromCurrency);
            if (exchangeRates == null) return null;
            float rate;
            if (!exchangeRates.Rates.TryGetValue(convertion.toCurrency, out rate)) return null;
            return convertion.Convert(rate);

        }

        public async Task<ExchangeRates> GetRatesByDay(int days)
        {
            var date = DateTime.Now.AddDays(-days);
            var response = await _client.GetAsync(date.ToString("yyyy-MM-dd"));

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<ExchangeRates>(content);
                return data;

            }
            else
            {
                return null;

            }
        }
        public async Task<ExchangeRates> GetRatesById(string id = _default)
        {

            var response = await _client.GetAsync($"/latest?base={id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<ExchangeRates>(content);
                return data;

            }
            else
            {
                return null;

            }
            
        }
        public async Task<CurrenciesList> GetRates()
        {

            var response = await _client.GetAsync($"/latest?base={_default}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<ExchangeRates>(content);

                return new CurrenciesList {Currencies = data.Rates.Keys.ToList()};
            }
            else
            {
                return null;

            }

        }
    }

  }

