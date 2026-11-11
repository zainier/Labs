using PostService.CommonTypes;

namespace PostService.Dtos;

/// <summary>
/// Змінені дані наявного поштового відправлення.
/// </summary>
public class PostingPutDto
{
    /// <summary>Ідентифікатор відправлення. Сервіс бере його з адреси запиту, значення в тілі ігнорується.</summary>
    /// <example>1</example>
    public int Id { get; set; }

    /// <summary>Відправник, щонайменше 2 символи.</summary>
    /// <example>Київ</example>
    public string From { get; set; } = string.Empty;

    /// <summary>Отримувач, щонайменше 2 символи.</summary>
    /// <example>Львів</example>
    public string To { get; set; } = string.Empty;

    /// <summary>Вміст відправлення, обов'язковий.</summary>
    /// <example>Книги</example>
    public string Content { get; set; } = string.Empty;

    /// <summary>Тип доставки.</summary>
    /// <example>Courier</example>
    public DeliveryType DeliveryType { get; set; }

    /// <summary>Вага, кг; більша за 0, для доставки у відділення — не більше 20.</summary>
    /// <example>4</example>
    public float Weight { get; set; }

    /// <summary>Ширина, см; більша за 0.</summary>
    /// <example>30</example>
    public float Width { get; set; }

    /// <summary>Висота, см; більша за 0.</summary>
    /// <example>20</example>
    public float Height { get; set; }

    /// <summary>Глибина, см; більша за 0.</summary>
    /// <example>10</example>
    public float Depth { get; set; }

    /// <summary>Оголошена цінність, грн; необов'язкова, не від'ємна.</summary>
    /// <example>500</example>
    public float? Value { get; set; }

    /// <summary>Вартість доставки, грн. Сервіс перераховує її за вагою та типом доставки, надіслане значення ігнорується.</summary>
    /// <example>80</example>
    public float Price { get; set; }

    /// <summary>Додатковий опис відправлення; необов'язковий.</summary>
    public string? Description { get; set; }
}
