using HFTEngine.MarketDataHandler.Model;
using HFTEngine.StrategyEngine.Enums;
using HFTEngine.StrategyEngine.Model;
using System;

namespace HFTEngine.StrategyEngine
{
    public class StrategyEngine
    {
        public event Action<Order> OnSignalGenerated;

        public void OnMarketDataReceived(MarketData data)
        {
            // Simple strategy: buy if price is below a certain threshold
            if (data.Price < 100)
            {
                var order = new Order
                {
                    Symbol = data.Symbol,
                    Price = data.Price,
                    Volume = 10,
                    Side = OrderSide.Buy
                };

                OnSignalGenerated?.Invoke(order);
            }
        }
    }
}
