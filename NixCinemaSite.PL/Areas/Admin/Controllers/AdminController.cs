 using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NixCinemaSite.PL.Areas.Admin.Controllers
{
    [Controller]
    [Area("Admin")]
    [Authorize(Roles = "Moderator, Admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
