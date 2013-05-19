using System.Collections.Generic;
using System.Web.Http;
using Blog.SignalRExample.Models;

namespace Blog.SignalRExample.Controllers
{
    public class StockController : ApiController
    {
        [HttpGet]
        public List<Stock> GetStocks()
        {
            return new List<Stock>
                {
                    new Stock { Price = 648.11, Symbol = "AAPL" },
                    new Stock { Price = 30.90, Symbol = "MSFT" },
                    new Stock { Price = 19.05, Symbol = "FB" },
                    new Stock { Price = 15.03, Symbol = "YHOO" },
                };
        }
    }
}
