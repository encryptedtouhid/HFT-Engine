using HFTEngine.Common;
using System;

namespace HFTEngine
{
    public class RiskManager
    {

        private decimal maxExposure = 100000;

        public bool ValidateOrder(Order order)
        {
            // Simple risk check: ensure the order value does not exceed max exposure
            decimal orderValue = order.Price * order.Volume;
            if (orderValue > maxExposure)
            {
                Console.WriteLine("Order rejected: exceeds maximum exposure");
                return false;
            }

            return true;
        }
    }
}
