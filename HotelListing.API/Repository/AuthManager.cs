using AutoMapper;
using HotelListing.API.Abstract;
using HotelListing.API.Data;
using HotelListing.API.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace HotelListing.API.Repository
{
    public class AuthManager : IAuthManager
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApiUser> _user;

        public AuthManager(IMapper mapper,UserManager<ApiUser> user)
        {
            this._mapper = mapper;
            this._user = user;
        }
        public async Task<IEnumerable<IdentityError>> RegisterAsync(ApiUserDTO userDTO)
        {
            var user = _mapper.Map<ApiUser>(userDTO);
            user.UserName = userDTO.Email;
            var result =await  _user.CreateAsync(user,userDTO.PassWord);
            if (result.Succeeded)
            {
             result = await _user.AddToRoleAsync(user, "User");
            }
            return result.Errors;
        }
    }
}
