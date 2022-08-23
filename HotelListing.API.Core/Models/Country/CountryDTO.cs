using  HotelListing.API.Data.Models.Hotel;

namespace  HotelListing.API.Data.Models.Country
{
    public class CountryDTO:BaseCountryDTO
    {
        public int Id { get; set; }
        public List<HotelDTO> Hotels { get; set; }
    }
}
