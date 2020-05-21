using Microsoft.AspNetCore.Mvc;

namespace EDiary.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public ActionResult Index() 
        {
            return View();
        }
    }
}
