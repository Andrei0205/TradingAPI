using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingAPI.DataAccessLayer.DataTransferObject.Stock;
using TradingAPI.DataAccessLayer.Entity;

namespace TradingAPI.Service.Abstract
{
    public interface IStockService
    {
        Task<StockDTO> CreateAsync(CreateStockDTO createStockDTO);
        Task<IEnumerable<StockDTO>> GetAllAsync();
        Task<StockDTO> GetByIdAsync(int id);
        Task<StockDTO> UpdateAsync(int id, UpdateStockDTO updateStockDTO);
        Task<StockDTO> DeleteAsync(int id);
    }
}
