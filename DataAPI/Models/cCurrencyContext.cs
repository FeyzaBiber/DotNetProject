using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAPI.Models
{
    public class cCurrencyContext : DbContext
    {
        public cCurrencyContext(DbContextOptions<cCurrencyContext> options) 
            : base(options)
        {
        }

        public DbSet<cCurrency> cCurrency { get; set; }

    }
}
