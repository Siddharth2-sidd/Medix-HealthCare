using Microsoft.AspNetCore.Mvc;

namespace Medix_HealthCare.Backend.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
