using System;
using System.Collections.Generic;
using System.Text;

namespace HFTEngine.Common
{
    public class MarketData
    {
        public string Symbol { get; set; }
        public decimal Price { get; set; }
        public int Volume { get; set; }
    }
}
