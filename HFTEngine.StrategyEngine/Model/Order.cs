using System;
using System.Collections.Generic;
using System.Text;

namespace HFTEngine.StrategyEngine.Model
{
    public class Order
    {
        public string Symbol { get; set; }
        public decimal Price { get; set; }
        public int Volume { get; set; }
        public OrderSide Side { get; set; }
    }
}
