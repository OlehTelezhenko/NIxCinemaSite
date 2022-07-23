using Microsoft.AspNetCore.Mvc;
using NixCinemaSite.BLL.Intefaces;
using NixCinemaSite.BLL.ModelsDTO;

namespace NixCinemaSite.PL.Controllers
{
    [Controller]
    public class PersonController : Controller
    {private readonly IPresentationPersonService _presentationPersonService;

        public PersonController(IPresentationPersonService presentationPersonService)
        {
            _presentationPersonService = presentationPersonService;
        }

        [HttpGet("Person/Index/")]
        [HttpGet("Person/Index/{sortOrder}")]
        [HttpGet("Person/Index/{sortOrder}/{currentPage}")]
        [HttpGet("Person/Index/{sortOrder}/{currentPage}/{searchString}")]
        public ActionResult Index(string? sortOrder, int? currentPage, string searchString)
        {
            var page = _presentationPersonService.GetPageAfterPagination(sortOrder, currentPage, searchString);
            return View(page);
        }

        [HttpGet]
        public ActionResult Details(Guid id)
        {
            return View(_presentationPersonService.Details(id));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonDTO person)
        {
            try
            {
                _presentationPersonService.Create(person);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            return View(_presentationPersonService.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, PersonDTO person)
        {
            try
            {
                _presentationPersonService.Edit(person);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            return View(_presentationPersonService.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(PersonDTO person)
        {
            try
            {
                _presentationPersonService.Delete(person.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        [Route("person/get/{input}")]
        public ActionResult get(string input)
        {
            try
            {
                var a = Guid.Parse(input);
                return Ok(_presentationPersonService.GetById(a));
            }
            catch (Exception)
            {
                return Ok(_presentationPersonService.Find(input));
            }
        }
    }
}
