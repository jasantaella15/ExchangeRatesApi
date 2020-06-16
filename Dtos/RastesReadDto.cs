using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRateApi.Dtos
{
    public class RastesReadDto
    {
        public Dictionary<string,float>  Rates { get; set; }
    }
}
