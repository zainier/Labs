using PostService.Dtos;
using PostService.Models;

namespace PostService.Mappings;

/// <summary>
/// Перетворення між DTO контракту та моделлю <see cref="Posting"/>.
/// </summary>
public static class PostingMapper
{
    /// <summary>Створює модель нового відправлення з даних запиту на створення.</summary>
    /// <param name="dto">Дані нового відправлення.</param>
    /// <returns>Модель відправлення без ідентифікатора, вартості й дати створення.</returns>
    public static Posting ToPosting(PostingPostDto dto)
    {
        return new Posting
        {
            From = dto.From,
            To = dto.To,
            Content = dto.Content,
            DeliveryType = dto.DeliveryType,
            Weight = dto.Weight,
            Width = dto.Width,
            Height = dto.Height,
            Depth = dto.Depth,
            Value = dto.Value,
            Description = dto.Description
        };
    }

    /// <summary>Створює модель відправлення з даних запиту на зміну.</summary>
    /// <param name="dto">Змінені дані відправлення.</param>
    /// <returns>Модель відправлення з ідентифікатором.</returns>
    public static Posting ToPosting(PostingPutDto dto)
    {
        return new Posting
        {
            Id = dto.Id,
            From = dto.From,
            To = dto.To,
            Content = dto.Content,
            DeliveryType = dto.DeliveryType,
            Weight = dto.Weight,
            Width = dto.Width,
            Height = dto.Height,
            Depth = dto.Depth,
            Value = dto.Value,
            Price = dto.Price,
            Description = dto.Description
        };
    }

    /// <summary>Перетворює модель відправлення на DTO для відповіді клієнту.</summary>
    /// <param name="posting">Модель відправлення.</param>
    /// <returns>DTO відправлення.</returns>
    public static PostingGetDto ToPostingGetDto(Posting posting)
    {
        return new PostingGetDto
        {
            Id = posting.Id,
            From = posting.From,
            To = posting.To,
            Content = posting.Content,
            DeliveryType = posting.DeliveryType,
            Weight = posting.Weight,
            Width = posting.Width,
            Height = posting.Height,
            Depth = posting.Depth,
            Value = posting.Value,
            Price = posting.Price,
            Description = posting.Description,
            CreatedAt = posting.CreatedAt
        };
    }
}
