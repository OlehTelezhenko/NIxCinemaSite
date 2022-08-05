using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NixCinemaSite.BLL.Intefaces;
using NixCinemaSite.BLL.ModelsDTO;

namespace NixCinemaSite.PL.Areas.Admin.Controllers
{
    [Controller]
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUsersService _presentationUsersService;
        public UserController(IUsersService presentationUsersService)
        {
            _presentationUsersService = presentationUsersService;
        }

        [HttpGet("User/Index")]
        [HttpGet("User/Index/{sortOrder?}")]
        [HttpGet("User/Index/{sortOrder?}/{currentPage?}")]
        [HttpGet("User/Index/{sortOrder?}/{currentPage?}/{searchString?}")]
        public async Task<ActionResult> Index(string? sortOrder, int? currentPage, string searchString)
        {
            var page = await _presentationUsersService.GetPageAfterPaginationAsync(sortOrder, currentPage, searchString);
            return View(page);
        }

        // GET: UserController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(Guid id)
        {
            var a = await _presentationUsersService.DetailsAsync(id);
            return View(a);
        }

        //GET: UserController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserWithRolesDTO user)
        {
            try
            {
                await _presentationUsersService.CreateAsync(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            var a = await _presentationUsersService.DetailsAsync(id);
            return View(a);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserWithRolesDTO user)
        {

            try
            {
                await _presentationUsersService.EditAsync(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
                //return View();
            }
        }

        [HttpGet]
        public async Task<ActionResult> Delete(Guid id)
        {
            return View(await _presentationUsersService.GetByIdAsync(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(UserWithRolesDTO user)
        {
            try
            {
                await _presentationUsersService.DeleteAsync(user.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
