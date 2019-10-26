using Microsoft.AspNetCore.Mvc;

namespace BidMyMechanic.Web.Controllers
{
    public class UserController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}