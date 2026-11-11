namespace PostService.CommonTypes;

/// <summary>
/// Тип доставки поштового відправлення. Визначає тариф: Department — 10 грн/кг,
/// Courier — 20 грн/кг, ExpressCourier — 30 грн/кг.
/// </summary>
public enum DeliveryType
{
    /// <summary>Доставка до відділення.</summary>
    Department,

    /// <summary>Кур'єрська доставка.</summary>
    Courier,

    /// <summary>Експрес-доставка кур'єром.</summary>
    ExpressCourier
}
