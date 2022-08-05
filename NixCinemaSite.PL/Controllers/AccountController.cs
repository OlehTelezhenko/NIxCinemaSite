using Microsoft.AspNetCore.Mvc;
using NixCinemaSite.BLL.Intefaces;
using NixCinemaSite.BLL.ModelsDTO;

namespace NixCinemaSite.PL.Areas.Admin.Controllers
{
    [Controller]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountServise;
        public AccountController(IAccountService accountServise)
        {
            _accountServise = accountServise;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                await _accountServise.Register(userDTO);
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            return View(userDTO);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (ModelState.IsValid)
            {
                await _accountServise.Login(loginDTO);
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            return View(loginDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await _accountServise.LogOut();
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
