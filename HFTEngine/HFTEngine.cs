using HFTEngine.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFTEngine
{
    public class HFTEngine
    {
        private MarketDataHandler marketDataHandler;
        private StrategyEngine strategyEngine;
        private OrderManager orderManager;
        private RiskManager riskManager;

        public HFTEngine()
        {
            marketDataHandler = new MarketDataHandler();
            strategyEngine = new StrategyEngine();
            orderManager = new OrderManager();
            riskManager = new RiskManager();

            // Wire up events
            marketDataHandler.OnMarketDataReceived += strategyEngine.OnMarketDataReceived;
            strategyEngine.OnSignalGenerated += OnSignalGenerated;
        }

        private void OnSignalGenerated(Order order)
        {
            if (riskManager.ValidateOrder(order))
            {
                orderManager.PlaceOrder(order);
            }
        }

        public void Start()
        {
            marketDataHandler.Connect("data-feed-connection-string");

            // Simulate receiving market data
            marketDataHandler.ProcessIncomingData(new MarketData
            {
                Symbol = "AAPL",
                Price = 95.5m,
                Volume = 1000
            });
        }
    }
}
