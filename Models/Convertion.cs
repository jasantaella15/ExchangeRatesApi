using ExchangeRateApi.Dtos;
using System;
using System.ComponentModel.DataAnnotations;

namespace ExchangeRateApi.Models
{
    public class Convertion
    {
        [Required]
        [StringLength(3)]
        public String fromCurrency { get; set; }

        [Required]
        [StringLength(3)]
        public String toCurrency { get; set; }

        public float Value { get; set; }

        public float Result { get; set; }

        public Convertion Convert(float rate)
        {
            Result = Value * rate;
            return this;

        }
    }
}
