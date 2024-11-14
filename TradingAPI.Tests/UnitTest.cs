using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TradingAPI.DataAccessLayer.DataTransferObject.Stock;


namespace TradingAPI.Tests
{
    [TestClass]
    public class TestGetEndPoint
    {
        [TestMethod]
        public async Task GetEndPointAsync()
        {
            var baseUrl = "http://localhost:5153/Stock";
            using (var httpClient = new HttpClient())
            {


                var createStockRequest = new CreateStockDTO()
                {
                    Symbol = "MSFT",
                    CompanyName = "Microsoft",
                    Purchase = 145m,
                    LastDiv = 1m,
                    Industry = "Tech"
                };

                var postResponse = await httpClient.PostAsJsonAsync(baseUrl, createStockRequest);
                postResponse.EnsureSuccessStatusCode();

                // Deserialize the response to get the created stock with its Id
                var responseContent = await postResponse.Content.ReadAsStringAsync();
                var createdStock = JsonSerializer.Deserialize<StockDTO> (responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                Assert.IsNotNull(createdStock, "Created stock should not be null.");
                Assert.IsTrue(createdStock.Id > 0, "Created stock Id should be greater than 0.");

                // Act - Get the stock by Id to verify it was saved correctly
                var getUrl = $"{baseUrl}/{createdStock.Id}"; // Adjust URL if necessary
                var getResponse = await httpClient.GetAsync(getUrl);
                getResponse.EnsureSuccessStatusCode();

                // Deserialize the response
                var getResponseContent = await getResponse.Content.ReadAsStringAsync();
                var stock = JsonSerializer.Deserialize<StockDTO>(getResponseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                // Assert - Check that the CompanyName is "BioNano"
                Assert.IsNotNull(stock);
                Assert.AreEqual("Microsoft", stock.CompanyName);

            }
        }
    }
}