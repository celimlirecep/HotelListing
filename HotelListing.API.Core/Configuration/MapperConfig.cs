using AutoMapper;
using  HotelListing.API.Data;
using  HotelListing.API.Data.Models.Country;
using  HotelListing.API.Data.Models.Hotel;
using  HotelListing.API.Data.Models.Users;

namespace  HotelListing.API.Data.Configuration
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
