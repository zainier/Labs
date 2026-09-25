using Delivery.Models;

namespace Delivery.Strategies
{
    public class ExpressCourierDeliveryStrategy : IDeliveryCostStrategy
    {
        private const decimal BaseCost = 120m;
        private const decimal CostPerKg = 24m;

        public DeliveryType DeliveryType
        {
            get
            {
                return DeliveryType.ExpressCourier;
            }
        }

        public decimal Calculate(VolumeWeight volumeWeight)
        {
            return BaseCost + volumeWeight.ChargeableWeight * CostPerKg;
        }
    }
}
