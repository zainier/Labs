using PostService.CommonTypes;

namespace PostService.Dtos;

/// <summary>
/// Поштове відправлення, яке сервіс повертає клієнту.
/// </summary>
public class PostingGetDto
{
    /// <summary>Ідентифікатор відправлення, який присвоює сервіс.</summary>
    /// <example>1</example>
    public int Id { get; set; }

    /// <summary>Відправник.</summary>
    /// <example>Київ</example>
    public string From { get; set; } = string.Empty;

    /// <summary>Отримувач.</summary>
    /// <example>Львів</example>
    public string To { get; set; } = string.Empty;

    /// <summary>Вміст відправлення.</summary>
    /// <example>Книги</example>
    public string Content { get; set; } = string.Empty;

    /// <summary>Тип доставки.</summary>
    /// <example>Courier</example>
    public DeliveryType DeliveryType { get; set; }

    /// <summary>Вага, кг.</summary>
    /// <example>2.5</example>
    public float Weight { get; set; }

    /// <summary>Ширина, см.</summary>
    /// <example>30</example>
    public float Width { get; set; }

    /// <summary>Висота, см.</summary>
    /// <example>20</example>
    public float Height { get; set; }

    /// <summary>Глибина, см.</summary>
    /// <example>10</example>
    public float Depth { get; set; }

    /// <summary>Оголошена цінність, грн; null, якщо не вказано.</summary>
    /// <example>500</example>
    public float? Value { get; set; }

    /// <summary>Вартість доставки, грн. Обчислює сервіс: вага × тариф типу доставки.</summary>
    /// <example>50</example>
    public float Price { get; set; }

    /// <summary>Додатковий опис відправлення; null, якщо не вказано.</summary>
    public string? Description { get; set; }

    /// <summary>Дата й час створення відправлення (UTC).</summary>
    public DateTime CreatedAt { get; set; }
}
