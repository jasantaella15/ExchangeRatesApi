using AutoMapper;
using ExchangeRateApi.Dtos;
using ExchangeRateApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRateApi.Profiles
{
    public class ExchangeRatesProfile : Profile
    {
        public ExchangeRatesProfile()
        {
            CreateMap<ExchangeRates, RastesReadDto>();
            CreateMap<CurrenciesList, CurrenciesReadDto>();
            CreateMap<ConvertionReadDto, Convertion>();

        }
    }
}
