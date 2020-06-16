using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRateApi.Dtos
{
    public class CurrenciesReadDto
    {
        public List<string> Currencies { get; set; }
    }
}