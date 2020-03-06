using Microsoft.AspNetCore.Mvc;
using Model.Interfaces;
using Service.interfaces;
using System.Collections.Generic;

namespace mApiDotNetCore.Controllers
{
    [ApiController, Route("[controller]")]
    public class GenericController<T> : Controller where T : class, IEntity
    {
        private IServiceGeneric<T> _service;

        public GenericController(IServiceGeneric<T> service)
        {
            _service = service;
        }
        
        [HttpGet]
        public virtual List<T> GetAll()
        {
            return _service.GetAll();
        }

        [HttpPost]
        public virtual IActionResult Add(T cat)
        {
            var res = _service.Create(cat);
            if(res != null)
            {
                return Ok(res);
            }
            return BadRequest("Cannot add movie in db, check payload");
        }
    }
}