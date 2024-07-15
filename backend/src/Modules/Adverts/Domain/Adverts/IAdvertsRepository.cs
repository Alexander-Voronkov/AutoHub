namespace AutoHub.Modules.Adverts.Domain.Adverts;

public interface IAdvertsRepository
{
    Task AddAsync(Advert advert);

    Task<Advert> GetByIdAsync(AdvertId id);
}