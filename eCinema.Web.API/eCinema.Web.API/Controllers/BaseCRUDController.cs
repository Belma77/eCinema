using eCinema.Services.CRUDservice;
using eCInema.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AuthorizeAttribute = eCinema.Web.API.Auth.CustomAuthorizeAttribute;

namespace eCinema.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(UserRole.Admin)]

    public class BaseCRUDController< Tmodel, TSearchObject, TInsert, TUpdate> : 
    BaseController<Tmodel, TSearchObject>
    where Tmodel:class where TSearchObject : class where TInsert : class where TUpdate:class
    {
        public BaseCRUDController(IBaseCRUDService<Tmodel,TSearchObject, TInsert, TUpdate> service):base(service)
        {

        }      

        [HttpPost]
        public virtual IActionResult Insert(TInsert insert)
        {
            return Ok(((IBaseCRUDService<Tmodel, TSearchObject, TInsert, TUpdate>)this._service).Insert(insert));
        }

        [HttpPut("{id}")]
        public virtual IActionResult Update(int id, TUpdate update)
        {
            return Ok(((IBaseCRUDService<Tmodel, TSearchObject, TInsert, TUpdate>)this._service).Update(id,update));
        }

        [HttpDelete("{id}")]
        public virtual IActionResult Delete(int id)
        {
            return Ok(((IBaseCRUDService<Tmodel, TSearchObject, TInsert, TUpdate>)this._service).Delete(id));
        }
    }
}
