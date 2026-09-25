using Delivery.Models;
using Delivery.Strategies;

namespace Delivery.Services
{
    public class EarlyBindingDeliveryCostService : IDeliveryCostService
    {
        public decimal Calculate(VolumeWeight volumeWeight, DeliveryType deliveryType)
        {
            switch (deliveryType)
            {
                case DeliveryType.Department:
                    DepartmentDeliveryStrategy department = new DepartmentDeliveryStrategy();
                    return department.Calculate(volumeWeight);

                case DeliveryType.Courier:
                    CourierDeliveryStrategy courier = new CourierDeliveryStrategy();
                    return courier.Calculate(volumeWeight);

                case DeliveryType.ExpressCourier:
                    ExpressCourierDeliveryStrategy express = new ExpressCourierDeliveryStrategy();
                    return express.Calculate(volumeWeight);

                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(deliveryType),
                        deliveryType,
                        "Невідомий спосіб доставки.");
            }
        }
    }
}
