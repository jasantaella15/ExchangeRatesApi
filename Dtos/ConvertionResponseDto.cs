using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRateApi.Dtos
{
    public class ConvertionResponseDto { 
    public String FromCurrency { get; set; }

    public String ToCurrency { get; set; }

    public float BaseValue { get; set; }

     public float Result { get; set; }
    }
}
