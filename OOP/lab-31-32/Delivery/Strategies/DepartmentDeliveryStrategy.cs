using Delivery.Models;

namespace Delivery.Strategies
{
    public class DepartmentDeliveryStrategy : IDeliveryCostStrategy
    {
        private const decimal BaseCost = 40m;
        private const decimal CostPerKg = 10m;

        public DeliveryType DeliveryType
        {
            get
            {
                return DeliveryType.Department;
            }
        }

        public decimal Calculate(VolumeWeight volumeWeight)
        {
            return BaseCost + volumeWeight.ChargeableWeight * CostPerKg;
        }
    }
}
