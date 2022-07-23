using Microsoft.AspNetCore.Mvc;
using NixCinemaSite.BLL.Intefaces;
using NixCinemaSite.BLL.ModelsDTO;

namespace NixCinemaSite.PL.Controllers
{
    [Controller]
    public class GenreController : Controller
    {
        private readonly IPresentationGenreService _presentationGenreService;
        public GenreController(IPresentationGenreService presentationGenreService)
        {
            _presentationGenreService = presentationGenreService;
        }

        [HttpGet("Genre/Index/")]
        [HttpGet("Genre/Index/{sortOrder}")]
        [HttpGet("Genre/Index/{sortOrder}/{currentPage}")]
        [HttpGet("Genre/Index/{sortOrder}/{currentPage}/{searchString}")]
        public ActionResult Index(string? sortOrder, int? currentPage, string searchString)
        {
            var page = _presentationGenreService.GetPageAfterPagination(sortOrder, currentPage, searchString);
            return View(page);
        }

        [HttpGet]
        public ActionResult Details(Guid id)
        {
            return View(_presentationGenreService.Details(id));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GenreDTO genre)
        {
            try
            {
                _presentationGenreService.Create(genre);
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
            return View(_presentationGenreService.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, GenreDTO genre)
        {
            try
            {
                _presentationGenreService.Edit(genre);
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
            return View(_presentationGenreService.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(GenreDTO genre)
        {
            try
            {
                _presentationGenreService.Delete(genre.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        [Route("genre/get/{input}")]
        public ActionResult get(string input)
        {
            try
            {
                var a = Guid.Parse(input);
                return Ok(_presentationGenreService.GetById(a));
            }
            catch (Exception)
            {
                return Ok(_presentationGenreService.Find(input));
            }
        }
    }
}
