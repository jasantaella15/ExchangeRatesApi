using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRateApi.Dtos
{
    public class ConvertionReadDto
    {

        public String fromCurrency { get; set; }

        public String toCurrency { get; set; }

        public float Value { get; set; }
    }
}
