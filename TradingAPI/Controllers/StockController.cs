using Microsoft.AspNetCore.Mvc;
using TradingAPI.DataAccessLayer.DataTransferObject.Stock;
using TradingAPI.Service.Abstract;
using TradingAPI.Service.Concrete;

namespace TradingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stocks = await _stockService.GetAllAsync();
            return Ok(stocks);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stock = await _stockService.GetByIdAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStock([FromBody] CreateStockDTO createStockDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stock = await _stockService.CreateAsync(createStockDTO);

            return Ok(stock);

        }

        [HttpPut("{id:int}")]

        public async Task<IActionResult> UpdateStock([FromRoute] int id, [FromBody] UpdateStockDTO updateStockDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stock = _stockService.UpdateAsync(id, updateStockDTO);
            if  (stock == null)
            {
                return NotFound();
            }
            return Ok(stock);

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteStock([FromRoute] int id)
        {
            var stock = await _stockService.DeleteAsync(id);
            if (stock == null) { return NotFound(); }
            return NoContent();
        }

    }
}
