using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if(User?.Identity != null && User.Identity.IsAuthenticated == true)
            {
                return RedirectToAction("All","Books");
            }

            return View();
        }
    }
}