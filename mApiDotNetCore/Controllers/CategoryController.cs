using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Service.interfaces;

namespace mApiDotNetCore.Controllers
{
    [ApiController, Route("[controller]")]
    public class CategoryController : GenericController<Category>
    {
        public CategoryController(IServiceGeneric<Category> service) : base(service)
        {
        }
    }
}
