using Delivery.Models;

namespace Delivery.Strategies
{
    public class CourierDeliveryStrategy : IDeliveryCostStrategy
    {
        private const decimal BaseCost = 80m;
        private const decimal CostPerKg = 15m;

        public DeliveryType DeliveryType
        {
            get
            {
                return DeliveryType.Courier;
            }
        }

        public decimal Calculate(VolumeWeight volumeWeight)
        {
            return BaseCost + volumeWeight.ChargeableWeight * CostPerKg;
        }
    }
}
