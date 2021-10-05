using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAPI.Models
{
    public class cCurrency
    {
        public int Id { get; set; } //has key
        public string CurrencyCode { get; set; }
        public float ExchangeRate { get; set; }
        public string cDate { get; set; }

    }
}
