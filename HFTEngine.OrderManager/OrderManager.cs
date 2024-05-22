using HFTEngine.Common;
using System;

namespace HFTEngine
{
    public class OrderManager
    {
        public void PlaceOrder(Order order)
        {
            // Simulate placing order
            Console.WriteLine($"Order placed: {order.Side} {order.Volume} of {order.Symbol} at {order.Price}");
        }
    }
}
