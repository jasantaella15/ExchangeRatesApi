using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRateApi.Models
{
    public class CurrenciesList
    {

        public IEnumerable<string> Currencies { get; set; }
    }
}
