using AutoMapper;
using HotelListing.API.Data;
using HotelListing.API.Models.Country;
using HotelListing.API.Models.Hotel;
using HotelListing.API.Models.Users;

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

            #region User Mapping
            CreateMap<ApiUser, ApiUserDTO>().ReverseMap();
            #endregion
        }
    }
}
