using PostService.CommonTypes;
using PostService.DataAccess;
using PostService.Models;

namespace PostService.BusinessLogic;

public class PostingService : IPostingService
{
    private readonly IPostingRepository _repository;

    public PostingService(IPostingRepository repository)
    {
        _repository = repository;
    }

    public Posting Create(Posting newPosting)
    {
        newPosting.CreatedAt = DateTime.UtcNow;
        newPosting.Price = CalculatePrice(
            newPosting.Weight,
            newPosting.DeliveryType
        );

        var postingId = _repository.Create(newPosting);

        var savedPosting = (Posting)newPosting.Clone();
        savedPosting.Id = postingId;

        return savedPosting;
    }

    public List<Posting> GetAll()
    {
        return _repository.GetList();
    }

    public Posting? Find(int postingId)
    {
        return _repository.GetById(postingId);
    }

    public Posting? Update(Posting posting)
    {
        var existingPosting = _repository.GetById(posting.Id);

        if (existingPosting is null)
        {
            return null;
        }

        _repository.Update(posting);

        return _repository.GetById(posting.Id);
    }

    public int Delete(int postingId)
    {
        return _repository.Delete(postingId);
    }

    private static float CalculatePrice(float weight, DeliveryType deliveryType)
    {
        var pricePerKg = deliveryType switch
        {
            DeliveryType.Department => 10f,
            DeliveryType.Courier => 20f,
            DeliveryType.ExpressCourier => 30f,
            _ => 10f
        };

        return weight * pricePerKg;
    }
}
