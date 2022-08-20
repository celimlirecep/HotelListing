using HotelListing.API.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace HotelListing.API.Abstract
{
    public interface IAuthManager 
    {
        Task<bool> Login(LoginDTO model);
        Task<IEnumerable<IdentityError>> RegisterAsync(ApiUserDTO userDTO);
    }
}
