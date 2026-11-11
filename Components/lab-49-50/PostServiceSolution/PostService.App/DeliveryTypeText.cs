using PostService.CommonTypes;

namespace PostService.App;

/// <summary>
/// Українські назви типів доставки для відображення в інтерфейсі.
/// </summary>
public static class DeliveryTypeText
{
    public static string ToText(DeliveryType deliveryType)
    {
        return deliveryType switch
        {
            DeliveryType.Department => "Відділення",
            DeliveryType.Courier => "Кур'єр",
            DeliveryType.ExpressCourier => "Експрес-кур'єр",
            _ => deliveryType.ToString()
        };
    }
}
