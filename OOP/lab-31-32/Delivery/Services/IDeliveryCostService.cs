using Delivery.Models;

namespace Delivery.Services
{
    public interface IDeliveryCostService
    {
        decimal Calculate(VolumeWeight volumeWeight, DeliveryType deliveryType);
    }
}
