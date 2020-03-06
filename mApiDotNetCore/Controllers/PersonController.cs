using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Service.interfaces;

namespace mApiDotNetCore.Controllers
{
    [ApiController, Route("[controller]")]
    public class PersonController : GenericController<Person>
    {
        public PersonController(IServiceGeneric<Person> service) : base(service)
        {
        }
    }
}