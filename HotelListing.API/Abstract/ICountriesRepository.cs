using HotelListing.API.Data;

namespace HotelListing.API.Abstract
{
    public interface ICountriesRepository: IGenericRepository<Country>
    {
        Task<Country> GetDetails(int id);
    }
}
