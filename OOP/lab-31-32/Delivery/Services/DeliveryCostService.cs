using Delivery.Models;
using Delivery.Strategies;

namespace Delivery.Services
{
    public class DeliveryCostService : IDeliveryCostService
    {
        private readonly IReadOnlyDictionary<DeliveryType, IDeliveryCostStrategy> _strategies;

        public DeliveryCostService(IEnumerable<IDeliveryCostStrategy> strategies)
        {
            _strategies = strategies.ToDictionary(s => s.DeliveryType);
        }

        public decimal Calculate(VolumeWeight volumeWeight, DeliveryType deliveryType)
        {
            if (!_strategies.TryGetValue(deliveryType, out IDeliveryCostStrategy? strategy))
            {
                throw new ArgumentOutOfRangeException(
                    nameof(deliveryType),
                    deliveryType,
                    "Не знайдено стратегію для обраного способу доставки.");
            }

            return strategy.Calculate(volumeWeight);
        }
    }
}
