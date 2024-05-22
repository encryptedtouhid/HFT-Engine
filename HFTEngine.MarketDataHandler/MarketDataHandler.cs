using HFTEngine.MarketDataHandler.Model;
using System;
using WebSocketSharp;

namespace HFTEngine.MarketDataHandler
{
    public class MarketDataHandler
    {
        private WebSocket webSocket;

        public event Action<MarketData> OnMarketDataReceived;

        public void Connect(string url)
        {
            webSocket = new WebSocket(url);
            webSocket.OnMessage += (sender, e) => ProcessIncomingData(e.Data);
            webSocket.OnOpen += (sender, e) => Console.WriteLine("Connected to data feed");
            webSocket.OnError += (sender, e) => Console.WriteLine($"Error: {e.Message}");
            webSocket.OnClose += (sender, e) => Console.WriteLine("Disconnected from data feed");

            webSocket.Connect();
        }

        private void ProcessIncomingData(string data)
        {
            // Assuming the incoming data is in JSON format
            var marketData = ParseMarketData(data);
            OnMarketDataReceived?.Invoke(marketData);
        }

        private MarketData ParseMarketData(string data)
        {
            // Deserialize JSON data to MarketData object (using JSON.NET or similar library)
            return Newtonsoft.Json.JsonConvert.DeserializeObject<MarketData>(data);
        }
    }
}
