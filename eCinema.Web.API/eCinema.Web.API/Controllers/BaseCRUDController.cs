﻿using eCinema.Services.CRUDservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCinema.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

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
        public IActionResult Update(int id, TUpdate update)
        {
            return Ok(((IBaseCRUDService<Tmodel, TSearchObject, TInsert, TUpdate>)this._service).Update(id,update));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(((IBaseCRUDService<Tmodel, TSearchObject, TInsert, TUpdate>)this._service).Delete(id));
        }
    }
}
