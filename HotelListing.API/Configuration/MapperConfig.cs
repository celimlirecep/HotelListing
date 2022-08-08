using AutoMapper;
using HotelListing.API.Data;
using HotelListing.API.Models.Country;
using HotelListing.API.Models.Hotel;

namespace HotelListing.API.Configuration
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            #region Country Mapping
            CreateMap<Country,CreateCountryDTO>().ReverseMap();
            CreateMap<Country,GetCountryDTO>().ReverseMap();
            CreateMap<Country,CountryDTO>().ReverseMap();
            CreateMap<Country,UpdateCountryDTO>().ReverseMap();
            #endregion

            #region Hotel Mapping
            CreateMap<Hotel, HotelDTO>().ReverseMap();
            #endregion
        }
    }
}
