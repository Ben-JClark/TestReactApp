using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace TestReactApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopController : ControllerBase
    {
        public static Shop _shop = new Shop();
        

        [HttpGet(Name = "GetShop")]
        public ActionResult<Shop> Get()
        {
            return Ok(_shop);
        }
    }
}
