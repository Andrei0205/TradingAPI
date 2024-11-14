using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingAPI.DataAccessLayer.Entity;

namespace TradingAPI.DataAccessLayer.Context 
{
    public class TradingAPIDatabaseContext : DbContext
    {
        public TradingAPIDatabaseContext(DbContextOptions<TradingAPIDatabaseContext> options) : base(options)
        {
        }
        
        public DbSet<Stock> Stocks { get; set; }
    }
}
