using eCinema.Services.CRUDservice;
using eCInema.Models.Dtos.Users;
using eCInema.Models.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Services.UserServices
{
    public interface IUserService:IBaseCRUDService<UserDto, UserSearchObject, UserInsertDto, UserUpdateDto>
    {
        UserDto Login(UserLoginDto login);
    }
}
