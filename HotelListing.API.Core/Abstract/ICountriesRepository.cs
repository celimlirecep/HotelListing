using  HotelListing.API.Data;

namespace  HotelListing.API.Core.Abstract
{
    public interface ICountriesRepository: IGenericRepository<Country>
    {
        Task<Country> GetDetails(int id);
    }
}
