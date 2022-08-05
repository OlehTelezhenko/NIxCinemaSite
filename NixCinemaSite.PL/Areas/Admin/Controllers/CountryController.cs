using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NixCinemaSite.BLL.Intefaces;
using NixCinemaSite.BLL.ModelsDTO;

namespace NixCinemaSite.PL.Areas.Admin.Controllers
{
    [Controller]
    [Area("Admin")]
    [Authorize(Roles = "Moderator, Admin")]
    public class CountryController : Controller
    {
        private readonly ICountryService _presentationCountryService;
        public CountryController(ICountryService presentationCountryService)
        {
            _presentationCountryService = presentationCountryService;
        }

        [HttpGet("Admin/Country/Index")]
        [HttpGet("Admin/Country/Index/{sortOrder?}")]
        [HttpGet("Admin/Country/Index/{sortOrder?}/{currentPage?}")]
        [HttpGet("Admin/Country/Index/{sortOrder?}/{currentPage?}/{searchString?}")]
        public ActionResult Index(string? sortOrder, int? currentPage, string searchString)
        {
            var page = _presentationCountryService.GetPageAfterPagination(sortOrder, currentPage, searchString);
            return View(page);
        }

        [HttpGet]
        // GET: CourseController/Details/5
        public ActionResult Details(Guid id)
        {
            return View(_presentationCountryService.Details(id));
        }
        [HttpGet]
        // GET: CourseController/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CountryDTO country)
        {
            try
            {
                _presentationCountryService.Create(country);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Edit/5
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            return View(_presentationCountryService.GetById(id));
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, CountryDTO country)
        {
            try
            {
                _presentationCountryService.Edit(country);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Delete/5
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            return View(_presentationCountryService.GetById(id));
        }

        // POST: CourseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, CountryDTO country)
        {
            try
            {
                _presentationCountryService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        [Route("country/get/{input}")]
        public ActionResult get(string input)
        {
            try
            {
                var a = Guid.Parse(input);
                return Ok(_presentationCountryService.GetById(a));
            }
            catch (Exception)
            {
                return Ok(_presentationCountryService.Find(input));
            }
        }
    }
}
