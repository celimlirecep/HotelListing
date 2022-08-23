using  HotelListing.API.Data.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace  HotelListing.API.Data.Abstract
{
    public interface IAuthManager 
    {
        Task<AuthResponseDTO> LoginAsync(LoginDTO model);
        Task<IEnumerable<IdentityError>> RegisterAsync(ApiUserDTO userDTO);
        Task<string> CreateRefreshTokenAsync();
        Task<AuthResponseDTO> VerifyRefreshTokenAsync(AuthResponseDTO request);
    }
}
