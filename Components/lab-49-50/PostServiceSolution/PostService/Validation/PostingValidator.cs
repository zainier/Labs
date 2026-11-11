using PostService.CommonTypes;
using PostService.Dtos;

namespace PostService.Validation;

/// <summary>
/// Перевіряє дані поштового відправлення, що надходять від клієнта.
/// Повертає словник помилок: ключ — ім'я поля у JSON, значення — повідомлення.
/// </summary>
public static class PostingValidator
{
    public const float MaxDepartmentWeight = 20f;

    private const int MinNameLength = 2;

    public static Dictionary<string, string[]> Validate(PostingPostDto dto)
    {
        return Validate(dto.From, dto.To, dto.Content, dto.DeliveryType,
            dto.Weight, dto.Width, dto.Height, dto.Depth, dto.Value);
    }

    public static Dictionary<string, string[]> Validate(PostingPutDto dto)
    {
        return Validate(dto.From, dto.To, dto.Content, dto.DeliveryType,
            dto.Weight, dto.Width, dto.Height, dto.Depth, dto.Value);
    }

    private static Dictionary<string, string[]> Validate(
        string from, string to, string content, DeliveryType deliveryType,
        float weight, float width, float height, float depth, float? value)
    {
        var errors = new Dictionary<string, string[]>();

        void AddError(string field, string message) => errors[field] = [message];

        if (string.IsNullOrWhiteSpace(from) || from.Trim().Length < MinNameLength)
        {
            AddError("from", $"Відправник має містити щонайменше {MinNameLength} символи");
        }

        if (string.IsNullOrWhiteSpace(to) || to.Trim().Length < MinNameLength)
        {
            AddError("to", $"Отримувач має містити щонайменше {MinNameLength} символи");
        }

        if (string.IsNullOrWhiteSpace(content))
        {
            AddError("content", "Вкажіть вміст відправлення");
        }

        if (!Enum.IsDefined(deliveryType))
        {
            AddError("deliveryType", "Виберіть тип доставки");
        }

        if (weight <= 0)
        {
            AddError("weight", "Вага має бути більшою за 0");
        }
        else if (deliveryType == DeliveryType.Department && weight > MaxDepartmentWeight)
        {
            AddError("weight", $"Для доставки у відділення вага не може перевищувати {MaxDepartmentWeight} кг");
        }

        if (width <= 0)
        {
            AddError("width", "Ширина має бути більшою за 0");
        }

        if (height <= 0)
        {
            AddError("height", "Висота має бути більшою за 0");
        }

        if (depth <= 0)
        {
            AddError("depth", "Глибина має бути більшою за 0");
        }

        if (value < 0)
        {
            AddError("value", "Оголошена цінність не може бути від'ємною");
        }

        return errors;
    }
}
