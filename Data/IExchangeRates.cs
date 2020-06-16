using System;
using System.Threading.Tasks;
using ExchangeRateApi.Dtos;
using ExchangeRateApi.Models;

namespace ExchangeRateApi.Data
{
    public interface IExchangeRates
    {
        Task<CurrenciesList> GetRates();

        Task<ExchangeRates> GetRatesById(String id);

        Task<ExchangeRates> GetRatesByDay(int days);

        Task<Convertion> GetConvertion(Convertion convertion);
        

    }
}
