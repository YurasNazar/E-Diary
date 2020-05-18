using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace EDiary.Controllers
{
    public class BaseController : Controller
    {
        protected virtual JsonResult CreateJsonResult(bool success, object data = null,
            string message = null, string returnUrl = null)
        {
            return Json(new { success, data, message, returnUrl }, new JsonSerializerOptions { PropertyNamingPolicy = null });
        }
    }
}
