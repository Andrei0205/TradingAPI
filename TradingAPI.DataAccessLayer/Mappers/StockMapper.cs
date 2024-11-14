using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingAPI.DataAccessLayer.DataTransferObject.Stock;
using TradingAPI.DataAccessLayer.Entity;

namespace TradingAPI.DataAccessLayer.Mappers
{
    public static class StockMapper
    {
        public static StockDTO toStockDTO(this Stock stockModel)
        {
            return new StockDTO
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                Industry = stockModel.Industry,
            };
        }

        public static Stock toStockFromCreateStockDTO(this CreateStockDTO stockDto)
        {
            return new Stock
            {
                Symbol = stockDto.Symbol,
                CompanyName = stockDto.CompanyName,
                Purchase = stockDto.Purchase,
                LastDiv = stockDto.LastDiv,
                Industry = stockDto.Industry,
            };
        }
    }
}
