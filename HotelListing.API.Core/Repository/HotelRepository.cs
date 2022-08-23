using AutoMapper;
using  HotelListing.API.Data.Abstract;
using  HotelListing.API.Data;

namespace  HotelListing.API.Data.Repository
{
    public class HotelRepository:GenericRepository<Hotel>,IHotelRepository
    {
        public HotelRepository(HotelListingDbContext context,IMapper mapper):base(context,mapper)
        {
            
        }
    }
}
