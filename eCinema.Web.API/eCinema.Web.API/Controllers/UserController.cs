using eCinema.Services.UserServices;
using eCInema.Models.Dtos.Users;
using eCInema.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using eCInema.Models.SearchObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AuthorizeAttribute = eCinema.Web.API.Auth.CustomAuthorizeAttribute;

namespace eCinema.Web.API.Controllers
{
    [Route("User")]
    [ApiController]
    [Authorize(UserRole.Admin)]
    public class UserController : BaseCRUDController<UserDto, UserSearchObject, UserInsertDto, UserUpdateDto>
    {
        public UserController(IUserService service):base(service)
        {
            
        }

        [AllowAnonymous]
        public override IActionResult Insert(UserInsertDto insert)
        {
            return base.Insert(insert);
        }

      

    }
}
