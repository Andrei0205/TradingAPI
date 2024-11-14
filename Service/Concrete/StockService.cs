using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingAPI.DataAccessLayer.Context;
using TradingAPI.DataAccessLayer.DataTransferObject.Stock;
using TradingAPI.DataAccessLayer.Entity;
using TradingAPI.DataAccessLayer.Mappers;
using TradingAPI.Service.Abstract;

namespace TradingAPI.Service.Concrete
{
    public class StockService : IStockService
    {
        private readonly TradingAPIDatabaseContext _databaseContext;
        public StockService(TradingAPIDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<StockDTO> CreateAsync(CreateStockDTO createStockDTO)
        {
            var stockModel = createStockDTO.toStockFromCreateStockDTO();
            await _databaseContext.Stocks.AddAsync(stockModel);
            await _databaseContext.SaveChangesAsync();
            return stockModel.toStockDTO();
        }

        public async Task<StockDTO> DeleteAsync(int id)
        {
            var existingStock = await _databaseContext.Stocks.FirstOrDefaultAsync(stock => stock.Id == id);
            if (existingStock == null)
            {
                return null;
            }
            _databaseContext.Stocks.Remove(existingStock);
            return existingStock.toStockDTO();
        }

        public async Task<IEnumerable<StockDTO>> GetAllAsync()
        {
            return await _databaseContext.Stocks
                .Select(stock => stock.toStockDTO()).ToListAsync();
        }

        public async Task<StockDTO> GetByIdAsync(int id)
        {
            var stock = await _databaseContext.Stocks
                .FirstOrDefaultAsync(stock =>stock.Id == id);
            if (stock == null)
            {
                return null;
            }
            return stock.toStockDTO();
        }

        public async Task<StockDTO> UpdateAsync(int id, UpdateStockDTO updateStockDTO)
        {
            var existingStock = await _databaseContext.Stocks.FirstOrDefaultAsync(stock => stock.Id == id);
            if (existingStock == null)
            {
                return null;
            }
            existingStock.Symbol = updateStockDTO.Symbol;
            existingStock.CompanyName = updateStockDTO.CompanyName;
            existingStock.Purchase = updateStockDTO.Purchase; 
            existingStock.LastDiv = updateStockDTO.LastDiv;
            existingStock.Industry = updateStockDTO.Industry;

            await _databaseContext.SaveChangesAsync();

            return existingStock.toStockDTO();
        }
    }
}
