using Delivery.Models;

namespace Delivery.Strategies
{
    public interface IDeliveryCostStrategy
    {
        DeliveryType DeliveryType { get; }

        decimal Calculate(VolumeWeight volumeWeight);
    }
}
