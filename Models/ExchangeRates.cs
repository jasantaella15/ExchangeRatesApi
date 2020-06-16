using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExchangeRateApi.Models
{
    public class ExchangeRates
    {
        [Required]
        [StringLength(3)]
        public string Base { get; set; }

        public Dictionary<string,float> Rates { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date  { get; set; }
    }
}
