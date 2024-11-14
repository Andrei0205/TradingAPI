using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingAPI.DataAccessLayer.DataTransferObject.Stock
{
    public class CreateStockDTO
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Symbol cannot be over 10 over characters")]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [MaxLength(10, ErrorMessage = "Company Name cannot be over 10 over characters")]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        [Range(1,10000)]
        public decimal Purchase { get; set; }
        [Required]
        [Range(0.01,100)]
        public decimal LastDiv { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Industry cannot be over 10 characters")]
        public string Industry { get; set; } = string.Empty;
    }
}
