using AutoHub.Modules.Adverts.Domain.Adverts;

namespace AutoHub.Modules.Adverts.Infrastructure.Domain.Adverts;

internal class AdvertsRepository : IAdvertsRepository
{
    private readonly AdvertsContext _advertsContext;

    internal AdvertsRepository(AdvertsContext advertsContext)
    {
        _advertsContext = advertsContext;
    }

    public async Task AddAsync(Advert advert)
    {
        await _advertsContext.Adverts.AddAsync(advert);
    }

    public async Task<Advert> GetByIdAsync(AdvertId id)
    {
        return await _advertsContext.Adverts.FindAsync(id);
    }
}
